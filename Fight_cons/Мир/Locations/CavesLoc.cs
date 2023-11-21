using System;

namespace Fight_cons.Мир
{
    internal class CavesLoc : AboutLoc
    {
        //  Пещеры начало
        public static void CavesStart(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "???";

            while (true)
            {
                //  Возможные события в локации
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{CurrentLocationName}\n");
                Output.TwriteLine(Dicscriptions(LocationName.Caves), 1);
                hero.HPBar();
                hero.MPBar();

                Console.Write("Ваши действия?\n"
                                + "1) Обыскать пещеру\n"
                                + "2) Отдохнуть\n");
                if (Hero.Exit_cave)
                    Console.Write("3) Выйти из пещеры\n");

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        Market.ShowWeaponGoods(hero);
                        //  Проверка боя с несколькими противниками
                        //if (Battles.Vero(0.9))
                        //    Battles.MakeBattle(hero, 1, 2, 0, 101, 102);
                        if (Battles.Vero(0.25))
                            if (!Hero.Exit_cave)
                            {
                                Output.TwriteLine("\nВы находите выход\n", 1);
                                Hero.Exit_cave = true;
                            }
                        if (Battles.Vero(0.7))
                        {
                            if (Battles.Vero(0.4))
                                Battles.MakeBattle(hero, 1);
                            else if (Battles.Vero(0.4))
                                Battles.MakeBattle(hero, 4);
                            else if (Battles.Vero(0.4))
                                Battles.MakeBattle(hero, 3);
                            else
                                Battles.MakeBattle(hero, 2);
                        }
                        hero.HeroStatistic.CaveResearch++;
                        Research(hero);
                        break;
                    case 2:
                        if (Battles.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeBattle(hero, 1);
                        }
                        break;
                    case 3:
                        if (Hero.Exit_cave)
                            VallyLoc.Vally(hero);
                        break;
                }
            }
        }

        //  Пещеры
        public static void Caves(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "Пещеры";

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{CurrentLocationName}\n");
                Output.TwriteLine(Dicscriptions(LocationName.Caves), 1);
                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Обыскать пещеру\n"
                                + "2) Отдохнуть\n"
                                + "3) Выйти из пещеры");

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        if (Battles.Vero(0.7))
                        {
                            if (Battles.Vero(0.4))
                                Battles.MakeBattle(hero, 1);
                            else if (Battles.Vero(0.4))
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
                        VallyLoc.Vally(hero);
                        break;
                }
            }
        }
    }
}
