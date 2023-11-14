using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public delegate void PotionUse(Hero hero);

    public class PotionDes
    {
        internal PotionUse Potion;

        internal int ID { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal byte Count { get; set; }

        //  Проверка на кол 
        internal string CountPotion
        {
            get
            {
                if (Count > 0)
                    return $"(Осталось: {Count})";
                else
                    return $"(НЕДОСТУПНО)";
            }
        }

        public PotionDes(Hero hero)
        {
            hero.PotionList.Add(this);
            ID = hero.PotionList.Count;
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
        public static void HealPotion(Hero hero)
        {
            double n = (hero.MaxHp / 100.0) * 50.0;
            hero.HP += (int)n;
            Output.WriteColorLine(ConsoleColor.Green, "Зелье лечения восстановливает ", $"+{(int)n} ", "HP\n"); 
            Sound.DRINK();
        }

        //  Выпить зелье маны
        public static void ManaPotion(Hero hero)
        {
            double n = (hero.MaxMp / 100.0) * 50.0;
            hero.MP += (int)n;
            Output.WriteColorLine(ConsoleColor.Blue, "Зелье маны восстановливает ", $"+{(int)n} ", "MP\n");
            Sound.DRINK();
        }

        //  Выпить противоядие
        public static void AntiPotion(Hero hero)
        {
            Console.WriteLine("Вы выпили противоядие и избавились от всех негативных эффектов");
            hero.Conditions.PoisentRound = 0;
            Sound.DRINK();
        }

        //  Выпить зелье силы
        public static void PowerPotion(Hero hero)
        {
            hero.Conditions.Attack = 200;
            Console.WriteLine($"Ваша сила теперь {hero.Attack}");
    
            Sound.DRINK();
        }
        //  больше ходов, больше маны, временных блоков, 
    }
}
