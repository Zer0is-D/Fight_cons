using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons.Противник
{
    internal class Ally : Charecter
    {
        internal Ally(string name, sbyte phase, int hp,
                  int attack, int speed, int crit_chance,
                  int defence, int magic_defence, int block,
                  sbyte max_moves, bool no_run, int strategy = 0)
        {
            Phase = phase;

            Name = name;
            HP = MaxHp = hp;

            Attack = attack;
            Speed = speed;
            Crit = crit_chance * 0.01;
            Defence = defence * 0.01;
            MagicDefence = magic_defence * 0.01;
            Block = block * 0.01;
            MaxMoves = max_moves;
            No_run = no_run;

            KillExp = (HP / 2) + (Attack / 2);
        }

        //  Конструктор 2       
        public Ally(string name, sbyte phase,
                     int HP_min, int HP_max,
                     int ATT_min, int ATT_max,
                     int SPD_min, int SPD_max,
                     int CRIT_min, int CRIT_max,
                     int DEF_min, int DEF_max,
                     int M_DEF_min, int M_DEF_max,
                     int BLK_min, int BLK_max,
                     sbyte max_turn_min, sbyte max_turn_max,
                     int strategy, bool wild = false)
        {
            Random rand = new Random();
            Wild = wild;
            Phase = phase;

            Name = name;

            if (Wild)
                MaxHp = rand.Next(HP_min, HP_max) * rand.Next(2, 5);
            else
                MaxHp = rand.Next(HP_min, HP_max);
            HP = rand.Next(HP_min, MaxHp);
            Attack = rand.Next(ATT_min, ATT_max);
            Speed = rand.Next(SPD_min, SPD_max) * 0.01;
            Crit = rand.Next(CRIT_min, CRIT_max) * 0.01;
            Defence = rand.Next(DEF_min, DEF_max) * 0.01;
            MagicDefence = rand.Next(M_DEF_min, M_DEF_max) * 0.01;
            Block = rand.Next(BLK_min, BLK_max) * 0.01;
            MaxMoves = rand.Next(max_turn_min, max_turn_max);
            strategeis = (Strategeis)strategy;

            KillExp = (HP / 2) + (Attack / 2);
        }
    }
}
