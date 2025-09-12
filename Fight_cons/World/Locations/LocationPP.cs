using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using static FightCons.CoreNSettings.Map;

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
            RockValley = 6,
            FlameForest = 7
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
            },
            //  FlameForest
            new string[]
            {
                //TODO Добавить описания
                //"Огромные монументальные фигуры даже будучи закопанными достигают более 80 метров в высоту",
                //"Это место и пустыня в частности, хранят множество тайн, возможно столько же сколько песчинок в округе",
                ""
            }
        };

        #region Настройки магазина
        //  Наименование объектов
        private static InventoryItem healPotionItem = new InventoryItem()
        {
            Name = "Дыхательные смеси",
            Description = "(Восстанавливает здоровье)",
        };

        private static InventoryItem manaPotionItem = new InventoryItem()
        {
            Name = "Кашка",
            Description = "(Восстанавливает ману)",
        };

        //  Настройки для магазина
        static sbyte GoodsNum = 2;
        static sbyte BonusesNum = 2; //  1-8

        //TODO Придумать реест с общим
        static List<Material> Materials = new List<Material>
        {
            new Material(WoodMat, 0.5, 3),
            new Material(MixedMat, 0.3, 6),
            new Material(IronMat, 0.1, 9),
            new Material(AlloyMat, 0.1, 12),
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
        private static Store NormanMarket = new Store(51, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion

        #region Настройки карт

        //TODO ПОНЯТЬ КАК СПАВНИТЬ ИГРОКА В РАЗНЫЕ МЕСТА В ЗАВИСИМОСТИ ОТ ПОЗИЦИИ В СЛЕД ЛОКАЦИИ
        static List<Map> maps = new List<Map>()
        {
            #region Coast
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','~','~','.','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','#', },//13, 1 
                    { '#','~','~','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','~','~','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','~','~','~','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#', },//18, 4
                    { '#','~','~','~','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','~','~','~','~','~','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','~','~','~','~','~','~','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','~','~','~','~','~','~','~','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
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
                    {(13, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.CoastToGreenGround;
                            GreenGround(hero);
                        }
                    },
                    {(18, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.CoastToDesert;
                            Desert(hero);
                        }
                    }
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

            #region GreenGround 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#', },//18, 6
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','O','.','.','.','.','.','.','.','.','.','.','.','.','#', },//6, 8 
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
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
                    {(6, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.GreenGroundToCoast;
                            Coast(hero);
                        }
                    },
                    {(18, 6), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.GreenGroundToDesert;
                            Desert(hero);
                        }
                    },
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

            #region Desert 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','.','.','#', },//16, 1 
                    { '#','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },//1, 2
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },//1, 5
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#', },//18, 6 
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', }, 
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
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
                    {(16, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.DesertToRockValley;
                            RockValley(hero);
                        }
                    },
                    {(1, 2), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.DesertToGreenGround;
                            GreenGround(hero);
                        }
                    },
                    {(1, 5), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.DesertToCoast;
                            Coast(hero);
                        }
                    },
                    {(18, 6), BanditTown }
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

            #region RockValley 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','O','.','.','.','.','.','.','.','.','.','.','.','.','#', },//6,2
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#', },//18, 6
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },//2, 8
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
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
                    {(18, 6), FlameForest },
                    {(2, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.RockValleyToDesert;
                            Desert(hero);
                        }
                    },
                    {(6, 2), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.DesertToRockValley;
                            Nomads1(hero);
                        }
                    },
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
            //  Coast
            { transit.PPStartPoint, (7, 5) },
            { transit.GreenGroundToCoast, (13, 2) },
            { transit.DesertToCoast, (17, 4) },

            //  GreenGround
            { transit.CoastToGreenGround, (6, 7) },
            { transit.DesertToGreenGround, (17, 6) },

            //  Desert
            { transit.GreenGroundToDesert, (2, 2) },
            { transit.CoastToDesert, (2, 5) },
            { transit.BanditTownToDesert, (17, 6) },
            { transit.RockValleyToDesert, (16, 2) },

            //  RockValley
            { transit.DesertToRockValley, (2, 7) },
            { transit.FlameForestToRockValley, (17, 6) },
        };

        #endregion
        #endregion

        //Побережье
        public static void Coast(Hero hero)
        {

            //TODO изменить под кортеж var user = (locName: "Глубоколесье", Description: Descriptions(((byte)LocationName.Deepwoods), Descript));
            string[] locInfo = new string[2];

            locInfo[0] = "Побережье";
            locInfo[1] = Descriptions(((byte)LocationName.Coast), Descript);

            maps[0].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo);

            while (true)
                maps[0].Transition(hero, (playerX, playerY), locInfo);

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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.1,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(53, Character.ChaRole.Enemy),
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

            locInfo[0] = "Зеленые земли";
            locInfo[1] = Descriptions(((byte)LocationName.GreenGround), Descript);

            maps[1].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[1].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(53, Character.ChaRole.Enemy),
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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.1,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(50, Character.ChaRole.Enemy),
                            new BattleSession(51, Character.ChaRole.Enemy),
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

            locInfo[0] = "Пустыня";
            locInfo[1] = Descriptions(((byte)LocationName.Desert), Descript);

            maps[2].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[2].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(50, Character.ChaRole.Enemy),
                    new BattleSession(51, Character.ChaRole.Enemy),
                    new BattleSession(52, Character.ChaRole.Enemy),
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
                        RockValley(hero);
                        break;
                }
            }
        }

        //Бандитские городки
        public static void BanditTown(Hero hero)
        {
            //Позже
            /*
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
            };

            //TODO изменить под кортеж var user = (locName: "Глубоколесье", Description: Descriptions(((byte)LocationName.Deepwoods), Descript));
            string[] locInfo = new string[2];

            locInfo[0] = "Бандитские городки";
            locInfo[1] = Descriptions(((byte)LocationName.BanditTown), Descript);

            maps[3].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[3].Transition(hero, (playerX, playerY), locInfo, scenario);
            */

            //TODO Шанс воровства велик
            if (GameFormulas.Vero(0.7))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(50, Character.ChaRole.Enemy),
                    new BattleSession(51, Character.ChaRole.Enemy),
                    new BattleSession(52, Character.ChaRole.Enemy),
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
                        hero.HeroCoordinates = transit.BanditTownToDesert;
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
                           + "1) Осмотреться");
                Output.PayMoneyLine($"2) Купить {healPotionItem.Name}", 50, hero.Money);
                Output.PayMoneyLine($"3) Купить {manaPotionItem.Name}", 100, hero.Money);
                Console.WriteLine("4) Вернуться");


                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        if (Output.Spent(hero, 50, healPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            healPotionItem.UseItem = healPotionItem.HealPotion;
                            Inventory.ItemAdd(hero, healPotionItem);
                        }
                        break;

                    case 3:
                        if (Output.Spent(hero, 100, manaPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            manaPotionItem.UseItem = manaPotionItem.ManaPotion;
                            Inventory.ItemAdd(hero, manaPotionItem);
                        }
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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.1,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(50, Character.ChaRole.Enemy),
                            new BattleSession(51, Character.ChaRole.Enemy),
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

            locInfo[0] = "Каменная долина";
            locInfo[1] = Descriptions(((byte)LocationName.RockValley), Descript);

            maps[3].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[3].Transition(hero, (playerX, playerY), locInfo, scenario);

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
                        FlameForest(hero);
                        break;
                    case 3:
                        Desert(hero);
                        break;
                }
            }
        }

        //Горящий лес
        public static void FlameForest(Hero hero)
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
                                List<BattleSession> battleList = new List<BattleSession>()
                                {
                                    new BattleSession(2, Character.ChaRole.Enemy),
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
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(2, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.FlameForestToRockValley;
                        RockValley(hero);
                        break;
                }
            }
        }

    }
}
