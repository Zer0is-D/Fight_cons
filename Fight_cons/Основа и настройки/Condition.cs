﻿using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    internal class Condition : Characteristics
    {
        //  Состояния
        public bool Parry = false;
        public bool Prot_up = false;        

        //  Debuffs
        internal protected int Frez_round;
        internal protected int Slow_round;
        internal protected int Poisent_round;
        internal protected int Bleed_round;

        //  Базовый урон от эффектов
        internal protected int Pisent_dmg = 3;
        internal protected int Bleed_dmg = 3;

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
            Frez_round = 0;

            //  Обнуление ходов
            Frez_round = 0;
            Slow_round = 0;
            Poisent_round = 0;
            Bleed_round = 0;
        }

        //  Обнуление любого объекта
        internal protected static void Clear(object x) => x = 0;

        internal protected void Random_debuff(Charecter attacker, Charecter victim)
        {
            if (Battles.Vero(0.7))
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
