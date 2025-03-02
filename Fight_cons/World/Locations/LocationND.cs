using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    internal class LocationND : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            Island1 = 0,
            SectorDzeta = 1,
            NewIaregaCity = 2,
            SectorEtta = 3,
            NewEdinstvenyCity = 4,
            SectorTeta = 5,
            GeliotopolCity = 6,
            SectorCsi = 7,
            HladnyPrimeCity = 8,
            SectorOmicron = 9,
            Cosmolit = 10,
            DarkGranulation = 11,
            SectorPi = 12,
            VladichiaOrbitaCity = 13,
            SectorHi = 14,
            OldIaregaCity = 15,
            SectorPsi = 16,
            Cvantograd = 17,
            SectorOmega = 18,
            GreenVectorVillage = 19,
            Dealer = 20,
        }

        public static string[][] Descript = new string[][]
        {
            //  Island1
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" +
                "то примыкающие к большим крупицам",
            },
            //  SectorDzeta
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" +
                "то примыкающие к большим крупицам",
            },
            //  NewIaregaCity
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorEtta
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  NewEdinstvenyCity
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorTeta
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n"
                + "то примыкающие к большим крупицам",
            },
            //  GeliotopolCity
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorCsi
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  HladnyPrimeCity
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorOmicron
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  Cosmolit
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  DarkGranulation
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorPi
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  VladichiaOrbitaCity
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorHi
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  OldIaregaCity
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorPsi
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  Cvantograd
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorOmega
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  GreenVectorVillage
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
        };

        //  Выход со стартовой позиции
        public static bool ExitCave;
        #endregion

        #region Локации НД
        //Остров1
        public static void Island1(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Остров1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Island1), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Лететь в Сектор Дзета\n"
                           + "3) Выйти из НД";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorDzeta(hero);
                        break;
                    case 3:
                        LocationVN.SpilledSpace(hero);
                        break;
                }
            }
        }

        //Сектор Дзета
        public static void SectorDzeta(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Дзета\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorDzeta), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Лететь в город Новая Ярега\n"
                           + "3) Лететь в сектор Этта\n"
                           + "4) Лететь в сектор Пи\n"
                           + "5) Вернуться на остров1";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewIaregaCity(hero);
                        break;
                    case 3:
                        SectorEtta(hero);
                        break;
                    case 4:
                        SectorPi(hero);
                        break;
                    case 5:
                        Island1(hero);
                        break;
                }
            }
        }

        //Город Новая Ярега
        public static void NewIaregaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новая Ярега\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NewIaregaCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorDzeta(hero);
                        break;
                }
            }
        }

        //Сектор Этта
        public static void SectorEtta(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Этта\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorEtta), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Новый Единственный\n"
                           + "3) Лететь в сектор Тета\n"
                           + "4) Лететь в сектор Дзета\n"
                           + "5) Лететь в сектор Омикрон";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorTeta(hero);
                        break;
                    case 4:
                        SectorDzeta(hero);
                        break;
                    case 5:
                        SectorOmicron(hero);
                        break;
                }
            }
        }

        //Город Новый Единственный
        public static void NewEdinstvenyCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NewEdinstvenyCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "1) Пойти к торговцам\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Dealer(hero);  
                        break;
                    case 3:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Торговец
        public static void Dealer(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Торговец\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Dealer), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                          + "1) Наблюдать и подслушивать\n"
                          + "2) Купить оружие\n"
                          + "3) Купить броню");
                Output.PayMoneyLine("4) Купить зелье здоровья", Output.PotionHPCost, hero.Money);
                Output.PayMoneyLine("5) Купить зелье маны", Output.PotionMPCost, hero.Money);
                Console.WriteLine("6) Выйти");

                switch (Input.ChoisInput(hero, 1, 6))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;

                    case 2:
                        MarketMethods.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        MarketMethods.ShowArmorGoods(hero);
                        break;

                    case 4:
                        if (Output.Spent(hero.Money, Output.PotionHPCost, "Зелье здоровья", "\nВы нищеброд! Проваливайте!\n"))
                            hero.PotionList[0].Count += 1;
                        break;

                    case 5:
                        if (Output.Spent(hero.Money, Output.PotionMPCost, "Зелье маны", "\nВы нищеброд! Проваливайте!\n"))
                            hero.PotionList[1].Count += 1;
                        break;

                    case 6:
                        NewEdinstvenyCity(hero);
                        break;
                }
            }
        }

        //Сектор Тета
        public static void SectorTeta(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Тета\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorTeta), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Гелиотополь\n"
                           + "3) Лететь в сектор Этта\n"
                           + "4) Лететь в сектор Кси";


                switch (Input.ChoisInput(hero, 1, 4, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        GeliotopolCity(hero);
                        break;
                    case 3:
                        SectorEtta(hero);
                        break;
                    case 4:
                        SectorCsi(hero);
                        break;
                }
            }
        }

        //Город Гелиотополь
        public static void GeliotopolCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.GeliotopolCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorTeta(hero);
                        break;
                }
            }
        }

        //Сектор Кси
        public static void SectorCsi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Кси\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorCsi), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Новый Единственный\n"
                           + "3) Лететь в сектор Тета\n"
                           + "4) Лететь в сектор Омикрон\n"
                           + "5) Лететь в сектор Хи";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorTeta(hero);
                        break;
                    case 4:
                        SectorOmicron(hero);
                        break;
                    case 5:
                        SectorHi(hero);
                        break;
                }
            }
        }

        //Город Хладный Прайм
        public static void HladnyPrimeCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.HladnyPrimeCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Омикрон
        public static void SectorOmicron(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Омикрон\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorOmicron), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти к Космолиту\n"
                           + "3) Идти к Темной грануляции\n"
                           + "4) Лететь в сектор Этта\n"
                           + "5) Лететь в сектор Кси\n"
                           + "6) Лететь в сектор Пи\n"
                           + "7) Лететь в сектор Пси";


                switch (Input.ChoisInput(hero, 1, 7, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Cosmolit(hero);
                        break;
                    case 3:
                        DarkGranulation(hero);
                        break;
                    case 4:
                        SectorEtta(hero);
                        break;
                    case 5:
                        SectorCsi(hero);
                        break;
                    case 6:
                        SectorPi(hero);
                        break;
                    case 7:
                        SectorPsi(hero);
                        break;
                }
            }
        }

        //Космолит
        public static void Cosmolit(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Cosmolit), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Темная грануляция
        public static void DarkGranulation(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.DarkGranulation), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Пи
        public static void SectorPi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Пи\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorPi), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Владычья Орбита\n"
                           + "3) Лететь в сектор Дзета\n"
                           + "4) Лететь в сектор Омикрон\n"
                           + "5) Лететь в сектор Омега";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorDzeta(hero);
                        break;
                    case 4:
                        SectorOmicron(hero);
                        break;
                    case 5:
                        SectorOmega(hero);
                        break;
                }
            }
        }

        //Город Владычья Орбита
        public static void VladichiaOrbitaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.VladichiaOrbitaCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Хи
        public static void SectorHi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Хи\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorHi), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Старая Ярега\n"
                           + "3) Лететь в сектор Кси\n"
                           + "4) Лететь в сектор Пси";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorTeta(hero);
                        break;
                    case 4:
                        SectorOmicron(hero);
                        break;
                    case 5:
                        SectorDzeta(hero);
                        break;
                }
            }
        }

        //Город Старая Ярега
        public static void OldIaregaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Старая Ярега\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.OldIaregaCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Спуститься к ледникам\n"
                           + "3) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Glaciers(hero);
                        break;
                    case 3:
                        SectorHi(hero);
                        break;
                }
            }
        }

        //Ледники
        public static void Glaciers(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Ледники\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.OldIaregaCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[6] == 2 ? "1) Выйти из НД\n" : "1) Искать\n", 0);
                Output.TwriteLine("2) Отдохнуть\n"
                                + "3) Вернуться в Старую Ярегу", 1);


                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[6] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[6] == 0)
                            {
                                hero.HeroQuests.Que[6] = 1;
                                hero.HeroQuests.MainND(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                                Battles.MakeRandomBattle(hero, 4, 5);
                            else
                                Output.TwriteLine("Вы ничего не находите\n", 1);
                        }

                        //hero.Statistic.WoodsResearch++;
                        //Research(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 5);
                        }
                        break;
                    case 3:
                        OldIaregaCity(hero);
                        break;
                }
            }
        }

        //Сектор Пси
        public static void SectorPsi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Пси\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorPsi), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Квантоград\n"
                           + "3) Лететь в сектор Омикрон\n"
                           + "4) Лететь в сектор Хи\n"
                           + "5) Лететь в сектор Омега";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Cvantograd(hero);
                        break;
                    case 3:
                        SectorOmicron(hero);
                        break;
                    case 4:
                        SectorHi(hero);
                        break;
                    case 5:
                        SectorOmega(hero);
                        break;
                }
            }
        }

        //Квантоград
        public static void Cvantograd(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Квантоград\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Cvantograd), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Омега
        public static void SectorOmega(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Омега\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorOmega), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в поселение Зеленый Вектор\n"
                           + "3) Лететь в сектор Пи\n"
                           + "4) Лететь в сектор Пси";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        GreenVectorVillage(hero);
                        break;
                    case 3:
                        SectorPi(hero);
                        break;
                    case 4:
                        SectorPsi(hero);
                        break;
                }
            }
        }

        //Поселение Зеленый Вектор
        public static void GreenVectorVillage(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.GreenVectorVillage), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        #endregion
    }
}
