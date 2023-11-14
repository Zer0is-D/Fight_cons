using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class AttackDes
    {
        public SkillsDele Attack { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //  Для формул
        private const sbyte FullArmor = 1;
        private const double ArmorFine = 1.5;

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

        //  Раздел НАПАДЕНИЕ
        //  Действие: Атака
        public static void BaseAttack(Charecter attacker, Charecter victim)
        {            
            double crit = CheckCrit(attacker);
            double attack = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int) CheckDefence(victim, attack);

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;

            UnitSkills.BattleLog(attacker, victim, crit, damag);
        }

        //  Действие: Пробитие брони
        public static void BreachArmorAttack(Charecter attacker, Charecter victim)
        {            
            double attack = attacker.TotalAttack / ArmorFine;

            //  Пробитие брони
            int damag = (int) attack;

            Unit.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Yellow, "наносит ", $"{damag} ", "урона у ");
            Unit.NameAndId(victim);
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.HP - damag} ", "HP\n");

            victim.HP -= damag;

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;
        }

        //  Действие: Кровотечение
        public static void Act_Bleed(Charecter attacker, Charecter victim)
        {
            double crit = CheckCrit(attacker);
            double att = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int) (CheckDefence(victim, att) / 2.00);
            victim.Conditions.BleedRound = 3;

            Output.WriteColorLine(ConsoleColor.Green, "\n", $"{attacker.Name} ", "накладывает ");
            Output.WriteColorLine(ConsoleColor.DarkRed, "", $"Кровотечение ");
            Output.WriteColorLine(ConsoleColor.Yellow, "и наносит ", $"{damag} ", "урона ");
            Output.WriteColorLine(ConsoleColor.DarkMagenta, $"у [{victim.Id}] ", $"{victim.Name} ");
            Output.WriteColorLine(ConsoleColor.Red, $"[{victim.Id}] ", $"{victim.HP - damag} ", "HP\n");

            victim.HP -= damag;

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;
        }

        //  Действие: Парирование
        public static void Act_Parry(Charecter attacker, Charecter victim)
        {
            attacker.Conditions.AttackParry = true;
            attacker.Turn = attacker.TotalMaxMoves;
        }

        //  Действие: Атака из-за парирования
        public static void Act_Parry_atc(Charecter attacker, Charecter victim)
        {
            double crit = CheckCrit(attacker);
            double attack = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int)CheckDefence(victim, attack);


            Output.WriteColorLine(ConsoleColor.Green, "\n", $"{attacker.Name} ", $"парирует атаку ");
            //  Если крит
            if (crit > 1)
            {                
                Output.WriteColorLine(ConsoleColor.DarkMagenta, $" [{victim.Id}] ", $"{victim.Name} ", "и наносит критические ");
                Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damag} ", "урона!\n У ");
            }
            //  Урон без крита
            else
            {
                Output.WriteColorLine(ConsoleColor.DarkMagenta, $"[{victim.Id}] ", $"{victim.Name} ", "и наносит ");
                Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damag} ", "урона у ");
            }
            Output.WriteColorLine(ConsoleColor.DarkMagenta, $"[{victim.Id}] ", $"{victim.Name} ");
            Output.WriteColorLine(ConsoleColor.Red, $"[{victim.Id}] ", $"{victim.HP - damag} ", "HP\n");
            victim.HP -= damag;

            if (attacker is Hero n)
                n.HeroStatistic.Attacks++;
        }
        //  Конец раздела


        //  Проверки
        //  Проверка на крит
        protected static double CheckCrit(Charecter cha)
        {
            Random rand = new Random();
            double crit = 0;

            if (rand.NextDouble() <= cha.TotalCrit)
                crit = cha.TotalAttack * (rand.Next(15, 20) * 0.1);

            return crit;
        }

        //  Проверка на защиту и блок
        public static double CheckDefence(Charecter charecter, double att)
        {
            if (charecter.Conditions.Prot_up)
                att = att * (FullArmor - charecter.TotalBlock) + (FullArmor - charecter.TotalDefence);
            else
                att = att * (FullArmor - charecter.TotalDefence);

            return att;
        }
    }
}
