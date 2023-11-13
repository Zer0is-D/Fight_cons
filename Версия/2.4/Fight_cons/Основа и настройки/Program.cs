using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fight_cons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game";
            Console.WindowWidth = 80;
            Console.WindowHeight = 25;
            Hero hero = new Hero();

            Outer.Game_logo(vers: "2.4");

            if (Settings.Bild_vers_active)
                Settings.Option_vers(hero);

            Settings.Option_sound(hero);
            Settings.Option_wait_skip(hero);

            hero.Creat_hero(hero);
            Console.ReadKey();
        } 
    }
}
