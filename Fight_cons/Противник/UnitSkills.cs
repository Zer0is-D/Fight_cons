using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;

namespace Fight_cons
{
    public class UnitSkills
    {
        public SkillsDele UnitSkill { get; set; }

        #region Магия
        //  Magic_slow!!!
        public static void SlowerSpell(Charecter attacker, Charecter victim)
        {
            sbyte spellPower = 5;

            short damag = GameFormulas.MagicDamage(attacker, victim, spellPower);
            victim.Condition.Moves++;
            victim.Condition.SlowRound = 3;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Blue, "", $"замедляет ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, "и сносит ", $"{damag} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", $"{Output.HPSymbol}\n");

            victim.HP -= damag;
            attacker.Statistic.Spells++;
            attacker.Turn += 2;
        }

        //  Ускорение
        public static void FasterSpell(Charecter person)
        {
            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkYellow, "", $"Ускоряет ", "себя!\n");
            person.Statistic.Spells++;
            person.Turn += 2;
        }

        //  Заморозка
        public static void FrezSpell(Charecter attacker, Charecter victim)
        {
            sbyte spellPower = 5;

            short damag = GameFormulas.MagicDamage(attacker, victim, spellPower);
            victim.Condition.FrezRound = 2;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", $"Замораживает ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, $"на {victim.Condition.FrezRound} хода и сносит ", $"{damag} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", $"{Output.HPSymbol}\n");

            victim.HP -= damag;
            attacker.Statistic.Spells++;
            attacker.Turn += 2;
        }

        //  Магический щит
        public static void MagicSheeldSpell(Charecter person)
        {
            person.Condition.MagicDefence = 2.0f;

            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", "Щит \n");
            person.Statistic.Spells++;
            person.Turn += 2;
        }

        public static void RevievSpell(Charecter reviever, Charecter riser)
        {
            Output.NameAndId(reviever, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", "воскрешает ");
            Output.NameAndId(riser);
            Console.WriteLine();

            riser.HP = GameFormulas.GetCurrentPercent(riser.MaxHp, 10);
            riser.Condition.IsAlive = true;
            riser.CharecterProfile.TooBrave = false;

            reviever.Statistic.Spells++;
            reviever.Turn += 4;
        }

        public static void SpawnSpell(Charecter person, Hero hero, List<Order> units)
        {
            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", "призывает ");
            var NewOne = Battles.AddNewUnit(hero, units, 3, 3, 3);

            foreach (var o in NewOne)
            {
                Output.NameAndId(o.charecter);
                Console.Write(", ");

            }
            Console.WriteLine();

            person.Statistic.Spells++;
            person.Turn += 4;
        }

        #endregion

        #region Атаки
        //  Действие Атака 
        public static void EnemyHits(Charecter attacker, Charecter victim)
        {
            attacker.Turn += 1;

            short damag = GameFormulas.Damage(attacker, victim, false, true);
            attacker.Statistic.Attacks++;

            BattleLog(attacker, victim, damag);
        }

        //  Отравляющая атака
        public static void PoisentAtt(Charecter attacker, Charecter victim)
        {
            short damag = (short)(GameFormulas.Damage(attacker, victim) / 2);

            victim.Condition.PoisentRound = 3;

            Output.NameAndId(attacker, true);
            Console.Write("накладывает на ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.DarkGreen, " ", $"отравление ");
            Output.WriteColorLine(ConsoleColor.Yellow, "сносит ", $"{damag} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", $"{Output.HPSymbol}\n");

            victim.HP -= damag;
            attacker.Statistic.Attacks++;
            attacker.Turn += 1;
        }

        //  Вамперизм
        public static void Vamperism(Charecter attacker, Charecter victim)
        {
            short damag = (short)(GameFormulas.Damage(attacker, victim) / 2);

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkRed, "использует ", $"вампиризм ");
            Output.WriteColorLine(ConsoleColor.Red, "и поглощает ", $"{damag} ", $"{Output.HPSymbol}! ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", $"{Output.HPSymbol}\n");

            attacker.HP += damag;
            victim.HP -= damag;
            attacker.Statistic.Attacks++;
            attacker.Turn += 1;
        }

        //  Defence!!!
        public static void HoldTheSheeld(Charecter person)
        {
            person.Condition.SheeldUp = true;
            Output.NameAndId(person, true);
            Console.Write("держит оборону\n");
            person.Turn += 5;
        }
        #endregion

        //  Log
        internal static void BattleLog(Charecter attacker, Charecter victim, short damag)
        {
            Output.NameAndId(attacker, true);
            Console.Write("сносит ");
            Output.NameAndId(victim);

            if (damag > attacker.TotalAttack)
                Output.WriteColorLine(ConsoleColor.Yellow, "критические ", $"{damag} ", "урона! У ");
            else
                Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damag} ", "урона у ");

            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damag} ", $"{Output.HPSymbol}\n");
            Sound.HIT();

            victim.HP -= damag;
        }
    }
}
