using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fight_cons
{
    class Game_events
    {        
        //  Кошелек
        public static void Pouch(Hero hero, int n_min, int n_max)
        {
            Outer.TwriteLine_general("Вы находите кошелек!\n"
                                         + "1) Взять его\n"
                                         + "2) Пройти мимо\n", Settings.T40);

            switch (Input.Chois_input(hero, 0, 3))
            {
                case 1:
                    if (Mechanics.Vero(0.7))
                    {
                        Random rand = new Random();
                        Outer.ChangeColor("Открывая кошелек вы находите ", $"{ n_min = rand.Next(n_min, n_max)} ", "монеток\n", ConsoleColor.Yellow);
                        hero.money += n_min;
                    }
                    else
                        Mechanics.Battle(hero, Location.Enemies(hero, 6));
                    break;
                case 2:
                    Outer.TwriteLine_general("Вы проходите мимо", Settings.T40);
                    break;
            }            
        }

        //  Победа / конец игры
        public static void Boss_fight(Hero hero)
        {
            Enemy enemy = new Enemy(hero, "Таотот", hp: 50, attack: 3, speed: 50, crit_chance: 20, defence: 10, magic_defence: 30, block: 0, max_moves: 6, no_run: true);

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
                hero.Hero_quest.Game_win_q = 2;

                hero.Hero_stats.Wins++;
                Outer.Victoy_log();
            }
            hero.debuffs.Poisent_round = 0;
            hero.RUN = false;

            if (hero.Hero_quest.Game_win_q == 2)
            {
                Settings.Bild_vers_active = true;
                Outer.TwriteLine_general("Вы убедили Таотота в своей силе", Settings.T30);
                Console.ReadKey();
                Outer.Final();
            }
        }
    }
}
