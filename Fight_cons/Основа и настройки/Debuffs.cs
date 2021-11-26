using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    //public delegate void DEBAFF_dele(Hero hero, Enemy enemy);

    public class Debuffs 
    {
        //  Поля
        public double Hp;
        public double Mp;
        public double Attack;
        public double Arcane;
        public double Speed;
        public double Crit;
        public double Defence;
        public double Magic_defence;
        public double Block;
        public sbyte Max_moves;


        //  Базовый урон от эффектов
        public int Pisent_dmg = 3;
        public int Bleed_dmg = 3;

        //  Ходы
        public sbyte Frez_round;
        public sbyte Slow_round;
        public sbyte Poisent_round;
        public sbyte Bleed_round;

        public void Clear()
        {
            //  Обнуление полей
            Hp = 0;
            Mp = 0;
            Attack = 0;
            Arcane = 0;
            Speed = 0;
            Crit = 0;
            Defence = 0;
            Magic_defence = 0;
            Block = 0;
            Max_moves = 0;
            Frez_round = 0;

            //  Обнуление ходов
            Frez_round = 0;
            Slow_round = 0;
            Poisent_round = 0;
            Bleed_round = 0;
        }

        public void Clear_one(object x) => x = 0;
    }
}
