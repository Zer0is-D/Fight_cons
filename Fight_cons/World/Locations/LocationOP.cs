using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    internal class LocationOP : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            Island1 = 0,
            KitegeCity = 1,
            PereplutTemple = 2,
            Kronstandt = 3,
            NovoiavCity = 4,
            CoralWall = 5,
            PalkinRestaurant = 6,
            NorthIsland = 7,
            Bazaar = 8
        }

        public static string[][] Descript = new string[][]
        {
            //Остров1
            new string[]
            {
                "...",
            },
            //Город Китеж
            new string[]
            {
                "...",
            },
            //Храм Переплута
            new string[]
            {
                "...",
            },
            //Город-порт Кронштандт
            new string[]
            {
                "...",
            },
            //Город Новоявь
            new string[]
            {
                "...",
            },
            //Коралловая стена
            new string[]
            {
                "...",
            },
            //Ресторан Палкинъ
            new string[]
            {
                "...",
            },
            //Северные острова
            new string[]
            {
                "...",
            },
        };

        //  Выход со стартовой позиции
        public static bool ExitCave;
        #endregion

        #region Локации ОП

        //Остров1
        public static void Island1(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Остров1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Island1), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Плыть в город Китеж\n"
                           + "3) Отдохнуть\n"
                           + "4) Выйти из ОП";


                switch (Input.ChoisInput(hero, 1, 4, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        KitegeCity(hero);
                        break;
                    case 3:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 1, 2, 3);
                        }
                        break;
                    case 4:
                        LocationVN.SpilledSpace(hero);
                        break;
                }
            }
        }

        //Город Китеж
        public static void KitegeCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Китеж\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.KitegeCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти в храм Переплута\n"
                           + "3) Плыть в Кронштандт\n"
                           + "4) Отдохнуть\n"
                           + "5) Вернуться на остров1";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        PereplutTemple(hero);
                        break;
                    case 3:
                        Kronstandt(hero);
                        break;
                    case 4:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 1, 2, 3);
                        }
                        break;
                        break;
                    case 5:
                        Island1(hero);
                        break;
                }
            }
        }

        //Храм Переплута
        //TODO возможность помолиться
        public static void PereplutTemple(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Храм Переплута\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.PereplutTemple), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        KitegeCity(hero);
                        break;
                }
            }
        }

        //Базар
        public static void Bazaar(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Базар\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Bazaar), Descript), 1);

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
                        KitegeCity(hero);
                        break;
                }
            }
        }

        //Город-порт Кронштандт
        public static void Kronstandt(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город-порт Кронштандт\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Kronstandt), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти к контрабандистам\n"
                           + "3) Плыть в город Новоявь\n"
                           + "4) Отдохнуть\n"
                           + "5) Плыть в город Китеж";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Contrabandist(hero);
                        break;
                    case 3:
                        NovoiavCity(hero);
                        break;
                    case 4:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 1, 2, 3);
                        }
                        break;
                    case 5:
                        KitegeCity(hero);
                        break;
                }
            }
        }

        //Контрабандисты
        public static void Contrabandist(Hero hero)
        {
            while (true)
            {
                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\n- Че надо?\n");

                Console.WriteLine("\nВаши действия?\n"
                          + "1) Купить оружие\n"
                          + "2) Купить броню");
                Output.PayMoneyLine("3) Купить зелье здоровья", Output.PotionHPCost, hero.Money);
                Output.PayMoneyLine("4) Купить зелье маны", Output.PotionMPCost, hero.Money);
                Console.WriteLine("5) Уйти");

                switch (Input.ChoisInput(hero, 1, 6))
                {
                    case 1:
                        MarketMethods.ShowWeaponGoods(hero);
                        break;

                    case 2:
                        MarketMethods.ShowArmorGoods(hero);
                        break;

                    case 3:
                        if (Output.Spent(hero.Money, Output.PotionHPCost, "Зелье здоровья", "\nВы нищеброд! Проваливайте!\n"))
                            hero.PotionList[0].Count += 1;
                        break;

                    case 4:
                        if (Output.Spent(hero.Money, Output.PotionMPCost, "Зелье маны", "\nВы нищеброд! Проваливайте!\n"))
                            hero.PotionList[1].Count += 1;
                        break;

                    case 5:
                        Kronstandt(hero);
                        break;
                }
            }
        }

        //Город Новоявь
        public static void NovoiavCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новоявь\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NovoiavCity), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти к коралловой стене\n"
                           + "3) Пойти в ресторан Палкинъ\n"
                           + "4) Плыть на северные острова\n"
                           + "5) Отдохнуть\n"
                           + "6) Плыть в Кронштандт";


                switch (Input.ChoisInput(hero, 1, 6, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        CoralWall(hero);
                        break;
                    case 3:
                        PalkinRestaurant(hero);
                        break;
                    case 4:
                        NorthIsland(hero);
                        break;
                    case 5:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 1, 2, 3);
                        }
                        break;
                    case 6:
                        Kronstandt(hero);
                        break;
                }
            }
        }

        //Коралловая стена
        public static void CoralWall(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Коралловая стена\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.CoralWall), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NovoiavCity(hero);
                        break;
                }
            }
        }

        //Ресторан Палкинъ
        //TODO Возможность поесть
        public static void PalkinRestaurant(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Ресторан Палкинъ\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.PalkinRestaurant), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NovoiavCity(hero);
                        break;
                }
            }
        }

        //Северные острова
        public static void NorthIsland(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Северные острова\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NorthIsland), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Плыть в город Новоявь";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NovoiavCity(hero);
                        break;
                }
            }
        }
        #endregion
    }
}
