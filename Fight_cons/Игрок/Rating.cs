using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace Fight_cons
{
    class Rating
    {
        private static string path = System.Windows.Forms.Application.StartupPath + "\\Palyers.xml";
        static string Name;
        static int Score;

        public static List<TopPlayers> players_ = new List<TopPlayers>()
        {
            new TopPlayers(){ Name = "Van", Score = 1000},
            new TopPlayers(){ Name = "Lev", Score = 993},
            new TopPlayers(){ Name = "Lox", Score = 100},
        };

        public static void Rating_system(Hero hero)
        {
            TopPlayers new_player = Total_score(hero);
            Save_user_score(new_player);

            //  Сортировка согласно новым данным
            players_.Add(new_player);            
            var s = players_.OrderBy(x => x.Score).ToList();

            Score_view();
        }

        private static void Save_user_score(TopPlayers user)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}<catalog></catalog>");
                foreach(var pl in players_)
                {
                    Save_user_score(pl);
                }
            }

            XDocument document = XDocument.Load(path);

            XElement xelem = new XElement("record",
                new XElement("user_name", user.Name),
                new XElement("user_score", user.Score));

            document.Root.Add(xelem);
            document.Save(path);
        }

        //  Запись нового игрока
        private static TopPlayers Total_score(Hero hero)
        {
            Console.WriteLine("Назовите себя (имя более 1 символа):");
            TopPlayers player = new TopPlayers();
            Name = player.Name = Console.ReadLine();
            Score = player.Score = (int)(
                (hero.Lvl * 10) +
                (hero.Exp * 2) +
                hero.TotalMaxHP +
                hero.PermanentBonuses.MaxHp +
                hero.TotalMaxMP +
                hero.PermanentBonuses.MaxMp +
                hero.TotalAttack +
                hero.PermanentBonuses.Attack +
                hero.TotalArcane +
                hero.PermanentBonuses.Arcane +
                hero.TotalSpeed +
                hero.PermanentBonuses.Speed +
                hero.TotalCrit +
                hero.PermanentBonuses.Crit +
                hero.TotalDefence +
                hero.PermanentBonuses.Defence +
                hero.TotalMagicDefence +
                hero.PermanentBonuses.MagicDefence +
                hero.TotalBlock +
                hero.PermanentBonuses.Block +
                hero.TotalMaxMoves +
                hero.PermanentBonuses.MaxMoves);

            return player;
        }

        //  Вывод рейтинга
        public static void Score_view()
        {
            XDocument document = XDocument.Load(path);
            int num = 1;
            var xes = document.Root.Elements().OrderByDescending(x => Convert.ToInt32(x.Element("user_score").Value));

            Console.WriteLine("\nЛокальный рейтинг:");
            foreach (XElement element in xes)
            {
                if (num < 21)
                    Console.WriteLine($"{num++}) {element.Element("user_name").Value}: {element.Element("user_score").Value}");
                else
                {
                    Console.WriteLine($"...) {Name}: {Score}");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
