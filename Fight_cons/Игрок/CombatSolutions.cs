using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    class CombatSolutions
    {
        //  Боевые решения
        private static int battle_choise;

        public static void CurrentEnemy(Hero hero, List<Order> enemies)
        {
            if (enemies.Count == 1)
                Fight_choice(hero, enemies.FirstOrDefault().charecter);
            else
            {         
                //  Замарозка
                if (hero.Conditions.FrezRound == 0)
                {
                    Console.WriteLine("\nВыберите противника");

                    foreach (var enemy in enemies)
                    {
                        if (enemy.charecter.TotalHP <= 0 | enemy.charecter.Run)
                            Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{enemy.charecter.Id}. {enemy.charecter.Name} [0/{enemy.charecter.TotalMaxHP}]\t");
                        else
                        {
                            Output.WriteColorLine(ConsoleColor.DarkMagenta, $"{enemy.charecter.Id}. ", $"{enemy.charecter.Name}", "\t");

                            if (enemy.charecter.Phase >= 2)
                                enemy.charecter.HP_bar_Phase();
                            else
                                enemy.charecter.HPBar(true);

                            if (hero.EnemyAbout)
                                enemy.charecter.MPBar();
                        }
                        Console.WriteLine();
                    }

                    var ch = Input.ChoisInput(0, (sbyte)enemies.Count());
                    foreach (var enemy in enemies)
                    {
                        if (enemy.charecter.Id == ch & enemy.charecter.TotalHP > 0 & !enemy.charecter.Run)
                        {
                            Console.WriteLine();
                            Fight_choice(hero, enemy.charecter, enemies);
                        }
                    }
                }
                //  Замарозка экрана
                else
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
            }
        }

        //  Боевые решения
        public static void Fight_choice(Hero hero, Charecter enemy, List<Order> enemies = null)
        {
            AllHeroSkills.Skills(hero, enemy);
            //AllHeroSkills.Spells(hero, enemy, 2, 3);
            battle_choise = 0;

            //  Информация о противнике 
            ShowBattleInfo(hero, enemy);

            // Выбор боевых действий
            Console.Write("Ваши действия?\n");

            if (hero.EnemyAbout)
                Console.Write("0) Узнать о противнике\n");

            Console.Write("1) Нападение\n"
                        + "2) Заклинания\n"
                        + "3) Выпить зелье\n"
                        + $"4) Обороняться ({hero.TotalBlock * 100}% {Output.BlockStr})\n");
            if (enemies != null)
            {
                Console.Write($"5) Назад\n"
                + $"6) Убежать\n");
            }
            else
                Console.Write($"5) Убежать\n");

            if (enemies != null)
                battle_choise = Input.ChoisInput(0, 6);
            else
                battle_choise = Input.ChoisInput(0, 5);

            switch (battle_choise)
            {
                case 0:
                    if (hero.EnemyAbout)
                        Information(hero, enemy);
                    else
                        Fight_choice(hero, enemy, enemies);
                    break;

                case 1:
                    AttackList(hero, enemy, enemies);
                    break;

                case 2:
                    SpellList(hero, enemy, enemies);
                    break;

                case 3:
                    PotionList(hero, enemy, enemies);
                    break;

                case 4:
                    hero.Conditions.SheeldUp = true;
                    hero.Turn = hero.TotalMaxMoves;
                    break;

                case 5:
                    if (enemies != null)
                        CurrentEnemy(hero, enemies);
                    else
                        Battles.Cant_run(hero, enemy);
                    break;
                case 6:
                    Battles.Cant_run(hero, enemy);
                    break;
            }

            //  Метод учета ходов и обнуление состояний
            Move_track(hero, enemy);

            //  Минус от эффектов
            Negative_effect_impact(hero, enemy);
        }

        //  Отображение боевоей информации
        private static void ShowBattleInfo(Hero hero, Charecter enemy)
        {
            //  Отрисовка hp противника
            Output.WriteColorName("\n", enemy, ":");
            if (enemy.Phase >= 2)
                enemy.HP_bar_Phase();
            else
                enemy.HPBar();

            //  Отрисовка mp противника
            if (hero.EnemyAbout)
                enemy.MPBar();
            Console.WriteLine();

            //  Отрисовка негативных эффектов, hp и mp игрока 
            Negative_effect(hero, enemy);
            hero.HPBar();
            hero.MPBar();
        }

        //  Атаки
        private static void AttackList(Hero hero, Charecter enemy, List<Order> enemies = null)
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

            battle_choise = Input.ChoisInput(0, (sbyte)(hero.AttackList.Count));
            if (battle_choise != 0)
                hero.AttackList[battle_choise - 1].Attack(hero, enemy);
            else
                Fight_choice(hero, enemy, enemies);
        }

        //  Заклинания
        private static void SpellList(Hero hero, Charecter enemy, List<Order> enemies = null)
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

            battle_choise = Input.ChoisInput(0, (sbyte)(hero.SpellList.Count));
            if (battle_choise != 0)
            {
                if (Formulas.CheckMana(hero, hero.SpellList[battle_choise - 1].Spell_cost))
                {
                    var heroSpell = hero.SpellList[battle_choise - 1];
                    heroSpell.Spell(hero, (Enemy)enemy, heroSpell.Spell_cost, heroSpell.Spell_power);
                }                    
                else
                {
                    Output.TwriteLine("\nНедостаточно маны!\n", 1);
                    Fight_choice(hero, enemy, enemies);
                }
            }
            else
                Fight_choice(hero, enemy, enemies);
        }

        //  Зелья
        private static void PotionList(Hero hero, Charecter enemy, List<Order> enemies = null)
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

            battle_choise = Input.ChoisInput(hero, 0, (sbyte)(hero.PotionList.Count));
            if (battle_choise != 0 && hero.PotionList[battle_choise - 1].Count > 0)
                hero.PotionList[battle_choise - 1].Drink(hero);
            else
                Fight_choice(hero, enemy, enemies);
        }


        #region Отображение и методы
        //  Узнать о противнике
        public static void Information(Charecter hero, Charecter enemy)
        {
            Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "################################################################################", "");
            Output.WriteColorLine(ConsoleColor.DarkMagenta, "Имя: ", $"{enemy.Name}", "\n");

            //Output.Comparison(enemy.TotalDefence, hero.TotalDefence, "DEF: ", "\t", "", true);
            //Output.Comparison(enemy.TotalAttack, hero.TotalBlock, "BLK: ", "\n", "", true);

            //Console.Write($"MDEF: {enemy.TotalMagicDefence * 100}%\n");

            //Output.Comparison(enemy.TotalAttack, hero.TotalAttack, "ATT: ", "\t");
            //Output.Comparison(enemy.TotalArcane, hero.TotalArcane, "ARC: ", "\n");

            //Output.Comparison(enemy.TotalMaxMoves, hero.TotalSpeed, "SPD: ", "\t", "", true);
            //Output.Comparison(enemy.TotalMaxMoves, hero.TotalCrit, "CRT: ", "\n", "", true);
            Output.WriteColorLine(ConsoleColor.DarkGray, "", "################################################################################", "");
        }

        //  Отображение ходов
        public static void Moves_show(Charecter hero) => Console.WriteLine($"\nВаши ходы:\n{hero.Turn}/{hero.TotalMaxMoves}");

        //  Учет ходов
        public static void Move_track(Charecter hero, Charecter enemy)
        {
            enemy.Turn = 0;
            hero.Turn++;
            hero.Conditions.SheeldUp = false;
            hero.Conditions.AttackParry = false;
        }
        #endregion

        #region Негативыне эффекты
        //  Отображение негативыне эффекты
        public static void Negative_effect(Charecter hero, Charecter enemy)
        {
            if (hero.Conditions.SlowRound > 0 || hero.Conditions.PoisentRound > 0 || hero.Conditions.FrezRound > 0)
            {
                Console.Write("\nУ вас эффект:\n");

                //  Замедление
                if (hero.Conditions.SlowRound > 0)
                    Output.WriteColorLine(ConsoleColor.Blue, " ", "Замедление ", $" [-{hero.Conditions.MaxMoves} {Output.EffMovStr}] ({hero.Conditions.SlowRound})\n");

                //  Заморозка
                if (hero.Conditions.FrezRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, " ", "Заморозка ", $" ({hero.Conditions.FrezRound})\n");                

                //  Отравление
                if (hero.Conditions.PoisentRound > 0)
                    Output.WriteColorLine(ConsoleColor.DarkGreen, " ", "Отравление ", $" [-{enemy.Conditions.PoisentDmg} {Output.HPStr}] ({hero.Conditions.PoisentRound})\n");
            }           
        }

        //  Вычитание негативыне эффекты
        public static void Negative_effect_impact(Hero hero, Charecter enemy)
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
        #endregion
    }
}
