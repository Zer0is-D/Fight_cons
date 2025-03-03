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

        //  Выход со стартовой позиции
        public static bool FindBoss;
        #endregion

        //  Разлитый космос
        public static void SpilledSpace(Hero hero)
        {
            if (GameFormulas.Vero(0.3))
                Battles.MakeCurrentBattle(hero, 10, 5);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Разлитый космос\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SpilledSpace), Descript), 0);

                hero.HPBar();
                hero.MPBar();

                string quo;

                if (FindBoss)
                {
                    quo = "\nВаши действия?\n"
                        + "1) Пойти в хоромы\n"
                        + "2) Точка ИСС\n"
                        + "3) Точка ДЖ\n"
                        + "4) Точка БТЛ\n"
                        + "5) Точка ОП\n"
                        + "6) Точка ПП\n"
                        + "7) Точка НД\n"
                        + "8) Отдохнуть";
                }
                else
                {
                    quo = "\nВаши действия?\n"
                        + "1) Бродить\n"
                        + "2) Точка ИСС\n"
                        + "3) Точка ДЖ\n"
                        + "4) Точка БТЛ\n"
                        + "5) Точка ОП\n"
                        + "6) Точка ПП\n"
                        + "7) Точка НД\n"
                        + "8) Отдохнуть\n";
                }

                switch (Input.ChoisInput(hero, 1, 8, quo))
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
                                Battles.MakeRandomBattle(hero, 10, 11, 12);
                        }
                        break;
                    case 2:
                        LocationISS.CavesStart(hero);
                        break;
                    case 3:
                        LocationDJ.Woods1(hero);
                        break;
                    case 4:
                        LocationBTL.Deepwoods(hero);
                        break;
                    case 5:
                        LocationOP.Island1(hero);
                        break;
                    case 6:
                        LocationPP.Coast(hero);
                        break;
                    case 7:
                        LocationND.Island1(hero);
                        break;
                    case 8:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 2, 3);
                        }
                    break;
                }
            }
        }
    }
}
