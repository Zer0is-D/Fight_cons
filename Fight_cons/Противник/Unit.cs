using System;
using System.Collections.Generic;

namespace Fight_cons.Противник
{
    internal class Unit : Charecter
    {
        public static int ExpForKill(int HP, int Attack) => (HP / 2) + (Attack / 2);


        internal Unit(string name, sbyte phase, int hp,
                 int attack, int speed, int crit_chance,
                 int defence, int magic_defence, int block,
                 sbyte max_moves, bool no_run, int strategy = 0)
        {
            Phase = phase;

            Name = name;
            HP = MaxHp = hp;

            Attack = attack;
            Speed = speed;
            Crit = crit_chance * 0.01;
            Defence = defence * 0.01;
            MagicDefence = magic_defence * 0.01;
            Block = block * 0.01;
            MaxMoves = max_moves;
            No_run = no_run;
        }

        //  Конструктор мин-макс
        public Unit(string name, sbyte phase,
            int HP_min, int HP_max,
            int ATT_min, int ATT_max,
            int SPD_min, int SPD_max,
            int CRIT_min, int CRIT_max,
            int DEF_min, int DEF_max,
            int M_DEF_min, int M_DEF_max,
            int BLK_min, int BLK_max,
            sbyte max_turn_min, sbyte max_turn_max,
            int strategy, bool wild = false)
        {
            Random rand = new Random();
            Wild = wild;
            Phase = phase;
            Name = name;

            if (Wild)
                MaxHp = rand.Next(HP_min, HP_max) * rand.Next(2, 5);
            else
                MaxHp = rand.Next(HP_min, HP_max);
            HP = rand.Next(HP_min, MaxHp);
            Attack = rand.Next(ATT_min, ATT_max);
            Speed = rand.Next(SPD_min, SPD_max) * 0.01;
            Crit = rand.Next(CRIT_min, CRIT_max) * 0.01;
            Defence = rand.Next(DEF_min, DEF_max) * 0.01;
            MagicDefence = rand.Next(M_DEF_min, M_DEF_max) * 0.01;
            Block = rand.Next(BLK_min, BLK_max) * 0.01;
            MaxMoves = rand.Next(max_turn_min, max_turn_max);
            strategeis = (Strategeis)strategy;
        }
        //  Решения противника
        public static void Unit_fight_choice(Charecter unit, Hero hero, List<Order> units)
        {
            //  Минус от эффектов
            Negative_effect_impact(unit);

            if (unit.TotalHP > 0 & !unit.Run & !hero.Run)
            {
                hero.Turn = 0;

                unit.Conditions.SheeldUp = false;

                switch (unit.strategeis)
                {
                    //  Любая базовая стратегия поведения
                    case Strategeis.Any:
                        if (Battles.Vero(0.5))
                            PersonStrategy.StrgATC(unit, hero, units);
                        else
                            PersonStrategy.StrgMAG(unit, hero, units);
                        break;

                    //  Атакующй стратегия
                    case Strategeis.Agresive:
                        PersonStrategy.StrgATC(unit, hero, units);
                        break;

                    //  Стратегия волшебника
                    case Strategeis.Mage:
                        PersonStrategy.StrgMAG(unit, hero, units);
                        break;

                    //  Стратегия некроманта
                    case Strategeis.Necromancer:
                        PersonStrategy.StrgNECRO(unit, hero, units);
                        break;

                    //  Стратегия хилера
                    case Strategeis.Healer:
                        ///
                        break;
                }
            }
            else if (unit.TotalHP <= 0)
                unit.IsAlive = false;
        }

        //  Вычитание негативыне эффекты
        public static void Negative_effect_impact(Charecter unit)
        {
            if (unit.Conditions.MaxMoves > 0 || unit.Conditions.PoisentRound > 0 || unit.Conditions.BleedRound > 0)
            {
                //  Кровотечение
                if (unit.Conditions.BleedRound > 0)
                {
                    Output.NameAndId(unit, false);
                    Output.WriteColorLine(ConsoleColor.DarkRed, $"получает -{unit.Conditions.BleedDmg} HP от ", "кровотечение\n");
                    unit.Conditions.BleedRound--;
                    unit.HP -= unit.Conditions.BleedDmg;
                }

                //  Замедление
                if (unit.Conditions.MaxMoves > 0)
                    unit.Conditions.SlowRound--;

                //  Отравление
                if (unit.Conditions.PoisentRound > 0)
                {
                    unit.Conditions.PoisentRound--;
                    unit.HP -= unit.Conditions.PoisentDmg;
                }
            }
        }
    }
}
