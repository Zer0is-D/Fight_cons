using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons.Мир
{
    internal class DeepWoodsLoc : AboutLoc
    {
        //  Темные леса
        public static void DeepWoods(Hero hero)
        {
            //  Название локации
            CurrentLocationName = "Леса";

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{CurrentLocationName}\n");
                Output.TwriteLine(Dicscriptions(LocationName.DeepWoods), 1);
                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Бродить\n"
                                + "2) Отдохнуть\n"
                                + "3) Вернуться в долину");

                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //  Босс
                        if (Battles.Vero(0.2) & hero.HeroQuests.Que[0] == 0)
                        {
                            hero.HeroQuests.Que[0] = 1;
                            hero.HeroQuests.MainQ(hero);
                            
                        }
                        //else if (Mechanics.Vero(0.9))
                        //{
                        //    Enemy Drevo = new Enemy
                        //    {
                        //        Name = "Drevo",
                        //        MAX_HP = 20,
                        //        hp = 20,
                        //        RUN = false
                        //    };
                        //    Mechanics.Battle(hero, Drevo);
                        //}                            
                        else if (Battles.Vero(0.6))
                            Battles.MakeBattle(hero, 4);
                        else if (Battles.Vero(0.4))
                            Battles.MakeBattle(hero, 5);
                        else
                            Output.TwriteLine("Вы ничего не находите\n", 1);
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
