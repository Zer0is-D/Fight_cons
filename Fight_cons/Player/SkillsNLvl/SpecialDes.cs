using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FightCons.Player.SkillsNLvl
{
    public class SpecialDes
    {
        internal SpecialDele Specials { get; set; }

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        internal SpecialDeleParty SpecialsParty { get; set; }
        internal int ID { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }

        //  Проверка на дубликат
        public SpecialDes(Hero hero, string name)
        {
            Name = name;
            SpecialDes repeat = hero.SpecialList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (repeat == null)
            {
                hero.SpecialList.Add(this);
                ID = hero.SpecialList.Count;
            }
            else
            {
                int index = hero.SpecialList.IndexOf(repeat);
                this.ID = repeat.ID;
                hero.SpecialList[index] = this;
            }
        }

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public SpecialDes(Character character, string name)
        {
            Name = name;
            SpecialDes repeat = character.SpecialList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (repeat == null)
            {
                character.SpecialList.Add(this);
                ID = character.SpecialList.Count;
            }
            else
            {
                int index = character.SpecialList.IndexOf(repeat);
                this.ID = repeat.ID;
                character.SpecialList[index] = this;
            }
        }

        //  Действие: базовая Атака
        public static void SpecialBranch(Character attacker, Character victim)
        {
            //  Пробитие брони
            //short damage = GameFormulas.Damage(attacker, victim, true);

            Output.NameAndId(attacker, true);
            Output.WriteColorLine(ConsoleColor.Yellow, "", $"разносит ", "броню у ");
            Output.NameAndId(victim);

            victim.Defense = 0;
            victim.CharacterArmor.Defense = 0;
            victim.CharacterWeapon.Defense = 0;

            attacker.Statistic.Attacks++;
            attacker.Statistic.ChaActions.Add(31);
        }
    }
}
