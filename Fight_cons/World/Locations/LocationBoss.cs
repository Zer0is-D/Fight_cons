using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightCons.World.Locations
{
    internal class LocationBoss : FightCons.Locations
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            Endroom = 0
        }

        public static string[][] Descript = new string[][]
        {
            //  Хоромы
            new string[]
            {
                "Огромные шкафы под завязку забитые сведеньями и данными которые никому больше не пригодятся.",
                "Вы вспоминаете лица тех кто положил жизнь на поиск этого места. Места которого не станет",
            }
        };
        #endregion

        //  Хоромы
        public static void Endroom(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Хоромы\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Endroom), Descript), 0);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                            + "1) Бродить\n"
                            + "2) Отдохнуть\n"
                            + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //  Босс
                        if (GameFormulas.Vero(0.2))
                            hero.HeroQuests.MainMainQ(hero);
                        else if (GameFormulas.Vero(0.6))
                            Battles.MakeRandomBattle(hero, 2, 3);
                        else
                            Output.TwriteLine("Вы ничего не находите\n", 1);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 10, 11);
                        }
                        break;
                    case 3:
                        LocationVN.SpilledSpace(hero);
                        break;
                }
            }
        }
    }
}
