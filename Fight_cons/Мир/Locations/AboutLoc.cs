using Fight_cons.Мир;
using Fight_cons.Мир.Locations;
using Fight_cons.Основа_и_настройки;
using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fight_cons
{
    class AboutLoc
    {
        public enum LocationName
        {
            CaveStart = 0,
            Caves = 1,
            Vally = 2,
            Neighborhood = 3,
            Village = 4,
            Inn = 5,
            Market = 6,
            DeepWoods = 7
        }

        public static List<Location> Locations = new List<Location>()
        {
            new Location(0, "???", 
                (Hero hero) =>
                {
                   
                }, CavesStart),
            new Location(1, "Пещеры", 
                (Hero hero) => 
                { 

                }, Caves),           
            new Location(2, "Долина", 
                (Hero hero) => 
                {
                     if (GameFormulas.Vero(0.4))
                        Battles.MakeBattle(hero, 3);
                     if (GameFormulas.Vero(0.01))
                        FindingPouchEvent(hero, 1, 7);
                }, 
                Vally),           
            new Location(3, "Окрестности деревни",
                (Hero hero) =>
                {
                    hero.HeroQuests.StartQ(hero, 2);
                    hero.HeroQuests.QYourName(hero);

                    if (GameFormulas.Vero(0.3))
                        FindingPouchEvent(hero, 0, 5);
                    if (GameFormulas.Vero(0.1))
                        Battles.MakeBattle(hero, 4);
                }, 
                Neighborhood),           
            new Location(4, "Деревня",(Hero hero) =>
                {
                    if (GameFormulas.Vero(0.15))
                        FindingPouchEvent(hero, 3, 10);
                    if (GameFormulas.Vero(0.05))
                        Battles.MakeBattle(hero, 5);
                }, 
                Village),           
            new Location(5, "Трактир",(Hero hero) =>
                {
                    //if (s.Contains("Атронахов"))
                    //    hero.Class_name = "Атронах";
                }, Inn),           
            new Location(6, "Рынок",(Hero hero) =>
                {
                    if (GameFormulas.Vero(0.01))
                        FindingPouchEvent(hero, 10, 100);
                }, 
                Market),
            new Location(7, "Леса",(Hero hero) =>
                {

                },
                DeepWoods),
        };

        /// <summary>
        /// Список противников
        /// </summary>
        public static List<Order> ListOfUnits = new List<Order>();

        /// <summary>
        /// Выбор противника из списка
        /// </summary>
        public static Enemy Enemies(int id)
        {
            List<Enemy> enemies = new List<Enemy>()
            {
                //  Пещерные противники
                /*0*/new Enemy("Нечто Неизведанное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 3, SPD_min: 30, SPD_max: 40, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, role: Charecter.ChaRole.Enemy),
                /*1*/new Enemy("Нечто Бронированное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 40, CRIT_min: 5, CRIT_max: 10, DEF_min: 20, DEF_max: 70, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 1, max_turn_max: 2, strategy: 0, role : Charecter.ChaRole.Enemy),
                /*2*/new Enemy("Нечто Магическое", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 45, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 30, M_DEF_max: 70, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, role : Charecter.ChaRole.Enemy),

                //  Противники в долине
                /*3*/new Enemy("Зверь", phase: 0, HP_min: 10, HP_max: 20, ATT_min: 1, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 1, CRIT_max: 2, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 20, BLK_max: 40, max_turn_min: 1, max_turn_max: 2, strategy: 1, role : Charecter.ChaRole.Wild),

                //  Противники в лесу
                /*4*/new Enemy("Демон", phase: 0, HP_min: 15, HP_max: 30, ATT_min: 3, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 10, CRIT_max: 15, DEF_min: 0, DEF_max: 0, M_DEF_min: 20, M_DEF_max: 30, BLK_min: 1, BLK_max: 5, max_turn_min: 2, max_turn_max: 5, strategy: 0, role : Charecter.ChaRole.Enemy),

                //  Противники в деревне
                /*5*/new Enemy("Ворюга", phase: 0, HP_min: 10, HP_max: 15, ATT_min: 3, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 20, CRIT_max: 30, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 20, BLK_max: 40, max_turn_min: 4, max_turn_max: 5, strategy: 1, role : Charecter.ChaRole.Enemy),
                //  Противники в деревне
                /*6*/new Enemy("Ог", phase: 4, HP_min: 40, HP_max: 60, ATT_min: 1, ATT_max: 2, SPD_min: 0, SPD_max: 10, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 0, BLK_max: 0, max_turn_min: 1, max_turn_max: 2, strategy: 1, role : Charecter.ChaRole.Enemy),
                /*7*/new Enemy("Таотот", phase: 3, hp: 50, attack: 3, speed: 30, crit_chance: 20, defence: 10, magic_defence: 30, block: 0, max_moves: 5, no_run: true),
                /*8*/new Enemy("Камень", phase: 0, hp: 6, attack: 0, speed: 0, crit_chance: 0, defence: 0, magic_defence: 0, block: 0, max_moves: 2, no_run: true),
                /*9*/new Enemy("Некромант", phase: 0, hp: 20, attack: 0, speed: 20, crit_chance: 0, defence: 0, magic_defence: 30, block: 0, max_moves: 5, no_run: true, strategy: 3),
                /*10*/new Enemy("Жертвиник", phase: 0, hp: 20, attack: 0, speed: 0, crit_chance: 0, defence: 0, magic_defence: 0, block: 0, max_moves: 2, no_run: true, strategy: 4),
            };

            return enemies[id];
        }
        public static Ally Allies(int id)
        {
            List<Ally> allies = new List<Ally>()
            {
                //  Пещерные противники
                /*0*/new Ally("Доброе Неизведанное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 3, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, role : Charecter.ChaRole.Ally),
                /*1*/new Ally("Доброе Бронированное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 10, DEF_min: 20, DEF_max: 70, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 1, max_turn_max: 2, strategy: 0, role : Charecter.ChaRole.Ally),
                /*2*/new Ally("Доброе Магическое", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 30, M_DEF_max: 70, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, role : Charecter.ChaRole.Ally),
            };

            return allies[id];
        }

        public static void DefualtLoad(Hero hero, Location location)
        {
            while (true)
            {
                location.LocationEvents(hero);

                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{location.Name}\n");
                Output.TwriteLine(Location.Dicscriptions(location.Id), 1);

                hero.HPBar();
                hero.MPBar();

                location.LocationChoices(hero);
            }
        }

        #region Локации
        public static void CavesStart(Hero hero)
        {
            Console.Write("Ваши действия?\n"
                            + "1) Обыскать пещеру\n"
                            + "2) Отдохнуть\n");
            if (Hero.Exit_cave)
                Console.Write("3) Выйти из пещеры\n");

            switch (Input.ChoisInput(hero, 1, 3))
            {
                case 1:
                    SER.Main2Async(hero);
                    //  Проверка боя с несколькими противниками
                    //if (GameFormulas.Vero(0.9))
                    //    Battles.MakeBattle(hero, 1, 101, 102);
                    if (GameFormulas.Vero(0.25))
                        if (!Hero.Exit_cave)
                        {
                            Output.TwriteLine("\nВы находите выход\n", 1);
                            Hero.Exit_cave = true;
                        }
                    if (GameFormulas.Vero(0.7))
                    {
                        if (GameFormulas.Vero(0.4))
                            Battles.MakeBattle(hero, 1);
                        else if (GameFormulas.Vero(0.4))
                            Battles.MakeBattle(hero, 4);
                        else if (GameFormulas.Vero(0.4))
                            Battles.MakeBattle(hero, 3);
                        else
                            Battles.MakeBattle(hero, 2);
                    }
                    hero.HeroStatistic.CaveResearch++;
                    Research(hero);
                    break;
                case 2:
                    if (GameFormulas.Vero(0.8))
                        RestEvent(hero);
                    else
                    {
                        RestEvent(hero);
                        Battles.MakeBattle(hero, 1);
                    }
                    break;
                case 3:
                    if (Hero.Exit_cave)
                        DefualtLoad(hero, Locations[(int)LocationName.Caves]);
                    break;
            }
        }

        //  Пещеры
        public static void Caves(Hero hero)
        {
            Console.WriteLine("\nВаши действия?\n"
                            + "1) Обыскать пещеру\n"
                            + "2) Отдохнуть\n"
                            + "3) Выйти из пещеры");

            switch (Input.ChoisInput(hero, 1, 3))
            {
                case 1:
                    if (GameFormulas.Vero(0.7))
                    {
                        if (GameFormulas.Vero(0.4))
                            Battles.MakeBattle(hero, 1);
                        else if (GameFormulas.Vero(0.4))
                            Battles.MakeBattle(hero, 3);
                        else
                            Battles.MakeBattle(hero, 2);
                    }
                    hero.HeroStatistic.CaveResearch++;
                    Research(hero);
                    break;
                case 2:
                    RestEvent(hero);
                    break;
                case 3:
                    DefualtLoad(hero, Locations[(int)LocationName.Vally]);
                    break;
            }
        }

        //  Леса
        public static void DeepWoods(Hero hero)
        {
            Console.WriteLine("\nВаши действия?\n"
                            + "1) Бродить\n"
                            + "2) Отдохнуть\n"
                            + "3) Вернуться в долину");

            switch (Input.ChoisInput(hero, 1, 3))
            {
                case 1:
                    //  Босс
                    if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[0] == 0)
                    {
                        hero.HeroQuests.Que[0] = 1;
                        hero.HeroQuests.MainQ(hero);

                    }
                    else if (GameFormulas.Vero(0.6))
                        Battles.MakeBattle(hero, 4);
                    else if (GameFormulas.Vero(0.4))
                        Battles.MakeBattle(hero, 5);
                    else
                        Output.TwriteLine("Вы ничего не находите\n", 1);
                    break;
                case 2:
                    RestEvent(hero);
                    break;
                case 3:
                    DefualtLoad(hero, Locations[(int)LocationName.Vally]);
                    break;
            }
        }

        //  Долина
        public static void Vally(Hero hero)
        {
            Console.WriteLine("\nВаши действия?\n"
                            + "1) Вернуться в пещеры\n"
                            + "2) Передохнуть\n"
                            + "3) Пойти в деревню\n"
                            + "4) Пойти в лес");

            switch (Input.ChoisInput(hero, 1, 4))
            {
                case 1:
                    DefualtLoad(hero, Locations[(int)LocationName.Caves]);
                    break;
                case 2:
                    RestEvent(hero);
                    break;
                case 3:
                    DefualtLoad(hero, Locations[(int)LocationName.Neighborhood]);
                    break;
                case 4:
                    DefualtLoad(hero, Locations[(int)LocationName.DeepWoods]);
                    break;
            }
        }

        //  Окрестности
        public static void Neighborhood(Hero hero)
        {
            Console.WriteLine("\nВаши действия?\n"
                            + "1) Войти в деревню\n"
                            + "2) Отдохнуть\n"
                            + "3) Вернуться в долину");

            switch (Input.ChoisInput(hero, 1, 3))
            {
                case 1:
                    DefualtLoad(hero, Locations[(int)LocationName.Village]);
                    break;
                case 2:
                    RestEvent(hero);
                    break;
                case 3:
                    DefualtLoad(hero, Locations[(int)LocationName.Vally]);
                    break;
            }
        }

        //  Деревня
        public static void Village(Hero hero)
        {
            Console.Write("\nВаши действия?\n");
            if (hero.Lvl > hero.HeroStatistic.HeroLvlKickOff)
                Console.Write("1) Пойти в трактир\n");
            else
                Output.WriteColorLine(ConsoleColor.Gray, "", "1) Пойти в трактир (Вас прогнали, приходите позже)\n");

            Console.WriteLine("2) Пойти на рынок\n"
                        + "3) Выйти из деревни");

            switch (Input.ChoisInput(hero, 1, 3))
            {
                case 1:
                    if (hero.Lvl > hero.HeroStatistic.HeroLvlKickOff)
                        DefualtLoad(hero, Locations[(int)LocationName.Inn]);
                    else
                        DefualtLoad(hero, Locations[(int)LocationName.Village]);
                    break;
                case 2:
                    Market(hero);
                    break;
                case 3:
                    DefualtLoad(hero, Locations[(int)LocationName.Neighborhood]);
                    break;
            }
        }

        //  Трактир
        public static void Inn(Hero hero)
        {
            Console.WriteLine("\nВаши действия?\n"
                            + "1) Наблюдать и подслушивать");
            Output.WriteColorLine(ConsoleColor.Yellow, "2) Выпить (", $"5{Output.MoneySymbol}", ")\n");
            Output.WriteColorLine(ConsoleColor.Yellow, "3) Армреслинг (", $"{Arm_game.Cost}{Output.MoneySymbol}", ")\n");
            Console.WriteLine("4) Выйти из трактира");

            switch (Input.ChoisInput(hero, 1, 4))
            {
                case 1:
                    hero.HeroSpying.SpyingInTavern(hero);
                    break;
                case 2:
                    if (hero.Money >= 5)
                    {
                        hero.Money -= 5;
                        Output.Spent(5);
                        Drinking(hero);
                    }
                    else
                        Output.TwriteLine("Заплати, а потом пей!", 1);
                    break;
                case 3:
                    if (hero.Money >= Arm_game.Cost)
                        ArmGameEvent(hero);
                    else
                        Output.TwriteLine("Бесплатно не интересует\n", 1);
                    break;
                case 4:
                    DefualtLoad(hero, Locations[(int)LocationName.Village]);
                    break;
            }
        }

        //  Рынок
        public static void Market(Hero hero)
        {
            //  Квесты
            if (hero.HeroQuests.Que[1] == 2)
                hero.HeroQuests.Q_leva_Market(hero);

            Console.WriteLine("\nВаши действия?\n"
                          + "1) Наблюдать и подслушивать\n"
                          + "2) Купить оружие\n"
                          + "3) Купить броню");
            Output.WriteColorLine(ConsoleColor.Yellow, "4) Купить зелье здоровья (", $"{Output.PotionHPCost}{Output.MoneySymbol}", ")\n");
            Output.WriteColorLine(ConsoleColor.Yellow, "5) Купить зелье маны (", $"{Output.PotionMPCost}{Output.MoneySymbol}", ")\n");
            Console.WriteLine("6) Выйти");

            switch (Input.ChoisInput(hero, 1, 6))
            {
                case 1:
                    //  Событие прослушивание  
                    break;

                case 2:
                    Fight_cons.Market.ShowWeaponGoods(hero);
                    break;

                case 3:
                    Fight_cons.Market.ShowArmorGoods(hero);
                    break;

                case 4:
                    if (hero.Money >= 20)
                    {
                        Output.Spent(20, "Зелье здоровья");

                        hero.Money -= 20;
                        hero.PotionList[0].Count += 1;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 5:
                    if (hero.Money >= 30)
                    {
                        Output.Spent(30, "Зелье маны");
                        hero.Money -= 30;
                        hero.PotionList[1].Count += 1;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 6:
                    DefualtLoad(hero, Locations[(int)LocationName.Village]);
                    break;
            }
        }
        #endregion

        /// <summary>
        ///  Находки при исследовании локаций
        /// </summary>
        public static void Research(Hero hero)
        {
            if (hero.HeroStatistic.CaveResearch == 20)
            {
                Output.Spent(0, "Древний свиток исцеления", true);

                SpellDes excision = new SpellDes(hero, "Исцеление")
                {
                    Spell = SpellDes.ExcisionSpell,
                    Description = $"Исцеление (3 {Output.MPSymbol})",
                    SpellСost = 0,
                    SpellPower = 0,
                };
            }

            if (hero.HeroStatistic.CaveResearch == 30)
            {
                Console.WriteLine("Вы слышите в темноте как что-то огромное надвигается на вас!");
                Battles.MakeBattle(hero, 6);
            }
        }

        #region События на локациях
        //  Выпить в таверне
        public static void Drinking(Hero hero)
        {
            Sound.DRINK();
            Output.TwriteLine("Вы чувствуете как холодный эль заливается в вас", 1);
            Output.TwriteLine("Вам нравится\n", 30);
            if (hero.drunk > 3)
            {
                Sound.HIT();
                Output.TwriteLine("*Звук удара головы об стол*", 1);
                Output.WaitNext(9, "Z");
                Output.TwriteLine("Вы проснулись", 50);
                Output.TwriteLine("Щас бы эля холодного...", 10);
                Console.ReadKey();
                hero.drunk = 0;
                hero.Max_drunk += 1;
                DefualtLoad(hero, Locations[(int)LocationName.Village]);
            }
            hero.HeroSpying.Sneak = 0;
            hero.drunk++;
        }

        //  Отдых  
        private static void RestEvent(Hero hero)
        {
            double H = (hero.MaxHp / 100.0) * 30.0, M = (hero.MaxMp / 100.0) * 20.0;
            hero.HP += (int)H;
            hero.MP += (int)M;
            Output.WriteColorLine(ConsoleColor.Green, "Небольшой перерыв восстановил вам ", $"+{(int)H} ", $"{Output.HPSymbol} ");
            Output.WriteColorLine(ConsoleColor.Blue, "и ", $"+{(int)M} ", $"{Output.MPSymbol}\n");
            Output.WaitNext(3, ".");
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
                        Battles.MakeBattle(hero, 5);
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
