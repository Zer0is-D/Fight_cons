using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Buffs 
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


        //  Состояния
        public bool Parry = false;
        public bool Prot_up = false;

        //  Ходы

        public void Clear()
        {
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

            Parry = false;
            Prot_up = false;
        }
            
        public static void Clear(object x) => x = 0;

        public void Random_debuff(Hero hero, Enemy enemy)
        {
            if (Mechanics.Vero(0.7))
            {
                Attack_des.Act_Parry_atc(hero, enemy);
            }
            else
            {
                Outer.ChangeColor("\n", $"{enemy.Name} ", "пропускает ход\n", ConsoleColor.DarkMagenta);
                enemy.Turn = enemy.max_moves;
                hero.Hero_stats.Attacks++;
            }
        }
    }
}
