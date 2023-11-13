using Fight_cons.form;
using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Fight_cons
{
    class ItemChar : Characteristics
    {
        public int Id;

        public int Cost;

        public static string ItemStats(ItemChar item, bool ShowName = true)
        {
            string str = "";
            if (ShowName)
                str = $"{item.Name} | ";

            str += Stat(item.Attack, "ATT");
            str += Stat(item.Arcane, "ARC");
            str += Stat(item.Defence, "DEF");
            str += Stat(item.MagicDefence, "MAG DEF");
            str += Stat(item.MaxHp, "MAX Hp");
            str += Stat(item.MaxMp, "MAX Mp");
            str += Stat(item.Speed, "SPD");
            str += Stat(item.Crit, "CRT");
            str += Stat(item.Block, "BLK");
            str += Stat(item.MaxMoves, "MAX MOV");

            return str;
        }

        public static string Stat(int weaponStat, string statName)
        {
            if (weaponStat != 0)
            {
                if (weaponStat > 0)
                    return $"+{weaponStat} {statName} | ";
                else
                    return $"{weaponStat} {statName} | ";
            }
            return "";
        }
        public static string Stat(double weaponStat, string statName)
        {
            if (weaponStat != 0)
            {
                if (weaponStat > 0)
                    return $"+{weaponStat * 100}% {statName} | ";
                else
                    return $"{weaponStat * 100}% {statName} | ";
            }
            return "";
        }
    }
}
