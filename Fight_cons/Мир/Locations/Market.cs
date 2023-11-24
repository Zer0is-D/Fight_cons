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
                    WeaponList.Add(new Weapon(weapon.ATTMin, weapon.ATTMax, 
                    weapon.ARCMin, weapon.ARCMax, weapon.DEFMin, weapon.DEFMax,
                    weapon.MDEFMin, weapon.MDEFMax, weapon.MAXHpMin, weapon.MAXHpMax,
                    weapon.MAXMp_min, weapon.MAXMpMax, weapon.SPDMin, weapon.SPDMax,
                    weapon.CRITMin, weapon.CRITMax, weapon.BLKMin, weapon.BLKMax,
                    weapon.MaxTurnMin, weapon.MaxTurnMax, hero.Lvl) 
                    { Id = i + 1});
                }
            }

            hero.HPBar();
            Console.WriteLine();
            foreach (var new_weapon in WeaponList)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{new_weapon.Id}) ", $"{new_weapon.Name} ");
                ItemChar.ItemStats(hero.HeroWeapon, new_weapon, true);

                Output.WriteColorLine(ConsoleColor.Yellow, $"\nЦена: ", $"{new_weapon.Cost}{Output.MoneySymbol}\n");
            }
            Output.TwriteLine("\n0) Выйти", 1);

            int chois = Input.ChoisInput(hero, 0, (sbyte) WeaponList.Count());

            if (chois == 0)
                Output.TwriteLine("Возвращяйся скорее! Желательно с деньгами!\n", 1);
            else
            {
                if (hero.Money >= WeaponList[chois - 1].Cost)
                {
                    Console.WriteLine("Хорошая покупка человек!");
                    hero.Money -= WeaponList[chois - 1].Cost;
                    hero.HeroWeapon = WeaponList[chois - 1];
                    Output.Spent(WeaponList[chois - 1].Cost, WeaponList[chois - 1].Name);
                }
                else
                    Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
            }              
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
                    ArmorList.Add(new Armor(armor.ATTMin, armor.ATTMax,
                    armor.ARCMin, armor.ARCMax, armor.DEFMin, armor.DEFMax,
                    armor.MDEFMin, armor.MDEFMax, armor.MAXHpMin, armor.MAXHpMax,
                    armor.MAXMp_min, armor.MAXMpMax, armor.SPDMin, armor.SPDMax,
                    armor.CRITMin, armor.CRITMax, armor.BLKMin, armor.BLKMax,
                    armor.MaxTurnMin, armor.MaxTurnMax, hero.Lvl) 
                    { Id = i + 1 });
                }
            }

            hero.HPBar();
            Console.WriteLine();
            foreach (var armor in ArmorList)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{armor.Id}) ", $"{armor.Name} ");
                Output.TwriteLine($"{armor.Armor_stats_market(hero.HeroArmor, armor, true, false)}", 1);
                Output.WriteColorLine(ConsoleColor.Yellow, $"\nЦена: ", $"{armor.Cost}{Output.MoneySymbol}\n");
            }
            Output.TwriteLine("0) Выйти", 1);

            int chois = Input.ChoisInput(hero, 0, (sbyte)ArmorList.Count());

            if (chois == 0)
                Output.TwriteLine("Возвращяйся скорее! Желательно с дарами!\n", 1);
            else
            {
                if (hero.Money >= ArmorList[chois - 1].Cost)
                {
                    Console.WriteLine("Хорошая покупка!");
                    hero.Money -= ArmorList[chois - 1].Cost;
                    hero.HeroArmor = ArmorList[chois - 1];
                    Output.Spent(ArmorList[chois - 1].Cost, ArmorList[chois - 1].Name);
                }
                else
                    Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
            }              
        }
    }    
}
