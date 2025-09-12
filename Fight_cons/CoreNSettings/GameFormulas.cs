using FightCons.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FightCons.CoreNSettings
{
    internal class GameFormulas
    {
        //  Для формул
        public const float ArmorFine = 1.5f;
        private const sbyte MinCritChance = 15;
        private const sbyte MaxCritChance = 20;


        /// <summary>
        /// Получить 1% от MAX HP
        /// </summary>
        public static float PercentHp(Character person) => ((float)person.HP / (float)person.MaxHp) * 100.0f;

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
        public static short Damage(Character attacker, Character victim, bool throwBranch = false)
        {
            float crit = CheckCrit(attacker);
            float attack;

            if (throwBranch)
                attack = attacker.TotalAttack / ArmorFine;            
            else
                attack = attacker.TotalAttack + crit;

            if (victim.Condition.AttackParry)
                if (CheckParry(attacker, victim))
                    victim.Condition.RandomDebuff(attacker, victim);

            return (short)(throwBranch == true ? attack : CheckDefence(victim, attack));            
        }

        public static short Damage(int baseAttack, Character victim, bool throwBranch = false)
        {
            //float crit = CheckCrit(attacker);
            float attack;

            if (!throwBranch)
                attack = baseAttack;
            else
                attack = baseAttack / ArmorFine;

            return (short)(throwBranch == true ? attack : CheckDefence(victim, attack));
        }

        #region Проверки для урона
        //  Проверка на парирование
        protected static bool CheckParry(Character attacker, Character victim)
        {
            Random rand = new Random();

            if (victim.TotalSpeed >= rand.NextDouble())
                return true;
            else
            {
                Console.WriteLine("Парирование не удалось!");
                return false;
            }
        }

        public static short MagicDamage(Character attacker, Character victim, short spellPower)
        {
            float crit = CheckCrit(attacker, true);
            float att = spellPower + attacker.TotalArcane + crit;

            //  Урон по врагу с магической защитой
            short damage = CheckMagicDefense(victim, att);

            return damage;
        }

        //  Проверка на крит
        public static int CheckCrit(Character cha, bool magic = false)
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
                if (rand.NextDouble() <= cha.TotalMagicDefense)
                    crit = (int)(cha.TotalArcane * (rand.Next(MinCritChance, MaxCritChance) * 0.1));
            }            

            return crit;
        }

        //  Проверка на защиту и блок
        public static short CheckDefence(Character charecter, float att)
        {
            if (charecter.Condition.ShieldUp)
                att = att * (1 - charecter.TotalBlock) + (1 - charecter.TotalDefense);
            else
                att = att * (1 - charecter.TotalDefense);

            return (short) att;
        }

        //  Проверка на магическую защиту
        public static short CheckMagicDefense(Character enemy, float att)
        {
            att = att * (1 - enemy.TotalMagicDefense);
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

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static bool CheckMana(Character character, short cost)
        {
            if (character.MP >= cost)
            {
                character.MP -= cost;
                return true;
            }
            else
                return false;
        }
        #endregion

        //  Вероятность события
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
        public static void DoScale(sbyte lvlScale, Character enemy)
        {
            Random rand = new Random();

            enemy.HP = ScaleMAXHP(lvlScale, enemy.HP);
            if (enemy.Wild)
                enemy.MaxHp = (short)(ScaleMAXHP(lvlScale, enemy.HP) * rand.Next(2, 3));
            else
                enemy.MaxHp = ScaleMAXHP(lvlScale, enemy.HP);
            enemy.Attack = ScaleATT(lvlScale, enemy.Attack);
        }

        //  Скейл параметров противника от уровня героя
        public static short ScaleMAXHP(sbyte lvlScale, short x) => (short)((lvlScale * 1.5) + x);

        //  Скейл параметров противника от уровня героя
        public static short ScaleATT(sbyte lvlScale, short x) => (short)((lvlScale * 0.5) + x);

        //TODO Разобраться что это такое
        public bool Equals(Unit unit1, Unit unit2)
        {
            return
                unit1.Name == unit2.Name &&
                unit1.Phase == unit2.Phase &&
                unit1.HP == unit2.HP &&
                unit1.Attack == unit2.Attack &&
                unit1.Speed == unit2.Speed &&
                unit1.Crit == unit2.Crit &&
                unit1.Defense == unit2.Defense &&
                unit1.MagicDefense == unit2.MagicDefense &&
                unit1.Block == unit2.Block &&
                unit1.Moves == unit2.Moves &&
                unit1.CantRunBattle == unit2.CantRunBattle &&
                unit1.Role == unit2.Role &&
                unit1.Strategy == unit2.Strategy;
        }

        //TODO Разобраться что это такое
        public int GetHashCode(Unit obj)
        {
            return
                obj.Name.GetHashCode() ^
                obj.Phase.GetHashCode() ^
                obj.HP.GetHashCode() ^
                obj.Attack.GetHashCode() ^
                obj.Speed.GetHashCode() ^
                obj.Crit.GetHashCode() ^
                obj.Defense.GetHashCode() ^
                obj.MagicDefense.GetHashCode() ^
                obj.Block.GetHashCode() ^
                obj.Moves.GetHashCode() ^
                obj.CantRunBattle.GetHashCode() ^
                obj.Role.GetHashCode() ^
                obj.Strategy.GetHashCode();
        }
        #endregion

        #region Проверки для карты
        public static bool CurrentCoordinate(int x, int y) => Map.playerX == x && Map.playerY == y;

        public static bool CurrentCoordinates(params (int,int)[] coordinates)
        {
            foreach (var cor in coordinates)
            {
                if (CurrentCoordinate(cor.Item1, cor.Item2))
                    return true;
            }
            return false;

            //var conditions = new List<bool>
            //{
            //    (playerX == 4 && playerY == 4),
            //    (playerX == 5 && playerY == 5)
            //};
            //return conditions.Any(c => c);
        }
        #endregion
    }
}                  