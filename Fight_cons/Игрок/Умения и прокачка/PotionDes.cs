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
        public PotionUse Potion;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Count { get; set; }

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
        public static void Act_Heal(Hero hero)
        {
            double n = (hero.MaxHp / 100.0) * 50.0;
            hero.HP += (int)n;
            Output.WriteColorLine(ConsoleColor.Green, "Зелье лечения восстановливает ", $"+{(int)n} ", "HP\n"); 
            Sound.DRINK();
        }

        //  Выпить зелье маны
        public static void Act_Mana(Hero hero)
        {
            double n = (hero.MaxMp / 100.0) * 50.0;
            hero.MP += (int)n;
            Output.WriteColorLine(ConsoleColor.Blue, "Зелье маны восстановливает ", $"+{(int)n} ", "MP\n");
            Sound.DRINK();
        }

        //  Выпить противоядие
        public static void Act_Anti(Hero hero)
        {
            Console.WriteLine("Вы выпили противоядие и избавились от всех негативных эффектов");
            hero.Conditions.PoisentRound = 0;
            Sound.DRINK();
        }

        //  Выпить зелье силы
        public static void Act_Power(Hero hero)
        {
            hero.Conditions.Attack = 200;
            Console.WriteLine($"Ваша сила теперь {hero.Attack}");
    
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
