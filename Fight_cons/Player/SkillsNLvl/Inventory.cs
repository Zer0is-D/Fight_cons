using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FightCons
{
    internal class Inventory
    {
        private static sbyte _inventoryMax = 10;

        public static void ShowInventory(Hero hero)
        {
            sbyte countItems = (sbyte)hero.CharacterInventory.Count();
            Console.WriteLine($"Ваш инвентарь: [{countItems}/{_inventoryMax}]");

            if (hero.CharacterInventory.Count() == 0)
                Console.WriteLine("(Пусто)");
            else
            {
                sbyte i = 1;
                foreach (var inv in hero.CharacterInventory)
                {
                    Console.WriteLine($"{i}. {inv.Name}\n");
                    i++;
                }
            }
        }

        internal static void ItemAdd(Character character, InventoryItem inventoryItem, sbyte count = 1, bool MustHave = false)
        {
            //ItemChar item = new ItemChar(name, ItemTypes.Item);
            if (character.CharacterInventory.Any(n => n.Name == inventoryItem.Name))
            {
                //if ()
                    character.CharacterInventory[character.CharacterInventory.FirstOrDefault(n => n.Name == inventoryItem.Name).ID - 1].Count += count;

                Output.WriteColorLine(ConsoleColor.Green, "Предмет ", $"{inventoryItem.Name} ", $"x{count} добавлен в инвентарь!\n");

            }
            else
            {
                if (MustHave)
                {
                    inventoryItem.Count = count;
                    character.CharacterInventory.Add(inventoryItem);
                    inventoryItem.ID = character.CharacterInventory.Count;
                    Output.WriteColorLine(ConsoleColor.Green, "Предмет ", $"{inventoryItem.Name} ", $"x{count} добавлен в инвентарь!\n");
                    if (character.CharacterInventory.Count() >= 10)
                        Console.WriteLine("Инвентарь переполнен!");
                }
                else
                {
                    if (character.CharacterInventory.Count() + 1 == _inventoryMax)
                        Console.WriteLine("В инвентаре нет место!");
                    else
                    {
                        Output.WriteColorLine(ConsoleColor.Green, "Предмет ", $"{inventoryItem.Name} ", $"x{count} добавлен в инвентарь!\n");
                        inventoryItem.Count = count;
                        character.CharacterInventory.Add(inventoryItem);
                        inventoryItem.ID = character.CharacterInventory.Count;
                    }
                }
            }
        }

        public static void UseItem()
        {

        }
    }

    public class InventoryItem
    {
        //public delegate void ItemUse(Character character);

        //internal ItemUse InvItem;
        internal ItemsDele UseItem { get; set; }

        internal int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public sbyte Count { get; set; }

        internal string CountItems
        {
            get
            {
                if (Count > 0)
                    return $"(Осталось: {Count})";
                else
                    return $"(НЕДОСТУПНО)";
            }
        }

        //public InventoryItem(Character character)
        //{
        //    character.CharacterInventory.Add(this);
        //    ID = character.CharacterInventory.Count;
        //}

        public void ActivateItem(Character character, List<BattleSession> units)
        {
            if (Count > 0)
            {
                UseItem(character, units);
                Count--;
            }
        }

        public void SuperHeal(Character character, List<BattleSession> enemy)
        {
            Random random = new Random();
            float n = (float)(random.Next(-10, 10));
            character.HP += (short)n;
            if (n > 0)
                Output.WriteColorLine(ConsoleColor.Green, $"{Name} восстанавливает ", $"+{n} ", $"{Output.HPSymbol}\n");
            else
                Output.WriteColorLine(ConsoleColor.Red, $"{Name} сносит ", $"{n} ", $"{Output.HPSymbol}\n");

            Sound.DRINK();
        }

        public void HealPotion(Character character, List<BattleSession> enemy)
        {
            float n = (float)(character.MaxHp / 100.0 * 50.0);
            character.HP += (short)n;
            Output.WriteColorLine(ConsoleColor.Green, $"{Name} восстанавливает ", $"+{(int)n} ", $"{Output.HPSymbol}\n");
            Sound.DRINK();
        }

        //  Выпить зелье маны
        public void ManaPotion(Character character, List<BattleSession> enemy)
        {
            double n = (character.MaxMp / 100.0) * 50.0;
            character.MP += (int)n;
            Output.WriteColorLine(ConsoleColor.Blue, "Зелье маны восстанавливает ", $"+{(int)n} ", $"{Output.MPSymbol}\n");
            Sound.DRINK();
        }

        //  Выпить противоядие
        public void AntiPotion(Character character, List<BattleSession> enemy)
        {
            Console.WriteLine("Вы выпили противоядие и избавились от всех негативных эффектов");
            character.Condition.PoisingRound = 0;
            Sound.DRINK();
        }

        //  Выпить зелье силы
        //Бесиво 
        public void PowerPotion(Character character, List<BattleSession> enemy)
        {
            character.Condition.Attack = (short)(character.TotalAttack * 3);
            Console.WriteLine($"Ваша сила теперь {character.Attack}");

            Sound.DRINK();
        }

        //  Кислота
        public void AcidPotion(Character character, List<BattleSession> victim)
        {
            victim[BattleSession.SelectedUnit].character.Defense = 0;

            Output.NameAndId(character, true);
            Output.WriteColorLine(ConsoleColor.DarkGreen, "Применяет ", $"{Name} ", "на ");
            Output.NameAndId(victim[BattleSession.SelectedUnit].character);
            Console.Write($"теперь {victim[BattleSession.SelectedUnit].character.Name} без брони!");
        }

        //  Бомба
        public void Bomb(Character attacker, List<BattleSession> victim)
        {
            //short damage = GameFormulas.Damage(10, victim[BattleSession.SelectedUnit].character);

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Yellow, "", $"взрывает ", "бомбу");

            foreach (BattleSession s in victim)
            {
                if (s.character.Role == Character.ChaRole.Enemy || s.character.Role == Character.ChaRole.Wild)
                {
                    short damage = GameFormulas.Damage(10, s.character);

                    Console.Write("\n\t");
                    Output.NameAndId(s.character);
                    Output.WriteColorLine(ConsoleColor.Yellow, "получает ", $"{damage} ", "урона");
                    s.character.HP -= damage;
                    Thread.Sleep(100);
                }
            }           
           
            //Output.WriteColorLine(ConsoleColor.Red, " ", $"{victim[BattleSession.SelectedUnit].character.HP - damage} ", $"{Output.HPSymbol}\n");        

            attacker.Statistic.Attacks++;
            Console.WriteLine();
            //attacker.Statistic.ChaActions.Add(12);
        }
    }
}
