using Fight_cons.Основа_и_настройки;
using System;
using static Fight_cons.ItemChar;

namespace Fight_cons
{
    public delegate void SkillsDele(Hero hero, Charecter enemy);
    public delegate void SpellDele(Hero hero, Charecter enemy, short cost, sbyte spellPower);

    public abstract class Charecter : Characteristics
    {
        internal protected short Id;

        #region Окончательные характеристики 
        internal protected short TotalHP
        {
            get => (short)(HP + CharecterWeapon.HP + CharecterArmor.HP + Condition.HP + PermanentBonus.HP);
        }
        internal protected short TotalMaxHP
        {
            get => (short)(MaxHp + CharecterWeapon.MaxHp + CharecterArmor.MaxHp + Condition.MaxHp + PermanentBonus.MaxHp);
        }
        internal protected short TotalMP
        {
            get => (short)(MP + CharecterWeapon.MP + CharecterArmor.MP + Condition.MP + PermanentBonus.MP);
        }
        internal protected short TotalMaxMP
        {
            get => (short)(MaxMp + CharecterWeapon.MaxMp + CharecterArmor.MaxMp + Condition.MaxMp + PermanentBonus.MaxMp);
        }
        internal protected short TotalAttack
        {
            get => (short)(Attack + CharecterWeapon.Attack + CharecterArmor.Attack + Condition.Attack + PermanentBonus.Attack);
        }
        internal protected short TotalArcane
        {
            get => (short)(Arcane + CharecterWeapon.Arcane + CharecterArmor.Arcane + Condition.Arcane + PermanentBonus.Arcane);
        }
        internal protected float TotalSpeed
        {
            get => Speed + CharecterWeapon.Speed + CharecterArmor.Speed + Condition.Speed + PermanentBonus.Speed;
        }
        internal protected float TotalCrit
        {
            get => Crit + CharecterWeapon.Crit + CharecterArmor.Crit + Condition.Crit + PermanentBonus.Crit;
        }
        internal protected float TotalDefence
        {
            get => Defence + CharecterWeapon.Defence + CharecterArmor.Defence + Condition.Defence + PermanentBonus.Defence;
        }
        internal protected float TotalMagicDefence
        {
            get => MagicDefence + CharecterWeapon.MagicDefence + CharecterArmor.MagicDefence + Condition.MagicDefence + PermanentBonus.MagicDefence;
        }
        internal protected float TotalBlock
        {
            get => Block + CharecterWeapon.Block + CharecterArmor.Block + Condition.Block + PermanentBonus.Block;
        }
        internal protected sbyte TotalMaxMoves
        {
            get => (sbyte)(Moves + CharecterWeapon.Moves + CharecterArmor.Moves + Condition.Moves + PermanentBonus.Moves);
        }
        #endregion

        //  Баффы и дебаффы от состояний, перманентных бонусов и классовых бонусов
        internal CharecterProfiles CharecterProfile = new CharecterProfiles();
        internal Conditions Condition = new Conditions();
        internal PermanentBonuses PermanentBonus = new PermanentBonuses();
        internal CharecterClases CharecterClass = new CharecterClases("No class", 0);
        internal Statistic Statistic = new Statistic();

        internal ItemChar CharecterWeapon = new ItemChar(name: "Кулаки", itemType: ItemTyps.Weapon,  attack: 1, speed: 0.2f, cost: 0, crit: 0, block: 0, maxMoves: 2);
        internal ItemChar CharecterArmor = new ItemChar("Без брони", itemType: ItemTyps.Armor, 0, 0);        

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
                    Output.WriteColorLine(Output.unitHPColor(CharecterProfile.Role), "", "#");
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
                    if (CharecterProfile.Phase == 2 && charsToNextBar == 10) // Для фазы 2
                    {
                        Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                        charsToNextBar = 0;
                    }
                    else if (CharecterProfile.Phase == 3 && charsToNextBar == 7) // Для фазы 3
                    {
                        Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                        charsToNextBar = 0;
                    }
                    else if (!eng)
                    {
                        if (phase4 == 3)
                            eng = true;
                        if (CharecterProfile.Phase == 4 && charsToNextBar == 5) // Для фазы 4
                        {
                            Output.WriteColorLine(ConsoleColor.Yellow, "", "|");
                            charsToNextBar = 0;
                            phase4++;
                        }
                    }

                    Output.WriteColorLine(Output.unitHPColor(CharecterProfile.Role), "", "#", "");
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
