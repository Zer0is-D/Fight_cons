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
            ItemConsrtucter(this, name, cost, attack, 
                defence, arcane, magDefence, maxHp, 
                maxMp, speed, crit, block, maxMoves);

            GetItemParamFields(this);
        }

        //  Конструктор 2
        public Weapon(int ATT_min, int ATT_max, int ARC_min, int ARC_max,
            int DEF_min, int DEF_max, int MDEF_min, int MDEF_max,
            int MAXHp_min, int MAXHp_max, int MAXMp_min, int MAXMp_max,
            int SPD_min, int SPD_max, int CRIT_min, int CRIT_max,
            int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max, 
            int lvl)
        {
            ItemConsrtucter(this, ATT_min, ATT_max, ARC_min, ARC_max,
            DEF_min, DEF_max, MDEF_min, MDEF_max,
            MAXHp_min, MAXHp_max, MAXMp_min, MAXMp_max,
            SPD_min, SPD_max, CRIT_min, CRIT_max,
            BLK_min, BLK_max, max_turn_min, max_turn_max,
            lvl);

            GetItemParamFields(this);
        }

        public string WeaponNames()
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
