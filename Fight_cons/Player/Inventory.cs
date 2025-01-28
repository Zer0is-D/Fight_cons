using System;
using System.Linq;
using static Fight_cons.ItemChar;

namespace Fight_cons
{
    internal class Inventory
    {
        private static sbyte _inventoryMax = 10;

        public static void ShowInventory(Hero hero)
        {
            sbyte countItems = (sbyte)hero.HeroInventory.Count();
            Console.WriteLine($"Ваш инвентарь: [{countItems}/{_inventoryMax}]");

            if (hero.HeroInventory.Count() == 0)
                Console.WriteLine("(Пусто)");
            else
            {
                sbyte i = 1;
                foreach (var inv in hero.HeroInventory)
                {
                    Console.WriteLine($"{i}. {inv.Name}\n");
                    i++;
                }
            }
        }

        internal static void ItemAdd(Hero hero, string name, bool MustHave = false)
        {
            ItemChar item = new ItemChar(name, ItemTyps.Item);
            item.Name = name;
            if (MustHave)
            {
                hero.HeroInventory.Add(item);
                Output.WriteColorLine(ConsoleColor.Green, "Предмет ", $"{item.Name} ", "добавлен в инвентарь!\n");
                if (hero.HeroInventory.Count() >= 10)
                    Console.WriteLine("Инвентарь переполнен!");
            }
            else
            {
                if (hero.HeroInventory.Count() + 1 == _inventoryMax)
                    Console.WriteLine("В инвинтаре нет место!");
                else
                {
                    Output.WriteColorLine(ConsoleColor.Green, "Предмет ", $"{item.Name} ", "добавлен в инвентарь!\n");
                    hero.HeroInventory.Add(item);
                }                   
            } 
        }
    }
}
