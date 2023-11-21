using Fight_cons.Основа_и_настройки;

namespace Fight_cons
{
    //  Бонусы от класса
    internal class ClassBonus : Characteristics
    {
        internal protected new int HP
        {
            get => this.MaxHp;
            set => this.MaxHp = value;
        }
        internal protected new int MP
        {
            get => this.MaxMp;
            set => this.MaxMp = value;
        }
    }
}
