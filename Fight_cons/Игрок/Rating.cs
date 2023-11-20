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
    class TopPlayers
    {
        public string Name;
        public int Score;
    }

    class Rating
    {
        private static string Path = System.Windows.Forms.Application.StartupPath + "\\Palyers.xml";
        static string Name;
        static int Score;

        //  Список игроков
        public static List<TopPlayers> players = new List<TopPlayers>()
        {
            new TopPlayers(){ Name = "Van", Score = 1000},
            new TopPlayers(){ Name = "Lev", Score = 993},
            new TopPlayers(){ Name = "Lox", Score = 100},
        };

        public static void RatingSystem(Hero hero)
        {
            TopPlayers new_player = CountHeroScore(hero);
            SaveUserScore(new_player);

            //  Сортировка согласно новым данным
            players.Add(new_player);            
            var s = players.OrderBy(x => x.Score).ToList();

            ShowRaiting();
        }

        private static void SaveUserScore(TopPlayers user)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
                File.WriteAllText(Path, $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}<catalog></catalog>");
                foreach(var pl in players)
                {
                    SaveUserScore(pl);
                }
            }

            XDocument document = XDocument.Load(Path);

            XElement xelem = new XElement("record",
                new XElement("user_name", user.Name),
                new XElement("user_score", user.Score));

            document.Root.Add(xelem);
            document.Save(Path);
        }

        //  Запись нового игрока
        private static TopPlayers CountHeroScore(Hero hero)
        {
            TopPlayers player = new TopPlayers();

            Console.WriteLine("Назовите себя (имя более 1 символа):");
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
        public static void ShowRaiting()
        {
            XDocument document = XDocument.Load(Path);
            int num = 1;
            var list = document.Root.Elements().OrderByDescending(x => Convert.ToInt32(x.Element("user_score").Value));

            Console.WriteLine("\nЛокальный рейтинг:");
            foreach (XElement element in list)
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
