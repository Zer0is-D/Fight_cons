using System;
using System.Threading;

namespace Fight_cons
{
    internal class Weapon : ItemChar
    {
        //  Конструктор
        public Weapon(string name, int cost, int attack, 
            double defence = 0, int arcane = 0, int magDefence = 0, 
            int maxHp = 0, int maxMp = 0, double speed = 0, 
            double crit = 0, double block = 0, sbyte maxMoves = 0)
        {
            Name = name;
            Cost = cost;
            Attack = attack;

            Defence = defence;
            Arcane = arcane;
            MagicDefence = magDefence;
            MaxHp = maxHp;
            MaxMp = maxMp;
            Speed = speed;
            Crit = crit;
            Block = block;
            MaxMoves = maxMoves;
        }

        //  Конструктор 2
        public Weapon(int ATT_min, int ATT_max, int ARC_min, int ARC_max,
            int DEF_min, int DEF_max, int MDEF_min, int MDEF_max,
            int MAXHp_min, int MAXHp_max, int MAXMp_min, int MAXMp_max,
            int SPD_min, int SPD_max, int CRIT_min, int CRIT_max,
            int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max, 
            int lvl)
        {
            Random rand = new Random();

            Name = Weapon_names();
            Attack = rand.Next(ATT_min, ATT_max);
            Thread.Sleep(50);
            Arcane = rand.Next(ARC_min, ARC_max);
            Thread.Sleep(50);
            Defence = rand.Next(DEF_min, DEF_max) * 0.01;
            Thread.Sleep(50);
            MagicDefence = rand.Next(MDEF_min, MDEF_max) * 0.01;
            Thread.Sleep(50);
            MaxHp = rand.Next(MAXHp_min, MAXHp_max);
            Thread.Sleep(50);
            MaxMp = rand.Next(MAXMp_min, MAXMp_max);
            Thread.Sleep(50);
            Speed = rand.Next(SPD_min, SPD_max) * 0.01;
            Thread.Sleep(50);
            Crit = rand.Next(CRIT_min, CRIT_max) * 0.01;
            Thread.Sleep(50);
            Block = rand.Next(BLK_min, BLK_max) * 0.01;
            Thread.Sleep(50);
            MaxMoves = (sbyte) rand.Next(max_turn_min, max_turn_max);

            int Spd_part = (int)((Speed > 0 ) ? Speed * 100 : 0);
            Cost = (int) Attack + Spd_part + (int) (Crit * 100) + (int) (Block * 100) + (lvl * 10);
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
            return Dop[rand.Next(0, Dop.Length)] + names[rand.Next(0, names.Length)];
        }
    }
}
