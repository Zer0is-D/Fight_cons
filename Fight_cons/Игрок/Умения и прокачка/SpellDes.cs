using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class SpellDes
    {
        public SkillsDele Spell { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte Spell_cost { get; set; }
        public int Spell_power { get; set; }

        public SpellDes(Hero hero, string name)
        {
            Name = name;
            SpellDes rep = hero.SpellList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (rep == null)
            {
                hero.SpellList.Add(this);
                ID = hero.SpellList.Count;
            }
            else
            {
                int index = hero.SpellList.IndexOf(rep);
                this.ID = rep.ID;
                hero.SpellList[index] = this;
            }
        }       

        //  Заклинания
        //  Действие: Очищающий луч
        public static void Spell_cleansing_ray(Hero hero, Charecter victim)
        {
            if (hero.MP >= 5)
            {
                hero.MP -= 5;
                Random rand = new Random();
                double crit = Crit_chek(hero);
                double att = 10 + hero.TotalArcane + crit;

                //  Урон по врагу с магической защитой
                int damag = (int)Magic_defence_chek(victim, att);                

                if (rand.NextDouble() <= 1 - victim.TotalSpeed)
                {
                    Output.WriteColorLine(ConsoleColor.Green, "\n", $"{hero.Name} ", $"наносит ");

                    if (crit > 1)
                        Output.WriteColorLine(ConsoleColor.DarkBlue, "заклинанием критические ", $"{damag} ", "урона! У");
                    else
                        Output.WriteColorLine(ConsoleColor.DarkBlue, "заклинанием ", $"{damag} ", "урона у ");

                    Output.WriteColorLine(ConsoleColor.DarkMagenta, $"[{victim.Id}] ", $"{victim.Name} ");
                    Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.HP - damag} ", "HP\n");
                    hero.HeroStatistic.Spells++;
                    victim.HP -= damag;
                    Thread.Sleep(400);
                }
                else
                    Output.WriteColorLine(ConsoleColor.DarkMagenta, $"\n[{victim.Id}] ", $"{victim.Name}\n");
            }
            else
            {
                Output.TwriteLine("\nНедостаточно маны!\n", 1);
                CombatSolutions.Fight_choice(hero, victim);
            }
        }

        //  Малое лечение
        public static void Heal(Hero hero, Charecter enemy)
        {
            if (hero.MP >= 3)
            {
                hero.MP -= 3;
                double crit = Crit_chek(hero);
                double H = ((hero.MaxHp / 100.0) * 30.0) + crit;                            

                if (crit > 1)
                    Output.WriteColorLine(ConsoleColor.Green, "\nВы критически восстановили себе ", $"+{(int)H} ", "HP\n");
                else
                    Output.WriteColorLine(ConsoleColor.Green, "\nВы восстановили себе ", $"+{(int)H} ", "HP\n");

                hero.HP += (int)H;

                hero.HeroStatistic.Spells++;
                Thread.Sleep(400);
            }
            else
            {
                Output.TwriteLine("\nНедостаточно маны!\n", 1);
                CombatSolutions.Fight_choice(hero, enemy);
            }
        }

        //  Замедление
        public static void Slow_down(Hero hero, Charecter enemy)
        {
            if (hero.MP >= 3)
            {
                hero.MP -= 3;

                enemy.Conditions.Speed = -0.2;
                Console.WriteLine("Вы замедлили противника!");
                hero.HeroStatistic.Spells++;

                Thread.Sleep(400);
            }
            else
            {
                Output.TwriteLine("\nНедостаточно маны!\n", 1);
                CombatSolutions.Fight_choice(hero, enemy);
            }
        }

        //  Исцеление от всех дебаффов
        public static void Excision(Hero hero, Charecter enemy)
        {
            if (hero.MP >= 6)
            {
                hero.MP -= 6;
                Console.WriteLine("\nВы избавились от всех негатив. эффектов\n");
                hero.Conditions.Clear();
                hero.HeroStatistic.Spells++;

                Thread.Sleep(400);
            }
            else
            {
                Output.TwriteLine("\nНедостаточно маны!\n", 1);
                CombatSolutions.Fight_choice(hero, enemy);
            }
        }


        //  Проверки
        //  Проверка на крит
        protected static double Crit_chek(Hero hero)
        {
            Random rand = new Random();
            double crit = 0;

            if (rand.NextDouble() <= hero.TotalMagicDefence)
                crit = hero.TotalArcane * (rand.Next(15, 20) * 0.1);
            return crit;
        }

        //  Проверка на защиту и блок
        protected static double Defence_chek(Charecter enemy, double att)
        {
            //  Если у противника блок то, иначе ...
            if (enemy.Conditions.Prot_up)
                att = att * (1 - enemy.Block) + (1 - enemy.Defence);
            else
                att = att * (1 - enemy.Defence);
            return att;
        }

        //  Проверка на магическую защиту
        protected static double Magic_defence_chek(Charecter enemy, double att)
        {
            att = att * (1 - enemy.TotalMagicDefence);
            return att;
        }
    }
}
