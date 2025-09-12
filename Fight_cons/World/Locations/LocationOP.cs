using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using static FightCons.CoreNSettings.Map;
using System.Drawing;
using System.Linq;

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
            Bazaar = 8,
            BlueHorizons = 9,
            TroubledWaters = 10
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
            //Базар
            new string[]
            {
                //TODO Добавить описания
                ""
            },
            //Воды Голубых Горизонтов
            new string[]
            {
                "Соленные воды выбрасываются на крохотные тонущие под массой островки жизни, медленно подбираясь к живому",
            },
            //Беспокойные воды
            new string[]
            {
                //TODO Добавить описания
                ""
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
            new Material(WoodMat, 0.7, 3),
            new Material(MixedMat, 0.2, 6),
            new Material(IronMat, 0.05, 9),
            new Material(AlloyMat, 0.05, 12),
        };
        static Dictionary<string, List<string>> WeaponsByMaterial = new Dictionary<string, List<string>>()
        {
            { WoodMat, new List<string> { "Деревянный меч", "Деревянная пика", "Деревянный топор", } },
            { MixedMat, new List<string> { "Смешанный меч", "Смешанная пика", "Смешанный топор", "Большой топор", "Секира", "Топорище", "Арбалет", "Серп", "Молот", } },
            { IronMat, new List<string> { "Железный меч", "Железная пика", "Железный топор", "Большой топор", "Секира", "Тяжелый арбалет", "Топорище", "Рапира", "Катана", "Арбалет", "Клинок", } },
            { AlloyMat, new List<string> { "Сплавленный меч", "Сплавленная пика", "Сплавленный топор", "Большой топор", "Секира", "Тяжелый арбалет", "Топорище", "Рапира", "Катана", "Арбалет", } },
        };
        static Dictionary<string, List<string>> ArmorByMaterial = new Dictionary<string, List<string>>()
        {
            { WoodMat, new List<string> { "Деревянная броня", "Деревянная кираса", "Деревянный жилет", } },
            { MixedMat, new List<string> { "Смешанная броня", "Смешанная кираса", "Смешанный жилет", "Кожаная броня" } },
            { IronMat, new List<string> { "Железная броня", "Железная кираса", "Железный жилет", } },
            { AlloyMat, new List<string> { "Сплавленная броня", "Сплавленная кираса", "Сплавленный жилет", } },
        };


        //  Рынок в поселение Решеноми
        private static Store Bazar = new Store(41, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        private static Store ContrabandistGoods = new Store(42, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion

        #region Настройки карт

        //TODO ПОНЯТЬ КАК СПАВНИТЬ ИГРОКА В РАЗНЫЕ МЕСТА В ЗАВИСИМОСТИ ОТ ПОЗИЦИИ В СЛЕД ЛОКАЦИИ
        static List<Map> maps = new List<Map>()
        {
            #region BlueHorizons 
            new Map
            (
                //  Размеры
                30, 15,

                //  Карта
                new char[,]
                {
                    { '~','~','~','~','~','◙','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#','#','~','~','~','~','~','~','~', },//5,0
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#','#','~','~','~','~','~','~', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#','#','~','~','~','~','~', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#','#','~','~','~','~', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#','#','#','~','~', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','◙','#','~','~', },//27,5
                    { '~','~','~','~','~','~','~','~','~','~','~','~','◙','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#','#','~', },//12,6
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#','#', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','#', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','◙','~','~','~','~','~','~','~','~','~','~','~','~','~','~', },//16,10
                    { '~','~','~','~','~','~','~','~','~','~','~','~','◙','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~', },//12,11
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~', },
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','◙','~','~','~','~','~','~','~', },//23,13
                    { '~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {
                    // Добавляем интерактивные объекты:
                    // Сундук на второй строке: координаты (14,1)
                    //{(14, 1), () => Map.ShowMessage("Вы нашли сундук с сокровищами!") },
                    // Сундук на девятой строке: координаты (12,8)
                    //{(12, 8), () => Map.ShowMessage("Вы нашли сундук с сокровищами!") },
                    // Точка выхода ('O') не добавляется в интерактивные объекты – для её активации нужно встать на нее
                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                    // Добавляем невидимые триггеры (например, ловушка)
                    //{   
                    //    new List<(int, int)>  
                    //    { 
                    //        (2, 3) 
                    //    },
                    //    () => maps[0].ShowMessage("Осторожно! Вы попали в ловушку!") 
                    //}
                },
                //  Точки входа
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(23, 13), Island1 },
                    {(12, 11), KitegeCity },
                    {(16, 10), Kronstandt },
                    {(12, 6), NovoiavCity },
                    {(27, 5), (Hero hero) => 
                    {
                        if (passDocuments)
                            TroubledWaters(hero);
                        else
                            Output.TwriteLine("\n- Морячок, без документов дальше не пройти!\n", 1);
                    }},
                    {(5, 0), NorthIsland },
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion
        };

        static Dictionary<Enum, (int, int)> SpawnPoints = new Dictionary<Enum, (int, int)>
        {
            //  BlueHorizons
            { transit.Island1ToBlueHorizons, (23, 12) },
            { transit.KitegeCityToBlueHorizons, (11, 11) },
            { transit.KronstandtToBlueHorizons, (17, 10) },
            { transit.NovoiavCityToBlueHorizons, (11, 6) },
            { transit.TroubledWatersToBlueHorizons, (26, 5) },
            { transit.NorthIslandToBlueHorizons, (5, 1) },

        };
        static bool passDocuments = false;
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
                           + "2) Выйти в океан\n"
                           + "3) Отдохнуть\n";
                           //+ "4) Выйти из ОП";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        hero.HeroCoordinates = transit.Island1ToBlueHorizons;
                        BlueHorizons(hero);
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
                           + "3) Отдохнуть\n"
                           + "4) Выйти в океан";


                switch (Input.ChoisInput(hero, 1, 4, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        PereplutTemple(hero);
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
                    case 4:
                        hero.HeroCoordinates = transit.KitegeCityToBlueHorizons;
                        BlueHorizons(hero);
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
                        if (Output.Spent(hero, 50, healPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            healPotionItem.UseItem = healPotionItem.HealPotion;
                            Inventory.ItemAdd(hero, healPotionItem);
                        }
                        break;

                    case 5:
                        if (Output.Spent(hero, 100, manaPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
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
                           + "3) Отдохнуть\n"
                           + "4) Выйти в океан";


                switch (Input.ChoisInput(hero, 1, 4, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Contrabandist(hero);
                        break;
                    case 3:
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
                    case 4:
                        hero.HeroCoordinates = transit.KronstandtToBlueHorizons;
                        BlueHorizons(hero);
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
                Output.PayMoneyLine($"5) Купить Документы", 200, hero.Money);
                Console.WriteLine("6) Уйти");

                switch (Input.ChoisInput(hero, 1, 6))
                {
                    case 1:
                        ContrabandistGoods.ShowWeaponGoods(hero);
                        break;

                    case 2:
                        ContrabandistGoods.ShowArmorGoods(hero);
                        break;

                    case 3:
                        if (Output.Spent(hero, 50, healPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            healPotionItem.UseItem = healPotionItem.HealPotion;
                            Inventory.ItemAdd(hero, healPotionItem);
                        }
                        break;

                    case 4:
                        if (Output.Spent(hero, 100, manaPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            manaPotionItem.UseItem = manaPotionItem.ManaPotion;
                            Inventory.ItemAdd(hero, manaPotionItem);
                        }
                        break;

                    case 5:
                        if (Output.Spent(hero, 200, "Документы", "\nВы нищеброд! Проваливайте!\n"))
                            passDocuments = true;
                        break;

                    case 6:
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
                           + "4) Отдохнуть\n"
                           + "5) Выйти в океан";


                switch (Input.ChoisInput(hero, 1, 5, quo))
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
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        break;
                    case 5:
                        hero.HeroCoordinates = transit.NovoiavCityToBlueHorizons;
                        BlueHorizons(hero);
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
                           + "2) Выйти в океан";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        hero.HeroCoordinates = transit.NorthIslandToBlueHorizons;
                        BlueHorizons(hero);
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
                                + "3) Вернуться", 1);

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
                        hero.HeroCoordinates = transit.TroubledWatersToBlueHorizons;
                        BlueHorizons(hero);
                        break;
                }
            }
        }

        //Воды Голубых Горизонтов
        public static void BlueHorizons(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.05,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6), (16, 6), (19, 6), (20, 6), (21, 6), (22, 6), (23, 6), (24, 6), (25, 6), (26, 6), (27, 6), (28, 6), (29, 6),
                                (1, 8), (2, 8), (3, 8), (4, 8), (5, 8), (6, 8), (7, 8), (8, 8), (9, 8), (10, 8), (11, 8), (12, 8), (13, 8), (14, 8), (15, 8), (16, 8), (17, 8), (18, 8), (19, 8), (20, 8), (21, 8), (22, 8), (23, 8), (24, 8), (25, 8), (26, 8), (27, 8), (28, 8), (29, 8),
                                (1, 10), (2, 10), (3, 10), (4, 10), (5, 10), (6, 10), (7, 10), (8, 10), (9, 10), (10, 10), (11, 10), (12, 10), (13, 10), (14, 10), (15, 10), (16, 10), (17, 10), (18, 10), (19, 10), (20, 10), (21, 10), (22, 10), (23, 10), (24, 10), (25, 10), (26, 10), (27, 10), (28, 10), (29, 10),
                                (1, 12), (2, 12), (3, 12), (4, 12), (5, 12), (6, 12), (7, 12), (8, 12), (9, 12), (10, 12), (11, 12), (12, 12), (13, 12), (14, 12), (15, 12), (16, 12), (17, 12), (18, 12), (19, 12), (20, 12), (21, 12), (22, 12), (23, 12), (24, 12), (25, 12), (26, 12), (27, 12), (28, 12), (29, 12),
                                (1, 13), (2, 13), (3, 13), (4, 13), (5, 13), (6, 13), (7, 13), (8, 13), (9, 13), (10, 13), (11, 13), (12, 13), (13, 13), (14, 13), (15, 13), (16, 13), (17, 13), (18, 13), (19, 13), (20, 13), (21, 13), (22, 13), (23, 13), (24, 13), (25, 13), (26, 13), (27, 13), (28, 13), (29, 13)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(40, Character.ChaRole.Enemy),
                            new BattleSession(41, Character.ChaRole.Enemy),
                            new BattleSession(42, Character.ChaRole.Enemy),
                        };
                        Battles.MakeRandomBattle(hero, battleList);
                    },
                    true
                ),
                #endregion
                #endregion
            };

            //TODO изменить под кортеж var user = (locName: "Глубоколесье", Description: Descriptions(((byte)LocationName.Deepwoods), Descript));
            string[] locInfo = new string[2];

            locInfo[0] = "Воды Голубых Горизонтов";
            locInfo[1] = Descriptions(((byte)LocationName.BlueHorizons), Descript);

            maps[0].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[0].Transition(hero, (playerX, playerY), locInfo, scenario);

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
        #endregion
    }
}
