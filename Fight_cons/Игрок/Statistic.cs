﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Statistic
    {
        //  Имя
        public bool know_name = false;

        //  События из бара
        //  На каком уровне выперли героя из бара
        public int Hero_lvl_know;


        //  Боевая статистика
        //  Количество физ атак
        public int Attacks;

        //  Количество маг атак
        public int Spells;

        //  Количество побед
        public int Wins;


        //  Мини игры
        //  Изучение пещеры
        public int Cave_ad;

        //  Победы в мини-играх
        public int Arm_game_wins;
    }
}
