using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fight_cons.form;

namespace Fight_cons
{
    class Input
    {
        static string[] Keywords = new string[] { "сохранить", "save", "инвентарь", "статы", "inv", "д_200", "настройки", "инв", "хелп", "help", "тп", "tp", "gold_100" };

        //  Выбор героя
        public static sbyte Chois_input(Hero hero, sbyte b1, sbyte b2)
        {
            do { hero.Choice = Sbyte_input(hero); }
            while (!(hero.Choice > b1 && hero.Choice < b2));
            return hero.Choice;
        }

        //  Выбор героя во время боя
        public static sbyte Chois_input(sbyte hero_choice, sbyte b1, sbyte b2)
        {
            do { hero_choice = Sbyte_input(); }
            while (!(hero_choice > b1 && hero_choice < b2));
            return hero_choice;
        }

        //  Проверка на sbyte без ключевых слов
        public static sbyte Sbyte_input()
        {
            string str;
            sbyte x;
            do { str = Console.ReadLine(); }
            while (!sbyte.TryParse(str, out x));
            
            return x;
        }

        //  Проверка на sbyte без ключевых слов
        public static string Name_input()
        {
            string str;
            do { str = Console.ReadLine(); }
            while ( str.Count() < 2);

            return str;
        }

        //  Проверка на sbyte с ключевыми словами
        public static sbyte Sbyte_input(Hero hero)
        {
            string str;
            sbyte x;
            do { str = Console.ReadLine(); }
            while (!sbyte.TryParse(str, out x) && !CheckKey(str));

            //  Если есть ключевое слово
            if (CheckKey(str))
            {
                Action_id(hero, str);
                return 0;
            }
            Console.Write("\n");

            return x;
        }       

        //  Проверка на ключевые слова
        public static bool CheckKey(string str)
        {
            bool ans = false;
            for (byte i = 0; i < Keywords.Length && !ans; i++)
                ans = Keywords[i] == str;
            return ans;
        }

        public async static void Action_id(Hero hero, string x)
        {
            if(x.ToLower() == Keywords[0] || x.ToLower() == Keywords[1])
            {
                //сохранить игру
            }

            if (x.ToLower() == Keywords[2] || x.ToLower() == Keywords[3] || x.ToLower() == Keywords[4])
                hero.Stats();

            if (x.ToLower() == Keywords[5])
            {
                Console.WriteLine($"А ПОСОСАТЬ НЕ ХОЧЕШЬ?");
                //hero.money += 200;
            }

            if (x.ToLower() == Keywords[6])
            {
                Console.WriteLine();
                Settings.Option_sound(hero);
                Settings.Option_wait_skip(hero);
            }

            if (x.ToLower() == Keywords[7])
                Inventory.Inventory_open(hero);

            if (x.ToLower() == Keywords[8] || x.ToLower() == Keywords[9])
                Outer.Help();

            if (x.ToLower() == Keywords[10] || x.ToLower() == Keywords[11])
                Teleport(hero);

            if (x.ToLower() == Keywords[12])
                hero.money += 100;
        }

        //  Телепортация
        public static void Teleport(Hero hero)
        {
            Map map = new Map(hero);
            DialogResult res = map.ShowDialog();

            if (res == DialogResult.OK)
            {
                Type loc = typeof(Location);
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
