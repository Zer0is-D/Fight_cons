using FightCons.CoreNSettings;
using FightCons.Player.SkillsNLvl;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using static FightCons.ItemChar;

namespace FightCons
{
    public delegate void SkillsDele(Hero hero, Character enemy);
    public delegate void SpellDele(Hero hero, Character enemy, short cost, sbyte spellPower);
    public delegate void SpecialDele(Hero hero, Character enemy);

    //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
    public delegate void SkillsDeleParty(Character сharacter, Character enemy);
    public delegate void SpellDeleParty(Character сharacter, Character enemy, short cost, sbyte spellPower);
    public delegate void SpecialDeleParty(Character сharacter, Character enemy);

    public abstract class Character : Characteristics
    {
        public bool IsPlayer { get; set; }
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
        internal protected float TotalDefense
        {
            get => Defense + CharacterWeapon.Defense + CharacterArmor.Defense + Condition.Defense + PermanentBonus.Defense;
        }
        internal protected float TotalMagicDefense
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

        //  Боевые навыки героя
        private protected List<AttackDes> _characterSkills = new List<AttackDes>();
        internal protected List<AttackDes> AttackList
        {
            get => _characterSkills;
            set => _characterSkills = value;
        }

        //  Заклинания героя
        private protected List<SpellDes> _characterSpells = new List<SpellDes>();
        internal protected List<SpellDes> SpellList
        {
            get => _characterSpells;
            set => _characterSpells = value;
        }

        //  Особые боевые навыки героя
        private protected List<SpecialDes> _characterSpecials = new List<SpecialDes>();
        internal protected List<SpecialDes> SpecialList
        {
            get => _characterSpecials;
            set => _characterSpecials = value;
        }

        //  Зелья героя
        private protected List<PotionDes> _characterPotions = new List<PotionDes>();
        internal protected List<PotionDes> PotionList
        {
            get => _characterPotions;
            set => _characterPotions = value;
        }

        internal protected sbyte? Phase;

        internal protected bool CantRunBattle { get; set; }

        internal protected bool Wild;

        public enum ChaRole
        {
            Hero = 0,
            Ally = 1,
            Enemy = 2,
            Wild = 3
        }
        public ChaRole Role;

        public enum Strategies
        {
            Any = 0,
            Aggressive = 1,
            Mage = 2,
            Necromancer = 3,
            Healer = 4,
            BeastMaster = 5
        }
        public Strategies Strategy = new Strategies();

        //  Баффы и дебаффы от состояний, перманентных бонусов и классовых бонусов
        internal PermanentBonuses PermanentBonus = new PermanentBonuses();
        internal Conditions Condition = new Conditions();
        internal Statistic Statistic = new Statistic();

        internal ItemChar CharacterWeapon = new ItemChar(name: "Без оружия", itemType: ItemTypes.Weapon,  attack: 1, speed: 0.2f, cost: 0, crit: 0, block: 0, maxMoves: 2);
        internal ItemChar CharacterArmor = new ItemChar("Без брони", itemType: ItemTypes.Armor, 0, 0);        

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
                    Output.WriteColorLine(Output.unitHPColor(Role), "", "#");
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
            if (Phase >= 2)
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

                    Output.WriteColorLine(Output.unitHPColor(Role), "", "#", "");
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
