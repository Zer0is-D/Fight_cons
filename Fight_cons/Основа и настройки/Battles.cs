using Fight_cons.Противник;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Battles
    {
        //  Создание списка противников/союзников и вызов боя
        public static void MakeBattle(Hero hero, params int[] unitId)
        {
            foreach (var enemy in unitId)
            {
                //  ПИЗДЕЦ КОСТЫЛЬ
                if (enemy > 99)
                {
                    AboutLoc.EnemyList.Add(new Order(AboutLoc.Allies(enemy - 100)));
                    Thread.Sleep(100);
                }
                else
                {
                    AboutLoc.EnemyList.Add(new Order(AboutLoc.Enemies(enemy)));
                    Thread.Sleep(100);
                }
            }

            Battle(hero, AboutLoc.EnemyList);
        }

        //  Битва
        public static void Battle(Hero hero, List<Order> units, int questId = 0)
        {
            List<Order> UnitTurnList = new List<Order>();
            bool FirstEnemy = true;

            //  Скейл параметров противника
            foreach (var unit in units)
            {
                if (unit.charecter.IsEnemy)
                    DoScale(hero.Lvl, unit.charecter);
            }

            //  Уведомление о начале боя
            Output.Fight_log();

            //  Перечисление противников
            foreach (var enemy in units)
            {
                if (units.Count() == 1)
                {
                    Output.WriteColorLine(ConsoleColor.DarkMagenta, "На вас нападает ", $"{enemy.charecter.Name} ");
                    Output.WriteColorLine(ConsoleColor.DarkRed, "[", $"{enemy.charecter.HP}", " HP]\n");
                    break;
                }
                else
                {
                    //  Для красивого отображения
                    if (FirstEnemy)
                    {
                        Output.WriteColorLine(ConsoleColor.DarkMagenta, "На вас нападают ", $"{enemy.charecter.Name} ");
                        Output.WriteColorLine(ConsoleColor.DarkRed, "[", $"{enemy.charecter.HP}", " HP],\n");
                        FirstEnemy = false;
                    }
                    else
                    {
                        Output.WriteColorLine(ConsoleColor.DarkMagenta, "", $"{enemy.charecter.Name} ");
                        Output.WriteColorLine(ConsoleColor.DarkRed, "[", $"{enemy.charecter.HP}", " HP],\n");
                    }
                }               
            }           
            Sound.BATTLE_MUSIC();            

            foreach (var enemy in units)
                UnitTurnList.Add(new Order(enemy.charecter, 0));

            UnitTurnList.Add(new Order(hero, 0));

            while (hero.TotalHP > 0 && StillStanding(UnitTurnList) && !hero.Run)
            {                
                Random rand = new Random();

                foreach (var unit in UnitTurnList)
                {
                    unit.Speed = (rand.Next(1, 999) * 0.001) + unit.charecter.TotalSpeed;
                    Thread.Sleep(100);
                }

                UnitTurnList = UnitTurnList.OrderByDescending(c => c.Speed).ToList();

                //  Присвоение id юнитам, кроме героя
                sbyte i = 1;
                foreach (var unit in units)
                {
                    if (!unit.charecter.isPlayer)
                    {
                        unit.charecter.Id = i;
                        i++;
                    }
                }

                //  Бой
                foreach (var cha in UnitTurnList)
                {
                    if (!cha.charecter.IsEnemy)
                    {
                        while (hero.Turn < hero.TotalMaxMoves & hero.TotalHP > 0 && StillStanding(UnitTurnList) && !hero.Run)
                            CombatSolutions.CurrentEnemy(hero, units);
                    }
                    else
                        Unit.Unit_fight_choice(cha.charecter, hero, units);
                }
            }

            //  Чистка параметров
            hero.Conditions.Clear();
            hero.Turn = 0;            

            if (hero.TotalHP <= 0)
                hero.HeroDeath();
            else
            {
                if (!hero.Run)
                {
                    Output.Victoy_log();
                    hero.HeroStatistic.Wins++;
                    Reward(hero, units);
                }                
            }
            hero.Run = false;
            AboutLoc.EnemyList.Clear();
        }

        /// <summary>
        /// Проверка мертвы ли противники 
        /// </summary>
        public static bool StillStanding(List<Order> list)
        {
            sbyte count = 0;
            sbyte dead = 0;
            sbyte runers = 0;
            foreach (var ch in list)
            {
                if (ch.charecter.TotalHP <= 0)
                    dead++;
                if (ch.charecter.Run)
                    runers++;
            }
            foreach (var u in list)
                if (u.charecter.IsEnemy == true)
                    count++;

            if (dead + runers == count)
                return false;
            else
                return true;
        }


        /// <summary>
        /// Награда за победу
        /// </summary>
        public static void Reward(Hero hero, List<Order> enemies)
        {
            Random random = new Random();
            int money = 0;
            int exp = 0;

            foreach (var enemy in enemies)
            {
                money += random.Next(0, 5) + (int)(enemy.charecter.TotalCrit * 10) + (int)(enemy.charecter.TotalBlock * 10) + (int)(enemy.charecter.TotalSpeed * 10);
                exp += enemy.charecter.KillExp;
            }

            Output.WriteColorLine(ConsoleColor.DarkCyan, $"Вы получили ", $"{exp}\u0407 ");
            if (money > 0)
            {
                Output.WriteColorLine(ConsoleColor.Yellow, "и ", $"{money}\u00A2\n");
                hero.Money += money;
            }
            else
                Console.WriteLine();

            hero.Level_up(hero, exp);
        }

        //  Проверка на побег
        public static void Cant_run(Hero hero, Charecter enemy)
        {
            if (!enemy.No_run)
            {
                if (Vero(0.5))
                {
                    if (Vero(0.3))
                        Console.WriteLine("Вы удачно сбежали\n");
                    else
                    {
                        double n = (hero.MaxHp / 100.0) * 10.0;
                        hero.HP -= (int)n;
                        Output.Run_log();
                        Console.WriteLine($"Вы сбежали с потерей {(int) n} HP\n");
                    }                    
                    hero.Run = true;
                }
                else
                    Output.TwriteLine("Побег не удался!\n", 1);
            }
            else
                Output.TwriteLine("Вы не можете убежать\n", 1);
        }

        public static void DoScale(int lvlScale, Charecter enemy)
        {
            Random rand = new Random();
            enemy.HP = Lvl_Scale_MAX_HP(lvlScale, enemy.HP);
            if (enemy.Wild)
                enemy.MaxHp = Lvl_Scale_MAX_HP(lvlScale, enemy.HP) * rand.Next(2, 3);
            else
                enemy.MaxHp = Lvl_Scale_MAX_HP(lvlScale, enemy.HP);
            enemy.Attack = Lvl_Scale_Attack(lvlScale, enemy.Attack);
        }

        //  Скейл параметров противника от уровня героя
        public static int Lvl_Scale_MAX_HP(int lvlScale, int x)
        {
            return (int)(lvlScale * 1.5) + x;
        }

        //  Скейл параметров противника от уровня героя
        public static int Lvl_Scale_Attack(int lvlScale, int x)
        {
            return (int)(lvlScale * 0.5) + x;
        }

        //  Веротятность события
        public static bool Vero(double x)
        {
            Random rand = new Random();
            bool ans = false;

            if (x >= rand.NextDouble())
                ans = true;

            return ans;
        }
    }

    //  Порядок хода
    public class Order
    {
        public Charecter? charecter;

        public double Speed;
        public Order(Charecter cha, double speed = 0)
        {
            charecter = cha;
            Speed = speed;
        }
    }
}
