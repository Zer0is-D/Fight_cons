using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fight_cons
{
    public partial class Hero : Charecter
    {
        public string Class_name = "???";

        //  Здоровье
        internal new protected int MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }
        public new int HP
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

        #region Левл и опыт
        private protected int _nextLvlExp = 10;

        private protected int _lvl = 1;
        internal protected int Lvl
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
        //  Информация о противниках
        public bool EnemyAbout = false;

        //  Боевые навыки героя
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

        //  Зелья героя
        private protected List<PotionDes> _heroPotions = new List<PotionDes>();
        internal protected List<PotionDes> PotionList
        { 
            get => _heroPotions; 
            set => _heroPotions = value;
        }

        #endregion

        internal List<ItemChar> HeroInventory = new List<ItemChar>();

        #region Второстепенные свойства и поля
        //  Квесты
        public Quests HeroQuests = new Quests();

        //  Внимательность/шпионаж
        public Spying HeroSpying = new Spying();

        //  Статистика
        internal Statistic HeroStatistic = new Statistic();

        //  Опьянение
        public byte drunk = 0;
        public byte Max_drunk = 3;

        //  Выход со стартовой позиции
        public static bool Exit_cave;
        #endregion

        //  Конструктор героя
        public Hero(int hp, int mp) 
        {
            MaxHp = hp;
            HP = hp;
            MaxMp = mp;
            MP = mp;
            Attack = 1;
            Speed = 0.2;
            Crit = 0.05;
            Block = 0.10;
            MaxMoves = 3;
            isPlayer = true;
        }
    }
}
