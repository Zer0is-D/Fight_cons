using System;

namespace Fight_cons.Основа_и_настройки
{
    internal class GameFormulas
    {
        //  Для формул
        private const double ArmorFine = 1.5;
        private const int MinCritChance = 15;
        private const int MaxCritChance = 20;

        /// <summary>
        /// Получить 1% от MAX HP
        /// </summary>
        public static double PercentHp(Charecter person) => ((double)person.HP / (double)person.MaxHp) * 100.0;

        /// <summary>
        /// Получить n% от MAX HP
        /// </summary>
        public static int GetCurrentPercent(double num, int percent) => (int)((double)(num / 100) * percent);

        /// <summary>
        /// Итоговый урон после всех проверок 
        /// </summary>
        /// <param name="attacker">Атакующий</param>
        /// <param name="victim">Жертва</param>
        /// <param name="throwBranch">Пробитие брони</param>
        /// <param name="parry">Парирование</param>
        /// <returns></returns>
        public static int Damage(Charecter attacker, Charecter victim, bool throwBranch = false, bool parry = false)
        {
            double crit = CheckCrit(attacker);
            double attack;

            if (!throwBranch)
                attack = attacker.TotalAttack + crit;
            else
                attack = attacker.TotalAttack + crit / ArmorFine;

            if (parry)
                if (CheckParry(attacker, victim))
                    victim.Conditions.RandomDebuff(attacker, victim);

            int damag = CheckDefence(victim, attack);

            return damag;
        }

        #region Проверки для урона
        //  Проверка на парирование
        protected static bool CheckParry(Charecter attacker, Charecter victim)
        {
            Random rand = new Random();
            if (victim.Conditions.AttackParry)
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

        public static int MagicDamage(Charecter attacker, Charecter victim, int spellPower)
        {
            double crit = CheckCrit(attacker, true);
            double att = spellPower + attacker.TotalArcane + crit;

            //  Урон по врагу с магической защитой
            int damag = CheckMagicDefence(victim, att);

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
        public static int CheckDefence(Charecter charecter, double att)
        {
            if (charecter.Conditions.SheeldUp)
                att = att * (1 - charecter.TotalBlock) + (1 - charecter.TotalDefence);
            else
                att = att * (1 - charecter.TotalDefence);

            return (int) att;
        }

        //  Проверка на магическую защиту
        public static int CheckMagicDefence(Charecter enemy, double att)
        {
            att = att * (1 - enemy.TotalMagicDefence);
            return (int) att;
        }

        public static bool CheckMana(Hero hero, int cost)
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
        public static void DoScale(int lvlScale, Charecter enemy)
        {
            Random rand = new Random();

            enemy.HP = ScaleMAXHP(lvlScale, enemy.HP);
            if (enemy.Wild)
                enemy.MaxHp = ScaleMAXHP(lvlScale, enemy.HP) * rand.Next(2, 3);
            else
                enemy.MaxHp = ScaleMAXHP(lvlScale, enemy.HP);
            enemy.Attack = ScaleATT(lvlScale, enemy.Attack);
        }

        //  Скейл параметров противника от уровня героя
        public static int ScaleMAXHP(int lvlScale, int x)
        {
            return (int)(lvlScale * 1.5) + x;
        }

        //  Скейл параметров противника от уровня героя
        public static int ScaleATT(int lvlScale, int x)
        {
            return (int)(lvlScale * 0.5) + x;
        }
        #endregion
    }
}
