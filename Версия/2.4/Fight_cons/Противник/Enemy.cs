using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fight_cons
{
    public class Enemy : Charecter
    {
        public int ID;

        //  Здоровье
        public int MAX_HP;
        protected int HP;
        public int hp
        {
            get
            {
                return HP;
            }
            set
            {
                if (HP > 0)
                    HP = value;
            }
        }

        public byte Strategy;

        //  Броня
        public Armor armor = new Armor("Без брони", 0, 0);
        public double defence { get => Defence + armor.Defenc + (buffs.Defence - debuffs.Defence); }

        //  Магическая защита
        public double magic_defence { get => Magic_defence + (buffs.Magic_defence - debuffs.Magic_defence); }

        //  Оружие
        public Weapon weapon = new Weapon(name: "Кулаки", attack: 0, speed: 0, cost: 0, crit: 0, block: 0, move: 0);
        public int attack { get => Attack + weapon.Attack + (int) (buffs.Attack - debuffs.Attack); }
        public double speed { get => Speed + weapon.Speed + (buffs.Speed - debuffs.Speed); }
        public double crit { get => Crit + weapon.Crit + (buffs.Crit - debuffs.Crit); }
        public double block { get => Block + weapon.Block + (buffs.Block - debuffs.Block); }
        public sbyte max_moves { get => (sbyte) (Max_moves + weapon.Move); }

        public bool No_run;

        //  Конструктор 0
        public Enemy()
        {

        }

        //  Конструктор 1
        public Enemy(Hero hero, string name, int hp, int attack, int speed, int crit_chance, int defence, int magic_defence, int block, sbyte max_moves, bool no_run)
        {
            Name = name;
            HP = Lvl_Scale_MAX_HP(hero, hp);
            Attack = Lvl_Scale_MAX_HP(hero, attack);
            Speed = Lvl_Scale_MAX_HP(hero, speed) * 0.01;
            Crit = crit_chance * 0.01;
            Defence = defence * 0.01;
            Magic_defence = magic_defence * 0.01;
            Block = Lvl_Scale_MAX_HP(hero, block) * 0.01;
            Max_moves = max_moves;
            No_run = no_run;
        }

        //  Конструктор 2       
        public Enemy(Hero hero, string name, int HP_min, int HP_max, int ATT_min, int ATT_max, int SPD_min, int SPD_max, int CRIT_min, int CRIT_max, int DEF_min, int DEF_max, int M_DEF_min, int M_DEF_max, int BLK_min, int BLK_max, sbyte max_turn_min, sbyte max_turn_max, byte strategy)
        {
            Random rand = new Random();
            Name = name;
            MAX_HP = HP = Lvl_Scale_MAX_HP(hero, rand.Next(HP_min, HP_max));
            Attack = Lvl_Scale_Attack(hero, rand.Next(ATT_min, ATT_max));
            Speed = rand.Next(SPD_min, SPD_max) * 0.01;
            Crit = rand.Next(CRIT_min, CRIT_max) * 0.01;
            Defence = rand.Next(DEF_min, DEF_max) * 0.01;
            Magic_defence = rand.Next(M_DEF_min, M_DEF_max) * 0.01;
            Block = rand.Next(BLK_min, BLK_max) * 0.01;
            Max_moves = (sbyte) rand.Next(max_turn_min, max_turn_max);
            Strategy = strategy;
        }

        //  Скейл параметров противника от уровня героя
        public int Lvl_Scale_MAX_HP(Hero hero, int x) 
        {
            return (int) (hero.lvl * 1.5) + x;
        }
        
        //  Скейл параметров противника от уровня героя
        public int Lvl_Scale_Attack(Hero hero, int x)
        {
            return (int)(hero.lvl * 1.3) + x;
        }

        //  Решения противника
        public void Enemy_fight_choice(Enemy enemy, Hero hero)
        {
            //  Минус от эффектов
            Negative_effect_impact(enemy, hero);

            hero.Turn = 1;
            enemy.Turn++;
            Enemy_strategy e_strategy = new Enemy_strategy();
            
            enemy.buffs.Prot_up = false;

            if (Mechanics.Vero(0.5) && enemy.Strategy >= 2)
                e_strategy.Strg_MAG(enemy, hero);
            else
                e_strategy.Strg_ATC(enemy, hero);
        }

        //  Вычитание негативыне эффекты
        public static void Negative_effect_impact(Enemy enemy, Hero hero)
        {
            if (enemy.debuffs.Max_moves > 0 || enemy.debuffs.Poisent_round > 0 || enemy.debuffs.Bleed_round > 0)
            {
                //  Кровотечение
                if (enemy.debuffs.Bleed_round > 0)
                {
                    Outer.ChangeColor($"\n", $"{enemy.Name} ", $"получает -{enemy.debuffs.Bleed_dmg} HP ", ConsoleColor.DarkMagenta);
                    Outer.ChangeColor("от ", "кровотечение ", "\n", ConsoleColor.DarkRed);
                    enemy.debuffs.Bleed_round--;
                    enemy.hp -= enemy.debuffs.Bleed_dmg;
                }

                //  Замедление
                if (enemy.debuffs.Max_moves > 0)
                    enemy.debuffs.Slow_round--;

                //  Отравление
                if (enemy.debuffs.Poisent_round > 0)
                {
                    enemy.debuffs.Poisent_round--;
                    enemy.hp -= enemy.debuffs.Pisent_dmg;
                }
            }
        }
    }
}
