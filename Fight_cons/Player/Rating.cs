using System;
using System.Collections.Generic;
using System.Linq;
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
        private static string Name;
        private static int Score;

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
                for (sbyte i = 0; i < players.Count;)
                {
                    SaveUserScore(players[i]);                    
                    i++;
                }
            }            

            XDocument document = XDocument.Load(Path);

            XElement xelem = new XElement("record",
                new XElement("userName", user.Name),
                new XElement("userScore", user.Score));

            document.Root.Add(xelem);
            document.Save(Path);
        }

        //  Запись нового игрока
        private static TopPlayers CountHeroScore(Hero hero)
        {
            TopPlayers player = new TopPlayers();

            do
            {
                Console.WriteLine("Назовите себя (мин 3 символа):");
                Name = player.Name = Console.ReadLine();
            } while (Name.Length < 3);
            

            Score = player.Score = (int)(
                (hero.Lvl * 10) +
                (hero.Exp * 2) +
                hero.TotalMaxHP +
                hero.PermanentBonus.MaxHp +
                hero.TotalMaxMP +
                hero.PermanentBonus.MaxMp +
                hero.TotalAttack +
                hero.PermanentBonus.Attack +
                hero.TotalArcane +
                hero.PermanentBonus.Arcane +
                hero.TotalSpeed +
                hero.PermanentBonus.Speed +
                hero.TotalCrit +
                hero.PermanentBonus.Crit +
                hero.TotalDefence +
                hero.PermanentBonus.Defence +
                hero.TotalMagicDefence +
                hero.PermanentBonus.MagicDefence +
                hero.TotalBlock +
                hero.PermanentBonus.Block +
                hero.TotalMaxMoves +
                hero.PermanentBonus.Moves);

            return player;
        }

        //  Вывод рейтинга
        private static void ShowRaiting()
        {
            XDocument document = XDocument.Load(Path);
            int num = 1;
            var list = document.Root.Elements().OrderByDescending(x => Convert.ToInt32(x.Element("userScore").Value));

            Console.WriteLine("\nЛокальный рейтинг:");
            foreach (XElement element in list)
            {
                if (num < 21)
                    Console.WriteLine($"{num++}) {element.Element("userName").Value}: {element.Element("userScore").Value}");
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
