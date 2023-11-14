using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Fight_cons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game";
            Console.SetWindowSize(80, 30);
            Console.OutputEncoding = Encoding.Unicode;

            Hero hero = new Hero(25, 10);

            Output.Game_logo(vers: "2.6 (Альфа)");

            if (Settings.BildVersActive)
                Settings.OptionVersions(hero);

            Settings.OptionWaitSkip(hero);

            Hero.Creat_hero(hero);
            Console.ReadKey();
        }
    }
}
