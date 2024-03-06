using System;
using System.Collections.Generic;
using System.Linq;
using static Fight_cons.ItemChar;

namespace Fight_cons
{
    class Market
    {
        private static List<ItemChar> WeaponList = new List<ItemChar>();
        private static List<ItemChar> ArmorList = new List<ItemChar>();

        public static sbyte NamOfGoods = 4;
        public static sbyte NamOfBonusies = 2; //  1-8

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
                    WeaponList.Add(new ItemChar(ItemTyps.Weapon, NamOfBonusies, weapon.ATTMin, weapon.ATTMax, 
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
                    ArmorList.Add(new ItemChar(ItemTyps.Armor, NamOfBonusies, armor.ATTMin, armor.ATTMax,
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
            Output.TwriteLine("1) Выйти", 1);
            foreach (var item in itemChars)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{item.Id + 1}) ", $"{item.Name}\n");

                if (itemChars[0].ItemType == ItemTyps.Weapon)
                    ItemStats(hero.HeroWeapon, item, true);
                else
                    ItemStats(hero.HeroArmor, item, true);

                Output.WriteColorLine(ConsoleColor.Yellow, $"\nЦена: ", $"{item.Cost}{Output.MoneySymbol}\n");
            }
            Output.WriteColorLine(ConsoleColor.Yellow, "0) Обновить товары за (", $"10{Output.MoneySymbol}",")\n");

            int chois = Input.ChoisInput(hero, 0, (sbyte)(itemChars.Count() + 1));

            switch (chois)
            {
                case 0:
                    if (hero.Money < 10)
                        Console.WriteLine("Ну не за бесплатно же!");
                    else
                    {
                        Output.Spent(hero, itemChars[chois - 2].Cost);

                        switch (itemChars[chois].ItemType)
                        {
                            case ItemTyps.Weapon:                                
                                WeaponList.Clear();
                                Console.WriteLine("Вот новые товары:");
                                ShowWeaponGoods(hero);
                                break;
                            case ItemTyps.Armor:
                                ArmorList.Clear();
                                Console.WriteLine("Вот новые товары:");
                                ShowArmorGoods(hero);
                                break;
                        }
                    }                    
                    break;
                case 1:
                    Output.TwriteLine("Возвращяйся скорее! Желательно с деньгами!\n", 1);
                    AboutLoc.Market(hero);
                    break;               
                default:
                    if (hero.Money >= itemChars[chois - 2].Cost)
                    {
                        Console.WriteLine("Хорошая покупка!");

                        switch (itemChars[chois - 2].ItemType)
                        {
                            case ItemTyps.Weapon:
                                hero.HeroWeapon = WeaponList[chois - 2];
                                break;
                            case ItemTyps.Armor:
                                hero.HeroArmor = ArmorList[chois - 2];
                                break;
                        }

                        Output.Spent(hero, itemChars[chois - 2].Cost, itemChars[chois - 2].Name);
                    }
                    else
                        Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
                    break;
            }
        }
    }    
}
