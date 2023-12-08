using System;
using System.Collections.Generic;
using System.Linq;

namespace Fight_cons
{
    class Market
    {
        private static List<Weapon> WeaponList = new List<Weapon>();
        private static List<Armor> ArmorList = new List<Armor>();

        private static sbyte NamOfGoods = 4;
        private static sbyte NamOfBonusies = 2; //  1-8

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
                    WeaponList.Add(new Weapon(NamOfBonusies, weapon.ATTMin, weapon.ATTMax, 
                    weapon.ARCMin, weapon.ARCMax, weapon.DEFMin, weapon.DEFMax,
                    weapon.MDEFMin, weapon.MDEFMax, weapon.MAXHpMin, weapon.MAXHpMax,
                    weapon.MAXMp_min, weapon.MAXMpMax, weapon.SPDMin, weapon.SPDMax,
                    weapon.CRITMin, weapon.CRITMax, weapon.BLKMin, weapon.BLKMax,
                    weapon.MaxTurnMin, weapon.MaxTurnMax, hero.Lvl) 
                    { Id = i + 1});
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

                for (sbyte i = 0; i < NamOfGoods; i++)
                {
                    ArmorList.Add(new Armor(NamOfBonusies, armor.ATTMin, armor.ATTMax,
                    armor.ARCMin, armor.ARCMax, armor.DEFMin, armor.DEFMax,
                    armor.MDEFMin, armor.MDEFMax, armor.MAXHpMin, armor.MAXHpMax,
                    armor.MAXMp_min, armor.MAXMpMax, armor.SPDMin, armor.SPDMax,
                    armor.CRITMin, armor.CRITMax, armor.BLKMin, armor.BLKMax,
                    armor.MaxTurnMin, armor.MaxTurnMax, hero.Lvl) 
                    { Id = i + 1 });
                }
            }

            GoodsOut(hero, null, ArmorList);
        }

        public static void GoodsOut(Hero hero, List<Weapon> weapons = null, List<Armor> armors = null)
        {
            List<ItemChar> itemChars = new List<ItemChar>();

            if (weapons != null)
            {
                foreach (var w in weapons)
                    itemChars.Add(w);
            }
            else
                foreach (var a in armors)
                    itemChars.Add(a);

            foreach (var item in itemChars)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{item.Id}) ", $"{item.Name}\n");

                if (weapons != null)
                    ItemChar.ItemStats(hero.HeroWeapon, item, true);
                else
                    ItemChar.ItemStats(hero.HeroArmor, item, true);

                Output.WriteColorLine(ConsoleColor.Yellow, $"\nЦена: ", $"{item.Cost}{Output.MoneySymbol}\n");
            }
            Output.TwriteLine("0) Выйти", 1);

            int chois = Input.ChoisInput(hero, 0, (sbyte)itemChars.Count());

            if (chois == 0)
            {
                Output.TwriteLine("Возвращяйся скорее! Желательно с деньгами!\n", 1);
                AboutLoc.Market(hero);
            }
            else
            {
                if (hero.Money >= itemChars[chois - 1].Cost)
                {
                    Console.WriteLine("Хорошая покупка!");
                    hero.Money -= itemChars[chois - 1].Cost;

                    if (weapons != null)
                        hero.HeroWeapon = WeaponList[chois - 1];                    
                    else
                        hero.HeroArmor = ArmorList[chois - 1];

                    Output.Spent(itemChars[chois - 1].Cost, itemChars[chois - 1].Name);
                }
                else
                    Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
            }
        }
    }    
}
