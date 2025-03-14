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
            //  Deepwoods
            new string[]
            {
                "Лес настолько густой, что даже ясное солнце не может пробиться сквозь плотную листву",
                "Находясь в лесу, кажется что ночная тьма отличается от тьмы здешней",
                "Пугает ни сколько дикие животные звуки, сколь их отсутствие",
                "В этом месте нет ветра, но холод пробирает до дрожи. Как и то что слышно только свое дыхание и хруст после каждого шага",
            },
            //  EastWoods
            new string[]
            {
                "Лес настолько густой, что даже ясное солнце не может пробиться сквозь плотную листву",
                "Находясь в лесу, кажется что ночная тьма отличается от тьмы здешней",
                "Пугает ни сколько дикие животные звуки, сколь их отсутствие",
                "В этом месте нет ветра, но холод пробирает до дрожи. Как и то что слышно только свое дыхание и хруст после каждого шага",
            },
            //  NorthWoods
            new string[]
            {
                "Лес настолько густой, что даже ясное солнце не может пробиться сквозь плотную листву",
                "Находясь в лесу, кажется что ночная тьма отличается от тьмы здешней",
                "Пугает ни сколько дикие животные звуки, сколь их отсутствие",
                "В этом месте нет ветра, но холод пробирает до дрожи. Как и то что слышно только свое дыхание и хруст после каждого шага",
            },
            //  Gigantopolis
            new string[]
            {
                "Огражденный и защищенный стенами городской колос стоит в авангарде среди окружающего его мрачного Глубоколесья",
                "Нагромождение гигантских жестянно-бетонных коробок стало жильем и прибежищем цивилизации. Слава отцам основателям!",
                "'Великие дома' некогда были факториями, теперь пустующие производственные сектора и отделы стали жилыми комнатами для новых рабочих",
                "Вы впервые видите настолько активную, динамичную, жизне-бурлящую картину. Глаза расходятся в стороны от " +
                "того сколько всего произошло на улицах в улетающую минуту",
                "Зажиточный господин в костюме с выделяющимся красными фрагментами и видимо опознавательными символами хвастается явно впечатлительной даме какую сумму оставил " +
                "в ресторации 'Над Карьером'",
            },
            //  Market
            new string[]
            {
                "Лавочники борются за каждый сантиметр пространства для своих товаров, и не дай бог дреной товар соседа коснется лавки другого",
                "Разнообразия выбора и однообразия неприлично завышенных цен",
                "Единственно что останавливает лавочников от массовой поножовщины наличие покупателей и только в последнюю очередь стража",
            },
            //  MainSquare
            new string[]
            {
                "Просторная главная площадь наполненная грамотно расставленными статуями и бюстами бывших королей и отцов основателей",
                "Именно здесь отцы основатели встретили 'Закат времен' - так вы услышали от учителя проводившего экскурс детям",
            },
            //  Palace
            new string[]
            {
                "Одна из самых ярких и ухоженных коробок именовалось дворцом. Одно из важных зданий города"
            },
            //  Administration
            new string[]
            {
                "Небольшое четырех этажное здание в кабинетах которого рас сосредоточились чиновники разных взглядов",
                "От кабинета к кабинету вы слышите обрывки разных разговоров, от шантажа до участия в заговоре, " +
                "от обсуждений законопроектов до грязных подробностях жизни ни о чем не говорящих вам имен",
            },
            //Quarry
            new string[]
            {
                "Карьер - дом всех малоимущих. Чем ниже опускаться, тем хуже и дешевле жилье. На вопрос насколько" +
                " хуже и дешевле - местные стесняются отвечать ",
            }
        };

        #region Настройки магазина
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
        private static Store GigantopolisMarket = new Store(31, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion
        #endregion

        #region Локации БТЛ

        //Глубоколесье
        public static void Deepwoods(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 31, 32, 33);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Глубоколесье\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Deepwoods), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                            + "1) Бродить\n"
                            + "2) Пойти в северные леса\n"
                            + "3) Пойти в восточные леса\n"
                            + "4) Отдохнуть";
                            //+ "5) Выйти из БТЛ";

                switch (Input.ChoisInput(hero, 1, 4, quo))
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
                            Battles.MakeRandomBattle(hero, 31, 32, 33);
                        }
                        break;
                    //case 5:
                    //    LocationVN.SpilledSpace(hero);
                    //    break;
                }
            }
        }

        //Восточный лес
        public static void EastWoods(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 31, 32, 33);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Восточный лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.EastWoods), Descript), 1);

                hero.HPnMPBar(true, true);

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
                            Battles.MakeRandomBattle(hero, 31, 32, 33);
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
                Battles.MakeRandomBattle(hero, 31, 32, 33);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Северный лес\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NorthWoods), Descript), 1);

                hero.HPnMPBar(true, true);

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
                            Battles.MakeRandomBattle(hero, 31, 32, 33);
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

                hero.HPnMPBar(true, true);

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

                hero.HPnMPBar(true, true);

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
                        GigantopolisMarket.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        GigantopolisMarket.ShowArmorGoods(hero);
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

                hero.HPnMPBar(true, true);

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

                hero.HPnMPBar(true, true);

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

                hero.HPnMPBar(true, true);

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

                hero.HPnMPBar(true, true);

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
                             Battles.MakeRandomBattle(hero, 31, 32, 33);
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
                             Battles.MakeRandomBattle(hero, 31, 32, 33);
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
                             Battles.MakeRandomBattle(hero, 31, 32, 33);
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
                             Battles.MakeRandomBattle(hero, 31, 32, 33);
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
                Battles.MakeRandomBattle(hero, 31, 32, 33);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Карьер\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Quarry), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Спуститься\n"
                           + "3) Уйти";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        QuarryBottom(hero);
                        break;
                    case 3:
                        Gigantopolis(hero);
                        break;
                }
            }
        }

        //Дно карьера
        public static void QuarryBottom(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 1, 2, 3);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Дно карьера\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Quarry), Descript), 1);

                hero.HPnMPBar(true, true);

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[3] == 2? "1) Выйти из БТЛ" : "1) Искать", 0);
                Output.TwriteLine("2) Отдохнуть\n"
                                + "3) Выбраться", 1);

                switch (Input.ChoisInput(hero, 1, 2))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[3] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[3] == 0)
                            {
                                hero.HeroQuests.Que[3] = 1;
                                hero.HeroQuests.MainBTL(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                                Battles.MakeRandomBattle(hero, 1, 2, 3);
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
                            Battles.MakeRandomBattle(hero, 1, 2, 3);
                        }
                        break;
                    case 3:
                        Quarry(hero);
                        break;
                }
            }
        }
        #endregion
    }
}
