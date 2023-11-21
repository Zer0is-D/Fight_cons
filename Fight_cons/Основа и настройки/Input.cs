using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Fight_cons.form;

namespace Fight_cons
{
    class Input
    {
        //  Проверка на соответствие
        public static int ChoisInput(Hero hero, sbyte minNum, sbyte maxNum)
        {
            int s = 0;
            do { s = SbyteInput(hero); }
            while (!(s > minNum - 1 && s < maxNum + 1));
            return s;
        }
        
        //  Проверка c ключевыми словами
        public static sbyte SbyteInput(Hero hero)
        {
            Dictionary<string, Action> KeyWords = new Dictionary<string, Action>();
            KeyWords["save"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            KeyWords["сохранить"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            KeyWords["инвентарь"] = () => { Inventory.ShowInventory(hero); };
            KeyWords["inv"] = () => { Inventory.ShowInventory(hero); };
            KeyWords["инв"] = () => { Inventory.ShowInventory(hero); };
            KeyWords["статы"] = () => { hero.ShowHeroStats(); };
            KeyWords["stats"] = () => { hero.ShowHeroStats(); };
            KeyWords["help"] = () => 
            {
                Console.WriteLine("\nКлючевые слова:\n");
                Output.WriteColorLine(ConsoleColor.Cyan, "", "инв ", "- вызов инвентаря (в разработке)\n");
                Output.WriteColorLine(ConsoleColor.Cyan, "", "статы ", "- вызов меню характеристики героя\n");
                Output.WriteColorLine(ConsoleColor.Cyan, "", "настройки ", "- вызов меню настроек\n");
                
            };
            KeyWords["настройки"] = () =>
            {
                Console.WriteLine();
                Settings.Option_sound(hero);
                Settings.OptionWaitSkip(hero);
            };
            //KeyWords["tp"] = () => { Teleport(hero); };
            //KeyWords["тп"] = () => { Teleport(hero); };
            KeyWords["gold_"] = () => 
            {
                int m;

                int.TryParse(Console.ReadLine(), out m);
                hero.Money += m;
            };
            KeyWords["uphp"] = () => { hero.MaxHp = 300; hero.HP = hero.MaxHp;  };

            string str;
            sbyte x;
            do
            {
                str = Console.ReadLine();
                if (KeyWords.ContainsKey(str.ToLower()))
                    KeyWords[str.ToLower()].Invoke();
            }
            while (!sbyte.TryParse(str, out x));

            return x;
        }

        //  Проверка выбора во время боя
        public static int ChoisInput(sbyte b1, sbyte b2)
        {
            int s = 0;
            do { s = SbyteInput(); }
            while (!(s > b1 - 1 && s < b2 + 1));
            return s;
        }

        public static int SbyteInput()
        {
            string str;
            sbyte x;
            do { str = Console.ReadLine(); }
            while (!sbyte.TryParse(str, out x));

            return x;
        }   

        //  Телепортация
        public static void Teleport(Hero hero)
        {
            Map map = new Map(hero);
            DialogResult res = map.ShowDialog();

            if (res == DialogResult.OK)
            {
                Type loc = typeof(AboutLoc);
                MethodInfo method = loc.GetMethod(map.CalledLocation);
                method.Invoke(hero);
            }
        }
    }

    //  Для телепорта
    static class Extension
    {
        public static object Invoke(this MethodInfo info, Hero hero)
        {
            return info.Invoke(null, new Hero[] { hero });
        }
    }
}
