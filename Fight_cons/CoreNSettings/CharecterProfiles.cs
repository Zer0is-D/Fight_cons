using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightCons.CoreNSettings
{
    public class CharacterProfiles
    {
        public bool IsPlayer;

        internal protected sbyte? Phase;

        public enum ChaRole
        {
            Hero = 0,
            Ally = 1,
            Enemy = 2,
            Wild = 3
        }
        public ChaRole Role;

        internal protected bool TooBrave;

        internal protected bool Wild;

        public enum Strategies
        {
            Any = 0,
            Aggressive = 1,
            Mage = 2,
            Necromancer = 3,
            Healer = 4,
            BeastMaster = 5
        }
        public Strategies Strategy = new Strategies();
    }
}
