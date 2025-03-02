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
        #endregion

        #region Локации ДЖ

        //Лес1
        public static void Woods1(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Пойти дальше\n"
                           + "3) Выйти из ДЖ";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Woods2(hero);
                        break;
                    case 3:
                        LocationVN.SpilledSpace(hero);
                        break;
                }
            }
        }

        //Лес2
        public static void Woods2(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес2\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес3\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Лес4\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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
                Output.TwriteLine(Descriptions(((byte)LocationName.Woods), Descript), 1);

                hero.HPBar();
                hero.MPBar();

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

                hero.HPBar();
                hero.MPBar();

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
                        MarketMethods.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        MarketMethods.ShowArmorGoods(hero);
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

                hero.HPBar();
                hero.MPBar();

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[2] == 2 ? "1) Выйти из ДЖ\n" : "1) Искать\n", 0);
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
                                Battles.MakeRandomBattle(hero, 4, 5);
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
                            Battles.MakeCurrentBattle(hero, 5);
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
