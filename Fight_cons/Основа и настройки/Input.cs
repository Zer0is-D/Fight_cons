using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fight_cons.form;
using Fight_cons.Основа_и_настройки;

namespace Fight_cons
{
    class Input
    {
        //  Проверка с героем 
        public static int Chois_input(Hero hero, sbyte b1, sbyte b2)
        {
            int s = 0;
            do { s = Sbyte_input(hero); }
            while (!(s > b1 - 1 && s < b2 + 1));
            return s;
        }
        
        //  Проверка на sbyte c ключевыми словами
        public static sbyte Sbyte_input(Hero hero)
        {
            Dictionary<string, Action> KeyWords = new Dictionary<string, Action>();
            KeyWords["save"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            KeyWords["сохранить"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            KeyWords["инвентарь"] = () => { Inventory.Inventory_open(hero); };
            KeyWords["inv"] = () => { Inventory.Inventory_open(hero); };
            KeyWords["инв"] = () => { Inventory.Inventory_open(hero); };
            KeyWords["статы"] = () => { hero.Stats(); };
            KeyWords["stats"] = () => { hero.Stats(); };
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
                Settings.Option_wait_skip(hero);
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

        //  Выбор героя во время боя
        public static int Chois_input(sbyte b1, sbyte b2)
        {
            int s = 0;
            do { s = Sbyte_input(); }
            while (!(s > b1 - 1 && s < b2 + 1));
            return s;
        }

        public static int Sbyte_input()
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
