using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Fight_cons
{
    class CombatSolutions
    {
        //  Боевые решения
        private static int BattleChoise;

        public static void CurrentEnemy(Hero hero, List<Order> units)
        {
            ConditionCheck(hero);

            if (units.Count == 1)
                FightChoice(hero, units.FirstOrDefault().charecter);
            else
            {
                Console.WriteLine("\nВыберите противника");

                LoadListOfUnits(units, hero.EnemyAbout);

                //  Выбор юнита из списка
                var ch = Input.ChoisInput(0, (sbyte)units.Count());
                foreach (var enemy in units)
                {
                    if (enemy.charecter.Id == ch & enemy.charecter.TotalHP > 0 & !enemy.charecter.Run)
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

            //  Информация о противнике 
            if (units != null)
                ShowBattleInfo(hero, unit);

            // Выбор боевых действий
            Console.Write("Ваши действия?\n");

            if (hero.EnemyAbout)
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
                BattleChoise = Input.ChoisInput(0, 6);
            else
                BattleChoise = Input.ChoisInput(0, 5);

            switch (BattleChoise)
            {
                case 0:
                    if (hero.EnemyAbout)
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
                    hero.Conditions.SheeldUp = true;
                    hero.Turn = hero.TotalMaxMoves;
                    break;

                case 5:
                    if (units != null)
                        CurrentEnemy(hero, units);
                    else
                        Battles.CantRun(hero, unit);
                    break;
                case 6:
                    Battles.CantRun(hero, unit);
                    break;
            }

            //  Метод учета ходов и обнуление состояний
            MovesTracker(hero, unit);

            //  Минус от эффектов
            NegativeEffectImpact(hero, unit);
        }

        #region Отображение боевоей информации
        private static void ShowBattleInfo(Hero hero, Charecter unit)
        {
            //  Отрисовка hp противника
            Output.WriteColorName("\n", unit, ":");
            if (unit.Phase >= 2)
                unit.PhaseHPBar();
            else
                unit.HPBar();

            //  Отрисовка mp противника
            if (hero.EnemyAbout)
                unit.MPBar();
            Console.WriteLine();

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
                    heroSpell.Spell(hero, (Enemy)unit, heroSpell.SpellСost, heroSpell.SpellPower);
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

            Console.Write($"X) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n"
                      + $"X) Убежать\n");

            BattleChoise = Input.ChoisInput(hero, 0, (sbyte)(hero.PotionList.Count));
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
                if (t.charecter.IsPlayer)
                    Output.WriteColorLine(Output.unitNameColor(t.charecter.Role), "", "Вы ", $"{string.Format("{0:0.00}", t.Speed)}");
                if (t.charecter.IsAlive & !t.charecter.IsPlayer)
                {
                    Output.WriteColorLine(Output.unitNameColor(t.charecter.Role), "", "# ", $"{string.Format("{0:0.00}", t.Speed)}");                    
                }
                if (Battles.UnitTurnList.Min(x => x.Speed) != t.Speed & t.charecter.IsAlive)
                    Console.Write(" | ");
            }

            Console.Write("]\n");
        }

        //  Отображение ходов
        private static void ShowMoves(Charecter hero) => Console.WriteLine($"\nВаши ходы:\n{hero.Turn}/{hero.TotalMaxMoves}");

        //  Учет ходов////////////////////////////////
        private static void MovesTracker(Charecter hero, Charecter unit)
        {
            hero.Turn++;
            hero.Conditions.SheeldUp = false;
            hero.Conditions.AttackParry = false;
        }

        //  Загрузка списка врагов для выбора
        private static void LoadListOfUnits(List<Order> enemies, bool loadMP)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.charecter.TotalHP <= 0 | enemy.charecter.Run)
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{enemy.charecter.Id}. {enemy.charecter.Name} [0/{enemy.charecter.TotalMaxHP}]\t");
                else
                {
                    Output.WriteColorLine(Output.unitNameColor(enemy.charecter.Role), $"{enemy.charecter.Id}. ", $"{enemy.charecter.Name}", "\t");

                    if (enemy.charecter.Phase >= 2)
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
            if (hero.Conditions.SlowRound > 0 || hero.Conditions.PoisentRound > 0 || hero.Conditions.FrezRound > 0)
            {
                Console.Write("\nУ вас эффект:\n");

                //  Замедление
                if (hero.Conditions.SlowRound > 0)
                    Output.WriteColorLine(ConsoleColor.Blue, " ", "Замедление ", $" [-{hero.Conditions.MaxMoves} {Output.EffMovSymbol}] ({hero.Conditions.SlowRound})\n");

                //  Заморозка
                if (hero.Conditions.FrezRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, " ", "Заморозка ", $" ({hero.Conditions.FrezRound})\n");                

                //  Отравление
                if (hero.Conditions.PoisentRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkGreen, " ", "Отравление ", $" [-{enemy.Conditions.PoisentDmg} {Output.HPSymbol}] ({hero.Conditions.PoisentRound})\n");
            }           
        }

        //  Вычитание негативыне эффекты
        private static void NegativeEffectImpact(Hero hero, Charecter enemy)
        {
            if (hero.Conditions.SlowRound > 0 || hero.Conditions.PoisentRound > 0)
            {
                //  Замедление
                if (hero.Conditions.SlowRound > 0)
                    hero.Conditions.SlowRound--;                    

                //  Отравление
                if (hero.Conditions.PoisentRound > 0)
                {
                    hero.Conditions.PoisentRound--;
                    hero.HP -= enemy.Conditions.PoisentDmg;
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

            hero.Conditions.FrezRound--;
            Thread.Sleep(400);
        }

        private static void ConditionCheck(Hero hero)
        {
            //  Проверка на Замарозку
            if (hero.Conditions.FrezRound != 0)
                FreezMenu(hero);
        }
        #endregion
    }
}
