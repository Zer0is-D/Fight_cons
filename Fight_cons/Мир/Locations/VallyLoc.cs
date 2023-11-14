using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons.Мир
{
    internal class VallyLoc : AboutLoc
    {
        //  Долина
        public static void Vally(Hero hero)
        {
            //  Название локации
            Loc_name = "Долина";

            while (true)
            {
                //  Возможные события в локации
                if (Battles.Vero(0.4))
                    Battles.MakeBattle(hero, 3);
                if (Battles.Vero(0.01))
                    Pouch(hero, 1, 7);

                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{Loc_name}\n");
                Output.TwriteLine(Dicscriptions(LocationName.Vally), 1);
                hero.HPBar();
                hero.MPBar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Вернуться в пещеры\n"
                                + "2) Передохнуть\n"
                                + "3) Пойти в деревню\n"
                                + "4) Пойти в лес");

                switch (Input.ChoisInput(hero, 1, 4))
                {
                    case 1:
                        CavesLoc.Caves(hero);
                        break;
                    case 2:
                        Rest(hero);
                        break;
                    case 3:
                        VillageLoc.Neighborhood(hero);
                        break;
                    case 4:
                        DeepWoodsLoc.Deep_woods(hero);
                        break;
                }
            }
        }
    }
}
