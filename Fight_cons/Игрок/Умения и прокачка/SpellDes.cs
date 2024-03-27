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
        public sbyte SpellСost { get; set; }
        public sbyte SpellPower { get; set; }

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
        public static void CleansingRaySpell(Hero hero, Charecter victim, short cost, sbyte spellPower)
        {
            Random rand = new Random();

            short damag = GameFormulas.MagicDamage(hero, victim, spellPower);

            if (rand.NextDouble() <= 1 - victim.TotalSpeed)
            {
                Output.NameAndId(hero, true);

                if (damag > hero.TotalArcane + spellPower)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием критические ", $"{damag} ", "урона! У");
                else
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием ", $"{damag} ", "урона у ");

                Output.NameAndId(victim);
                Output.WriteColorLine(ConsoleColor.Red, "", $"{victim.HP - damag} ", $"{Output.HPSymbol}\n");                
                victim.HP -= damag;

                hero.Statistic.Spells++;
            }
            else
            {
                Output.NameAndId(victim, true);
                Console.Write(" уворачивается\n");
            }
        }

        //  Малое лечение
        public static void HealSpell(Hero hero, Charecter enemy, short cost, sbyte spellPower)
        {
            float crit = GameFormulas.CheckCrit(hero, true);
            float Heal = (float)((hero.MaxHp / 100.0 * 30.0) + crit);

            if (crit > 1)
                Output.WriteColorLine(ConsoleColor.Green, "\nВы критически восстановили себе ", $"+{(int)Heal} ", $"{Output.HPSymbol}\n");
            else
                Output.WriteColorLine(ConsoleColor.Green, "\nВы восстановили себе ", $"+{(int)Heal} ", $"{Output.HPSymbol}\n");

            hero.HP += (short) Heal;

            hero.Statistic.Spells++;
        }

        //  Замедление
        public static void SlowDownSpell(Hero hero, Charecter enemy, short cost, sbyte spellPower)
        {
            enemy.Condition.Speed = -0.2f;
            Console.WriteLine("Вы замедлили противника!");

            hero.Statistic.Spells++;
        }

        //  Исцеление
        public static void ExcisionSpell(Hero hero, Charecter enemy, short cost, sbyte spellPower)
        {
            Console.WriteLine("\nВы избавились от всех негатив. эффектов\n");
            hero.Condition.Clear();

            hero.Statistic.Spells++;
        }
        #endregion
    }
}
