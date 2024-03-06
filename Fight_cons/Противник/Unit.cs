using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;

namespace Fight_cons.Противник
{
    public class Unit : Charecter
    {
        public static int ExpForKill(int HP, short Attack) => (HP / 2) + (Attack / 2);

        public Unit(Bestiaria bestiaria)
        {
            Random rand = new Random();

            switch (bestiaria.Role)
            {
                case ChaRole.Enemy:
                    IsEnemy = true;
                    break;
                case ChaRole.Ally:
                    IsEnemy = false;
                    break;
            }

            Role = bestiaria.Role;
            Phase = bestiaria.Phase;
            Name = bestiaria.Name;

            if (Role == ChaRole.Wild)
                MaxHp = (bestiaria.HpMax == 0) ?
                    (short)(bestiaria.HpMin * rand.Next(2, 5)) : (short)(rand.Next(bestiaria.HpMin, bestiaria.HpMax) * rand.Next(2, 5));
            else
                MaxHp = (bestiaria.HpMax == 0) ?
                    bestiaria.HpMin : (short)rand.Next(bestiaria.HpMin, bestiaria.HpMax);

            HP = (bestiaria.HpMax == 0) ?
                 bestiaria.HpMin : (short)rand.Next(bestiaria.HpMin, bestiaria.HpMax);

            Attack = (bestiaria.HpMax == 0) ?
                 bestiaria.AttMin : (short)rand.Next(bestiaria.AttMin, bestiaria.AttMax);

            Speed = (bestiaria.HpMax == 0) ?
                bestiaria.SpdMin : (float)(rand.Next(bestiaria.SpdMin, bestiaria.SpdMax) * 0.01);

            Crit = (bestiaria.HpMax == 0) ?
                (float)(bestiaria.CrtMin * 0.01) : (float)(rand.Next(bestiaria.CrtMin, bestiaria.CrtMax) * 0.01);

            Defence = (bestiaria.HpMax == 0) ?
                (float)(bestiaria.DefMin * 0.01) : (float)(rand.Next(bestiaria.DefMin, bestiaria.DefMax) * 0.01);

            MagicDefence = (bestiaria.HpMax == 0) ?
                (float)(bestiaria.MDefMin * 0.01) : (float)(rand.Next(bestiaria.MDefMin, bestiaria.MDefMax) * 0.01);

            Block = (bestiaria.HpMax == 0) ?
                (float)(bestiaria.BlkMin * 0.01) : (float)(rand.Next(bestiaria.BlkMin, bestiaria.BlkMax) * 0.01);

            Moves = (bestiaria.HpMax == 0) ?
                bestiaria.MovMin : (sbyte)rand.Next(bestiaria.MovMin, bestiaria.MovMax);

            Strategy = bestiaria.Strategy;

            KillExp = ExpForKill(HP, Attack);
        }

        //  Решения противника
        public static void UnitFightChoice(Charecter unit, Hero hero, List<Order> units)
        {
            //  Минус от эффектов
            NegativeEffectImpact(unit);

            if (unit.TotalHP > 0 & !unit.Run & !hero.Run)
            {
                hero.Turn = 0;

                unit.Conditions.SheeldUp = false;

                switch (unit.Strategy)
                {
                    //  Любая базовая стратегия поведения
                    case Strategeis.Any:
                        if (GameFormulas.Vero(0.5))
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
        public static void NegativeEffectImpact(Charecter unit)
        {
            if (unit.Conditions.Moves > 0 || unit.Conditions.PoisentRound > 0 || unit.Conditions.BleedRound > 0)
            {
                //  Кровотечение
                if (unit.Conditions.BleedRound > 0)
                {
                    Output.NameAndId(unit, false);
                    Output.WriteColorLine(ConsoleColor.DarkRed, $"получает -{Condition.BleedDmg} HP от ", "кровотечение\n");
                    unit.Conditions.BleedRound--;
                    unit.HP -= Condition.BleedDmg;
                }

                //  Замедление
                if (unit.Conditions.Moves > 0)
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
