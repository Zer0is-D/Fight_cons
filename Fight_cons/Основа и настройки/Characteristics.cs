namespace Fight_cons.Основа_и_настройки
{
    public class Characteristics
    {
        //  Свойства
        private string _name;
        internal protected string Name
        {
            get => _name;
            set => _name = value;
        }

        //  Здоровье
        private protected int _maxHp;
        internal protected int MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        private protected int _hp;
        internal protected int HP
        {
            get => _hp;
            set => _hp = value;
        }

        //  Мана
        private protected int _maxMp;
        internal protected int MaxMp
        {
            get => _maxMp;
            set => _maxMp = value;
        }


        internal protected int _mp;
        internal protected int MP
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
        internal protected int MaxMoves;
    }
}
