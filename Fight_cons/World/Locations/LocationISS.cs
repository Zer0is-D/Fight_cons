using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    public class LocationISS : FightCons.Locations
    {
        //TODO Доделать нормальное наследование чтобы не плодить одинаковые методы

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
                "...",
            },
            //Пещеры
            new string[]
            {
                "...",
            },
            //Долина
            new string[]
            {
                "...",
            },
            //Поселение Ордо
            new string[]
            {
                "...",
            },
            //Трактир
            new string[]
            {
                "...",
            },
            //Предгорье
            new string[]
            {
                "...",
            },
            //Поселение Сенисус
            new string[]
            {
                "...",
            },
            //Дом Алхимии
            new string[]
            {
                "...",
            },
            //Окрестности Решеноми
            new string[]
            {
                "...",
            },
            //Поселение Решеноми
            new string[]
            {
                "...",
            },
            //Рынок
            new string[]
            {
                "...",
            },
            //Леса
            new string[]
            {
                "...",
            },

        };

        private static string Descriptions(byte i)
        {
            Random rand = new Random();
            return Descript[i][rand.Next(Descript[i].Length)];
        }

        /// <summary>
        /// Список противников
        /// </summary>
        public static List<Order> ListOfUnits = new List<Order>();

        //  Выход со стартовой позиции
        public static bool ExitCave;
        #endregion

        #region Локации ИСС
        //  Пещеры
        public static void CavesStart(Hero hero)
        {
            if (GameFormulas.Vero(0.3))
                Battles.MakeCurrentBattle(hero, 0, 9);

            while (true)
            {
                //TODO Подгрузка однотипных данных. Подумать насчет оптимизации, но со свободой!!! 
                //DefualtLoad(hero.HPBar, );

                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"???\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.CaveStart)), 1);

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
                            Battles.MakeRandomBattle(hero, 0, 1, 2);

                        hero.Statistic.CaveResearch++;
                        Research(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 0, 1, 2);
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
                Output.TwriteLine(Descriptions(((byte)LocationName.Caves)), 1);

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
                            Battles.MakeRandomBattle(hero, 0, 1, 2);

                        hero.Statistic.CaveResearch++;
                        Research(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 0, 1, 2);
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
                Battles.MakeCurrentBattle(hero, 11);
            if (GameFormulas.Vero(0.4))
                Battles.MakeRandomBattle(hero, 3);
            if (GameFormulas.Vero(0.01))
                FindingPouchEvent(hero, 1, 7);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Долина\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Valley)), 1);

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
                            Battles.MakeRandomBattle(hero, 3);
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
                Battles.MakeCurrentBattle(hero, 5);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Ордо\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.VillageOrdo)), 1);

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
                Output.TwriteLine(Descriptions(((byte)LocationName.Inn)), 1);

                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                           + "1) Наблюдать и подслушивать");
                Output.PayMoneyLine("2) Выпить", Output.BeerCost, hero.Money);
                Output.PayMoneyLine("3) Армреслинг", Arm_game.Cost, hero.Money);
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
                        if (Output.Spent(hero.Money, Arm_game.Cost, "", "Бесплатно не интересует\n"))
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
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods)), 1);

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
                            Battles.MakeCurrentBattle(hero, 5);
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
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods)), 1);

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
                        //    Battles.MakeCurrentBattle(hero, 5);
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
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                Console.Write("\nВаши действия?\n");
                if (!hero.CharecterProfile.EnemyAbout)
                    Output.PayMoneyLine("1) Способность видеть", Output.VisionSkillCost, hero.Money);
                else
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", "1) Способность видеть (уже изучено)\n");
                Console.WriteLine("2) Вернуться");
                //TODO Перенести строчки к алхимикам
                Output.PayMoneyLine("3) Купить зелье здоровья", Output.PotionHPCost, hero.Money);
                Output.PayMoneyLine("4) Купить зелье маны", Output.PotionMPCost, hero.Money);

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
                Battles.MakeCurrentBattle(hero, 4);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Окрестности посления\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Neighborhood)), 1);

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
                            Battles.MakeCurrentBattle(hero, 5);
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
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods)), 1);

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
                        //    Battles.MakeCurrentBattle(hero, 5);
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
            if (hero.HeroQuests.Que[1] == 2)
                hero.HeroQuests.Q_leva_Market(hero);
            if (GameFormulas.Vero(0.01))
                FindingPouchEvent(hero, 10, 100);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Рынок\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Market)), 1);

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
                        FightCons.Market.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        FightCons.Market.ShowArmorGoods(hero);
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
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo;

                if (hero.HeroQuests.Que[0] == 2)
                {
                    quo = "\nВаши действия?\n"
                        + "1) Выйти из ИСС\n"
                        + "2) Отдохнуть\n"
                        + "3) Вернуться в долину";
                }
                else
                {
                    quo = "\nВаши действия?\n"
                        + "1) Бродить\n"
                        + "2) Отдохнуть\n"
                        + "3) Вернуться в долину";
                }

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[0] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[0] == 0)
                            {
                                hero.HeroQuests.Que[0] = 1;
                                hero.HeroQuests.MainQ(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                                Battles.MakeRandomBattle(hero, 4, 5);
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
                            Battles.MakeRandomBattle(hero, 4, 5);
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
                Battles.MakeCurrentBattle(hero, 6);
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
                                         + "2) Пройти мимо\n", 40);

            switch (Input.ChoisInput(hero, 1, 2))
            {
                case 1:
                    if (GameFormulas.Vero(0.7))
                    {
                        Random rand = new Random();
                        Output.WriteColorLine(ConsoleColor.Yellow, "Открывая кошелек вы находите ", $"{minGold = rand.Next(minGold, maxGold)}{Output.MoneySymbol} ", "монеток\n");
                        hero.Money += minGold;
                    }
                    else
                        Battles.MakeCurrentBattle(hero, 5);
                    break;
                case 2:
                    Output.TwriteLine("Вы проходите мимо", 40);
                    break;
            }
        }

        //  Bar-game
        public static void ArmGameEvent(Hero hero)
        {
            hero.Money -= Arm_game.Cost;

            Arm_game form1 = new Arm_game(hero);
            DialogResult res = form1.ShowDialog();
            if (res == DialogResult.Yes)
            {
                Console.WriteLine("Поздравляю! Вот ваши деньги\n");
                hero.Money += Arm_game.Cost * 2;
            }
            else
                Console.WriteLine("Слабак...\n");
        }
        #endregion
    }
}
