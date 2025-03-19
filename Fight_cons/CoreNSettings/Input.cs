using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Policy;
using System.Windows.Forms;
using FightCons.form;

namespace FightCons
{
    class Input
    {
        /// <summary>
        /// Проверка на соответствие
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="minNum">Минимальное значение</param>
        /// <param name="maxNum">Максимальное значение</param>
        /// <param name="question">Повторяющейся вопрос</param>
        /// <returns></returns>
        public static sbyte ChoisInput(Hero hero, sbyte minNum, sbyte maxNum, string question = "")
        {
            sbyte s = 0;
            do 
            {
                if (question.Length > 1)
                    Console.WriteLine(question);

                s = SbyteInput(hero); 
            }
            while (!(s > minNum - 1 && s < maxNum + 1));
            return s;
        }

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static sbyte ChoisInput(Character character, sbyte minNum, sbyte maxNum, string question = "")
        {
            sbyte s = 0;
            do
            {
                if (question.Length > 1)
                    Console.WriteLine(question);

                s = SbyteInput(character);
            }
            while (!(s > minNum - 1 && s < maxNum + 1));
            return s;
        }

        //  Проверка выбора во время боя
        public static sbyte ChoisInput(sbyte b1, sbyte b2)
        {
            sbyte s = 0;
            do { s = SbyteInput(); }
            while (!(s > b1 - 1 && s < b2 + 1));
            return s;
        }

        public static sbyte SbyteInput()
        {
            string str;
            sbyte x;
            do { str = Console.ReadLine(); }
            while (!sbyte.TryParse(str, out x));

            return x;
        }   

        //  Телепортация
        public static void Teleport(Hero hero)
        {
            Map map = new Map(hero);
            DialogResult res = map.ShowDialog();

            if (res == DialogResult.OK)
            {
                Type loc = typeof(Locations);
                MethodInfo method = loc.GetMethod(map.CalledLocation);
                method.Invoke(hero);
            }
        }

        //  Проверка c ключевыми словами
        public static sbyte SbyteInput(Hero hero)
        {
            Dictionary<string, Action> KeyWords = new Dictionary<string, Action>();
            #region Ключевые слова
            //KeyWords["save"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            //KeyWords["сохранить"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            KeyWords["инвентарь"] = () => { Inventory.ShowInventory(hero); };
            KeyWords["inv"] = () => { Inventory.ShowInventory(hero); };
            KeyWords["инв"] = () => { Inventory.ShowInventory(hero); };
            KeyWords["статы"] = () => { hero.ShowHeroStats(); };
            KeyWords["stats"] = () => { hero.ShowHeroStats(); };
            KeyWords["fstats"] = () => { Output.ShowFullHeroStats(hero); };
            KeyWords["ach"] = () => { Output.HeroAchievements(hero); };            
            KeyWords["help"] = () => { Output.HelpCommand(); };
            KeyWords["негр"] = () => { Output.HelpCommand(); };
            KeyWords["настройки"] = () =>
            {
                Console.WriteLine();
                Settings.OptionSound(hero);
                Settings.OptionWaitSkip(hero);
            };
            //TODO Упростить способ телепортации
            //KeyWords["tp"] = () => { Teleport(hero); };
            //KeyWords["тп"] = () => { Teleport(hero); };
            KeyWords["gold_"] = () =>
            {
                short m;

                short.TryParse(Console.ReadLine(), out m);
                hero.Money += m;
                hero.Statistic.Money += m;
            };
            KeyWords["uphp"] = () => { hero.MaxHp = 300; hero.HP = hero.MaxHp; };
            KeyWords["tavern1"] = () => { PipeMessage.TavernLocal(hero); };
            KeyWords["gsettings"] = () =>
            {
                sbyte ans;
                do
                {
                    Console.WriteLine("\nИгровые параметры:\n" +
                                $"1) Количество бонусов у оружия в магазине\n" +
                                $"2) Количество предметов в магазине\n" +
                                $"3) Урон от кровотечения\n" +
                                $"4) Режим игры\n" +
                                $"5) Выйти\n");

                    ans = ChoisInput(hero, 1, 5);
                    switch (ans)
                    {
                        case 1:
                            MarketMethods.NamOfBonuses = ChoisInput(hero, 1, 8, "Установите нужное количество (1-8)\n" +
                                $"Сейчас: {MarketMethods.NamOfBonuses}");
                            break;
                        case 2:
                            MarketMethods.NamOfGoods = ChoisInput(hero, 1, 100, "Установите нужное количество (1-100)\n" +
                                $"Сейчас: {MarketMethods.NamOfGoods}");
                            break;
                        case 3:
                            Conditions.BleedDmg = ChoisInput(hero, 1, 100, "Установите нужное количество\n" +
                                $"Сейчас: {Conditions.BleedDmg}");
                            break;
                        case 4:
                            Settings.OptionVersions(hero);
                            break;
                        case 5:
                            break;
                    }
                } while (ans != 5);

            };
            KeyWords["толк"] = () => { Output.Remark(); };
            #endregion

            string str;
            sbyte x;
            do
            {
                str = Console.ReadLine();
                if (KeyWords.ContainsKey(str.ToLower()))
                    KeyWords[str.ToLower()].Invoke();
            }
            while (!sbyte.TryParse(str, out x));

            return x;
        }

        //  НАГРУЗОЧНЫЙ PARTY /////////////////////////////////////////////////////
        public static sbyte SbyteInput(Character character)
        {
            Dictionary<string, Action> KeyWords = new Dictionary<string, Action>();
            /*
            #region Ключевые слова
            //KeyWords["save"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            //KeyWords["сохранить"] = () => { Console.WriteLine($"{hero.Name} saved!"); };
            KeyWords["инвентарь"] = () => { Inventory.ShowInventory(character); };
            KeyWords["inv"] = () => { Inventory.ShowInventory(character); };
            KeyWords["инв"] = () => { Inventory.ShowInventory(character); };
            KeyWords["статы"] = () => { character.ShowHeroStats(); };
            KeyWords["stats"] = () => { character.ShowHeroStats(); };
            KeyWords["fstats"] = () => { Output.ShowFullHeroStats(character); };
            KeyWords["ach"] = () => { Output.HeroAchievements(character); };
            KeyWords["help"] = () => { Output.HelpCommand(); };
            KeyWords["негр"] = () => { Output.HelpCommand(); };
            KeyWords["настройки"] = () =>
            {
                Console.WriteLine();
                Settings.OptionSound(character);
                Settings.OptionWaitSkip(character);
            };
            //TODO Упростить способ телепортации
            //KeyWords["tp"] = () => { Teleport(hero); };
            //KeyWords["тп"] = () => { Teleport(hero); };
            KeyWords["gold_"] = () =>
            {
                short m;

                short.TryParse(Console.ReadLine(), out m);
                character.Money += m;
                character.Statistic.Money += m;
            };
            KeyWords["uphp"] = () => { character.MaxHp = 300; character.HP = character.MaxHp; };
            KeyWords["tavern1"] = () => { PipeMessage.TavernLocal(character); };
            KeyWords["gsettings"] = () =>
            {
                sbyte ans;
                do
                {
                    Console.WriteLine("\nИгровые параметры:\n" +
                                $"1) Количество бонусов у оружия в магазине\n" +
                                $"2) Количество предметов в магазине\n" +
                                $"3) Урон от кровотечения\n" +
                                $"4) Режим игры\n" +
                                $"5) Выйти\n");

                    ans = ChoisInput(hero, 1, 5);
                    switch (ans)
                    {
                        case 1:
                            MarketMethods.NamOfBonuses = ChoisInput(hero, 1, 8, "Установите нужное количество (1-8)\n" +
                                $"Сейчас: {MarketMethods.NamOfBonuses}");
                            break;
                        case 2:
                            MarketMethods.NamOfGoods = ChoisInput(hero, 1, 100, "Установите нужное количество (1-100)\n" +
                                $"Сейчас: {MarketMethods.NamOfGoods}");
                            break;
                        case 3:
                            Conditions.BleedDmg = ChoisInput(hero, 1, 100, "Установите нужное количество\n" +
                                $"Сейчас: {Conditions.BleedDmg}");
                            break;
                        case 4:
                            Settings.OptionVersions(hero);
                            break;
                        case 5:
                            break;
                    }
                } while (ans != 5);

            };
            KeyWords["толк"] = () => { Output.Remark(); };
            #endregion
            */
            string str;
            sbyte x;
            do
            {
                str = Console.ReadLine();
                if (KeyWords.ContainsKey(str.ToLower()))
                    KeyWords[str.ToLower()].Invoke();
            }
            while (!sbyte.TryParse(str, out x));

            return x;
        }
    }

    //  Для телепорта
    static class Extension
    {
        public static object Invoke(this MethodInfo info, Hero hero)
        {
            return info.Invoke(null, new Hero[] { hero });
        }
    }
}
