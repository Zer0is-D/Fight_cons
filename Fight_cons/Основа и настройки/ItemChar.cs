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
    class ParamScaleTicket
    {
        //  дописать модуль для ореинтирования конкретных классов
        public int 
        ATTMin = 0,         ATTMax = 10,
        ARCMin = 0,         ARCMax = 10,
        DEFMin = -30,       DEFMax = 50,
        MDEFMin = -30,      MDEFMax = 50,
        MAXHpMin = -20,     MAXHpMax = 50,
        MAXMp_min = -30,    MAXMpMax = 50,
        SPDMin = -50,       SPDMax = 50,
        CRITMin = -50,      CRITMax = 50,
        BLKMin = -20,       BLKMax = 30;
        public sbyte MaxTurnMin = -2, MaxTurnMax = 4;

        public ParamScaleTicket(int lvl)
        {
            ATTMin += lvl;      ATTMax += lvl;
            ARCMin += lvl;      ARCMax += lvl;
            DEFMin += lvl;      DEFMax += lvl;
            MDEFMin += lvl;     MDEFMax += lvl;
            MAXHpMin += lvl;    MAXHpMax += lvl;
            MAXMp_min += lvl;   MAXMpMax += lvl;
            SPDMin += lvl;      SPDMax += lvl;
            CRITMin += lvl;     CRITMax += lvl;
            BLKMin += lvl;      BLKMax += lvl;
        }
    }

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

        public static void ItemStats(ItemChar item1, ItemChar item2, bool next = false)
        {
            if (next) Console.WriteLine();
            Comparison(item1.Attack, item2.Attack, "ATT");
            Comparison(item1.Arcane, item2.Arcane, "ARC");
            Comparison(item1.Defence, item2.Defence, "DEF", true);
            Comparison(item1.MagicDefence, item2.MagicDefence, "VDEF", true);            
            Comparison(item1.MaxHp, item2.MaxHp, "VHp");
            if (next) Console.WriteLine();
            Comparison(item1.MaxMp, item2.MaxMp, "VMp");
            Comparison(item1.Speed, item2.Speed, "SPD", true);
            Comparison(item1.Crit, item2.Crit, "CRT", true);
            Comparison(item1.Block, item2.Block, "BLK", true);
            Comparison(item1.MaxMoves, item2.MaxMoves, "VMOV");
        }


        //  Метод сравнение параметров (double)
        public static void Comparison(double parametr_1, double parametr_2, string text_mid = "", bool isDouble = false)
        {
            string curString = $"{parametr_2}";

            if (isDouble)
                curString = $"{parametr_2 * 100}%";

            if (parametr_2 > parametr_1)
                Output.WriteColorLine(ConsoleColor.Green, "", $"{curString} {text_mid} {Output.UpSymbol} ", $"\t|");
            else if (parametr_2 == parametr_1)
                Output.WriteColorLine(ConsoleColor.White, "", $"{curString} {text_mid}  ", $"\t|");
            else
                Output.WriteColorLine(ConsoleColor.Red, "", $"{curString} {text_mid} {Output.DownSymbol} ", $"\t|");
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
