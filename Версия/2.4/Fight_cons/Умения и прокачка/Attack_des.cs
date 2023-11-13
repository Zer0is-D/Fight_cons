using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Attack_des
    {
        public Skills_dele Attack { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Attack_des(Hero hero, string name)
        {
            Name = name;
            Attack_des rep = hero.Attacks_list.Where(x => x.Name == this.Name).FirstOrDefault();
            if (rep == null)
            {
                hero.Attacks_list.Add(this);
                ID = hero.Attacks_list.Count;
            }
            else
            {
                int index = hero.Attacks_list.IndexOf(rep);
                this.ID = rep.ID;
                hero.Attacks_list[index] = this;
            }
        }        

        //  Раздел НАПАДЕНИЕ
        //  Действие: Атака
        public static void Act_Attac(Hero hero, Enemy enemy)
        {            
            double crit = Crit_chek(hero);
            double att = hero.attack + crit;

            //  Урон по врагу с защитой
            int damag = (int) Defence_chek(enemy, att);

            hero.Hero_stats.Attacks++;
            Combat_solutions.Battle_log(hero, enemy, crit, damag);
        }

        //  Действие: Пробитие брони
        public static void Act_breach_armor(Hero hero, Enemy enemy)
        {            
            double att = hero.attack;

            //  Пробитие брони
            int damag = (int) att;

            Outer.ChangeColor("\n", $"{hero.Name} ", $"наносит ", ConsoleColor.Green);
            Outer.ChangeColor("", $"{damag} ", "урона ", ConsoleColor.Yellow);
            Outer.ChangeColor("у ", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n", ConsoleColor.Red);

            enemy.hp -= damag;

            hero.Hero_stats.Attacks++;
        }

        //  Действие: Кровотечение
        public static void Act_Bleed(Hero hero, Enemy enemy)
        {
            double crit = Crit_chek(hero);
            double att = hero.attack + crit;

            //  Урон по врагу с защитой
            int damag = (int) (Defence_chek(enemy, att) / 2.00);
            enemy.debuffs.Bleed_round = 3;

            Outer.ChangeColor("\n", $"{hero.Name} ", "накладывает ", ConsoleColor.Green);
            Outer.ChangeColor("", $"Кровотечение ", $"", ConsoleColor.DarkRed);
            Outer.ChangeColor("и наносит ", $"{damag} ", "урона ", ConsoleColor.Yellow);
            Outer.ChangeColor("у ", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n", ConsoleColor.Red);

            enemy.hp -= damag;

            hero.Hero_stats.Attacks++;
        }

        //  Действие: Парирование
        public static void Act_Parry(Hero hero, Enemy enemy)
        {
            hero.buffs.Parry = true;
            hero.Turn = hero.max_moves;
        }

        //  Действие: Атака из-за парирования
        public static void Act_Parry_atc(Hero hero, Enemy enemy)
        {
            double crit = Crit_chek(hero);
            double att = hero.attack + crit;

            //  Урон по врагу с защитой
            int damag = (int) att;

            //  Если крит
            if (crit > 1)
            {
                Outer.ChangeColor("\n", $"{hero.Name} ", $"парирует атаку ", ConsoleColor.Green);
                Outer.ChangeColor("", $"{enemy.Name} ", "и наносит критические ", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{damag} ", "урона!\n ", ConsoleColor.Yellow);
                Outer.ChangeColor("У ", $"{enemy.Name}  ", "", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n", ConsoleColor.Red);
            }
            //  Урон без крита
            else
            {
                Outer.ChangeColor("\n", $"{hero.Name} ", $"парирует атаку ", ConsoleColor.Green);
                Outer.ChangeColor("", $"{enemy.Name} ", "и наносит ", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{damag} ", "урона ", ConsoleColor.Yellow);
                Outer.ChangeColor("у ", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{enemy.hp - damag} ", "HP\n", ConsoleColor.Red);
            }
            enemy.hp -= damag;

            hero.Hero_stats.Attacks++;
        }
        //  Конец раздела


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
    }
}
