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
        public static void Fight_choice(Hero hero, Charecter enemy, List<Order> enemies = null)
        {
            AllSkillsEver.Skills(hero, enemy);

            //  Информация о противнике 
            Output.WriteColorName("\n", enemy, ":");
            if (enemy.Phase >= 2)
                enemy.HP_bar_Phase();
            else
                enemy.HPBar();

            if (hero.EnemyAbout)
                enemy.MPBar();
            Console.WriteLine();

            //  Визуал  
            Negative_effect(hero, enemy);
            hero.HPBar();
            hero.MPBar();            

            //  Боевые решения
            int battle_choise;

            //  Если заморозки нет то ...
            if (hero.Conditions.Frez_round == 0)
            {
                // Выбор боевых действий
                Console.Write("Ваши действия?\n");
                if (hero.EnemyAbout)
                    Console.Write("0) Узнать о противнике\n");
                Console.Write("1) Нападение\n"
                            + "2) Заклинания\n"
                            + "3) Выпить зелье\n"
                            + $"4) Обороняться ({hero.TotalBlock * 100}% BLK)\n");
                if (enemies != null)
                {
                    Console.Write($"5) Назад\n"
                    + $"6) Убежать\n");
                }                
                else
                    Console.Write($"5) Убежать\n");

                if (enemies != null)
                    battle_choise = Input.Chois_input(0, 6);
                else
                    battle_choise = Input.Chois_input(0, 5);

                switch (battle_choise)
                {
                    case 0:
                        if (hero.EnemyAbout)
                            Information(hero, enemy);
                        else
                            Fight_choice(hero, enemy, enemies);
                        break;

                    case 1:
                        Console.Write("Ваши действия?\n"
                                 + $"X) Нападение\n");

                        Console.Write($"  0) Назад\n");
                        foreach (var sk in hero.AttackList)
                        {
                            Console.WriteLine($"  {sk.ID}) {sk.Description}");
                        }

                        Console.Write($"X) Заклинания\n"
                                  + $"X) Выпить зелье\n"
                                  + $"X) Обороняться ({hero.TotalBlock * 100}% BLK)\n"
                                  + $"X) Убежать\n");

                        battle_choise = Input.Chois_input(0, (sbyte)(hero.AttackList.Count));
                        if (battle_choise != 0)
                            hero.AttackList[battle_choise - 1].Attack(hero, enemy);
                        else
                            Fight_choice(hero, enemy, enemies);
                        break;

                    case 2:
                        Console.Write("Ваши действия?\n"
                                 + $"X) Нападение\n"
                                 + $"X) Заклинания\n");

                        Console.Write($"  0) Назад\n");
                        foreach (var sp in hero.SpellList)
                        {
                            Console.WriteLine($"  {sp.ID}) {sp.Description}");
                        }

                        Console.Write($"X) Выпить зелье\n"
                                  + $"X) Обороняться ({hero.TotalBlock * 100}% BLK)\n"
                                  + $"X) Убежать\n");

                        battle_choise = Input.Chois_input(0, (sbyte)(hero.SpellList.Count));
                        if (battle_choise != 0)
                            hero.SpellList[battle_choise - 1].Spell(hero, (Enemy)enemy);
                        else
                            Fight_choice(hero, enemy, enemies);

                        break;

                    case 3:
                        Console.Write("Ваши действия?\n"
                                 + $"X) Нападение\n"
                                 + $"X) Заклинания\n"
                                 + $"X) Выпить зелье\n");

                        Console.Write($"  0) Назад\n", 1);

                        foreach (var p in hero.PotionList)
                        {
                            if (p.Count > 0)
                                Console.WriteLine($"  {p.ID}) {p.Description} {p.Have_potion}");
                            else
                                Output.WriteColorLine(ConsoleColor.DarkGray, "  ", $"{p.ID}) {p.Description} {p.Have_potion}\n");
                        }

                        Console.Write($"X) Обороняться ({hero.TotalBlock * 100}% BLK)\n"
                                  + $"X) Убежать\n");

                        battle_choise = Input.Chois_input(hero, 0, (sbyte)(hero.PotionList.Count));
                        if (battle_choise != 0 && hero.PotionList[battle_choise - 1].Count > 0)
                            hero.PotionList[battle_choise - 1].Drink(hero);
                        else
                            Fight_choice(hero, enemy, enemies);
                        break;

                    case 4:
                        hero.Conditions.Prot_up = true;
                        hero.Turn = hero.TotalMaxMoves;
                        break;

                    case 5:
                        if (enemies != null)
                            CurEn(hero, enemies);
                        else
                            Battles.Cant_run(hero, enemy);
                        break;
                    case 6:
                        Battles.Cant_run(hero, enemy);
                        break;
                }
            }
            //  Экран замарозки
            else
            {
                Output.WriteColorLine(ConsoleColor.DarkBlue, " ",
                    $"Ваши действия?\n"
                    + "1) Нападение\n"
                    + "2) Заклинания\n"
                    + "3) Выпить зелье\n"
                    + $"4) Обороняться ({hero.TotalBlock * 100}% BLK)\n"
                    + $"5) Убежать\n");

                hero.Conditions.Frez_round--;
                Thread.Sleep(400);
            }

            //  Метод учета ходов и обнуление состояний
            Move_track(hero, enemy);

            //  Минус от эффектов
            Negative_effect_impact(hero, enemy);
        }

        //  Реализовать выбор противника из списка

        public static void CurEn(Hero hero, List<Order> enemies)
        {
            if (enemies.Count == 1)
                Fight_choice(hero, enemies.FirstOrDefault().charecter);
            else
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

                var ch = Input.Chois_input(0, (sbyte)enemies.Count());
                foreach (var enemy in enemies)
                {
                    if (enemy.charecter.Id == ch & enemy.charecter.TotalHP > 0 & !enemy.charecter.Run)
                    {
                        Console.WriteLine();
                        Fight_choice(hero, enemy.charecter, enemies);
                    }
                }
            }              
        }

        #region Отображение и методы
        //  Узнать о противнике
        public static void Information(Charecter hero, Charecter enemy)
        {
            Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "################################################################################", "");
            Output.WriteColorLine(ConsoleColor.DarkMagenta, "Имя: ", $"{enemy.Name}", "\n");

            Output.Comparison(enemy.TotalDefence, hero.TotalDefence, "DEF: ", "\t", "", true);
            Output.Comparison(enemy.TotalAttack, hero.TotalBlock, "BLK: ", "\n", "", true);

            Console.Write($"MDEF: {enemy.TotalMagicDefence * 100}%\n");

            Output.Comparison(enemy.TotalAttack, hero.TotalAttack, "ATT: ", "\t");
            Output.Comparison(enemy.TotalArcane, hero.TotalArcane, "ARC: ", "\n");

            Output.Comparison(enemy.TotalMaxMoves, hero.TotalSpeed, "SPD: ", "\t", "", true);
            Output.Comparison(enemy.TotalMaxMoves, hero.TotalCrit, "CRT: ", "\n", "", true);
            Output.WriteColorLine(ConsoleColor.DarkGray, "", "################################################################################", "");
        }

        ////  Лог
        //public static void Battle_log(Charecter hero, Charecter enemy, double crit, int damag)
        //{
        //    Output.WriteColorLine(ConsoleColor.Green, "\n", $"{Output.WriteColorName(hero)} ", "наносит ");
        //    //  Если крит
        //    if (crit > 1)
        //        Output.WriteColorLine(ConsoleColor.Yellow, "критические ", $"{damag} ", "урона! У ");

        //    //  Урон без крита
        //    else
        //        Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damag} ", "урона у ");

        //    Output.WriteColorLine(ConsoleColor.DarkMagenta, "", $"{enemy.Name} ", "");
        //    Output.WriteColorLine(ConsoleColor.Red, "", $"{enemy.HP - damag} ", "HP\n");
        //    enemy.HP -= damag;
        //}

        //  Отображение ходов
        public static void Moves_show(Charecter hero) => Console.WriteLine($"\nВаши ходы:\n{hero.Turn}/{hero.TotalMaxMoves}");

        //  Учет ходов
        public static void Move_track(Charecter hero, Charecter enemy)
        {
            enemy.Turn = 0;
            hero.Turn++;
            hero.Conditions.Prot_up = false;
            hero.Conditions.Parry = false;
        }
        #endregion

        #region Негативыне эффекты
        //  Отображение негативыне эффекты
        public static void Negative_effect(Charecter hero, Charecter enemy)
        {
            if (hero.Conditions.Slow_round > 0 || hero.Conditions.Poisent_round > 0 || hero.Conditions.Frez_round > 0)
            {
                Console.Write("\nУ вас эффект:\n");

                //  Замедление
                if (hero.Conditions.Slow_round > 0)
                    Output.WriteColorLine(ConsoleColor.Blue, " ", "Замедление ", $" [-{hero.Conditions.MaxMoves} MOV] ({hero.Conditions.Slow_round})\n");

                //  Заморозка
                if (hero.Conditions.Frez_round > 0)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, " ", "Заморозка ", $" ({hero.Conditions.Frez_round})\n");                

                //  Отравление
                if (hero.Conditions.Poisent_round > 0)
                    Output.WriteColorLine(ConsoleColor.DarkGreen, " ", "Отравление ", $" [-{enemy.Conditions.Pisent_dmg} HP] ({hero.Conditions.Poisent_round})\n");
            }           
        }

        //  Вычитание негативыне эффекты
        public static void Negative_effect_impact(Hero hero, Charecter enemy)
        {
            if (hero.Conditions.Slow_round > 0 || hero.Conditions.Poisent_round > 0)
            {
                //  Замедление
                if (hero.Conditions.Slow_round > 0)
                    hero.Conditions.Slow_round--;                    

                //  Отравление
                if (hero.Conditions.Poisent_round > 0)
                {
                    hero.Conditions.Poisent_round--;
                    hero.HP -= enemy.Conditions.Pisent_dmg;
                }                    
            }
        }
        #endregion
    }
}
