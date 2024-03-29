﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    class AllSkillsEver
    {
        public Skills_dele Skill { get; set; }

        //  Фиксированные навыки
        public static void Skills(Hero hero, Charecter enemy)
        {
            double finalDam = AttackDes.Defence_chek(enemy, hero.TotalAttack);

            AttackDes Attac = new AttackDes(hero, "Обычная атака")
            {
                Attack = AttackDes.Act_Attac,
                Description = $"Атаковать ({(int)finalDam} ATT | CRT: {hero.TotalCrit * 100}%)"
            };

            AttackDes Attac_breanch = new AttackDes(hero, "Пробитие")
            {
                Attack = AttackDes.Act_breach_armor,
                Description = $"Пробитие брони и защиты ({(int)(hero.TotalAttack / 1.5)} ATT)"
            };

            //  Можно загружать набор навыков во время боя
            SpellDes Cleansing_ray = new SpellDes(hero, "Очищающий луч")
            {
                Spell = SpellDes.Spell_cleansing_ray,
                Spell_cost = 5,
                Spell_power = 10                
            };
            Cleansing_ray.Description = $"Очищающий луч ({Cleansing_ray.Spell_power + hero.TotalArcane} ATT | МЕТ {(enemy.TotalSpeed - 1) * 100}% | {Cleansing_ray.Spell_cost} MP)";

            //  Способность: Малое лечение
            if (hero.HeroStatistic.Spells >= 5)
            {                
                SpellDes Healing = new SpellDes(hero, "Малое лечение")
                {
                    Spell = SpellDes.Heal,
                    Spell_cost = 3
                };
                Healing.Description = $"Малое лечение (+30% HP | {Healing.Spell_cost} MP)";
            }

            //  Способность: Кровотечение
            if (hero.HeroStatistic.Attacks >= 10)
            {
                AttackDes Attac_bleed = new AttackDes(hero, "Вызвать кровотечение")
                {
                    Attack = AttackDes.Act_Bleed,
                    Description = $"Вызвать кровотечение ({hero.TotalAttack / 2} ATT | {enemy.Conditions.Bleed_dmg} DMG/3 ХОДА)"
                };
            }

            Clear_dub(hero, enemy);

            //  Способность: Парирование
            if (hero.HeroStatistic.Attacks >= 15)
            {
                AttackDes Attac_Parry = new AttackDes(hero, "Парировать")
                {
                    Attack = AttackDes.Act_Parry,
                    Description = $"Парировать атаку ({hero.TotalSpeed * 100}% МЕТ)"
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
                    Attack = AttackDes.Act_Attac,
                    Description = $"Атаковать ({hero.TotalAttack} ATT | CRT: {hero.TotalCrit * 100}%)"
                };

                AttackDes Attac_breanch = new AttackDes(hero, "Пробитие")
                {
                    Attack = AttackDes.Act_breach_armor,
                    Description = $"Пробитие брони и защиты ({hero.TotalAttack} ATT)"
                };

                PotionDes Heal_potion = new PotionDes(hero)
                {
                    Name = "Зелье лечения",
                    Potion = PotionDes.Act_Heal,
                    Description = "Зелье лечения",
                };
                Heal_potion.Count = 1;

                PotionDes Mana_potion = new PotionDes(hero)
                {
                    Name = "Зелье маны",
                    Potion = PotionDes.Act_Mana,
                    Description = "Зелье маны",
                };
                Mana_potion.Count = 1;

                PotionDes Anti_potion = new PotionDes(hero)
                {
                    Name = "Противоядие",
                    Potion = PotionDes.Act_Mana,
                    Description = "Противоядие"
                };

                PotionDes Power_potion = new PotionDes(hero)
                {
                    Name = "Зелье силы",
                    Potion = PotionDes.Act_Power,
                    Description = "Зелье силы"
                };
                Power_potion.Count = 1;
            }

            hero.AttackList = hero.AttackList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            hero.PotionList = hero.PotionList.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
        }
    }
}
