using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    internal class LocationDJ : FightCons.Locations
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
            MagicManHouse = 8,
            Dealer = 9,
        }

        public static string[][] Descript = new string[][]
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

        //  Выход со стартовой позиции
        public static bool ExitCave;
        #endregion

        #region Локации ДЖ

        //Лес1
        public static void Woods1(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти дальше\n"
                           + "3) Выйти из ДЖ";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Woods2(hero);
                        break;
                    case 3:
                        LocationVN.SpilledSpace(hero);
                        break;
                }
            }
        }

        //Лес2
        public static void Woods2(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес2\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти дальше\n"
                           + "3) Вернуться назад";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Woods3(hero);
                        break;
                    case 3:
                        Woods1(hero);
                        break;
                }
            }
        }

        //Лес3
        public static void Woods3(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес3\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти дальше\n"
                           + "3) Вернуться назад";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Woods4(hero);
                        break;
                    case 3:
                        Woods2(hero);
                        break;
                }
            }
        }

        //Лес4
        public static void Woods4(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес4\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти дальше\n"
                           + "3) Вернуться назад";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        MainWoods(hero);
                        break;
                    case 3:
                        Woods3(hero);
                        break;
                }
            }
        }

        //MainWoods
        public static void MainWoods(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Основной лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти к торговцу\n"
                           + "3) Вернуться назад";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Dealer(hero);
                        break;
                    case 3:
                        Woods4(hero);
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
                        MainWoods(hero);
                        break;
                }
            }
        }
        #endregion
    }
}
