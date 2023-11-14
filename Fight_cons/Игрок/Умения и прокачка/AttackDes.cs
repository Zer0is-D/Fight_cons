using Fight_cons.Основа_и_настройки;
using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fight_cons
{
    public class AttackDes
    {
        internal SkillsDele Attack { get; set; }

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

        #region Атаки
        //  Действие: базовая Атака
        public static void BaseAttack(Charecter attacker, Charecter victim)
        {
            int damag = Formulas.Damage(attacker, victim);

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;

            UnitSkills.BattleLog(attacker, victim, damag);
        }

        //  Действие: Пробитие брони
        public static void BreachArmorAttack(Charecter attacker, Charecter victim)
        {           
            //  Пробитие брони
            int damag = Formulas.Damage(attacker, victim, true);

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Yellow, "наносит ", $"{damag} ", "урона у ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.HP - damag} ", "HP\n");

            victim.HP -= damag;

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;
        }

        //  Действие: Кровотечение
        public static void MakeBleedAttack(Charecter attacker, Charecter victim)
        {
            int damag = Formulas.Damage(attacker, victim);

            victim.Conditions.BleedRound = 3;

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.DarkRed, "накладывает ", $"Кровотечение ");
            Output.WriteColorLine(ConsoleColor.Yellow, "и наносит ", $"{damag} ", "урона у ");
            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, " ", $"{victim.HP - damag} ", "HP\n");

            victim.HP -= damag;

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;
        }

        //  Действие: Парирование
        public static void ParryAttack(Charecter person, Charecter victim)
        {
            person.Conditions.AttackParry = true;
            person.Turn = person.TotalMaxMoves;
        }

        //  Действие: Атака из-за парирования
        public static void Act_Parry_atc(Charecter attacker, Charecter victim)
        {
            int damag = Formulas.Damage(attacker, victim);

            Output.NameAndId(attacker, true);
            Console.Write("парирует атаку ");
            Output.NameAndId(victim);

            if (damag > attacker.TotalAttack)
                Output.WriteColorLine(ConsoleColor.Yellow, "и наносит критические ", $"{damag} ", "урона!\n У ");
            else
                Output.WriteColorLine(ConsoleColor.Yellow, "и наносит ", $"{damag} ", "урона у ");

            Output.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, " ", $"{victim.HP - damag} ", "HP\n");
            victim.HP -= damag;

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;
        }
        #endregion
    }
}
