using System;
using System.Linq;

namespace Fight_cons
{
    internal class Armor : ItemChar
    {
        public Armor(string name, int cost, int attack,
            double defence = 0, int arcane = 0, int magDefence = 0,
            int maxHp = 0, int maxMp = 0, double speed = 0,
            double crit = 0, double block = 0, sbyte maxMoves = 0)
        {
            ItemConsrtucter(this, name, cost, attack,
                defence, arcane, magDefence, maxHp,
                maxMp, speed, crit, block, maxMoves);

            GetItemParamFields(this);
        }

        //  Конструтор 2
        public Armor(int bonusies, int ATT_min, int ATT_max, int ARC_min, int ARC_max,
            int DEF_min, int DEF_max, int MDEF_min, int MDEF_max,
            int MAXHp_min, int MAXHp_max, int MAXMp_min, int MAXMp_max,
            int SPD_min, int SPD_max, int CRIT_min, int CRIT_max,
            int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max,
            int lvl)
        {
            ItemConsrtucter(this, bonusies, ATT_min, ATT_max, ARC_min, ARC_max,
                        DEF_min, DEF_max, MDEF_min, MDEF_max,
                        MAXHp_min, MAXHp_max, MAXMp_min, MAXMp_max,
                        SPD_min, SPD_max, CRIT_min, CRIT_max,
                        BLK_min, BLK_max, max_turn_min, max_turn_max,
                        lvl);

            GetItemParamFields(this);
        }

        public string Armor_stats_market(Armor armor_on, Armor armor_new, bool Show_all = false, bool Name_show = true)
        {
            if (Name_show)
                Output.WriteColorLine(ConsoleColor.DarkYellow, "", $"{Name} | ");

            //  Сравнение брони
            if (armor_new.Defence > armor_on.Defence)
                Output.WriteColorLine(ConsoleColor.Green, "", $"{Defence * 100}% DEF {Output.UpSymbol} ");
            else if (armor_new.Defence == armor_on.Defence)
                Output.WriteColorLine(ConsoleColor.White, "", $"{Defence * 100}% DEF ");
            else
                Output.WriteColorLine(ConsoleColor.Red, "", $"{Defence * 100}% DEF {Output.DownSymbol} ");

            return "";
        }

        public string ArmorNames()
        {
            Random rand = new Random();

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
            return names[rand.Next(0, names.Count())];
        }
    }
}
