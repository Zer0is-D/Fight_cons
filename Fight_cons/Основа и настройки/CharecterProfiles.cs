using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons.Основа_и_настройки
{
    public class CharecterProfiles
    {
        public bool IsPlayer;

        //  Информация о противниках
        public bool EnemyAbout = false;

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

        public enum Strategeis
        {
            Any = 0,
            Agresive = 1,
            Mage = 2,
            Necromancer = 3,
            Healer = 4,
            BeastMaster = 5
        }
        public Strategeis Strategy = new Strategeis();
    }
}
