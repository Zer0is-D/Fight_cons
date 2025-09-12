using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FightCons.CoreNSettings.Map;

namespace FightCons.World.Locations
{
    internal class LocationDJ : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            Woods1 = 0,
            Woods2 = 1,
            Woods3 = 2,
            Woods4 = 3,
            MainWoods = 4,
            Dealer = 5,
            Egion = 6,
        }

        public static string[][] Descript = new string[][]
        {
            //  Woods1
            new string[]
            {
                "Хитро-зеленый замысел виднеется невооруженным глазом в каждом дереве и удобно встреченной тропинке",
                "Нет сомнений, вы чувствуете в этом месте себя гостем, раз деревья не стесняются перед вами 'дышать-да-жить'",
            },
            //  Woods2
            new string[]
            {
                "Хитро-зеленый замысел виднеется невооруженным глазом в каждом дереве и удобно встреченной тропинке",
                "Нет сомнений, вы чувствуете в этом месте себя гостем, раз деревья не стесняются перед вами 'дышать-да-жить'",
            },
            //  Woods3
            new string[]
            {
                "Хитро-зеленый замысел виднеется невооруженным глазом в каждом дереве и удобно встреченной тропинке",
                "Нет сомнений, вы чувствуете в этом месте себя гостем, раз деревья не стесняются перед вами 'дышать-да-жить'",
            },
            //  Woods4
            new string[]
            {
                "Хитро-зеленый замысел виднеется невооруженным глазом в каждом дереве и удобно встреченной тропинке",
                "Нет сомнений, вы чувствуете в этом месте себя гостем, раз деревья не стесняются перед вами 'дышать-да-жить'",
            },
            //  MainWoods
            new string[]
            {
                "Вы дошли видимо до большой центровой поляны. Тут совсем не густой лес",
                "Посреди пустого пространства стоит древесный колос",
            },
            //  Dealer
            new string[]
            {
                "Древоподобный гуманоид сидит на мховом камне, терпеливо наблюдая как ты к нему подходишь",
                "За древолюдом сооружена конструкция с навесом где стоит 'позаимствованный' людской товар",
            },
            //  Egion
            new string[]
            {
                "Древо древ, древесное божество не иначе.",
                "Пред вами вздыхающий разумный гигант. Дерево которое нельзя встретить нигде. Оно хочет жить, а значит сделает для этого все",
                "Вы ощущаете источающие хладнокровье от дерева, оно знало про ваш путь и готовилось к встрече",
            },
        };

        //  Выход со стартовой позиции
        public static bool ExitCave;

        #region Настройки магазина

        //  Наименование объектов
        private static InventoryItem healPotionItem = new InventoryItem()
        {
            Name = "Чистая роса",
            Description = "(Восстанавливает здоровье)",
        };

        private static InventoryItem manaPotionItem = new InventoryItem()
        {
            Name = "Мудрая роса",
            Description = "(Восстанавливает ману)",
        };

        //  Настройки для магазина
        static sbyte GoodsNum = 1;
        static sbyte BonusesNum = 8; //  1-8

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
        private static Store WoodDealerMarket = new Store(21, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion

        #region Настройки карт

        //TODO ПОНЯТЬ КАК СПАВНИТЬ ИГРОКА В РАЗНЫЕ МЕСТА В ЗАВИСИМОСТИ ОТ ПОЗИЦИИ В СЛЕД ЛОКАЦИИ
        static List<Map> maps = new List<Map>()
        {
            #region Woods1
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','#','.','.','.','.','.','#','#','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','#','.','.','.','.','.','.','.','.','.','.','#','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','O','#', },//18, 4
                    { '#','.','.','.','.','.','#','.','.','.','.','#','#','#','.','.','#','.','.','#', },//5, 6
                    { '#','.','.','.','.','O','#','.','.','.','.','#','#','#','.','.','#','.','.','#', },
                    { '#','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','#','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
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
                    {(18, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.Woods1ToWoods2;
                            Woods2(hero);
                        }
                    },
                    {(5, 6), Dealer}
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

            #region Woods2 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','.','.','.','#','.','.','.','.','.','#','#','.','.','.','.','O','#','#', },//17, 2    
                    { '#','#','.','.','.','#','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','#','#','#','#','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','#','#','#','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','#','.','.','#','#','#','#','#','#','#','#','#', },
                    { '#','#','.','.','.','.','.','.','#','.','.','O','.','.','.','.','.','#','#','#', },//11, 7
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
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
                    {(17, 2), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.Woods2ToWoods1;
                            Woods1(hero);
                        }
                    },
                    {(11, 7), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.Woods2ToWoods3;
                            Woods3(hero);
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

            #region Woods3 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','#','#','#','O','.','#','.','.','.','#','#','#','#','#','#','#','#','#', },//5, 1
                    { '#','#','.','.','.','.','.','#','.','.','.','#','.','.','.','.','#','#','#','#', },
                    { '#','#','.','.','.','.','#','.','.','.','.','#','.','#','.','.','.','.','.','#', },
                    { '#','#','.','.','.','#','.','.','.','.','.','#','.','#','.','.','.','.','.','#', },
                    { '#','#','.','.','.','.','.','#','#','#','.','.','.','#','.','#','#','#','.','#', },
                    { '#','#','.','.','.','.','.','#','.','.','.','.','.','#','.','#','.','.','.','#', },
                    { '#','#','.','.','.','.','.','#','.','#','.','.','.','#','.','#','.','.','#','#', },
                    { '#','#','#','#','#','#','#','#','#','#','.','#','.','.','.','#','O','#','#','#', }, //16, 8
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
                    {(5, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.Woods3ToWoods2;
                            Woods2(hero);
                        }
                    },
                    {(16, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.Woods3ToWoods4;
                            Woods4(hero);
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

            #region Woods4
            new Map
            (
                //  Размеры
                20, 10,
                //41, 19,
                //42, 16,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','#','#','#','#','O','#','#','#','#','#','#','#','#','#','#','#','#','#', },//6, 1
                    { '#','#','#','.','.','.','.','#','#','#','#','#','.','#','#','.','#','#','#','#', },
                    { '#','#','#','.','.','.','#','.','.','.','.','#','.','#','#','.','.','.','.','#', },
                    { '#','#','#','.','.','#','.','.','.','.','.','#','.','#','#','.','.','.','.','#', },
                    { '#','#','#','.','.','.','.','#','#','#','.','.','.','#','#','#','#','#','.','#', },
                    { '#','#','#','.','.','.','.','#','.','.','.','.','.','#','#','#','#','#','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','.','.','.','#','#','#','#','#','#','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','O','#','#','#','#','#','#','#', },//12, 8
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
                new Dictionary<(int, int), Action>
                {

                    // Добавляем невидимые триггеры (например, ловушка)
                    //{(5, 5), () => maps[1].TriggerTrap() }
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(6, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.Woods4ToMainWoods;
                            MainWoods(hero);
                        }
                    },
                    {(12, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.Woods4ToWoods3;
                            Woods3(hero);
                        }
                    }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);
                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(3, Character.ChaRole.Enemy),
                    };
                    Battles.MakeCurrentBattle(hero, battleList);
                },
                0.9)
            ),
            #endregion

            #region MainWoods
            new Map
            (
                //  Размеры
                20, 10,
                //41, 19,
                //42, 16,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#','#', },// 17, 4
                    { '#','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },//1, 5
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },//11, 7
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
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
                new Dictionary<(int, int), Action>
                {

                    // Добавляем невидимые триггеры (например, ловушка)
                    //{(5, 5), () => maps[1].TriggerTrap() }
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(1, 5), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.MainWoodsToWoods4;
                            Woods4(hero);
                        }
                    },
                    {(17, 4), Egion  }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);
                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(3, Character.ChaRole.Enemy),
                    };
                    Battles.MakeCurrentBattle(hero, battleList);
                },
                0.9)
            )
            #endregion
        };

        static Dictionary<Enum, (int, int)> SpawnPoints = new Dictionary<Enum, (int, int)>
        {
            //  Woods1
            { transit.DJStartPoint, (2, 2) },
            { transit.DealerToWoods1, (4, 6) },
            { transit.Woods2ToWoods1, (17, 4) },

            //  Woods2
            { transit.Woods1ToWoods2, (17, 3) },
            { transit.Woods3ToWoods2, (10, 7) },

            //  Woods3
            { transit.Woods2ToWoods3, (5, 2) },
            { transit.Woods4ToWoods3, (16, 7) },

            //  Woods4
            { transit.Woods3ToWoods4, (12, 7) },
            { transit.MainWoodsToWoods4, (6, 2) },

            //  MainWoods
            { transit.Woods4ToMainWoods, (2, 5) },
            { transit.EgionToMainWoods, (16, 4) },
        };

        #endregion
        #endregion

        #region Локации ДЖ

        //Лес1
        public static void Woods1(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте
           
                #region Область нечести и культистов
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
                                new BattleSession(20, Character.ChaRole.Enemy),
                                new BattleSession(1, Character.ChaRole.Wild)
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

            locInfo[0] = "Лес";
            locInfo[1] = Descriptions(((byte)LocationName.Woods1), Descript);

            maps[0].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[0].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(1, Character.ChaRole.Wild),
                    new BattleSession(20, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods1), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти дальше\n";
                           //+ "3) Выйти из ДЖ";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Woods2(hero);
                        break;
                    //case 3:
                    //    LocationVN.SpilledSpace(hero);
                    //    break;
                }
            }
        }

        //Лес2
        public static void Woods2(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте
           
                #region Область нечести и культистов
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
                                new BattleSession(20, Character.ChaRole.Enemy),
                                new BattleSession(1, Character.ChaRole.Enemy)
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

            locInfo[0] = "Лес";
            locInfo[1] = Descriptions(((byte)LocationName.Woods2), Descript);

            maps[1].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[1].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(1, Character.ChaRole.Wild),
                    new BattleSession(20, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес2\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods2), Descript), 1);

                hero.HPnMPBar(true, true);

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
                        hero.HeroCoordinates = transit.DJStartPoint;
                        Woods1(hero);
                        break;
                }
            }
        }

        //Лес3
        public static void Woods3(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте
           
                #region Область нечести и культистов
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
                                new BattleSession(20, Character.ChaRole.Enemy),
                                new BattleSession(1, Character.ChaRole.Enemy)
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

            locInfo[0] = "Лес";
            locInfo[1] = Descriptions(((byte)LocationName.Woods3), Descript);

            maps[2].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[2].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(1, Character.ChaRole.Wild),
                    new BattleSession(20, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес3\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods3), Descript), 1);

                hero.HPnMPBar(true, true);

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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте
           
                #region Область нечести и культистов
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
                                new BattleSession(20, Character.ChaRole.Enemy),
                                new BattleSession(21, Character.ChaRole.Enemy)
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

            locInfo[0] = "Лес";
            locInfo[1] = Descriptions(((byte)LocationName.Woods4), Descript);

            maps[3].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[3].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(1, Character.ChaRole.Wild),
                    new BattleSession(20, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес4\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods4), Descript), 1);

                hero.HPnMPBar(true, true);

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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
            };

            //TODO изменить под кортеж var user = (locName: "Глубоколесье", Description: Descriptions(((byte)LocationName.Deepwoods), Descript));
            string[] locInfo = new string[2];

            locInfo[0] = "Главный лес";
            locInfo[1] = Descriptions(((byte)LocationName.MainWoods), Descript);

            maps[4].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[4].Transition(hero, (playerX, playerY), locInfo, scenario);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Основной лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.MainWoods), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Подойти к Эгеону\n"
                           + "3) Пойти к торговцу\n"
                           + "4) Вернуться назад";
                

                switch (Input.ChoisInput(hero, 1, 4, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Egion(hero);
                        break;
                    case 3:
                        Dealer(hero);
                        break;
                    case 4:
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
                        WoodDealerMarket.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        WoodDealerMarket.ShowArmorGoods(hero);
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
                        hero.HeroCoordinates = transit.DealerToWoods1;
                        Woods1(hero);
                        break;
                }
            }
        }

        //Egion
        public static void Egion(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Эгеон\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Egion), Descript), 1);

                hero.HPnMPBar(true, true);

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[2] == 2 ? "1) Выйти из ДЖ" : "1) Искать", 0);
                Output.TwriteLine("2) Отдохнуть\n"
                                + "3) Вернуться в основной лес", 1);

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[2] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[2] == 0)
                            {
                                hero.HeroQuests.Que[2] = 1;
                                hero.HeroQuests.MainDJ(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                            {
                                List<BattleSession> battleList = new List<BattleSession>()
                                {
                                    new BattleSession(21, Character.ChaRole.Enemy),
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
                                new BattleSession(20, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.EgionToMainWoods;
                        MainWoods(hero);
                        break;
                }
            }
        }        
        #endregion
    }
}
