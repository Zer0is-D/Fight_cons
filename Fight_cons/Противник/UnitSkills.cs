using Fight_cons.Основа_и_настройки;
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
        public static void SlowerSpell(Charecter attacker, Charecter victim)
        {
            int spellPower = 5;

            int damag = Formulas.MagicDamage(attacker, victim, spellPower);
            victim.Conditions.MaxMoves++;
            victim.Conditions.SlowRound = 3;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Blue, "", $"замедляет ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, "и сносит ", $"{damag} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            victim.HP -= damag;
            attacker.Turn += 2;
        }

        //  Ускорение
        public static void FasterSpell(Charecter person)
        {
            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkYellow, "", $"Ускоряет ", "себя!\n");
            Thread.Sleep(100);
            person.Turn += 2;
        }

        //  Заморозка
        public static void FrezSpell(Charecter attacker, Charecter victim)
        {
            int spellPower = 5;

            int damag = Formulas.MagicDamage(attacker, victim, spellPower);
            victim.Conditions.FrezRound = 2;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", $"Замораживает ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, $"на {victim.Conditions.FrezRound} хода и сносит ", $"{damag} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            victim.HP -= damag;
            Thread.Sleep(100);
            attacker.Turn += 2;
        }

        //  Магический щит
        public static void MagicSheeldSpell(Charecter person)
        {
            person.Conditions.MagicDefence = 2.0;

            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", "Щит \n");
            Thread.Sleep(100);
            person.Turn += 2;
        }

        public static void RevievSpell(Charecter reviever, Charecter riser)
        {
            Output.NameAndId(reviever, true);
            Output.WriteColorLine(ConsoleColor.DarkYellow, "воскрешает ", $"{riser.Name}", $"!\n");
            riser.HP = Formulas.GetCurrentPercent(riser, 10);
            riser.IsAlive = true;

            Thread.Sleep(100);
            reviever.Turn += 4;
        }

        #endregion

        #region Атаки
        //  Действие Атака 
        public static void EnemyHits(Charecter attacker, Charecter victim)
        {
            attacker.Turn += 1;

            int damag = Formulas.Damage(attacker, victim, false, true);

            BattleLog(attacker, victim, damag);

            Thread.Sleep(100);
        }

        //  Отравляющая атака
        public static void Poisent_att(Charecter attacker, Charecter victim)
        {
            int damag = Formulas.Damage(attacker, victim) / 2;

            victim.Conditions.PoisentRound = 3;

            Output.NameAndId(attacker, true);
            Console.Write("накладывает на ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.DarkGreen, " ", $"отравление ");
            Output.WriteColorLine(ConsoleColor.Yellow, "сносит ", $"{damag} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            victim.HP -= damag;
            Thread.Sleep(100);
            attacker.Turn += 1;
        }

        //  Вамперизм
        public static void Vamperism(Charecter attacker, Charecter victim)
        {
            int damag = Formulas.Damage(attacker, victim) / 2;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkRed, "использует ", $"вампиризм ");
            Output.WriteColorLine(ConsoleColor.Red, "и поглощает ", $"{damag} ", "HP! ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");

            attacker.HP += damag;
            victim.HP -= damag;
            Thread.Sleep(100);
            attacker.Turn += 1;
        }

        //  Defence!!!
        public static void HoldTheSheeld(Charecter person)
        {
            person.Conditions.SheeldUp = true;
            Output.NameAndId(person, true);
            Console.Write("держит оборону\n");
            person.Turn += 5;
            Thread.Sleep(100);
        }
        #endregion

        //  Log
        internal static void BattleLog(Charecter attacker, Charecter victim, int damag)
        {
            Output.NameAndId(attacker, true);
            Console.Write("сносит ");
            Output.NameAndId(victim);

            if (damag > attacker.TotalAttack)
                Output.WriteColorLine(ConsoleColor.Yellow, "критические ", $"{damag} ", "урона! У ");
            else
                Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damag} ", "урона у ");

            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", "HP\n");
            Sound.HIT();

            victim.HP -= damag;
            Thread.Sleep(100);
        }
    }
}
