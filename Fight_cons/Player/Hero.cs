using FightCons.CoreNSettings;
using FightCons.Player.SkillsNLvl;
using System;
using System.Collections.Generic;

namespace FightCons
{
    public partial class Hero : Character
    {
        public string ClassName = "???";
        //TODO что это???
        public byte Sneak = 0;

        //  Здоровье
        //TODO точно ли нужно это?
        internal new protected short MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }
        public new short HP
        {
            get => _hp;
            set
            {
                if (value > MaxHp)
                    _hp = MaxHp;
                if (value >= 1 && value <= MaxHp)
                    _hp = value;
            }
        }

        //TODO пересмотреть
        #region Левл и опыт
        internal protected int NextLvlExp = 10;

        private protected sbyte _lvl = 1;
        internal protected sbyte Lvl
        {
            get => _lvl;
            set
            {
                if (value >= 1)
                    _lvl = value;
                else
                    Console.Write("Неправильное значение уровня");
            }
        }

        private protected int _exp = 0;
        internal protected int Exp
        {
            get => _exp;
            set
            {
                if (value >= -0)
                    _exp = value;
                else
                    Console.Write("Неправильное значение опыта");
            }
        }
        #endregion

        //  Деньги
        private protected int _money;
        internal protected int Money
        {
            get => _money;
            set
            {
                if (value >= 0)
                    _money = value;
            }
        }

        #region Умения героя

        //  Боевые навыки героя
        /*
        private protected List<AttackDes> _heroSkills = new List<AttackDes>();
        internal protected List<AttackDes> AttackList
        { 
            get => _heroSkills; 
            set => _heroSkills = value; 
        }

        //  Заклинания героя
        private protected List<SpellDes> _heroSpells = new List<SpellDes>();
        internal protected List<SpellDes> SpellList
        { 
            get => _heroSpells; 
            set => _heroSpells = value; 
        }

        //  Особые боевые навыки героя
        private protected List<SpecialDes> _heroSpecials = new List<SpecialDes>();
        internal protected List<SpecialDes> SpecialList
        {
            get => _heroSpecials;
            set => _heroSpecials = value;
        }

        //  Зелья героя
        private protected List<PotionDes> _heroPotions = new List<PotionDes>();
        internal protected List<PotionDes> PotionList
        { 
            get => _heroPotions; 
            set => _heroPotions = value;
        }
        */
        #endregion

        internal CharacterClasses CharacterClass = new CharacterClasses("No class", 0);

        #region Второстепенные свойства и поля
        //  Квесты
        public Quests HeroQuests = new Quests();

        //TODO подумать о том чтобы скрестить с квестами
        //  Внимательность/шпионаж
        public Spying HeroSpying = new Spying();

        public Map.transit HeroCoordinates { get; set; }

        //TODO Вообще переместить
        //  Опьянение
        public byte DrunkCondition = 0;
        public byte OverDrunk = 3;
        #endregion

        //  Конструктор героя
        public Hero(short hp, short mp) 
        {
            MaxHp = hp;
            HP = hp;
            MaxMp = mp;
            MP = mp;
            Attack = 1;
            Speed = 0.2f;
            Crit = 0.05f;
            Block = 0.10f;
            Moves = 2;
            IsPlayer = true;
            Condition.IsAlive = true;
            //Role = ChaRole.Hero;
        }
    }
}
