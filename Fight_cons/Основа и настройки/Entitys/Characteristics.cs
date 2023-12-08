using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fight_cons.Основа_и_настройки
{
    public class Characteristics
    {
        //  Место для хранения информации о себе
        public List<Info> ItemList = new List<Info>();

        //  Свойства
        private string _name;
        internal string Name
        {
            get => _name;
            set => _name = value;
        }

        //  Здоровье
        private protected int _maxHp;
        public int MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        private protected int _hp;
        public int HP
        {
            get => _hp;
            set => _hp = value;
        }

        //  Мана
        private protected int _maxMp;
        public int MaxMp
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
        private protected int _attack;
        public int Attack
        {
            get => _attack;
            set => _attack = value;
        }

        //  Сила магии
        private protected int _arcane;
        public int Arcane
        {
            get => _arcane;
            set => _arcane = value;
        }

        //  Скорость
        private protected double _speed;
        public double Speed
        {
            get => _speed;
            set => _speed = value;
        }

        //  Шанс крита
        private protected double _crit;
        public double Crit
        {
            get => _crit;
            set
            {
                if (value < 1)
                    _crit = value;
            }
        }

        //  Физическая защита
        private protected double _defence;
        public double Defence
        {
            get => _defence;
            set
            {
                if (value <= 0)
                    _defence = 0;
                if (value <= 1)
                    _defence = value;
            }
        }

        //  Магическая защита
        private protected double _magicDefence;
        public double MagicDefence
        {
            get => _magicDefence;
            set
            {
                if (value <= 0)
                    _magicDefence = 0;
                if (value <= 1)
                    _magicDefence = value;
            }
        }

        //  Шанс блока
        private protected double _block;
        public double Block
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
        public int MaxMoves;

        public void GetItemParamFields(Characteristics cha)
        {
            //Output output = new Output();

            //List<object> fields = new List<object>();
            //List<string> fields2 = new List<string>();

            //var s = cha.GetType().GetProperties();
            //foreach (var a in s)
            //    fields.Add(a.GetValue(cha));

            //var sS = output.GetType().GetProperties();
            //foreach (var a in sS)
            //    //if (a.GetType().Name.Contains("Str"))
            //        fields2.Add(a.Name);

            //for (int i = 0; i < fields.Count();)
            //{
            //    ItemList.Add(new Info(fields[i], fields2[i]));
            //    i++;
            //}

            //  Рабочие варианты
            ////Попробовать доделать В1
            //foreach (var property in s)
            //{
            //    if (property.GetType().IsPublic)
            //        ItemList.Add(new Info(property.GetValue(cha), Output.AttackStr));
            //}


            //  В2
            var list = new List<Info>
            {
                new Info(cha.Attack, Output.AttackStr),
                new Info(cha.Arcane, Output.ArcaneStr),
                new Info(cha.Defence, Output.DefenceStr),
                new Info(cha.MagicDefence, Output.MagicDefenceStr),
                new Info(cha.MaxHp, Output.MaxHpStr),
                new Info(cha.MaxMp, Output.MaxMpStr),
                new Info(cha.Speed, Output.SpeedStr),
                new Info(cha.Crit, Output.CritStr),
                new Info(cha.Block, Output.BlockStr),
                new Info(cha.MaxMoves, Output.MaxMovesStr)
            };
            ItemList.AddRange(list);
        }
    }
}
