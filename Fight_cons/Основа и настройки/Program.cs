using Fight_cons.Формы;
using System;
using System.Text;
using System.Windows.Forms;

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

            DifrentFiles.LoadBestiarList();

            DataFromWF.ConfigData();
            
            Hero.CreateHero(hero);
            Console.ReadKey();
        }
    }

    public class DataFromWF : Form
    {
        public static void ConfigData()
        {
            var ConfigTry = new ConfigTry().ShowDialog();             
        }
    }
}
