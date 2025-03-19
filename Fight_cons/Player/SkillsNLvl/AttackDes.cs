using FightCons.CoreNSettings;
using System;
using System.Linq;

namespace FightCons
{
    public class AttackDes
    {
        internal SkillsDele Attack { get; set; }
        internal SkillsDeleParty AttackParty { get; set; }

        internal int ID { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }

        //  Проверка на дубликат
        public AttackDes(Hero hero, string name)
        {
            Name = name;
            AttackDes repeat = hero.AttackList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (repeat == null)
            {
                hero.AttackList.Add(this);
                ID = hero.AttackList.Count;
            }
            else
            {
                int index = hero.AttackList.IndexOf(repeat);
                this.ID = repeat.ID;
                hero.AttackList[index] = this;
            }
        }
        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public AttackDes(Character character, string name)
        {
            Name = name;
            AttackDes repeat = character.AttackList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (repeat == null)
            {
                character.AttackList.Add(this);
                ID = character.AttackList.Count;
            }
            else
            {
                int index = character.AttackList.IndexOf(repeat);
                this.ID = repeat.ID;
                character.AttackList[index] = this;
            }
        }

        #region Атаки
        //  Действие: базовая Атака
        public static void BaseAttack(Character attacker, Character victim)
        {
            short damage = GameFormulas.Damage(attacker, victim);

            attacker.Statistic.Attacks++;
            attacker.Statistic.ChaActions.Add(10);

            UnitSkills.BattleLog(attacker, victim, damage);
        }

        //  Действие: Пробитие брони
        public static void BreachArmorAttack(Character attacker, Character victim)
        {           
            //  Пробитие брони
            short damage = GameFormulas.Damage(attacker, victim, true);

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Yellow, "пробивают броню и наносит ", $"{damage} ", "урона у ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.HP - damage} ", $"{Output.HPSymbol}\n");

            victim.HP -= damage;

            attacker.Statistic.Attacks++;
            attacker.Statistic.ChaActions.Add(11);
        }

        //  Действие: Кровотечение
        public static void MakeBleedAttack(Character attacker, Character victim)
        {
            short damage = GameFormulas.Damage(attacker, victim);

            victim.Condition.BleedRound = 3;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkRed, "накладывает ", $"Кровотечение ");
            Output.WriteColorLine(ConsoleColor.Yellow, "и наносит ", $"{damage} ", "урона у ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, " ", $"{victim.HP - damage} ", $"{Output.HPSymbol}\n");

            victim.HP -= damage;

            attacker.Statistic.Attacks++;
            attacker.Statistic.ChaActions.Add(12);
        }
        
        //  Действие: Парирование
        public static void ParryAttack(Character person, Character victim)
        {
            person.Condition.AttackParry = true;
            person.Turn = person.TotalMaxMoves;
        }

        //  Действие: Атака из-за парирования
        public static void ActParryAtt(Character attacker, Character victim)
        {
            short damage = GameFormulas.Damage(attacker, victim);

            Output.NameAndId(attacker, true);
            Console.Write("парирует атаку ");
            Output.NameAndId(victim);

            if (damage > attacker.TotalAttack)
                Output.WriteColorLine(ConsoleColor.Yellow, "и наносит критические ", $"{damage} ", "урона!\n У ");
            else
                Output.WriteColorLine(ConsoleColor.Yellow, "и наносит ", $"{damage} ", "урона у ");

            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, " ", $"{victim.HP - damage} ", $"{Output.HPSymbol}\n");
            victim.HP -= damage;

            if (attacker is Hero hero)
                hero.Statistic.Attacks++;
        }
        #endregion
    }
}
