using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Mechanics
    {
        //  Битва
        public static void Battle(Hero hero, Enemy enemy)
        {
            Outer.Fight_log();
            Outer.ChangeColor("\nНа вас нападает ", $"{enemy.Name}", "!\n", ConsoleColor.DarkMagenta);
            Sound.BATTLE_MUSIC();

            double Hero_speed = hero.speed;
            double Enemy_speed = enemy.speed;
            while ((enemy.hp > 0) && (hero.hp > 0) && !hero.RUN && !enemy.RUN)
            {
                Random rand = new Random();
                Hero_speed = (rand.Next(1, 999) * 0.001) + hero.speed;
                Enemy_speed = (rand.Next(1, 999) * 0.001) + enemy.speed;

                if (Hero_speed > Enemy_speed)
                {
                    if (hero.Turn < hero.max_moves)
                        Combat_solutions.Fight_choice(hero, enemy);
                    else
                        enemy.Enemy_fight_choice(enemy, hero);
                }
                else
                {
                    if (enemy.Turn < enemy.Max_moves)
                        enemy.Enemy_fight_choice(enemy, hero);
                    else
                        Combat_solutions.Fight_choice(hero, enemy);
                }
            }
            if (!hero.RUN)
            {
                //  Чистка
                hero.debuffs.Clear();
                hero.buffs.Clear();
                hero.Turn = 1;
                enemy.Turn = 1;

                hero.Hero_stats.Wins++;
                Outer.Victoy_log();
                Reward(hero, enemy);
            }
            hero.debuffs.Clear();
            hero.buffs.Clear();

            hero.RUN = false;
        }

        //  Награда за победу
        public static void Reward(Hero hero, Enemy enemy)
        {
            Random random = new Random();

            int exp = (enemy.MAX_HP / 2) + (enemy.Attack / 2);
            int money = random.Next(0, 5) + (int)(enemy.Crit * 10) + (int)(enemy.block * 10) + (int)(enemy.speed * 10);
            hero.money += money;
            Console.WriteLine($"Вы получили {exp} опыта и {money} золота\n");
            hero.Level_up(hero, exp);
        }

        //  Проверка на побег
        public static void Cant_run(Hero hero, Enemy enemy)
        {
            if (!enemy.No_run)
            {
                if (Vero(0.5))
                {
                    if (Vero(0.3))
                    {
                        Console.WriteLine("Вы удачно сбежали\n");
                        Outer.Run_log();
                        hero.RUN = true;
                    }
                    else
                    {
                        double n = (hero.MAX_HP / 100.0) * 10.0;
                        hero.hp -= (int)n;
                        Console.WriteLine($"Вы сбежали с потерей {(int)n } HP\n");
                        Outer.Run_log();
                        hero.RUN = true;
                    }
                }
                else
                    Outer.TwriteLine("Побег не удался!\n", Settings.T1);
            }
            else
                Outer.TwriteLine("Вы не можете убежать\n", Settings.T1);
        }

        //  Веротятность события
        public static bool Vero(double x)
        {
            Random rand = new Random();
            bool ans = false;

            if (x >= rand.NextDouble())
                ans = true;

            return ans;
        }

        //  Отдых  
        public static void Rest(Hero hero)
        {
            double H = (hero.MAX_HP / 100.0) * 30.0, M = (hero.MAX_MP / 100.0) * 20.0;
            hero.hp += (int)H;
            hero.mp += (int)M;
            Outer.ChangeColor("Небольшой перерыв восстановил вам ", $"+{(int)H} ", "HP ", ConsoleColor.Green);
            Outer.ChangeColor("и ", $"+{(int)M} ", "MP\n", ConsoleColor.Blue);
            Outer.Wait_next(3, ".");
        }
    }
}
