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

            CharecterProfile.Role = bestiaria.CharecterProfile.Role;
            CharecterProfile.Phase = bestiaria.CharecterProfile.Phase;
            Name = bestiaria.Name;

            if (CharecterProfile.Role == CharecterProfiles.ChaRole.Wild)
                MaxHp = (bestiaria.HpMax == 0) ?
                    (short)(bestiaria.HpMin * rand.Next(2, 5)) : (short)(rand.Next(bestiaria.HpMin, bestiaria.HpMax) * rand.Next(2, 5));
            else
                MaxHp = (bestiaria.HpMax == 0) ?
                    bestiaria.HpMin : (short)rand.Next(bestiaria.HpMin, bestiaria.HpMax);

            if (bestiaria.HpMax == 0)
            {
                HP = bestiaria.HpMin;

                Attack = bestiaria.AttMin;

                Speed = bestiaria.SpdMin * 0.01f;

                Crit = bestiaria.CrtMin * 0.01f;

                Defence = bestiaria.DefMin * 0.01f;

                MagicDefence = bestiaria.MDefMin * 0.01f;

                Block = bestiaria.BlkMin * 0.01f;

                Moves = bestiaria.MovMin;
            }
            else
            {
                HP = (short)rand.Next(bestiaria.HpMin, bestiaria.HpMax);

                Attack = (short)rand.Next(bestiaria.AttMin, bestiaria.AttMax);

                Speed = (float)(rand.Next(bestiaria.SpdMin, bestiaria.SpdMax) * 0.01);

                Crit = (float)(rand.Next(bestiaria.CrtMin, bestiaria.CrtMax) * 0.01);

                Defence = (float)(rand.Next(bestiaria.DefMin, bestiaria.DefMax) * 0.01);

                MagicDefence = (float)(rand.Next(bestiaria.MDefMin, bestiaria.MDefMax) * 0.01);

                Block = (float)(rand.Next(bestiaria.BlkMin, bestiaria.BlkMax) * 0.01);

                Moves = (sbyte)rand.Next(bestiaria.MovMin, bestiaria.MovMax);
            }

            CharecterProfile.Strategy = bestiaria.CharecterProfile.Strategy;

            KillExp = ExpForKill(HP, Attack);
        }

        //  Решения противника
        public static void UnitFightChoice(Charecter unit, Hero hero, List<Order> units)
        {
            //  Минус от эффектов
            NegativeEffectImpact(unit);

            if (unit.TotalHP > 0 & !unit.Condition.LeavedBattle & !hero.Condition.LeavedBattle)
            {
                hero.Turn = 0;

                unit.Condition.SheeldUp = false;

                PersonStrategy.UnitAction(unit, hero, units);                
            }
            else if (unit.TotalHP <= 0)
                unit.Condition.IsAlive = false;
        }

        //  Вычитание негативыне эффекты
        public static void NegativeEffectImpact(Charecter unit)
        {
            if (unit.Condition.Moves > 0 || unit.Condition.PoisentRound > 0 || unit.Condition.BleedRound > 0)
            {
                //  Кровотечение
                if (unit.Condition.BleedRound > 0)
                {
                    Output.NameAndId(unit, false);
                    Output.WriteColorLine(ConsoleColor.DarkRed, $"получает -{Conditions.BleedDmg} HP от ", "кровотечение\n");
                    unit.Condition.BleedRound--;
                    unit.HP -= Conditions.BleedDmg;
                }

                //  Замедление
                if (unit.Condition.Moves > 0)
                    unit.Condition.SlowRound--;

                //  Отравление
                if (unit.Condition.PoisentRound > 0)
                {
                    unit.Condition.PoisentRound--;
                    unit.HP -= unit.Condition.PoisentDmg;
                }
            }
        }
    }
}
