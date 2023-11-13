using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    class Combat_solutions
    {
        //  Боевые решения
        public static void Fight_choice(Hero hero, Enemy enemy)
        {
            All_skills_ever.Skills(hero, enemy);

            //Moves_show(hero);

            //  Визуал  
            Negative_effect(hero, enemy);
            hero.HP_bar();
            hero.MP_bar();

            //  Метод учета ходов и обнуление состояний
            Move_track(hero, ref enemy);

            //  Боевые решения
            sbyte battle_choise;
            
            //  Если заморозки нет то ...
            if (hero.debuffs.Frez_round == 0)
            {
                // Выбор боевых действий
                Console.Write("Ваши действия?\n");
                if (hero.Info)
                    Console.Write("0) Узнать о противнике\n");
                Console.Write("1) Нападение\n"
                    + "2) Заклинания\n"
                    + "3) Выпить зелье\n"
                    + $"4) Обороняться ({hero.block * 100}% BLK)\n"
                    + $"5) Убежать\n");

                switch (Input.Chois_input(hero.Choice, -1, 6))
                {
                    case 0:
                        if (hero.Info)
                            Information(hero, enemy);
                        else
                            Fight_choice(hero, enemy);
                        break;

                    case 1:
                        Console.Write("Ваши действия?\n"
                                 + $"X) Нападение\n");

                        Console.Write($"  0) Назад\n");
                        foreach (var sk in hero.Attacks_list)
                        {
                            Console.WriteLine($"  {sk.ID}) {sk.Description}");
                        }

                        Console.Write($"X) Заклинания\n"
                                  + $"X) Выпить зелье\n"
                                  + $"X) Обороняться ({hero.block * 100}% BLK)\n"
                                  + $"X) Убежать\n");

                        battle_choise = Input.Chois_input(hero.Choice, -1, (sbyte)(hero.Attacks_list.Count + 1));
                        if (battle_choise != 0)
                            hero.Attacks_list[battle_choise - 1].Attack(hero, enemy);
                        else
                            Fight_choice(hero, enemy);

                        break;

                    case 2:
                        Console.Write("Ваши действия?\n"
                                 + $"X) Нападение\n"
                                 + $"X) Заклинания\n");

                        Console.Write($"  0) Назад\n");
                        foreach (var sp in hero.Spell_list)
                        {
                            Console.WriteLine($"  {sp.ID}) {sp.Description}");
                        }

                        Console.Write($"X) Выпить зелье\n"
                                  + $"X) Обороняться ({hero.block * 100}% BLK)\n"
                                  + $"X) Убежать\n");

                        battle_choise = Input.Chois_input(hero.Choice, -1, (sbyte)(hero.Spell_list.Count + 1));
                        if (battle_choise != 0)
                            hero.Spell_list[battle_choise - 1].Spell(hero, enemy);
                        else
                            Fight_choice(hero, enemy);

                        break;

                    case 3:
                        Console.Write("Ваши действия?\n"
                                 + $"X) Нападение\n"
                                 + $"X) Заклинания\n"
                                 + $"X) Выпить зелье\n");

                        Console.Write($"  0) Назад\n", 1);

                        foreach (var p in hero.Potion_list)
                        {
                            if (p.Count > 0)
                                Console.WriteLine($"  {p.ID}) {p.Description} {p.Have_potion}");
                            else
                                Outer.ChangeColor("  ", $"{p.ID}) {p.Description} {p.Have_potion}", "\n", ConsoleColor.DarkGray);
                        }

                        Console.Write($"X) Обороняться ({hero.block * 100}% BLK)\n"
                                  + $"X) Убежать\n");

                        battle_choise = Input.Chois_input(hero.Choice, -1, (sbyte)(hero.Potion_list.Count + 1));
                        if (battle_choise != 0 && hero.Potion_list[battle_choise - 1].Count > 0)
                            hero.Potion_list[battle_choise - 1].Drink(hero);
                        else
                            Fight_choice(hero, enemy);
                        break;

                    case 4:
                        hero.buffs.Prot_up = true;
                        hero.Turn = hero.max_moves;
                        break;

                    case 5:
                        Mechanics.Cant_run(hero, enemy);
                        break;
                }
            }
            else
            {    
                Outer.ChangeColor(" ",
                    $"Ваши действия?\n"
                    + "1) Нападение\n"
                    + "2) Заклинания\n"
                    + "3) Выпить зелье\n"
                    + $"4) Обороняться ({hero.block * 100}% BLK)\n"
                    + $"5) Убежать\n", "", ConsoleColor.DarkBlue);

                hero.debuffs.Frez_round--;
                Thread.Sleep(400);
            }

            //  Минус от эффектов
            Negative_effect_impact(hero, enemy);
        }

        //  Узнать о противнике
        public static void Information(Hero hero, Enemy enemy)
        {
            Outer.ChangeColor("\n", "################################################################################", "", ConsoleColor.DarkGray);
            Outer.ChangeColor("Имя: ", $"{enemy.Name}", "\n", ConsoleColor.DarkMagenta);

            Outer.Comparison(enemy.defence, hero.defence, "DEF: ", "\t");
            Outer.Comparison(enemy.block, hero.block, "BLK: ", "\n");

            Console.Write($"MDEF: {enemy.magic_defence * 100}%\n");

            Outer.Comparison(enemy.attack, hero.attack, "ATT: ", "\t");
            Outer.Comparison(enemy.Arcane, hero.Arcane, "ARC: ", "\n");

            Outer.Comparison(enemy.speed, hero.speed, "SPD: ", "\t");
            Outer.Comparison(enemy.crit, hero.crit, "CRT: ", "\n");
            Outer.ChangeColor("", "################################################################################", "", ConsoleColor.DarkGray);
        }

        //  Лог
        public static void Battle_log(Hero hero, Enemy enemy, double crit, int damag)
        {
            //  Если крит
            if (crit > 1)
            {
                Outer.ChangeColor("\n", $"{hero.Name} ", $"наносит критические ", ConsoleColor.Green);
                Outer.ChangeColor("", $"{damag} ", "урона! ", ConsoleColor.Yellow);
                Outer.ChangeColor("У ", $"{enemy.Name}  ", "", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n", ConsoleColor.Red);
            }

            //  Урон без крита
            else
            {
                Outer.ChangeColor("\n", $"{hero.Name} ", $"наносит ", ConsoleColor.Green);
                Outer.ChangeColor("", $"{damag} ", "урона ", ConsoleColor.Yellow);
                Outer.ChangeColor("у ", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n", ConsoleColor.Red);
            }
            enemy.hp -= damag;
        }

        //  Отоюражение ходов
        public static void Moves_show(Hero hero) => Console.WriteLine($"\nВаши ходы:\n{hero.Turn}/{hero.max_moves - hero.debuffs.Max_moves}");

        //  Учет ходов
        public static void Move_track(Hero hero, ref Enemy enemy)
        {
            enemy.Turn = 1;
            hero.Turn++;
            hero.buffs.Prot_up = false;
            hero.buffs.Parry = false;
        }

        //  Отображение негативыне эффекты
        public static void Negative_effect(Hero hero, Enemy enemy)
        {
            if (hero.debuffs.Max_moves > 0 || hero.debuffs.Poisent_round > 0 || hero.debuffs.Frez_round > 0)
            {
                Console.Write("\nУ вас эффект:\n");

                //  Замедление
                if (hero.debuffs.Max_moves > 0)
                    Outer.ChangeColor(" ", "Замедление ", $" [-{hero.debuffs.Max_moves} MOV] ({hero.debuffs.Slow_round})\n", ConsoleColor.Blue);

                //  Заморозка
                if (hero.debuffs.Frez_round > 0)
                    Outer.ChangeColor(" ", "Заморозка ", $" ({hero.debuffs.Frez_round})\n", ConsoleColor.DarkBlue);                

                //  Отравление
                if (hero.debuffs.Poisent_round > 0)
                    Outer.ChangeColor(" ", "Отравление ", $" [-{enemy.debuffs.Pisent_dmg} HP] ({hero.debuffs.Poisent_round})\n", ConsoleColor.DarkGreen);
            }           
        }

        //  Вычитание негативыне эффекты
        public static void Negative_effect_impact(Hero hero, Enemy enemy)
        {
            if (hero.debuffs.Slow_round > 0 || hero.debuffs.Poisent_round > 0)
            {
                //  Замедление
                if (hero.debuffs.Slow_round > 0)
                    hero.debuffs.Slow_round--;                    

                //  Отравление
                if (hero.debuffs.Poisent_round > 0)
                {
                    hero.debuffs.Poisent_round--;
                    hero.hp -= enemy.debuffs.Pisent_dmg;
                }                    
            }
        }
    }
}
