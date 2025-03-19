using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using static FightCons.Character;

namespace FightCons
{
    public class UnitSkills
    {
        public SkillsDele UnitSkill { get; set; }

        #region Магия
        //  Magic_slow!!!
        public static void SlowerSpell(Character attacker, Character victim)
        {
            sbyte spellPower = 5;

            short damage = GameFormulas.MagicDamage(attacker, victim, spellPower);
            victim.Condition.Moves++;
            victim.Condition.SlowRound += 3;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Blue, "", $"замедляет ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, "и сносит ", $"{damage} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damage} ", $"{Output.HPSymbol}\n");

            victim.HP -= damage;
            attacker.Statistic.Spells++;
            attacker.Turn += 2;
        }

        //  Ускорение
        public static void FasterSpell(Character person)
        {
            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkYellow, "", $"Ускоряет ", "себя!\n");
            person.Statistic.Spells++;
            person.Turn += 2;
        }

        //  Заморозка
        public static void FreesSpell(Character attacker, Character victim)
        {
            sbyte spellPower = 5;

            short damage = GameFormulas.MagicDamage(attacker, victim, spellPower);
            victim.Condition.FreesRound += 2;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", $"Замораживает ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Yellow, $"на {victim.Condition.FreesRound} хода и сносит ", $"{damage} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damage} ", $"{Output.HPSymbol}\n");

            victim.HP -= damage;
            attacker.Statistic.Spells++;
            attacker.Turn += 2;
        }

        //  Магический щит
        public static void MagicShieldSpell(Character person)
        {
            person.Condition.MagicDefense = 2.0f;

            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", "Щит \n");
            person.Statistic.Spells++;
            person.Turn += 2;
        }

        public static void ReviveSpell(Character reviver, Character riser)
        {
            Output.NameAndId(reviver, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", "воскрешает ");
            Output.NameAndId(riser);
            Console.WriteLine();

            riser.HP = GameFormulas.GetCurrentPercent(riser.MaxHp, 10);
            riser.Condition.IsAlive = true;
            riser.CantRunBattle = false;

            reviver.Statistic.Spells++;
            reviver.Turn += 4;
        }

        public static void SpawnSpell(Character person, Hero hero, List<Order> units)
        {
            //Random random = new Random();

            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.DarkBlue, "", "призывает ");

            List<Order> NewEnemyList = new List<Order>()
            {
                new Order(1, ChaRole.Wild),
                new Order(1, ChaRole.Wild),
                new Order(1, ChaRole.Wild),

            };

            //var NewOne = Battles.AddNewUnit(hero, units, 1, 1, 1);
            var NewOne = Battles.AddNewUnit(hero, units, NewEnemyList);

            foreach (var o in NewOne)
            {
                Output.NameAndId(o.character);
                Console.Write(", ");

            }
            Console.WriteLine();

            person.Statistic.Spells++;
            person.Turn += 4;
        }

        public static void AdSpamSpellAsync(Character person)
        {
            // change to messageMas
            
            string[] Dialogs =
            {
                "Реклама",
                "Текст рекламы",
            };

            Output.NameAndId(person, true);
            Output.WriteColorLine(ConsoleColor.Yellow, "", "спамит ", "рекламой!\n");

            PipeMessage.MultiAdSpellAsync(Dialogs, 3);

            person.Statistic.Spells++;
            person.Turn += 2;
        }

        #endregion

        #region Атаки
        //  Действие Атака 
        public static void EnemyHits(Character attacker, Character victim)
        {
            attacker.Turn += 1;

            short damage = GameFormulas.Damage(attacker, victim, false);
            attacker.Statistic.Attacks++;

            BattleLog(attacker, victim, damage);
        }

        //  Отравляющая атака
        public static void PoisingAtt(Character attacker, Character victim)
        {
            short damage = (short)(GameFormulas.Damage(attacker, victim) / 2);

            victim.Condition.PoisingRound = 3;

            Output.NameAndId(attacker, true);
            Console.Write("накладывает на ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.DarkGreen, "", $"отравление ");
            Output.WriteColorLine(ConsoleColor.Yellow, "сносит ", $"{damage} ", "урона! У ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damage} ", $"{Output.HPSymbol}\n");

            victim.HP -= damage;
            attacker.Statistic.Attacks++;
            attacker.Turn += 1;
        }

        //  Вампиризм
        public static void Vampirisms(Character attacker, Character victim)
        {
            short damage = (short)(GameFormulas.Damage(attacker, victim) / 2);

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkRed, "использует ", $"вампиризм ");
            Output.WriteColorLine(ConsoleColor.Red, "и поглощает ", $"{damage} ", $"{Output.HPSymbol}! ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damage} ", $"{Output.HPSymbol}\n");

            attacker.HP += damage;
            victim.HP -= damage;
            attacker.Statistic.Attacks++;
            attacker.Turn += 1;
        }

        //  Defense!!!
        public static void HoldTheShield(Character person)
        {
            person.Condition.ShieldUp = true;
            Output.NameAndId(person, true);
            Console.Write("держит оборону\n");
            person.Turn += 5;
        }
        #endregion

        //  Log
        internal static void BattleLog(Character attacker, Character victim, short damage)
        {
            Output.NameAndId(attacker, true);
            Console.Write("сносит ");
            Output.NameAndId(victim);

            if (damage > attacker.TotalAttack)
                Output.WriteColorLine(ConsoleColor.Yellow, "критические ", $"{damage} ", "урона! У ");
            else
                Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damage} ", "урона у ");

            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.TotalHP - damage} ", $"{Output.HPSymbol}\n");
            Sound.HIT();

            victim.HP -= damage;
        }
    }
}
