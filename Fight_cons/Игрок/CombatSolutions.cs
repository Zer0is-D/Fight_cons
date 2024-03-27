using Fight_cons.Основа_и_настройки;
using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Fight_cons
{
    class CombatSolutions
    {
        //  Боевые решения
        private static sbyte BattleChoise;
        private static bool QuickCommandDone = false;

        public static void CurrentEnemy(Hero hero, List<Order> units)
        {
            ConditionCheck(hero);

            if (units.Count == 1)
                FightChoice(hero, units.FirstOrDefault().charecter);
            else
            {
                Console.WriteLine("\nВыберите противника");

                LoadListOfUnits(units, hero.CharecterProfile.EnemyAbout);

                //  Выбор юнита из списка
                var ch = Input.ChoisInput(0, (sbyte)units.Count());
                foreach (var enemy in units)
                {
                    if (enemy.charecter.Id == ch & enemy.charecter.TotalHP > 0 & !enemy.charecter.Condition.LeavedBattle)
                    {
                        Console.WriteLine();
                        FightChoice(hero, enemy.charecter, units);
                    }
                }
            }            
        }

        //  Боевые решения
        private static void FightChoice(Hero hero, Charecter unit, List<Order> units = null)
        {
            AllHeroSkills.Skills(hero, unit);
            BattleChoise = 0;

            //  Информация
            ShowBattleInfo(hero, unit, units);

            // Выбор боевых действий
            Console.Write("Ваши действия?\n");

            if (hero.CharecterProfile.EnemyAbout)
                Console.Write("0) Узнать о противнике\n");

            Console.Write("1) Нападение\n"
                        + "2) Заклинания\n"
                        + "3) Выпить зелье\n"
                        + $"4) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n");
            if (units != null)
            {
                Console.Write($"5) Назад\n"
                + $"6) Убежать\n");
            }
            else
                Console.Write($"5) Убежать\n");

            if (units != null)
                BattleChoise = BattleChoisInput(0, 6, hero, unit, units);
            else
                BattleChoise = BattleChoisInput(0, 5, hero, unit, units);

            if (!QuickCommandDone)
            {
                switch (BattleChoise)
                {
                    case 0:
                        if (hero.CharecterProfile.EnemyAbout)
                            InformationAboutUnit(hero, unit);
                        else
                            FightChoice(hero, unit, units);
                        break;

                    case 1:
                        AttackList(hero, unit, units);
                        break;

                    case 2:
                        SpellList(hero, unit, units);
                        break;

                    case 3:
                        PotionList(hero, unit, units);
                        break;

                    case 4:
                        hero.Condition.SheeldUp = true;
                        hero.Turn = hero.TotalMaxMoves;
                        break;

                    case 5:
                        if (units != null)
                            CurrentEnemy(hero, units);
                        else
                            Battles.RunFromBattle(hero, unit);
                        break;
                    case 6:
                        Battles.RunFromBattle(hero, unit);
                        break;
                }
            }

            //  Метод учета ходов и обнуление состояний
            MovesTracker(hero, unit);

            //  Минус от эффектов
            NegativeEffectImpact(hero, unit);
        }

        public static sbyte BattleChoisInput(sbyte b1, sbyte b2, Hero hero, Charecter unit, List<Order> units = null)
        {
            do
            {
                BattleChoise = Input.SbyteInput();
                if (QuickBattleInput(hero, unit, units))
                    break;

            }
            while (!(BattleChoise > b1 - 1 && BattleChoise < b2 + 1));
            return BattleChoise;
        }

        private static bool QuickBattleInput(Hero hero, Charecter unit, List<Order> units = null)
        {
            if (BattleChoise > 10)
            {
                if (BattleChoise <= 19)
                {
                    BattleChoise -= 10;
                    if (BattleChoise <= hero.AttackList.Count)
                    {
                        hero.AttackList[BattleChoise - 1].Attack(hero, unit);
                        QuickCommandDone = true;

                        return true;
                    }
                }
                else if (BattleChoise >= 19 & BattleChoise < 30)
                {
                    BattleChoise -= 20;
                    if (BattleChoise <= hero.SpellList.Count)
                    {
                        if (GameFormulas.CheckMana(hero, hero.SpellList[BattleChoise - 1].SpellСost))
                        {
                            var heroSpell = hero.SpellList[BattleChoise - 1];
                            heroSpell.Spell(hero, (Unit)unit, heroSpell.SpellСost, heroSpell.SpellPower);
                            QuickCommandDone = true;

                            return true;
                        }
                        else
                        {
                            Output.TwriteLine("\nНедостаточно маны!\n", 1);
                            BattleChoise += 20;
                        }
                    }
                }
                else if (BattleChoise >= 31 & BattleChoise < 40)
                {
                    BattleChoise -= 30;
                    if (BattleChoise <= hero.PotionList.Count)
                    {
                        hero.PotionList[BattleChoise - 1].Drink(hero);
                        QuickCommandDone = true;

                        return true;
                    }
                }
            }

            return false;
        }

        #region Отображение боевоей информации
        private static void ShowBattleInfo(Hero hero, Charecter unit, List<Order> units = null)
        {
            //  Отрисовка hp противника
            Output.WriteColorName("\n", unit, ":");
            if (unit.CharecterProfile.Phase >= 2)
                unit.PhaseHPBar();
            else
                unit.HPBar();

            //  Отрисовка mp противника
            //if (hero.CharecterProfile.EnemyAbout)
            //    unit.MPBar();
            //Console.WriteLine();

            if (units != null)
                Turns();

            //  Отрисовка негативных эффектов, hp и mp игрока 
            NegativeEffectView(hero, unit);
            hero.HPBar();
            hero.MPBar();
        }

        //  Атаки
        private static void AttackList(Hero hero, Charecter unit, List<Order> units = null)
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

            BattleChoise = Input.ChoisInput(0, (sbyte)(hero.AttackList.Count));
            if (BattleChoise != 0)
                hero.AttackList[BattleChoise - 1].Attack(hero, unit);
            else
                FightChoice(hero, unit, units);
        }

        //  Заклинания
        private static void SpellList(Hero hero, Charecter unit, List<Order> units = null)
        {
            Console.Write("Ваши действия?\n"
                       + $"X) Нападение\n"
                       + $"X) Заклинания\n");

            Console.Write($"  0) Назад\n");
            foreach (var sp in hero.SpellList)
            {
                Console.WriteLine($"  {sp.ID}) {sp.Description}");
            }

            Console.Write($"X) Выпить зелье\n"
                      + $"X) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n"
                      + $"X) Убежать\n");

            BattleChoise = Input.ChoisInput(0, (sbyte)(hero.SpellList.Count));
            if (BattleChoise != 0)
            {
                if (GameFormulas.CheckMana(hero, hero.SpellList[BattleChoise - 1].SpellСost))
                {
                    var heroSpell = hero.SpellList[BattleChoise - 1];
                    heroSpell.Spell(hero, (Unit)unit, heroSpell.SpellСost, heroSpell.SpellPower);
                }
                else
                {
                    Output.TwriteLine("\nНедостаточно маны!\n", 1);
                    FightChoice(hero, unit, units);
                }
            }
            else
                FightChoice(hero, unit, units);
        }

        //  Зелья
        private static void PotionList(Hero hero, Charecter unit, List<Order> units = null)
        {
            Console.Write("Ваши действия?\n"
                                  + $"X) Нападение\n"
                                  + $"X) Заклинания\n"
                                  + $"X) Выпить зелье\n");

            Console.Write($"  0) Назад\n", 1);

            foreach (var p in hero.PotionList)
            {
                if (p.Count > 0)
                    Console.WriteLine($"  {p.ID}) {p.Description} {p.CountPotion}");
                else
                    Output.WriteColorLine(ConsoleColor.DarkGray, "  ", $"{p.ID}) {p.Description} {p.CountPotion}\n");
            }

            string quo = $"X) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n"
                      + $"X) Убежать\n";
            //Console.Write($"X) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n"
            //          + $"X) Убежать\n");

            BattleChoise = Input.ChoisInput(hero, 0, (sbyte)(hero.PotionList.Count), quo);
            if (BattleChoise != 0 && hero.PotionList[BattleChoise - 1].Count > 0)
                hero.PotionList[BattleChoise - 1].Drink(hero);
            else
                FightChoice(hero, unit, units);
        }
        #endregion

        #region Отображение и методы
        //  Узнать о противнике
        private static void InformationAboutUnit(Charecter hero, Charecter unit)
        {
            Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "################################################################################", "");
            Output.WriteColorLine(ConsoleColor.DarkMagenta, "Имя: ", $"{unit.Name}", "\n");

            ItemChar.Comparison(unit.TotalDefence, hero.TotalDefence, $"{Output.DefenceStr}: ", true);
            ItemChar.Comparison(unit.TotalAttack, hero.TotalBlock, $"{Output.BlockStr}: ", true);

            Console.Write($"MDEF: {unit.TotalMagicDefence * 100}%\n");

            ItemChar.Comparison(unit.TotalAttack, hero.TotalAttack, $"{Output.AttackStr}: ");
            ItemChar.Comparison(unit.TotalArcane, hero.TotalArcane, $"{Output.ArcaneStr}: ");

            ItemChar.Comparison(unit.TotalMaxMoves, hero.TotalSpeed, $"{Output.SpeedStr}: ", true);
            ItemChar.Comparison(unit.TotalMaxMoves, hero.TotalCrit, $"{Output.CritStr}: ", true);
            Output.WriteColorLine(ConsoleColor.DarkGray, "", "################################################################################", "");
        }

        private static void Turns()
        {
            Console.Write("\n\t\t\t[");
            foreach (var t in Battles.UnitTurnList)
            {
                if (t.charecter.CharecterProfile.IsPlayer)
                    Output.WriteColorLine(Output.unitNameColor(t.charecter.CharecterProfile.Role), "", "Вы ", $"{string.Format("{0:0.00}", t.Speed)}");
                if (t.charecter.Condition.IsAlive & !t.charecter.CharecterProfile.IsPlayer)
                {
                    Output.WriteColorLine(Output.unitNameColor(t.charecter.CharecterProfile.Role), "", "# ", $"{string.Format("{0:0.00}", t.Speed)}");                    
                }
                if (Battles.UnitTurnList.Min(x => x.Speed) != t.Speed & t.charecter.Condition.IsAlive)
                    Console.Write(" | ");
            }

            Console.Write("]\n");
        }

        //  Учет ходов////////////////////////////////
        private static void MovesTracker(Charecter hero, Charecter unit)
        {
            hero.Turn++;
            hero.Condition.SheeldUp = false;
            hero.Condition.AttackParry = false;
            QuickCommandDone = false;
        }

        //  Загрузка списка врагов для выбора
        private static void LoadListOfUnits(List<Order> enemies, bool loadMP)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.charecter.TotalHP <= 0 | enemy.charecter.Condition.LeavedBattle)
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{enemy.charecter.Id}. {enemy.charecter.Name} [0/{enemy.charecter.TotalMaxHP}]\t");
                else
                {
                    Output.WriteColorLine(Output.unitNameColor(enemy.charecter.CharecterProfile.Role), $"{enemy.charecter.Id}. ", $"{enemy.charecter.Name}", "\t");

                    if (enemy.charecter.CharecterProfile.Phase >= 2)
                        enemy.charecter.PhaseHPBar();
                    else
                        enemy.charecter.HPBar(true);

                    if (loadMP)
                        enemy.charecter.MPBar();
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Негативыне эффекты
        //  Отображение негативыне эффекты
        private static void NegativeEffectView(Charecter hero, Charecter enemy)
        {
            if (hero.Condition.SlowRound > 0 || hero.Condition.PoisentRound > 0 || hero.Condition.FrezRound > 0)
            {
                Console.Write("\nУ вас эффект:\n");

                //  Замедление
                if (hero.Condition.SlowRound > 0)
                    Output.WriteColorLine(ConsoleColor.Blue, " ", "Замедление ", $" [-{hero.Condition.Moves} {Output.EffMovSymbol}] ({hero.Condition.SlowRound})\n");

                //  Заморозка
                if (hero.Condition.FrezRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, " ", "Заморозка ", $" ({hero.Condition.FrezRound})\n");                

                //  Отравление
                if (hero.Condition.PoisentRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkGreen, " ", "Отравление ", $" [-{enemy.Condition.PoisentDmg} {Output.HPSymbol}] ({hero.Condition.PoisentRound})\n");
            }           
        }

        //  Вычитание негативыне эффекты
        private static void NegativeEffectImpact(Hero hero, Charecter enemy)
        {
            if (hero.Condition.SlowRound > 0 || hero.Condition.PoisentRound > 0)
            {
                //  Замедление
                if (hero.Condition.SlowRound > 0)
                    hero.Condition.SlowRound--;                    

                //  Отравление
                if (hero.Condition.PoisentRound > 0)
                {
                    hero.Condition.PoisentRound--;
                    hero.HP -= enemy.Condition.PoisentDmg;
                }                    
            }
        }

        private static void FreezMenu(Hero hero)
        {
            Output.WriteColorLine(ConsoleColor.DarkBlue, " ",
                $"Ваши действия?\n"
                + "1) Нападение\n"
                + "2) Заклинания\n"
                + "3) Выпить зелье\n"
                + $"4) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n"
                + $"5) Убежать\n");

            hero.Condition.FrezRound--;
            Thread.Sleep(400);
        }

        private static void ConditionCheck(Hero hero)
        {
            //  Проверка на Замарозку
            if (hero.Condition.FrezRound != 0)
                FreezMenu(hero);
        }
        #endregion
    }
}
