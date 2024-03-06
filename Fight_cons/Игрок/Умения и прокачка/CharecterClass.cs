using Fight_cons.Основа_и_настройки;
using System;

namespace Fight_cons
{
    //  Бонусы от класса
    internal class CharecterClass : Characteristics
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

        public CharecterClass(string name, params float[] Cha)
        {
            Name = name;
        }

        public static void GiveHeroClass(Hero hero)
        {
            //HeroClass heroClass = new HeroClass("Воин", hero.ClassBonuses.MaxHp += 1, );

            string quo = "Выберите класс:\n"
              + $"1) Воин (Упор на {Output.HPSymbol}, {Output.AttackStr}, {Output.DefenceStr})\n"
              + $"2) Волшебник (Упор на {Output.ArcaneStr}, {Output.MagicDefenceStr}, {Output.MPSymbol})\n"
              + $"3) Ловкач (Упор на {Output.CritStr}, {Output.SpeedStr}, {Output.BlockStr})\n";

            switch (Input.ChoisInput(hero, 0, 3, quo))
            {
                case 1:
                    hero.Class_name = "Воин";
                    hero.ClassBonuses.MaxHp += 5;
                    hero.ClassBonuses.Attack += 1;
                    hero.ClassBonuses.Defence += 0.01f;
                    break;

                case 2:
                    hero.Class_name = "Волшебник";
                    hero.ClassBonuses.Arcane += 1;
                    hero.ClassBonuses.MagicDefence += 0.01f;
                    hero.ClassBonuses.MaxMp += 5;
                    break;

                case 3:
                    hero.Class_name = "Ловкач";
                    hero.ClassBonuses.Crit += 0.01f;
                    hero.ClassBonuses.Speed += 0.01f;
                    hero.ClassBonuses.Block += 0.01f;
                    break;
            }

            //  Выдать начальные навыки
            AllHeroSkills.Skills(hero, 1);
        }
    }
}
