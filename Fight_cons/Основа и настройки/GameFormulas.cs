using Fight_cons.Противник;
using System;
using System.Xml.Linq;

namespace Fight_cons.Основа_и_настройки
{
    internal class GameFormulas
    {
        //  Для формул
        private const float ArmorFine = 1.5f;
        private const sbyte MinCritChance = 15;
        private const sbyte MaxCritChance = 20;

        /// <summary>
        /// Получить 1% от MAX HP
        /// </summary>
        public static float PercentHp(Charecter person) => ((float)person.HP / (float)person.MaxHp) * 100.0f;

        /// <summary>
        /// Получить n% от MAX HP
        /// </summary>
        public static short GetCurrentPercent(float num, sbyte percent) => (short)((num / 100) * percent);

        /// <summary>
        /// Итоговый урон после всех проверок 
        /// </summary>
        /// <param name="attacker">Атакующий</param>
        /// <param name="victim">Жертва</param>
        /// <param name="throwBranch">Пробитие брони</param>
        /// <param name="parry">Парирование</param>
        /// <returns></returns>
        public static short Damage(Charecter attacker, Charecter victim, bool throwBranch = false, bool parry = false)
        {
            float crit = CheckCrit(attacker);
            float attack;

            if (!throwBranch)
                attack = attacker.TotalAttack + crit;
            else
                attack = attacker.TotalAttack + crit / ArmorFine;

            if (parry)
                if (CheckParry(attacker, victim))
                    victim.Condition.RandomDebuff(attacker, victim);

            short damag = CheckDefence(victim, attack);

            return damag;
        }

        #region Проверки для урона
        //  Проверка на парирование
        protected static bool CheckParry(Charecter attacker, Charecter victim)
        {
            Random rand = new Random();
            if (victim.Condition.AttackParry)
            {
                if (victim.TotalSpeed >= rand.NextDouble())
                    return true;
                else
                {
                    Console.WriteLine("Парирование не удалось!");
                    return false;
                }
            }
            else
                return false;
        }

        public static short MagicDamage(Charecter attacker, Charecter victim, short spellPower)
        {
            float crit = CheckCrit(attacker, true);
            float att = spellPower + attacker.TotalArcane + crit;

            //  Урон по врагу с магической защитой
            short damag = CheckMagicDefence(victim, att);

            return damag;
        }

        //  Проверка на крит
        public static int CheckCrit(Charecter cha, bool magic = false)
        {
            Random rand = new Random();
            int crit = 0;

            if (!magic)
            {
                if (rand.NextDouble() <= cha.TotalCrit)
                    crit = (int)(cha.TotalAttack * (rand.Next(MinCritChance, MaxCritChance) * 0.1));
            }
            else
            {
                if (rand.NextDouble() <= cha.TotalMagicDefence)
                    crit = (int)(cha.TotalArcane * (rand.Next(MinCritChance, MaxCritChance) * 0.1));
            }            

            return crit;
        }

        //  Проверка на защиту и блок
        public static short CheckDefence(Charecter charecter, float att)
        {
            if (charecter.Condition.SheeldUp)
                att = att * (1 - charecter.TotalBlock) + (1 - charecter.TotalDefence);
            else
                att = att * (1 - charecter.TotalDefence);

            return (short) att;
        }

        //  Проверка на магическую защиту
        public static short CheckMagicDefence(Charecter enemy, float att)
        {
            att = att * (1 - enemy.TotalMagicDefence);
            return (short) att;
        }

        public static bool CheckMana(Hero hero, short cost)
        {
            if (hero.MP >= cost)
            {
                hero.MP -= cost;
                return true;
            }
            else
                return false;
        }
        #endregion

        //  Веротятность события
        //  шанс N% на успех
        public static bool Vero(double x)
        {
            Random rand = new Random();
            bool ans = false;

            if (x >= rand.NextDouble())
                ans = true;

            return ans;
        }

        #region Формулы для юнитов
        public static void DoScale(sbyte lvlScale, Charecter enemy)
        {
            Random rand = new Random();

            enemy.HP = ScaleMAXHP(lvlScale, enemy.HP);
            if (enemy.CharecterProfile.Wild)
                enemy.MaxHp = (short)(ScaleMAXHP(lvlScale, enemy.HP) * rand.Next(2, 3));
            else
                enemy.MaxHp = ScaleMAXHP(lvlScale, enemy.HP);
            enemy.Attack = ScaleATT(lvlScale, enemy.Attack);
        }

        //  Скейл параметров противника от уровня героя
        public static short ScaleMAXHP(sbyte lvlScale, short x)
        {
            return (short)((lvlScale * 1.5) + x);
        }

        //  Скейл параметров противника от уровня героя
        public static short ScaleATT(sbyte lvlScale, short x)
        {
            return (short)((lvlScale * 0.5) + x);
        }

        public bool Equals(Unit unit1, Unit unit2)
        {
            return
                unit1.Name == unit2.Name &&
                unit1.CharecterProfile.Phase == unit2.CharecterProfile.Phase &&
                unit1.HP == unit2.HP &&
                unit1.Attack == unit2.Attack &&
                unit1.Speed == unit2.Speed &&
                unit1.Crit == unit2.Crit &&
                unit1.Defence == unit2.Defence &&
                unit1.MagicDefence == unit2.MagicDefence &&
                unit1.Block == unit2.Block &&
                unit1.Moves == unit2.Moves &&
                unit1.CharecterProfile.TooBrave == unit2.CharecterProfile.TooBrave &&
                unit1.CharecterProfile.Role == unit2.CharecterProfile.Role &&
                unit1.CharecterProfile.Strategy == unit2.CharecterProfile.Strategy;
        }

        public int GetHashCode(Unit obj)
        {
            return
                obj.Name.GetHashCode() ^
                obj.CharecterProfile.Phase.GetHashCode() ^
                obj.HP.GetHashCode() ^
                obj.Attack.GetHashCode() ^
                obj.Speed.GetHashCode() ^
                obj.Crit.GetHashCode() ^
                obj.Defence.GetHashCode() ^
                obj.MagicDefence.GetHashCode() ^
                obj.Block.GetHashCode() ^
                obj.Moves.GetHashCode() ^
                obj.CharecterProfile.TooBrave.GetHashCode() ^
                obj.CharecterProfile.Role.GetHashCode() ^
                obj.CharecterProfile.Strategy.GetHashCode();
        }
        #endregion
    }
}                  