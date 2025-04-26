using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;

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
                "Соленные воды выбрасываются на крохотные тонущие под массой островки жизни, медленно подбираясь к живому",
            },
            //Город Китеж
            new string[]
            {
                "Прекрасный и таинственный город Китеж объединяет в себе сразу две стихии, одна часть города подводой, другая на суше",
                "Некоторые районы недоступны для людей в силу того что они закрыты массивными стальными дверьми, которые не просто вскрыть",
                "Город кишит инженерами разных профилей, которые упорно трудятся над новыми техниками строительства подводой и изучением" +
                "методов вскрытия хитроумных механизмов",
            },
            //Храм Переплута
            new string[]
            {
                "Огромное сооружение выполненное в бело-синих тонах. Огромный алтарь и величественная статуя с тремя лицами",
                "Храм наполнен благовонием и приглушенным звучанием молитвы",
                "На стенах главного храма виднеются сюжеты с участием Трехликих и их контакту с разными народами",
            },
            //Город-порт Кронштандт
            new string[]
            {
                //TODO Добавить описания
                "Главная отправная точка всех путешественников и военных. Порт отчасти несет мистический характер для военных. " +
                "Ведь отправившись отсюда ты либо возвращаешься ветераном, либо не возвращаешься вовсе",
            },
            //Город Новоявь
            new string[]
            {
                "Один из самых больших из имеющихся городов. Известен осушённой территорией благодаря возведению коралловой стены",
                "Когда-то таланты инженерной мысли УТРОИЛИ территорию города за что навсегда вписали себя в историю",
                "Самый густонаселенный город, так же известен своим мультикультурным многообразием",
                "Поговаривают что именно в Новояве самые лучшие рестораны и кухни. Если пробовать новые блюда и кухни разных народов то только сюда!",
            },
            //Коралловая стена
            new string[]
            {
                //TODO Добавить описания
                "Самое большое естественно выращенное строение созданное по экспериментальной технологии до сих пор хранящийся под строгой тайной",
            },
            //Ресторан Палкинъ
            new string[]
            {
                //TODO Добавить описания
                "Известнейший ресторан в городе. Сюда приезжают люди из самых дальних уголков океана чтобы полакомиться изысканным мясом и вырезкой",
            },
            //Северные острова
            new string[]
            {
                //TODO Добавить описания
                "Первое о чем говорят про это место - ссылка всех заключенных. И лишь во вторую очередь как о месте проживания " +
                "окруженного множество полуправдивых мифов народе",
            },
        };

        #region Настройки магазина
        //  Наименование объектов
        private static InventoryItem healPotionItem = new InventoryItem()
        {
            Name = "Настойка",
            Description = "(Восстанавливает здоровье)",
        };

        private static InventoryItem manaPotionItem = new InventoryItem()
        {
            Name = "Сыта",
            Description = "(Восстанавливает ману)",
        };

        //  Настройки для магазина
        static sbyte GoodsNum = 6;
        static sbyte BonusesNum = 2; //  1-8

        //TODO Придумать реест с общим
        static List<Material> Materials = new List<Material>
        {
            new Material("дерево", 0.7, 3),
            new Material("смешенное", 0.2, 6),
            new Material("железо", 0.05, 9),
            new Material("сплав", 0.05, 12),
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
        private static Store Bazar = new Store(41, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion
        #endregion

        #region Локации ОП

        //Остров1
        public static void Island1(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(40, Character.ChaRole.Enemy),
                    new BattleSession(41, Character.ChaRole.Enemy),
                    new BattleSession(42, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Остров1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Island1), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Плыть в город Китеж\n"
                           + "3) Отдохнуть\n";
                           //+ "4) Выйти из ОП";


                switch (Input.ChoisInput(hero, 1, 3, quo))
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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(40, Character.ChaRole.Enemy),
                                new BattleSession(41, Character.ChaRole.Enemy),
                                new BattleSession(42, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }
                        break;
                    //case 4:
                    //    LocationVN.SpilledSpace(hero);
                    //    break;
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

                hero.HPnMPBar(true, true);

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(40, Character.ChaRole.Enemy),
                                new BattleSession(41, Character.ChaRole.Enemy),
                                new BattleSession(42, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }
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

                hero.HPnMPBar(true, true);

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

                hero.HPnMPBar(true, true);

                Console.WriteLine("\nВаши действия?\n"
                          + "1) Наблюдать и подслушивать\n"
                          + "2) Купить оружие\n"
                          + "3) Купить броню");
                Output.PayMoneyLine($"4) Купить {healPotionItem.Name}", 50, hero.Money);
                Output.PayMoneyLine($"5) Купить {manaPotionItem.Name}", 100, hero.Money);
                Console.WriteLine("6) Выйти");

                switch (Input.ChoisInput(hero, 1, 6))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;

                    case 2:
                        Bazar.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        Bazar.ShowArmorGoods(hero);
                        break;

                    case 4:
                        if (Output.Spent(hero.Money, 50, healPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            healPotionItem.UseItem = healPotionItem.HealPotion;
                            Inventory.ItemAdd(hero, healPotionItem);
                        }
                        break;

                    case 5:
                        if (Output.Spent(hero.Money, 100, manaPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            manaPotionItem.UseItem = manaPotionItem.ManaPotion;
                            Inventory.ItemAdd(hero, manaPotionItem);
                        }
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

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти к контрабандистам\n"
                           + "3) Плыть в город Новоявь\n"
                           + "4) Плыть в Беспокойные воды\n"
                           + "5) Отдохнуть\n"
                           + "6) Плыть в город Китеж";


                switch (Input.ChoisInput(hero, 1, 6, quo))
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
                        TroubledWaters(hero);
                        break;
                    case 5:
                        if (GameFormulas.Vero(0.6))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(40, Character.ChaRole.Enemy),
                                new BattleSession(41, Character.ChaRole.Enemy),
                                new BattleSession(42, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }
                        break;
                    case 6:
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
                hero.HPnMPBar(true, true);

                Console.WriteLine("\n- Че надо?\n");

                Console.WriteLine("\nВаши действия?\n"
                          + "1) Купить оружие\n"
                          + "2) Купить броню");
                Output.PayMoneyLine($"3) Купить {healPotionItem.Name}", 50, hero.Money);
                Output.PayMoneyLine($"4) Купить {manaPotionItem.Name}", 100, hero.Money);
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
                        if (Output.Spent(hero.Money, 50, healPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            healPotionItem.UseItem = healPotionItem.HealPotion;
                            Inventory.ItemAdd(hero, healPotionItem);
                        }
                        break;

                    case 4:
                        if (Output.Spent(hero.Money, 100, manaPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            manaPotionItem.UseItem = manaPotionItem.ManaPotion;
                            Inventory.ItemAdd(hero, manaPotionItem);
                        }
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

                hero.HPnMPBar(true, true);

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

                hero.HPnMPBar(true, true);

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

                hero.HPnMPBar(true, true);

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
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(40, Character.ChaRole.Enemy),
                    new BattleSession(41, Character.ChaRole.Enemy),
                    new BattleSession(42, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Северные острова\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NorthIsland), Descript), 1);

                hero.HPnMPBar(true, true);

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

        //Беспокойные воды
        public static void TroubledWaters(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(40, Character.ChaRole.Enemy),
                    new BattleSession(41, Character.ChaRole.Enemy),
                    new BattleSession(42, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Беспокойные воды\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NorthIsland), Descript), 1);

                hero.HPnMPBar(true, true);

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[4] == 2 ? "1) Выйти из ОП" : "1) Искать выход", 0);
                Output.TwriteLine("2) Отдохнуть\n"
                                + "3) Вернуться в Кронштандт", 1);

                switch (Input.ChoisInput(hero, 1, 2))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[4] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[4] == 0)
                            {
                                hero.HeroQuests.Que[4] = 1;
                                hero.HeroQuests.MainOP(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                            {
                                List<BattleSession> battleList = new List<BattleSession>()
                                {
                                    new BattleSession(40, Character.ChaRole.Enemy),
                                    new BattleSession(41, Character.ChaRole.Enemy),
                                    new BattleSession(42, Character.ChaRole.Enemy),
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
                        if (GameFormulas.Vero(0.7))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(40, Character.ChaRole.Enemy),
                                new BattleSession(41, Character.ChaRole.Enemy),
                                new BattleSession(42, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        Kronstandt(hero);
                        break;
                }
            }
        }

        #endregion
    }
}
