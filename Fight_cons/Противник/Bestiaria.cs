using System.Collections.Generic;
using System.Linq;
using static Fight_cons.Основа_и_настройки.CharecterProfiles;

namespace Fight_cons
{
    public class Bestiaria : Charecter
    {
        public static List<Bestiaria> BestiariaList = new List<Bestiaria>();
        public static List<Bestiaria> NewBestiariaList = new List<Bestiaria>();
        public static void AddNewBestiarias(Bestiaria bestiaria) => NewBestiariaList.Add(bestiaria);

        public short
            HpMin, HpMax,
            AttMin, AttMax;

        public sbyte
            SpdMin, SpdMax,
            CrtMin, CrtMax,
            DefMin, DefMax,
            MDefMin, MDefMax,
            BlkMin, BlkMax,
            MovMin, MovMax;

        public Bestiaria(string name, sbyte phase, short hp, short attack, sbyte speed, sbyte critChance, sbyte defence, sbyte magicDefence, sbyte block, sbyte moves, bool noRun, ChaRole role, Strategeis strategy = 0)
        {
            Name = name;
            CharecterProfile.Phase = phase;
            CharecterProfile.Role = role;

            HpMin = hp;
            AttMin = attack;
            SpdMin = speed;
            CrtMin = critChance;
            DefMin = defence;
            MDefMin = magicDefence;
            BlkMin = block;
            MovMin = moves;

            CharecterProfile.TooBrave = noRun;

            CharecterProfile.Strategy = strategy;
        }

        public Bestiaria(string name, sbyte phase, short hpMin, short hpMax, short attMin, short attMax, sbyte spdMin, sbyte spdMax, 
            sbyte critMin, sbyte critMax, sbyte defMin, sbyte defMax, sbyte mDefMin, sbyte mDefMax, sbyte blkMin, sbyte blkMax, sbyte movMin, sbyte movMax,
            Strategeis strategy, ChaRole role)
        {
            Name = name;
            CharecterProfile.Phase = phase;
            CharecterProfile.Role = role;

            HpMin = hpMin; HpMax = hpMax;
            AttMin = attMin; AttMax = attMax;

            SpdMin = spdMin; SpdMax = spdMax;
            CrtMin = critMin; CrtMax = critMax;
            DefMin = defMin; DefMax = defMax;
            MDefMin = mDefMin; MDefMax = mDefMax;
            BlkMin = blkMin; BlkMax = blkMax;
            MovMin = movMin; MovMax = movMax;

            CharecterProfile.Strategy = strategy;
        }
        
        //  Создание листа противников если он пустой
        public static void CreateBasicBestiaria()
        {
            List<Bestiaria> bestiarias = new List<Bestiaria>
            {
                //  Пещерные противники
                /*0*/
                new Bestiaria("Нечто Неизведанное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, role: ChaRole.Enemy, strategy: Strategeis.Any) { Id = 0 },
                /*1*/
                new Bestiaria("Нечто Бронированное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 40, critMin: 5, critMax: 10, defMin: 20, defMax: 70, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, role: ChaRole.Enemy, strategy: Strategeis.Any) { Id = 1 },
                /*2*/
                new Bestiaria("Нечто Магическое", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 45, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, role: ChaRole.Enemy, strategy: Strategeis.Any) { Id = 2 },

                //  Противники в долине
                /*3*/
                new Bestiaria("Зверь", phase: 0, hpMin: 10, hpMax: 20, attMin: 1, attMax: 5, spdMin: 30, spdMax: 30, critMin: 1, critMax: 2, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 20, blkMax: 40, movMin: 1, movMax: 2, role: ChaRole.Wild, strategy: Strategeis.Agresive) { Id = 3 },

                //  Противники в лесу
                /*4*/
                new Bestiaria("Демон", phase: 0, hpMin: 15, hpMax: 30, attMin: 3, attMax: 5, spdMin: 30, spdMax: 30, critMin: 10, critMax: 15, defMin: 0, defMax: 0, mDefMin: 20, mDefMax: 30, blkMin: 1, blkMax: 5, movMin: 2, movMax: 5, role: ChaRole.Enemy, strategy: Strategeis.Any) { Id = 4 },

                //  Противники в деревне
                /*5*/
                new Bestiaria("Ворюга", phase: 0, hpMin: 10, hpMax: 15, attMin: 3, attMax: 5, spdMin: 30, spdMax: 30, critMin: 20, critMax: 30, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 20, blkMax: 40, movMin: 4, movMax: 5, role: ChaRole.Enemy, strategy: Strategeis.Agresive) { Id = 5 },
                //  Противники в деревне
                /*6*/
                new Bestiaria("Ог", phase: 4, hpMin: 40, hpMax: 60, attMin: 1, attMax: 2, spdMin: 0, spdMax: 10, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 0, blkMax: 0, movMin: 1, movMax: 2, role: ChaRole.Enemy, strategy: Strategeis.Agresive) { Id = 6 },
                /*7*/
                new Bestiaria("Таотот", phase: 3, hp: 50, attack: 3, speed: 30, critChance: 20, defence: 10, magicDefence: 30, block: 0, moves: 5, noRun: true, ChaRole.Enemy) { Id = 7 },
                /*8*/
                new Bestiaria("Камень", phase: 0, hp: 6, attack: 0, speed: 0, critChance: 0, defence: 0, magicDefence: 0, block: 0, moves: 2, noRun: true, ChaRole.Enemy) { Id = 8 },
                /*9*/
                new Bestiaria("Некромант", phase: 0, hp: 20, attack: 0, speed: 20, critChance: 0, defence: 0, magicDefence: 30, block: 0, moves: 5, noRun: true, ChaRole.Enemy, strategy: Strategeis.Necromancer) { Id = 9 },
                /*10*/
                new Bestiaria("Жертвиник", phase: 0, hp: 20, attack: 0, speed: 0, critChance: 0, defence: 0, magicDefence: 0, block: 0, moves: 2, noRun: true, ChaRole.Enemy, strategy: Strategeis.Healer) { Id = 10 },
                /*11*/
                new Bestiaria("Зверолов", phase: 0, hpMin: 10, hpMax: 25, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 1, defMax: 15, mDefMin: 10, mDefMax: 50, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, role: ChaRole.Enemy, strategy: Strategeis.BeastMaster) { Id = 11 },

                //  Союзники после 99
                /*100*/
                new Bestiaria("Доброе Неизведанное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 3, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, role: ChaRole.Ally, strategy: Strategeis.Any) { Id = 100 },
                /*101*/
                new Bestiaria("Доброе Бронированное", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 20, defMax: 70, mDefMin: 0, mDefMax: 0, blkMin: 10, blkMax: 30, movMin: 1, movMax: 2, role: ChaRole.Ally, strategy: Strategeis.Any) { Id = 101 },
                /*102*/
                new Bestiaria("Доброе Магическое", phase: 0, hpMin: 5, hpMax: 15, attMin: 1, attMax: 2, spdMin: 30, spdMax: 30, critMin: 5, critMax: 10, defMin: 0, defMax: 0, mDefMin: 30, mDefMax: 70, blkMin: 10, blkMax: 30, movMin: 2, movMax: 3, role: ChaRole.Ally, strategy: Strategeis.Any) { Id = 102 },
            };

            BestiariaList.AddRange(bestiarias);
        }       

        //  Общий список базовых и новых противников
        public static Bestiaria GetUnit(short id)
        {
            //  Добавление новых в список
            if (NewBestiariaList.Count > 0)
            {
                foreach (var b in NewBestiariaList)
                    BestiariaList.Add(b);
            }

            var unit = BestiariaList.FirstOrDefault(u => u.Id == id);

            if (unit == null)
                return null;
            else
                return unit;
        }
    }
}
