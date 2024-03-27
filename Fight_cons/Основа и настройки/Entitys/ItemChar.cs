using Fight_cons.Основа_и_настройки;
using System;
using System.Linq;
using System.Threading;

namespace Fight_cons
{
    class ParamScaleTicket
    {
        //  дописать модуль для ореинтирования конкретных классов
        public short
        ATTMin = 0, ATTMax = 10,
        ARCMin = 0, ARCMax = 10,
        MAXHpMin = -20, MAXHpMax = 50,
        MAXMp_min = -30, MAXMpMax = 50;

        public sbyte
        DEFMin = -30, DEFMax = 50,
        MDEFMin = -30, MDEFMax = 50,        
        SPDMin = -50, SPDMax = 50,
        CRITMin = -50, CRITMax = 50,
        BLKMin = -20, BLKMax = 30,
        MaxTurnMin = -2, MaxTurnMax = 4;

        protected ParamScaleTicket(sbyte lvl)
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

    class WeaponScaleTicket(sbyte lvl) : ParamScaleTicket(lvl)
    {
        public new short
        ATTMin = 0, ATTMax = 10,
        ARCMin = 0, ARCMax = 10,
        MAXHpMin = -10, MAXHpMax = 10,
        MAXMp_min = -10, MAXMpMax = 10;
        
        public new sbyte
        DEFMin = -10, DEFMax = 10,
        MDEFMin = -10, MDEFMax = 10,
        SPDMin = -20, SPDMax = 10,
        CRITMin = -20, CRITMax = 40,
        BLKMin = -20, BLKMax = 30,
        MaxTurnMin = -2, MaxTurnMax = 4;
    }

    class ArmorScaleTicket(sbyte lvl) : ParamScaleTicket(lvl)
    {
        public new short
        ATTMin = 0, ATTMax = 2,
        ARCMin = 0, ARCMax = 2,
        MAXHpMin = -20, MAXHpMax = 50,
        MAXMp_min = -30, MAXMpMax = 50;
        
        public new sbyte
        DEFMin = -30, DEFMax = 50,
        MDEFMin = -30, MDEFMax = 50,
        SPDMin = -40, SPDMax = 40,
        CRITMin = -10, CRITMax = 10,
        BLKMin = -5, BLKMax = 5,
        MaxTurnMin = -2, MaxTurnMax = 4;
    }

    class ItemChar : Characteristics
    {
        public byte Id;

        public enum ItemTyps
        {
            Item = 0,
            Weapon = 1,
            Armor = 2
        }
        public ItemTyps ItemType;

        public short Cost;

        #region Конструторы для предметов
        public ItemChar(string name, ItemTyps itemType, short cost = 0, short attack = 0,
            float defence = 0, short arcane = 0, sbyte magDefence = 0,
            short maxHp = 0, short maxMp = 0, float speed = 0,
            float crit = 0, float block = 0, sbyte maxMoves = 0)
        {
            Name = name;
            ItemType = itemType;

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
            Moves = maxMoves;

            GetItemParamFields(this);
        }

        public ItemChar(ItemTyps itemType, short bonusies,
            short ATT_min, short ATT_max, short ARC_min, short ARC_max,
            sbyte DEF_min, sbyte DEF_max, sbyte MDEF_min, sbyte MDEF_max,
            short MAXHp_min, short MAXHp_max, short MAXMp_min, short MAXMp_max,
            sbyte SPD_min, sbyte SPD_max, sbyte CRIT_min, sbyte CRIT_max,
            sbyte BLK_min, sbyte BLK_max, sbyte max_turn_min, sbyte max_turn_max,
            sbyte lvl)
        {
            Random rand = new Random();
            ItemType = itemType;

            //  Количество бонусных параметров
            bonusies = (short) rand.Next(0, bonusies);            
            int[] masOfParamNum = new int[bonusies];

            foreach (var m in masOfParamNum)
                masOfParamNum[m] = rand.Next(1, 11);

            Name = GenerateName(this);

            switch (itemType)
            {
                case ItemTyps.Weapon:
                    Attack = (short) rand.Next(ATT_min, ATT_max);
                    break;
                case ItemTyps.Armor:
                    Defence = (float) (rand.Next(DEF_min, DEF_max) * 0.01);
                    break;
            }

            foreach (var num in masOfParamNum)
            {
                switch (num)
                {
                    case 1:
                        Arcane = (short) rand.Next(ARC_min, ARC_max);
                        break;
                    case 2:
                        MagicDefence = (float) (rand.Next(MDEF_min, MDEF_max) * 0.01);
                        break;
                    case 3:
                        MaxHp = (short) rand.Next(MAXHp_min, MAXHp_max);
                        break;
                    case 4:
                        MaxMp = (short) rand.Next(MAXMp_min, MAXMp_max);
                        break;
                    case 5:
                        Speed = (float) (rand.Next(SPD_min, SPD_max) * 0.01);
                        break;
                    case 6:
                        Crit = (float) (rand.Next(CRIT_min, CRIT_max) * 0.01);
                        break;
                    case 7:
                        Block = (float) (rand.Next(BLK_min, BLK_max) * 0.01);
                        break;
                    case 8:
                        Moves = (sbyte)rand.Next(max_turn_min, max_turn_max);
                        break;
                    case 9:
                        Attack += (short) rand.Next(ATT_min, ATT_max);
                        break;
                    case 10:
                        Defence += (float) (rand.Next(DEF_min, DEF_max) * 0.01);
                        break;
                }
                Thread.Sleep(50);
            }

            short Spd_part = (short) ((Speed > 0) ? Speed * 100 : 0);

            switch (itemType)
            {
                case ItemTyps.Weapon:
                    Cost = (short)(Attack + Spd_part + (Crit * 100) + (Block * 100) + (lvl * 10));
                    break;
                case ItemTyps.Armor:
                    Cost = (short)(50 + (Defence * 1000) + (lvl * 10));
                    break;
                case ItemTyps.Item:
                    Cost = 50;
                    break;
            }
            Thread.Sleep(50);
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

        public static void ItemStats(ItemChar item1, ItemChar item2)
        {
            //if (next) Console.WriteLine();
            Comparison(item1.Attack, item2.Attack, Output.AttackStr);
            Comparison(item1.Arcane, item2.Arcane, Output.ArcaneStr);
            Comparison(item1.Defence, item2.Defence, Output.DefenceStr, true);
            Comparison(item1.MagicDefence, item2.MagicDefence, Output.MagicDefenceStr, true);
            Comparison(item1.MaxHp, item2.MaxHp, Output.MaxHpStr);
            //if (next) Console.WriteLine();
            Comparison(item1.MaxMp, item2.MaxMp, Output.MaxMpStr);
            Comparison(item1.Speed, item2.Speed, Output.SpeedStr, true);
            Comparison(item1.Crit, item2.Crit, Output.CritStr, true);
            Comparison(item1.Block, item2.Block, Output.BlockStr, true);
            Comparison(item1.Moves, item2.Moves, Output.MaxMovesStr);
        }

        //  Метод сравнение параметров (double)
        public static void Comparison(float parametr_1, float parametr_2, string text_mid = "", bool isFloat = false)
        {
            const string space = "  ";    // 2 пробела
            string curString = "";
            string actualValue = "";

            if (isFloat)
            {
                if (Settings.DetiledParamValue)
                {
                    curString = $"{(parametr_2 - parametr_1) * 100}%";
                    actualValue = $"{parametr_2 * 100}%";
                }
                else
                    curString = $"{parametr_2 * 100}%";
            }
            else
            {
                if (Settings.DetiledParamValue)
                {
                    curString = $"{parametr_2 - parametr_1}";
                    actualValue = $"{parametr_2}";
                }                    
                else
                    curString = $"{parametr_2}";
            }

            if (Settings.DetiledParamValue)
            {
                if (parametr_2 > parametr_1)
                    Output.WriteColorLine(ConsoleColor.Green, "", $"{curString} {text_mid} ({actualValue}) {Output.UpSymbol} {space}", $"\t|");
                else if (parametr_2 == parametr_1) Console.Write("");
                //Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{curString} {text_mid} {space}", $"\t|");
                else
                    Output.WriteColorLine(ConsoleColor.Red, "", $"{curString} {text_mid} ({actualValue}) {Output.DownSymbol} {space}", $"\t|");
            }
            else
            {
                if (parametr_2 > parametr_1)
                    Output.WriteColorLine(ConsoleColor.Green, "", $"{curString} {text_mid} {Output.UpSymbol} {space}", $"\t|");
                else if (parametr_2 == parametr_1) Console.Write("");
                //Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{curString} {text_mid} {space}", $"\t|");
                else
                    Output.WriteColorLine(ConsoleColor.Red, "", $"{curString} {text_mid} {Output.DownSymbol} {space}", $"\t|");
            }
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
        public string GenerateName(ItemChar item)
        {
            Random rand = new Random();

            string[] WeaponNames =
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

            string[] WeaponDop =
            {
                "Обычный ",
                "Необычный ",
                "Великолепный ",
                "Потрясающий ",
                "Магический ",
            };
            // 5 - 1

            string[] ArmorNames =
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

            switch (item.ItemType)
            {
                case ItemTyps.Weapon:
                    return WeaponDop[rand.Next(0, WeaponDop.Length)] + WeaponNames[rand.Next(0, WeaponNames.Length)];
                    break;
                case ItemTyps.Armor:
                    return ArmorNames[rand.Next(0, ArmorNames.Count())];
                    break;
            }

            Console.WriteLine("Ошибка наименования объекта!");
            return "NullName";
        }

        //public string Armor_stats_market(ItemChar armor_on, ItemChar armor_new, bool Show_all = false, bool Name_show = true)
        //{
        //    if (Name_show)
        //        Output.WriteColorLine(ConsoleColor.DarkYellow, "", $"{Name} | ");

        //    //  Сравнение брони
        //    if (armor_new.Defence > armor_on.Defence)
        //        Output.WriteColorLine(ConsoleColor.Green, "", $"{Defence * 100}% DEF {Output.UpSymbol} ");
        //    else if (armor_new.Defence == armor_on.Defence)
        //        Output.WriteColorLine(ConsoleColor.White, "", $"{Defence * 100}% DEF ");
        //    else
        //        Output.WriteColorLine(ConsoleColor.Red, "", $"{Defence * 100}% DEF {Output.DownSymbol} ");

        //    return "";
        //}
    }
}
