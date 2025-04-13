using FightCons.CoreNSettings;
using FightCons.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FightCons
{
    class CombatSolutionsParty
    {
        //  Боевые решения
        private static sbyte BattleChoice;
        private static bool SkipTurn;
        private static bool QuickCommandDone = false;

        private static string[] AvailableSkillsStr = new string[6];
        private static List<Action<Character, Character, List<Order>>> AvailableSkillsList = new List<Action<Character, Character, List<Order>>>();
        private static List<Action<sbyte, Character, Character, List<Order>>> AvailableQuickBattleSkillsList = new List<Action<sbyte, Character, Character, List<Order>>>();

        public static void CurrentEnemy(Character character, List<Order> units, List<BattleScenarioEvent> scenario = null)
        {
            Battles.BattleMap(character, units);

            SkipTurn = ConditionCheck(character);

            if (units.Count == 1 || SkipTurn)
                FightChoice(character, units.FirstOrDefault().character);
            else
            {
                Console.WriteLine("\nВыберите противника");

                LoadListOfUnits(units, character.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active);

                //  Выбор юнита из списка
                var ch = Input.ChoisInput(0, (sbyte)units.Count());
                foreach (var enemy in units)
                {
                    if (enemy.character.Id == ch & enemy.character.TotalHP > 0 & !enemy.character.Condition.LeavedBattle)
                    {
                        Console.WriteLine();
                        FightChoice(character, enemy.character, units);
                    }
                }
            }
        }

        //  Боевые решения
        private static void FightChoice(Character character, Character unit, List<Order> units = null, List<BattleScenarioEvent> scenario = null)
        {
            AllHeroSkills.Skills(character, unit);

            bool[] skillAccess = new bool[]
            {
                character.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active,    //  Узнать о противнике
                true,                               //  Нападение
                true,                               //  Заклинания
                true,                               //  Способности   /*hero.Statistic.SpecialSkills[1],*/
                true,                               //  Выпить зелье
                true,                               //  Обороняться
                true,                               //  Убежать
            };

            AvailableSkillsStr = AvailableSkillsOutput(character, skillAccess);

            AvailableSkillsList = AvailableSkills(skillAccess);
            AvailableQuickBattleSkillsList = AvailableQuickBattleSkills(skillAccess);

            BattleChoice = 0;

            //  Раскоментировать после успеха
            //BattleScenarioEvent.CheckBattleScenario(character, units, scenario);
            character.Condition.AttackParry = false;

            //  Информация
            ShowBattleInfo(character, unit, units);

            if (!SkipTurn)
            {
                // Выбор боевых действий
                sbyte av = 0;
                Console.Write("Ваши действия?\n");

                for (short i = 0; i < AvailableSkillsStr.Length; i++)
                {
                    if (!skillAccess[0] && i == 0)
                        av++;

                    if (AvailableSkillsStr[i] != "")
                    {

                        Console.Write($"{av}) {AvailableSkillsStr[i]}\n");
                        av++;
                    }

                }

                //  Смена выбранного противника
                if (units != null)
                {
                    if (skillAccess[0])
                        Console.Write($"{AvailableSkillsList.Count}) Назад\n");// 0 - t
                    else
                        Console.Write($"{AvailableSkillsList.Count + 1}) Назад\n"); // 0 - f
                }


                if (units == null && skillAccess[0])
                    BattleChoice = BattleChoiceInput(0, (sbyte)AvailableSkillsList.Count, character, unit, units);
                else if (units == null && !skillAccess[0])
                    BattleChoice = BattleChoiceInput(1, (sbyte)AvailableSkillsList.Count, character, unit, units);

                else if (!skillAccess[0])
                    BattleChoice = BattleChoiceInput(1, (sbyte)(AvailableSkillsList.Count + 1), character, unit, units); // 0 - f
                else
                    BattleChoice = BattleChoiceInput(0, (sbyte)(AvailableSkillsList.Count), character, unit, units);  // 0 - t

                if (!QuickCommandDone)
                {
                    //  Вызов соответствующей категории способностей (1-5)
                    if (skillAccess[0] && BattleChoice < AvailableSkillsList.Count) // 0 - f <
                        AvailableSkillsList[BattleChoice](character, unit, units);

                    else if (!skillAccess[0] && BattleChoice <= AvailableSkillsList.Count && BattleChoice > 0)
                        AvailableSkillsList[BattleChoice - 1](character, unit, units);   // 0 - f
                }

                //  Выбрать другого противника
                if (BattleChoice == AvailableSkillsList.Count && skillAccess[0])
                    CurrentEnemy(character, units);
                else if (BattleChoice == AvailableSkillsList.Count + 1 && !skillAccess[0])
                    CurrentEnemy(character, units);

                /*  Старый функ
                if (!QuickCommandDone)
                {
                    
                     * switch (BattleChoice)
                    //{
                    //    /*  Пока не трогаем!!!
                    //    //case 0:
                    //    //    if (hero.CharacterProfile.EnemyAbout)
                    //    //        InformationAboutUnit(hero, unit, units);
                    //    //    else
                    //    //        FightChoice(hero, unit, units);
                    //    //    break;
                    //    //case 1:
                    //    //    AttackList(hero, unit, units);
                    //    //    break;

                    //    //case 2:
                    //    //    SpellList(hero, unit, units);
                    //    //    break;

                    //    //case 3:
                    //    //    PotionList(hero, unit, units);
                    //    //    break;

                    //    //case 4:
                    //    //    Protection(hero, unit, units);
                    //          break;

                    //      case 5:
                    //        Battles.RunFromBattle(hero, unit);
                    //        break;


                    //    case 6:
                            
                    //        //else
                    //        //    Battles.RunFromBattle(hero, unit);
                    //        break;
                    //}
                }*/
            }

            //  Метод учета ходов и обнуление состояний
            MovesTracker(character, unit);

            //  Минус от эффектов
            NegativeEffectImpact(character, unit);
        }

        //TODO Добавить описания отмены использования зелий
        /*  Старый метод. Временно оставить на несколько версий вперед
        private static bool QuickBattleInput(Hero hero, Character unit, List<Order> units = null)
        {
            if (BattleChoice > 10)
            {
                if (BattleChoice <= 19)
                {
                    BattleChoice -= 10;
                    if (BattleChoice <= hero.AttackList.Count)
                    {
                        hero.AttackList[BattleChoice - 1].Attack(hero, unit);
                        QuickCommandDone = true;

                        return true;
                    }
                }
                else if (BattleChoice >= 19 & BattleChoice < 30)
                {
                    BattleChoice -= 20;
                    if (BattleChoice <= hero.SpellList.Count)
                    {
                        if (GameFormulas.CheckMana(hero, hero.SpellList[BattleChoice - 1].SpellСost))
                        {
                            var heroSpell = hero.SpellList[BattleChoice - 1];
                            heroSpell.Spell(hero, (Unit)unit, heroSpell.SpellСost, heroSpell.SpellPower);
                            QuickCommandDone = true;

                            return true;
                        }
                        else
                        {
                            Output.TwriteLine("\nНедостаточно маны!\n", 1);
                            BattleChoice += 20;
                        }
                    }
                }
                else if (BattleChoice >= 31 & BattleChoice < 40)
                {
                    BattleChoice -= 30;
                    if (BattleChoice <= hero.PotionList.Count)
                    {
                        hero.PotionList[BattleChoice - 1].Drink(hero);
                        QuickCommandDone = true;

                        return true;
                    }
                }
            }

            return false;
        }
        */
        private static bool QuickBattleInput(Character character, Character unit, List<Order> units = null)
        {
            sbyte firstD = BattleChoice;
            sbyte secondD = (sbyte)(BattleChoice % 10);

            while (firstD >= 10)
                firstD = (BattleChoice /= 10);

            if (firstD <= AvailableQuickBattleSkillsList.Count)
            {
                AvailableQuickBattleSkillsList[firstD - 1](secondD, character, unit, units);
                QuickCommandDone = true;

                return true;
            }

            Console.WriteLine("ОШИБКА! Быстрый набор команды отключен");
            return false;
        }

        #region Отображение боевоей информации
        private static void ShowBattleInfo(Character сharacter, Character unit, List<Order> units = null)
        {
            //  Отрисовка hp противника
            unit.DifferentHpBar();

            //TODO раскоментировать когда мп будет тратиться
            //  Отрисовка mp противника
            //if (hero.CharacterProfile.EnemyAbout)
            //    unit.MPBar();

            Console.WriteLine();

            if (units != null)
                TurnsOrderOutput();

            //  Эксперементальная мера
            //Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "| ############################################################################ |", "");

            //  Отрисовка негативных эффектов, hp и mp игрока 
            NegativeEffectView(сharacter, unit);

            сharacter.HPnMPBar(true, true);
        }

        //  Узнать о противнике
        private static void InformationAboutUnit(Character character, Character unit, List<Order> units = null)
        {
            Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "##################################    Инфо    ##################################", "\n");
            Output.WriteColorLine(ConsoleColor.DarkMagenta, "Имя: ", $"{unit.Name}", "\n");

            unit.HPnMPBar(true, true);

            /*  Старый сегмент
            //if (unit.CharacterProfile.Phase >= 2)
            //    unit.PhaseHPBar();
            //else
            //    unit.HPBar();
            //unit.MPBar();
            */

            /*  Временно скрытый сегмент
            //Console.WriteLine();

            //ItemChar.Comparison(unit.TotalAttack, hero.TotalAttack, $"{Output.AttackStr}: ");
            //ItemChar.Comparison(unit.TotalArcane, hero.TotalArcane, $"{Output.ArcaneStr}: ");

            //ItemChar.Comparison(unit.TotalDefence, hero.TotalDefence, $"{Output.DefenceStr}: ", true);
            //ItemChar.Comparison(unit.TotalMagicDefence, hero.TotalMagicDefence, $"{Output.MagicDefenceStr}: ", true);

            //ItemChar.Comparison(unit.TotalMaxMoves, hero.TotalSpeed, $"{Output.SpeedStr}: ", true);
            //ItemChar.Comparison(unit.TotalMaxMoves, hero.TotalCrit, $"{Output.CritStr}: ", true);

            //ItemChar.Comparison(unit.TotalAttack, hero.TotalBlock, $"{Output.BlockStr}: ", true);
            */

            Console.WriteLine($"{Output.AttackStr}: {unit.TotalAttack}\t\t{Output.ArcaneStr}: {unit.TotalArcane}\n"
                           + $"{Output.DefenceStr}: {unit.TotalDefense * 100}%\t\t{Output.MagicDefenceStr}: {unit.TotalMagicDefense * 100}%\n"
                           + $"{Output.SpeedStr}: {unit.TotalSpeed * 100}%\t{Output.CritStr}: {unit.TotalCrit * 100}%\n"
                           + $"{Output.BlockStr}: {unit.TotalBlock * 100}%\n");

            Output.WriteColorLine(ConsoleColor.Cyan, "Экипировано оружие:\n", $"{unit.CharacterWeapon.Name} ", $"| {ItemChar.ItemStats(unit.CharacterWeapon, false)}");
            Output.WriteColorLine(ConsoleColor.Cyan, "\nЭкипирована броня:\n", $"{unit.CharacterArmor.Name} ", $"| {ItemChar.ItemStats(unit.CharacterArmor, false)}\n");

            Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "################################################################################", "\n");

            Console.ReadKey();
        }

        /*  Атаки (старая версия)
        private static void AttackList(Hero hero, Character unit, List<Order> units = null)
        {


            Console.Write("Ваши действия?\n"
                      + $"X) Нападение\n");

            Console.Write($"  0) Назад\n");
            foreach (var sk in hero.AttackList)
            {
                Console.WriteLine($"  {sk.ID}) {sk.Description}");
            }

            Console.Write($"X) Заклинания\n"
                      + $"X) Выпить зелье\n"
                      + $"X) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n"
                      + $"X) Убежать\n");

            BattleChoice = Input.ChoisInput(0, (sbyte)(hero.AttackList.Count));
            if (BattleChoice != 0)
                hero.AttackList[BattleChoice - 1].Attack(hero, unit);
            else
                FightChoice(hero, unit, units);
        }
        */

        //  Атаки
        private static void AttackList(Character character, Character unit, List<Order> units = null)
        {
            Console.Write("Ваши действия?\n");
            for (short i = 0; i < AvailableSkillsStr.Length; i++)
            {
                if (i == 2)
                {
                    Console.Write($"  0) Назад\n");
                    foreach (var sk in character.AttackList)
                    {
                        Console.WriteLine($"  {sk.ID}) {sk.Description}");
                    }
                }
                if (AvailableSkillsStr[i] != "")
                    Console.Write($"X) {AvailableSkillsStr[i]}\n");
            }

            BattleChoice = Input.ChoisInput(0, (sbyte)(character.AttackList.Count));
            if (BattleChoice != 0)
                character.AttackList[BattleChoice - 1].AttackParty(character, unit);
            else
                FightChoice(character, unit, units);
        }

        //  Быстрый набор Атаки
        private static void QuickBattleAttackInput(sbyte id, Character character, Character unit, List<Order> units = null)
        {
            if (id != 0 && id <= character.AttackList.Count)
                character.AttackList[id - 1].AttackParty(character, unit);
            else
                FightChoice(character, unit, units);
        }

        //  Заклинания
        private static void SpellList(Character character, Character unit, List<Order> units = null)
        {
            Console.Write("Ваши действия?\n");
            for (short i = 0; i < AvailableSkillsStr.Length; i++)
            {
                if (i == 3)
                {
                    Console.Write($"  0) Назад\n");
                    foreach (var sp in character.SpellList)
                    {
                        Console.WriteLine($"  {sp.ID}) {sp.Description}");
                    }
                }
                if (AvailableSkillsStr[i] != "")
                    Console.Write($"X) {AvailableSkillsStr[i]}\n");
            }

            BattleChoice = Input.ChoisInput(0, (sbyte)(character.SpellList.Count));
            if (BattleChoice != 0)
            {
                if (GameFormulas.CheckMana(character, character.SpellList[BattleChoice - 1].SpellСost))
                {
                    var heroSpell = character.SpellList[BattleChoice - 1];
                    heroSpell.SpellParty(character, (Unit)unit, heroSpell.SpellСost, heroSpell.SpellPower);
                }
                else
                {
                    Output.TwriteLine("\nНедостаточно маны!\n", 1);
                    FightChoice(character, unit, units);
                }
            }
            else
                FightChoice(character, unit, units);
        }

        //  Быстрый набор Заклинания
        private static void QuickBattleSpellInput(sbyte id, Character character, Character unit, List<Order> units = null)
        {
            if (id != 0 && id <= character.SpellList.Count)
            {
                if (GameFormulas.CheckMana(character, character.SpellList[id - 1].SpellСost))
                {
                    var heroSpell = character.SpellList[id - 1];
                    heroSpell.SpellParty(character, (Unit)unit, heroSpell.SpellСost, heroSpell.SpellPower);
                }
                else
                {
                    Output.TwriteLine("\nНедостаточно маны!\n", 1);
                    FightChoice(character, unit, units);
                }
            }
            else
                FightChoice(character, unit, units);
        }

        //  Способности
        private static void SpecialList(Character character, Character unit, List<Order> units = null)
        {
            Console.Write("Ваши действия?\n");
            for (short i = 0; i < AvailableSkillsStr.Length; i++)
            {
                if (i == 4)
                {
                    Console.Write($"  0) Назад\n");
                    foreach (var sk in character.SpecialList)
                    {
                        Console.WriteLine($"  {sk.ID}) {sk.Description}");
                    }
                }
                if (AvailableSkillsStr[i] != "")
                    Console.Write($"X) {AvailableSkillsStr[i]}\n");
            }

            BattleChoice = Input.ChoisInput(0, (sbyte)(character.SpecialList.Count));
            if (BattleChoice != 0)
                character.SpecialList[BattleChoice - 1].SpecialsParty(character, unit);
            else
                FightChoice(character, unit, units);
        }

        //  Быстрый набор способностей
        private static void QuickBattleSpecialInput(sbyte id, Character character, Character unit, List<Order> units = null)
        {
            if (id != 0 && id <= character.SpecialList.Count)
                character.SpecialList[id - 1].SpecialsParty(character, unit);
            else
                FightChoice(character, unit, units);
        }

        //  Зелья
        private static void PotionList(Character character, Character unit, List<Order> units = null)
        {
            Console.Write("Ваши действия?\n");
            for (short i = 0; i < AvailableSkillsStr.Length; i++)
            {
                if (i == 5)
                {
                    Console.Write($"  0) Назад\n");
                    foreach (var p in character.PotionList)
                    {
                        if (p.Count > 0)
                            Console.WriteLine($"  {p.ID}) {p.Description} {p.CountPotion}");
                        else
                            Output.WriteColorLine(ConsoleColor.DarkGray, "  ", $"{p.ID}) {p.Description} {p.CountPotion}\n");
                    }
                }
                if (AvailableSkillsStr[i] != "")
                    Console.Write($"X) {AvailableSkillsStr[i]}\n");
            }

            BattleChoice = Input.ChoisInput(character, 0, (sbyte)(character.PotionList.Count));
            if (BattleChoice != 0 && character.PotionList[BattleChoice - 1].Count > 0)
                character.PotionList[BattleChoice - 1].Drink(character);
            else
                FightChoice(character, unit, units);
        }

        //  Быстрый набор Зелья
        private static void QuickBattlePotionInput(sbyte id, Character character, Character unit, List<Order> units = null)
        {
            if (id != 0 && id <= character.PotionList.Count && character.PotionList[id - 1].Count > 0)
                character.PotionList[id - 1].Drink(character);
            else
                FightChoice(character, unit, units);
        }

        //  Обороняться
        private static void Protection(Character character, Character unit, List<Order> units = null)
        {
            Output.NameAndId(character, true);
            Output.WriteColorLine(ConsoleColor.White, "держит ", "оборону", "\n");

            character.Condition.ShieldUp = true;
            character.Turn = character.TotalMaxMoves;
        }
        #endregion

        #region Отображение и методы

        private static void TurnsOrderOutput()
        {
            Console.Write("\n\t\t\t[");
            foreach (var t in Battles.UnitTurnList)
            {
                if (t.character.IsPlayer)
                    Output.WriteColorLine(Output.unitNameColor(t.character.Role), "", "Вы ", $"{string.Format("{0:0.00}", t.Speed)}");
                if (t.character.Condition.IsAlive & !t.character.IsPlayer)
                {
                    Output.WriteColorLine(Output.unitNameColor(t.character.Role), "", "# ", $"{string.Format("{0:0.00}", t.Speed)}");
                }
                if (Battles.UnitTurnList.Min(x => x.Speed) != t.Speed & t.character.Condition.IsAlive)
                    Console.Write(" | ");
            }

            Console.Write("]\n");
        }

        //  Учет ходов
        private static void MovesTracker(Character hero, Character unit)
        {
            hero.Turn++;
            hero.Condition.ShieldUp = false;
            QuickCommandDone = false;
        }

        //  Загрузка списка врагов для выбора
        //  Пока не меняем
        private static void LoadListOfUnits(List<Order> enemies, bool loadMP)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.character.TotalHP <= 0 | enemy.character.Condition.LeavedBattle)
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{enemy.character.Id}. {enemy.character.Name} [0/{enemy.character.TotalMaxHP}]\t");
                else
                {
                    Output.WriteColorLine(Output.unitNameColor(enemy.Role), $"{enemy.character.Id}. ", $"{enemy.character.Name}", "\t");

                    //enemy.character.HPnMPBar(true);

                    if (enemy.character.Phase >= 2)
                        enemy.character.PhaseHPBar();
                    else
                    {
                        if (loadMP)
                            Console.WriteLine();
                        enemy.character.HPBar(true);
                    }

                    if (loadMP)
                        enemy.character.MPBar();
                }
                Console.WriteLine();
            }
        }

        public static sbyte BattleChoiceInput(sbyte b1, sbyte b2, Character character, Character unit, List<Order> units = null)
        {
            do
            {
                BattleChoice = Input.SbyteInput();
                if (BattleChoice < 100 && BattleChoice > 10)
                    if (QuickBattleInput(character, unit, units))
                        break;

            }
            while (!(BattleChoice > b1 - 1 && BattleChoice < b2 + 1));
            return BattleChoice;
        }
        #endregion

        #region Негативыне эффекты
        //TODO Сделать отдельный список со всем негативными эффектами для удобного использования
        //  Отображение негативные эффекты
        private static void NegativeEffectView(Character hero, Character enemy)
        {
            if (hero.Condition.SlowRound > 0 || hero.Condition.PoisingRound > 0 || hero.Condition.FreesRound > 0)
            {
                Console.Write("\nУ вас эффект:\n");

                //  Замедление
                if (hero.Condition.SlowRound > 0)
                    Output.WriteColorLine(ConsoleColor.Blue, " ", "Замедление ", $" [-{hero.Condition.Moves} {Output.EffMovSymbol}] ({hero.Condition.SlowRound})\n");

                //  Заморозка
                if (hero.Condition.FreesRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, " ", "Заморозка ", $" ({hero.Condition.FreesRound})\n");

                //  Отравление
                if (hero.Condition.PoisingRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkGreen, " ", "Отравление ", $" [-{enemy.Condition.PoisingDmg} {Output.HPSymbol}] ({hero.Condition.PoisingRound})\n");
            }
            else
                Console.WriteLine();
        }

        //TODO Сделать отдельный список со всем негативными эффектами для удобного использования
        //  Вычитание негативные эффекты
        private static void NegativeEffectImpact(Character character, Character enemy)
        {
            if (character.Condition.SlowRound > 0 || character.Condition.PoisingRound > 0)
            {
                //  Замедление
                if (character.Condition.SlowRound > 0)
                    character.Condition.SlowRound--;

                //  Отравление
                if (character.Condition.PoisingRound > 0)
                {
                    character.Condition.PoisingRound--;
                    character.HP -= enemy.Condition.PoisingDmg;
                }
            }
        }

        //  Визуализация заморозки проверка ее наличия
        private static bool ConditionCheck(Character character)
        {
            //  Проверка на Замарозку
            if (character.Condition.FreesRound > 0)
            {
                //  На случай если список пуст
                if (AvailableSkillsList == null)
                {
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "",
                        $"Ваши действия?\n"
                        + "1) Нападение\n"
                        + "2) Заклинания\n"
                        + "3) Способности\n"
                        + "4) Выпить зелье\n"
                        + $"5) Обороняться ({character.TotalBlock * 100}% {Output.BlockStr})\n"
                        + $"6) Убежать\n");
                }
                else
                {
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "\n", $"Ваши действия?\n");
                    for (short i = 0; i < AvailableSkillsStr.Length; i++)
                    {
                        if (AvailableSkillsStr[i] != "")
                            Output.WriteColorLine(ConsoleColor.DarkBlue, "", $"{i}) {AvailableSkillsStr[i]}\n");
                    }
                }

                character.Condition.FreesRound--;
                Thread.Sleep(400);

                Console.ReadKey();
                return true;
            }
            return false;
        }
        #endregion

        #region Настройки 
        //  Добавление способностей в список доступных способностей 
        private static List<Action<Character, Character, List<Order>>> AvailableSkills(bool[] skillAccess)
        {
            List<Action<Character, Character, List<Order>>> mas = new List<Action<Character, Character, List<Order>>>();

            //  Узнать о противнике
            if (skillAccess[0])
                mas.Add(InformationAboutUnit);

            //  Нападение
            if (skillAccess[1])
                mas.Add(AttackList);

            //  Заклинания
            if (skillAccess[2])
                mas.Add(SpellList);

            //  Способности
            if (skillAccess[3])
                mas.Add(SpecialList);

            //  Выпить зелье
            if (skillAccess[4])
                mas.Add(PotionList);

            //  Обороняться
            if (skillAccess[5])
                mas.Add(Protection);

            //  Убежать
            if (skillAccess[6])
                mas.Add(Battles.RunFromBattle);

            return mas;
        }

        //  Добавление способностей быстрого набора в список доступных способностей быстрого нобора
        private static List<Action<sbyte, Character, Character, List<Order>>> AvailableQuickBattleSkills(bool[] skillAccess)
        {
            List<Action<sbyte, Character, Character, List<Order>>> mas = new List<Action<sbyte, Character, Character, List<Order>>>();

            //  Узнать о противнике
            //if (skillAccess[0])
            //    mas.Add(InformationAboutUnit);

            //  Нападение
            if (skillAccess[1])
                mas.Add(QuickBattleAttackInput);

            //  Заклинания
            if (skillAccess[2])
                mas.Add(QuickBattleSpellInput);

            //  Способности
            if (skillAccess[3])
                mas.Add(QuickBattleSpecialInput);

            //  Выпить зелье
            if (skillAccess[4])
                mas.Add(QuickBattlePotionInput);

            ////  Обороняться
            //if (skillAccess[5])
            //    mas.Add(Protection);

            ////  Убежать
            //if (skillAccess[6])
            //    mas.Add(Battles.RunFromBattle);

            return mas;
        }

        //  Добавление вывода доступных способностей
        private static string[] AvailableSkillsOutput(Character character, bool[] skillAccess)
        {
            string[] mas = new string[7];

            mas[0] = skillAccess[0] == true ? "Узнать о противнике" : "";

            mas[1] = skillAccess[1] == true ? "Нападение" : "";

            mas[2] = skillAccess[2] == true ? "Заклинания" : "";

            mas[3] = skillAccess[3] == true ? "Способности" : "";

            mas[4] = skillAccess[4] == true ? "Выпить зелье" : "";

            mas[5] = skillAccess[5] == true ? $"Обороняться ({character.TotalBlock * 100}% {Output.BlockStr})" : "";

            mas[6] = skillAccess[6] == true ? "Убежать" : "";

            //  Временно оставить
            //for (int i = 0; i < mas.Length; i++)
            //    AvailableSkillsStr[i] += mas[i];

            return mas;
        }

        #endregion
    }
}
