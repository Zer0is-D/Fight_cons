using System;
using System.Collections.Generic;
using System.Threading;

namespace FightCons.Enemies
{
    public class Unit : Character
    {
        public static int ExpForKill(int HP, short Attack) => (HP / 2) + (Attack / 2);

        public Unit(Bestiaries bestiaries, ChaRole role)
        {
            Random rand = new Random();

            Role = role;
            //Role = bestiaries.Role;
            Phase = bestiaries.Phase;
            Name = bestiaries.Name;

            //TODO решить судьбу метода
            //if (Role == ChaRole.Wild)
            //    MaxHp = (bestiaries.HpMax == 0) ?
            //        (short)(bestiaries.HpMin * rand.Next(2, 5)) : (short)(rand.Next(bestiaries.HpMin, bestiaries.HpMax) * rand.Next(2, 5));
            //else
                MaxHp = (bestiaries.HpMax == 0) ?
                    bestiaries.HpMin : (short)rand.Next(bestiaries.HpMin, bestiaries.HpMax);

            if (bestiaries.HpMax == 0)
            {
                HP = bestiaries.HpMin;

                Attack = bestiaries.AttMin;

                Speed = bestiaries.SpdMin * 0.01f;

                Crit = bestiaries.CrtMin * 0.01f;

                Defense = bestiaries.DefMin * 0.01f;

                MagicDefense = bestiaries.MDefMin * 0.01f;

                Block = bestiaries.BlkMin * 0.01f;

                Moves = bestiaries.MovMin;
            }
            else
            {
                HP = (short)rand.Next(bestiaries.HpMin, bestiaries.HpMax);

                Attack = (short)rand.Next(bestiaries.AttMin, bestiaries.AttMax);

                Speed = (float)(rand.Next(bestiaries.SpdMin, bestiaries.SpdMax) * 0.01);

                Crit = (float)(rand.Next(bestiaries.CrtMin, bestiaries.CrtMax) * 0.01);

                Defense = (float)(rand.Next(bestiaries.DefMin, bestiaries.DefMax) * 0.01);

                MagicDefense = (float)(rand.Next(bestiaries.MDefMin, bestiaries.MDefMax) * 0.01);

                Block = (float)(rand.Next(bestiaries.BlkMin, bestiaries.BlkMax) * 0.01);

                Moves = (sbyte)rand.Next(bestiaries.MovMin, bestiaries.MovMax);
            }

            CantRunBattle = bestiaries.CantRunBattle;

            Strategy = bestiaries.Strategy;

            KillExp = ExpForKill(HP, Attack);
        }

        //  Решения противника
        public static void UnitFightChoice(Character unit, Hero hero, List<BattleSession> units, List<BattleScenarioEvent> scenario = null)
        {
            Thread.Sleep(50);
            BattleScenarioEvent.CheckBattleScenarios(hero, units, scenario);

            //  Минус от эффектов
            NegativeEffectImpact(unit);

            if (unit.TotalHP > 0 & !unit.Condition.LeavedBattle & !hero.Condition.LeavedBattle)
            {
                hero.Turn = 0;

                unit.Condition.ShieldUp = false;

                PersonStrategy.UnitAction(unit, hero, units);                
            }
            else if (unit.TotalHP <= 0)
            {
                unit.Condition.Clear();
                unit.Condition.IsAlive = false;
            }                
        }

        //  Вычитание негативные эффекты
        public static void NegativeEffectImpact(Character unit)
        {
            if (unit.Condition.Moves > 0 || unit.Condition.PoisingRound > 0 || unit.Condition.BleedRound > 0)
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
                if (unit.Condition.PoisingRound > 0)
                {
                    unit.Condition.PoisingRound--;
                    unit.HP -= unit.Condition.PoisingDmg;
                }
            }
        }
    }
    //  Убрать позже
    //public class UnitList
    //{
    //    public sbyte UnitID { get; set; }
    //    public ChaRole ChaRole { get; set; }

    //    public UnitList(sbyte unitID, ChaRole chaRole)
    //    {
    //        UnitID = unitID;
    //        ChaRole = chaRole;
    //    }
    //}
}
