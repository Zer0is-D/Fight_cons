using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FightCons.CoreNSettings.Map;

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
            //if (GameFormulas.Vero(0.3))
            //{
            //    List<BattleSession> battleList = new List<BattleSession>()
            //    {
            //        new BattleSession(10, Character.ChaRole.Enemy),
            //        new BattleSession(5, Character.ChaRole.Enemy),
            //    };
            //    Battles.MakeCurrentBattle(hero, battleList);
            //}
                

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Разлитый космос\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SpilledSpace), Descript), 0);

                hero.HPnMPBar(true, true);

                string quo = FindBoss ? "Пойти в хоромы" : "Бродить";

                Console.WriteLine("\nВаши действия?");
                Console.WriteLine($"1) {quo}");
                Output.WriteColorLine(hero.HeroQuests.Que[1] == 2 ? ConsoleColor.DarkGray : ConsoleColor.Gray, "", "2) Точка ИСС\n");
                Output.WriteColorLine(hero.HeroQuests.Que[2] == 2 ? ConsoleColor.DarkGray : ConsoleColor.Gray, "", "3) Точка ДЖ\n");
                Output.WriteColorLine(hero.HeroQuests.Que[3] == 2 ? ConsoleColor.DarkGray : ConsoleColor.Gray, "", "4) Точка БТЛ\n");
                Output.WriteColorLine(hero.HeroQuests.Que[4] == 2 ? ConsoleColor.DarkGray : ConsoleColor.Gray, "", "5) Точка ОП\n");
                Output.WriteColorLine(hero.HeroQuests.Que[5] == 2 ? ConsoleColor.DarkGray : ConsoleColor.Gray, "", "6) Точка ПП\n");
                Output.WriteColorLine(hero.HeroQuests.Que[6] == 2 ? ConsoleColor.DarkGray : ConsoleColor.Gray, "", "7) Точка НД\n");
                Console.WriteLine("8) Отдохнуть\n");

                switch (Input.ChoisInput(hero, 1, 8))
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
                            {
                                List<BattleSession> battleList = new List<BattleSession>()
                                {
                                    new BattleSession(10, Character.ChaRole.Enemy),
                                    new BattleSession(11, Character.ChaRole.Enemy),
                                    new BattleSession(12, Character.ChaRole.Enemy),
                                };
                                Battles.MakeRandomBattle(hero, battleList);
                            }                                
                        }
                        break;
                    case 2:
                        LocationISS.CavesStart(hero);
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.DJStartPoint;
                        LocationDJ.Woods1(hero);
                        break;
                    case 4:
                        hero.HeroCoordinates = transit.BTLStartPoint;
                        LocationBTL.Deepwoods(hero);
                        break;
                    case 5:
                        LocationOP.Island1(hero);
                        break;
                    case 6:
                        hero.HeroCoordinates = transit.PPStartPoint;
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
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(2, Character.ChaRole.Enemy),
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }
                    break;
                }
            }
        }
    }
}
