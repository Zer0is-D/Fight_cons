using FightCons.CoreNSettings;
using FightCons.Player.SkillsNLvl;
using System.Linq;

namespace FightCons
{
    class AllHeroSkills
    {
        //  Фиксированные навыки
        public static void Skills(Hero hero, Character enemy)
        {
            double finalDam = GameFormulas.CheckDefence(enemy, hero.TotalAttack);

            #region Атаки
            AttackDes Attac = new AttackDes(hero, "Обычная атака")
            {
                AttackParty = AttackDes.BaseAttack,
                Description = $"Атаковать ({(int)finalDam} {Output.AttackStr} | {Output.CritStr}: {hero.TotalCrit * 100}%)"
            };

            AttackDes AttacBreanch = new AttackDes(hero, "Пробитие")
            {
                AttackParty = AttackDes.BreachArmorAttack,
                Description = $"Пробитие брони и защиты ({(short)((float)hero.TotalAttack / GameFormulas.ArmorFine)} {Output.AttackStr})"
            };

            //  Способность: Кровотечение
            if (hero.Statistic.Attacks >= 10)
            {
                AttackDes AttacBleed = new AttackDes(hero, "Вызвать кровотечение")
                {
                    AttackParty = AttackDes.MakeBleedAttack,
                    Description = $"Вызвать кровотечение ({hero.TotalAttack / 2} {Output.AttackStr} | {Conditions.BleedDmg} {Output.DmgSymbol}/3 ХОДА)"
                };

                //  Способность: Парирование (доработать)
                //if (hero.Statistic.Attacks >= 15)
                //{
                //    AttackDes AttacParry = new AttackDes(hero, "Парировать")
                //    {
                //        Attack = AttackDes.ParryAttack,
                //        Description = $"Парировать атаку ({hero.TotalSpeed * 100}% МЕТ)"//////////////////////////////////////////////////////////////
                //    };
                //}
            }
            #endregion

            #region Заклинания
            SpellDes CleansingRay = new SpellDes(hero, "Очищающий луч")
            {
                SpellParty = SpellDes.CleansingRaySpell,
                SpellСost = 5,
                SpellPower = 10
            };
            CleansingRay.Description = $"Очищающий луч ({CleansingRay.SpellPower + hero.TotalArcane} {Output.AttackStr} | МЕТ {(enemy.TotalSpeed - 1) * 100}% | {CleansingRay.SpellСost} {Output.MPSymbol})";

            //  Способность: Малое лечение
            if (hero.Statistic.Spells >= 5)
            {
                SpellDes Healing = new SpellDes(hero, "Малое лечение")
                {
                    SpellParty = SpellDes.HealSpell,
                    SpellСost = 3
                };
                Healing.Description = $"Малое лечение (+30% {Output.HPSymbol} | {Healing.SpellСost} {Output.MPSymbol})";
            }
            #endregion

            #region Особенности
            if (hero.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active)
            {
                SpecialDes SpecialBranch = new SpecialDes(hero, "Навык 'Штопор'")
                {
                    SpecialsParty = SpecialDes.SpecialBranch,
                    Description = $"'Вскрывает' броню противника"
                };
            }

            #endregion


            #region Зелья

            #endregion

            //  Не трогать
            ClearDuplicat(hero, enemy);
        }

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static void Skills(Character character, Character enemy)
        {
            double finalDam = GameFormulas.CheckDefence(enemy, character.TotalAttack);

            #region Атаки
            AttackDes Attac = new AttackDes(character, "Обычная атака")
            {
                AttackParty = AttackDes.BaseAttack,
                Description = $"Атаковать ({(int)finalDam} {Output.AttackStr} | {Output.CritStr}: {character.TotalCrit * 100}%)"
            };

            AttackDes AttacBreanch = new AttackDes(character, "Пробитие")
            {
                AttackParty = AttackDes.BreachArmorAttack,
                Description = $"Пробитие брони и защиты ({(int)(character.TotalAttack / 1.5)} {Output.AttackStr})"
            };

            //  Способность: Кровотечение
            if (character.Statistic.Attacks >= 10)
            {
                AttackDes AttacBleed = new AttackDes(character, "Вызвать кровотечение")
                {
                    AttackParty = AttackDes.MakeBleedAttack,
                    Description = $"Вызвать кровотечение ({character.TotalAttack / 2} {Output.AttackStr} | {Conditions.BleedDmg} {Output.DmgSymbol}/3 ХОДА)"
                };

                //  Способность: Парирование (доработать)
                //if (hero.Statistic.Attacks >= 15)
                //{
                //    AttackDes AttacParry = new AttackDes(hero, "Парировать")
                //    {
                //        Attack = AttackDes.ParryAttack,
                //        Description = $"Парировать атаку ({hero.TotalSpeed * 100}% МЕТ)"//////////////////////////////////////////////////////////////
                //    };
                //}
            }
            #endregion

            #region Заклинания
            SpellDes CleansingRay = new SpellDes(character, "Очищающий луч")
            {
                SpellParty = SpellDes.CleansingRaySpell,
                SpellСost = 5,
                SpellPower = 10
            };
            CleansingRay.Description = $"Очищающий луч ({CleansingRay.SpellPower + character.TotalArcane} {Output.AttackStr} | МЕТ {(enemy.TotalSpeed - 1) * 100}% | {CleansingRay.SpellСost} {Output.MPSymbol})";

            ////  Способность: Малое лечение
            //if (character.Statistic.Spells >= 5)
            //{
            //    SpellDes Healing = new SpellDes(character, "Малое лечение")
            //    {
            //        Spell = SpellDes.HealSpell,
            //        SpellСost = 3
            //    };
            //    Healing.Description = $"Малое лечение (+30% {Output.HPSymbol} | {Healing.SpellСost} {Output.MPSymbol})";
            //}
            #endregion

            #region Особенности
            if (character.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active)
            {
                SpecialDes SpecialBranch = new SpecialDes(character, "Навык 'Штопор'")
                {
                    SpecialsParty = SpecialDes.SpecialBranch,
                    Description = $"'Вскрывает' броню противника"
                };
            }

            #endregion


            #region Зелья

            #endregion

            //  Не трогать
            ClearDuplicat(character, enemy);
        }

        //  Чистка от дубликатов
        public static void ClearDuplicat(Hero hero, Character enemy)
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

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static void ClearDuplicat(Character character, Character enemy)
        {
            //  Чистка заклинаний
            //  По схожему описанию
            character.SpellList = character.SpellList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            //  По схожему имени
            character.SpellList = character.SpellList.GroupBy(x => x.Name).Select(x => x.First()).Distinct().ToList();

            //  Чистка атак
            //  По схожему описанию
            character.AttackList = character.AttackList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            //  По схожему имени
            character.AttackList = character.AttackList.GroupBy(x => x.Name).Select(x => x.First()).Distinct().ToList();
        }

        //  Первоначальные навыки героя
        public static void Skills(Character character, int i)
        {
            if (i == 1)
            {
                AttackDes Attac = new AttackDes(character, "Обычная атака")
                {
                    AttackParty = AttackDes.BaseAttack,
                    Description = $"Атаковать ({character.TotalAttack} {Output.AttackStr} | {Output.CritStr}: {character.TotalCrit * 100}%)"
                };

                AttackDes AttacBreanch = new AttackDes(character, "Пробитие")
                {
                    AttackParty = AttackDes.BreachArmorAttack,
                    Description = $"Пробитие брони и защиты ({character.TotalAttack} {Output.AttackStr})"
                };

                //PotionDes HealPotion = new PotionDes(character)
                //{
                //    Name = "Зелье лечения",
                //    Potion = PotionDes.HealPotion,
                //    Description = "Зелье лечения",
                //};
                //HealPotion.Count = 1;

                //PotionDes ManaPotion = new PotionDes(character)
                //{
                //    Name = "Зелье маны",
                //    Potion = PotionDes.ManaPotion,
                //    Description = "Зелье маны",
                //};
                //ManaPotion.Count = 1;

                //PotionDes AntiPotion = new PotionDes(character)
                //{
                //    Name = "Противоядие",
                //    Potion = PotionDes.ManaPotion,
                //    Description = "Противоядие"
                //};

                //PotionDes PowerPotion = new PotionDes(character)
                //{
                //    Name = "Зелье силы",
                //    Potion = PotionDes.PowerPotion,
                //    Description = "Зелье силы"
                //};
                //PowerPotion.Count = 1;
            }

            character.AttackList = character.AttackList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            //character.PotionList = character.PotionList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
        }
    }
}
