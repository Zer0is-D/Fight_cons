using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    internal class LocationND
    {
        #region Данные и настроки локации
        public enum LocationName
        {
            Island1 = 0,
            SectorDzeta = 1,
            NewIaregaCity = 2,
            SectorEtta = 3,
            NewEdinstvenyCity = 4,
            SectorTeta = 5,
            GeliotopolCity = 6,
            SectorCsi = 7,
            HladnyPrimeCity = 8,
            SectorOmicron = 9,
            Cosmolit = 10,
            DarkGranulation = 11,
            SectorPi = 12,
            VladichiaOrbitaCity = 13,
            SectorHi = 14,
            OldIaregaCity = 15,
            SectorPsi = 16,
            Cvantograd = 17,
            SectorOmega = 18,
            GreenVectorVillage = 19,
        }

        public static string[][] Descript = new string[][]
        {
            //  Island1
            new string[]
            {
                "...",
            },
            //  SectorDzeta
            new string[]
            {
                "...",
            },
            //  NewIaregaCity
            new string[]
            {
                "...",
            },
            //  SectorEtta
            new string[]
            {
                "...",
            },
            //  NewEdinstvenyCity
            new string[]
            {
                "...",
            },
            //  SectorTeta
            new string[]
            {
                "...",
            },
            //  GeliotopolCity
            new string[]
            {
                "...",
            },
            //  SectorCsi
            new string[]
            {
                "...",
            },
            //  HladnyPrimeCity
            new string[]
            {
                "...",
            },
            //  SectorOmicron
            new string[]
            {
                "...",
            },
            //  Cosmolit
            new string[]
            {
                "...",
            },
            //  DarkGranulation
            new string[]
            {
                "...",
            },
            //  SectorPi
            new string[]
            {
                "...",
            },
            //  VladichiaOrbitaCity
            new string[]
            {
                "...",
            },
            //  SectorHi
            new string[]
            {
                "...",
            },
            //  OldIaregaCity
            new string[]
            {
                "...",
            },
            //  SectorPsi
            new string[]
            {
                "...",
            },
            //  Cvantograd
            new string[]
            {
                "...",
            },
            //  SectorOmega
            new string[]
            {
                "...",
            },
            //  GreenVectorVillage
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

        //  Выход со стартовой позиции
        public static bool ExitCave;
        #endregion

        #region Локации НД
        //Остров1
        public static void Island1(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Остров1\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Island1)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Лететь в Сектор Дзета\n"
                           + "3) Выйти из НД";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorDzeta(hero);
                        break;
                    case 3:
                        LocationVN.SpilledSpace(hero);
                        break;
                }
            }
        }

        //Сектор Дзета
        public static void SectorDzeta(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Дзета\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorDzeta)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Лететь в город Новая Ярега\n"
                           + "3) Лететь в сектор Этта\n"
                           + "4) Лететь в сектор Пи\n"
                           + "5) Вернуться на остров1";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewIaregaCity(hero);
                        break;
                    case 3:
                        SectorEtta(hero);
                        break;
                    case 4:
                        SectorPi(hero);
                        break;
                    case 5:
                        Island1(hero);
                        break;
                }
            }
        }

        //Город Новая Ярега
        public static void NewIaregaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новая Ярега\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NewIaregaCity)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorDzeta(hero);
                        break;
                }
            }
        }

        //Сектор Этта
        public static void SectorEtta(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Этта\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorEtta)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Новый Единственный\n"
                           + "3) Лететь в сектор Тета\n"
                           + "4) Лететь в сектор Дзета\n"
                           + "5) Лететь в сектор Омикрон";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorTeta(hero);
                        break;
                    case 4:
                        SectorDzeta(hero);
                        break;
                    case 5:
                        SectorOmicron(hero);
                        break;
                }
            }
        }

        //Город Новый Единственный
        public static void NewEdinstvenyCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.NewEdinstvenyCity)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Тета
        public static void SectorTeta(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Тета\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorTeta)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Гелиотополь\n"
                           + "3) Лететь в сектор Этта\n"
                           + "4) Лететь в сектор Кси";


                switch (Input.ChoisInput(hero, 1, 4, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        GeliotopolCity(hero);
                        break;
                    case 3:
                        SectorEtta(hero);
                        break;
                    case 4:
                        SectorCsi(hero);
                        break;
                }
            }
        }

        //Город Гелиотополь
        public static void GeliotopolCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.GeliotopolCity)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorTeta(hero);
                        break;
                }
            }
        }

        //Сектор Кси
        public static void SectorCsi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Кси\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorCsi)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Новый Единственный\n"
                           + "3) Лететь в сектор Тета\n"
                           + "4) Лететь в сектор Омикрон\n"
                           + "5) Лететь в сектор Хи";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorTeta(hero);
                        break;
                    case 4:
                        SectorOmicron(hero);
                        break;
                    case 5:
                        SectorHi(hero);
                        break;
                }
            }
        }

        //Город Хладный Прайм
        public static void HladnyPrimeCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.HladnyPrimeCity)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Омикрон
        public static void SectorOmicron(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Омикрон\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorOmicron)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти к Космолиту\n"
                           + "3) Идти к Темной грануляции\n"
                           + "4) Лететь в сектор Этта\n"
                           + "5) Лететь в сектор Кси\n"
                           + "6) Лететь в сектор Пи\n"
                           + "7) Лететь в сектор Пси";


                switch (Input.ChoisInput(hero, 1, 7, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Cosmolit(hero);
                        break;
                    case 3:
                        DarkGranulation(hero);
                        break;
                    case 4:
                        SectorEtta(hero);
                        break;
                    case 5:
                        SectorCsi(hero);
                        break;
                    case 6:
                        SectorPi(hero);
                        break;
                    case 7:
                        SectorPsi(hero);
                        break;
                }
            }
        }

        //Космолит
        public static void Cosmolit(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Cosmolit)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Темная грануляция
        public static void DarkGranulation(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.DarkGranulation)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Пи
        public static void SectorPi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Пи\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorPi)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Владычья Орбита\n"
                           + "3) Лететь в сектор Дзета\n"
                           + "4) Лететь в сектор Омикрон\n"
                           + "5) Лететь в сектор Омега";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorDzeta(hero);
                        break;
                    case 4:
                        SectorOmicron(hero);
                        break;
                    case 5:
                        SectorOmega(hero);
                        break;
                }
            }
        }

        //Город Владычья Орбита
        public static void VladichiaOrbitaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.VladichiaOrbitaCity)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Хи
        public static void SectorHi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Хи\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorHi)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Старая Ярега\n"
                           + "3) Лететь в сектор Кси\n"
                           + "4) Лететь в сектор Пси";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        NewEdinstvenyCity(hero);
                        break;
                    case 3:
                        SectorTeta(hero);
                        break;
                    case 4:
                        SectorOmicron(hero);
                        break;
                    case 5:
                        SectorDzeta(hero);
                        break;
                }
            }
        }

        //Город Старая Ярега
        public static void OldIaregaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.OldIaregaCity)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Пси
        public static void SectorPsi(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Пси\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorPsi)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Квантоград\n"
                           + "3) Лететь в сектор Омикрон\n"
                           + "4) Лететь в сектор Хи\n"
                           + "5) Лететь в сектор Омега";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Cvantograd(hero);
                        break;
                    case 3:
                        SectorOmicron(hero);
                        break;
                    case 4:
                        SectorHi(hero);
                        break;
                    case 5:
                        SectorOmega(hero);
                        break;
                }
            }
        }

        //Квантоград
        public static void Cvantograd(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Квантоград\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Cvantograd)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        //Сектор Омега
        public static void SectorOmega(Hero hero)
        {
            if (GameFormulas.Vero(0.6))
                Battles.MakeRandomBattle(hero, 0, 1, 2);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Омега\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorOmega)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в поселение Зеленый Вектор\n"
                           + "3) Лететь в сектор Пи\n"
                           + "4) Лететь в сектор Пси";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        GreenVectorVillage(hero);
                        break;
                    case 3:
                        SectorPi(hero);
                        break;
                    case 4:
                        SectorPsi(hero);
                        break;
                }
            }
        }

        //Поселение Зеленый Вектор
        public static void GreenVectorVillage(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Новый Единственный\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.GreenVectorVillage)), 1);

                hero.HPBar();
                hero.MPBar();

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorEtta(hero);
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
                //VillageOrdo(hero);
            }
            hero.Sneak = 0;
            hero.DrunkCondition++;
        }

        //  Событие отдых
        private static void RestEvent(Hero hero)
        {
            if (hero.ClassName != "Волшебник")
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
