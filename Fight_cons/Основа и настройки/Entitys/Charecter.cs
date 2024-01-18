﻿using Fight_cons.Основа_и_настройки;
using System;

namespace Fight_cons
{
    public delegate void SkillsDele(Hero hero, Charecter enemy);
    public delegate void SpellDele(Hero hero, Charecter enemy, int cost, int power);

    public abstract class Charecter : Characteristics
    {
        internal protected int Id;
        internal protected int TotalHP
        {
            get => (int)(HP + HeroWeapon.HP + HeroArmor.HP + Conditions.HP + PermanentBonuses.HP);
        }
        internal protected int TotalMaxHP
        {
            get => (int)(MaxHp + HeroWeapon.MaxHp + HeroArmor.MaxHp + Conditions.MaxHp + PermanentBonuses.MaxHp);
        }
        internal protected int TotalMP
        {
            get => (int)(MP + HeroWeapon.MP + HeroArmor.MP + Conditions.MP + PermanentBonuses.MP);
        }
        internal protected int TotalMaxMP
        {
            get => (int)(MaxMp + HeroWeapon.MaxMp + HeroArmor.MaxMp + Conditions.MaxMp + PermanentBonuses.MaxMp);
        }
        internal protected int TotalAttack
        {
            get => (int)(Attack + HeroWeapon.Attack + HeroArmor.Attack + Conditions.Attack + PermanentBonuses.Attack);
        }
        internal protected int TotalArcane
        {
            get => (int)(Arcane + HeroWeapon.Arcane + HeroArmor.Arcane + Conditions.Arcane + PermanentBonuses.Arcane);
        }
        internal protected double TotalSpeed 
        {
            get => Speed + HeroWeapon.Speed + HeroArmor.Speed + Conditions.Speed + PermanentBonuses.Speed;
        }
        internal protected  double TotalCrit 
        {
            get => Crit + HeroWeapon.Crit + HeroArmor.Crit + Conditions.Crit + PermanentBonuses.Crit;
        }
        internal protected double TotalDefence
        {
            get => Defence + HeroWeapon.Defence + HeroArmor.Defence + Conditions.Defence + PermanentBonuses.Defence;
        }
        internal protected double TotalMagicDefence
        {
            get => MagicDefence + HeroWeapon.MagicDefence + HeroArmor.MagicDefence + Conditions.MagicDefence + PermanentBonuses.MagicDefence;
        }
        internal protected double TotalBlock 
        {
            get => Block + HeroWeapon.Block + HeroArmor.Block + Conditions.Block + PermanentBonuses.Block;
        }
        internal protected int TotalMaxMoves 
        {
            get => MaxMoves + HeroWeapon.MaxMoves + HeroArmor.MaxMoves + Conditions.MaxMoves + PermanentBonuses.MaxMoves;
        }

        //  Характеристики 
        //internal Characteristics characteristics = new Characteristics();

        //  Баффы и дебаффы от состояний, перманентных бонусов и классовых бонусов
        internal Condition Conditions = new Condition();
        internal PermanentBonus PermanentBonuses = new PermanentBonus();
        internal CharecterClass ClassBonuses = new CharecterClass("No class", 0);

        internal Weapon HeroWeapon = new Weapon(name: "Кулаки", attack: 1, speed: 0.2, cost: 0, crit: 0, block: 0, maxMoves: 2);
        internal Armor HeroArmor = new Armor("Без брони", 0, 0);        

        //  Сбежать с боя
        internal protected bool Run = false;

        //  Текущий ход
        internal protected int Turn;

        #region Костыли
        //  Временные Костыли!!!
        //  Общие
        internal protected sbyte? Phase;

        internal bool IsPlayer;
        public bool IsAlive = true;
        public bool IsEnemy = false;
        public enum ChaRole
        {
            Hero = 0,
            Ally = 1,
            Enemy = 2,
            Wild = 3
        }
        public ChaRole Role;

        internal protected bool No_run;

        internal protected bool Wild;

        internal protected int KillExp;
        public enum Strategeis
        {
            Any = 0,
            Agresive = 1,
            Mage = 2,
            Necromancer = 3,
            Healer = 4
        }
        public Strategeis strategeis = new Strategeis();
        #endregion

        //  МЕТОДЫ
        //  Шкала здоровья
        public void HPBar(bool next = false)
        {
            double part = TotalMaxHP / 10.0, c = 0;

            if (!next)
                Console.Write("\n");

            Console.Write($"{Output.HPSymbol}: [");
            while (c <= TotalMaxHP)
            {
                if (c <= TotalHP)
                    Output.WriteColorLine(Output.unitHPColor(IsEnemy), "", "#");
                else
                    Output.WriteColorLine(ConsoleColor.Black, "", "#");
                c += part;
            }

            Console.Write("]    ");
            Console.Write($"{Output.HPSymbol}: {TotalHP}/{TotalMaxHP}");
        }

        //  Шкала маны
        public void MPBar()
        {
            if (TotalMaxMP > 0)
            {
                double part = TotalMaxMP / 10.0, c = 0;

                Console.Write($"\n{Output.MPSymbol}: [");
                while (c <= TotalMaxMP)
                {
                    if (TotalMP == 0)
                        Output.WriteColorLine(ConsoleColor.Black, "", "#");
                    else if (c <= TotalMP)
                        Output.WriteColorLine(ConsoleColor.Blue, "", "#");
                    else
                        Output.WriteColorLine(ConsoleColor.Black, "", "#");
                    c += part;
                }

                Console.Write("]    ");
                Console.Write($"{Output.MPSymbol}: {MP}/{TotalMaxMP}\n");
            }
            else
                Output.WriteColorLine(ConsoleColor.Blue, $"\n{Output.MPSymbol}: [", " нет маны ", "]\n");
        }

        public void PhaseHPBar()
        {
            double part = TotalMaxHP / 20.0;
            double c = 0;
            //  Для корректного отображения 4 фазы
            bool eng = false;
            sbyte phase4 = 0;
            int charsToNextBar = 0;

            Console.Write($"{Output.HPSymbol}: [");
            while (c <= TotalMaxHP)
            {
                if (c <= TotalHP)
                {
                    if (Phase == 2 && charsToNextBar == 10) // Для фазы 2
                    {
                        Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                        charsToNextBar = 0;
                    }
                    else if (Phase == 3 && charsToNextBar == 7) // Для фазы 3
                    {
                        Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                        charsToNextBar = 0;
                    }
                    else if (!eng)
                    {
                        if (phase4 == 3)
                            eng = true;
                        if (Phase == 4 && charsToNextBar == 5) // Для фазы 4
                        {
                            Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                            charsToNextBar = 0;
                            phase4++;
                        }
                    }

                    Output.WriteColorLine(Output.unitHPColor(IsEnemy), "", "#", "");
                    charsToNextBar++;
                }
                else
                {
                    Output.WriteColorLine(ConsoleColor.Black, "", "#");
                    c += part;
                }

                c += part;
            }

            Console.Write("]    ");
            Console.Write($"{Output.HPSymbol}: {TotalHP}/{TotalMaxHP}");
        }
    }
}
