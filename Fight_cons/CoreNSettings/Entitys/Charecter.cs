using FightCons.CoreNSettings;
using FightCons.Enemies;
using System;
using static FightCons.ItemChar;

namespace FightCons
{
    public delegate void SkillsDele(Hero hero, Character enemy);
    public delegate void SpellDele(Hero hero, Character enemy, short cost, sbyte spellPower);
    public delegate void SpecialDele(Hero hero, Character enemy);

    public abstract class Character : Characteristics
    {
        internal protected short Id;

        #region Окончательные характеристики 
        internal protected short TotalHP
        {
            get => (short)(HP + CharacterWeapon.HP + CharacterArmor.HP + Condition.HP + PermanentBonus.HP);
        }
        internal protected short TotalMaxHP
        {
            get => (short)(MaxHp + CharacterWeapon.MaxHp + CharacterArmor.MaxHp + Condition.MaxHp + PermanentBonus.MaxHp);
        }
        internal protected short TotalMP
        {
            get => (short)(MP + CharacterWeapon.MP + CharacterArmor.MP + Condition.MP + PermanentBonus.MP);
        }
        internal protected short TotalMaxMP
        {
            get => (short)(MaxMp + CharacterWeapon.MaxMp + CharacterArmor.MaxMp + Condition.MaxMp + PermanentBonus.MaxMp);
        }
        internal protected short TotalAttack
        {
            get => (short)(Attack + CharacterWeapon.Attack + CharacterArmor.Attack + Condition.Attack + PermanentBonus.Attack);
        }
        internal protected short TotalArcane
        {
            get => (short)(Arcane + CharacterWeapon.Arcane + CharacterArmor.Arcane + Condition.Arcane + PermanentBonus.Arcane);
        }
        internal protected float TotalSpeed
        {
            get => Speed + CharacterWeapon.Speed + CharacterArmor.Speed + Condition.Speed + PermanentBonus.Speed;
        }
        internal protected float TotalCrit
        {
            get => Crit + CharacterWeapon.Crit + CharacterArmor.Crit + Condition.Crit + PermanentBonus.Crit;
        }
        internal protected float TotalDefence
        {
            get => Defense + CharacterWeapon.Defense + CharacterArmor.Defense + Condition.Defense + PermanentBonus.Defense;
        }
        internal protected float TotalMagicDefence
        {
            get => MagicDefense + CharacterWeapon.MagicDefense + CharacterArmor.MagicDefense + Condition.MagicDefense + PermanentBonus.MagicDefense;
        }
        internal protected float TotalBlock
        {
            get => Block + CharacterWeapon.Block + CharacterArmor.Block + Condition.Block + PermanentBonus.Block;
        }
        internal protected sbyte TotalMaxMoves
        {
            get => (sbyte)(Moves + CharacterWeapon.Moves + CharacterArmor.Moves + Condition.Moves + PermanentBonus.Moves);
        }
        #endregion

        //  Баффы и дебаффы от состояний, перманентных бонусов и классовых бонусов
        internal CharacterProfiles CharacterProfile = new CharacterProfiles();
        internal Conditions Condition = new Conditions();
        internal PermanentBonuses PermanentBonus = new PermanentBonuses();
        internal CharacterClasses CharacterClass = new CharacterClasses("No class", 0);
        internal Statistic Statistic = new Statistic();

        internal ItemChar CharacterWeapon = new ItemChar(name: "Без оружия", itemType: ItemTyps.Weapon,  attack: 1, speed: 0.2f, cost: 0, crit: 0, block: 0, maxMoves: 2);
        internal ItemChar CharacterArmor = new ItemChar("Без брони", itemType: ItemTyps.Armor, 0, 0);        

        //  Текущий ход
        internal protected int Turn;

        internal protected int KillExp;

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
                    Output.WriteColorLine(Output.unitHPColor(CharacterProfile.Role), "", "#");
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

        //  Выбор отрисовки
        public void DifferentHpBar()
        {
            //Output.WriteColorName("\n", this, ":");
            if (CharacterProfile.Phase >= 2)
                PhaseHPBar();
            else
                HPBar();
        }

        //  Шкала с фазами
        public void PhaseHPBar()
        {
            double part = TotalMaxHP / 20.0;
            double c = 0;
            //  Для корректного отображения 4 фазы
            bool eng = false;
            sbyte phase4 = 0;
            int charsToNextBar = 0;

            Console.Write($"\n{Output.HPSymbol}: [");
            while (c <= TotalMaxHP)
            {
                if (c <= TotalHP)
                {
                    if (CharacterProfile.Phase == 2 && charsToNextBar == 10) // Для фазы 2
                    {
                        Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                        charsToNextBar = 0;
                    }
                    else if (CharacterProfile.Phase == 3 && charsToNextBar == 7) // Для фазы 3
                    {
                        Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                        charsToNextBar = 0;
                    }
                    else if (!eng)
                    {
                        if (phase4 == 3)
                            eng = true;
                        if (CharacterProfile.Phase == 4 && charsToNextBar == 5) // Для фазы 4
                        {
                            Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                            charsToNextBar = 0;
                            phase4++;
                        }
                    }

                    Output.WriteColorLine(Output.unitHPColor(CharacterProfile.Role), "", "#", "");
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

        //TODO механика скрыть от пользователя HP или MP
        //  Отобразить HP и MP (MP опционально)
        public void HPnMPBar(bool hp = false, bool mp = false)
        {
            if (hp || mp)
            {
                if (hp)
                    DifferentHpBar();
                if (mp)
                    MPBar();
            }
            else
            {
                Output.WriteColorLine(ConsoleColor.DarkGray, $"\n{Output.HPSymbol}: [", "НЕИЗВЕСТНО", "]");
                Output.WriteColorLine(ConsoleColor.DarkGray, $"\n{Output.MPSymbol}: [", "НЕИЗВЕСТНО", "]\n");
            }
        }
    }
}
