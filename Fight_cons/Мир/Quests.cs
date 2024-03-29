﻿using Fight_cons.Мир;
using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Quests
    {
        public Dictionary<byte, byte> Que = new Dictionary<byte, byte>
        {
            [0] = 0,    //  Основной квест
            [1] = 0,    //  Квест "Секреты Бегемота"
            [2] = 0,    //  Квест "Твое имя камень!"
            [3] = 0,    //  Квест "ДА БУДЕТ СМЕРТЬ"
            [4] = 0,    //  Квест "Яблочный убийца"
            [5] = 0,    //  
            [6] = 0,    //  
            [7] = 0,    //  
        };

        public void StartQ(Hero hero, byte i)
        {
            if (hero.Hero_quest.Que[i] == 0) 
                hero.Hero_quest.Que[i]++;
        }

        /*public async void QuestUpdater(Hero hero)
        {
            var q = hero.Hero_quest.Que.Count;

            for (int i = 0; i < q;)
            {
                switch (i)
                {
                    case 0:
                        MainQ(hero);
                        break;
                    case 1:
                        Q_Leva_1(hero);
                        break;
                    case 2:
                        Q_Your_name(hero);
                        break;
                }
                i++;
            }
        }*/

        public void MainQ(Hero hero)
        {
            switch (hero.Hero_quest.Que[0])
            {
                case 1:
                    Output.TwriteLine("\nВы находите Таотота\n", 1);
                    Battles.MakeBattle(hero, 7);

                    //  Чистка параметров
                    hero.Conditions.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Run)
                        {
                            hero.Hero_quest.Que[0] = 2;
                            hero.Hero_quest.MainQ(hero);

                            Output.Victoy_log();
                            hero.HeroStatistic.Wins++;
                        }
                    }
                    hero.Run = false;
                    AboutLoc.EnemyList.Clear();
                    break;

                    case 2:
                    //  END GAME
                    if (hero.Hero_quest.Que[0] == 2)
                    {
                        Settings.Bild_vers_active = true;
                        Output.TwriteLine("Вы убедили Таотота в своей силе", 30);
                        Console.ReadKey();
                        Output.Final();
                    }
                    break;
            }            
        }

        #region Квесты
        //  Квест "Секреты Бегемота"
        public void Q_Leva_1(Hero hero)
        {
            //  Введение
            switch (hero.Hero_quest.Que[1])
            {
                case 1:
                    if (Battles.Vero(0.6))
                    {
                        Output.StartQuest("Секреты Бегемота");
                        
                        Output.TwriteLine("К вам подсаживается Бегемот и говорит:", 1);
                        Console.ReadKey(true);
                        Sound.Voice_Leva("- Вижу в глазах твоих битву! *кашляет и вытерает руку об пузо* ", 30);
                        Console.ReadKey(true);
                        Sound.Voice_Leva("- Раскрою тебе секрет! Но только тебе!", 1);
                        Console.ReadKey(true);
                        Output.TwriteLine("*Он подсаживается ближе и говорит на ухо*", 10);
                        Console.ReadKey(true);
                        Sound.Voice_Leva("- Но при условии если раздобудешь красивую деревянную статуэтку и 50 золотых\n", 10);
                        Console.ReadKey(true);
                        hero.Hero_quest.Que[1] = 2;
                    }
                    break; 
                //case 2:
                //    Output.TwriteLine("\nБегемот ждет статуэтку и 50 золотых монет\n", 1);
                //    break;
                case 3:
                    Output.TwriteLine("\nБегемот ждет статуэтку и 50 золотых монет\n", 1);
                    if (hero.Money >= 50)
                    {
                        hero.Money -= 50;
                        var item = hero.HeroInventory.FirstOrDefault(x => x.Name.Contains("Статуэтка"));
                        hero.HeroInventory.Remove(item);

                        Sound.Voice_Leva("- Вот она статуэтка!", 1);
                        Console.ReadKey(true);
                        Sound.Voice_Leva("- Ты можешь взять один мой огненный меч! ", 1);
                        Console.ReadKey(true);
                        Weapon Q_Leva_swored = new Weapon(name: "Меч 'Бегемота Левы'", cost: 300, attack: 11, speed: 0.2, crit: 0.2, block: 0.2, maxMoves: 1);

                        Output.WriteColorLine(ConsoleColor.White, $"\n", $"{Q_Leva_swored.Name} ", "| ");
                        Output.Comparison(hero.HeroWeapon.Attack, Q_Leva_swored.Attack, text_left: "", tab_or_line: "| ", text_mid: "ATT");
                        Output.Comparison(hero.HeroWeapon.Speed, Q_Leva_swored.Speed, text_left: "", tab_or_line: "| ", text_mid: "SPD", true);
                        Output.Comparison(hero.HeroWeapon.Crit, Q_Leva_swored.Crit, text_left: "", tab_or_line: "| ", text_mid: "CRT", true);
                        Output.Comparison(hero.HeroWeapon.Block, Q_Leva_swored.Block, text_left: "", tab_or_line: "| ", text_mid: "BLK", true);
                        if (Q_Leva_swored.MaxMoves >= 1)
                            Output.Comparison(hero.HeroWeapon.MaxMoves, Q_Leva_swored.MaxMoves, text_left: "", tab_or_line: "| \n", text_mid: "MOV");
                        else
                            Console.WriteLine();

                        //Game.TwriteLine($"{Q_Leva_swored.Weapon_stats_market(hero.weapon, Q_Leva_swored, true)}\n", 1);

                        Output.TwriteLine("\nВаши действия?\n"
                                      + "1) Взять меч\n"
                                      + "2) Я пришел за твоим секретом!", 1);

                        switch (Input.Chois_input(hero, 0, 3))
                        {
                            case 1:
                                hero.HeroWeapon = Q_Leva_swored;
                                Sound.Voice_Leva("Будь аккуратен с ним!\n", 1);
                                break;
                            case 2:
                                Sound.Voice_Leva("В таком случаи секрет в том...", 1);
                                Sound.Voice_Leva("... чтобы качать только здоровья, ну и немного атаку...\n", 1);
                                hero.PermanentBonuses.MaxHp += 3;
                                hero.PermanentBonuses.Attack += 1;
                                break;
                        }
                        hero.Hero_quest.Que[1] = 4;
                    }
                    break;
            }                     
        }

        public void Q_leva_Market(Hero hero)
        {
            Console.WriteLine("\nВаши действия?");
            Output.WriteColorLine(ConsoleColor.Yellow, "1) Купить статуэтку (", "30\u00A2", ")\n");
            Console.WriteLine("2) Купить оружие\n"
                            + "3) Купить броню");
            Output.WriteColorLine(ConsoleColor.Yellow, "4) Купить зелье здоровья (", "20\u00A2", ")\n");
            Output.WriteColorLine(ConsoleColor.Yellow, "5) Купить зелье маны (", "30\u00A2", ")\n");
            Console.WriteLine("6) Выйти");

            switch (Input.Chois_input(hero, 1, 6))
            {
                case 1:
                    if (hero.Money >= 30)
                    {
                        hero.Money -= 30;
                        Output.Spent(30);

                        Inventory.ItemAdd(hero, "Статуэтка", true);
                        Output.TwriteLine("\nСпасибо за покупку!", 1);
                        hero.Hero_quest.Que[1] = 3;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 2:
                    Market.Weapon_goods(hero);
                    break;

                case 3:
                    Market.Armor_goods(hero);
                    break;

                case 4:
                    if (hero.Money >= 20)
                    {
                        hero.Money -= 20;
                        Output.Spent(20, "Зелье здоровья");
                        hero.PotionList[0].Count += 1;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 5:
                    if (hero.Money >= 30)
                    {
                        hero.Money -= 30;
                        Output.Spent(30, "Зелье маны");
                        hero.PotionList[1].Count += 1;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 6:
                    VillageLoc.Village(hero);
                    break;
            }
        }

        //  Квест "Кiт, ты хозяина мав?"
        public void Q_Your_name(Hero hero)
        {
            if (hero.Hero_quest.Que[2] == 1)
            {
                Output.TwriteLine("Проходя вдоль переулка к вам обращается рыжеволосый мальчик.", 10);
                Console.ReadKey(true);
                Output.TwriteLine("- Эй, Камень, ты что тут забыл? Мне мама говорила вы только зверьми бываете.", 10);
                Console.ReadKey(true);
                Output.TwriteLine("- ...", 30);
                Console.ReadKey(true);
                Output.TwriteLine("Вы уже хотели ответить, но не смогли издать ни звука.", 10);
                Console.ReadKey(true);
                Output.TwriteLine("- Эй, ты чего молчишь? Говорить не умеешь?", 10);
                Console.ReadKey(true);
                Output.TwriteLine("- Ну и ну, в человека превращаешься, а Камнем и остался - просмеялся мальчик.", 10);
                Console.ReadKey(true);
                Output.TwriteLine("Неподалеку послышался крик:\n- Эй, ты опять...Ох, а вы?.. - спросил мужчина с светло рыжей бородой.", 10);
                Console.ReadKey(true);
                Output.TwriteLine("- Камень! Я его назвал Камень!", 10);
                Console.ReadKey(true);
                Output.TwriteLine("\n(Внимание вопрос! Вы Камень? потом это запишется в имя)\n"
                    + "1) Неодобрительно кивнуть\n"
                    + "2) Одобрительно кивнуть", 10);

                switch (Input.Chois_input(hero, 0, 3))
                {
                    case 1:
                        hero.HeroStatistic.know_name = true;
                        break;
                    case 2:
                        hero.Name = "Камень";
                        hero.HeroStatistic.know_name = true;
                        break;
                }
                Output.TwriteLine("- Вы его извините, он совсем неугомонный. С ним я даже с работой не успеваю.", 10);
                Console.ReadKey(true);
                Output.TwriteLine("- Надеюсь он вам не сильно помешал. Всего доброго. - они поспешно удалились.\n", 10);
                Console.ReadKey(true);

                hero.Hero_quest.Que[2]++;
            }            
        }

        //  Квест "ДА БУДЕТ СМЕРТЬ"
        public void Q_def(Hero hero)
        {
            Console.WriteLine("Вы видите кошку");
            Console.WriteLine("Идя вдоль рынка вы замечаете у прилавка человека, что часто кашляет. Старик, увидя вас приятно улыбается." +
                "- Добрый день, не хотите ли чего приобрести ? -сказал указав на прилавок с не особо свежими фруктами.");
        }

        //  Квест "Яблочный убийца"
        public void Q_apple(Hero hero)
        {
            Console.WriteLine("Вы видите кошку");
            Console.WriteLine("Идя вдоль рынка вы замечаете у прилавка человека, что часто кашляет. Старик, увидя вас приятно улыбается." +
                "- Добрый день, не хотите ли чего приобрести ? -сказал указав на прилавок с не особо свежими фруктами.");
        }
        #endregion
    }
}
