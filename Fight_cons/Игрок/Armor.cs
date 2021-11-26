using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Armor
    {
        public int ID;
        public string Name;

        protected int COST;
        public int Cost
        {
            get
            {
                return COST;
            }
            set
            {
                COST = value;
            }
        }

        protected double CRIT;
        public double Crit
        {
            get
            {
                return CRIT;
            }
            set
            {
                CRIT = value;
            }
        }

        protected double DEFENC;
        public double Defenc
        {
            get
            {
                return DEFENC;
            }
            set
            {
                DEFENC = value;
            }
        }

        //  Конструтор 1
        public Armor(string name, double defenc, int cost)
        {
            Name = name;
            //Crit = crit;
            Defenc = defenc;
            Cost = cost;
        }

        //  Конструтор 2
        public Armor(Hero hero, int defenc_min, int defenc_max, int lvl)
        {
            Random rand = new Random();

            Name = Armor_names(rand.Next(0, 4));
            //Crit = Scale_lvl(hero, rand.Next(crit_min, crit_max)) * 0.01;
            Defenc = Scale_lvl(hero, rand.Next(defenc_min, defenc_max)) * 0.01;

            Cost = 50 + (int) (Defenc * 1000) + (lvl * 10);
        }

        //  Скейл параметров противника от уровня героя
        public int Scale_lvl(Hero hero, int x)
        {
            return (int)(hero.lvl * 1.2) + x;
        }


        public string Armor_stats(bool Show_all = false, bool Name_show = true)
        {
            string str = "";
            if (Name_show)
                str = $"{Name} | ";
            

            if (Defenc != 0)
            {
                if (Defenc >= 0)
                    str += $"+{Defenc * 100}% DEF | ";
                else
                    str += $"{Defenc * 100}% DEF | ";
            }

            //if (Show_all)
            //{
            //    if (Move >= 0)
            //        str += $"+{Move} MOV | ";
            //    else
            //        str += $"{Move} MOV | ";
            //}

            return str;
        }

        public string Armor_stats_market(Armor armor_on, Armor armor_new, bool Show_all = false, bool Name_show = true)
        {
            char Up = '\u2191';
            char Down = '\u2193';

            if (Name_show)
                Outer.ChangeColor("", $"{Name} | ", "", ConsoleColor.DarkYellow);

            //  Сравнение брони
            if (armor_new.Defenc > armor_on.Defenc)
                Outer.ChangeColor("", $"{Defenc * 100}% DEF {Up} ", "| ", ConsoleColor.Green);
            else if (armor_new.Defenc == armor_on.Defenc)
                Outer.ChangeColor("", $"{Defenc * 100}% DEF ", "| ", ConsoleColor.White);
            else
                Outer.ChangeColor("", $"{Defenc * 100}% DEF {Down} ", "| ", ConsoleColor.Red);

            return "";
        }

        public string Armor_names(int n)
        {
            string[] names =
            {
                //  Тяжелая броня
                "Железная броня",
                "Кожаная",

                //  Средняя броня
                "Кираса",
                "Стальной нагрудник",

                //  Легкая броня

            };
            // 4 - 1
            return names[n];
        }
    }
}
