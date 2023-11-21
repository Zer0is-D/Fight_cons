using System;
using System.Collections.Generic;
using System.Threading;

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

                var weapon = new ParamScaleTicket(hero.Lvl);

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
                Output.WriteColorLine(ConsoleColor.White, $"\n{new_weapon.Id}) ", $"{new_weapon.Name} ", "| ");
                ItemChar.ItemStats(hero.HeroWeapon, new_weapon, true);

                Output.WriteColorLine(ConsoleColor.Yellow, $"\n   Цена: ", $"{new_weapon.Cost}{Output.MoneySymbol}\n");
            }
            Output.TwriteLine("\n5) Выйти", 1);

            int chois = Input.ChoisInput(hero, 1, 5);
            switch (chois)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    if (hero.Money >= WeaponList[chois - 1].Cost)
                    {
                        Console.WriteLine("Хорошая покупка человек!");
                        hero.Money -= WeaponList[chois - 1].Cost;
                        hero.HeroWeapon = WeaponList[chois - 1];
                        Output.Spent(WeaponList[chois - 1].Cost, WeaponList[chois - 1].Name);
                    }
                    else
                        Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
                    break;
                case 5:
                    Output.TwriteLine("Возвращяйся скорее! Желательно с дарами!\n", 1);
                    break;
            }                
        }

        //  Генератор рандомной брони
        public static void Armor_goods(Hero hero)
        {
            if (hero.Lvl - LVL > 1 || ArmorList.Count == 0)
            {
                ArmorList.Clear();

                var armor = new ParamScaleTicket(hero.Lvl);

                for (byte i = 0; i < NamOfGoods; i++)
                {
                    ArmorList.Add(new Armor(armor.ATTMin, armor.ATTMax,
                    armor.ARCMin, armor.ARCMax, armor.DEFMin, armor.DEFMax,
                    armor.MDEFMin, armor.MDEFMax, armor.MAXHpMin, armor.MAXHpMax,
                    armor.MAXMp_min, armor.MAXMpMax, armor.SPDMin, armor.SPDMax,
                    armor.CRITMin, armor.CRITMax, armor.BLKMin, armor.BLKMax,
                    armor.MaxTurnMin, armor.MaxTurnMax, hero.Lvl) 
                    { Id = i + 1 });
                    Thread.Sleep(50);
                }
            }

            hero.HPBar();
            Console.WriteLine();
            foreach (var armor in ArmorList)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{armor.Id}) ", $"{armor.Name} ");
                Output.TwriteLine($"{armor.Armor_stats_market(hero.HeroArmor, armor, true, false)}", 1);
                Output.WriteColorLine(ConsoleColor.Yellow, $"   Цена: ", $"{armor.Cost}{Output.MoneySymbol}\n");
            }
            Output.TwriteLine("5) Выйти", 1);

            int chois = Input.ChoisInput(hero, 1, 5);
            switch (chois)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    if (hero.Money >= ArmorList[chois - 1].Cost)
                    {
                        Console.WriteLine("Хорошая покупка!");
                        hero.Money -= ArmorList[chois - 1].Cost;
                        hero.HeroArmor = ArmorList[chois - 1];
                        Output.Spent(ArmorList[chois - 1].Cost, ArmorList[chois - 1].Name);
                    }
                    else
                        Output.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", 1);
                    break;
                case 5:
                    Output.TwriteLine("Возвращяйся скорее! Желательно с дарами!\n", 1);
                    break;
            }               
        }
    }    
}
