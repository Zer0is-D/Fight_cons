using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public delegate void Potion_use(Hero hero);

    public class Potion_des
    {
        public Potion_use Potion;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Count { get; set; }

        public Potion_des(Hero hero)
        {
            hero.Potion_list.Add(this);
            ID = hero.Potion_list.Count;
        }

        public void Drink(Hero hero)
        {
            if (Count > 0)
            {
                Potion(hero);
                Count--;
            }
        }

        //  Выпить зелье лечения
        public static void Act_Heal(Hero hero)
        {
            double n = (hero.MAX_HP / 100.0) * 50.0;
            hero.hp += (int)n;
            Outer.ChangeColor("Зелье лечения восстановливает ", $"+{(int)n} ", "HP\n", ConsoleColor.Green);
            Sound.DRINK();
        }

        //  Выпить зелье маны
        public static void Act_Mana(Hero hero)
        {
            double n = (hero.MAX_MP / 100.0) * 50.0;
            hero.mp += (int)n;
            Outer.ChangeColor("Зелье маны восстановливает ", $"+{(int)n} ", "MP\n", ConsoleColor.Blue);
            Sound.DRINK();
        }

        //  Выпить противоядие
        public static void Act_Anti(Hero hero)
        {
            Console.WriteLine("Вы выпили противоядие и избавились от всех негативных эффектов");
            hero.debuffs.Poisent_round = 0;
            Sound.DRINK();
        }

        //  Выпить зелье силы
        public static void Act_Power(Hero hero)
        {
            hero.buffs.Attack = 200;
            Console.WriteLine($"Ваша сила теперь {hero.attack}");
    
            Sound.DRINK();
        }

        //  Проверка на кол 
        public string Have_potion
        {
            get
            {
                if (Count > 0)
                    return $"(Осталось: {Count})";
                else
                    return $"(НЕДОСТУПНО)";
            }
        }
    }
}
