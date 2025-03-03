using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        #endregion

        #region Локации ИСС
        //  Пещеры
        public static void CavesStart(Hero hero)
        {
            if (GameFormulas.Vero(0.3))
                Battles.MakeCurrentBattle(hero, 10, 5);

            while (true)
            {
                //TODO Подгрузка однотипных данных. Подумать насчет оптимизации, но со свободой!!! 
                //DefaultLoad(hero.HPBar, );

                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"???\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.CaveStart), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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
                                Output.TwriteLine("\nВы находите выход\n", 1);
                                ExitCave = true;
                            }
                        if (GameFormulas.Vero(0.6))
                            Battles.MakeRandomBattle(hero, 10, 11, 12);

                        hero.Statistic.CaveResearch++;
                        Research(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 10, 11, 12);
                        }
                        break;
                    case 3:
                        if (ExitCave)
                            Valley(hero);
                        break;
                }
            }
        }

        //  Пещеры
        public static void Caves(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Пещеры\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Caves), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                            + "1) Обыскать пещеру\n"
                            + "2) Отдохнуть\n"
                            + "3) Выйти из пещеры";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        if (GameFormulas.Vero(0.7))
                            Battles.MakeRandomBattle(hero, 10, 11, 12);

                        hero.Statistic.CaveResearch++;
                        Research(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 10, 11, 12);
                        }
                        break;
                    case 3:
                        Valley(hero);
                        break;
                }
            }
        }

        //  Долина
        public static void Valley(Hero hero)
        {
            if (GameFormulas.Vero(0.2))
                Battles.MakeCurrentBattle(hero, 7);
            if (GameFormulas.Vero(0.4))
                Battles.MakeRandomBattle(hero, 1);
            if (GameFormulas.Vero(0.01))
                FindingPouchEvent(hero, 1, 7);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Долина\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Valley), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                //TODO Появления наименования мест посто того как узнал
                //TODO Сделать нумерацию возможных действий через массив строк 
                string quo = "\nВаши действия?\n"
                            + "1) Пойти в поселение Ордо\n"
                            + "2) Пойти в предгорье\n"
                            + "3) Пойти в окрестности\n" // появления инфы позже
                            + "4) Пойти в лес\n"
                            + "5) Передохнуть\n"
                            + "6) Вернуться в пещеры";

                switch (Input.ChoisInput(hero, 1, 6, quo))
                {
                    case 1:
                        OrdoColony(hero);
                        break;
                    case 2:
                        Foothills(hero);
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                    case 4:
                        Woods(hero);
                        break;
                    case 5:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 1);
                        }
                        break;
                    case 6:
                        Caves(hero);
                        break;
                }
            }
        }

        //  Поселение Ордо
        public static void OrdoColony(Hero hero)
        {
            if (GameFormulas.Vero(0.15))
                FindingPouchEvent(hero, 3, 10);
            if (GameFormulas.Vero(0.05))
                Battles.MakeCurrentBattle(hero, 3);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Ордо\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.VillageOrdo), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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
                            Inn(hero);
                        else
                            OrdoColony(hero);
                        break;
                    case 3:
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

                hero.HPBar();
                hero.MPBar();

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
                        if (Output.Spent(hero.Money, Output.BeerCost, "", "Заплати, а потом пей!"))
                            Drinking(hero);
                        break;
                    case 3:
                        if (Output.Spent(hero.Money, ArmGame.Cost, "", "Бесплатно не интересует\n"))
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
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Предгорье\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Foothills), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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
                            Battles.MakeCurrentBattle(hero, 3);
                        }
                        break;
                    case 3:
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

                hero.HPBar();
                hero.MPBar();

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

                hero.HPBar();
                hero.MPBar();

                Console.Write("\nВаши действия?\n");
                if (!hero.CharecterProfile.EnemyAbout)
                    Output.PayMoneyLine("1) Способность видеть", Output.VisionSkillCost, hero.Money);
                else
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", "1) Способность видеть (уже изучено)\n");

                Output.PayMoneyLine("2) Купить зелье здоровья", Output.PotionHPCost, hero.Money);
                Output.PayMoneyLine("3) Купить зелье маны", Output.PotionMPCost, hero.Money);
                Console.WriteLine("4) Вернуться");

                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        if (!hero.CharecterProfile.EnemyAbout)
                        {
                            if (Output.Spent(hero.Money, Output.VisionSkillCost, "", "Вам нахватает средств"))
                            {
                                Console.WriteLine("Теперь вы можете видеть врагов");
                                hero.CharecterProfile.EnemyAbout = true;
                            }
                        }
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
                Battles.MakeCurrentBattle(hero, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Окрестности посления\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Neighborhood), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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
                            Battles.MakeCurrentBattle(hero, 3);
                        }
                        break;
                    case 3:
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

                hero.HPBar();
                hero.MPBar();

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
                hero.HeroQuests.Q_leva_Market(hero);
            if (GameFormulas.Vero(0.01))
                FindingPouchEvent(hero, 10, 100);

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

                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        //  Событие прослушивание  
                        break;

                    case 2:
                        MarketMethods.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        MarketMethods.ShowArmorGoods(hero);
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

                hero.HPBar();
                hero.MPBar();

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
                                Battles.MakeRandomBattle(hero, 2, 3);
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
                            Battles.MakeRandomBattle(hero, 2, 3);
                        }
                        break;
                    case 3:
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
                    Spell = SpellDes.ExcisionSpell,
                    Description = $"Исцеление (3 {Output.MPSymbol})",
                    SpellСost = 0,
                    SpellPower = 0,
                };
            }

            if (hero.Statistic.CaveResearch == 30)
            {
                Console.WriteLine("Вы слышите в темноте как что-то огромное надвигается на вас!");
                Battles.MakeCurrentBattle(hero, 18);
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
            Output.TwriteLine("Вы находите кошелек!\n"
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
                        Battles.MakeCurrentBattle(hero, 3);
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
