﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons.Мир
{
    internal class VillageLoc : AboutLoc
    {
        //  Окрестности
        public static void Neighborhood(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "Окрестности деревни";

            while (true)
            {
                hero.HeroQuests.StartQ(hero, 2);
                hero.HeroQuests.Q_Your_name(hero);

                //  Возможные события в локации
                if (Battles.Vero(0.3))
                    FindingPouchEvent(hero, 0, 5);
                if (Battles.Vero(0.1))
                    Battles.MakeBattle(hero, 4);

                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{CurrentLocationName}\n");
                Output.TwriteLine(Dicscriptions(LocationName.Neighborhood), 1);
                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Войти в деревню\n"
                                + "2) Отдохнуть\n"
                                + "3) Вернуться в долину");

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        Village(hero);
                        break;
                    case 2:
                        RestEvent(hero);
                        break;
                    case 3:
                        VallyLoc.Vally(hero);
                        break;
                }
            }
        }

        //  Деревня
        public static void Village(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "Деревня";

            while (true)
            {
                //  Возможные события в локации
                if (Battles.Vero(0.15))
                    FindingPouchEvent(hero, 3, 10);
                if (Battles.Vero(0.05))
                    Battles.MakeBattle(hero, 5);

                Output.WriteColorLine(ConsoleColor.Cyan, "Локация: ", $"{CurrentLocationName}\n");
                Output.TwriteLine(Dicscriptions(LocationName.Village), 1);
                hero.HPBar();
                hero.MPBar();

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
                            Inn(hero);
                        else
                            Village(hero);
                        break;
                    case 2:
                        Market_loc(hero);
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                }
            }
        }

        //  Трактир
        public static void Inn(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "Трактир";

            while (true)
            {
                string s = Dicscriptions(LocationName.Inn);
                Output.WriteColorLine(ConsoleColor.Cyan, "Локация: ", $"{CurrentLocationName}\n");
                Output.TwriteLine(s, 1);

                if (s.Contains("Атронахов"))
                    hero.Class_name = "Атронах";

                hero.HPBar();
                hero.MPBar();

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
                        Village(hero);
                        break;
                }
            }
        }

        //  Рынок
        public static void Market_loc(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "Рынок";

            while (true)
            {
                //  Возможные события в локации
                if (Battles.Vero(0.01))
                    FindingPouchEvent(hero, 10, 100);

                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{CurrentLocationName}\n");
                Output.TwriteLine(Dicscriptions(LocationName.Market), 1);
                hero.HPBar();
                hero.MPBar();

                //  Квесты
                if (hero.HeroQuests.Que[1] == 2)
                    hero.HeroQuests.Q_leva_Market(hero);

                Console.WriteLine("\nВаши действия?\n"
                              + "1) Наблюдать и подслушивать\n"
                              + "2) Купить оружие\n"
                              + "3) Купить броню");
                Output.WriteColorLine(ConsoleColor.Yellow, "4) Купить зелье здоровья (", $"20{Output.MoneySymbol}", ")\n");
                Output.WriteColorLine(ConsoleColor.Yellow, "5) Купить зелье маны (", $"30{Output.MoneySymbol}", ")\n");
                Console.WriteLine("6) Выйти");

                switch (Input.ChoisInput(hero, 1, 6))
                {
                    case 1:
                        //  Событие прослушивание  
                        break;

                    case 2:
                        Market.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        Market.ShowArmorGoods(hero);
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
                        Village(hero);
                        break;
                }
            }
        }

        //  Храм
        public static void Templ(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "Храм";

            //  Описания локации
            string[] Discript = new string[4];
            Discript[0] = "Место где становятся монахами";
            Discript[1] = "Огромный красивый зал, можно только догадываться как тут было прекрасно, до обвала";
            Discript[2] = "3";
            Discript[3] = "4";

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{CurrentLocationName}\n");
                //Outer.TwriteLine(Rand_discrip(Discript), 0);
                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Наблюдать и подслушивать\n"
                                + "2) Общаться\n"
                                + "3) Выйти из поместье");

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //  Событие "Осмотреться"
                        break;
                    case 2:
                        //  Событие прослушивание
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                }
            }
        }
    }
}
