using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightCons.World.Locations
{
    internal class LocationND : FightCons.Locations
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
            Glaciers = 16,
            SectorPsi = 17,
            Cvantograd = 18,
            SectorOmega = 19,
            GreenVectorVillage = 20,
            Dealer = 21,
        }

        public static string[][] Descript = new string[][]
        {
            //  Island1
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" +
                "то примыкающие к большим крупицам",
            },
            //  SectorDzeta
            new string[]
            {
                "Сектор где жизни идет свои ходом. Одно из немногих спокойных мест для проживания",
            },
            //  NewIaregaCity
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorEtta
            new string[]
            {
                "Тут располагается столица - сердце империи",
            },
            //  NewEdinstvenyCity
            new string[]
            {
                "Новый Единственный - город манифест заявляющий о единствен между народами и целями",
            },
            //  SectorTeta
            new string[]
            {
                "Производственный центр Империи, сюда приезжают за работой! В Империи нет места лентяям",
                "Большое количество залежей антигравия добывается и обрабатывается именно здесь",
            },
            //  GeliotopolCity
            new string[]
            {
                "Гелиотополь город производства. По сути колония куда ссылают работать",
                "Не самое приятное место для жизни и работы. Однако гарантия жилья и безопасности все еще подкупает определенную прослойку населения",
            },
            //  SectorCsi
            new string[]
            {
                "Вечно мятежный сектор Кси. Известен своим буйным нравом и нестабильностью. Империя в попытках усмирить сектор потратила " +
                "немыслимые суммы и огромное количество солдат",
                "Нестабильность и преступность сектора парой играет Империи на руку - там они без особых проблем заключат 'не официальные' сделки, а отставные генералы" +
                "продают списанные корабли"
            },
            //  HladnyPrimeCity
            new string[]
            {
                "Хладный Прайм - город возможностей и приключений. Сюда приезжают из соседних секторов 'покуролесить по полной'",
                "Тут можно приобрести рабов, оружия, незаконные препараты и корабли. Главное не спрашивать откуда товар",
                "Пластичность моральных качеств местных предпринимателей настолько поражает - что невольно считаешь себя святым",
            },
            //  SectorOmicron
            new string[]
            {
                "Центр мира вокруг которого вертеться все. Место обитания левиафанов и других хищников. Отсюда раз в ... происходит нападения на все сектора",
                "Вольные государства и даже империя пыталась раз и навсегда покончить с левиафанами, но все попытки заканчивались " +
                "провалом. Географические особенности и бури не позволяют эффективно организовывать какие либо операции в этом секторе",
            },
            //  Cosmolit
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  DarkGranulation
            new string[]
            {
                "Кипящие пространства наполненное всюду беспорядочно крутящимися пылинками-кораблями, то резко исчезающими, \n" 
                + "то примыкающие к большим крупицам",
            },
            //  SectorPi
            new string[]
            {
                "Сектор с размерено и спокойной жизнью. Является самым 'раскрошенным' по островам и обделенная ресурсами, " +
                "однако именно поэтому империи на нее никогда не нападет",
                "Сожмите печенье и киньте в стакан молока, те мелкие кусочки что всплыли будут тем множеством раздробленных жилых островков в секторе",
            },
            //  VladichiaOrbitaCity
            new string[]
            {
                "Мирные, семейные и религиозные - так можно охарактеризовать местных людей",
                "Поговаривают что среди местных тайно живут отставные солдаты империи под видом беженцев",
            },
            //  SectorHi
            new string[]
            {
                "Младший брат сектора Омикрон - так можно сказать о секторе Хи",
                "Местные бояться селиться из-за суеверных поверий насчет руин, империя потеряла интерес к месту после пропажи нескольких " +
                "разведывательных кораблей, но от чего бежит разумный туда же мчит безумный. Рыскари верят что здесь можно обогатиться",
            },
            //  OldIaregaCity
            new string[]
            {
                "Городок который должен был закрыться и тихо умереть, но постоянный приток рыскарей поддерживает в нем жизнь",
                "Тут можно быстро найти работу, просадить состояния в баре и заработать кучу долгов",
            },
            
            //  Ледняки
            new string[]
            {
                //TODO Добавить описания
                "Собачий холод и пустота"
            },
            //  SectorPsi   
            new string[]
            {
                "Кость в горле империи. Центр вольных государств где сосредоточен объединенный флот. " +
                "Помимо постоянных интриг и заявлений политиков в работе на империю, здесь находится второй центр бурной жизни",
            },
            //  Cvantograd
            new string[]
            {
                "Квантоград город умельцев и убежище противников империи",
                "Удобное географическое положения и грамотное расстановка сил дает преимущество в защите и обороне сектора и в города в частности.",
            },
            //  SectorOmega
            new string[]
            {
                "Сектор Омега является спасением для вольных государств. Здесь огромное количество ресурсов и нетипичная фауна",
                "Частные компании разных вольных государств добывают ресурсы облажены особым налогом который уходит на постройку и поддержания " +
                "флота обеспечивающего защиту от попыток империи захватить сектор",
            },
            //  GreenVectorVillage
            new string[]
            {
                "Поселение Зеленый Вектор - уютный городок где отдыхают после тяжелой работы мирные люди. " +
                "Однако над этим стоят бесконечные интриги и конфликты между компаниями",
            },
        };

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
                Output.TwriteLine(Descriptions(((byte)LocationName.Island1), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Лететь в Сектор Дзета\n";
                           //+ "3) Выйти из НД";


                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        SectorDzeta(hero);
                        break;
                    //case 3:
                    //    LocationVN.SpilledSpace(hero);
                    //    break;
                }
            }
        }

        //Сектор Дзета
        public static void SectorDzeta(Hero hero)
        {
            if (GameFormulas.Vero(0.4))
                Battles.MakeRandomBattle(hero, 60, 61, 62);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Дзета\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorDzeta), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Лететь в город Новая Ярега\n"
                           + "3) Лететь в сектор Этта\n"
                           + "4) Лететь в сектор Пи\n"
                           + "5) Вернуться на остров1\n"
                           + "6) Отдохнуть";


                switch (Input.ChoisInput(hero, 1, 6, quo))
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
                    case 6:
                        if (GameFormulas.Vero(0.75))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 3);
                        }
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
                Output.TwriteLine(Descriptions(((byte)LocationName.NewIaregaCity), Descript), 1);

                hero.HPnMPBar(true, true);

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
            if (GameFormulas.Vero(0.8))
                Battles.MakeRandomBattle(hero, 60, 61, 62);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Этта\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorEtta), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Новый Единственный\n"
                           + "3) Лететь в сектор Тета\n"
                           + "4) Лететь в сектор Дзета\n"
                           + "5) Лететь в сектор Омикрон\n"
                           + "6) Отдохнуть";


                switch (Input.ChoisInput(hero, 1, 6, quo))
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
                    case 6:
                        if (GameFormulas.Vero(0.5))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 60, 61);
                        }
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
                Output.TwriteLine(Descriptions(((byte)LocationName.NewEdinstvenyCity), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "1) Пойти к торговцам\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Dealer(hero);  
                        break;
                    case 3:
                        SectorEtta(hero);
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
                        NewEdinstvenyCity(hero);
                        break;
                }
            }
        }

        //Сектор Тета
        public static void SectorTeta(Hero hero)
        {
            if (GameFormulas.Vero(0.7))
                Battles.MakeRandomBattle(hero, 60, 61, 62);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Тета\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorTeta), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в Город Гелиотополь\n"
                           + "3) Лететь в сектор Этта\n"
                           + "4) Лететь в сектор Кси\n"
                           + "5) Отдохнуть";


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
                    case 5:
                        if (GameFormulas.Vero(0.6))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 60, 61);
                        }
                        break;
                }
            }
        }

        //Город Гелиотополь
        public static void GeliotopolCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Гелиотополь\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.GeliotopolCity), Descript), 1);

                hero.HPnMPBar(true, true);

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
                Battles.MakeRandomBattle(hero, 66, 67, 68);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Кси\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorCsi), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Хладный Прайм\n"
                           + "3) Лететь в сектор Тета\n"
                           + "4) Лететь в сектор Омикрон\n"
                           + "5) Лететь в сектор Хи\n"
                           + "6) Отдохнуть";


                switch (Input.ChoisInput(hero, 1, 6, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        HladnyPrimeCity(hero);
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
                    case 6:
                        if (GameFormulas.Vero(0.2))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 68, 68);
                        }
                        break;
                }
            }
        }

        //Город Хладный Прайм
        public static void HladnyPrimeCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Хладный Прайм\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.HladnyPrimeCity), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 2, quo))
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
            if (GameFormulas.Vero(0.9))
                Battles.MakeRandomBattle(hero, 60, 61, 62, 63, 64, 65, 66, 67, 68);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Омикрон\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorOmicron), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти к Космолиту\n"
                           + "3) Идти к Темной грануляции\n"
                           + "4) Лететь в сектор Этта\n"
                           + "5) Лететь в сектор Кси\n"
                           + "6) Лететь в сектор Пи\n"
                           + "7) Лететь в сектор Пси\n"
                           + "8) Отдохнуть";


                switch (Input.ChoisInput(hero, 1, 8, quo))
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
                    case 8:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 1, 1, 1, 1);
                        }
                        break;
                }
            }
        }

        //Космолит
        public static void Cosmolit(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Космолит\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Cosmolit), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 2, quo))
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
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Темная грануляция\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.DarkGranulation), Descript), 1);

                hero.HPnMPBar(true, true);

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
            if (GameFormulas.Vero(0.4))
                Battles.MakeCurrentBattle(hero, 3);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Пи\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorPi), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Владычья Орбита\n"
                           + "3) Лететь в сектор Дзета\n"
                           + "4) Лететь в сектор Омикрон\n"
                           + "5) Лететь в сектор Омега\n"
                           + "6) Отдохнуть";


                switch (Input.ChoisInput(hero, 1, 6, quo))
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
                    case 6:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 3);
                        }
                        break;
                }
            }
        }

        //Город Владычья Орбита
        public static void VladichiaOrbitaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Владычья Орбита\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.VladichiaOrbitaCity), Descript), 1);

                hero.HPnMPBar(true, true);

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
            if (GameFormulas.Vero(0.8))
                Battles.MakeRandomBattle(hero, 66, 67, 68);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Хи\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorHi), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Старая Ярега\n"
                           + "3) Лететь в сектор Кси\n"
                           + "4) Лететь в сектор Пси\n"
                           + "5) Отдохнуть";


                switch (Input.ChoisInput(hero, 1, 5, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        OldIaregaCity(hero);
                        break;
                    case 3:
                        SectorCsi(hero);
                        break;
                    case 4:
                        SectorPsi(hero);
                        break;
                    case 5:
                        if (GameFormulas.Vero(0.7))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeRandomBattle(hero, 66, 67, 68);
                        }
                        break;
                }
            }
        }

        //Город Старая Ярега
        public static void OldIaregaCity(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Город Старая Ярега\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.OldIaregaCity), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Спуститься к ледникам\n"
                           + "3) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        Glaciers(hero);
                        break;
                    case 3:
                        SectorHi(hero);
                        break;
                }
            }
        }

        //Ледники
        public static void Glaciers(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Ледники\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.Glaciers), Descript), 1);

                hero.HPnMPBar(true, true);

                Output.TwriteLine("\nВаши действия?\n", 0);
                Output.TwriteLine(hero.HeroQuests.Que[6] == 2 ? "1) Выйти из НД" : "1) Искать", 0);
                Output.TwriteLine("2) Отдохнуть\n"
                                + "3) Вернуться в Старую Ярегу", 1);


                switch (Input.ChoisInput(hero, 1, 3))
                {
                    case 1:
                        //  Босс
                        if (hero.HeroQuests.Que[6] == 2)
                            LocationVN.SpilledSpace(hero);
                        else
                        {
                            if (GameFormulas.Vero(0.2) & hero.HeroQuests.Que[6] == 0)
                            {
                                hero.HeroQuests.Que[6] = 1;
                                hero.HeroQuests.MainND(hero);
                            }
                            else if (GameFormulas.Vero(0.6))
                                Battles.MakeRandomBattle(hero, 1, 3);
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
                            Battles.MakeRandomBattle(hero, 66, 67, 68);
                        }
                        break;
                    case 3:
                        OldIaregaCity(hero);
                        break;
                }
            }
        }

        //Сектор Пси
        public static void SectorPsi(Hero hero)
        {
            if (GameFormulas.Vero(0.8))
                Battles.MakeRandomBattle(hero, 63, 64, 65);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Пси\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorPsi), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в город Квантоград\n"
                           + "3) Лететь в сектор Омикрон\n"
                           + "4) Лететь в сектор Хи\n"
                           + "5) Лететь в сектор Омега\n"
                           + "6) Отдохнуть";


                switch (Input.ChoisInput(hero, 1, 6, quo))
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
                    case 6:
                        if (GameFormulas.Vero(0.8))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 3);
                        }
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
                Output.TwriteLine(Descriptions(((byte)LocationName.Cvantograd), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Вернуться";


                switch (Input.ChoisInput(hero, 1, 2, quo))
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
                Battles.MakeRandomBattle(hero, 63, 64, 65);

            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Сектор Омега\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.SectorOmega), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Идти в поселение Зеленый Вектор\n"
                           + "3) Лететь в сектор Пи\n"
                           + "4) Лететь в сектор Пси\n"
                           + "5) Отдохнуть";


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
                    case 5:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 1, 1, 7);
                        }
                        break;
                }
            }
        }

        //Поселение Зеленый Вектор
        public static void GreenVectorVillage(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Зеленый Вектор\n");
                Output.TwriteLine(Descriptions(((byte)LocationName.GreenVectorVillage), Descript), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Осмотреться\n"
                           + "2) Осмотреться\n"
                           + "3) Вернуться";


                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            Battles.MakeCurrentBattle(hero, 1);
                        }
                        break;
                    case 3:
                        SectorEtta(hero);
                        break;
                }
            }
        }

        #endregion
    }
}
