using Fight_cons.Основа_и_настройки;
using System;
using System.Threading;

namespace Fight_cons
{
    class ParamScaleTicket
    {
        //  дописать модуль для ореинтирования конкретных классов
        public int
        ATTMin = 0, ATTMax = 10,
        ARCMin = 0, ARCMax = 10,
        DEFMin = -30, DEFMax = 50,
        MDEFMin = -30, MDEFMax = 50,
        MAXHpMin = -20, MAXHpMax = 50,
        MAXMp_min = -30, MAXMpMax = 50,
        SPDMin = -50, SPDMax = 50,
        CRITMin = -50, CRITMax = 50,
        BLKMin = -20, BLKMax = 30;
        public sbyte MaxTurnMin = -2, MaxTurnMax = 4;

        protected ParamScaleTicket(int lvl)
        {
            ATTMin += lvl; ATTMax += lvl;
            ARCMin += lvl; ARCMax += lvl;
            DEFMin += lvl; DEFMax += lvl;
            MDEFMin += lvl; MDEFMax += lvl;
            MAXHpMin += lvl; MAXHpMax += lvl;
            MAXMp_min += lvl; MAXMpMax += lvl;
            SPDMin += lvl; SPDMax += lvl;
            CRITMin += lvl; CRITMax += lvl;
            BLKMin += lvl; BLKMax += lvl;
        }
    }

    class WeaponScaleTicket(int lvl) : ParamScaleTicket(lvl)
    {
        public new int
        ATTMin = 0, ATTMax = 10,
        ARCMin = 0, ARCMax = 10,
        DEFMin = -10, DEFMax = 10,
        MDEFMin = -10, MDEFMax = 10,
        MAXHpMin = -10, MAXHpMax = 10,
        MAXMp_min = -10, MAXMpMax = 10,
        SPDMin = -20, SPDMax = 10,
        CRITMin = -20, CRITMax = 40,
        BLKMin = -20, BLKMax = 30;
        public new sbyte MaxTurnMin = -2, MaxTurnMax = 4;
    }

    class ArmorScaleTicket(int lvl) : ParamScaleTicket(lvl)
    {
        public new int
        ATTMin = 0, ATTMax = 2,
        ARCMin = 0, ARCMax = 2,
        DEFMin = -30, DEFMax = 50,
        MDEFMin = -30, MDEFMax = 50,
        MAXHpMin = -20, MAXHpMax = 50,
        MAXMp_min = -30, MAXMpMax = 50,
        SPDMin = -40, SPDMax = 40,
        CRITMin = -10, CRITMax = 10,
        BLKMin = -5, BLKMax = 5;
        public new sbyte MaxTurnMin = -2, MaxTurnMax = 4;
    }

    class ItemChar : Characteristics
    {
        public int Id;

        public int Cost;

        #region Конструторы для предметов
        public static void ItemConsrtucter(ItemChar item, string name, int cost, int attack,
            double defence = 0, int arcane = 0, int magDefence = 0,
            int maxHp = 0, int maxMp = 0, double speed = 0,
            double crit = 0, double block = 0, sbyte maxMoves = 0)
        {
            item.Name = name;
            item.Cost = cost;
            item.Attack = attack;
            item.Defence = defence;
            item.Arcane = arcane;
            item.MagicDefence = magDefence;
            item.MaxHp = maxHp;
            item.MaxMp = maxMp;
            item.Speed = speed;
            item.Crit = crit;
            item.Block = block;
            item.MaxMoves = maxMoves;
        }

        public static void ItemConsrtucter(ItemChar item,
            int ATT_min, int ATT_max, int ARC_min, int ARC_max,
            int DEF_min, int DEF_max, int MDEF_min, int MDEF_max,
            int MAXHp_min, int MAXHp_max, int MAXMp_min, int MAXMp_max,
            int SPD_min, int SPD_max, int CRIT_min, int CRIT_max,
            int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max,
            int lvl)
        {
            Random rand = new Random();

            if (item is Weapon weapon)
                weapon.Name = weapon.WeaponNames();
            else
                (item as Armor).Name = (item as Armor).ArmorNames();

            item.Attack = rand.Next(ATT_min, ATT_max);
            Thread.Sleep(50);
            item.Arcane = rand.Next(ARC_min, ARC_max);
            Thread.Sleep(50);
            item.Defence = rand.Next(DEF_min, DEF_max) * 0.01;
            Thread.Sleep(50);
            item.MagicDefence = rand.Next(MDEF_min, MDEF_max) * 0.01;
            Thread.Sleep(50);
            item.MaxHp = rand.Next(MAXHp_min, MAXHp_max);
            Thread.Sleep(50);
            item.MaxMp = rand.Next(MAXMp_min, MAXMp_max);
            Thread.Sleep(50);
            item.Speed = rand.Next(SPD_min, SPD_max) * 0.01;
            Thread.Sleep(50);
            item.Crit = rand.Next(CRIT_min, CRIT_max) * 0.01;
            Thread.Sleep(50);
            item.Block = rand.Next(BLK_min, BLK_max) * 0.01;
            Thread.Sleep(50);
            item.MaxMoves = (sbyte)rand.Next(max_turn_min, max_turn_max);

            int Spd_part = (int)((item.Speed > 0) ? item.Speed * 100 : 0);

            if (item is Weapon weapon1)
                weapon1.Cost = (int)item.Attack + Spd_part + (int)(item.Crit * 100) + (int)(item.Block * 100) + (lvl * 10);
            else
                (item as Armor).Cost = 50 + (int)(item.Defence * 1000) + (lvl * 10);
        }
        #endregion

        public static string ItemStats(ItemChar item, bool ShowName = true)
        {
            string str = "";
            if (ShowName)
                str = $"{item.Name} | ";

            int i = 0;
            foreach (var statInfo in item.ItemList)
            {
                if (statInfo.ParamValue == Math.Round(statInfo.ParamValue))
                    str += Stat((int)statInfo.ParamValue, statInfo.ParamName);
                else
                    str += Stat(statInfo.ParamValue, statInfo.ParamName);

                i++;
            }

            return str;
        }

        public static void ItemStats(ItemChar item1, ItemChar item2, bool next = false)
        {
            string str = "";
            if (next)
                str = $"{item2.Name} | ";

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
            string space = "  ";    // 2 пробела
            string curString = $"{parametr_2}";

            if (isDouble)
                curString = $"{parametr_2 * 100}%";

            if (parametr_2 > parametr_1)
                Output.WriteColorLine(ConsoleColor.Green, "", $"{curString} {text_mid} {Output.UpSymbol} {space}", $"\t|");
            else if (parametr_2 == parametr_1)
                Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{curString} {text_mid} {space}", $"\t|");
            else
                Output.WriteColorLine(ConsoleColor.Red, "", $"{curString} {text_mid} {Output.DownSymbol} {space}", $"\t|");
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
