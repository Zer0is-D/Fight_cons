using Fight_cons.Основа_и_настройки;
using System;

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

            str += Stat(item.Attack, Output.AttackStr);
            str += Stat(item.Arcane, Output.ArcaneStr);
            str += Stat(item.Defence, Output.DefenceStr);
            str += Stat(item.MagicDefence, Output.MagicDefenceStr);
            str += Stat(item.MaxHp, Output.MaxHpStr);
            str += Stat(item.MaxMp, Output.MaxMpStr);
            str += Stat(item.Speed, Output.SpeedStr);
            str += Stat(item.Crit, Output.CritStr);
            str += Stat(item.Block, Output.BlockStr);
            str += Stat(item.MaxMoves, Output.MaxMovesStr);

            return str;
        }

        public static void ItemStats(ItemChar item1, ItemChar item2, bool next = false)
        {
            if (next) Console.WriteLine();
            Comparison(item1.Attack, item2.Attack, Output.AttackStr);
            Comparison(item1.Arcane, item2.Arcane, Output.ArcaneStr);
            Comparison(item1.Defence, item2.Defence, Output.DefenceStr, true);
            Comparison(item1.MagicDefence, item2.MagicDefence, Output.MagicDefenceStr, true);            
            Comparison(item1.MaxHp, item2.MaxHp, Output.MaxHpStr);
            if (next) Console.WriteLine();
            Comparison(item1.MaxMp, item2.MaxMp, Output.MaxMpStr);
            Comparison(item1.Speed, item2.Speed, Output.SpeedStr, true);
            Comparison(item1.Crit, item2.Crit, Output.CritStr, true);
            Comparison(item1.Block, item2.Block, Output.BlockStr, true);
            Comparison(item1.MaxMoves, item2.MaxMoves, Output.MaxMovesStr);
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
