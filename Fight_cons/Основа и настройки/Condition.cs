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
        internal protected sbyte FrezRound;
        internal protected sbyte SlowRound;
        internal protected sbyte PoisentRound;
        internal protected sbyte BleedRound;

        //  Базовый урон от эффектов
        internal protected sbyte PoisentDmg = 3;
        public static sbyte BleedDmg = 3;

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
            Moves = 0;

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
