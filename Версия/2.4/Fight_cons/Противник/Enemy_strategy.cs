using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Enemy_strategy 
    {
        public void Strg_ATC(Enemy enemy, Hero hero)
        {
            double percent_hp = ((double) enemy.hp/ (double) enemy.MAX_HP) * 100.0;

            while (true)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (Need_to_run(enemy, min1: 10, min2: 20))
                    break;

                //  Условья
                //  Если здоровье меньше 30% (атака 60% / оборона 40%)
                if (percent_hp < 30)
                {
                    if (Mechanics.Vero(0.6))
                    {
                        Enemy_skills.Enemy_Hit(hero, enemy);
                        break;
                    }                              
                    else
                    {
                        enemy.buffs.Prot_up = true;
                        Outer.ChangeColor("\n", $"{enemy.Name} ", "держит оборону\n", ConsoleColor.DarkMagenta);
                        enemy.Turn = 2;
                        break;
                    }
                }

                if (!hero.buffs.Parry)
                {
                    Enemy_skills.Enemy_Hit(hero, enemy);
                    break;
                }
                //  Отравляющая атака                
                if (hero.debuffs.Poisent_round == 0)
                {
                    if (Mechanics.Vero(0.5))
                    {
                        Enemy_skills.Poisent_att(hero, enemy);
                        break;
                    }
                }
                else
                {
                    enemy.buffs.Prot_up = true;
                    Outer.ChangeColor("\n", $"{enemy.Name} ", "держит оборону\n", ConsoleColor.DarkMagenta);
                    enemy.Turn = 2;
                    break;
                }
            }
        }

        public void Strg_MAG(Enemy enemy, Hero hero)
        {
            double percent_hp = ((double)enemy.hp / (double)enemy.MAX_HP) * 100.0;

            while (true)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (Need_to_run(enemy, min1: 10, min2: 20))
                    break;

                //  Заклинания
                if (Mechanics.Vero(0.9))
                {
                    //  Заклинание заморозки
                    if (Mechanics.Vero(0.1))
                    {
                        Enemy_skills.Spell_frez(hero, enemy);
                        break;
                    }

                    //  Заклинание замедления
                    if (hero.debuffs.Max_moves < 3)
                    {
                        if (Mechanics.Vero(0.7))
                        {
                            Enemy_skills.Spell_slow(hero, enemy);
                            break;
                        }
                    }
                    
                    //  Заклинание вампиризм
                    else if (Mechanics.Vero(0.5))
                    {
                        Enemy_skills.Vamperism(hero, enemy);
                        break;
                    }
                }
                else if (Mechanics.Vero(0.3))
                {
                    Enemy_skills.Enemy_Hit(hero, enemy);
                    break;
                }
                else
                    {
                    enemy.buffs.Prot_up = true;
                    Outer.ChangeColor("\n", $"{enemy.Name} ", "держит оборону\n", ConsoleColor.DarkMagenta);
                    enemy.Turn = 2;
                    break;
                }
            }
        }

        public bool Need_to_run(Enemy enemy, byte min)
        {
            double percent_hp = ((double)enemy.hp / (double)enemy.MAX_HP) * 100.0;

            if (percent_hp < min)
            {
                if (Mechanics.Vero(0.8))
                {
                    Outer.ChangeColor("\n", $"{enemy.Name} ", "сбегает\n", ConsoleColor.DarkMagenta);
                    enemy.RUN = true;
                    return true;
                }
            }
            return false;
        }

        public bool Need_to_run(Enemy enemy, byte min1, byte min2)
        {
            double percent_hp = ((double)enemy.hp / (double)enemy.MAX_HP) * 100.0;

            if (percent_hp < min1 || percent_hp < min2)
            {
                if (Mechanics.Vero(0.8))
                {
                    Outer.ChangeColor("\n", $"{enemy.Name} ", "сбегает\n", ConsoleColor.DarkMagenta);
                    enemy.RUN = true;
                    return true;
                }
            }
            return false;
        }
    }
}
