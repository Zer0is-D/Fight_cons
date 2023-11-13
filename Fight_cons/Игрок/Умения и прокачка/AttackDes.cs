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
        public Skills_dele Attack { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public AttackDes(Hero hero, string name)
        {
            Name = name;
            AttackDes rep = hero.AttackList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (rep == null)
            {
                hero.AttackList.Add(this);
                ID = hero.AttackList.Count;
            }
            else
            {
                int index = hero.AttackList.IndexOf(rep);
                this.ID = rep.ID;
                hero.AttackList[index] = this;
            }
        }        

        //  Раздел НАПАДЕНИЕ
        //  Действие: Атака
        public static void Act_Attac(Charecter attacker, Charecter victim)
        {            
            double crit = Crit_chek(attacker);
            double att = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int) Defence_chek(victim, att);

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;

            UnitSkills.Battle_log(attacker, victim, crit, damag);
        }

        //  Действие: Пробитие брони
        public static void Act_breach_armor(Charecter attacker, Charecter victim)
        {            
            double att = attacker.TotalAttack / 1.5;

            //  Пробитие брони
            int damag = (int) att;

            Output.WriteColorLine(ConsoleColor.Green, "\n", $"{attacker.Name} ", "наносит ");
            Output.WriteColorLine(ConsoleColor.Yellow, "", $"{damag} ", "урона ");
            Output.WriteColorLine(ConsoleColor.DarkMagenta, $"у [{victim.Id}] ", $"{victim.Name} ");
            Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.HP - damag} ", "HP\n");

            victim.HP -= damag;

            if (attacker is Hero hero)
                hero.HeroStatistic.Attacks++;
        }

        //  Действие: Кровотечение
        public static void Act_Bleed(Charecter attacker, Charecter victim)
        {
            double crit = Crit_chek(attacker);
            double att = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int) (Defence_chek(victim, att) / 2.00);
            victim.Conditions.Bleed_round = 3;

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
            attacker.Conditions.Parry = true;
            attacker.Turn = attacker.TotalMaxMoves;
        }

        //  Действие: Атака из-за парирования
        public static void Act_Parry_atc(Charecter attacker, Charecter victim)
        {
            double crit = Crit_chek(attacker);
            double att = attacker.TotalAttack + crit;

            //  Урон по врагу с защитой
            int damag = (int) att;

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
        protected static double Crit_chek(Charecter cha)
        {
            Random rand = new Random();
            Thread.Sleep(200);
            double crit = 0;

            if (rand.NextDouble() <= cha.TotalCrit)
                crit = cha.TotalAttack * (rand.Next(15, 20) * 0.1);
            return crit;
        }

        //  Проверка на защиту и блок
        public static double Defence_chek(Charecter charecter, double att)
        {
            //  Если у противника блок то, иначе ...
            if (charecter.Conditions.Prot_up)
                att = att * (1 - charecter.TotalBlock) + (1 - charecter.TotalDefence);
            else
                att = att * (1 - charecter.TotalDefence);
            return att;
        }
    }
}
