using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fight_cons
{
    public class PersonStrategy 
    {
        private static Charecter WhoToBeat(Charecter person, Hero hero, List<Order> units)
        {
            Random rand = new Random();
            List<Charecter> MyEnemies = new List<Charecter>();

            //  Ренегат
            if (person.Role == Charecter.ChaRole.Wild)
            {
                foreach (var cha in units)
                {
                    if (person.IsAlive & cha.charecter.Id != person.Id)
                        MyEnemies.Add(cha.charecter);
                }
                MyEnemies.Add(hero);
            }
            //  Если противник встретит не противника
            else if (person.Role == Charecter.ChaRole.Enemy)
            {
                foreach (var cha in units)
                {
                    if (!cha.charecter.IsEnemy & cha.charecter.Id != person.Id & person.IsAlive)
                        MyEnemies.Add(cha.charecter);
                }
                MyEnemies.Add(hero);
            }
            //  Если противник встретит такого же 
            else
            {
                foreach (var cha in units)
                {
                    if (cha.charecter.IsEnemy & cha.charecter.Id != person.Id & person.IsAlive)
                        MyEnemies.Add(cha.charecter);
                }                
            }            

            return MyEnemies[rand.Next(0, MyEnemies.Count)];
        }

        public static void StrgATC(Charecter attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (NeedToRun(attacker, min1: 10, min2: 20))
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

                if (!hero.Conditions.AttackParry)
                {
                    UnitSkills.EnemyHits(attacker, WhoToBeat(attacker, hero, units));
                    break;
                }
                //  Отравляющая атака                
                if (hero.Conditions.PoisentRound == 0)
                {
                    if (GameFormulas.Vero(0.5))
                    {
                        UnitSkills.Poisent_att(attacker, WhoToBeat(attacker, hero, units));
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

        public static void StrgMAG(Charecter attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (NeedToRun(attacker, min1: 10, min2: 20))
                    break;
                else if (GameFormulas.PercentHp(attacker) < 60)
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
                    if (hero.Conditions.MaxMoves < 3)
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
                else
                {
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
            attacker.Turn = 0;
        }

        public static void StrgNECRO(Charecter attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (NeedToRun(attacker, min1: 10, min2: 20))
                    break;
                else if (GameFormulas.PercentHp(attacker) < 60)
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
                    if (GameFormulas.Vero(0.8) & units.Any(e => e.charecter.IsAlive == false))
                    {
                        foreach (var en in units)
                        {
                            if (en.charecter.IsAlive == false)
                            {
                                UnitSkills.RevievSpell(attacker, en.charecter);
                                break;
                            }
                        }                        
                    }

                    //  Заклинание вампиризм
                    else if (GameFormulas.Vero(0.5))
                    {
                        UnitSkills.Vamperism(WhoToBeat(attacker, hero, units), attacker);
                        break;
                    }
                }
                else if (GameFormulas.Vero(0.3))
                {
                    UnitSkills.EnemyHits(WhoToBeat(attacker, hero, units), attacker);
                    break;
                }
                else
                {
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
            attacker.Turn = 0;
        }

        /// <summary>
        /// Проверка побега
        /// </summary>
        public static bool NeedToRun(Charecter person, byte min1, byte? min2 = null)
        {            
            if (min2 == null)
            {
                if (GameFormulas.PercentHp(person) < min1)
                {
                    if (GameFormulas.Vero(0.8))
                    {
                        Output.WriteColorLine(ConsoleColor.DarkMagenta, $"\n[{person.Id}] ", $"{person.Name} ", "сбегает\n");
                        person.Run = true;
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
                        Output.WriteColorLine(ConsoleColor.DarkMagenta, $"\n[{person.Id}] ", $"{person.Name} ", "сбегает\n");
                        person.Run = true;
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
