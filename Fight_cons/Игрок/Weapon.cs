using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Weapon
    {
        public int ID;
        public string Name;        

        //protected int ATTACK;
        public int Attack
        {
            get; set;
        }

        //protected double SPEED;
        public double Speed
        {
            get; set;
        }

        //protected int COST;
        public int Cost
        {
            get; set;
        }

        //protected double CRIT;
        public double Crit
        {
            get; set;
        }

        //protected double BLOCK;
        public double Block
        {
            get; set;
        }

        //protected sbyte MOVES;
        public sbyte Move
        {
            get; set;
        }

        //  Конструктор
        public Weapon(string name, int attack, double speed, int cost, double crit, double block, sbyte move)
        {
            Name = name;
            Attack = attack;
            Speed = speed;
            Cost = cost;
            Crit = crit;
            Block = block;
            Move = move;
        }

        //  Конструктор 2
        public Weapon(int ATT_min, int ATT_max, int SPD_min, int SPD_max, int CRIT_min, int CRIT_max, int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max, int lvl)
        {
            Random rand = new Random();

            Name = Weapon_names();
            Attack = rand.Next(ATT_min, ATT_max);
            Speed = rand.Next(SPD_min, SPD_max) * 0.01;
            Crit = rand.Next(CRIT_min, CRIT_max) * 0.01;
            Block = rand.Next(BLK_min, BLK_max) * 0.01;
            Move = (sbyte) rand.Next(max_turn_min, max_turn_max);

            int Spd_part = (int)((Speed > 0 ) ? Speed * 100 : 0);
            Cost = Attack + Spd_part + (int) (Crit * 100) + (int) (Block * 100) + (lvl * 10);
        }

        public string Weapon_stats(bool Show_all = false, bool Name_show = true)
        {
            string str = "";
            if (Name_show)
                str = $"{Name} | ";

            str += $"+{Attack} ATT | ";

            if (Speed != 0)
            {
                if (Speed > 0)
                    str += $"+{Speed * 100}% SPD | ";
                else
                    str += $"{Speed * 100}% SPD | ";
            }

            if (Crit != 0)
            {
                if (Crit > 0)
                    str += $"+{Crit * 100}% CRT | ";
                else
                    str += $"{Crit * 100}% CRT | ";
            }            

            if (Block != 0)
            {
                if (Block > 0)
                    str += $"+{Block * 100}% BLK | ";
                else
                    str += $"{Block * 100}% BLK | ";
            }            

            if (Show_all)
            {
                if (Move > 0)
                    str += $"+{Move} MOV | ";
                else
                    str += $"{Move} MOV | ";
            }

            return str;
        }
        

        public string Weapon_names()
        {
            Random rand = new Random();

            string[] names =
            {
                //  Тяжелые оружия
                "Большой топор",
                "Топорище",
                "Секира",
                "Тяжелый арбалет",
                "Буба",

                //  Средние оружия
                "Рапира",
                "Меч",
                "Копье",
                "Катана",
                "Топор",
                "Арбалет",

                //  Легкое оружия
                "Нож",
                "Клинок",
                "Серп",
                "Молот",
                "Скрытый клинок",
            };
            // 16 - 1

            string[] Dop =
            {
                "Обычный ",
                "Необычный ",
                "Великолепный ",
                "Потрясающий ",
                "Магический ",
            };
            // 5 - 1
            return Dop[rand.Next(0, 4)] + names[rand.Next(0, 16)];
        }
    }
}
