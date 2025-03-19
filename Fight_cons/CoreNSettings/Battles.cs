using FightCons.CoreNSettings;
using FightCons.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static FightCons.Character;

namespace FightCons
{
    public class Battles
    {
        public static List<Order> ListOfUnits = new List<Order>();

        #region Генерация кол. противников 
        //TODO пересмотреть и доработать в случае чего
        //  Можно доработать и добалвять или заменять встречающихся противников

        private static sbyte HeroLvlMargin = 3;
        private static sbyte MinGroupSize = 1;
        private static sbyte MaxGroupSize = 2;
        private static sbyte EnemyRangeId = 3;

        //  Битва со случайном противником/отрядом из заданного диапазона 
        /*public static void MakeRandomBattle(Hero hero, List<BattleScenarioEvent> scenario = null, params sbyte[] unitId)
        {
            Random random = new Random();

            if (hero.Lvl >= HeroLvlMargin)
            {
                HeroLvlMargin += 3;
                MaxGroupSize += 1;

                if (HeroLvlMargin >= 6)
                    EnemyRangeId = 4;
            }

            sbyte groupSize = (sbyte)random.Next(MinGroupSize, MaxGroupSize + 1);

            sbyte[] hostiles = new sbyte[groupSize];

            //  Запись рандомного диапазона ID
            for (sbyte i = 0; i < groupSize;)
            {
                if (unitId != null)
                    hostiles[i] = unitId[random.Next(unitId.Length)];
                else
                    hostiles[i] = (sbyte)random.Next(0, EnemyRangeId);

                Thread.Sleep(100);
                Thread.Sleep(100);
                i++;
            }

            MakeCurrentBattle(hero, scenario, hostiles);
        }*/

        //  Битва со случайном противником/отрядом из заданного диапазона 
        public static void MakeRandomBattle(Hero hero, List<Order> unitLists, List<BattleScenarioEvent> scenario = null)
        {
            Random random = new Random();

            while (hero.Lvl >= HeroLvlMargin)
            {
                HeroLvlMargin += 3;
                MaxGroupSize += 1;

                if (HeroLvlMargin >= 6)
                    EnemyRangeId = 4;
            }

            sbyte groupSize = (sbyte)random.Next(MinGroupSize, MaxGroupSize + 1);

            sbyte[] hostiles = new sbyte[groupSize];
            List<Order> randomList = new List<Order>();

            //  Запись рандомного диапазона ID
            for (sbyte i = 0; i < groupSize;)
            {
                if (unitLists != null)
                    randomList.Add(unitLists[random.Next(0, unitLists.Count - 1)]);
                else
                    hostiles[i] = (sbyte)random.Next(0, EnemyRangeId);

                Thread.Sleep(100);
                i++;
            }

            MakeCurrentBattle(hero, randomList, scenario);
        }
        #endregion

        public static List<Order> UnitTurnList;

        //  Создание списка противников/союзников и вызов боя
        /*public static void MakeCurrentBattle(Hero hero, List<BattleScenarioEvent> scenario = null, params sbyte[] unitId)
        //{
        //    foreach (var enemy in unitId)
        //    {
        //        var u = new Order(EnemyFromXML.LaudedEnemies(enemy, Character.ChaRole.Enemy), Character.ChaRole.Enemy);

        //        if (u.character != null)
        //            ListOfUnits.Add(u);
        //        else
        //            Console.WriteLine($"ID: {enemy} нет в списках!\n");

        //        //  Определение сторон конфликта
        //        Thread.Sleep(50);
        //    }

        //    Battle(hero, ListOfUnits, scenario);
        //}*/

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        //  Создание списка противников/союзников и вызов боя
        public static void MakeCurrentBattle(Hero hero, List<Order> unitLists, List<BattleScenarioEvent> scenario = null)
        {
            foreach (var enemy in unitLists)
            {
                var u = new Order(EnemyFromXML.LaudedEnemies(enemy.UnitID, enemy.Role), enemy.Role);

                if (u.character != null)
                    ListOfUnits.Add(u);
                else
                    Console.WriteLine($"ID: {enemy} нет в списках!\n");

                Thread.Sleep(50);
            }

            Battle(hero, ListOfUnits, scenario);
        }

        /*Старый метод
        public static List<Order> AddNewUnit(Hero hero, List<Order> units, params sbyte[] unitId)
        {
            List<Order> newList = new List<Order>();

            foreach (var enemy in unitId)
            {
                var u = new Order(EnemyFromXML.LaudedEnemies(enemy, Character.ChaRole.Enemy), Character.ChaRole.Enemy);

                if (u.character != null)
                {
                    newList.Add(u);
                }
                else
                    Console.WriteLine($"ID: {enemy} нет в списках!\n");

                Thread.Sleep(50);
            }

            //  Скейл параметров противника
            foreach (var unit in newList)
            {
                if (unit.Role == Character.ChaRole.Enemy)
                    GameFormulas.DoScale(hero.Lvl, unit.character);
            }

            units.AddRange(newList);

            //  Запись всех участников битвы
            UnitTurnList = BattleMemberList(hero, units);

            Random rand = new Random();

            foreach (var unit in UnitTurnList)
            {
                unit.Speed = (rand.Next(0, 100) * 0.01) + unit.character.TotalSpeed;
                Thread.Sleep(100);
            }

            UnitTurnList = UnitTurnList.OrderByDescending(c => c.Speed).ToList();

            //  Присвоение id юнитам, кроме героя
            sbyte i = 1;
            foreach (var unit in units)
            {
                if (unit.character.Role != Character.ChaRole.Hero)
                {
                    unit.character.Id = i;
                    i++;
                }
            }

            if (newList != null)
                return newList;
            else
                return null;
        }*/

        public static List<Order> AddNewUnit(Hero hero, List<Order> units, List<Order> newUnits)
        {
            List<Order> newList = new List<Order>();


            foreach (var enemy in newUnits)
            {
                var u = new Order(EnemyFromXML.LaudedEnemies(enemy.UnitID, enemy.Role), enemy.Role);

                if (u.character != null)
                {
                    newList.Add(u);
                }
                else
                    Console.WriteLine($"ID: {enemy} нет в списках!\n");

                Thread.Sleep(50);
            }

            //  Скейл параметров противника
            foreach (var unit in newList)
            {
                if (unit.Role != ChaRole.Hero)
                    GameFormulas.DoScale(hero.Lvl, unit.character);
            }

            units.AddRange(newList);

            //  Запись всех участников битвы
            UnitTurnList = BattleMemberList(hero, units);

            Random rand = new Random();

            foreach (var unit in UnitTurnList)
            {
                unit.Speed = (rand.Next(0, 100) * 0.01) + unit.character.TotalSpeed;
                Thread.Sleep(100);
            }

            UnitTurnList = UnitTurnList.OrderByDescending(c => c.Speed).ToList();

            //  Присвоение id юнитам, кроме героя
            sbyte i = 1;
            foreach (var unit in units)
            {
                if (unit.character.Role != ChaRole.Hero)
                {
                    unit.character.Id = i;
                    i++;
                }
            }

            if (newList != null)
                return newList;
            else
                return null;
        }

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static List<Order> AddNewUnit(Character character, List<Order> units, List<Order> newUnits)
        {
            Hero heroChare = units.FirstOrDefault(x => x.character.IsPlayer).character as Hero;
            List<Order> newList = new List<Order>();


            foreach (var enemy in newUnits)
            {
                var u = new Order(EnemyFromXML.LaudedEnemies(enemy.UnitID, enemy.Role), enemy.Role);

                if (u.character != null)
                {
                    newList.Add(u);
                }
                else
                    Console.WriteLine($"ID: {enemy} нет в списках!\n");

                Thread.Sleep(50);
            }

            //  Скейл параметров противника
            foreach (var unit in newList)
            {
                if (unit.Role != ChaRole.Hero)
                    GameFormulas.DoScale(heroChare.Lvl, unit.character);
            }

            units.AddRange(newList);

            //  Запись всех участников битвы
            UnitTurnList = BattleMemberList(character, units);

            Random rand = new Random();

            foreach (var unit in UnitTurnList)
            {
                unit.Speed = (rand.Next(0, 100) * 0.01) + unit.character.TotalSpeed;
                Thread.Sleep(100);
            }

            UnitTurnList = UnitTurnList.OrderByDescending(c => c.Speed).ToList();

            //  Присвоение id юнитам, кроме героя
            sbyte i = 1;
            foreach (var unit in units)
            {
                if (unit.character.Role != ChaRole.Hero)
                {
                    unit.character.Id = i;
                    i++;
                }
            }

            if (newList != null)
                return newList;
            else
                return null;
        }

        //  Битва
        public static void Battle(Hero hero, List<Order> units, List<BattleScenarioEvent> scenario = null)
        {
            UnitTurnList = null;
            Order.Round = 0;

            //  Скейл параметров противника
            foreach (var unit in units)
            {
                if (!unit.character.IsPlayer)
                    GameFormulas.DoScale(hero.Lvl, unit.character);
            }

            //  Уведомление о начале боя
            //SER.SecondWindowByProcces("FightLog");
            Output.FightWarning();

            //  Перечисление противников
            ShowAttackersNames(units);

            //  Запись всех участников битвы
            UnitTurnList = BattleMemberList(hero, units);

            Sound.BATTLE_MUSIC();

            //TODO переделать 
            while (hero.TotalHP > 0 && StillStanding(UnitTurnList) && !hero.Condition.LeavedBattle)
            {
                Random rand = new Random();

                foreach (var unit in UnitTurnList)
                {
                    //  Влияние вероятности на инициативу 50 или 100 
                    unit.Speed = (rand.Next(0, 50) * 0.01) + unit.character.TotalSpeed;
                    Thread.Sleep(100);
                }

                UnitTurnList = UnitTurnList.OrderByDescending(c => c.Speed).ToList();

                //  Присвоение id юнитам, кроме героя
                sbyte i = 1;
                foreach (var unit in units)
                {
                    if (!unit.character.IsPlayer)
                    {
                        unit.character.Id = i;
                        i++;
                    }
                }

                //  Бой
                foreach (var cha in UnitTurnList)
                {
                    if (cha.Role == ChaRole.Hero)
                    {
                        //while (hero.Turn < hero.TotalMaxMoves & hero.TotalHP > 0 && StillStanding(UnitTurnList) && !hero.Condition.LeavedBattle)
                        while (cha.character.Turn < cha.character.TotalMaxMoves & cha.character.TotalHP > 0 && StillStanding(UnitTurnList) && !cha.character.Condition.LeavedBattle)
                        {
                            //if (cha.character.IsPlayer)
                            //    CombatSolutions.CurrentEnemy(hero, units, scenario);
                            //else
                                CombatSolutionsParty.CurrentEnemy(cha.character, units, scenario);
                        }
                            
                    }
                    else
                        Unit.UnitFightChoice(cha.character, hero, units, scenario);
                    Order.Round++;
                }
            }

            //  Чистка параметров
            hero.Condition.Clear();
            scenario.Clear();
            hero.Turn = 0;

            if (hero.TotalHP <= 0)
                hero.HeroDeath();
            else
            {
                if (!hero.Condition.LeavedBattle)
                {
                    Output.VictoryWarning();
                    hero.Statistic.Wins++;
                    BattleReward(hero, units);
                }
            }
            hero.Condition.LeavedBattle = false;
            ListOfUnits.Clear();
        }

        //  Различные проверки        
        private static bool StillStanding(List<Order> list)
        {
            CheckForCrops();

            foreach (var ch in list)
            {
                if (ch.Role != Character.ChaRole.Ally & ch.Role != Character.ChaRole.Hero & ch.character.Condition.IsAlive & !ch.character.Condition.LeavedBattle)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Проверка мертвы ли противники 
        /// </summary>
        public static void CheckForCrops()
        {
            foreach (var ch in UnitTurnList)
            {
                if (ch.character.TotalHP <= 0)
                    ch.character.Condition.IsAlive = false;
            }
        }

        private static List<Order> BattleMemberList(Character hero, List<Order> units)
        {
            List<Order> UnitTurnList = new List<Order>();

            foreach (var unit in units)
                UnitTurnList.Add(new Order(unit.character, unit.Role));

            UnitTurnList.Add(new Order(hero, 0));

            return UnitTurnList;
        }      

        /// <summary>
        /// Награда за победу
        /// </summary>
        private static void BattleReward(Hero hero, List<Order> units)
        {
            Random random = new Random();
            short money = 0;
            short exp = 0;

            foreach (var unit in units)
            {
                if (unit.character.Condition.LeavedBattle)
                {
                    money += (short)((random.Next(0, 5)
                        + (unit.character.TotalCrit * 10)
                        + (unit.character.TotalBlock * 10)
                        + (unit.character.TotalSpeed * 10)) / 2);

                    exp += (short)(unit.character.KillExp / 2);
                }
                else
                {
                    money += (short)(random.Next(0, 5)
                        + (unit.character.TotalCrit * 10)
                        + (unit.character.TotalBlock * 10)
                        + (unit.character.TotalSpeed * 10));

                    exp += (short)unit.character.KillExp;
                }
            }

            Output.WriteColorLine(ConsoleColor.DarkCyan, $"Вы получили ", $"{exp}{Output.ExpSymbol} ");
            if (money > 0)
            {
                Output.WriteColorLine(ConsoleColor.Yellow, "и ", $"{money}{Output.MoneySymbol}\n");
                hero.Money += money;
                hero.Statistic.Money += money;
            }
            else
                Console.WriteLine();

            hero.LevelUp(hero, exp);
        }

        //  Проверка на побег
        //TODO Можно добавить к вероятности скорость героя
        public static void RunFromBattle(Hero hero, Character unit, List<Order> units = null)
        {
            if (!unit.CantRunBattle)
            {
                if (GameFormulas.Vero(0.5))
                {
                    if (GameFormulas.Vero(0.3))
                        Console.WriteLine("Вы удачно сбежали\n");
                    else
                    {
                        double n = (hero.MaxHp / 100.0) * 10.0;
                        hero.HP -= (short) n;
                        Output.RunWarning();
                        Console.WriteLine($"Вы сбежали с потерей {(int)n} {Output.HPSymbol}\n");
                    }
                    hero.Condition.LeavedBattle = true;
                }
                else
                    Output.TwriteLine("Побег не удался!\n", 1);
            }
            else
                Output.TwriteLine("Вы не можете убежать\n", 1);
        }

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static void RunFromBattle(Character character, Character unit, List<Order> units = null)
        {
            if (!unit.CantRunBattle)
            {
                if (GameFormulas.Vero(0.5))
                {
                    if (GameFormulas.Vero(0.3))
                        Console.WriteLine("Вы удачно сбежали\n");
                    else
                    {
                        double n = (character.MaxHp / 100.0) * 10.0;
                        character.HP -= (short)n;
                        Output.RunWarning();
                        Console.WriteLine($"Вы сбежали с потерей {(int)n} {Output.HPSymbol}\n");
                    }
                    character.Condition.LeavedBattle = true;
                }
                else
                    Output.TwriteLine("Побег не удался!\n", 1);
            }
            else
                Output.TwriteLine("Вы не можете убежать\n", 1);
        }

        private static void ShowAttackersNames(List<Order> units)
        {
            bool FirstUnit = true;

            foreach (var unit in units)
            {
                if (units.Count() == 1)
                {
                    Output.WriteColorLine(Output.unitNameColor(unit.Role), "На вас нападает ", $"{unit.character.Name} ");
                    Output.WriteColorLine(ConsoleColor.DarkRed, "[", $"{unit.character.HP}", $" {Output.HPSymbol}]\n");
                    break;
                }
                else
                {
                    //  Для красивого отображения
                    if (FirstUnit)
                    {
                        Output.WriteColorLine(Output.unitNameColor(unit.Role), "На вас нападают ", $"{unit.character.Name} ");
                        Output.WriteColorLine(ConsoleColor.DarkRed, "[", $"{unit.character.HP}", $" {Output.HPSymbol}],\n");
                        FirstUnit = false;
                    }
                    else
                    {
                        Output.WriteColorName("", unit.character, " ");
                        //Output.WriteColorLine(ConsoleColor.DarkMagenta, "", $"{enemy.charecter.Name} ");
                        Output.WriteColorLine(ConsoleColor.DarkRed, "\t[", $"{unit.character.HP}", $" {Output.HPSymbol}],\n");
                    }
                }
            }
        }
    }

    //  Порядок хода
    public class Order
    {
        public sbyte UnitID { get; set; }

        public Character? character;

        public double Speed { get; set; }

        public static byte Round { get; set; }

        public ChaRole Role { get; set; }

        //public Character.ChaRole Role { get; set; }

        public Order(sbyte unitID, ChaRole chaRole)
        {
            UnitID = unitID;
            Role = chaRole;
        }

        public Order(Character cha, ChaRole role)
        {
            character = cha;
            Speed = 0;
            Role = role;
        }
    }


    public class BattleScenarioEvent
    {
        public Func<Hero, List<Order>, byte, bool> Condition { get; }
        public Action<Hero, List<Order>> Action { get; }

        public static bool MultiTrigger = false;

        public BattleScenarioEvent(Func<Hero, List<Order>, byte, bool> condition, Action<Hero, List<Order>> action, bool multiTrigger = false)
        {
            Condition = condition;
            Action = action;
            MultiTrigger = multiTrigger;
        }

        public static void CheckBattleScenarios(Hero hero, List<Order> units, List<BattleScenarioEvent> scenario = null)
        {
            if (scenario != null)
            {
                if (MultiTrigger)
                    CheckMultiBattleScenario(hero, units, scenario);
                else
                    CheckSingleBattleScenario(hero, units, scenario);               
            }
        }

        public static void CheckSingleBattleScenario(Hero hero, List<Order> units, List<BattleScenarioEvent> scenario = null)
        {
            if (scenario != null)
            {
                foreach (var bEvent in scenario.Where(x => x.Condition(hero, units, Order.Round)).ToList())
                {
                    bEvent.Action(hero, units);
                    scenario.Remove(bEvent);
                }
            }
        }

        public static void CheckMultiBattleScenario(Hero hero, List<Order> units, List<BattleScenarioEvent> scenario = null)
        {
            if (scenario != null)
            {
                foreach (var bEvent in scenario.Where(x => x.Condition(hero, units, Order.Round)).ToList())
                {
                    bEvent.Action(hero, units);
                }
            }
        }
    }
}
