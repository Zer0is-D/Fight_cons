using FightCons.CoreNSettings;
using System;
using static FightCons.Character;

namespace FightCons
{
    //  Бонусы от класса
    internal class CharacterClasses : Characteristics
    {
        internal protected new short HP
        {
            get => this.MaxHp;
            set => this.MaxHp = value;
        }
        internal protected new short MP
        {
            get => this.MaxMp;
            set => this.MaxMp = value;
        }
        public enum ChaClass
        {
            NoMan = 0,
            Fighter = 1,
            Wizard = 2,
            Rouge = 3            
        }
        public ChaClass Class;

        public CharacterClasses(string name, params float[] Cha)
        {
            Name = name;
        }

        public static void GiveHeroClass(Hero hero)
        {
            //HeroClass heroClass = new HeroClass("Воин", hero.ClassBonuses.MaxHp += 1, );

            string quo = "Выберите класс:\n"
              + $"1) Мощь (Упор на {Output.HPSymbol}, {Output.AttackStr}, {Output.DefenceStr})\n"
              + $"2) Комбинаторика (Упор на {Output.ArcaneStr}, {Output.MagicDefenceStr}, {Output.MPSymbol})\n"
              + $"3) Динамика (Упор на {Output.CritStr}, {Output.SpeedStr}, {Output.BlockStr})\n"
              + $"0) Свобода\n";


            switch (Input.ChoisInput(hero, 0, 3, quo))
            {
                case 0:
                    hero.CharacterClass.Class = ChaClass.NoMan;
                    break;
                case 1:
                    hero.CharacterClass.Class = ChaClass.Fighter;
                    break;

                case 2:
                    hero.CharacterClass.Class = ChaClass.Wizard;
                    break;

                case 3:
                    hero.CharacterClass.Class = ChaClass.Rouge;
                    break;
            }

            ChainClassAndCharacter(hero);

            //  Выдать начальные навыки
            AllHeroSkills.Skills(hero, 1);
        }

        private static void ChainClassAndCharacter(Hero hero)
        {
            switch (hero.CharacterClass.Class)
            {
                case ChaClass.NoMan:
                    hero.ClassName = "Свобода";                    
                    break;

                case ChaClass.Fighter:
                    hero.ClassName = "Мощь";
                    hero.CharacterClass.MaxHp += 5;
                    hero.CharacterClass.Attack += 1;
                    hero.CharacterClass.Defense += 0.01f;
                    break;

                case ChaClass.Wizard:
                    hero.ClassName = "Комбинатор";
                    hero.CharacterClass.Arcane += 1;
                    hero.CharacterClass.MagicDefense += 0.01f;
                    hero.CharacterClass.MaxMp += 5;
                    break;

                case ChaClass.Rouge:
                    hero.ClassName = "Динамика";
                    hero.CharacterClass.Crit += 0.01f;
                    hero.CharacterClass.Speed += 0.01f;
                    hero.CharacterClass.Block += 0.01f;
                    break;
            }
        }
    }
}
