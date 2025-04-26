using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightCons
{
    public class SpellDes
    {
        public SpellDele Spell { get; set; }
        public SpellDeleParty SpellParty { get; set; }

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
        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public SpellDes(Character character, string name)
        {
            Name = name;
            SpellDes rep = character.SpellList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (rep == null)
            {
                character.SpellList.Add(this);
                ID = character.SpellList.Count;
            }
            else
            {
                int index = character.SpellList.IndexOf(rep);
                this.ID = rep.ID;
                character.SpellList[index] = this;
            }
        }

        #region Заклинания
        //  Действие: Очищающий луч
        public static void CleansingRaySpell(Hero hero, List<BattleSession> victim, short cost, sbyte spellPower)
        {
            Random rand = new Random();

            short damag = GameFormulas.MagicDamage(hero, victim[BattleSession.SelectedUnit].character, spellPower);

            if (rand.NextDouble() <= 1 - victim[BattleSession.SelectedUnit].character.TotalSpeed)
            {
                Output.NameAndId(hero, true);

                if (damag > hero.TotalArcane + spellPower)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием критические ", $"{damag} ", "урона! У");
                else
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием ", $"{damag} ", "урона у ");

                Output.NameAndId(victim[BattleSession.SelectedUnit].character);
                Output.WriteColorLine(ConsoleColor.Red, "", $"{victim[BattleSession.SelectedUnit].character.HP - damag} ", $"{Output.HPSymbol}\n");
                victim[BattleSession.SelectedUnit].character.HP -= damag;

                hero.Statistic.Spells++;
            }
            else
            {
                Output.NameAndId(victim[BattleSession.SelectedUnit].character, true);
                Console.Write("уворачивается\n");
            }
        }
        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static void CleansingRaySpell(Character character, List<BattleSession> victim, short cost, sbyte spellPower)
        {
            Random rand = new Random();

            short damag = GameFormulas.MagicDamage(character, victim[BattleSession.SelectedUnit].character, spellPower);

            if (rand.NextDouble() <= 1 - victim[BattleSession.SelectedUnit].character.TotalSpeed)
            {
                Output.NameAndId(character, true);

                if (damag > character.TotalArcane + spellPower)
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием критические ", $"{damag} ", "урона! У");
                else
                    Output.WriteColorLine(ConsoleColor.DarkBlue, "наносит заклинанием ", $"{damag} ", "урона у ");

                Output.NameAndId(victim[BattleSession.SelectedUnit].character);
                Output.WriteColorLine(ConsoleColor.Red, "", $"{victim[BattleSession.SelectedUnit].character.HP - damag} ", $"{Output.HPSymbol}\n");
                victim[BattleSession.SelectedUnit].character.HP -= damag;

                character.Statistic.Spells++;
            }
            else
            {
                Output.NameAndId(victim[BattleSession.SelectedUnit].character, true);
                Console.Write("уворачивается\n");
            }
        }
        
        //  Малое лечение
        public static void HealSpell(Character character, List<BattleSession> enemy, short cost, sbyte spellPower)
        {
            float crit = GameFormulas.CheckCrit(character, true);
            float Heal = (float)((character.MaxHp / 100.0 * 30.0) + crit);

            if (crit > 1)
                Output.WriteColorLine(ConsoleColor.Green, "\nВы критически восстановили себе ", $"+{(int)Heal} ", $"{Output.HPSymbol}\n");
            else
                Output.WriteColorLine(ConsoleColor.Green, "\nВы восстановили себе ", $"+{(int)Heal} ", $"{Output.HPSymbol}\n");

            character.HP += (short) Heal;

            character.Statistic.Spells++;
        }

        //  Замедление
        public static void SlowDownSpell(Character character, List<BattleSession> enemy, short cost, sbyte spellPower)
        {
            enemy[BattleSession.SelectedUnit].character.Condition.Speed = -0.2f;
            Console.WriteLine("Вы замедлили противника!");

            character.Statistic.Spells++;
        }

        //  Исцеление
        public static void ExcisionSpell(Character character, List<BattleSession> enemy, short cost, sbyte spellPower)
        {
            Console.WriteLine("\nВы избавились от всех негатив. эффектов\n");
            character.Condition.Clear();

            character.Statistic.Spells++;
        }
        #endregion
    }
}
