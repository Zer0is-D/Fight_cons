using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
