using FightСons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightСons.World.Locations
{
    internal class LocationBoss : FightСons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            CaveStart = 0,
            Caves = 1,
            Vally = 2,
            OrdoNeighborhood = 3,
            VillageOrdo = 4,
            Inn = 5,
            Market = 6,
            Woods = 7,
            MagicManHouse = 8
        }

        public static string[][] Discript = new string[][]
        {
            //  Пещеры
            new string[]
            {
                "...",
                "...",
                "...",
            },
            //  Долина
            new string[]
            {
                "...",
                "...",
                "...",
            },
            //  Окрестности Ордо
            new string[]
            {
                "...",
                "...",
                "...",
            },
            //  Деревня Ордо
            new string[]
            {
                "...",
                "...",
                "...",
            },
            //  Трактир
            new string[]
            {
                "...",
                "...",
                "...",
            },
            //  Рынок
            new string[]
            {
                "...",
                "...",
                "...",
            },
            //  Леса
            new string[]
            {
                "...",
                "...",
                "...",
            },
            //  Храм
            new string[]
            {
                "111",
            }
        };

        private static string Dicscriptions(byte i)
        {
            Random rand = new Random();
            return Discript[i][rand.Next(Discript[i].Length)];
        }

        /// <summary>
        /// Список противников
        /// </summary>
        public static List<Order> ListOfUnits = new List<Order>();
        #endregion

        //  Хоромы
        public static void Endroom(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Хоромы\n");
                Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                            + "1) Бродить\n"
                            + "2) Отдохнуть\n"
                            + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //  Босс
                        if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[0] == 2)
                        {
                            //TODO Сделать боссфайт финальный
                            hero.HeroQuests.Que[0] = 3;
                            //hero.HeroQuests.MainQ(hero);
                        }
                        else if (GameFormulas.Vero(0.6))
                            Battles.MakeRandomBattle(hero, 4, 5);
                        else
                            Output.TwriteLine("Вы ничего не находите\n", 1);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 4, 5);
                        }
                        break;
                    case 3:
                        LocationISS.Vally(hero);
                        break;
                }
            }
        }
    }
}
