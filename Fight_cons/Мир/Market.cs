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
            if (hero.lvl - LVL > 1 || Current_weapons.Count == 0)
            {
                Current_weapons.Clear();
                byte n = (byte)hero.lvl;
                LVL = hero.lvl;
                for (byte i = 0; i < 4; i++)
                {
                    Current_weapons.Add(new Weapon(2 + n, 10 + n, -20 - n, 20 + n, 0, 50 + n, 0, 20 + n, -2, 4, n) { ID = i + 1});
                    Thread.Sleep(50);
                }
            }

            hero.HP_bar();
            Console.WriteLine();
            foreach (var new_weapon in Current_weapons)
            {
                Outer.ChangeColor($"\n{new_weapon.ID}) ", $"{new_weapon.Name} ", "| ", ConsoleColor.White);
                Outer.Comparison(hero.weapon.Attack, new_weapon.Attack, text_left: "", tab_or_line: "| ", text_mid: "ATT");
                Outer.Comparison(hero.weapon.Speed, new_weapon.Speed, text_left: "", tab_or_line: "| ", text_mid: "SPD");
                Outer.Comparison(hero.weapon.Crit, new_weapon.Crit, text_left: "", tab_or_line: "| ", text_mid: "CRT");
                Outer.Comparison(hero.weapon.Block, new_weapon.Block, text_left: "", tab_or_line: "| ", text_mid: "BLK");
                if (new_weapon.Move >= 1)
                    Outer.Comparison(hero.weapon.Move, new_weapon.Move, text_left: "", tab_or_line: "| \n", text_mid: "MOV");
                else
                    Console.WriteLine();

                //Game.TwriteLine($"\n{new_weapon.Weapon_stats_market(hero.weapon, new_weapon, new_weapon.Move >= 1, false)}", 1);

                Outer.ChangeColor($"   Цена: ", $"{new_weapon.Cost}\n", "", ConsoleColor.Yellow);
            }
            Outer.TwriteLine("\n5) Выйти", Settings.T1);

            if (Input.Chois_input(hero, 0, 6) != 5)
            {
                if (hero.money >= Current_weapons[hero.Choice - 1].Cost)
                {
                    Console.WriteLine("Хорошая покупка человек!");
                    hero.money -= Current_weapons[hero.Choice - 1].Cost;
                    hero.weapon = Current_weapons[hero.Choice - 1];
                }
                else
                    Outer.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", Settings.T1);
            }
            else
                Outer.TwriteLine("Возвращяйся скорее! Желательно с дарами!\n", Settings.T1);
        }

        //  Генератор рандомной брони
        public static void Armor_goods(Hero hero)
        {
            if (hero.lvl - LVL > 1 || Current_armor.Count == 0)
            {
                Current_armor.Clear();
                byte n = (byte)hero.lvl;
                LVL = hero.lvl;
                for (byte i = 0; i < 4; i++)
                {
                    Current_armor.Add(new Armor(hero, 1 + n, 20 + n, LVL) { ID = i + 1 });
                    Thread.Sleep(50);
                }
            }

            hero.HP_bar();
            Console.WriteLine();
            foreach (var a in Current_armor)
            {
                Outer.ChangeColor($"\n{a.ID}) ", $"{a.Name} ", "| ", ConsoleColor.White);
                Outer.TwriteLine($"{a.Armor_stats_market(hero.armor, a, true, false)}", 1);
                Outer.ChangeColor($"   Цена: ", $"{a.Cost}\n", "", ConsoleColor.Yellow);
            }
            Outer.TwriteLine("5) Выйти", Settings.T1);

            if (Input.Chois_input(hero, 0, 6) != 5)
            {
                if (hero.money >= Current_armor[hero.Choice - 1].Cost)
                {
                    Console.WriteLine("Хорошая покупка человек!");
                    hero.money -= Current_armor[hero.Choice - 1].Cost;
                    hero.armor = Current_armor[hero.Choice - 1];
                }
                else
                    Outer.TwriteLine("Чтобы что-то получить, нужно что-то отдать!", Settings.T1);
            }
            else
                Outer.TwriteLine("Возвращяйся скорее! Желательно с дарами!\n", Settings.T1);
        }
    }    
}
