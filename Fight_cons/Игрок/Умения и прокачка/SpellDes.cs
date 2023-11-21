using Fight_cons.Основа_и_настройки;
using System;
using System.Linq;

namespace Fight_cons
{
    public class SpellDes
    {
        public SpellDele Spell { get; set; }

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

        #region Заклинания
        //  Действие: Очищающий луч
        public static void CleansingRaySpell(Hero hero, Charecter victim, int cost, int spellPower)
        {
            Random rand = new Random();

            int damag = Formulas.MagicDamage(hero, victim, spellPower);

            if (rand.NextDouble() <= 1 - victim.TotalSpeed)
            {
                Output.NameAndId(hero, true);

                if (damag > hero.TotalArcane + spellPower)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием критические ", $"{damag} ", "урона! У");
                else
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием ", $"{damag} ", "урона у ");

                Output.NameAndId(victim);
                Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.HP - damag} ", $"{Output.HPStr}\n");                
                victim.HP -= damag;

                hero.HeroStatistic.Spells++;
            }
            else
            {
                Output.NameAndId(victim, true);
                Console.Write(" уворачивается");
            }
        }

        //  Малое лечение
        public static void HealSpell(Hero hero, Charecter enemy, int cost, int power)
        {
            double crit = Formulas.CheckCrit(hero, true);
            double Heal = ((hero.MaxHp / 100.0) * 30.0) + crit;

            if (crit > 1)
                Output.WriteColorLine(ConsoleColor.Green, "\nВы критически восстановили себе ", $"+{(int)Heal} ", $"{Output.HPStr}\n");
            else
                Output.WriteColorLine(ConsoleColor.Green, "\nВы восстановили себе ", $"+{(int)Heal} ", $"{Output.HPStr}\n");

            hero.HP += (int)Heal;

            hero.HeroStatistic.Spells++;
        }

        //  Замедление
        public static void SlowDownSpell(Hero hero, Charecter enemy, int cost, int power)
        {
            enemy.Conditions.Speed = -0.2;
            Console.WriteLine("Вы замедлили противника!");

            hero.HeroStatistic.Spells++;
        }

        //  Исцеление
        public static void ExcisionSpell(Hero hero, Charecter enemy, int cost, int power)
        {
            Console.WriteLine("\nВы избавились от всех негатив. эффектов\n");
            hero.Conditions.Clear();

            hero.HeroStatistic.Spells++;
        }
        #endregion
    }
}
