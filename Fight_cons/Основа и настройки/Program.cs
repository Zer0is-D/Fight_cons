using System;
using System.Text;

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

            Output.GameLogo(vers: "2.6 (Альфа)");
            //AboutLoc.AnatherConsole();

            if (Settings.BildVersActive)
                Settings.OptionVersions(hero);

            Settings.OptionWaitSkip(hero);

            Hero.CreateHero(hero);
            Console.ReadKey();
        }
    }
}
