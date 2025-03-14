using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FightCons.CoreNSettings
{
    public class Characteristics
    {
        //  Место для хранения информации о характеристиках
        public List<Info> ItemList = new List<Info>();

        //  Свойства
        private string _name;
        internal string Name
        {
            get => _name;
            set => _name = value;
        }

        //  Здоровье
        private protected short _maxHp;
        public short MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        private protected short _hp;
        public short HP
        {
            get => _hp;
            set => _hp = value;
        }

        //  Мана
        private protected short _maxMp;
        public short MaxMp
        {
            get => _maxMp;
            set => _maxMp = value;
        }


        private protected int _mp;
        public int MP
        {
            get => _mp;
            set
            {
                if (value > MaxMp)
                    _mp = MaxMp;
                if (value >= 0 && value <= MaxMp)
                    _mp = value;
                if (value < 0)
                    _mp = 0;
            }
        }

        //  Атака
        private protected short _attack;
        public short Attack
        {
            get => _attack;
            set => _attack = value;
        }

        //  Сила магии
        private protected short _arcane;
        public short Arcane
        {
            get => _arcane;
            set => _arcane = value;
        }

        //  Скорость
        private protected float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        //  Шанс крита
        private protected float _crit;
        public float Crit
        {
            get => _crit;
            set
            {
                if (value < 1)
                    _crit = value;
            }
        }

        //  Физическая защита
        private protected float _defense;
        public float Defense
        {
            get => _defense;
            set
            {
                if (value <= 0)
                    _defense = 0;
                if (value <= 1)
                    _defense = value;
            }
        }

        //  Магическая защита
        private protected float _magicDefense;
        public float MagicDefense
        {
            get => _magicDefense;
            set
            {
                if (value <= 0)
                    _magicDefense = 0;
                if (value <= 1)
                    _magicDefense = value;
            }
        }

        //  Шанс блока
        private protected float _block;
        public float Block
        {
            get => _block;
            set
            {
                if (value <= 0)
                    _block = 0;
                if (value <= 1)
                    _block = value;
            }
        }

        //  Макс. ходов
        public sbyte Moves;

        //  Сведенье о характеристиках предмета
        //TODO разобраться и понять где применяется 
        public void GetItemParamFields(Characteristics cha)
        {
            //  В2
            var list = new List<Info>
            {
                new Info(cha.Attack, Output.AttackStr),
                new Info(cha.Arcane, Output.ArcaneStr),
                new Info(cha.Defense, Output.DefenceStr),
                new Info(cha.MagicDefense, Output.MagicDefenceStr),
                new Info(cha.MaxHp, Output.MaxHpStr),
                new Info(cha.MaxMp, Output.MaxMpStr),
                new Info(cha.Speed, Output.SpeedStr),
                new Info(cha.Crit, Output.CritStr),
                new Info(cha.Block, Output.BlockStr),
                new Info(cha.Moves, Output.MaxMovesStr)
            };
            ItemList.AddRange(list);
        }
    }
    public class Info
    {
        public double ParamValue { get; set; }
        public string ParamName { get; set; }

        public Info(object a, object b)
        {
            string check = a.ToString();

            ParamValue = double.Parse(check);
            ParamName = (string)b;
        }
    }
}
