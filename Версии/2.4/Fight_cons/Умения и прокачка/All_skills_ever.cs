using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    class All_skills_ever
    {
        public Skills_dele Skill { get; set; }

        public static void Skills(Hero hero, int i)
        {
            if (i == 1)
            {
                Attack_des Attac = new Attack_des(hero, "Обычная атака")
                {
                    Attack = Attack_des.Act_Attac,
                    Description = $"Атаковать ({hero.attack} ATT | CRT: {hero.crit * 100}%)"
                };

                Attack_des Attac_breanch = new Attack_des(hero, "Пробитие")
                {
                    Attack = Attack_des.Act_breach_armor,
                    Description = $"Пробитие брони и защиты ({hero.attack} ATT)"
                };

                Potion_des Heal_potion = new Potion_des(hero)
                {
                    Name = "Зелье лечения",
                    Potion = Potion_des.Act_Heal,
                    Description = "Зелье лечения",
                };
                Heal_potion.Count = 1;

                Potion_des Mana_potion = new Potion_des(hero)
                {
                    Name = "Зелье маны",
                    Potion = Potion_des.Act_Mana,
                    Description = "Зелье маны",
                };
                Mana_potion.Count = 1;

                Potion_des Anti_potion = new Potion_des(hero)
                {
                    Name = "Противоядие",
                    Potion = Potion_des.Act_Mana,
                    Description = "Противоядие"
                };

                Potion_des Power_potion = new Potion_des(hero)
                {
                    Name = "Зелье силы",
                    Potion = Potion_des.Act_Power,
                    Description = "Зелье силы"
                };
                Power_potion.Count = 1;               
            }

            hero.Attacks_list = hero.Attacks_list.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            hero.Potion_list = hero.Potion_list.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
        }

        public static void Skills(Hero hero, Enemy enemy)
        {
            Attack_des Attac = new Attack_des(hero, "Обычная атака")
            {
                Attack = Attack_des.Act_Attac,
                Description = $"Атаковать ({hero.attack} ATT | CRT: {hero.crit * 100}%)"
            };

            Attack_des Attac_breanch = new Attack_des(hero, "Пробитие")
            {
                Attack = Attack_des.Act_breach_armor,
                Description = $"Пробитие брони и защиты ({hero.attack} ATT)"
            };

            //  Можно загружать набор навыков во время боя
            Spell_des Cleansing_ray = new Spell_des(hero, "Очищающий луч")
            {
                Spell = Spell_des.Spell_cleansing_ray,
                Spell_cost = 5,
                Spell_power = 10                
            };
            Cleansing_ray.Description = $"Очищающий луч (10 ATT | МЕТ {(1 - enemy.speed) * 100}% | {Cleansing_ray.Spell_cost} MP)";

            //  Способность: Малое лечение
            if (hero.Hero_stats.Spells >= 5)
            {                
                Spell_des Healing = new Spell_des(hero, "Малое лечение")
                {
                    Spell = Spell_des.Heal,
                    Spell_cost = 3
                };
                Healing.Description = $"Малое лечение (+30% HP | {Healing.Spell_cost} MP)";
            }

            //  Способность: Кровотечение
            if (hero.Hero_stats.Attacks >= 10)
            {
                Attack_des Attac_bleed = new Attack_des(hero, "Вызвать кровотечение")
                {
                    Attack = Attack_des.Act_Bleed,
                    Description = $"Вызвать кровотечение ({hero.attack / 2} ATT | {enemy.debuffs.Bleed_dmg} DMG/3 ХОДА)"
                };
            }

            Clear_dub(hero, enemy);

            //  Способность: Парирование
            if (hero.Hero_stats.Attacks >= 15)
            {
                Attack_des Attac_Parry = new Attack_des(hero, "Парировать")
                {
                    Attack = Attack_des.Act_Parry,
                    Description = $"Парировать атаку ({hero.speed * 100}% МЕТ)"
                };
            }

            Clear_dub(hero, enemy);
        }

        //  Чистка от дубликатов
        public static void Clear_dub(Hero hero, Enemy enemy)
        {
            //  Чистка заклинаний
            //  По схожему описанию
            hero.Spell_list = hero.Spell_list.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            //  По схожему имени
            hero.Spell_list = hero.Spell_list.GroupBy(x => x.Name).Select(x => x.First()).Distinct().ToList();

            //  Чистка атак
            //  По схожему описанию
            hero.Attacks_list = hero.Attacks_list.GroupBy(x => x.Description).Select(x => x.First()).Distinct().ToList();
            //  По схожему имени
            hero.Attacks_list = hero.Attacks_list.GroupBy(x => x.Name).Select(x => x.First()).Distinct().ToList();
        }
    }
}
