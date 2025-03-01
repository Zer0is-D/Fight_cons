using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    internal class LocationBTL : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            Deepwoods = 0,
            EastWoods = 1,
            NorthWoods = 2,
            Gigantopolis = 3,
            Market = 4,
            MainSquare = 5,
            Palace = 6,
            Administration = 7,
            Quarry = 8
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

        //TODO убрать ненужную переменную
        //  Выход со стартовой позиции
        public static bool ExitCave;
        #endregion

        #region Локации БТЛ
        
        //Глубоколесье
        public static void Deepwoods(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Глубоколесье\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Deepwoods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                            + "1) Бродить\n"
                            + "2) Пойти в северные леса\n"
                            + "3) Пойти в восточные леса\n"
                            + "4) Отдохнуть\n"
                            + "5) Выйти из БТЛ";

                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Бродить
                        break;
                    case 2:
                        NorthWoods(hero);
                        break;
                    case 3:
                        EastWoods(hero);
                        break;
                    case 4:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 5);
                        }
                        break;
                    case 5:
                        LocationVN.SpilledSpace(hero);
                        break;
                }
            }
        }

        //Восточный лес
        public static void EastWoods(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Восточный лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.EastWoods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Пойти в Гигантополь\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в глубоколесье";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        Gigantopolis(hero);
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
                        Deepwoods(hero);
                        break;
                }
            }
        }

        //Северный лес
        public static void NorthWoods(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Северный лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NorthWoods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Пойти в Гигантополь\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в глубоколесье";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        Gigantopolis(hero);
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
                        Deepwoods(hero);
                        break;
                }
            }
        }

        //Гигантополь
        public static void Gigantopolis(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Гигантополь\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Gigantopolis), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Бродить\n"
                           + "2) Пойти на главную площадь\n"
                           + "3) Пойти на рынок\n"
                           + "4) Пойти в Дом Ремесленников\n"
                           + "5) Пойти в северный лес\n"
                           + "6) Пойти в восточный лес\n"
                           + "7) Пойти к карьеру";

                switch (Input.ChoisInput(hero, 1, 7, quo))
                {
                    case 1:
                        //TODO Бродить
                        break;
                    case 2:
                        MainSquare(hero);
                        break;
                    case 3:
                        Market(hero);
                        break;
                    case 4:
                        EneHouse(hero);
                        break;
                    case 5:
                        NorthWoods(hero);
                        break;
                    case 6:
                        EastWoods(hero);
                        break;
                    case 7:
                        Quarry(hero);
                        break;
                }
            }
        }

        //Рынок
        public static void Market(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Рынок\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Market), Descript), 1);

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
                        Gigantopolis(hero);
                        break;
                }
            }
        }

        //Дом ремесленников 
        public static void EneHouse(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Рынок\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Market), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                          + "1) Наблюдать и подслушивать\n"
                          + "2) Купить оружие\n"
                          + "3) Купить броню");
                Console.WriteLine("4) Выйти");

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
                        Gigantopolis(hero);
                        break;
                }
            }
        }

        //Главная площадь
        public static void MainSquare(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Главная площадь\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.MainSquare), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Войти в дворец\n"
                           + "2) Войти в канцелярию\n"
                           + "3) Вернуться";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        Palace(hero);
                        break;
                    case 2:
                        Administration(hero);
                        break;
                    case 3:
                        Gigantopolis(hero);
                        break;
                }
            }
        }

        //Дворец
        public static void Palace(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Дворец\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Palace), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Уйти";

                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        MainSquare(hero);
                        break;
                }
            }
        }

        //Канцелярия 
        public static void Administration(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Канцелярия\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Administration), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Уйти";

                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        MainSquare(hero);
                        break;
                }
            }
        }

        //Штаб вольных клинков
        /*
        public static void Lorem(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Решноми\n");
                Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Войти в деревню\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        VillageOrdo(hero);
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
                        Vally(hero);
                        break;
                }
            }
        }

        //Дом Союза Вольных Дельцов
        public static void Lorem(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Решноми\n");
                Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Войти в деревню\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        VillageOrdo(hero);
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
                        Vally(hero);
                        break;
                }
            }
        }

        //Дом ремесленников
        public static void Lorem(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Решноми\n");
                Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Войти в деревню\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        VillageOrdo(hero);
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
                        Vally(hero);
                        break;
                }
            }
        }
        //Дом знаний
        public static void Lorem(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Решноми\n");
                Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Войти в деревню\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        VillageOrdo(hero);
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
                        Vally(hero);
                        break;
                }
            }
        }
        */


        //Карьер
        public static void Quarry(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Карьер\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Quarry), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Уйти";

                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Gigantopolis(hero);
                        break;
                }
            }
        }
        #endregion
    }
}
