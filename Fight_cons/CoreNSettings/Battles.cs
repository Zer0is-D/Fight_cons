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
        public static List<BattleSession> ListOfUnits = new List<BattleSession>();

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
        public static void MakeRandomBattle(Hero hero, List<BattleSession> unitLists, List<BattleScenarioEvent> scenario = null)
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
            List<BattleSession> randomList = new List<BattleSession>();

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

        public static List<BattleSession> UnitTurnList;

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
        public static void MakeCurrentBattle(Hero hero, List<BattleSession> unitLists, List<BattleScenarioEvent> scenario = null)
        {
            foreach (var enemy in unitLists)
            {
                var u = new BattleSession(EnemyFromXML.LaudedEnemies(enemy.UnitID, enemy.Role), enemy.Role);

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

        public static List<BattleSession> AddNewUnit(Hero hero, List<BattleSession> units, List<BattleSession> newUnits)
        {
            List<BattleSession> newList = new List<BattleSession>();


            foreach (var enemy in newUnits)
            {
                var u = new BattleSession(EnemyFromXML.LaudedEnemies(enemy.UnitID, enemy.Role), enemy.Role);

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
        public static List<BattleSession> AddNewUnit(Character character, List<BattleSession> units, List<BattleSession> newUnits)
        {
            Hero heroChare = units.FirstOrDefault(x => x.character.IsPlayer).character as Hero;
            List<BattleSession> newList = new List<BattleSession>();


            foreach (var enemy in newUnits)
            {
                var u = new BattleSession(EnemyFromXML.LaudedEnemies(enemy.UnitID, enemy.Role), enemy.Role);

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
        public static void Battle(Hero hero, List<BattleSession> units, List<BattleScenarioEvent> scenario = null)
        {
            UnitTurnList = null;
            BattleSession.Round = 0;

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
                    BattleSession.Round++;
                }
            }

            //  Чистка параметров
            hero.Condition.Clear();
            if (scenario != null)
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

        public static void ClearBattlePlace(Hero hero, List<BattleSession> units, List<BattleScenarioEvent> scenario = null)
        {
            //  Чистка параметров
            hero.Condition.Clear();
            if (scenario != null)
                scenario.Clear();
            hero.Turn = 0;

            hero.Condition.LeavedBattle = false;
            ListOfUnits.Clear();
        }

        //  Различные проверки        
        private static bool StillStanding(List<BattleSession> list)
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

        private static List<BattleSession> BattleMemberList(Character hero, List<BattleSession> units)
        {
            List<BattleSession> UnitTurnList = new List<BattleSession>();

            foreach (var unit in units)
                UnitTurnList.Add(new BattleSession(unit.character, unit.Role));

            UnitTurnList.Add(new BattleSession(hero, 0));

            return UnitTurnList;
        }      

        /// <summary>
        /// Награда за победу
        /// </summary>
        private static void BattleReward(Hero hero, List<BattleSession> units)
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
        public static void RunFromBattle(Hero hero, List<BattleSession> units = null)
        {
            var unit = units[BattleSession.SelectedUnit].character;

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
        public static void RunFromBattle(Character character, List<BattleSession> units = null)
        {
            var unit = units[BattleSession.SelectedUnit].character;

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

        private static void ShowAttackersNames(List<BattleSession> units)
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

        //struct UnitPosition
        //{
        //    public Character character;
        //    public int x, y; // Позиция противника
        //    public bool hasCover; // Установлено ли укрытие

        //    public UnitPosition(Character character, int x, int y)
        //    {
        //        this.character = character;
        //        this.x = x;
        //        this.y = y;
        //    }
        //}

        public static void BattleMap(Character character, List<BattleSession> units = null)
        {
            /* Старый вариант
            //WriteColorLine(ConsoleColor.DarkGray, "", "┌──────────────────────────────────────────────────────────────────────────────┐");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ │");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ │");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ │");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ │");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ |");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ---------------------------------------------------------------------------- |");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ |");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ |");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ |");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ |");
            //WriteColorLine(ConsoleColor.DarkGray, "", "| ############################################################################ |");
            //WriteColorLine(ConsoleColor.DarkGray, "", "└──────────────────────────────────────────────────────────────────────────────┘");*/

            // 2
            //Output.WriteColorLine(ConsoleColor.DarkGray, "\t\t\t", "| ########### ###### ########### |", "\t\n");
            //Output.WriteColorLine(ConsoleColor.DarkGray, "\t\t\t", "| ########## ☺ #### ☺ ########## |", "\t\n");
            //Output.WriteColorLine(ConsoleColor.DarkGray, "\t\t\t", "| ########### ###### ########### |", "\t\n");

            List<BattleSession> enemySide = new List<BattleSession>();
            List<BattleSession> allySide = new List<BattleSession>();

            string[] masHeadNFoot =
            {
                "\t\t\t| ############### ############## |\t",
                "\t\t\t| ########### ###### ########### |\t",
                "\t\t\t| ######## ###### ###### ####### |\t",
                "\t\t\t| #### ###### ###### ###### #### |\t",
            };

            sbyte enemyNum = 0;
            sbyte allytNum = 0;

            foreach (var u in units)
            {
                if (u.Role == ChaRole.Enemy || u.Role == ChaRole.Wild)
                {
                    enemySide.Add(u);
                    enemyNum++;
                }
                else
                {
                    allySide.Add(u);
                    allytNum++;
                }                    
            }
            allytNum++; //hero
            allySide.Add(new BattleSession(character, ChaRole.Hero));
            
            //  Не трогаем 
            Console.WriteLine("\n\t\t\t┌────────────────────────────────┐\t");
            Console.WriteLine("\t\t\t| ############################## │\t");

            #region Сторона противника
            //Console.Write("\t\t\t| ");
            //if (enemySide.Count >= 2)
            //    Console.Write("########### ###### ########### |");
            //else
            //    Console.Write("############### ############## |");

            Console.Write(masHeadNFoot[enemySide.Count > 4 ? masHeadNFoot.Length - 1 : enemySide.Count - 1] + "\n\t\t\t| ");
            Tes(enemySide, character);
            #endregion

            #region Centre
            //if (enemySide.Count >= 2)
            //    Console.Write("\t\t\t| ########### ###### ########### |\t\n");
            //else
            //    Console.Write("\t\t\t| ############### ############## |\t\n");
            Console.Write(masHeadNFoot[enemySide.Count > 4 ? masHeadNFoot.Length - 1 : enemySide.Count - 1]);

            Console.Write("\t\t\t\t| ############################## |\t");
            Console.Write("\t\t\t\t| ------------------------------ |\t");
            Console.Write("\t\t\t\t| ############################## |\t\n");

            //if (allySide.Count >= 2)
            //    Console.Write("\t\t\t| ########### ###### ########### |\t\n");
            //else
            //    Console.Write("\t\t\t| ############### ############## |\t\n");
            Console.Write(masHeadNFoot[allySide.Count > 4 ? masHeadNFoot.Length - 1 : allySide.Count - 1] + "\n\t\t\t| ");
            #endregion

            #region Сторона союзника
            Tes(allySide, character);

            //if (allySide.Count >= 2)
            //    Console.Write("\t\t\t| ########### ###### ########### |\t\n");
            //else
            //    Console.Write("\t\t\t| ############### ############## |\t\n");
            Console.Write(masHeadNFoot[allySide.Count > 4 ? masHeadNFoot.Length - 1 : allySide.Count - 1]);
            #endregion

            //  Не трогаем 
            Console.Write("\t\t\t\t| ############################## |\t");
            Console.Write("\t\t\t\t└────────────────────────────────┘\t\n");
            

            /*Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t",
            //                                units.Count >= 2 ? "| ########### ###### ########### |" : "| ############### ############## |", "\t\n");

            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t",


            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t",
            //                                units.Count >= 2 ? "| ########### ###### ########### |" : "| ############### ############## |", "\t\n");

            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t", "| ############################## |", "\t\n");
            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t", "| ------------------------------ |", "\t\n");
            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t", "| ############################## |", "\t\n");

            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t",
            //                                 units.Count > 2 ? "| ########### ###### ########### |" : "| ############### ############## |", "\t\n");
            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t",
            //                                 units.Count > 2 ? "| ########## ☻ #### ☻ ########## |" : "| ############## ☻ ############# │", "\t\n");
            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t",
            //                                 units.Count > 2 ? "| ########### ###### ########### |" : "| ############### ############## |", "\t\n");
            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t", "| ############################## |", "\t\n");
            //Output.WriteColorLine(ConsoleColor.Gray, "\t\t\t", "└────────────────────────────────┘", "\t\n");

            //Console.BackgroundColor = ConsoleColor.DarkGray;*/
        }

        public static void Tes(List<BattleSession> unit, Character character, bool good = false)
        {
            string simbol = good ? " ☻ " : " ☺ ";

            string[] masFirst =
            {
                "##############",
                "##########",
                "#######",
                "###",
            };

            string[] masEnd =
            {
                "############# |\t\n",
                "########## |\t\n",
                "###### |\t\n",
                "### |\t\n",
            };
            string space = "####";

            Console.Write(masFirst[unit.Count > 4 ? masFirst.Length - 1 : unit.Count - 1]);

            if (BasicCheck(unit[0].character, character))
                Output.WriteColorLine(Output.unitNameColor(unit[0].Role), "", simbol);
            else
                Output.WriteColorLine(ConsoleColor.DarkGray, "", simbol);

            for (int i = 1; i < unit.Count; i++)
            {
                if (i == 4)
                    break;
                if (BasicCheck(unit[i].character, character))
                    Output.WriteColorLine(Output.unitNameColor(unit[i].Role), space, simbol);
                else
                    Output.WriteColorLine(ConsoleColor.DarkGray, space, simbol);
            }

            Console.Write(masEnd[unit.Count > 4 ? masEnd.Length - 1 : unit.Count - 1]);
        }

        
        /*public static void BattleMap(Character character, List<Order> units = null)
        {
            List<Order> enemySide = new List<Order>();
            List<Order> allySide = new List<Order>();

            sbyte enemyNum = 0;
            sbyte allytNum = 0;

            foreach (var u in units)
            {
                if (u.Role == ChaRole.Enemy || u.Role == ChaRole.Wild)
                {
                    enemySide.Add(u);
                    enemyNum++;
                }
                else
                {
                    allySide.Add(u);
                    allytNum++;
                }
            }
            allySide.Add(new Order(character, character.Role));
            allytNum++; //hero

            BattleMapEn(enemySide, enemyNum);
            BattleMapAl(allySide, allytNum);
        }

        public static void BattleMapEn(List<Order> enemySide, sbyte enemyNum)
        {
            int width = 30;
            int height = 4;

            //allySide.Add(new UnitPosition(character));

            UnitPosition[] enemyPositions = new UnitPosition[enemyNum];

            int startX = 15; // Начальная позиция по X для размещения
            int startY = 1;  //height - 2; // Начальная позиция по Y для размещения

            for (int i = 0; i < enemyNum; i++)
            {
                if (enemyNum == 1)
                {
                    enemyPositions[0] = new UnitPosition(enemySide[i].character, startX, startY);
                }
                else if (enemyNum == 2)
                {
                    enemyPositions[0] = new UnitPosition(enemySide[i].character, startX - 3, startY);
                    enemyPositions[1] = new UnitPosition(enemySide[i].character, startX + 2, startY);

                }
                else if (enemyNum == 3)
                {
                    enemyPositions[0] = new UnitPosition(enemySide[i].character, startX - 7, startY);
                    enemyPositions[1] = new UnitPosition(enemySide[i].character, startX, startY);
                    enemyPositions[2] = new UnitPosition(enemySide[i].character, startX + 7, startY);
                }
                else if (enemyNum >= 4 && enemyNum <= 6)
                {
                    int rows = 2;
                    int columns = (enemyNum + 1) / rows;

                    for (int j = 0; j < enemyNum; j++)
                    {
                        enemyPositions[j] = new UnitPosition(enemySide[i].character, startX + (columns - 1) + (i % columns) * 2, startY + (i / columns));
                    }
                }
                else if (enemyNum >= 7 && enemyNum <= 9)
                {
                    sbyte level = 0;
                    for (int j = 0; j < enemyNum; j++)
                    {
                        enemyPositions[j] = new UnitPosition(enemySide[i].character, startX + (i - level) * 2, startY - level);

                        if (j == (level + 1) * 2 - 1)
                            level++;
                    }
                }
            }

            Console.WriteLine();

            string[,] gameMap = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    gameMap[i, j] = " ";
                }
            }


            for (int i = 0; i < enemyNum; i++)
            {
                gameMap[enemyPositions[i].y, enemyPositions[i].x] = enemyPositions[i].character.TotalHP > 0 ? "A" : "D";

                // Укрытие перед противником
                if (enemyPositions[i].y > 0 && !enemyPositions[i].hasCover)
                {
                    gameMap[enemyPositions[i].y + 1, enemyPositions[i].x] = "@";
                    enemyPositions[i].hasCover = true;
                }
            }

            // Печать карты
            PrintMap(gameMap, width, height);
        }
        public static void BattleMapAl(List<Order> allySide, sbyte allytNum)
        {
            int width = 30;
            int height = 4;

            UnitPosition[] allyPositions = new UnitPosition[allytNum];

            int startX = 15; // Начальная позиция по X для размещения
            int startY = 1;  //height - 2; // Начальная позиция по Y для размещения

            for (int i = 0; i < allytNum; i++)
            {
                if (allytNum == 1)
                {
                    allyPositions[0] = new UnitPosition(allySide[i].character, startX, startY);
                }
                else if (allytNum == 2)
                {
                    allyPositions[0] = new UnitPosition(allySide[i].character, startX, startY);
                    allyPositions[1] = new UnitPosition(allySide[i].character, startX + 5, startY);

                }
                else if (allytNum == 3)
                {
                    allyPositions[0] = new UnitPosition(allySide[i].character, startX, startY);
                    allyPositions[1] = new UnitPosition(allySide[i].character, startX + 2, startY);
                    allyPositions[2] = new UnitPosition(allySide[i].character, startX + 2, startY);
                }
                else if (allytNum >= 4 && allytNum <= 6)
                {
                    sbyte rows = 2;
                    sbyte columns = (sbyte)(allytNum / rows);

                    for (int j = 0; j < allytNum; j++)
                    {
                        allyPositions[j] = new UnitPosition(allySide[i].character, startX + (i % columns) * 2, startY - (i / columns));
                    }
                }
                else if (allytNum >= 7 && allytNum <= 9)
                {
                    sbyte level = 0;
                    for (int j = 0; j < allytNum; j++)
                    {
                        allyPositions[j] = new UnitPosition(allySide[i].character, startX + (i - level) * 2, startY - level);

                        if (j == (level + 1) * 2 - 1)
                            level++;
                    }
                }
            }

            Console.WriteLine();

            string[,] gameMap = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    gameMap[i, j] = " ";
                }
            }


            for (int i = 0; i < allytNum; i++)
            {
                gameMap[allyPositions[i].y, allyPositions[i].x] = allyPositions[i].character.TotalHP > 0 ? "A" : "D";

                // Укрытие перед противником
                if (allyPositions[i].y > 0 && !allyPositions[i].hasCover)
                {
                    gameMap[allyPositions[i].y - 1, allyPositions[i].x] = "@";
                    allyPositions[i].hasCover = true;
                }
            }

            // Печать карты
            PrintMap(gameMap, width, height);
        }*/

        private static bool BasicCheck(Character en, Character al) => en.TotalHP > 0 & !en.Condition.LeavedBattle & !al.Condition.LeavedBattle;

        static void PrintMap(string[,] map, int width, int height)
        {
            Console.WriteLine("\t\t\t┌" + new string('─', width) + "┐\t");
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t\t\t│");
                for (int j = 0; j < width; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine("│");
            }
            Console.WriteLine("\t\t\t└" + new string('─', width) + "┘\t\n");
        }
    }

    //  Порядок хода
    public class BattleSession
    {
        public sbyte UnitID { get; set; }

        public Character? character;

        public double Speed { get; set; }

        public static byte Round { get; set; }

        public ChaRole Role { get; set; }

        public static short SelectedUnit { get; set; }

        public BattleSession(sbyte unitID, ChaRole chaRole)
        {
            UnitID = unitID;
            Role = chaRole;
        }

        public BattleSession(Character cha, ChaRole role)
        {
            character = cha;
            Speed = 0;
            Role = role;
        }
    }


    public class BattleScenarioEvent
    {
        public Func<Hero, List<BattleSession>, byte, bool> Condition { get; }
        public Action<Hero, List<BattleSession>> Action { get; }

        public static bool MultiTrigger = false;

        public BattleScenarioEvent(Func<Hero, List<BattleSession>, byte, bool> condition, Action<Hero, List<BattleSession>> action, bool multiTrigger = false)
        {
            Condition = condition;
            Action = action;
            MultiTrigger = multiTrigger;
        }

        public static void CheckBattleScenarios(Hero hero, List<BattleSession> units, List<BattleScenarioEvent> scenario = null)
        {
            if (scenario != null)
            {
                if (MultiTrigger)
                    CheckMultiBattleScenario(hero, units, scenario);
                else
                    CheckSingleBattleScenario(hero, units, scenario);               
            }
        }

        public static void CheckSingleBattleScenario(Hero hero, List<BattleSession> units, List<BattleScenarioEvent> scenario = null)
        {
            if (scenario != null)
            {
                foreach (var bEvent in scenario.Where(x => x.Condition(hero, units, BattleSession.Round)).ToList())
                {
                    bEvent.Action(hero, units);
                    scenario.Remove(bEvent);
                }
            }
        }

        public static void CheckMultiBattleScenario(Hero hero, List<BattleSession> units, List<BattleScenarioEvent> scenario = null)
        {
            if (scenario != null)
            {
                foreach (var bEvent in scenario.Where(x => x.Condition(hero, units, BattleSession.Round)).ToList())
                {
                    bEvent.Action(hero, units);
                }
            }
        }
    }
}
