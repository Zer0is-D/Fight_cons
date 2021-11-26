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
        /// <summary>
        /// Тут находяться главные поля
        /// </summary>

        //  Левл и опыт
        public int exp_n_lvl = 10;
        protected int LVL = 1;      
        public int lvl
        {
            get
            {
                return LVL;
            }
            set
            {
                if(value >= 1)
                    LVL = value;
                else
                    Console.Write("Неправильное значение уровня");
            }
        }

        protected int EXP = 0;
        public int exp
        {
            get
            {
                return EXP;
            }
            set
            {
                if (value >= -0)
                    EXP = value;
                else
                    Console.Write("Неправильное значение опыта");
            }
        }

        //  Здоровья
        public int MAX_HP = 25;
        protected int HP = 25;
        public int hp
        {
            get
            {
                return HP;
            }
            set
            {
                if (value > MAX_HP)
                    hp = MAX_HP;
                if (value >= 1 && value <= MAX_HP)    
                    HP = value;
                if (value <= 0)
                    Death();
            }
        }

        //  Мана
        public int MAX_MP = 10;
        protected int MP = 10;
        public int mp
        {
            get
            {
                return MP;
            }
            set
            {
                if (value > MAX_MP)
                    mp = MAX_MP;
                if (value >= 0 && value <= MAX_MP)
                    MP = value;
                if (value < 0)
                    MP = 0;
            }
        }

        //  Деньги
        protected int Money;
        public int money
        {
            get
            {
                return Money;
            }
            set
            {
                if (value >= 0)
                    Money = value;
            }
        }

        //  Боевые навыки героя
        private List<Attack_des> SKILLS = new List<Attack_des>();
        public List<Attack_des> Attacks_list { get => SKILLS; set => SKILLS = value; }

        //  Заклинания героя
        private List<Spell_des> SPELLS = new List<Spell_des>();
        public List<Spell_des> Spell_list { get => SPELLS; set => SPELLS = value; }

        //  Зелья героя
        private List<Potion_des> POTIONS = new List<Potion_des>();
        public List<Potion_des> Potion_list { get => POTIONS; set => POTIONS = value; }       

        //  Броня
        public Armor armor = new Armor("Без брони", 0, 0);
        public double defence { get => Defence + armor.Defenc + (buffs.Defence - debuffs.Defence); }

        //  Оружие
        public Weapon weapon = new Weapon(name: "Кулаки", attack: 1, speed: 0.2, cost: 0, crit: 0.2, block: 0.05, move: 3);

        public int attack { get => Attack + weapon.Attack + (int) (buffs.Attack - debuffs.Attack); }
        public double crit { get => Crit + weapon.Crit + (buffs.Crit - debuffs.Crit); }       
        public double speed { get => Speed + weapon.Speed + (buffs.Speed - debuffs.Speed); }
        public double block { get => Block + weapon.Block + (buffs.Block - debuffs.Block); }
        public sbyte max_moves { get => (sbyte) (Max_moves + weapon.Move); }

        public int arcane { get => Arcane + (int) (buffs.Arcane - debuffs.Arcane); }            
    }
}
