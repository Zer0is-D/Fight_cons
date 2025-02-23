using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightCons.World.Locations
{
    internal class LocationVN : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            SpilledSpace = 0
        }

        public static string[][] Descript = new string[][]
        {
            //  Разлитый космос
            new string[]
            {
                "...",
            }
        };

        private static string Descriptions(byte i)
        {
            Random rand = new Random();
            return Descript[i][rand.Next(Descript[i].Length)];
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
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Разлитый космос\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SpilledSpace)), 1);

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
                        LocationISS.Valley(hero);
                        break;
                }
            }
        }
    }
}
