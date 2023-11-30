using Fight_cons.Основа_и_настройки;
using Fight_cons.Противник;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
                    AboutLoc.ListOfUnits.Add(new Order(AboutLoc.Allies(enemy - 100)));
                    Thread.Sleep(50);
                }
                else
                {
                    AboutLoc.ListOfUnits.Add(new Order(AboutLoc.Enemies(enemy)));
                    Thread.Sleep(50);
                }
            }

            Battle(hero, AboutLoc.ListOfUnits);
        }

        //  Битва
        public static void Battle(Hero hero, List<Order> units)
        {
            List<Order> UnitTurnList;

            //  Скейл параметров противника
            foreach (var unit in units)
            {
                if (unit.charecter.IsEnemy)
                    GameFormulas.DoScale(hero.Lvl, unit.charecter);
            }

            //  Уведомление о начале боя
            Output.FightLog();

            //  Перечисление противников
            ListOfNames(units);

            //  Запись всех участников битвы
            UnitTurnList = BattleMemberList(hero, units);

            Sound.BATTLE_MUSIC();

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
                    if (cha.charecter.isPlayer)
                    {
                        while (hero.Turn < hero.TotalMaxMoves & hero.TotalHP > 0 && StillStanding(UnitTurnList) && !hero.Run)
                            CombatSolutions.CurrentEnemy(hero, units);
                    }
                    else
                        Unit.UnitFightChoice(cha.charecter, hero, units);
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
                    Output.VictoyLog();
                    hero.HeroStatistic.Wins++;
                    Reward(hero, units);
                }                
            }
            hero.Run = false;
            AboutLoc.ListOfUnits.Clear();
        }

        private static List<Order> BattleMemberList(Hero hero, List<Order> units)
        {
            List<Order> UnitTurnList = new List<Order>();

            foreach (var unit in units)
                UnitTurnList.Add(new Order(unit.charecter, 0));

            UnitTurnList.Add(new Order(hero, 0));

            return UnitTurnList;
        }

        private static void ListOfNames(List<Order> units)
        {
            bool FirstUnit = true;

            foreach (var unit in units)
            {
                if (units.Count() == 1)
                {
                    Output.WriteColorLine(Output.unitNameColor(unit.charecter.Role), "На вас нападает ", $"{unit.charecter.Name} ");
                    Output.WriteColorLine(ConsoleColor.DarkRed, "[", $"{unit.charecter.HP}", $" {Output.HPSymbol}]\n");
                    break;
                }
                else
                {
                    //  Для красивого отображения
                    if (FirstUnit)
                    {
                        Output.WriteColorLine(ConsoleColor.DarkMagenta, "На вас нападают ", $"{unit.charecter.Name} ");
                        Output.WriteColorLine(ConsoleColor.DarkRed, "[", $"{unit.charecter.HP}", $" {Output.HPSymbol}],\n");
                        FirstUnit = false;
                    }
                    else
                    {
                        Output.WriteColorName("", unit.charecter, " ");
                        //Output.WriteColorLine(ConsoleColor.DarkMagenta, "", $"{enemy.charecter.Name} ");
                        Output.WriteColorLine(ConsoleColor.DarkRed, "\t[", $"{unit.charecter.HP}", $" {Output.HPSymbol}],\n");
                    }
                }
            }
        }

        /// <summary>
        /// Проверка мертвы ли противники 
        /// </summary>
        private static bool StillStanding(List<Order> list)
        {
            sbyte dead = 0;
            sbyte runers = 0;

            foreach (var ch in list)
            {
                if (ch.charecter.TotalHP <= 0)
                    dead++;
                if (ch.charecter.Run)
                    runers++;
            }

            if (dead + runers == list.Count())
                return false;
            else
                return true;
        }

        /// <summary>
        /// Награда за победу
        /// </summary>
        private static void Reward(Hero hero, List<Order> units)
        {
            Random random = new Random();
            int money = 0;
            int exp = 0;

            foreach (var unit in units)
            {
                money += random.Next(0, 5) + (int)(unit.charecter.TotalCrit * 10) + (int)(unit.charecter.TotalBlock * 10) + (int)(unit.charecter.TotalSpeed * 10);
                exp += unit.charecter.KillExp;
            }

            Output.WriteColorLine(ConsoleColor.DarkCyan, $"Вы получили ", $"{exp}{Output.ExpSymbol} ");
            if (money > 0)
            {
                Output.WriteColorLine(ConsoleColor.Yellow, "и ", $"{money}{Output.MoneySymbol}\n");
                hero.Money += money;
            }
            else
                Console.WriteLine();

            hero.LevelUp(hero, exp);
        }

        //  Проверка на побег
        public static void CantRun(Hero hero, Charecter unit)
        {
            if (!unit.No_run)
            {
                if (GameFormulas.Vero(0.5))
                {
                    if (GameFormulas.Vero(0.3))
                        Console.WriteLine("Вы удачно сбежали\n");
                    else
                    {
                        double n = (hero.MaxHp / 100.0) * 10.0;
                        hero.HP -= (int)n;
                        Output.RunLog();
                        Console.WriteLine($"Вы сбежали с потерей {(int) n} {Output.HPSymbol}\n");
                    }                    
                    hero.Run = true;
                }
                else
                    Output.TwriteLine("Побег не удался!\n", 1);
            }
            else
                Output.TwriteLine("Вы не можете убежать\n", 1);
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
