using Fight_cons.Основа_и_настройки;
using System;

namespace Fight_cons
{
    internal class Condition : Characteristics
    {
        //  Состояния
        public bool AttackParry = false;
        public bool SheeldUp = false;        

        //  Debuffs
        internal protected int FrezRound;
        internal protected int SlowRound;
        internal protected int PoisentRound;
        internal protected int BleedRound;

        //  Базовый урон от эффектов
        internal protected int PoisentDmg = 3;
        public static int BleedDmg = 3;

        internal protected void Clear()
        {
            //  Обнуление полей
            HP = 0;
            MP = 0;
            Attack = 0;
            Arcane = 0;
            Speed = 0;
            Crit = 0;
            Defence = 0;
            MagicDefence = 0;
            Block = 0;
            MaxMoves = 0;

            //  Обнуление ходов
            FrezRound = 0;
            SlowRound = 0;
            PoisentRound = 0;
            BleedRound = 0;
        }

        //  Обнуление любого объекта
        internal protected static void Clear(object x) => x = 0;

        internal protected void RandomDebuff(Charecter attacker, Charecter victim)
        {
            if (GameFormulas.Vero(0.7))
                AttackDes.Act_Parry_atc(attacker, victim);
            else
            {
                Output.WriteColorLine(ConsoleColor.DarkMagenta, "\n", $"{victim.Name} ", "пропускает ход\n");
                victim.Turn = victim.TotalMaxMoves;
                if (attacker is Hero hero)
                    hero.HeroStatistic.Attacks++;
            }
        }
    }
}
