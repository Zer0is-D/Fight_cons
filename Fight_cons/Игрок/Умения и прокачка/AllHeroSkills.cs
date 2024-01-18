using Fight_cons.Основа_и_настройки;
using System.Linq;

namespace Fight_cons
{
    class AllHeroSkills
    {
        //  Фиксированные навыки
        public static void Skills(Hero hero, Charecter enemy)
        {
            double finalDam = GameFormulas.CheckDefence(enemy, hero.TotalAttack);

            AttackDes Attac = new AttackDes(hero, "Обычная атака")
            {
                Attack = AttackDes.BaseAttack,
                Description = $"Атаковать ({(int)finalDam} {Output.AttackStr} | {Output.CritStr}: {hero.TotalCrit * 100}%)"
            };

            AttackDes Attac_breanch = new AttackDes(hero, "Пробитие")
            {
                Attack = AttackDes.BreachArmorAttack,
                Description = $"Пробитие брони и защиты ({(int)(hero.TotalAttack / 1.5)} {Output.AttackStr})"
            };

            //  Способность: Кровотечение
            if (hero.HeroStatistic.Attacks >= 10)
            {
                AttackDes Attac_bleed = new AttackDes(hero, "Вызвать кровотечение")
                {
                    Attack = AttackDes.MakeBleedAttack,
                    Description = $"Вызвать кровотечение ({hero.TotalAttack / 2} {Output.AttackStr} | {Condition.BleedDmg} {Output.DmgSymbol}/3 ХОДА)"
                };
            }

            //  Способность: Парирование
            if (hero.HeroStatistic.Attacks >= 15)
            {
                AttackDes Attac_Parry = new AttackDes(hero, "Парировать")
                {
                    Attack = AttackDes.ParryAttack,
                    Description = $"Парировать атаку ({hero.TotalSpeed * 100}% МЕТ)"//////////////////////////////////////////////////////////////
                };
            }

            SpellDes Cleansing_ray = new SpellDes(hero, "Очищающий луч")
            {
                Spell = SpellDes.CleansingRaySpell,
                SpellСost = 5,
                SpellPower = 10
            };
            Cleansing_ray.Description = $"Очищающий луч ({Cleansing_ray.SpellPower + hero.TotalArcane} {Output.AttackStr} | МЕТ {(enemy.TotalSpeed - 1) * 100}% | {Cleansing_ray.SpellСost} {Output.MPSymbol})";

            //  Способность: Малое лечение
            if (hero.HeroStatistic.Spells >= 5)
            {
                SpellDes Healing = new SpellDes(hero, "Малое лечение")
                {
                    Spell = SpellDes.HealSpell,
                    SpellСost = 3
                };
                Healing.Description = $"Малое лечение (+30% {Output.HPSymbol} | {Healing.SpellСost} {Output.MPSymbol})";
            }

            //  Способность: Кровотечение
            if (hero.HeroStatistic.Attacks >= 10)
            {
                AttackDes Attac_bleed = new AttackDes(hero, "Вызвать кровотечение")
                {
                    Attack = AttackDes.MakeBleedAttack,
                    Description = $"Вызвать кровотечение ({hero.TotalAttack / 2} {Output.AttackStr} | {Condition.BleedDmg} {Output.DmgSymbol}/3 ХОДА)"
                };
            }

            Clear_dub(hero, enemy);
        }

        //  Чистка от дубликатов
        public static void Clear_dub(Hero hero, Charecter enemy)
        {
            //  Чистка заклинаний
            //  По схожему описанию
            hero.SpellList = hero.SpellList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            //  По схожему имени
            hero.SpellList = hero.SpellList.GroupBy(x => x.Name).Select(x => x.First()).Distinct().ToList();

            //  Чистка атак
            //  По схожему описанию
            hero.AttackList = hero.AttackList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            //  По схожему имени
            hero.AttackList = hero.AttackList.GroupBy(x => x.Name).Select(x => x.First()).Distinct().ToList();
        }

        //  Первоначальные навыки героя
        public static void Skills(Hero hero, int i)
        {
            if (i == 1)
            {
                AttackDes Attac = new AttackDes(hero, "Обычная атака")
                {
                    Attack = AttackDes.BaseAttack,
                    Description = $"Атаковать ({hero.TotalAttack} {Output.AttackStr} | {Output.CritStr}: {hero.TotalCrit * 100}%)"
                };

                AttackDes Attac_breanch = new AttackDes(hero, "Пробитие")
                {
                    Attack = AttackDes.BreachArmorAttack,
                    Description = $"Пробитие брони и защиты ({hero.TotalAttack} {Output.AttackStr})"
                };

                PotionDes Heal_potion = new PotionDes(hero)
                {
                    Name = "Зелье лечения",
                    Potion = PotionDes.HealPotion,
                    Description = "Зелье лечения",
                };
                Heal_potion.Count = 1;

                PotionDes Mana_potion = new PotionDes(hero)
                {
                    Name = "Зелье маны",
                    Potion = PotionDes.ManaPotion,
                    Description = "Зелье маны",
                };
                Mana_potion.Count = 1;

                PotionDes Anti_potion = new PotionDes(hero)
                {
                    Name = "Противоядие",
                    Potion = PotionDes.ManaPotion,
                    Description = "Противоядие"
                };

                PotionDes Power_potion = new PotionDes(hero)
                {
                    Name = "Зелье силы",
                    Potion = PotionDes.PowerPotion,
                    Description = "Зелье силы"
                };
                Power_potion.Count = 1;
            }

            hero.AttackList = hero.AttackList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            hero.PotionList = hero.PotionList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
        }
    }
}
