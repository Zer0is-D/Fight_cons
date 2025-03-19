using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    internal class LocationPP : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            Coast = 0,
            GreenGround = 1,
            Desert = 2,
            Nomads1 = 3,
            BanditTown = 4,
            Nomads2 = 5,
            RockValley = 6
        }

        public static string[][] Descript = new string[][]
        {
            //  Coast
            new string[]
            {
                //TODO Добавить описания
                "Охлаждающий морской бриз наступает на раскаленный океан песчинок",
            },
            //  GreenGround
            new string[]
            {
                //TODO Добавить описания
                "Темные пески и нависающие черные хмурые облака. Выжженная земля",
            },
            //  Desert
            new string[]
            {
                //TODO Добавить описания
                "Безжизненные как будто все еще тлеющие пески, окружают все в радиусе вашего взгляда",
            },
            //  Nomads1
            new string[]
            {
                //TODO Добавить описания
                "Кочевники еще из далека вас рассмотрели. Вы подошли ближе только после разрешения",
            },
            //  BanditTown
            new string[]
            {
                //TODO Добавить описания
                "Если бы преступление было местом, о вы явно его нашли",
                "Шанс что вас не ограбит первый же встречный в городе - крайне мал",
            },
            //  Nomads2
            new string[]
            {
                //TODO Добавить описания
                "Караван из 40 человек путешествует аккуратно и незаметно. Местные старшие разводят " +
                "'Охладители' - водяной костер позволяющий пережить знойный день",
            },
            //  RockValley
            new string[]
            {
                //TODO Добавить описания
                "Огромные монументальные фигуры даже будучи закопанными достигают более 80 метров в высоту",
                "Это место и пустыня в частности, хранят множество тайн, возможно столько же сколько песчинок в округе",
            }
        };

        #region Настройки магазина
        //  Настройки для магазина
        static sbyte GoodsNum = 2;
        static sbyte BonusesNum = 2; //  1-8

        //TODO Придумать реест с общим
        static List<Material> Materials = new List<Material>
        {
            new Material("дерево", 0.5, 3),
            new Material("смешенное", 0.3, 6),
            new Material("железо", 0.1, 9),
            new Material("сплав", 0.1, 12),
        };
        static Dictionary<string, List<string>> WeaponsByMaterial = new Dictionary<string, List<string>>()
        {
            { "дерево", new List<string> { "Деревянный меч", "Деревянная пика", "Деревянный топор", } },
            { "смешенное", new List<string> { "Смешанный меч", "Смешанная пика", "Смешанный топор", "Большой топор", "Секира", "Топорище", "Арбалет", "Серп", "Молот", } },
            { "железо", new List<string> { "Железный меч", "Железная пика", "Железный топор", "Большой топор", "Секира", "Тяжелый арбалет", "Топорище", "Рапира", "Катана", "Арбалет", "Клинок", } },
            { "сплав", new List<string> { "Сплавленный меч", "Сплавленная пика", "Сплавленный топор", "Большой топор", "Секира", "Тяжелый арбалет", "Топорище", "Рапира", "Катана", "Арбалет", } },
        };
        static Dictionary<string, List<string>> ArmorByMaterial = new Dictionary<string, List<string>>()
        {
            { "дерево", new List<string> { "Деревянная броня", "Деревянная кираса", "Деревянный жилет", } },
            { "смешенное", new List<string> { "Смешанная броня", "Смешанная кираса", "Смешанный жилет", "Кожаная броня" } },
            { "железо", new List<string> { "Железная броня", "Железная кираса", "Железный жилет", } },
            { "сплав", new List<string> { "Сплавленная броня", "Сплавленная кираса", "Сплавленный жилет", } },
        };

        /*  Общий список
        static string[] mas = new string[]
        {
            "Копье",
            "Меч",
            "Нож",
        };

        foreach (var ma in mas)
        {
            WeaponsByMaterial["дерево"].Add(ma);
            WeaponsByMaterial["смешенное"].Add(ma);
            WeaponsByMaterial["железо"].Add(ma);
            WeaponsByMaterial["сплав"].Add(ma);
        }*/


        //  Рынок в поселение Решеноми
        private static Store NormanMarket = new Store(51, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion
        #endregion

        //Побережье
        public static void Coast(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Побережье\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Coast), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти в зеленые земли\n"
                           + "3) Пойти в пустыню\n";
                           //+ "4) Выйти из ПП";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        GreenGround(hero);
                        break;
                    case 3:
                        Desert(hero);
                        break;
                    //case 4:
                    //    LocationVN.SpilledSpace(hero);
                    //    break;
                }
            }
        }

        //Зеленые земли
        public static void GreenGround(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
            {
                List<Order> battleList = new List<Order>()
                {
                    new Order(53, Character.ChaRole.Enemy),
                };
                Battles.MakeCurrentBattle(hero, battleList);
            }
                

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Зеленые земли\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.GreenGround), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти в пустыню\n"
                           + "3) Вернуться на побережье";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Desert(hero);
                        break;
                    case 3:
                        Coast(hero);
                        break;
                }
            }
        }

        //Пустыня
        public static void Desert(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
            {
                List<Order> battleList = new List<Order>()
                {
                    new Order(50, Character.ChaRole.Enemy),
                    new Order(51, Character.ChaRole.Enemy),
                    new Order(52, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Пустыня\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Desert), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти в каменную долину\n"
                           + "3) Пойти в бандитский город\n"
                           + "4) Пойти к кочевникам\n"
                           + "5) Пойти в зеленые земли\n"
                           + "6) Вернуться на побережье";


                switch (Input.ChoisInput(hero, 1, 6, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        RockValley(hero);
                        break;
                    case 3:
                        BanditTown(hero);
                        break;
                    case 4:
                        Nomads1(hero);
                        break;
                    case 5:
                        GreenGround(hero);
                        break;
                    case 6:
                        Coast(hero);
                        break;
                }
            }
        }

        //Кочевники 1
        public static void Nomads1(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Кочевники 1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Nomads1), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Купить оружие\n"
                           + "3) Купить броню"
                           + "4) Вернуться";


                switch (Input.ChoisInput(hero, 1, 4, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NormanMarket.ShowWeaponGoods(hero);
                        break;
                    case 3:
                        NormanMarket.ShowArmorGoods(hero);
                        break;
                    case 4:
                        Desert(hero);
                        break;
                }
            }
        }

        //Бандитские городки
        public static void BanditTown(Hero hero)
        {
            //TODO Шанс воровства велик
            if (GameFormulas.Vero(0.7))
            {
                List<Order> battleList = new List<Order>()
                {
                    new Order(50, Character.ChaRole.Enemy),
                    new Order(51, Character.ChaRole.Enemy),
                    new Order(52, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Бандитские городки\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.BanditTown), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти к кочевники2\n"
                           + "3) Вернуться в пустыню";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Nomads2(hero);
                        break;
                    case 3:
                        Desert(hero);
                        break;
                }
            }
        }

        //Кочевники 2
        public static void Nomads2(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Кочевники 2\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Nomads2), Descript), 1);

                hero.HPnMPBar(true, true);

                Console.WriteLine("\nВаши действия?\n"
                           + "1) Осмотреться\n");
                Output.PayMoneyLine("2) Купить зелье здоровья", Output.PotionHPCost, hero.Money);
                Output.PayMoneyLine("3) Купить зелье маны", Output.PotionMPCost, hero.Money);
                Console.WriteLine("4) Вернуться");


                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        if (Output.Spent(hero.Money, Output.PotionHPCost, "Зелье здоровья", "\nВы нищеброд! Проваливайте!\n"))
                            hero.PotionList[0].Count += 1;
                        break;

                    case 3:
                        if (Output.Spent(hero.Money, Output.PotionMPCost, "Зелье маны", "\nВы нищеброд! Проваливайте!\n"))
                            hero.PotionList[1].Count += 1;
                        break;
                    case 4:
                        BanditTown(hero);
                        break;
                }
            }
        }

        //Каменная долина
        public static void RockValley(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Каменная долина\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.RockValley), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Горящий лес\n"
                           + "3) Вернуться в пустыню";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                        
                    case 2:
                        BurningForest(hero);
                        break;
                    case 3:
                        Desert(hero);
                        break;
                }
            }
        }

        //Горящий лес
        public static void BurningForest(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Горящий лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Desert), Descript), 1);

                hero.HPnMPBar(true, true);

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[5] == 2 ? "1) Выйти из ПП" : "1) Искать", 0);
                Output.TwriteLine("2) Отдохнуть\n"
                                + "3) Вернуться в основной лес", 1);

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[5] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[5] == 0)
                            {
                                hero.HeroQuests.Que[5] = 1;
                                hero.HeroQuests.MainPP(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                            {
                                List<Order> battleList = new List<Order>()
                                {
                                    new Order(2, Character.ChaRole.Enemy),
                                };
                                Battles.MakeRandomBattle(hero, battleList);
                            }
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
                            List<Order> battleList = new List<Order>()
                            {
                                new Order(2, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        RockValley(hero);
                        break;
                }
            }
        }

    }
}
