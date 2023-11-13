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

        public static List<Top_players> players_ = new List<Top_players>()
        {
            new Top_players(){ Name = "Van", Score = 1000},
            new Top_players(){ Name = "Lev", Score = 993},
            new Top_players(){ Name = "Lox", Score = 100},
        };

        public static void Rating_system(int hero_lvl, int hero_exp, int hero_money)
        {
            Top_players new_player = Total_score(hero_lvl, hero_exp, hero_money);
            Save_user_score(new_player);

            //  Сортировка согласно новым данным
            players_.Add(new_player);            
            var s = players_.OrderBy(x => x.Score).ToList();

            Score_view();
        }

        private static void Save_user_score(Top_players user)
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
        private static Top_players Total_score(int hero_lvl, int hero_exp, int hero_money)
        {
            Console.WriteLine("Назовите себя (имя более 1 символа):");
            Top_players player = new Top_players();
            Name = player.Name = Input.Name_input();
            Score = player.Score = (hero_lvl * 3) + (hero_exp * 2) + hero_money;

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

            Console.WriteLine("\nСкоро локальный рейтинг");

            Console.ReadKey();
        }
    }
}
