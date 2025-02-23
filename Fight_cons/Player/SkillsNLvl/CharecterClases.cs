using FightCons.CoreNSettings;
using System;
using static FightCons.Charecter;

namespace FightCons
{
    //  Бонусы от класса
    internal class CharecterClases : Characteristics
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
            Fither = 1,
            Wisard = 2,
            Rouge = 3            
        }
        public ChaClass Class;

        public CharecterClases(string name, params float[] Cha)
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
                    hero.CharecterClass.Class = ChaClass.NoMan;
                    break;
                case 1:
                    hero.CharecterClass.Class = ChaClass.Fither;
                    break;

                case 2:
                    hero.CharecterClass.Class = ChaClass.Wisard;
                    break;

                case 3:
                    hero.CharecterClass.Class = ChaClass.Rouge;
                    break;
            }

            ChainClassAndCharecther(hero);

            //  Выдать начальные навыки
            AllHeroSkills.Skills(hero, 1);
        }

        private static void ChainClassAndCharecther(Hero hero)
        {
            switch (hero.CharecterClass.Class)
            {
                case ChaClass.NoMan:
                    hero.ClassName = "Свобода";                    
                    break;

                case ChaClass.Fither:
                    hero.ClassName = "Мощь";
                    hero.CharecterClass.MaxHp += 5;
                    hero.CharecterClass.Attack += 1;
                    hero.CharecterClass.Defence += 0.01f;
                    break;

                case ChaClass.Wisard:
                    hero.ClassName = "Комбинатор";
                    hero.CharecterClass.Arcane += 1;
                    hero.CharecterClass.MagicDefence += 0.01f;
                    hero.CharecterClass.MaxMp += 5;
                    break;

                case ChaClass.Rouge:
                    hero.ClassName = "Динамика";
                    hero.CharecterClass.Crit += 0.01f;
                    hero.CharecterClass.Speed += 0.01f;
                    hero.CharecterClass.Block += 0.01f;
                    break;
            }
        }
    }
}
