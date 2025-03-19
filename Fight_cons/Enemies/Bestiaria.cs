using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace FightCons
{
    public class Bestiaries : Character
    {
        public static List<Bestiaries> BestiaryList = new List<Bestiaries>();
        public static List<Bestiaries> NewBestiaryList = new List<Bestiaries>();
        public static void AddNewBestiaries(Bestiaries bestiary) => NewBestiaryList.Add(bestiary);

        #region Характеристики диапазон 
        internal short HpMin { get; set; }
        internal short HpMax { get; set; }
        internal short AttMin { get; set; }
        internal short AttMax { get; set; }

        internal sbyte SpdMin { get; set; }
        internal sbyte SpdMax { get; set; }
        internal sbyte CrtMin { get; set; }
        internal sbyte CrtMax { get; set; }
        internal sbyte DefMin { get; set; }
        internal sbyte DefMax { get; set; }
        internal sbyte MDefMin { get; set; }
        internal sbyte MDefMax { get; set; }
        internal sbyte BlkMin { get; set; }
        internal sbyte BlkMax { get; set; }
        internal sbyte MovMin { get; set; }
        internal sbyte MovMax { get; set; }
        #endregion

        public Bestiaries(string name, sbyte phase, short hp, short attack, sbyte speed, sbyte critChance, sbyte defense, sbyte magicDefense, sbyte block, 
            sbyte moves, bool noRun, /*ChaRole role,*/ Strategies strategy = 0)
        {
            Name = name;
            Phase = phase;
            //Role = role;

            HpMin = hp;
            AttMin = attack;
            SpdMin = speed;
            CrtMin = critChance;
            DefMin = defense;
            MDefMin = magicDefense;
            BlkMin = block;
            MovMin = moves;

            CantRunBattle = noRun;

            Strategy = strategy;
        }

        public Bestiaries(string name, sbyte phase, short hpMin, short hpMax, short attMin, short attMax, sbyte spdMin, sbyte spdMax, 
            sbyte critMin, sbyte critMax, sbyte defMin, sbyte defMax, sbyte mDefMin, sbyte mDefMax, sbyte blkMin, sbyte blkMax, sbyte movMin, sbyte movMax,
            Strategies strategy/*, ChaRole role*/)
        {
            Name = name;
            Phase = phase;
            //Role = role;

            HpMin = hpMin; HpMax = hpMax;
            AttMin = attMin; AttMax = attMax;

            SpdMin = spdMin; SpdMax = spdMax;
            CrtMin = critMin; CrtMax = critMax;
            DefMin = defMin; DefMax = defMax;
            MDefMin = mDefMin; MDefMax = mDefMax;
            BlkMin = blkMin; BlkMax = blkMax;
            MovMin = movMin; MovMax = movMax;

            Strategy = strategy;
        }
        
        //  Создание листа противников если он пустой
        public static void CreateBasicBestiary()
        {
            List<Bestiaries> bestiaries = new List<Bestiaries>
            {
                #region Противники Общие
                //  Временный босс перехода
                /*0*/
                new Bestiaries("Таотот", phase: 3, hp: 50, attack: 3, speed: 30, critChance: 20, defense: 10, magicDefense: 30, block: 0, moves: 5, noRun: true/*, ChaRole.Enemy*/)
                { Id = 0 },
                
                /*1*/
                new Bestiaries("Дикий Зверь", phase: 0, hpMin: 10, hpMax: 20, attMin: 1, attMax: 5, spdMin: 30, spdMax: 30, critMin: 1, critMax: 2, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 20, blkMax: 40, movMin: 1, movMax: 2, /*role: ChaRole.Wild,*/ strategy: Strategies.Aggressive) 
                { Id = 1 },

                /*2*/
                new Bestiaries("Демон", phase: 0, hpMin: 15, hpMax: 30, attMin: 3, attMax: 5, spdMin: 30, spdMax: 30, critMin: 10, critMax: 15, defMin: 0, defMax: 0, mDefMin: 20, mDefMax: 30, blkMin: 1, blkMax: 5, movMin: 2, movMax: 5, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any) 
                { Id = 2 },

                /*3*/
                new Bestiaries("Ворюга", phase: 0, hpMin: 10, hpMax: 15, attMin: 3, attMax: 5, spdMin: 30, spdMax: 30, critMin: 20, critMax: 30, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 20, blkMax: 40, movMin: 4, movMax: 5, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive) 
                { Id = 3 },
                
                /*4*/
                new Bestiaries("Препятствие", phase: 0, hp: 6, attack: 0, speed: 0, critChance: 0, defense: 0, magicDefense: 0, block: 0, moves: 2, noRun: true/*, ChaRole.Enemy*/) 
                { Id = 4 },

                /*5*/
                new Bestiaries("Некромант", phase: 0, hp: 20, attack: 0, speed: 20, critChance: 0, defense: 0, magicDefense: 30, block: 0, moves: 5, noRun: true, /*ChaRole.Enemy,*/ strategy: Strategies.Necromancer)
                { Id = 5 },

                /*6*/
                new Bestiaries("Жертвенник", phase: 0, hp: 20, attack: 0, speed: 0, critChance: 0, defense: 0, magicDefense: 0, block: 0, moves: 2, noRun: true, /*ChaRole.Enemy,*/ strategy: Strategies.Healer)
                { Id = 6 },
                
                /*7*/
                new Bestiaries("Зверолов", phase: 0, hpMin: 10, hpMax: 25, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 1, defMax: 15, mDefMin: 10, mDefMax: 50, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.BeastMaster) 
                { Id = 7 },

                //TODO ВРЕМЕННАЯ МЕРА поменять как додумаем
                //  Союзники после 99
                /*100*/
                new Bestiaries("Стражник", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Ally,*/ strategy: Strategies.Any) 
                { Id = 100 },
                /*101*/
                new Bestiaries("Бронированный стражник", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 20, defMax: 70, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Ally,*/ strategy: Strategies.Any) 
                { Id = 101 },
                /*102*/
                new Bestiaries("Стражник кудесник", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Ally,*/ strategy: Strategies.Any) 
                { Id = 102 },
                #endregion

                #region Противники ИСС

                //  Пещеры
                /*10*/
                new Bestiaries("Нечто Неизведанное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any) 
                { Id = 10 },
                /*11*/
                new Bestiaries("Нечто Бронированное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 20, defMax: 70, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any) 
                { Id = 11 },
                /*12*/
                new Bestiaries("Нечто Магическое", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 90, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any) 
                { Id = 12 },

                //13-17 19
                //  13 Храмовник
                //  14 Алхимик


                // Мини-босс пещер
                /*18*/
                new Bestiaries("Ог", phase: 2, hpMin: 60, hpMax: 80, attMin: 4, attMax: 6, spdMin: 0, spdMax: 10, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 0, blkMax: 0, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive) 
                { Id = 18 },
                #endregion

                #region Противники ДЖ                
                /*20*/
                new Bestiaries("Древлянин", phase: 0, hpMin: 10, hpMax: 15, attMin: 3, attMax: 5, spdMin: 30, spdMax: 30, critMin: 20, critMax: 30, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 20, blkMax: 40, movMin: 4, movMax: 5, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive)
                { Id = 20 },

                //  21 Сильный древлянин - более мощная версия древ + побольше брони и маг брони
                new Bestiaries("Старший древлянин", phase: 0, hpMin: 20, hpMax: 40, attMin: 5, attMax: 8, spdMin: 40, spdMax: 50, critMin: 30, critMax: 40, defMin: 10, defMax: 30, mDefMin: 30, mDefMax: 40, blkMin: 20, blkMax: 40, movMin: 5, movMax: 6, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 21 },
                //  22 Алабаст
                //  23 Дерево - препятствие(доработать)

                //24-29

                #endregion

                #region Противники БТЛ                
                //  30 Стража Гигантополя - нечто
                new Bestiaries("Стража Гигантополя", phase: 0, hpMin: 15, hpMax: 30, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 30 },
                //  31 Культист - нечто
                new Bestiaries("Культист", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 31 },
                //  32 Лестная нечисть - нечто
                new Bestiaries("Лестная нечисть", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 32 },
                //  33 Крупная нечисть - бронир, но просто жирный мин брони
                new Bestiaries("Крупная нечисть", phase: 0, hpMin: 10, hpMax: 23, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 30, defMax: 50, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 33 },
     
                //34-39
                #endregion

                #region Противники ОП                
                //  40 Пираты - нечто
                new Bestiaries("Пират", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive)
                { Id = 40 },

                //  41 Пират стрелок - маг 
                new Bestiaries("Пират стрелок", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 45, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Mage)
                { Id = 41 },

                //  42 Крупный пират - бронир, но просто жирный мин брони
                new Bestiaries("Крупный пират", phase: 0, hpMin: 10, hpMax: 23, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 30, defMax: 50, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 42 },

                //  43 Коралитовый страж - много брони и маг брони
                new Bestiaries("Коралитовый страж", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 60, defMax: 80, mDefMin: 40, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive)
                { Id = 43 },

                //44-49
                #endregion

                #region Противники ПП               
                //  50 Пустынный бандит - нечто
                new Bestiaries("Пустынный бандит", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive)
                { Id = 50 },
                //  51 Бандит лучник - маг
                new Bestiaries("Бандит лучник", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 45, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Mage)
                { Id = 51 },
                //  52 Крупный бандит - бронир, но просто жирный мин брони
                new Bestiaries("Крупный бандит", phase: 0, hpMin: 15, hpMax: 30, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 7, defMin: 20, defMax: 40, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 52 },
                //  52 Зеленый - бронир, но просто жирный мин брони
                new Bestiaries("Зеленый", phase: 0, hpMin: 20, hpMax: 50, attMin: 3, attMax: 5, spdMin: 30, spdMax: 40, critMin: 5, critMax: 7, defMin: 5, defMax: 20, mDefMin: 50, mDefMax: 80, blkMin: 10, blkMax: 30, movMin: 3, movMax: 4, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 53 },

                //53-59
                #endregion

                #region Противники НД
                //  60 Имперский солдат - нечто
                new Bestiaries("Имперский солдат", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 60 },
                //  61 Имперский стрелок - маг
                new Bestiaries("Имперский стрелок", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 45, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Mage)
                { Id = 61 },
                //  62 Имперский броненосец - бронированное
                new Bestiaries("Имперский броненосец", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 20, defMax: 50, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive)
                { Id = 62 },
                //  63 Солдат ВГ - нечто
                new Bestiaries("Солдат ВГ", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 63 },
                //  64 Стрелок ВГ - маг
                new Bestiaries("Стрелок ВГ", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 45, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Mage)
                { Id = 64 },
                //  65 Крупный воин ВГ - бронир
                new Bestiaries("Крупный воин ВГ", phase: 0, hpMin: 10, hpMax: 20, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 30, defMax: 50, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive)
                { Id = 65 },
                //  66 Рыскарь наемник - нечто
                new Bestiaries("Рыскарь наемник", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Any)
                { Id = 66 },
                //  67 Рыскарь стрелок - маг
                new Bestiaries("Рыскарь стрелок", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 45, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, /*role: ChaRole.Enemy,*/ strategy: Strategies.Mage)
                { Id = 67 },
                //  68 Крепкий наемник - бронир
                new Bestiaries("Крепкий наемник", phase: 0, hpMin: 10, hpMax: 20, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 30, defMax: 50, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, /*role: ChaRole.Enemy,*/ strategy: Strategies.Aggressive)
                { Id = 68 },

                //66-69
                #endregion

                #region Противники ВБ
                //70-79

                #endregion                
                
                //  Главный босс
                /*79*/
                new Bestiaries("Покровитель", phase: 4, hp: 1000, attack: 15, speed: 30, critChance: 10, defense: 70, magicDefense: 70, block: 20, moves: 2, noRun: true/*, ChaRole.Enemy*/) 
                { Id = 79 },

                
                /*80*/
                new Bestiaries("Джобе воин", phase: 1, hp: 70, attack: 12, speed: 30, critChance: 30, defense: 50, magicDefense: 20, block: 20, moves: 3, noRun: true, strategy: Strategies.Aggressive/*, ChaRole.Enemy*/)
                { Id = 80 },
                
                //81
                new Bestiaries("Джобе лекарь", phase: 1, hp: 40, attack: 12, speed: 30, critChance: 30, defense: 50, magicDefense: 20, block: 20, moves: 3, noRun: true, strategy: Strategies.Healer)
                { Id = 81 },
                //82
                new Bestiaries("Джобе волшебник", phase: 1, hp: 40, attack: 12, speed: 30, critChance: 30, defense: 50, magicDefense: 20, block: 20, moves: 3, noRun: true, strategy: Strategies.Mage)
                { Id = 82 },
                //83
                new Bestiaries("Джобе некромант", phase: 1, hp: 50, attack: 12, speed: 30, critChance: 30, defense: 50, magicDefense: 20, block: 20, moves: 3, noRun: true, strategy: Strategies.Necromancer)
                { Id = 83 },
                //84
                new Bestiaries("Джобе укротитель зверей", phase: 1, hp: 50, attack: 12, speed: 30, critChance: 30, defense: 50, magicDefense: 20, block: 20, moves: 3, noRun: true, strategy: Strategies.BeastMaster)
                { Id = 84 },
                //85
                new Bestiaries("Джобе", phase: 1, hp: 100, attack: 12, speed: 30, critChance: 30, defense: 50, magicDefense: 20, block: 20, moves: 3, noRun: true, strategy: Strategies.Any)
                { Id = 85 },
                
            };

            BestiaryList.AddRange(bestiaries);
        }       

        //  Общий список базовых и новых противников
        public static Bestiaries GetUnit(short id)
        {
            //TODO Нужно немного переделать метод. Сделать дозагрузку базовых противников
            //  Добавление новых в список
            if (NewBestiaryList.Count > 0)
            {
                foreach (var b in NewBestiaryList)
                    BestiaryList.Add(b);
            }

            var unit = BestiaryList.FirstOrDefault(u => u.Id == id);

            if (unit == null)
            {
                Console.WriteLine("Противник не найден в файле");
                return null;
            }                
            else
                return unit;
        }
    }
}
