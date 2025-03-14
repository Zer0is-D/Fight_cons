using FightCons.World.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using static FightCons.ItemChar;

namespace FightCons
{
    //TODO Доделать список магазинов 
    internal class Store
    {
        public sbyte ID;

        //public List<List<ItemChar>> MarketList = new List<List<ItemChar>>();
        private static List<ItemChar> WeaponList = new List<ItemChar>();
        private static List<ItemChar> ArmorList = new List<ItemChar>();
        static Dictionary<string, List<string>> WeaponsByMaterial = new Dictionary<string, List<string>>();
        static Dictionary<string, List<string>> ArmorByMaterial = new Dictionary<string, List<string>>();
        static List<Material> Materials = new List<Material>();
        //private string[] ObjectTags;

        public static sbyte NamOfGoods;
        public static sbyte NamOfBonuses; //  1-8

        public Store (sbyte id, sbyte namOfGoods, sbyte namOfBonuses, List<Material> materials, Dictionary<string, List<string>> weaponsByMaterial, 
            Dictionary<string, List<string>> armorByMaterial)
        {
            ID = id;
            NamOfGoods = namOfGoods;
            NamOfBonuses = namOfBonuses;
            Materials = materials;
            WeaponsByMaterial = weaponsByMaterial;
            ArmorByMaterial = armorByMaterial;
        }

        private static int LVL = 1;

        //  Генератор рандомного оружия
        public void ShowWeaponGoods(Hero hero)
        {
            if (hero.Lvl - LVL > 1 || WeaponList.Count == 0)
            {
                WeaponList.Clear();

                var weapon = new WeaponScaleTicket(hero.Lvl);

                LVL = hero.Lvl;
                for (byte i = 0; i < NamOfGoods; i++)
                {
                    WeaponList.Add(new ItemChar(ItemTypes.Weapon, NamOfBonuses, weapon.ATTMin, weapon.ATTMax,
                    weapon.ARCMin, weapon.ARCMax, weapon.DEFMin, weapon.DEFMax,
                    weapon.MDEFMin, weapon.MDEFMax, weapon.MAXHpMin, weapon.MAXHpMax,
                    weapon.MAXMp_min, weapon.MAXMpMax, weapon.SPDMin, weapon.SPDMax,
                    weapon.CRITMin, weapon.CRITMax, weapon.BLKMin, weapon.BLKMax,
                    weapon.MaxTurnMin, weapon.MaxTurnMax, hero.Lvl, Materials, WeaponsByMaterial)
                    { Id = (byte)(i + 1) });
                }
            }

            GoodsOut(hero, WeaponList);
        }

        //  Генератор рандомной брони
        public void ShowArmorGoods(Hero hero)
        {
            if (hero.Lvl - LVL > 1 || ArmorList.Count == 0)
            {
                ArmorList.Clear();

                var armor = new ArmorScaleTicket(hero.Lvl);

                for (byte i = 0; i < NamOfGoods; i++)
                {
                    ArmorList.Add(new ItemChar(ItemTypes.Armor, NamOfBonuses, armor.ATTMin, armor.ATTMax,
                    armor.ARCMin, armor.ARCMax, armor.DEFMin, armor.DEFMax,
                    armor.MDEFMin, armor.MDEFMax, armor.MAXHpMin, armor.MAXHpMax,
                    armor.MAXMp_min, armor.MAXMpMax, armor.SPDMin, armor.SPDMax,
                    armor.CRITMin, armor.CRITMax, armor.BLKMin, armor.BLKMax,
                    armor.MaxTurnMin, armor.MaxTurnMax, hero.Lvl, Materials, ArmorByMaterial)
                    { Id = (byte)(i + 1) });
                }
            }

            GoodsOut(hero, ArmorList);
        }

        public void GoodsOut(Hero hero, List<ItemChar> itemChars)
        {
            Output.WriteColorLine(ConsoleColor.Yellow, "\n1) Обновить товары за (", $"10{Output.MoneySymbol}", ")\n");
            foreach (var item in itemChars)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{item.Id + 1}) ", $"{item.Name}\n");

                if (itemChars[0].ItemType == ItemTypes.Weapon)
                    ItemStats(hero.CharacterWeapon, item);
                else
                    ItemStats(hero.CharacterArmor, item);

                Output.WriteColorLine(ConsoleColor.Yellow, $"\nЦена: ", $"{item.Cost}{Output.MoneySymbol}\n");
            }
            Output.TwriteLine("\n0) Выйти\n", 1);

            int chois = Input.ChoisInput(hero, 0, (sbyte)(itemChars.Count() + 1));

            switch (chois)  
            {
                case 0:
                    Output.TwriteLine("Возвращайся скорее! Желательно с деньгами!\n", 1);
                    break;
                case 1:
                    if (Output.Spent(hero.Money, Output.ShowNewItemsCost, "", "Ну не за бесплатно же!"))
                    {
                        switch (itemChars[chois].ItemType)
                        {
                            case ItemTypes.Weapon:
                                WeaponList.Clear();
                                Console.WriteLine("Вот новые товары:");
                                ShowWeaponGoods(hero);
                                break;
                            case ItemTypes.Armor:
                                ArmorList.Clear();
                                Console.WriteLine("Вот новые товары:");
                                ShowArmorGoods(hero);
                                break;
                        }
                    }
                    break;
                default:
                    if (hero.Money >= itemChars[chois - 2].Cost)
                    {
                        Console.WriteLine("Хорошая покупка!");

                        switch (itemChars[chois - 2].ItemType)
                        {
                            case ItemTypes.Weapon:
                                hero.CharacterWeapon = WeaponList[chois - 2];
                                break;
                            case ItemTypes.Armor:
                                hero.CharacterArmor = ArmorList[chois - 2];
                                break;
                        }

                        Output.Spent(hero.Money, itemChars[chois - 2].Cost, itemChars[chois - 2].Name);
                    }
                    else
                        Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
                    break;
            }
        }
    }

    class MarketMethods
    {
        private static List<ItemChar> WeaponList = new List<ItemChar>();
        private static List<ItemChar> ArmorList = new List<ItemChar>();

        public static sbyte NamOfGoods = 4;
        public static sbyte NamOfBonuses = 2; //  1-8

        private static int LVL = 1;

        //  Генератор рандомного оружия
        public static void ShowWeaponGoods(Hero hero)
        {
            if (hero.Lvl - LVL > 1 || WeaponList.Count == 0)
            {
                WeaponList.Clear();

                var weapon = new WeaponScaleTicket(hero.Lvl);

                LVL = hero.Lvl;
                for (byte i = 0; i < NamOfGoods; i++)
                {
                    WeaponList.Add(new ItemChar(ItemTypes.Weapon, NamOfBonuses, weapon.ATTMin, weapon.ATTMax, 
                    weapon.ARCMin, weapon.ARCMax, weapon.DEFMin, weapon.DEFMax,
                    weapon.MDEFMin, weapon.MDEFMax, weapon.MAXHpMin, weapon.MAXHpMax,
                    weapon.MAXMp_min, weapon.MAXMpMax, weapon.SPDMin, weapon.SPDMax,
                    weapon.CRITMin, weapon.CRITMax, weapon.BLKMin, weapon.BLKMax,
                    weapon.MaxTurnMin, weapon.MaxTurnMax, hero.Lvl) 
                    { Id = (byte)(i + 1) });
                }
            }

            GoodsOut(hero, WeaponList);
        }

        //  Генератор рандомной брони
        public static void ShowArmorGoods(Hero hero)
        {
            if (hero.Lvl - LVL > 1 || ArmorList.Count == 0)
            {
                ArmorList.Clear();

                var armor = new ArmorScaleTicket(hero.Lvl);

                for (byte i = 0; i < NamOfGoods; i++)
                {
                    ArmorList.Add(new ItemChar(ItemTypes.Armor, NamOfBonuses, armor.ATTMin, armor.ATTMax,
                    armor.ARCMin, armor.ARCMax, armor.DEFMin, armor.DEFMax,
                    armor.MDEFMin, armor.MDEFMax, armor.MAXHpMin, armor.MAXHpMax,
                    armor.MAXMp_min, armor.MAXMpMax, armor.SPDMin, armor.SPDMax,
                    armor.CRITMin, armor.CRITMax, armor.BLKMin, armor.BLKMax,
                    armor.MaxTurnMin, armor.MaxTurnMax, hero.Lvl) 
                    { Id = (byte)(i + 1) });
                }
            }

            GoodsOut(hero, ArmorList);
        }

        public static void GoodsOut(Hero hero, List<ItemChar> itemChars)
        {
            Output.WriteColorLine(ConsoleColor.Yellow, "\n1) Обновить товары за (", $"10{Output.MoneySymbol}", ")\n");
            foreach (var item in itemChars)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{item.Id + 1}) ", $"{item.Name}\n");

                if (itemChars[0].ItemType == ItemTypes.Weapon)
                    ItemStats(hero.CharacterWeapon, item);
                else
                    ItemStats(hero.CharacterArmor, item);

                Output.WriteColorLine(ConsoleColor.Yellow, $"\nЦена: ", $"{item.Cost}{Output.MoneySymbol}\n");
            }
            Output.TwriteLine("\n0) Выйти\n", 1);

            int chois = Input.ChoisInput(hero, 0, (sbyte)(itemChars.Count() + 1));

            switch (chois)
            {
                case 0:
                    Output.TwriteLine("Возвращайся скорее! Желательно с деньгами!\n", 1);               
                    break;
                case 1:
                    if (Output.Spent(hero.Money, Output.ShowNewItemsCost, "", "Ну не за бесплатно же!"))
                    {
                        switch (itemChars[chois].ItemType)
                        {
                            case ItemTypes.Weapon:
                                WeaponList.Clear();
                                Console.WriteLine("Вот новые товары:");
                                ShowWeaponGoods(hero);
                                break;
                            case ItemTypes.Armor:
                                ArmorList.Clear();
                                Console.WriteLine("Вот новые товары:");
                                ShowArmorGoods(hero);
                                break;
                        }
                    }
                    break;               
                default:
                    if (hero.Money >= itemChars[chois - 2].Cost)
                    {
                        Console.WriteLine("Хорошая покупка!");

                        switch (itemChars[chois - 2].ItemType)
                        {
                            case ItemTypes.Weapon:
                                hero.CharacterWeapon = WeaponList[chois - 2];
                                break;
                            case ItemTypes.Armor:
                                hero.CharacterArmor = ArmorList[chois - 2];
                                break;
                        }

                        Output.Spent(hero.Money, itemChars[chois - 2].Cost, itemChars[chois - 2].Name);
                    }
                    else
                        Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
                    break;
            }
        }
    }    
}
