using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Spell_des
    {
        public Skills_dele Spell { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Spell_cost { get; set; }
        public int Spell_power { get; set; }

        public Spell_des(Hero hero, string name)
        {
            Name = name;
            Spell_des rep = hero.Spell_list.Where(x => x.Name == this.Name).FirstOrDefault();
            if (rep == null)
            {
                hero.Spell_list.Add(this);
                ID = hero.Spell_list.Count;
            }
            else
            {
                int index = hero.Spell_list.IndexOf(rep);
                this.ID = rep.ID;
                hero.Spell_list[index] = this;
            }
        }       

        //  Заклинания
        //  Действие: Очищающий луч
        public static void Spell_cleansing_ray(Hero hero, Enemy enemy)
        {
            if (hero.mp >= 5)
            {
                hero.mp -= 5;
                Random rand = new Random();
                double crit = Crit_chek(hero);
                double att = 10 + hero.arcane + crit;

                //  Урон по врагу с магической защитой
                int damag = (int)Magic_defence_chek(enemy, att);                

                if (rand.NextDouble() <= 1 - enemy.speed)
                {
                    if (crit > 1)
                    {
                        Outer.ChangeColor("\n", $"{hero.Name} ", $"наносит ", ConsoleColor.Green);
                        Outer.ChangeColor("заклинанием критические ", $"{damag} ", "урона! ", ConsoleColor.DarkBlue);
                        Outer.ChangeColor("У ", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
                        Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n\n", ConsoleColor.Red);
                        hero.Hero_stats.Spells++;
                        enemy.hp -= damag;
                        Thread.Sleep(400);
                    }
                    else
                    {
                        Outer.ChangeColor("\n", $"{hero.Name} ", $"наносит ", ConsoleColor.Green);
                        Outer.ChangeColor("заклинанием ", $"{damag} ", "урона ", ConsoleColor.DarkBlue);
                        Outer.ChangeColor("у ", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
                        Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n\n", ConsoleColor.Red);
                        hero.Hero_stats.Spells++;
                        enemy.hp -= damag;
                        Thread.Sleep(400);
                    }
                }
                else
                    Outer.ChangeColor("\n", $"{enemy.Name} ", $"уворачивается от заклинания\n", ConsoleColor.DarkMagenta);
            }
            else
            {
                Outer.TwriteLine("\nНедостаточно маны!\n", 1);
                Combat_solutions.Fight_choice(hero, enemy);
            }
        }

        //  Малое лечение
        public static void Heal(Hero hero, Enemy enemy)
        {
            if (hero.mp >= 3)
            {
                hero.mp -= 3;
                double crit = Crit_chek(hero);
                double H = ((hero.MAX_HP / 100.0) * 30.0) + crit;                            

                if (crit > 1)
                    Outer.ChangeColor("\nВы критически восстановили себе ", $"+{(int)H} ", "HP\n", ConsoleColor.Green);
                else
                    Outer.ChangeColor("\nВы восстановили себе ", $"+{(int)H} ", "HP\n", ConsoleColor.Green);

                hero.hp += (int)H;

                hero.Hero_stats.Spells++;
                Thread.Sleep(400);
            }
            else
            {
                Outer.TwriteLine("\nНедостаточно маны!\n", 1);
                Combat_solutions.Fight_choice(hero, enemy);
            }
        }

        //  Замедление
        public static void Slow_down(Hero hero, Enemy enemy)
        {
            if (hero.mp >= 3)
            {
                hero.mp -= 3;

                enemy.buffs.Speed = -0.2;
                Console.WriteLine("Вы замедлили противника!");
                hero.Hero_stats.Spells++;

                Thread.Sleep(400);
            }
            else
            {
                Outer.TwriteLine("\nНедостаточно маны!\n", 1);
                Combat_solutions.Fight_choice(hero, enemy);
            }
        }

        //  Исцеление от всех дебаффов
        public static void Excision(Hero hero, Enemy enemy)
        {
            if (hero.mp >= 6)
            {
                hero.mp -= 6;
                Console.WriteLine("\nВы избавились от всех негатив. эффектов\n");
                hero.debuffs.Clear();
                hero.Hero_stats.Spells++;

                Thread.Sleep(400);
            }
            else
            {
                Outer.TwriteLine("\nНедостаточно маны!\n", 1);
                Combat_solutions.Fight_choice(hero, enemy);
            }
        }


        //  Проверки
        //  Проверка на крит
        protected static double Crit_chek(Hero hero)
        {
            Random rand = new Random();
            double crit = 0;

            if (rand.NextDouble() <= hero.Crit)
                crit = hero.Attack * (rand.Next(15, 20) * 0.1);
            return crit;
        }

        //  Проверка на защиту и блок
        protected static double Defence_chek(Enemy enemy, double att)
        {
            //  Если у противника блок то, иначе ...
            if (enemy.buffs.Prot_up)
                att = att * (1 - enemy.block) + (1 - enemy.defence);
            else
                att = att * (1 - enemy.defence);
            return att;
        }

        //  Проверка на магическую защиту
        protected static double Magic_defence_chek(Enemy enemy, double att)
        {
            att = att * (1 - enemy.magic_defence);
            return att;
        }
    }
}
