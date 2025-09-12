using FightCons.WForms;
using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FightCons.World.Locations;
using static FightCons.CoreNSettings.Map;

namespace FightCons
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.Title = "Game";

            Settings.RecommendedWindowSize();

            Hero hero = new Hero(25, 10);

            Output.GameLogo(vers: "Universa 0.1 (Преальфа)");

            EnemyFromXML.LoadBestiaryList();

            // TODO Доработать позже 
            DataFromWF.ConfigData();
            //Settings.DelayEffects = false;

            sbyte StartPoint;

            if (!Settings.SkipStart)
                StartPoint = Hero.CreateHero(hero);
            else
                StartPoint = Hero.TestStart(hero);

            switch (StartPoint)
            {
                case 1:
                    LocationISS.CavesStart(hero);
                    break;
                case 2:
                    hero.HeroCoordinates = transit.DJStartPoint;
                    LocationDJ.Woods1(hero);
                    break;
                case 3:
                    hero.HeroCoordinates = transit.BTLStartPoint;
                    LocationBTL.Deepwoods(hero);
                    break;
                case 4:
                    LocationOP.Island1(hero);
                    break;
                case 5:
                    hero.HeroCoordinates = transit.PPStartPoint;
                    LocationPP.Coast(hero);
                    break;
                case 6:
                    LocationND.Island1(hero);
                    break;
            }

            Console.ReadKey();
        }
    }

    public class DataFromWF : Form
    {
        public static void ConfigData() => new ConfigTry().ShowDialog();
    }
}
