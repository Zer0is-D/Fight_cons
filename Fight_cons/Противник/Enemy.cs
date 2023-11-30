using Fight_cons.Противник;
using System;

namespace Fight_cons
{
    internal class Enemy : Unit
    {
        internal Enemy(string name, sbyte phase, int hp,
                  int attack, int speed, int crit_chance,
                  int defence, int magic_defence, int block,
                  sbyte max_moves, bool no_run, int strategy = 0)
        {
            Consrtucter(this, name, phase, hp, attack, speed, crit_chance,
                defence, magic_defence, block, max_moves, no_run);
        }

        //  Конструктор 2       
        public Enemy(string name, sbyte phase, int HP_min, int HP_max,
            int ATT_min, int ATT_max, int SPD_min, int SPD_max,
            int CRIT_min, int CRIT_max, int DEF_min, int DEF_max,
            int M_DEF_min, int M_DEF_max, int BLK_min, int BLK_max,
            sbyte max_turn_min, sbyte max_turn_max, int strategy, ChaRole role)
        {
            Consrtucter(this, name, phase, HP_min, HP_max, ATT_min, ATT_max,
                SPD_min, SPD_max, CRIT_min, CRIT_max, DEF_min, DEF_max,
                M_DEF_min, M_DEF_max, BLK_min, BLK_max, max_turn_min, max_turn_max, strategy, role);
        }
    }
}
