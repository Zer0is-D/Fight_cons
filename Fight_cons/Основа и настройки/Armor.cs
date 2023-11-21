using System;
using System.Linq;
using System.Threading;

namespace Fight_cons
{
    internal class Armor : ItemChar
    {       
        public Armor(string name, int cost, double defence, int attack = 0, 
            int arcane = 0, double magDefence = 0, int maxHp = 0, int maxMp = 0, 
            double speed = 0, double crit = 0, double block = 0, sbyte maxMoves = 0)
        {
            Name = name;
            Cost = cost;
            Defence = defence;

            Attack = attack;
            Arcane = arcane;
            MagicDefence = magDefence;
            MaxHp = maxHp;
            MaxMp = maxMp;
            Speed = speed;
            Crit = crit;
            Block = block;
            MaxMoves = maxMoves;
        }

        //  Конструтор 2
        public Armor(int ATT_min, int ATT_max, int ARC_min, int ARC_max,
            int DEF_min, int DEF_max, int MDEF_min, int MDEF_max,
            int MAXHp_min, int MAXHp_max, int MAXMp_min, int MAXMp_max,
            int SPD_min, int SPD_max, int CRIT_min, int CRIT_max,
            int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max,
            int lvl)
        {
            Random rand = new Random();

            Name = ArmorNames();
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
            MaxMoves = (sbyte)rand.Next(max_turn_min, max_turn_max);

            Cost = 50 + (int) (Defence * 1000) + (lvl * 10);            
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
