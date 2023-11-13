using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fight_cons
{
    class Market
    {
        private static List<Weapon> Current_weapons = new List<Weapon>();
        private static List<Armor> Current_armor = new List<Armor>();
        public static int LVL = 1;

        //  Генератор рандомного оружия
        public static void Weapon_goods(Hero hero)
        {
            if (hero.Lvl - LVL > 1 || Current_weapons.Count == 0)
            {
                Current_weapons.Clear();
                byte n = (byte)hero.Lvl;
                LVL = hero.Lvl;
                for (byte i = 0; i < 4; i++)
                {
                    Current_weapons.Add(new Weapon(2 + n, 10 + n, -20 - n, 20 + n, 0, 50 + n, 0, 20 + n, -2, 4, n) { Id = i + 1});
                    Thread.Sleep(50);
                }
            }

            hero.HPBar();
            Console.WriteLine();
            foreach (var new_weapon in Current_weapons)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{new_weapon.Id}) ", $"{new_weapon.Name} ", "| ");
                Output.Comparison(hero.HeroWeapon.Attack, new_weapon.Attack, text_left: "", tab_or_line: "| ", text_mid: "ATT");
                Output.Comparison(hero.HeroWeapon.Speed, new_weapon.Speed, text_left: "", tab_or_line: "| ", text_mid: "SPD", true);
                Output.Comparison(hero.HeroWeapon.Crit, new_weapon.Crit, text_left: "", tab_or_line: "| ", text_mid: "CRT", true);
                Output.Comparison(hero.HeroWeapon.Block, new_weapon.Block, text_left: "", tab_or_line: "| ", text_mid: "BLK", true);
                if (new_weapon.MaxMoves >= 1)
                    Output.Comparison(hero.HeroWeapon.MaxMoves, new_weapon.MaxMoves, text_left: "", tab_or_line: "| \n", text_mid: "MOV");
                else
                    Console.WriteLine();

                Output.WriteColorLine(ConsoleColor.Yellow, $"   Цена: ", $"{new_weapon.Cost}\u00A2\n");
            }
            Output.TwriteLine("\n5) Выйти", 1);

            int chois = Input.Chois_input(hero, 0, 6);
            switch (chois)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    if (hero.Money >= Current_weapons[chois - 1].Cost)
                    {
                        Console.WriteLine("Хорошая покупка человек!");
                        hero.Money -= Current_weapons[chois - 1].Cost;
                        hero.HeroWeapon = Current_weapons[chois - 1];
                        Output.Spent(Current_weapons[chois - 1].Cost, Current_weapons[chois - 1].Name);
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
            if (hero.Lvl - LVL > 1 || Current_armor.Count == 0)
            {
                Current_armor.Clear();
                byte n = (byte)hero.Lvl;
                LVL = hero.Lvl;
                for (byte i = 0; i < 4; i++)
                {
                    Current_armor.Add(new Armor(hero, 1 + n, 20 + n, LVL) { Id = i + 1 });
                    Thread.Sleep(50);
                }
            }

            hero.HPBar();
            Console.WriteLine();
            foreach (var armor in Current_armor)
            {
                Output.WriteColorLine(ConsoleColor.White, $"\n{armor.Id}) ", $"{armor.Name} ");
                Output.TwriteLine($"{armor.Armor_stats_market(hero.HeroArmor, armor, true, false)}", 1);
                Output.WriteColorLine(ConsoleColor.Yellow, $"   Цена: ", $"{armor.Cost}\u00A2\n");
            }
            Output.TwriteLine("5) Выйти", 1);

            int chois = Input.Chois_input(hero, 0, 6);
            switch (chois)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    if (hero.Money >= Current_armor[chois - 1].Cost)
                    {
                        Console.WriteLine("Хорошая покупка!");
                        hero.Money -= Current_armor[chois - 1].Cost;
                        hero.HeroArmor = Current_armor[chois - 1];
                        Output.Spent(Current_armor[chois - 1].Cost, Current_armor[chois - 1].Name);
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
