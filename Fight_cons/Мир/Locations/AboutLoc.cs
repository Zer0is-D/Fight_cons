using Fight_cons.Мир.Locations;
using Fight_cons.Основа_и_настройки;
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

        //  Запись событий перед заходов в локацию
        public static List<Location> Locations = new List<Location>()
        {
            new Location(0, "???", 
                (Hero hero) =>
                {
                    Fight_cons.Market.ShowArmorGoods(hero);
                    if (GameFormulas.Vero(0.4))
                        Battles.MakeCurrentBattle(hero, 2, 0);
                }, CavesStart),
            new Location(0, "Пещеры", 
                (Hero hero) => 
                { 

                }, Caves),           
            new Location(1, "Долина", 
                (Hero hero) => 
                {
                     if (GameFormulas.Vero(0.4))
                        Battles.MakeRandomBattle(hero, 3);
                     if (GameFormulas.Vero(0.01))
                        FindingPouchEvent(hero, 1, 7);
                }, 
                Vally),           
            new Location(2, "Окрестности деревни",
                (Hero hero) =>
                {
                    hero.HeroQuests.StartQ(hero, 2);
                    hero.HeroQuests.QYourName(hero);

                    if (GameFormulas.Vero(0.3))
                        FindingPouchEvent(hero, 0, 5);
                    if (GameFormulas.Vero(0.1))
                        Battles.MakeCurrentBattle(hero, 4);
                }, 
                Neighborhood),           
            new Location(3, "Деревня",(Hero hero) =>
                {
                    if (GameFormulas.Vero(0.15))
                        FindingPouchEvent(hero, 3, 10);
                    if (GameFormulas.Vero(0.05))
                        Battles.MakeCurrentBattle(hero, 5);
                }, 
                Village),           
            new Location(4, "Трактир",(Hero hero) =>
                {
                    //if (s.Contains("Атронахов"))
                    //    hero.Class_name = "Атронах";
                }, Inn),           
            new Location(5, "Рынок",(Hero hero) =>
                {
                    if (GameFormulas.Vero(0.01))
                        FindingPouchEvent(hero, 10, 100);
                }, 
                Market),
            new Location(6, "Леса",(Hero hero) =>
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
        //public static Unit Enemies(int id)
        //{
        //    List<Unit> enemies = new List<Unit>()
        //    {
        //        //  Пещерные противники
        //        /*0*/new Unit("Нечто Неизведанное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, maxTurnMin: 2, maxTurnMax: 3, role : Charecter.ChaRole.Enemy, strategy : Charecter.Strategeis.Any),
        //        /*1*/new Unit("Нечто Бронированное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 20, defMax: 70, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, maxTurnMin: 1, maxTurnMax: 2, role : Charecter.ChaRole.Enemy,strategy: Charecter.Strategeis.Any),
        //        /*2*/new Unit("Нечто Магическое", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 45, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, maxTurnMin: 2, maxTurnMax: 3, role : Charecter.ChaRole.Enemy, strategy : Charecter.Strategeis.Any),

        //        //  Противники в долине
        //        /*3*/new Unit("Зверь", phase: 0, hpMin: 10, hpMax: 20, attMin: 1, attMax: 5, spdMin: 30, spdMax: 30, critMin: 1, critMax: 2, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 20, blkMax: 40, maxTurnMin: 1, maxTurnMax: 2, role : Charecter.ChaRole.Wild, strategy: Charecter.Strategeis.Agresive),

        //        //  Противники в лесу
        //        /*4*/new Unit("Демон", phase: 0, hpMin: 15, hpMax: 30, attMin: 3, attMax: 5, spdMin: 30, spdMax: 30, critMin: 10, critMax: 15, defMin: 0, defMax: 0, mDefMin: 20, mDefMax: 30, blkMin: 1, blkMax: 5, maxTurnMin: 2, maxTurnMax: 5, role : Charecter.ChaRole.Enemy, strategy : Charecter.Strategeis.Any),

        //        //  Противники в деревне
        //        /*5*/new Unit("Ворюга", phase: 0, hpMin: 10, hpMax: 15, attMin: 3, attMax: 5, spdMin: 30, spdMax: 30, critMin: 20, critMax: 30, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 20, blkMax: 40, maxTurnMin: 4, maxTurnMax: 5, role : Charecter.ChaRole.Enemy, strategy: Charecter.Strategeis.Agresive),
        //        //  Противники в деревне
        //        /*6*/new Unit("Ог", phase: 4, hpMin: 40, hpMax: 60, attMin: 1, attMax: 2, spdMin: 0, spdMax: 10, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 0, blkMax: 0, maxTurnMin: 1, maxTurnMax: 2, role : Charecter.ChaRole.Enemy, strategy: Charecter.Strategeis.Agresive),
        //        /*7*/new Unit("Таотот", phase: 3, hp: 50, attack: 3, speed: 30, critChance: 20, defence: 10, magicDefence: 30, block: 0, maxMoves: 5, noRun: true, Charecter.ChaRole.Enemy),
        //        /*8*/new Unit("Камень", phase: 0, hp: 6, attack: 0, speed: 0, critChance: 0, defence: 0, magicDefence: 0, block: 0, maxMoves: 2, noRun: true, Charecter.ChaRole.Enemy),
        //        /*9*/new Unit("Некромант", phase: 0, hp: 20, attack: 0, speed: 20, critChance: 0, defence: 0, magicDefence: 30, block: 0, maxMoves: 5, noRun: true, Charecter.ChaRole.Enemy, strategy: Charecter.Strategeis.Necromancer),
        //        /*10*/new Unit("Жертвиник", phase: 0, hp: 20, attack: 0, speed: 0, critChance: 0, defence: 0, magicDefence: 0, block: 0, maxMoves: 2, noRun: true, Charecter.ChaRole.Enemy, strategy: Charecter.Strategeis.Healer),

        //        //  Союзники после 99
        //        /*100*/new Unit("Доброе Неизведанное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, maxTurnMin: 2, maxTurnMax: 3, role : Charecter.ChaRole.Ally, strategy : Charecter.Strategeis.Any),
        //        /*101*/new Unit("Доброе Бронированное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 20, defMax: 70, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, maxTurnMin: 1, maxTurnMax: 2, role : Charecter.ChaRole.Ally, strategy : Charecter.Strategeis.Any),
        //        /*102*/new Unit("Доброе Магическое", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, maxTurnMin: 2, maxTurnMax: 3, role : Charecter.ChaRole.Ally, strategy : Charecter.Strategeis.Any),
        //    };

        //    return enemies[id];
        //}

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
                    if (GameFormulas.Vero(0.25))
                        if (!Hero.Exit_cave)
                        {
                            Output.TwriteLine("\nВы находите выход\n", 1);
                            Hero.Exit_cave = true;
                        }
                    if (GameFormulas.Vero(0.7))
                        Battles.MakeRandomBattle(hero, 0, 1, 2);

                    hero.HeroStatistic.CaveResearch++;
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
                    if (Hero.Exit_cave)
                        DefualtLoad(hero, Locations[(sbyte)LocationName.Vally]);
                    break;
            }
        }

        //  Пещеры
        public static void Caves(Hero hero)
        {
            string quo = "\nВаши действия?\n"
                            + "1) Обыскать пещеру\n"
                            + "2) Отдохнуть\n"
                            + "3) Выйти из пещеры";

            switch (Input.ChoisInput(hero, 1, 3, quo))
            {
                case 1:
                    if (GameFormulas.Vero(0.7))
                        Battles.MakeRandomBattle(hero, 0, 1, 2);

                    hero.HeroStatistic.CaveResearch++;
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
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Vally]);
                    break;
            }
        }

        //  Леса
        public static void DeepWoods(Hero hero)
        {
            string quo = "\nВаши действия?\n"
                            + "1) Бродить\n"
                            + "2) Отдохнуть\n"
                            + "3) Вернуться в долину";

            switch (Input.ChoisInput(hero, 1, 3, quo))
            {
                case 1:
                    //  Босс
                    if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[0] == 0)
                    {
                        hero.HeroQuests.Que[0] = 1;
                        hero.HeroQuests.MainQ(hero);
                    }
                    else if (GameFormulas.Vero(0.6))
                        Battles.MakeRandomBattle(hero, 4, 5);
                    else
                        Output.TwriteLine("Вы ничего не находите\n", 1);

                    hero.HeroStatistic.WoodsResearch++;
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
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Vally]);
                    break;
            }
        }

        //  Долина
        public static void Vally(Hero hero)
        {
            string quo = "\nВаши действия?\n"
                            + "1) Вернуться в пещеры\n"
                            + "2) Передохнуть\n"
                            + "3) Пойти в деревню\n"
                            + "4) Пойти в лес";

            switch (Input.ChoisInput(hero, 1, 4, quo))
            {
                case 1:
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Caves]);
                    break;
                case 2:
                    if (GameFormulas.Vero(0.8))
                        RestEvent(hero);
                    else
                    {
                        RestEvent(hero);
                        Battles.MakeRandomBattle(hero, 3);
                    }
                    break;
                case 3:
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Neighborhood]);
                    break;
                case 4:
                    DefualtLoad(hero, Locations[(sbyte)LocationName.DeepWoods]);
                    break;
            }
        }

        //  Окрестности
        public static void Neighborhood(Hero hero)
        {
            string quo = "\nВаши действия?\n"
                            + "1) Войти в деревню\n"
                            + "2) Отдохнуть\n"
                            + "3) Вернуться в долину";

            switch (Input.ChoisInput(hero, 1, 3, quo))
            {
                case 1:
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Village]);
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
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Vally]);
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
                        DefualtLoad(hero, Locations[(sbyte)LocationName.Inn]);
                    else
                        DefualtLoad(hero, Locations[(sbyte)LocationName.Village]);
                    break;
                case 2:
                    Market(hero);
                    break;
                case 3:
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Neighborhood]);
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
                        Output.Spent(hero, 5);
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
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Village]);
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
                    if (hero.Money >= Output.PotionHPCost)
                    {
                        Output.Spent(hero, Output.PotionHPCost, "Зелье здоровья");
                        hero.PotionList[0].Count += 1;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 5:
                    if (hero.Money >= Output.PotionMPCost)
                    {
                        Output.Spent(hero, Output.PotionMPCost, "Зелье маны");
                        hero.PotionList[1].Count += 1;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 6:
                    DefualtLoad(hero, Locations[(sbyte)LocationName.Village]);
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
                Output.Spent(hero, 0, "Древний свиток исцеления", true);

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
                DefualtLoad(hero, Locations[(sbyte)LocationName.Village]);
            }
            hero.HeroSpying.Sneak = 0;
            hero.drunk++;
        }

        //  Событие отдых
        private static void RestEvent(Hero hero)
        {
            if (hero.Class_name != "Волшебник")
                MakeRest(hero);
            else
            {
                string quo = "Выберите вид отдыха:\n" +
                            "1) Обычный\n" +
                            "2) Медитация";

                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        MakeRest(hero);
                        break;
                    case 2:
                        MakeMeditation(hero);
                        break;
                }
            }                  
        }

        //  Отдых
        private static void MakeRest(Hero hero)
        {
            sbyte usualResoredHP = 30;
            sbyte usualResoredMP = 20;

            hero.HP += GameFormulas.GetCurrentPercent(hero.MaxHp, usualResoredHP);
            hero.MP += GameFormulas.GetCurrentPercent(hero.MaxMp, usualResoredMP);
            Output.WriteColorLine(ConsoleColor.Green, "Небольшой перерыв восстановил вам ", $"+{GameFormulas.GetCurrentPercent(hero.MaxHp, usualResoredHP)} ", $"{Output.HPSymbol} ");
            Output.WriteColorLine(ConsoleColor.Blue, "и ", $"+{GameFormulas.GetCurrentPercent(hero.MaxMp, usualResoredMP)} ", $"{Output.MPSymbol}\n");
            Output.WaitNext(3, ".");
        }
        //  Медитация
        private static void MakeMeditation(Hero hero)
        {
            //  Mage restore
            sbyte mageResoredHP = 20;
            sbyte mageResoredMP = 50;

            hero.HP += GameFormulas.GetCurrentPercent(hero.MaxHp, mageResoredHP);
            hero.MP += GameFormulas.GetCurrentPercent(hero.MaxMp, mageResoredMP);
            Output.WriteColorLine(ConsoleColor.Green, "Медитация восстановила вам ", $"+{GameFormulas.GetCurrentPercent(hero.MaxHp, mageResoredHP)} ", $"{Output.HPSymbol} ");
            Output.WriteColorLine(ConsoleColor.Blue, "и ", $"+{GameFormulas.GetCurrentPercent(hero.MaxMp, mageResoredMP)} ", $"{Output.MPSymbol}\n");
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
