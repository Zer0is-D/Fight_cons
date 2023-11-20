using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NPOI.SS.Formula.Functions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fight_cons
{
    class Market
    {
        private static List<Weapon> WeaponList = new List<Weapon>();
        private static List<Armor> ArmorList = new List<Armor>();
        private static int LVL = 1;

        //  Генератор рандомного оружия
        public static void ShowWeaponGoods(Hero hero)
        {
            if (hero.Lvl - LVL > 1 || WeaponList.Count == 0)
            {
                WeaponList.Clear();

                var weapon = new ParamScaleTicket(hero.Lvl);

                LVL = hero.Lvl;
                for (byte i = 0; i < 4; i++)
                {
                    WeaponList.Add(new Weapon(weapon.ATTMin, weapon.ATTMax, 
                    weapon.ARCMin, weapon.ARCMax, weapon.DEFMin, weapon.DEFMax,
                    weapon.MDEFMin, weapon.MDEFMax, weapon.MAXHpMin, weapon.MAXHpMax,
                    weapon.MAXMp_min, weapon.MAXMpMax, weapon.SPDMin, weapon.SPDMax,
                    weapon.CRITMin, weapon.CRITMax, weapon.BLKMin, weapon.BLKMax,
                    weapon.MaxTurnMin, weapon.MaxTurnMax, hero.Lvl) { Id = i + 1});
                    Thread.Sleep(50);
                }
            }

            hero.HPBar();
            Console.WriteLine();
            foreach (var new_weapon in WeaponList)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{new_weapon.Id}) ", $"{new_weapon.Name} ", "| ");
                ItemChar.ItemStats(hero.HeroWeapon, new_weapon, true);
                //ItemChar.Comparison(hero.HeroWeapon.Attack, new_weapon.Attack, text_mid: "ATT");
                //ItemChar.Comparison(hero.HeroWeapon.Speed, new_weapon.Speed, text_mid: "SPD", true);
                //ItemChar.Comparison(hero.HeroWeapon.Crit, new_weapon.Crit, text_mid: "CRT", true);
                //ItemChar.Comparison(hero.HeroWeapon.Block, new_weapon.Block, text_mid: "BLK", true);
                //if (new_weapon.MaxMoves >= 1)
                //    ItemChar.Comparison(hero.HeroWeapon.MaxMoves, new_weapon.MaxMoves, text_mid: "MOV");
                //else
                //    Console.WriteLine();

                Output.WriteColorLine(ConsoleColor.Yellow, $"\n   Цена: ", $"{new_weapon.Cost}\u00A2\n");
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
                byte n = (byte)hero.Lvl;
                LVL = hero.Lvl;
                for (byte i = 0; i < 4; i++)
                {
                    ArmorList.Add(new Armor(hero, 1 + n, 20 + n, LVL) { Id = i + 1 });
                    Thread.Sleep(50);
                }
            }

            hero.HPBar();
            Console.WriteLine();
            foreach (var armor in ArmorList)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{armor.Id}) ", $"{armor.Name} ");
                Output.TwriteLine($"{armor.Armor_stats_market(hero.HeroArmor, armor, true, false)}", 1);
                Output.WriteColorLine(ConsoleColor.Yellow, $"   Цена: ", $"{armor.Cost}\u00A2\n");
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
