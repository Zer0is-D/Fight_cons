using FightCons.CoreNSettings;
using FightCons.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightCons
{
    public class PersonStrategy 
    {
        private static Character WhoToBeat(Character person, Hero hero, List<Order> units)
        {
            Random rand = new Random();
            List<Character> MyEnemies = new List<Character>();

            foreach (var cha in units)
            {
                switch (person.CharacterProfile.Role)
                {
                    case CharacterProfiles.ChaRole.Wild:
                        if (cha.character.Id != person.Id & cha.character.Condition.IsAlive & !cha.character.Condition.LeavedBattle)
                            MyEnemies.Add(cha.character);
                        break;

                    case CharacterProfiles.ChaRole.Enemy:
                        if (cha.character.CharacterProfile.Role != CharacterProfiles.ChaRole.Enemy & cha.character.Id != person.Id & cha.character.Condition.IsAlive & !cha.character.Condition.LeavedBattle)
                            MyEnemies.Add(cha.character);
                        break;

                    case CharacterProfiles.ChaRole.Ally:
                        if (cha.character.CharacterProfile.Role == CharacterProfiles.ChaRole.Enemy & cha.character.Id != person.Id & cha.character.Condition.IsAlive & !cha.character.Condition.LeavedBattle)
                            MyEnemies.Add(cha.character);
                        break;
                }                    
            }
            if (person.CharacterProfile.Role != CharacterProfiles.ChaRole.Ally)
                MyEnemies.Add(hero);

            if (MyEnemies.Count() == 0)
                return null;

            return MyEnemies[rand.Next(0, MyEnemies.Count)];
        }

        public static void UnitAction(Character unit, Hero hero, List<Order> units)
        {
            switch (unit.CharacterProfile.Strategy)
            {
                //  Любая базовая стратегия поведения
                case CharacterProfiles.Strategies.Any:
                    if (GameFormulas.Vero(0.5))
                        StrgATC(unit, hero, units);
                    else
                        StrgMAG(unit, hero, units);
                    break;

                //  Атакующй стратегия
                case CharacterProfiles.Strategies.Aggressive:
                    StrgATC(unit, hero, units);
                    break;

                //  Стратегия волшебника
                case CharacterProfiles.Strategies.Mage:
                    StrgMAG(unit, hero, units);
                    break;

                //  Стратегия некроманта
                case CharacterProfiles.Strategies.Necromancer:
                    StrgNECRO(unit, hero, units);
                    break;

                //  Стратегия хилера
                case CharacterProfiles.Strategies.BeastMaster:
                    StrgBeastMaster(unit, hero, units);
                    break;

                default:
                    StrgATC(unit, hero, units);
                    break;
            }
        }

        public static void StrgATC(Character attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (!attacker.CharacterProfile.TooBrave && NeedToRun(attacker, min1: 10, min2: 20))
                    break;

                //  Условья
                //  Если здоровье меньше 30% (атака 60% / оборона 40%)
                if (GameFormulas.PercentHp(attacker) < 30)
                {
                    if (GameFormulas.Vero(0.6))
                    {
                        UnitSkills.EnemyHits(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }                              
                    else
                    {
                        UnitSkills.HoldTheSheeld(attacker);
                        break;
                    }
                }
                if (WhoToBeat(attacker, hero, units) != null)
                {
                    if (!hero.Condition.AttackParry)
                    {
                        UnitSkills.EnemyHits(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }
                    //  Отравляющая атака                
                    if (hero.Condition.PoisentRound == 0)
                    {
                        if (GameFormulas.Vero(0.5))
                        {
                            UnitSkills.PoisentAtt(attacker, WhoToBeat(attacker, hero, units));
                            break;
                        }
                    }
                }                
                else
                {
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
            attacker.Turn = 0;
        }

        public static void StrgMAG(Character attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (!attacker.CharacterProfile.TooBrave && NeedToRun(attacker, min1: 10, min2: 20))
                    break;

                //UnitSkills.AdSpamSpellAsync(attacker);

                if (WhoToBeat(attacker, hero, units) != null)
                {
                    if (GameFormulas.PercentHp(attacker) < 60)
                    {
                        if (GameFormulas.Vero(0.5))
                        {
                            UnitSkills.Vamperism(attacker, WhoToBeat(attacker, hero, units));
                            break;
                        }
                    }

                    //  Заклинания
                    if (GameFormulas.Vero(0.9))
                    {
                        //  Заклинание заморозки
                        if (GameFormulas.Vero(0.1))
                        {
                            UnitSkills.FrezSpell(attacker, WhoToBeat(attacker, hero, units));
                            break;
                        }

                        //  Заклинание замедления
                        if (hero.Condition.SlowRound <= 1)
                        {
                            if (GameFormulas.Vero(0.7))
                            {
                                UnitSkills.SlowerSpell(attacker, WhoToBeat(attacker, hero, units));
                                break;
                            }
                        }

                        //  Заклинание вампиризм
                        else if (GameFormulas.Vero(0.5))
                        {
                            UnitSkills.Vamperism(attacker, WhoToBeat(attacker, hero, units));
                            break;
                        }
                    }
                    else if (GameFormulas.Vero(0.3))
                    {
                        UnitSkills.EnemyHits(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }
                }                
                else
                {
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
            attacker.Turn = 0;
        }

        public static void StrgNECRO(Character attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (!attacker.CharacterProfile.TooBrave && NeedToRun(attacker, min1: 10, min2: 20))
                    break;
                if (WhoToBeat(attacker, hero, units) != null)
                {
                    if (GameFormulas.PercentHp(attacker) < 60)
                    {
                        if (GameFormulas.Vero(0.5))
                        {
                            UnitSkills.Vamperism(attacker, WhoToBeat(attacker, hero, units));
                            break;
                        }
                    }

                    //  Заклинания
                    if (GameFormulas.Vero(0.9))
                    {
                        if (GameFormulas.Vero(0.8) & units.Any(e => e.character.Condition.IsAlive == false))
                        {
                            foreach (var en in units)
                            {
                                if (en.character.Condition.IsAlive == false)
                                {
                                    UnitSkills.RevievSpell(attacker, en.character);
                                    break;
                                }
                            }
                        }

                        //  Заклинание вампиризм
                        else if (GameFormulas.Vero(0.5))
                        {
                            UnitSkills.Vamperism(attacker, WhoToBeat(attacker, hero, units));
                            break;
                        }
                    }
                    else if (GameFormulas.Vero(0.3))
                    {
                        UnitSkills.EnemyHits(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }
                }               
                else
                {
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
            attacker.Turn = 0;
        }

        public static void StrgBeastMaster(Character attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (!attacker.CharacterProfile.TooBrave && NeedToRun(attacker, min1: 10, min2: 20))
                    break;

                //  Условья
                //  Если здоровье меньше 30% (атака 60% / оборона 40%)
                if (GameFormulas.PercentHp(attacker) < 30)
                {
                    if (GameFormulas.Vero(0.4))
                    {
                        UnitSkills.SpawnSpell(attacker, hero, units);
                        break;
                    }
                    else if(GameFormulas.Vero(0.6))
                    {
                        UnitSkills.EnemyHits(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }
                }
                if (WhoToBeat(attacker, hero, units) != null)
                {
                    if (!hero.Condition.AttackParry)
                    {
                        UnitSkills.EnemyHits(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }
                }
                else
                {
                    UnitSkills.SpawnSpell(attacker, hero, units);//////////////////////////////////////////////////////////
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
            attacker.Turn = 0;
        }

        /// <summary>
        /// Проверка побега
        /// </summary>
        public static bool NeedToRun(Character person, sbyte min1, short? min2 = null)
        {
            if (min2 == null)
            {
                if (GameFormulas.PercentHp(person) < min1)
                {
                    if (GameFormulas.Vero(0.8))
                    {
                        Output.WriteColorLine(Output.unitNameColor(person.CharacterProfile.Role), $"\n[{person.Id}] ", $"{person.Name} ", "сбегает\n");
                        Console.ReadKey();
                        person.Condition.LeavedBattle = true;
                        return true;
                    }
                }
            }
            else
            {
                if (GameFormulas.PercentHp(person) < min1 || GameFormulas.PercentHp(person) < min2)
                {
                    if (GameFormulas.Vero(0.8))
                    {
                        Output.WriteColorLine(Output.unitNameColor(person.CharacterProfile.Role), $"\n[{person.Id}] ", $"{person.Name} ", "сбегает\n");
                        Console.ReadKey();
                        person.Condition.LeavedBattle = true;
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
