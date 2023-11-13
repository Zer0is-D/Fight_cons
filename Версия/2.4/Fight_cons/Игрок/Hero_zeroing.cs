using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public partial class Hero
    {
        /// <summary>
        /// Тут находяться вторичные поля
        /// </summary>

        //  Информация о противниках
        public bool Info = false;

        //  Имя
        public bool know_name = false;

        //  Выход со стартовой позиции
        public static bool Exit_cave;

        //  На каком уровне выперли героя
        public static int Hero_lvl_know;

        //  Инвентарь
        public List<Inventory> Hero_inv = new List<Inventory>();

        //  Квесты
        public Quests Hero_quest = new Quests();
        public Spying Hero_spying = new Spying();

        //  Опьянение
        public byte drunk = 0;
        public byte Max_drunk = 3;

        //  Статистика
        public Statistic Hero_stats = new Statistic();
    }
}
