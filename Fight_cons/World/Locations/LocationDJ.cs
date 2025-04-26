using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private static Store WoodDealerMarket = new Store(21, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion
        #endregion

        #region Локации ДЖ

        //Лес1
        public static void Woods1(Hero hero)
        {
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
                        Woods1(hero);
                        break;
                }
            }
        }

        //Лес3
        public static void Woods3(Hero hero)
        {
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
                        MainWoods(hero);
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

                switch (Input.ChoisInput(hero, 1, 2))
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
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        MainWoods(hero);
                        break;
                }
            }
        }        
        #endregion
    }
}
