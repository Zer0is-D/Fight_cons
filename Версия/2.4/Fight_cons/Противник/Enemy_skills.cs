using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Enemy_skills
    {
        public Skills_dele E_skill { get; set; }

        //  Способности
        //  Magic_slow!!!
        public static void Spell_slow(Hero hero, Enemy enemy)
        {
            Random rand = new Random();
            double att = enemy.attack;

            int damag = (int) (att / 2.0);
            hero.debuffs.Max_moves++;
            hero.debuffs.Slow_round = 3;

            Outer.ChangeColor("\n", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("", $"замедляет ", $"вас ", ConsoleColor.Blue);
            Outer.ChangeColor("и сносит ", $"{damag} ", "урона! У вас ", ConsoleColor.Yellow);
            Outer.ChangeColor("", $"{hero.hp - damag} ", "HP\n", ConsoleColor.Red);

            hero.hp -= damag;
        }

        //  Ускорение
        public static void Spell_Fast(Hero hero, Enemy enemy)
        {
            enemy.Turn -= enemy.Turn;

            Outer.ChangeColor("\n", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("", $"Ускоряет ", $"себя!\n", ConsoleColor.DarkYellow);
        }

        //  Заморозка
        public static void Spell_frez(Hero hero, Enemy enemy)
        {
            Random rand = new Random();
            double att = enemy.attack;

            int damag = (int) (att / 2.0);
            hero.debuffs.Frez_round = 2;

            Outer.ChangeColor("\n\n", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("", $"Замораживает ", $"вас на {hero.debuffs.Frez_round} хода ", ConsoleColor.DarkBlue);
            Outer.ChangeColor("и сносит ", $"{damag} ", "урона! У вас ", ConsoleColor.Yellow);
            Outer.ChangeColor("", $"{hero.hp - damag} ", "HP\n", ConsoleColor.Red);

            hero.hp -= damag;
        }

        //  Действие Атака 
        public static void Enemy_Hit(Hero hero, Enemy enemy)
        {
            Random rand = new Random();
            double crit = Crit_chek(enemy);
            double att = enemy.attack + crit;

            //  Урон по врагу с защитой
            int damag = (int) Defence_chek(hero, att);

            //  Проверка на парирование
            if (Parry_chek(hero, enemy))
                hero.buffs.Random_debuff(hero, enemy);
            else
                Battle_log(enemy, hero, crit, damag);
        }

        //  Отравляющая атака
        public static void Poisent_att(Hero hero, Enemy enemy)
        {
            Random rand = new Random();
            double crit = Crit_chek(enemy);
            double att = enemy.attack + crit;

            //  Урон по врагу с защитой
            int damag = (int) (att / 2.0);

            hero.debuffs.Poisent_round = 3;

            Outer.ChangeColor("\n", $"{enemy.Name} ", "накладывает на вас ", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("", $"отравление ", "и ", ConsoleColor.DarkGreen);
            Outer.ChangeColor("сносит ", $"{damag} ", "урона! У вас ", ConsoleColor.Yellow);
            Outer.ChangeColor("", $"{hero.hp - damag} ", "HP\n", ConsoleColor.Red);

            hero.hp -= damag;
        }

        //  Вамперизм
        public static void Vamperism(Hero hero, Enemy enemy)
        {
            Random rand = new Random();
            double crit = Crit_chek(enemy);
            double att = enemy.attack + crit;

            int damag = (int) (att / 2.0);

            Outer.ChangeColor("\n", $"{enemy.Name} ", "", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("использует ", $"вампиризм ", "", ConsoleColor.DarkRed);
            Outer.ChangeColor("и поглощает ", $"{damag} ", "HP! ", ConsoleColor.Red);
            Outer.ChangeColor("У вас ", $"{hero.hp - damag} ", "HP\n", ConsoleColor.Red);

            enemy.hp += damag;
            hero.hp -= damag;
        }

        //  Магический щит
        public static void Super_sheeld(Hero hero, Enemy enemy)
        {
            enemy.buffs.Defence = 2.0;

            Outer.ChangeColor("\n", $"{enemy.Name} ", "накладывает на себя ", ConsoleColor.DarkMagenta);
            Outer.ChangeColor("", $"Щит ", "\n", ConsoleColor.DarkBlue);
        }


        //  Проверки и логи
        //  Log
        private static void Battle_log(Enemy enemy, Hero hero, double crit, int damag)
        {
            //  Если крит урон
            if (crit >= 1)
            {
                Outer.ChangeColor("\n", $"{enemy.Name} ", $"сносит вам критические ", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{damag} ", "урона! У вас ", ConsoleColor.Yellow);
                Outer.ChangeColor("", $"{hero.hp - damag} ", "HP\n", ConsoleColor.Red);
                Sound.HIT();
            }

            //  Если не крит урон 
            else
            {
                Outer.ChangeColor("\n", $"{enemy.Name} ", $"сносит вам ", ConsoleColor.DarkMagenta);
                Outer.ChangeColor("", $"{damag} ", "у вас ", ConsoleColor.Yellow);
                Outer.ChangeColor("", $"{hero.hp - damag} ", "HP\n", ConsoleColor.Red);
                Sound.HIT();
            }
            hero.hp -= damag;
            Thread.Sleep(400);
        }

        //  Проверка на парирование
        protected static bool Parry_chek(Hero hero, Enemy enemy)
        {
            Random rand = new Random();
            if (hero.buffs.Parry)
            {
                if (hero.speed >= rand.NextDouble())
                    return true;
                else
                {
                    Console.WriteLine("Парирование не удалось!");
                    return false;
                }                    
            }
            else
                return false;
        }

        //  Проверка на крит
        protected static double Crit_chek(Enemy enemy)
        {
            Random rand = new Random();
            double crit = 0;

            if (rand.NextDouble() <= enemy.Crit)
                crit = enemy.Attack * (rand.Next(15, 20) * 0.1);
            return crit;
        }

        //  Проверка на защиту и блок
        protected static double Defence_chek(Hero hero, double att)
        {
            //  Если у противника блок то, иначе ...
            if (hero.buffs.Prot_up)
                att = att * (1 - hero.block) + (1 - hero.defence);
            else
                att = att * (1 - hero.defence);
            return att;
        }
    }
}
