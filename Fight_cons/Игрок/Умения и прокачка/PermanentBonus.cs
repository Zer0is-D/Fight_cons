using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons.Основа_и_настройки
{
    internal class PermanentBonus : Characteristics
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

        //  Пассивные бонусы персонажа
        internal protected int LvlPointsPer;
    }
}
