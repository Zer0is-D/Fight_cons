namespace Fight_cons.Основа_и_настройки
{
    internal class PermanentBonuses : Characteristics
    {
        internal protected new short HP
        {
            get => this.MaxHp;
            set => this.MaxHp = value;
        }
        internal protected new short MP
        {
            get => this.MaxMp;
            set => this.MaxMp = value;
        }

        //  Пассивные бонусы персонажа
        internal protected int LvlPointsPer;
    }
}
