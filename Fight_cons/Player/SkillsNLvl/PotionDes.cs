using System;

namespace FightCons
{
    //public delegate void PotionUse(Hero hero);
    public delegate void PotionUse(Character character);

    public class PotionDes
    {
        internal PotionUse Potion;
        //internal PotionUseParty PotionParty;

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
        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public PotionDes(Character character)
        {
            character.PotionList.Add(this);
            ID = character.PotionList.Count;
        }

        public void Drink(Character character)
        {
            if (Count > 0)
            {
                Potion(character);
                Count--;
            }
        }
        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        //public void Drink(Character character)
        //{
        //    if (Count > 0)
        //    {
        //        PotionParty(character);
        //        Count--;
        //    }
        //}

        //  Выпить зелье лечения
        public static void HealPotion(Character character)
        {
            float n = (float)(character.MaxHp / 100.0 * 50.0);
            character.HP += (short)n;
            Output.WriteColorLine(ConsoleColor.Green, "Зелье лечения восстановливает ", $"+{(int)n} ", $"{Output.HPSymbol}\n"); 
            Sound.DRINK();
        }

        //  Выпить зелье маны
        public static void ManaPotion(Character character)
        {
            double n = (character.MaxMp / 100.0) * 50.0;
            character.MP += (int)n;
            Output.WriteColorLine(ConsoleColor.Blue, "Зелье маны восстановливает ", $"+{(int)n} ", $"{Output.MPSymbol}\n");
            Sound.DRINK();
        }

        //  Выпить противоядие
        public static void AntiPotion(Character character)
        {
            Console.WriteLine("Вы выпили противоядие и избавились от всех негативных эффектов");
            character.Condition.PoisingRound = 0;
            Sound.DRINK();
        }

        //  Выпить зелье силы
        public static void PowerPotion(Character character)
        {
            character.Condition.Attack = (short)(character.TotalAttack * 3);
            Console.WriteLine($"Ваша сила теперь {character.Attack}");
    
            Sound.DRINK();
        }
        //  больше ходов, больше маны, временных блоков, 
    }
}
