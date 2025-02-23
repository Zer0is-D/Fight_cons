using FightСons.CoreNSettings;
using System.Linq;

namespace FightСons
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

            AttackDes AttacBreanch = new AttackDes(hero, "Пробитие")
            {
                Attack = AttackDes.BreachArmorAttack,
                Description = $"Пробитие брони и защиты ({(int)(hero.TotalAttack / 1.5)} {Output.AttackStr})"
            };

            //  Способность: Кровотечение
            if (hero.Statistic.Attacks >= 10)
            {
                AttackDes AttacBleed = new AttackDes(hero, "Вызвать кровотечение")
                {
                    Attack = AttackDes.MakeBleedAttack,
                    Description = $"Вызвать кровотечение ({hero.TotalAttack / 2} {Output.AttackStr} | {Conditions.BleedDmg} {Output.DmgSymbol}/3 ХОДА)"
                };
            }

            //  Способность: Парирование
            if (hero.Statistic.Attacks >= 15)
            {
                AttackDes AttacParry = new AttackDes(hero, "Парировать")
                {
                    Attack = AttackDes.ParryAttack,
                    Description = $"Парировать атаку ({hero.TotalSpeed * 100}% МЕТ)"//////////////////////////////////////////////////////////////
                };
            }

            SpellDes CleansingRay = new SpellDes(hero, "Очищающий луч")
            {
                Spell = SpellDes.CleansingRaySpell,
                SpellСost = 5,
                SpellPower = 10
            };
            CleansingRay.Description = $"Очищающий луч ({CleansingRay.SpellPower + hero.TotalArcane} {Output.AttackStr} | МЕТ {(enemy.TotalSpeed - 1) * 100}% | {CleansingRay.SpellСost} {Output.MPSymbol})";

            //  Способность: Малое лечение
            if (hero.Statistic.Spells >= 5)
            {
                SpellDes Healing = new SpellDes(hero, "Малое лечение")
                {
                    Spell = SpellDes.HealSpell,
                    SpellСost = 3
                };
                Healing.Description = $"Малое лечение (+30% {Output.HPSymbol} | {Healing.SpellСost} {Output.MPSymbol})";
            }

            //  Способность: Кровотечение
            if (hero.Statistic.Attacks >= 10)
            {
                AttackDes AttacBleed = new AttackDes(hero, "Вызвать кровотечение")
                {
                    Attack = AttackDes.MakeBleedAttack,
                    Description = $"Вызвать кровотечение ({hero.TotalAttack / 2} {Output.AttackStr} | {Conditions.BleedDmg} {Output.DmgSymbol}/3 ХОДА)"
                };
            }

            ClearDuplicat(hero, enemy);
        }

        //  Чистка от дубликатов
        public static void ClearDuplicat(Hero hero, Charecter enemy)
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

                AttackDes AttacBreanch = new AttackDes(hero, "Пробитие")
                {
                    Attack = AttackDes.BreachArmorAttack,
                    Description = $"Пробитие брони и защиты ({hero.TotalAttack} {Output.AttackStr})"
                };

                PotionDes HealPotion = new PotionDes(hero)
                {
                    Name = "Зелье лечения",
                    Potion = PotionDes.HealPotion,
                    Description = "Зелье лечения",
                };
                HealPotion.Count = 1;

                PotionDes ManaPotion = new PotionDes(hero)
                {
                    Name = "Зелье маны",
                    Potion = PotionDes.ManaPotion,
                    Description = "Зелье маны",
                };
                ManaPotion.Count = 1;

                PotionDes AntiPotion = new PotionDes(hero)
                {
                    Name = "Противоядие",
                    Potion = PotionDes.ManaPotion,
                    Description = "Противоядие"
                };

                PotionDes PowerPotion = new PotionDes(hero)
                {
                    Name = "Зелье силы",
                    Potion = PotionDes.PowerPotion,
                    Description = "Зелье силы"
                };
                PowerPotion.Count = 1;
            }

            hero.AttackList = hero.AttackList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            hero.PotionList = hero.PotionList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
        }
    }
}
