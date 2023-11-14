using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class PersonStrategy 
    {
        /// <summary>
        /// Процент ХП
        /// </summary>
        private static double percent_hp(Charecter person) => ((double)person.HP / (double)person.MaxHp) * 100.0;

        private static Charecter WhoToBeat(Charecter person, Hero hero, List<Order> units)
        {
            Random rand = new Random();
            List<Charecter> MyList = new List<Charecter>();

            //  Если противник встретит не противника
            if (person.IsEnemy)
            {
                foreach (var cha in units)
                {
                    if (cha.charecter.IsEnemy == false & cha.charecter.Id == person.Id)
                        MyList.Add(cha.charecter);
                }                
            }
            //  Если противник встретит такого же 
            else
            {
                foreach (var cha in units)
                {
                    if (cha.charecter.IsEnemy == true & cha.charecter.Id == person.Id)
                        MyList.Add(cha.charecter);
                }                
            }
            MyList.Add(hero);

            //if (MyList.Count <= 1)
            //    return MyList.FirstOrDefault();

            return MyList[rand.Next(0, MyList.Count)];
        }

        public static void Strg_ATC(Charecter attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (Need_to_run(attacker, min1: 10, min2: 20))
                    break;

                //  Условья
                //  Если здоровье меньше 30% (атака 60% / оборона 40%)
                if (percent_hp(attacker) < 30)
                {
                    if (Battles.Vero(0.6))
                    {
                        UnitSkills.Enemy_Hit(attacker, WhoToBeat(attacker, hero, units));
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
                    UnitSkills.Enemy_Hit(attacker, WhoToBeat(attacker, hero, units));
                    break;
                }
                //  Отравляющая атака                
                if (hero.Conditions.PoisentRound == 0)
                {
                    if (Battles.Vero(0.5))
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
        }

        public static void Strg_MAG(Charecter attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (Need_to_run(attacker, min1: 10, min2: 20))
                    break;
                else if (percent_hp(attacker) < 60)
                {
                    if (Battles.Vero(0.5))
                    {
                        UnitSkills.Vamperism(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }                        
                }

                //  Заклинания
                if (Battles.Vero(0.9))
                {
                    //  Заклинание заморозки
                    if (Battles.Vero(0.1))
                    {
                        UnitSkills.Spell_frez(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }

                    //  Заклинание замедления
                    if (hero.Conditions.MaxMoves < 3)
                    {
                        if (Battles.Vero(0.7))
                        {
                            UnitSkills.Spell_slow(attacker, WhoToBeat(attacker, hero, units));
                            break;
                        }
                    }
                    
                    //  Заклинание вампиризм
                    else if (Battles.Vero(0.5))
                    {
                        UnitSkills.Vamperism(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }
                }
                else if (Battles.Vero(0.3))
                {
                    UnitSkills.Enemy_Hit(attacker, WhoToBeat(attacker, hero, units));
                    break;
                }
                else
                {
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
        }

        public static void Strg_NECRO(Charecter attacker, Hero hero, List<Order> units)
        {
            while (attacker.Turn < attacker.TotalMaxMoves)
            {
                //  Если здоровье меньше 10-20% то сбегаем
                if (Need_to_run(attacker, min1: 10, min2: 20))
                    break;
                else if (percent_hp(attacker) < 60)
                {
                    if (Battles.Vero(0.5))
                    {
                        UnitSkills.Vamperism(attacker, WhoToBeat(attacker, hero, units));
                        break;
                    }
                }

                //  Заклинания
                if (Battles.Vero(0.9))
                {
                    if (Battles.Vero(0.8) & units.Any(e => e.charecter.IsAlive == false))
                    {
                        foreach (var en in units)
                        {
                            if (en.charecter.IsAlive == false)
                            {
                                UnitSkills.Spell_Alive(attacker, en.charecter);
                                break;
                            }
                        }                        
                    }

                    //  Заклинание вампиризм
                    else if (Battles.Vero(0.5))
                    {
                        UnitSkills.Vamperism(WhoToBeat(attacker, hero, units), attacker);
                        break;
                    }
                }
                else if (Battles.Vero(0.3))
                {
                    UnitSkills.Enemy_Hit(WhoToBeat(attacker, hero, units), attacker);
                    break;
                }
                else
                {
                    UnitSkills.HoldTheSheeld(attacker);
                    break;
                }
            }
        }

        /// <summary>
        /// Проверка побега
        /// </summary>
        public static bool Need_to_run(Charecter person, byte min1, byte? min2 = null)
        {            
            if (min2 == null)
            {
                if (percent_hp(person) < min1)
                {
                    if (Battles.Vero(0.8))
                    {
                        Output.WriteColorLine(ConsoleColor.DarkMagenta, $"\n[{person.Id}] ", $"{person.Name} ", "сбегает\n");
                        person.Run = true;
                        return true;
                    }
                }
            }
            else
            {
                if (percent_hp(person) < min1 || percent_hp(person) < min2)
                {
                    if (Battles.Vero(0.8))
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
