using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static FightCons.CoreNSettings.Map;

namespace FightCons.World.Locations
{
    public class LocationISS : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            CaveStart = 0,
            Caves = 1,
            Valley = 2,
            VillageOrdo = 3,
            Inn = 4,
            Foothills = 5,
            SenisusColony = 6,
            AlchemyHouse = 7,
            Neighborhood = 8,
            ReshinomiColony = 9,
            Market = 10,
            Woods = 11
        }

        public static string[][] Descript = new string[][]
        {
            //Старт Пещеры
            new string[]
            {
                "Тут довольно холодно и сыро",
                "Место очень заросло и было бы невозможно ориентироваться если бы не\n" + "маленькие отверстия в потолке",
                "Эти пещеры наполнены зловонием павших тел",
            },
            //Пещеры
            new string[]
            {
                "Тут довольно холодно и сыро",
                "Место очень заросло и было бы невозможно ориентироваться если бы не\n" + "маленькие отверстия в потолке",
                "Эти пещеры наполнены зловонием павших тел",
            },
            //Долина
            new string[]
            {
                "Долина дает увидеть пещеры под холмистой местность, темный лес, хижины людей и совсем рядом с ними жилище духов",
                "Духи любят пировать вместе с другими",
                "Чистая, приятная и свежая трава под ногами. Вам это по нраву",
            },
            //Поселение Ордо
            new string[]
            {
                //"Духи хоть и живут отдельно, но видно, что им дозволено бродить по деревне",
                "Люди занимаются земледелием и проводят вас взглядом",
                //"Бедный музыкант всегда может надеяться на монету, когда выступает для духов",
                //"Обрывки диалогов рассказывают вам о необычайно богатом духе и странным к нему\n отношению",
                "Жизнь тут спокойная и размеренная, никто не торопиться и не спешит",
                "Небольшая деревня, безликие и уставшие направляются в трактир",                
                //"Некоторые монахи достигли просветления и соединились с духами, теперь они едины и борются с демонами",
               
            },
            //Трактир
            new string[]
            {
                "Трактир, место наливающиеся песнями, рассказами движимые и смазанные менее и более крепкими горячительными напитками",
                "Недовольные посетители разглагольствуют о том что в Сенисусе пиво лучше да девки веселее!",
                "У трактирной стойки устало стоит трактирщик и энергичный и веселящейся Квасура, незаметно подливающий некоторым горячительное",
                "Монах по кличке 'Бегемот Лева' пьет эль как не в себя, попутно рассказывая похабные истории и непростительные анекдоты",
                "Периодически вы чувствуете чей-то взгляд на себе, но оборачиваясь никого не находите",
            },
            //Предгорье
            new string[]
            {
                "Приятную свежесть перебивают звуки диких хищников которые охотятся пока что на других животных",
                "Скалистая местность трудно проходиться, этим иного пользуются коварные разбойники и хитрые хищники",
            },
            //Поселение Сенисус
            new string[]
            {
                "На высотах горы 'Тысячи свидетелей' расположилась нелюбимая, но всем необходимая деревня Сенисус",
                "Приятная прохладная погода сочетающееся с теплым солнцем благотворно влияет что на тело, что на дух",
                "В городе совсем нет патрулей храмовников, обычно хотя бы раз встречающихся по пути в других поселениях",
            },
            //Дом Алхимии
            new string[]
            {
                "Странные пергаменты, котлы с варевом разной степени мерзости",
                "Резкие и сильные запахи вышибают из привычного восприятия реальности в комнате",
                "Неподготовленные люди как правило сюда не входят, ходят слухи что местный паренек на спор вошел сюда, а вышел уже мертвым",
                "Если бы не мистическая обстановка, можно было бы подумать что вы зашли к престарелым поварам неумехам",
            },
            //Окрестности Решеноми
            new string[]
            {
                "Монахи, что бродят тут, строят дома, молятся 'Ораулу' и приносят дары духам",
                "Местные дети играют с животными-духами. Духи любят детей из-за собственной схожести с ними",
            },
            //Поселение Решеноми
            new string[]
            {
                "Поселение примыкает к органическими словно мясо-костным стенам еще большего поселения, возможно даже города. " +
                "Как будто разросшийся придаток"
            },
            //Рынок
            new string[]
            {
                "Духи зазывалы, еще более навязчивые, чем люди. Приходить сюда стоит с точным осознанием того что нужно купить",
                "Орехи, безделушки, оружия. Духи успевают раздобыть все что необходимо",
                "Довольные лица покупателей и еще более довольные лица продавцов",
                //"Духам нравятся ценности, они находят много самородков и просят делать украшения, взамен на пару приманутых овец и кувшин чистой воды",
            },
            //Леса
            new string[]
            {
                "Опасность поджидает за каждый углом, вы ценная находка для демонов и бандитов",
                "Наблюдая издалека за животными в их движении чувствуется тревога",
                "Некоторые звери чувствует себя слишком спокойно и уверено, будто понимая что им ничего не грозит",
            },

        };

        //  Выход со стартовой позиции
        public static bool ExitCave;

        #region Настройки магазина
        //  Наименование объектов
        private static InventoryItem healPotionItem = new InventoryItem()
        {
            Name = "Живица",
            Description = "(Восстанавливает здоровье)",
        };

        private static InventoryItem manaPotionItem = new InventoryItem()
        {
            Name = "Коренья",
            Description = "(Восстанавливает ману)",
        };


        //  Настройки для магазина
        static sbyte GoodsNum = 3;
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
        private static Store ReshinomyMarket = new Store(11, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion

        #region Настройки карт

        //TODO ПОНЯТЬ КАК СПАВНИТЬ ИГРОКА В РАЗНЫЕ МЕСТА В ЗАВИСИМОСТИ ОТ ПОЗИЦИИ В СЛЕД ЛОКАЦИИ
        static List<Map> maps = new List<Map>()
        {
            #region Valley 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','.','.','#', },
                    { '#','.','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','⌂','.','.','X','.','.','.','.','.','.','#', },
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
                            hero.HeroCoordinates = transit.ValleyToFoothills;
                            Foothills(hero);
                        }
                    },//+ "2) Пойти в предгорье\n"
                    {(2, 2), Caves }, //+ "6) Вернуться в пещеры";
                    {(18, 4), Woods },//+ "4) Пойти в лес\n"
                    {(12, 6), OrdoColony },//  "1) Пойти в поселение Ордо\n"
                    {(9, 8), Neighborhood }//+ "3) Пойти в окрестности\n" // появления инфы позже
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

            #region Foothills
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
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','.','#','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','⌂','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#', },
                    { '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#', },
                    { '#','#','#','#','#','#','#','#','#','O','#','#','#','#','#','#','#','#','#','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }

                    /*{ '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    //{ '#','.','.','.','.','#','#','#','#','#','#','.','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','.','.','#', },
                    //{ '#','.','.','.','.','#','#','#','#','#','.','.','.','.','#','#','#','#','#','#','#','.','.','#','#','#','#','#','#','#','#','.','.','.','#','#','#','.','.','.','#', },
                    //{ '0','.','.','.','.','#','#','#','#','.','.','.','.','.','#','#','#','#','#','#','.','.','.','#','#','#','#','#','#','#','.','.','.','#','#','#','.','.','.','.','0', },
                    //{ '#','.','.','.','.','.','#','#','#','.','.','.','.','.','.','#','#','#','#','#','.','.','.','.','#','#','#','.','.','.','.','.','.','#','#','#','.','.','.','.','#', },
                    //{ '#','#','.','.','.','.','.','#','#','.','.','.','.','.','.','.','#','#','#','#','.','.','.','.','.','#','.','.','.','.','.','.','.','#','#','#','.','.','.','.','#', },
                    //{ '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','.','.','.','.','.','.','.','.','.','#','#','#','.','.','#','#','.','.','.','#','.','#', },
                    //{ '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','.','.','.','.','.','.','.','.','.','#','#','#','#','.','.','#','#','.','.','#','#','.','#', },
                    //{ '#','#','#','.','.','.','.','.','.','.','.','.','#','#','.','.','.','#','.','.','.','.','.','.','.','.','.','#','#','#','#','.','.','.','#','.','.','#','#','.','#', },
                    //{ '#','#','#','#','.','.','.','.','.','.','#','.','#','#','#','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#','#','.','.','.','.','#','#','#','.','#', },
                    //{ '#','#','#','#','.','.','.','.','.','.','#','.','#','#','#','#','.','.','.','.','#','#','#','#','.','.','.','.','#','#','#','#','.','.','.','.','#','#','#','.','#', },
                    //{ '#','#','#','#','.','.','.','.','#','#','#','.','#','#','#','.','.','.','#','#','#','#','#','.','.','.','.','#','#','#','.','.','.','.','.','.','#','#','#','.','#', },
                    //{ '#','#','#','#','.','.','.','.','#','#','#','.','#','#','#','#','.','.','#','#','#','#','#','#','.','.','.','.','#','#','.','.','.','.','.','.','#','#','#','.','#', },
                    //{ '#','#','#','#','.','.','#','#','#','#','#','.','#','#','#','#','#','#','#','#','#','#','#','#','.','.','.','.','.','#','.','.','.','.','.','.','.','#','#','.','#', },
                    //{ '#','#','#','.','.','#','#','#','#','#','#','.','#','#','#','#','#','#','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','#','.','.','#','#','.','#', },
                    //{ '#','#','#','.','.','#','#','#','#','#','#','.','#','#','#','#','#','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','#','#','.','.','#','#','.','#', },
                    //{ '#','#','#','.','.','#','#','#','#','#','#','.','.','#','#','#','#','#','#','#','#','#','.','.','.','#','.','.','.','.','.','.','.','#','#','#','.','.','#','.','#', },
                    //{ '#','#','#','#','.','#','#','#','#','#','#','.','.','.','#','#','#','#','#','#','#','#','.','.','.','#','#','.','.','.','.','.','.','#','#','#','#','.','.','.','#', },
                    //{ '#','#','#','#','#','#','#','#','#','#','#','.','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','.','.','.','#', },
                    //{ '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    */

                    /*{ '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    //{ '#','.','.','.','.','#','#','#','#','#','#','.','.','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','.','.','.','.','.','#', },
                    //{ '#','.','.','.','.','#','#','#','#','#','.','.','.','.','#','#','#','#','#','.','.','#','#','#','#','#','#','#','#','.','.','.','#','#','#','.','.','.','.','.','.','#', },
                    //{ '0','.','.','.','.','#','#','#','#','.','.','.','.','.','#','#','#','#','.','.','.','#','#','#','#','#','#','#','.','.','.','#','#','#','.','.','.','.','.','.','.','O', },
                    //{ '#','.','.','.','.','.','#','#','#','.','.','.','.','.','.','#','#','#','.','.','.','.','#','#','#','.','.','.','.','.','.','#','#','#','.','.','.','.','.','.','.','#', },
                    //{ '#','#','.','.','.','.','.','#','#','.','.','.','.','.','.','.','#','#','.','.','.','.','.','#','.','.','.','.','.','.','.','#','#','#','.','.','.','.','.','.','.','#', },
                    //{ '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','#','#','#','.','.','#','#','.','.','.','#','.','.','.','.','#', },
                    //{ '#','#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#','.','.','#','#','.','.','#','#','.','.','.','.','#', },
                    //{ '#','#','#','.','.','.','.','.','.','.','.','.','#','#','.','.','.','.','.','.','.','.','.','.','.','#','#','#','#','.','.','.','#','.','.','#','#','.','.','.','.','#', },
                    //{ '#','#','#','#','.','.','.','.','.','.','#','.','#','#','#','.','.','.','.','.','.','.','.','.','.','#','#','#','#','#','.','.','.','.','#','#','#','.','.','.','.','#', },
                    //{ '#','#','#','#','.','.','.','.','#','#','#','.','#','#','#','.','#','#','#','#','#','.','.','.','.','#','#','#','.','.','.','.','.','.','#','#','#','.','.','.','.','#', },
                    //{ '#','#','#','#','.','.','.','.','#','#','#','.','#','#','#','#','#','#','#','#','#','#','.','.','.','.','#','#','.','.','.','.','.','.','#','#','#','.','.','.','.','#', },
                    //{ '#','#','#','#','.','.','#','#','#','#','#','.','#','#','#','#','#','#','#','#','#','#','.','.','.','.','.','#','.','.','.','.','.','.','.','#','#','.','.','.','.','#', },
                    //{ '#','#','#','.','.','#','#','#','#','#','#','.','#','#','#','#','#','#','#','#','#','.','.','.','.','.','.','.','.','.','.','.','#','.','.','#','#','.','.','.','.','#', },
                    //{ '#','#','#','#','.','#','#','#','#','#','#','.','.','.','#','#','#','#','#','#','.','.','.','#','#','.','.','.','.','.','.','#','#','#','#','.','.','.','.','.','.','#', },
                    //{ '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                */
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
                    {(3, 3), SenisusColony },
                    {(9, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.FoothillsToValley;
                            Valley(hero);
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
            )
            #endregion
        };

        static Dictionary<Enum, (int, int)> SpawnPoints = new Dictionary<Enum, (int, int)>
        {
            //  Valley
            { transit.CavesToValley, (3,2) },
            { transit.FoothillsToValley, (16,2) },
            { transit.WoodsToValley, (17,4) },
            { transit.OrdoToValley, (11,6) },
            { transit.NeighborhoodToValley, (9,7) },

            //  Foothills
            { transit.ValleyToFoothills, (9,7) },
            { transit.SenisusColonyToFoothills, (4,3) },
        };

        #endregion
        #endregion

        #region Локации ИСС
        //  Пещеры
        public static void CavesStart(Hero hero)
        {
            if (GameFormulas.Vero(0.8))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(10, Character.ChaRole.Enemy),
                    new BattleSession(5, Character.ChaRole.Enemy),
                };

                List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                {
                    new BattleScenarioEvent
                    (
                        (hero, battleList, turn) =>
                        {
                            foreach(var ur in battleList)
                            {
                                if (ur.character.Condition.LeavedBattle)
                                     return true;
                            }

                            return false;


                        },
                        (hero, battleList) =>
                        {
                            if (battleList.FirstOrDefault(c => c.character.Condition.LeavedBattle).character.Condition.LeavedBattle)
                                Output.NameAndId(battleList.FirstOrDefault(c => c.character.Condition.LeavedBattle == false).character);
                                Console.WriteLine(": - КУДА ТЫ ЧЕРТ ПОДЕРИ СБЕЖАЛ?!");
                        }
                    ),

                    //new BattleScenarioEvent(
                    //    (hero, EnemyList, turn) => turn == 0,
                    //    (hero, EnemyList) =>
                    //    {
                    //        Console.WriteLine("СПАВН СОЮЗНИКА");

                    //    }
                    //    ),

                };


                Battles.MakeCurrentBattle(hero, battleList, battleScenarioEvents);
            }                

            while (true)
            {
                //TODO Подгрузка однотипных данных. Подумать насчет оптимизации, но со свободой!!! 
                //DefaultLoad(hero.HPBar, );

                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"???\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.CaveStart), Descript), 1);

                hero.HPnMPBar(true, true);

                Console.Write("Ваши действия?\n"
                                + "1) Обыскать пещеру\n"
                                + "2) Отдохнуть\n");
                if (ExitCave)
                    Console.Write("3) Выйти из пещеры\n");

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        if (GameFormulas.Vero(0.25))
                            if (!ExitCave)
                            {
                                Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "###########################################################################################################");
                                Output.WriteColorLine(ConsoleColor.White, "", "    Вы находите выход!    ");
                                Output.WriteColorLine(ConsoleColor.DarkGray, "", "###########################################################################################################\n");
                                Console.ReadLine();
                                ExitCave = true;
                            }
                        if (GameFormulas.Vero(0.6))
                        {
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(10, Character.ChaRole.Enemy),
                                new BattleSession(11, Character.ChaRole.Enemy),
                                new BattleSession(12, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }                            

                        hero.Statistic.CaveResearch++;
                        Research(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(10, Character.ChaRole.Enemy),
                                new BattleSession(11, Character.ChaRole.Enemy),
                                new BattleSession(12, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        if (ExitCave)
                        {
                            hero.HeroCoordinates = transit.CavesToValley;
                            Valley(hero);
                        }
                        break;
                }
            }
        }

        //  Пещеры
        public static void Caves(Hero hero)
        {
            if (GameFormulas.Vero(0.4))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(10, Character.ChaRole.Enemy),
                    new BattleSession(5, Character.ChaRole.Enemy),
                };

                List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                {
                    new BattleScenarioEvent
                    (
                        (hero, battleList, turn) =>
                        {
                            foreach(var ur in battleList)
                            {
                                if (ur.character.Condition.LeavedBattle)
                                     return true;
                            }

                            return false;


                        },
                        (hero, battleList) =>
                        {
                            if (battleList.FirstOrDefault(c => c.character.Condition.LeavedBattle).character.Condition.LeavedBattle)
                                Output.NameAndId(battleList.FirstOrDefault(c => c.character.Condition.LeavedBattle == false).character);
                                Console.WriteLine(": - КУДА ТЫ ЧЕРТ ПОДЕРИ СБЕЖАЛ?!");
                        }
                    ),

                    //new BattleScenarioEvent(
                    //    (hero, EnemyList, turn) => turn == 0,
                    //    (hero, EnemyList) =>
                    //    {
                    //        Console.WriteLine("СПАВН СОЮЗНИКА");

                    //    }
                    //    ),

                };


                Battles.MakeCurrentBattle(hero, battleList, battleScenarioEvents);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Пещеры\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Caves), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                            + "1) Обыскать пещеру\n"
                            + "2) Отдохнуть\n"
                            + "3) Выйти из пещеры";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        if (GameFormulas.Vero(0.7))
                        {
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(10, Character.ChaRole.Enemy),
                                new BattleSession(11, Character.ChaRole.Enemy),
                                new BattleSession(12, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }

                        hero.Statistic.CaveResearch++;
                        Research(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(10, Character.ChaRole.Enemy),
                                new BattleSession(11, Character.ChaRole.Enemy),
                                new BattleSession(12, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.CavesToValley;
                        Valley(hero);
                        break;
                }
            }
        }

        //Долина
        public static void Valley(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область зверолова
                new LocationScenarioEvent
                (
                    0.1,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            //GameFormulas.CurrentCoordinates((3, 5), (4, 5), (5, 5)),
                            GameFormulas.CurrentCoordinates(
                                (1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1),
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4)
                                ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(7, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                    },
                    true
                ),
                #endregion

                #region Область разбойников
                new LocationScenarioEvent
                (
                    0.2,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            //GameFormulas.CurrentCoordinates((3, 5), (4, 5), (5, 5)),
                            GameFormulas.CurrentCoordinates(
                                (12, 1), (13, 1), (14, 1), (15, 1), (16, 1), (17, 1), (18, 1),
                                (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2), (18, 2),
                                (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3), (18, 3),
                                (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4), (18, 4)
                                ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                    },
                    true
                )
	            #endregion
                
                //  Не ясно нужен или нет 
                /*new LocationScenarioEvent
                //(
                //    (hero, turn) => true,
                //    (hero) =>
                //    {
                //        Console.WriteLine("ыфваывафыва");
                //        Console.WriteLine("ыфваывафыва");
                //        Console.WriteLine("ыфваывафыва");
                //        Console.WriteLine("ыфваывафыва");
                //        if (GameFormulas.Vero(0.8))
                //            RestEvent(hero);
                //        else
                //        {
                //            RestEvent(hero);

                //            rendering = false;
                //            //mapStartLine = -1;
                //            Console.CursorVisible = true;

                //            List<BattleSession> battleList = new List<BattleSession>()
                //            {
                //                new BattleSession(1, Character.ChaRole.Wild),
                //            };
                //            Battles.MakeRandomBattle(hero, battleList);
                //        }
                //    },
                //    true
                )*/

                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Долина";
            locInfo[1] = Descriptions(((byte)LocationName.Valley), Descript);

            maps[0].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[0].Transition(hero, (playerX, playerY), locInfo, scenario);

            /*while (true)
            //{
            //    Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Долина\n");
            //    Output.TwriteLine(Descriptions(((byte)LocationName.Valley), Descript), 1);

            //    hero.HPnMPBar(true, true);

            //    //TODO Появления наименования мест посто того как узнал
            //    //TODO Сделать нумерацию возможных действий через массив строк
            //    string quo = "\nВаши действия?\n"
            //                + "1) Пойти в поселение Ордо\n"
            //                + "2) Пойти в предгорье\n"
            //                + "3) Пойти в окрестности\n" // появления инфы позже
            //                + "4) Пойти в лес\n"
            //                + "5) Передохнуть\n"
            //                + "6) Вернуться в пещеры";

            //    switch (Input.ChoisInput(hero, 1, 6, quo))
            //    {
            //        case 1:
            //            OrdoColony(hero);
            //            break;
            //        case 2:
            //            Foothills(hero);
            //            break;
            //        case 3:
            //            Neighborhood(hero);
            //            break;
            //        case 4:
            //            Woods(hero);
            //            break;
            //        case 5:
            //            RestEvent(hero);
            //            break;
            //        case 6:
            //            Caves(hero);
            //            break;
            //    }
            //}*/
        }

        //  Поселение Ордо
        public static void OrdoColony(Hero hero)
        {
            if (GameFormulas.Vero(0.15))
                FindingPouchEvent(hero, 3, 10);
            if (GameFormulas.Vero(0.05))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(3, Character.ChaRole.Enemy),
                };
                Battles.MakeCurrentBattle(hero, battleList);
            }
             
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Ордо\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.VillageOrdo), Descript), 1);

                hero.HPnMPBar(true, true);

                Console.Write("\nВаши действия?\n");

                if (hero.Lvl > hero.Statistic.HeroLvlKickOff)
                    Console.Write("1) Пройтись\n");
                else
                    Output.WriteColorLine(ConsoleColor.Gray, "", "1) Пойти в трактир (Вас прогнали, приходите позже)\n");

                Console.WriteLine("2) Пойти в трактир\n"
                                + "3) Вернуться в долину");

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //Контент
                        break;
                    case 2:
                        if (hero.Lvl > hero.Statistic.HeroLvlKickOff)
                        {
                            hero.HeroCoordinates = transit.WoodsToValley;
                            Inn(hero);
                        }
                        else
                            OrdoColony(hero);
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.OrdoToValley;
                        Valley(hero);
                        break;
                }
            }
        }

        //  Трактир
        public static void Inn(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Трактир\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Inn), Descript), 1);

                hero.HPnMPBar(true, true);

                Console.WriteLine("\nВаши действия?\n"
                           + "1) Наблюдать и подслушивать");
                Output.PayMoneyLine("2) Выпить", Output.BeerCost, hero.Money);
                Output.PayMoneyLine("3) Армреслинг", ArmGame.Cost, hero.Money);
                Console.WriteLine("4) Выйти из трактира");

                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        hero.HeroSpying.SpyingInTavern(hero);
                        break;
                    case 2:
                        if (Output.Spent(hero, Output.BeerCost, "", "Заплати, а потом пей!"))
                        {
                            Drinking(hero);
                            hero.HP = hero.MaxHp;
                        }
                            
                        break;
                    case 3:
                        if (Output.Spent(hero, ArmGame.Cost, "", "Бесплатно не интересует\n"))
                            ArmGameEvent(hero);
                        break;
                    case 4:
                        OrdoColony(hero);
                        PipeMessage.DialogInturapted = true;
                        break;
                }
            }
        }

        //Предгорье
        public static void Foothills(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область бандитов
                new LocationScenarioEvent
                (
                    0.1,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                                  (16, 1), 
                                (14, 2), (15, 2), (16, 2), (17, 2),
                                (14, 3), (15, 3), (16, 3), (17, 3),
                                (14, 4), (15, 4), (16, 4), (17, 4), (18, 4)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                    },
                    true
                ),
                #endregion

                #region Область зверей
                new LocationScenarioEvent
                (
                    0.05,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            //GameFormulas.CurrentCoordinates((3, 5), (4, 5), (5, 5)),
                            GameFormulas.CurrentCoordinates
                            (
                                (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2),
                                (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3),
                                (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4),
                                (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5),
                                (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(1, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                    },
                    true
                )
	            #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Предгорье";
            locInfo[1] = Descriptions(((byte)LocationName.Foothills), Descript);

            maps[1].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[1].Transition(hero, (playerX, playerY), locInfo, scenario);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Предгорье\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Foothills), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Пойти в поселение Сенисус\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        SenisusColony(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.FoothillsToValley;
                        Valley(hero);
                        break;
                }
            }
        }

        //Поселение Сенисус
        public static void SenisusColony(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Сенисус\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SenisusColony), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Войти в Дом алхимии\n"
                           + "2) Пройтись\n"
                           + "3) Спуститься к предгорью";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        AlchemyHouse(hero);
                        break;
                    case 2:
                        //if (GameFormulas.Vero(0.9))
                        //    RestEvent(hero);
                        //else
                        //{
                        //    RestEvent(hero);
                        //    Battles.MakeCurrentBattle(hero, 3);
                        //}
                        break;
                    case 3:
                        Foothills(hero);
                        break;
                }
            }
        }

        //Дом Алхимии
        public static void AlchemyHouse(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Дом алхимии\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.AlchemyHouse), Descript), 1);

                hero.HPnMPBar(true, true);

                Console.Write("\nВаши действия?\n");
                if (!hero.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active)
                    Output.PayMoneyLine("1) Способность видеть", Output.VisionSkillCost, hero.Money);
                else
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", "1) Способность видеть (уже изучено)\n");

                Output.PayMoneyLine($"2) Купить {healPotionItem.Name}", 50, hero.Money);
                Output.PayMoneyLine($"3) Купить {manaPotionItem.Name}", 100, hero.Money);
                Console.WriteLine("4) Вернуться");

                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        if (!hero.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active)
                        {
                            if (Output.Spent(hero, Output.VisionSkillCost, "", "Вам нахватает средств"))
                            {
                                Console.WriteLine("Теперь вы можете видеть врагов");
                                hero.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active = true;
                            }
                        }
                        break;

                    case 2:
                        if (Output.Spent(hero, 50, healPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            //TODO оптимизировать процесс. Не надо создавать сто раз один и тот же объект. 

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
                        SenisusColony(hero);
                        break;
                }
            }
        }

        //Окрестности Решеноми
        public static void Neighborhood(Hero hero)
        {
            //hero.HeroQuests.StartQ(hero, 2);
            //hero.HeroQuests.QYourName(hero);

            if (GameFormulas.Vero(0.3))
                FindingPouchEvent(hero, 0, 5);
            if (GameFormulas.Vero(0.1))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(2, Character.ChaRole.Enemy),
                };
                Battles.MakeCurrentBattle(hero, battleList);
            }

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Окрестности посления\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Neighborhood), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Войти в деревню\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        ReshinomiColony(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.NeighborhoodToValley;
                        Valley(hero);
                        break;
                }
            }
        }

        //Поселение Решеноми
        public static void ReshinomiColony(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Решноми\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.ReshinomiColony), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Пойти на рынок\n"
                           + "2) Пройтись\n"
                           + "3) Вернуться в окрестности";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        Market(hero);
                        break;
                    case 2:
                        //if (GameFormulas.Vero(0.9))
                        //    RestEvent(hero);
                        //else
                        //{
                        //    RestEvent(hero);
                        //    Battles.MakeCurrentBattle(hero, 3);
                        //}
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                }
            }
        }

        //  Рынок
        public static void Market(Hero hero)
        {
            //  Квесты
            if (hero.HeroQuests.Que[11] == 2)
                hero.HeroQuests.LevaMarketQ(hero);
            if (GameFormulas.Vero(0.01))
                FindingPouchEvent(hero, 10, 100);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Рынок\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Market), Descript), 1);

                hero.HPnMPBar(true, true);

                Console.WriteLine("\nВаши действия?\n"
                          + "1) Наблюдать и подслушивать\n"
                          + "2) Купить оружие\n"
                          + "3) Купить броню");
                Console.WriteLine("4) Выйти");

                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        //  Событие прослушивание  
                        break;

                    case 2:
                        ReshinomyMarket.ShowWeaponGoods(hero);
                        //MarketMethods.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        ReshinomyMarket.ShowArmorGoods(hero);
                        //MarketMethods.ShowArmorGoods(hero);
                        break;

                    case 4:
                        ReshinomiColony(hero);
                        break;
                }
            }
        }

        //  Леса
        public static void Woods(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPnMPBar(true, true);

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[1] == 2 ? "1) Выйти из ИСС" : "1) Бродить", 0);
                Output.TwriteLine("2) Отдохнуть\n"
                                + "3) Вернуться в долину", 1);

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[1] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[1] == 0)
                            {
                                hero.HeroQuests.Que[1] = 1;
                                hero.HeroQuests.MainISS(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                            {
                                List<BattleSession> battleList = new List<BattleSession>()
                                {
                                    new BattleSession(2, Character.ChaRole.Enemy),
                                    new BattleSession(3, Character.ChaRole.Enemy),
                                };
                                Battles.MakeRandomBattle(hero, battleList);
                            }                                
                            else
                                Output.TwriteLine("Вы ничего не находите\n", 1);
                        }                        

                        hero.Statistic.WoodsResearch++;
                        Research(hero);
                        break;
                    case 2:
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
                    case 3:
                        hero.HeroCoordinates = transit.WoodsToValley;
                        Valley(hero);
                        break;
                }
            }
        }
        #endregion

        /// <summary>
        ///  Находки при исследовании локаций
        /// </summary>
        public static void Research(Hero hero)
        {
            if (hero.Statistic.CaveResearch == 20)
            {
                Output.Spent("Древний свиток исцеления", true);

                SpellDes excision = new SpellDes(hero, "Исцеление")
                {
                    SpellParty = SpellDes.ExcisionSpell,
                    Description = $"Исцеление (3 {Output.MPSymbol})",
                    SpellCost = 0,
                    SpellPower = 0,
                };
            }

            if (hero.Statistic.CaveResearch == 30)
            {
                Console.WriteLine("Вы слышите в темноте как что-то огромное надвигается на вас!");

                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(18, Character.ChaRole.Enemy),
                };
                Battles.MakeCurrentBattle(hero, battleList);
            }
        }

        #region События на локациях
        //  Выпить в таверне
        public static void Drinking(Hero hero)
        {
            Sound.DRINK();
            Output.TwriteLine("Вы чувствуете как холодный эль заливается в вас", 1);
            Output.TwriteLine("Вам нравится\n", 30);
            if (hero.DrunkCondition > hero.OverDrunk)
            {
                Sound.HIT();
                Output.TwriteLine("*Звук удара головы об стол*", 1);
                Output.WaitNext(9, "Z");
                Output.TwriteLine("Вы проснулись", 50);
                Output.TwriteLine("Щас бы эля холодного...", 10);
                Console.ReadKey();
                hero.DrunkCondition = 0;
                hero.OverDrunk += 1;
                OrdoColony(hero);
            }
            hero.Sneak = 0;
            hero.DrunkCondition++;
        }

        //  Кошелек
        public static void FindingPouchEvent(Hero hero, int minGold, int maxGold)
        {
            Output.TwriteLine("\nВы находите кошелек!\n"
                                         + "1) Взять его\n"
                                         + "2) Пройти мимо\n", 1);

            switch (Input.ChoisInput(hero, 1, 2))
            {
                case 1:
                    if (GameFormulas.Vero(0.7))
                    {
                        Random rand = new Random();
                        Output.WriteColorLine(ConsoleColor.Yellow, "Открывая кошелек вы находите ", $"{minGold = rand.Next(minGold, maxGold)}{Output.MoneySymbol} ", "монеток\n");
                        hero.Money += minGold;
                        hero.Statistic.Money += minGold;
                    }
                    else
                    {
                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(3, Character.ChaRole.Enemy),
                        };
                        Battles.MakeCurrentBattle(hero, battleList);
                    }                        
                    break;
                case 2:
                    Output.TwriteLine("Вы проходите мимо", 10);
                    break;
            }
        }

        //  Bar-game
        public static void ArmGameEvent(Hero hero)
        {
            hero.Money -= ArmGame.Cost;

            ArmGame form1 = new ArmGame(hero);
            DialogResult res = form1.ShowDialog();
            if (res == DialogResult.Yes)
            {
                Console.WriteLine("Поздравляю! Вот ваши деньги\n");
                hero.Money += ArmGame.Cost * 2;
                hero.Statistic.Money += ArmGame.Cost * 2; ;
            }
            else
                Console.WriteLine("Слабак...\n");
        }
        #endregion
    }
}
