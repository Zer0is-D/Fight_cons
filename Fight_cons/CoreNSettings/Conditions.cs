using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;

namespace FightCons
{
    internal class Conditions : Characteristics
    {
        public bool IsAlive = true;

        //  Состояния
        public bool AttackParry = false;
        public bool ShieldUp = false;

        //  Сбежать с боя
        public bool LeavedBattle = false;

        //  Debuffs
        internal protected sbyte FreesRound;
        internal protected sbyte SlowRound;
        internal protected sbyte PoisingRound;
        internal protected sbyte BleedRound;

        //  Базовый урон от эффектов
        internal protected sbyte PoisingDmg = 3;
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
            Defense = 0;
            MagicDefense = 0;
            Block = 0;
            Moves = 0;

            //  Обнуление ходов
            FreesRound = 0;
            SlowRound = 0;
            PoisingRound = 0;
            BleedRound = 0;
        }

        //  Обнуление любого объекта
        internal protected static void Clear(object x) => x = 0;

        internal protected void RandomDebuff(Character attacker, Character victim)
        {
            if (GameFormulas.Vero(0.7))
                AttackDes.ActParryAtt(attacker, victim);
            else
            {
                Output.WriteColorLine(ConsoleColor.DarkMagenta, "\n", $"{attacker.Name} ", "пропускает ход\n");
                attacker.Turn = attacker.TotalMaxMoves;
                victim.Statistic.Attacks++;
            }
        }
    }
}
    