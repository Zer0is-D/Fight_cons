using FightСons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightСons.World.Locations
{
    internal class LocationVN : FightСons.Locations
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

        //  Выход со стартовой позиции
        public static bool FindBoss;
        #endregion

        //  Разлитый космос
        public static void SpilledSpace(Hero hero)
        {
            if (GameFormulas.Vero(0.3))
                Battles.MakeCurrentBattle(hero, 0, 9);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес\n");
                Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo;

                if (FindBoss)
                {
                    quo = "\nВаши действия?\n"
                        + "1) Пойти в хоромы\n"
                        + "2) Отдохнуть\n"
                        + "3) Вернуться в долину";
                }
                else
                {
                    quo = "\nВаши действия?\n"
                        + "1) Бродить\n"
                        + "2) Отдохнуть\n"
                        + "3) Вернуться в долину";
                }

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        if (FindBoss)
                            LocationBoss.Endroom(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.25))
                            {
                                Output.TwriteLine("\nВы находите вход\n", 1);
                                FindBoss = true;
                            }
                            else if (GameFormulas.Vero(0.6))
                                Battles.MakeRandomBattle(hero, 0, 1, 2);
                        }
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
