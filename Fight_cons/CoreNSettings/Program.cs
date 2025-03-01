using FightCons.WForms;
using System;
using System.Text;
using System.Windows.Forms;

namespace FightCons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Game";
            Console.SetWindowSize(80, 30);
            Console.OutputEncoding = Encoding.Unicode;

            Settings.RecommendedWindowSize();

            Hero hero = new Hero(25, 10);

            Output.GameLogo(vers: "Universa 1.0 (Преальфа)");

            EnemyFromXML.LoadBestiaryList();

            // TODO Доработать позже 
            //DataFromWF.ConfigData();
            Settings.DelayEffects = false;


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
