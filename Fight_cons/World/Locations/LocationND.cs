using FightCons.CoreNSettings;
using FightCons.WForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static FightCons.CoreNSettings.Map;

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

        #region Настройки карт

        //TODO ПОНЯТЬ КАК СПАВНИТЬ ИГРОКА В РАЗНЫЕ МЕСТА В ЗАВИСИМОСТИ ОТ ПОЗИЦИИ В СЛЕД ЛОКАЦИИ
        static List<Map> maps = new List<Map>()
        {
            #region SectorDzeta 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','⌂','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(1, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.DzetaToEtta;
                            SectorEtta(hero);
                        }
                    },
                    {(10, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.DzetaToPi;
                            SectorPi(hero);
                        }
                    },
                    {(16, 7), NewIaregaCity },
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion

            #region SectorEtta 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#', },
                    { '#','.','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(1, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.EttaToTeta;
                            SectorTeta(hero);
                        }
                    },
                    {(10, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.EttaToOmicron;
                            SectorOmicron(hero);
                        }
                    },
                    {(18, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.EttaToDzeta;
                            SectorDzeta(hero);
                        }
                    },
                    {(10, 5), NewEdinstvenyCity }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion*/

            #region SectorTeta 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','O','#', },
                    { '#','.','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(18, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.TetaToEtta;
                            SectorEtta(hero);
                        }
                    },
                    {(10, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.TetaToCsi;
                            SectorCsi(hero);
                        }
                    },
                    {(10, 5), GeliotopolCity }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion*/

            #region SectorCsi 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','.','O','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(10, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.CsiToTeta;
                            SectorTeta(hero);
                        }
                    },
                    {(18, 5), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.CsiToOmicron;
                            SectorOmicron(hero);
                        }
                    },
                    {(10, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.CsiToHi;
                            SectorHi(hero);
                        }
                    },
                    {(10, 5), HladnyPrimeCity }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion

            #region SectorOmicron 
            new Map
            (
                //  Размеры
                20, 20,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','#','#','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','#','#','#','.','.','.','#', },
                    { '#','.','.','.','.','#','#','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','#','#','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','#','#','#','#','#','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','#','#','#','#','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','#','#','O','.','#','.','.','.','.','.','O','#', },
                    { '#','O','.','.','.','.','#','#','#','#','#','.','#','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','#','#','#','.','#','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','#','.','.','#','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','#','#','#','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','O','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(10, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.OmicronToEtta;
                            SectorEtta(hero);
                        }
                    },
                    {(18, 9), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.OmicronToPi;
                            SectorPi(hero);
                        }
                    },
                    {(1, 10), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.OmicronToCsi;
                            SectorCsi(hero);
                        }
                    },
                    {(10, 18), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.OmicronToPsi;
                            SectorPsi(hero);
                        }
                    },
                    {(6, 16), Cosmolit },
                    {(10, 9), DarkGranulation }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion*/

            #region SectorPi 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','O','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(10, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.PiToDzeta;
                            SectorDzeta(hero);
                        }
                    },
                    {(1, 5), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.PiToOmicron;
                            SectorOmicron(hero);
                        }
                    },
                    {(10, 8), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.PiToOmega;
                            SectorOmega(hero);
                        }
                    },
                    {(10, 5), VladichiaOrbitaCity }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion*/

            #region SectorHi 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','.','O','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','X','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(10, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.HiToCsi;
                            SectorCsi(hero);
                        }
                    },
                    {(18, 5), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.HiToPsi;
                            SectorPsi(hero);
                        }
                    },
                    {(10, 5), OldIaregaCity }, 
                    {(4, 7),  Glaciers}
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion*/

            #region SectorPsi 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','.','O','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(10, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.PsiToOmicron;
                            SectorOmicron(hero);
                        }
                    },
                    {(1, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.PsiToHi;
                            SectorHi(hero);
                        }
                    },
                    {(18, 5), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.PsiToOmega;
                            SectorOmega(hero);
                        }
                    },
                    {(10, 5), Cvantograd }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion*/

            #region SectorOmega 
            new Map
            (
                //  Размеры
                20, 10,

                //  Карта
                new char[,]
                {
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                    { '#','.','.','.','.','.','.','.','.','.','O','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','O','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','⌂','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','.','#', },
                    { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
                },
                //  Интерактивные объекты
                new Dictionary<(int, int), Action>
                {

                },
                //  Тригер события
                new Dictionary<List<(int, int)>, Action>
                {
                },
                //  Точки выхода
                new Dictionary<(int, int), Action<Hero>>
                {
                    {(10, 1), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.OmegaToPi;
                            SectorPi(hero);
                        }
                    },
                    {(1, 4), (Hero hero) =>
                        {
                            hero.HeroCoordinates = transit.OmegaToPsi;
                            SectorPsi(hero);
                        }
                    },
                    {(10, 5), GreenVectorVillage }
                },
                (RestEvent,
                (Hero hero) =>
                {
                    RestEvent(hero);

                    List<BattleSession> battleList = new List<BattleSession>()
                    {
                        new BattleSession(1, Character.ChaRole.Wild),
                    };
                    Battles.MakeRandomBattle(hero, battleList);
                },
                0.8)
            ),
            #endregion*/
        };

        static Dictionary<Enum, (int, int)> SpawnPoints = new Dictionary<Enum, (int, int)>
        {
            //  Dzeta
            { transit.EttaToDzeta, (4, 4)},
            { transit.NewIaregaCityToDzeta, (16, 6)},
            { transit.PiToDzeta, (10, 7)},

            //  Etta
            { transit.DzetaToEtta, (17, 4)},
            { transit.NewEdinstvenyCityToEtta, (10, 4)},
            { transit.OmicronToEtta, (10, 7)},
            { transit.TetaToEtta, (2, 4)},

            //  Teta
            { transit.EttaToTeta, (17, 4)},
            { transit.GeliotopolCityToTeta, (9, 5)},
            { transit.CsiToTeta, (10, 7)},

            //  Csi
            { transit.TetaToCsi, (10, 2)},
            { transit.HladnyPrimeCityToCsi, (9, 5)},
            { transit.OmicronToCsi, (17, 5)},
            { transit.HiToCsi, (10, 7)},

            //  Omicron
            { transit.EttaToOmicron, (10, 2)},
            { transit.CosmolitToOmicron, (6, 15)},
            { transit.DarkGranulationToOmicron, (11, 9)},
            { transit.CsiToOmicron, (2, 10)},
            { transit.PsiToOmicron, (10, 17)},
            { transit.PiToOmicron, (17, 9)},

            //  Pi
            { transit.DzetaToPi, (10, 2)},
            { transit.VladichiaOrbitaCityToPi, (11, 5)},
            { transit.OmicronToPi, (2, 5)},
            { transit.OmegaToPi, (10, 7)},

            //  Hi
            { transit.CsiToHi, (10, 2)},
            { transit.OldIaregaCityToHi, (10, 6)},
            { transit.GlaciersToHi, (5, 7)},
            { transit.PsiToHi, (17, 5)},

            //  Psi
            { transit.OmicronToPsi, (10, 2)},
            { transit.CvantogradToPsi, (10, 6)},
            { transit.HiToPsi, (2, 4)},
            { transit.OmegaToPsi, (17, 5)},

            //  Omega
            { transit.PsiToOmega, (2, 4)},
            { transit.GreenVectorVillageToOmega, (10, 6)},
            { transit.PiToOmega, (10, 2)},
        };

        static bool CanPass = false;

        #endregion

        #region Настройки магазина
        //  Наименование объектов
        private static InventoryItem healPotionItem = new InventoryItem()
        {
            Name = "Целебник",
            Description = "(Восстанавливает здоровье)",
        };

        private static InventoryItem manaPotionItem = new InventoryItem()
        {
            Name = "Концентрат",
            Description = "(Восстанавливает ману)",
        };

        //  Настройки для магазина
        static sbyte GoodsNum = 9;
        static sbyte BonusesNum = 2; //  1-8

        //TODO Придумать реест с общим
        static List<Material> Materials = new List<Material>
        {
            new Material(WoodMat, 0.7, 3),
            new Material(MixedMat, 0.2, 6),
            new Material(IronMat, 0.05, 9),
            new Material(AlloyMat, 0.05, 12),
        };
        static Dictionary<string, List<string>> WeaponsByMaterial = new Dictionary<string, List<string>>()
        {
            { WoodMat, new List<string> { "Деревянный меч", "Деревянная пика", "Деревянный топор", } },
            { MixedMat, new List<string> { "Смешанный меч", "Смешанная пика", "Смешанный топор", "Большой топор", "Секира", "Топорище", "Арбалет", "Серп", "Молот", } },
            { IronMat, new List<string> { "Железный меч", "Железная пика", "Железный топор", "Большой топор", "Секира", "Тяжелый арбалет", "Топорище", "Рапира", "Катана", "Арбалет", "Клинок", } },
            { AlloyMat, new List<string> { "Сплавленный меч", "Сплавленная пика", "Сплавленный топор", "Большой топор", "Секира", "Тяжелый арбалет", "Топорище", "Рапира", "Катана", "Арбалет", } },
        };
        static Dictionary<string, List<string>> ArmorByMaterial = new Dictionary<string, List<string>>()
        {
            { WoodMat, new List<string> { "Деревянная броня", "Деревянная кираса", "Деревянный жилет", } },
            { MixedMat, new List<string> { "Смешанная броня", "Смешанная кираса", "Смешанный жилет", "Кожаная броня" } },
            { IronMat, new List<string> { "Железная броня", "Железная кираса", "Железный жилет", } },
            { AlloyMat, new List<string> { "Сплавленная броня", "Сплавленная кираса", "Сплавленный жилет", } },
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
        private static Store DealerMarket = new Store(61, GoodsNum, BonusesNum, Materials, WeaponsByMaterial, ArmorByMaterial);
        #endregion
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
                        hero.HeroCoordinates = transit.NewIaregaCityToDzeta;
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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область зверолова
                new LocationScenarioEvent
                (
                    0.2,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            //GameFormulas.CurrentCoordinates((3, 5), (4, 5), (5, 5)),
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2),
                                (1, 3), (2, 3),
                                (1, 4), (2, 4),
                                (1, 5), (2, 5),
                                (1, 6), (2, 6)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                        {
                            new BattleScenarioEvent
                            (
                                (hero, EnemyList, turn) => hero.Turn == 0,
                                (hero, EnemyList) =>
                                {
                                    Output.TwriteLine("\n- Предъявите документы!", 10, true);
                                    Output.TwriteLine("\n*У вас нет документов*", 10, true);
                                    Output.TwriteLine("\n- Шпион 'Вольников'!", 10, true);
                                }
                            ),
                        };

                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(60, Character.ChaRole.Enemy),
                            new BattleSession(61, Character.ChaRole.Enemy),
                        };
                        Battles.MakeRandomBattle(hero, battleList, battleScenarioEvents);
                    },
                    true
                ),
                #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Дзета";
            locInfo[1] = Descriptions(((byte)LocationName.SectorDzeta), Descript);

            maps[0].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[0].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.4))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(60, Character.ChaRole.Enemy),
                    new BattleSession(61, Character.ChaRole.Enemy),
                    new BattleSession(62, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }                

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.NewIaregaCityToDzeta;
                        SectorDzeta(hero);
                        break;
                }
            }
        }

        //Сектор Этта
        public static void SectorEtta(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Имперских войск
                new LocationScenarioEvent
                (
                    0.05,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                        {
                            new BattleScenarioEvent
                            (
                                (hero, EnemyList, turn) => hero.Turn == 0,
                                (hero, EnemyList) =>
                                {
                                    Output.TwriteLine("\n- Предъявите документы!", 10, true);
                                    Output.TwriteLine("\n*У вас нет документов*", 10, true);
                                    Output.TwriteLine("\n- Шпион 'Вольников'!", 10, true);
                                }
                            ),
                        };

                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(60, Character.ChaRole.Enemy),
                            new BattleSession(61, Character.ChaRole.Enemy),
                        };
                        Battles.MakeRandomBattle(hero, battleList, battleScenarioEvents);
                    },
                    true
                ),
                #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Этта";
            locInfo[1] = Descriptions(((byte)LocationName.SectorEtta), Descript);

            maps[1].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[1].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.8))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(60, Character.ChaRole.Enemy),
                    new BattleSession(61, Character.ChaRole.Enemy),
                    new BattleSession(62, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(60, Character.ChaRole.Enemy),
                                new BattleSession(61, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.NewEdinstvenyCityToEtta; 
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
                Output.PayMoneyLine($"4) Купить {healPotionItem.Name}", 50, hero.Money);
                Output.PayMoneyLine($"5) Купить {manaPotionItem.Name}", 100, hero.Money);
                Console.WriteLine("6) Выйти");

                switch (Input.ChoisInput(hero, 1, 6))
                {
                    case 1:
                        //TODO Событие прослушивание  
                        break;

                    case 2:
                        DealerMarket.ShowWeaponGoods(hero);
                        break;

                    case 3:
                        DealerMarket.ShowArmorGoods(hero);
                        break;

                    case 4:
                        if (Output.Spent(hero, 50, healPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            healPotionItem.UseItem = healPotionItem.HealPotion;
                            Inventory.ItemAdd(hero, healPotionItem);
                        }
                        break;

                    case 5:
                        if (Output.Spent(hero, 100, manaPotionItem.Name, "\nВы нищеброд! Проваливайте!\n"))
                        {
                            manaPotionItem.UseItem = manaPotionItem.ManaPotion;
                            Inventory.ItemAdd(hero, manaPotionItem);
                        }
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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.1,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                        {
                            new BattleScenarioEvent
                            (
                                (hero, EnemyList, turn) => hero.Turn == 0,
                                (hero, EnemyList) =>
                                {
                                    Output.TwriteLine("\n- Предъявите документы!", 10, true);
                                    Output.TwriteLine("\n*У вас нет документов*", 10, true);
                                    Output.TwriteLine("\n- Шпион 'Империи'!", 10, true);
                                }
                            ),
                        };

                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(63, Character.ChaRole.Enemy),
                            new BattleSession(64, Character.ChaRole.Enemy),
                        };
                        Battles.MakeRandomBattle(hero, battleList, battleScenarioEvents);
                    },
                    true
                ),
                #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Тета";
            locInfo[1] = Descriptions(((byte)LocationName.SectorTeta), Descript);

            maps[2].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[2].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.7))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(60, Character.ChaRole.Enemy),
                    new BattleSession(61, Character.ChaRole.Enemy),
                    new BattleSession(62, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(60, Character.ChaRole.Enemy),
                                new BattleSession(61, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.GeliotopolCityToTeta;
                        SectorTeta(hero);
                        break;
                }
            }
        }

        //Сектор Кси
        public static void SectorCsi(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.05,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                        {
                            new BattleScenarioEvent
                            (
                                (hero, EnemyList, turn) => turn == 0,
                                (hero, EnemyList) =>
                                {
                                    Output.TwriteLine("\n- Что ты тут вынюхиваешь, а шнырь?", 10, true);
                                    Output.TwriteLine("\n*Молчание*", 10, true);

                                    Console.WriteLine("\nВаши действия?\n"
                                                    + "1) Напасть\n"
                                                    + "2) Уйти\n");

                                    switch (Input.ChoisInput(hero, 1, 2))
                                    {
                                        case 1:
                                            break;
                                        case 2:
                                            Output.TwriteLine("\n*Вы уходите из сектора*", 10, true);
                                            Battles.ClearBattlePlace(hero, EnemyList);

                                            hero.HeroCoordinates = transit.CsiToTeta;
                                            SectorTeta(hero);
                                            break;
                                    }                                    
                                }
                            ),
                        };

                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(66, Character.ChaRole.Enemy),
                            new BattleSession(67, Character.ChaRole.Enemy),
                        };
                        Battles.MakeRandomBattle(hero, battleList, battleScenarioEvents);
                    },
                    true
                ),
                #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Кси";
            locInfo[1] = Descriptions(((byte)LocationName.SectorCsi), Descript);

            maps[3].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[3].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(66, Character.ChaRole.Enemy),
                    new BattleSession(67, Character.ChaRole.Enemy),
                    new BattleSession(68, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(68, Character.ChaRole.Enemy),
                                new BattleSession(68, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.HladnyPrimeCityToCsi;
                        SectorCsi(hero);
                        break;
                }
            }
        }

        //Сектор Омикрон
        public static void SectorOmicron(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Битв
                new LocationScenarioEvent
                (
                    0.05,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 8), (2, 8), (3, 8), (4, 8), (5, 8), (6, 8), (7, 8), (8, 8), (9, 8), (10, 8), (11, 8), (12, 8), (13, 8), (14, 8), (15, 8), (16, 8), (17, 8),
                                (1, 10), (2, 10), (3, 10), (4, 10), (5, 10), (6, 10), (7, 10), (8, 10), (9, 10), (10, 10), (11, 10), (12, 10), (13, 10), (14, 10), (15, 10), (16, 10), (17, 10),
                                (1, 12), (2, 12), (3, 12), (4, 12), (5, 12), (6, 12), (7, 12), (8, 12), (9, 12), (10, 12), (11, 12), (12, 12), (13, 12), (14, 12), (15, 12), (16, 12), (17, 12),
                                (1, 14), (2, 14), (3, 14), (4, 14), (5, 14), (6, 14), (7, 14), (8, 14), (9, 14), (10, 14), (11, 14), (12, 14), (13, 14), (14, 14), (15, 14), (16, 14), (17, 14),
                                (1, 16), (2, 16), (3, 16), (4, 16), (5, 16), (6, 16), (7, 16), (8, 16), (9, 16), (10, 16), (11, 16), (12, 16), (13, 16), (14, 16), (15, 16), (16, 16), (17, 16),
                                (1, 18), (2, 18), (3, 18), (4, 18), (5, 18), (6, 18), (7, 18), (8, 18), (9, 18), (10, 18), (11, 18), (12, 18), (13, 18), (14, 18), (15, 18), (16, 18), (17, 18)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(60, Character.ChaRole.Enemy),
                            new BattleSession(61, Character.ChaRole.Enemy),
                            new BattleSession(62, Character.ChaRole.Enemy),
                            new BattleSession(63, Character.ChaRole.Enemy),
                            new BattleSession(64, Character.ChaRole.Enemy),
                            new BattleSession(65, Character.ChaRole.Enemy),
                            new BattleSession(66, Character.ChaRole.Enemy),
                            new BattleSession(67, Character.ChaRole.Enemy),
                            new BattleSession(68, Character.ChaRole.Enemy),
                        };
                        Battles.MakeRandomBattle(hero, battleList);
                    },
                    true
                ),
                #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Омикрон";
            locInfo[1] = Descriptions(((byte)LocationName.SectorOmicron), Descript);

            maps[4].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[4].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.9))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(60, Character.ChaRole.Enemy),
                    new BattleSession(61, Character.ChaRole.Enemy),
                    new BattleSession(62, Character.ChaRole.Enemy),
                    new BattleSession(63, Character.ChaRole.Enemy),
                    new BattleSession(64, Character.ChaRole.Enemy),
                    new BattleSession(65, Character.ChaRole.Enemy),
                    new BattleSession(66, Character.ChaRole.Enemy),
                    new BattleSession(67, Character.ChaRole.Enemy),
                    new BattleSession(68, Character.ChaRole.Enemy),

                };
                Battles.MakeRandomBattle(hero, battleList);
            }

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(1, Character.ChaRole.Enemy),
                                new BattleSession(1, Character.ChaRole.Enemy),
                                new BattleSession(1, Character.ChaRole.Enemy),
                                new BattleSession(1, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.CosmolitToOmicron;
                        SectorOmicron(hero);
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
                        hero.HeroCoordinates = transit.DarkGranulationToOmicron;
                        SectorOmicron(hero);
                        break;
                }
            }
        }

        //Сектор Пи
        public static void SectorPi(Hero hero)
        {
            //Нет событий (мирный город)

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Пи";
            locInfo[1] = Descriptions(((byte)LocationName.SectorPi), Descript);

            maps[5].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo);

            while (true)
                maps[5].Transition(hero, (playerX, playerY), locInfo);

            if (GameFormulas.Vero(0.4))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(3, Character.ChaRole.Enemy),
                };
                Battles.MakeCurrentBattle(hero, battleList);
            }

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.VladichiaOrbitaCityToPi;
                        SectorPi(hero);
                        break;
                }
            }
        }

        //Сектор Хи
        public static void SectorHi(Hero hero)
        {
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.05,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                        {
                            new BattleScenarioEvent
                            (
                                (hero, EnemyList, turn) => turn == 0,
                                (hero, EnemyList) =>
                                {
                                    Output.TwriteLine("\n- Что ты тут вынюхиваешь, а шнырь?", 10, true);
                                    Output.TwriteLine("\n*Молчание*", 10, true);

                                    Console.WriteLine("\nВаши действия?\n"
                                                    + "1) Напасть\n"
                                                    + "2) Уйти\n");

                                    switch (Input.ChoisInput(hero, 1, 2))
                                    {
                                        case 1:
                                            break;
                                        case 2:
                                            Output.TwriteLine("\n*Вы уходите из сектора*", 10, true);
                                            Battles.ClearBattlePlace(hero, EnemyList);

                                            hero.HeroCoordinates = transit.CsiToTeta;
                                            SectorTeta(hero);
                                            break;
                                    }
                                }
                            ),
                        };

                        List<BattleSession> battleList = new List<BattleSession>()
                        {
                            new BattleSession(66, Character.ChaRole.Enemy),
                            new BattleSession(67, Character.ChaRole.Enemy),
                            new BattleSession(68, Character.ChaRole.Enemy),
                        };
                        Battles.MakeRandomBattle(hero, battleList, battleScenarioEvents);
                    },
                    true
                ),
                #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Хи";
            locInfo[1] = Descriptions(((byte)LocationName.SectorHi), Descript);

            maps[6].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[6].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.8))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(66, Character.ChaRole.Enemy),
                    new BattleSession(67, Character.ChaRole.Enemy),
                    new BattleSession(68, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

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
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(66, Character.ChaRole.Enemy),
                                new BattleSession(67, Character.ChaRole.Enemy),
                                new BattleSession(68, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.OldIaregaCityToHi;
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
                            {
                                List<BattleSession> battleList = new List<BattleSession>()
                                {
                                    new BattleSession(1, Character.ChaRole.Wild),
                                    new BattleSession(3, Character.ChaRole.Enemy),
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
                                new BattleSession(66, Character.ChaRole.Enemy),
                                new BattleSession(67, Character.ChaRole.Enemy),
                                new BattleSession(68, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList);
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
            List<LocationScenarioEvent> scenario = new List<LocationScenarioEvent>
            {
                #region События на карте

                #region Область Вольных войск
                new LocationScenarioEvent
                (
                    0.1,
                    (hero, turn) =>
                    {
                        var conditions = new List<bool>
                        {
                            GameFormulas.CurrentCoordinates
                            (
                                (1, 2), (2, 2), (3, 2), (4, 2), (5, 2), (6, 2), (7, 2), (8, 2), (9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2), (17, 2),
                                (1, 3), (2, 3), (3, 3), (4, 3), (5, 3), (6, 3), (7, 3), (8, 3), (9, 3), (10, 3), (11, 3), (12, 3), (13, 3), (14, 3), (15, 3), (16, 3), (17, 3),
                                (1, 4), (2, 4), (3, 4), (4, 4), (5, 4), (6, 4), (7, 4), (8, 4), (9, 4), (10, 4), (11, 4), (12, 4), (13, 4), (14, 4), (15, 4), (16, 4), (17, 4),
                                (1, 5), (2, 5), (3, 5), (4, 5), (5, 5), (6, 5), (7, 5), (8, 5), (9, 5), (10, 5), (11, 5), (12, 5), (13, 5), (14, 5), (15, 5), (16, 5), (17, 5),
                                (1, 6), (2, 6), (3, 6), (4, 6), (5, 6), (6, 6), (7, 6), (8, 6), (9, 6), (10, 6), (11, 6), (12, 6), (13, 6), (14, 6), (15, 6), (16, 6), (17, 6),
                                (1, 7), (2, 7), (3, 7), (4, 7), (5, 7), (6, 7), (7, 7), (8, 7), (9, 7), (10, 7), (11, 7), (12, 7), (13, 7), (14, 7), (15, 7), (16, 7), (17, 7)
                            ),
                        };
                        return conditions.Any(c => c);
                    },
                    (hero) =>
                    {
                        List<BattleScenarioEvent> battleScenarioEvents = new List<BattleScenarioEvent>
                        {
                            new BattleScenarioEvent
                            (
                                (hero, EnemyList, turn) => turn == 0,
                                (hero, EnemyList) =>
                                {
                                    Output.TwriteLine("\n- Предъявите документы!", 10, true);
                                    Output.TwriteLine("\n*У вас нет документов*", 10, true);

                                    Console.WriteLine("\nВаши действия?\n"
                                                    + "1) Напасть\n"
                                                    + "2) Уйти\n");
                                                    //+ "3) Показать документы\n");

                                    switch (Input.ChoisInput(hero, 1, 2))
                                    {
                                        case 1:
                                            Output.TwriteLine("\n- Шпион 'Империи'!", 10, true);
                                            break;
                                        case 2:
                                            Output.TwriteLine("\n*Вы уходите из сектора*", 10, true);
                                            Battles.ClearBattlePlace(hero, EnemyList);

                                            hero.HeroCoordinates = transit.CsiToTeta;
                                            SectorTeta(hero);
                                            break;
                                        case 3:
                                            Output.TwriteLine("\n- Всего доброго", 10, true);

                                            CanPass = true;
                                            break;
                                    }
                                }
                            ),
                        };

                        if (!CanPass)
                        {
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(66, Character.ChaRole.Enemy),
                                new BattleSession(67, Character.ChaRole.Enemy),
                            };
                            Battles.MakeRandomBattle(hero, battleList, battleScenarioEvents);
                        }
                        CanPass = false;
                    },
                    true
                ),
                #endregion
                #endregion
            };

            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Пси";
            locInfo[1] = Descriptions(((byte)LocationName.SectorPsi), Descript);

            maps[7].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo, scenario);

            while (true)
                maps[7].Transition(hero, (playerX, playerY), locInfo, scenario);

            if (GameFormulas.Vero(0.8))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(63, Character.ChaRole.Enemy),
                    new BattleSession(64, Character.ChaRole.Enemy),
                    new BattleSession(65, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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
                        hero.HeroCoordinates = transit.CvantogradToPsi;
                        SectorPsi(hero);
                        break;
                }
            }
        }

        //Сектор Омега
        public static void SectorOmega(Hero hero)
        {
            string[] locInfo = new string[2];

            locInfo[0] = "Сектор Омега";
            locInfo[1] = Descriptions(((byte)LocationName.SectorOmega), Descript);

            maps[8].Transition(hero, SpawnPoints, hero.HeroCoordinates, locInfo);

            while (true)
                maps[8].Transition(hero, (playerX, playerY), locInfo);

            if (GameFormulas.Vero(0.6))
            {
                List<BattleSession> battleList = new List<BattleSession>()
                {
                    new BattleSession(63, Character.ChaRole.Enemy),
                    new BattleSession(64, Character.ChaRole.Enemy),
                    new BattleSession(65, Character.ChaRole.Enemy),
                };
                Battles.MakeRandomBattle(hero, battleList);
            }

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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(1, Character.ChaRole.Wild),
                                new BattleSession(1, Character.ChaRole.Wild),
                                new BattleSession(7, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
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

                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(1, Character.ChaRole.Wild),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        hero.HeroCoordinates = transit.GreenVectorVillageToOmega;
                        SectorOmega(hero);
                        break;
                }
            }
        }

        #endregion
    }
}
