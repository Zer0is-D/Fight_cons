using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class UnitSkills
    {
        public SkillsDele Unit_skill { get; set; }

        #region Магия
        //  Magic_slow!!!
        public static void Spell_slow(Charecter attacker, Charecter victim)
        {
            double att = attacker.TotalAttack;

            int damag = (int) (att / 2.0);
            victim.Conditions.MaxMoves++;
            victim.Conditions.SlowRound = 3;

            Unit.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Blue, "", $"замедляет ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, "и сносит ", $"{damag} ", "урона! У ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            victim.HP -= damag;
            attacker.Turn += 2;
        }

        //  Ускорение
        public static void Spell_Fast(Charecter person)
        {
            Unit.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkYellow, "", $"Ускоряет ", "себя!\n");
            Thread.Sleep(100);
            person.Turn += 2;
        }

        //  Заморозка
        public static void Spell_frez(Charecter attacker, Charecter victim)
        {
            double att = attacker.TotalAttack;

            int damag = (int) (att / 2.0);
            victim.Conditions.FrezRound = 2;

            Unit.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", $"Замораживает ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, $"на {victim.Conditions.FrezRound} хода и сносит ", $"{damag} ", "урона! У ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            victim.HP -= damag;
            Thread.Sleep(100);
            attacker.Turn += 2;
        }

        //  Магический щит
        public static void Super_sheeld(Charecter person)
        {
            person.Conditions.Defence = 2.0;

            Unit.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", $"Щит \n");
            Thread.Sleep(100);
            person.Turn += 2;
        }

        public static void Spell_Alive(Charecter reviever, Charecter riser)
        {
            Unit.NameAndId(reviever, true);
            Output.WriteColorLine(ConsoleColor.DarkYellow, "воскрешает ", $"{riser.Name}", $"!\n");
            riser.HP = 10;
            riser.IsAlive = true;

            Thread.Sleep(100);
            reviever.Turn += 4;
        }

        #endregion

        //  Действие Атака 
        public static void Enemy_Hit(Charecter attacker, Charecter victim)
        {
            double crit = Crit_chek(attacker);
            double att = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int) Defence_chek(victim, att);

            //  Проверка на парирование
            if (Parry_chek(victim, attacker))
                victim.Conditions.Random_debuff(attacker, victim);
            else
                BattleLog(attacker, victim, crit, damag);

            attacker.Turn += 1;
            Thread.Sleep(100);
        }

        //  Отравляющая атака
        public static void Poisent_att(Charecter attacker, Charecter victim)
        {
            double crit = Crit_chek(attacker);
            double att = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int) (att / 2.0);

            victim.Conditions.PoisentRound = 3;

            Unit.NameAndId(attacker, true);
            Console.Write("накладывает на ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.DarkGreen, " ", $"отравление ");
            Output.WriteColorLine(ConsoleColor.Yellow, "сносит ", $"{damag} ", "урона! У ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            victim.HP -= damag;
            Thread.Sleep(100);
            attacker.Turn += 1;
        }

        //  Вамперизм
        public static void Vamperism(Charecter attacker, Charecter victim)
        {
            double crit = Crit_chek(attacker);
            double att = attacker.TotalAttack + crit;

            int damag = (int) (att / 2.0);

            Unit.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkRed, "использует ", $"вампиризм ");
            Output.WriteColorLine(ConsoleColor.Red, "и поглощает ", $"{damag} ", "HP! ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            attacker.HP += damag;
            victim.HP -= damag;
            Thread.Sleep(100);
            attacker.Turn += 1;
        }

        //  Defence!!!
        public static void HoldTheSheeld(Charecter person)
        {
            person.Conditions.Prot_up = true;
            Unit.NameAndId(person, true);
            Console.Write("держит оборону\n");
            person.Turn += 5;
            Thread.Sleep(100);
        }


        #region Проверки и логи
        //  Log
        internal static void BattleLog(Charecter attacker, Charecter victim, double crit, int damag)
        {
            Unit.NameAndId(attacker, true);
            Console.Write("сносит ");
            Unit.NameAndId(victim);

            if (crit >= 1)
                Output.WriteColorLine(ConsoleColor.Yellow, "критические ", $"{damag} ", "урона! У ");
            else
                Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damag} ", "урона у ");

            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");
            Sound.HIT();

            victim.HP -= damag;
            Thread.Sleep(100);
        }

        //  Проверка на парирование
        protected static bool Parry_chek(Charecter attacker, Charecter victim)
        {
            Random rand = new Random();
            if (victim.Conditions.AttackParry)
            {
                if (victim.TotalSpeed >= rand.NextDouble())
                    return true;
                else
                {
                    Console.WriteLine("Парирование не удалось!");
                    return false;
                }                    
            }
            else
                return false;
        }

        //  Проверка на крит
        protected static double Crit_chek(Charecter person)
        {
            Random rand = new Random();
            Thread.Sleep(100);
            double crit = 0;

            if (rand.NextDouble() <= person.TotalCrit)
                crit = person.TotalAttack * (rand.Next(15, 20) * 0.1);

            return crit;
        }

        //  Проверка на защиту и блок
        protected static double Defence_chek(Charecter victim, double att)
        {
            //  Если у противника блок то, иначе ...
            if (victim.Conditions.Prot_up)
                att = att * (1 - (victim.TotalBlock + victim.TotalDefence));
            else
                att = att * (1 - victim.TotalDefence);

            Thread.Sleep(100);
            return att;
        }
        #endregion
    }
}
