using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public delegate void Skills_dele(Hero hero, Enemy enemy);

    public abstract class Charecter
    {
        //  Свойства
        public string Name;
        public string Class_name = "???";

        //  Атака
        protected int ATTACK = 1;
        public int Attack
        {
            get
            {
                return ATTACK;
            }
            set
            {
                ATTACK = value;
            }
        }

        //  Сила магии
        protected int ARCANE = 0;
        public int Arcane
        {
            get
            {
                return ARCANE;
            }
            set
            {
                ARCANE = value;
            }
        }

        //  Скорость
        protected double SPEED = 0.3;
        public double Speed
        {
            get
            {
                return SPEED;
            }
            set
            {
                SPEED = value;
            }
        }

        //  Шанс крита
        protected double CRIT = 0.1;
        public double Crit
        {
            get
            {
                return CRIT;
            }
            set
            {
                if (value < 1)
                    CRIT = value; 
            }
        }

        //  Физическая защита
        protected double DEFENCE = 0;
        public double Defence
        {
            get
            {
                return DEFENCE;
            }
            set
            {
                if (value <= 0)
                    DEFENCE = 0;
                if (value <= 1)
                    DEFENCE = value;
            }
        }

        //  Магическая защита
        protected double MAGIC_DEFENCE = 0;
        public double Magic_defence
        {
            get
            {
                return MAGIC_DEFENCE;
            }
            set
            {
                if (value <= 0)
                    MAGIC_DEFENCE = 0;
                if (value <= 1)
                    MAGIC_DEFENCE = value;
            }
        }

        //  Шанс блока
        protected double BLOCK = 0.10;
        public double Block
        {
            get
            {
                return BLOCK;
            }
            set
            {
                if (value <= 0)
                    BLOCK = 0;
                if (value <= 1)
                    BLOCK = value;
            }
        }

        //  Макс. ходов
        public sbyte Max_moves = 4;

        //  Выбор
        protected sbyte CHOICE;
        public sbyte Choice
        {
            get
            {
                return CHOICE;
            }
            set
            {
                CHOICE = value;
            }
        }

        //  Сбежать с боя
        public bool RUN = false;

        //  Ходы
        public sbyte Turn = 1;

        //  Баффы и дебаффы
        public Buffs buffs = new Buffs();
        public Debuffs debuffs = new Debuffs();

        //  Бонусы
        public Passive_bonus passive = new Passive_bonus();
        public Class_lvl_bonus class_Lvl_b = new Class_lvl_bonus();
    }
}
