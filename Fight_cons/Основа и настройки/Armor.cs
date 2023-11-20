using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    internal class Armor : ItemChar
    {       
        public Armor(string name, int cost, double defence, int attack = 0, int arcane = 0, double magDefence = 0, int maxHp = 0, int maxMp = 0, double speed = 0, double crit = 0, double block = 0, sbyte maxMoves = 0)
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

        //int ATT_min, int ATT_max, int ARC_min, int ARC_max,
        //    int DEF_min, int DEF_max, int MDEF_min, int MDEF_max,
        //    int MAXHp_min, int MAXHp_max, int MAXMp_min, int MAXMp_max,
        //    int SPD_min, int SPD_max, int CRIT_min, int CRIT_max,
        //    int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max,
        //    int lvl

        //  Конструтор 2
        public Armor(Hero hero, int defenc_min, int defenc_max, int lvl)
        {
            Random rand = new Random();

            Name = Armor_names(rand.Next(0, 4));
            //Crit = Scale_lvl(hero, rand.Next(crit_min, crit_max)) * 0.01;
            Defence = Scale_lvl(hero, rand.Next(defenc_min, defenc_max)) * 0.01;

            Cost = 50 + (int) (Defence * 1000) + (lvl * 10);
        }

        //  Скейл параметров противника от уровня героя
        public int Scale_lvl(Hero hero, int x)
        {
            return (int)(hero.Lvl * 1.2) + x;
        }

        public string Armor_stats_market(Armor armor_on, Armor armor_new, bool Show_all = false, bool Name_show = true)
        {
            char Up = '\u2191';
            char Down = '\u2193';

            if (Name_show)
                Output.WriteColorLine(ConsoleColor.DarkYellow, "", $"{Name} | ");

            //  Сравнение брони
            if (armor_new.Defence > armor_on.Defence)
                Output.WriteColorLine(ConsoleColor.Green, "", $"{Defence * 100}% DEF {Up} ");
            else if (armor_new.Defence == armor_on.Defence)
                Output.WriteColorLine(ConsoleColor.White, "", $"{Defence * 100}% DEF ");
            else
                Output.WriteColorLine(ConsoleColor.Red, "", $"{Defence * 100}% DEF {Down} ");

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
