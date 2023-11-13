using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Inventory
    {
        public string Obj_name;

        public Inventory(Hero hero)
        {
            hero.Hero_inv.Add(this);
            Obj_name = hero.Hero_inv.ToString();
        }

        public static void Inventory_open(Hero hero)
        {
            sbyte max = 10;

            Console.WriteLine("Ваш инвентарь:");
            if (hero.Hero_inv.Count == 0)
                Console.WriteLine("(Пусто)");
            else
            {
                foreach (var inv in hero.Hero_inv)
                {
                    Console.Write($"{inv}) {inv.Obj_name}\n");
                }
            }
            //for (int i = hero.Hero_inv.Count + 1; i <= max; i++)
            //    Console.Write($"{i}) Пусто\n");
        }
    }
}
