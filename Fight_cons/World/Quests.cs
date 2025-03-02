using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using static FightCons.Locations;
using static FightCons.ItemChar;
using FightCons.World.Locations;
using System.Security.Policy;

namespace FightCons
{
    public class Quests
    {
        public Dictionary<byte, byte> Que = new Dictionary<byte, byte>
        {
            [0] = 0,    //  Победа над Покровителем 
            [1] = 0,    //  Победа над Тоатотом 
            [2] = 0,    //  Победа над ... 
            [3] = 0,    //  Победа над ... 
            [4] = 0,    //  Победа над ... 
            [5] = 0,    //  Победа над ... 
            [6] = 0,    //  Победа над ... 
            [7] = 0,    //  
            [8] = 0,    //  
            [11] = 0,    //  Квест "Секреты Бегемота"
            [12] = 0,    //  Квест "Твое имя камень!"

            //  Квест "ДА БУДЕТ СМЕРТЬ"
            //  Квест "Яблочный убийца"
        };

        //TODO посмотреть необходимость этого метода
        public void StartQ(Hero hero, byte i)
        {
            if (hero.HeroQuests.Que[i] == 0) 
                hero.HeroQuests.Que[i]++;
        }

        //1. Основная задача в ИСС
        public void MainISS(Hero hero)
        {
            switch (hero.HeroQuests.Que[1])
            {
                case 1:
                    Output.TwriteLine("\nВы находите Таотота\n", 1);
                    Battles.MakeCurrentBattle(hero, 7);

                    //  Чистка параметров
                    hero.Condition.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Condition.LeavedBattle)
                        {
                            hero.HeroQuests.Que[1] = 2;
                            hero.HeroQuests.MainISS(hero);

                            Output.VictoryWarning();
                            hero.Statistic.Wins++;
                        }
                    }
                    hero.Condition.LeavedBattle = false;
                    Battles.ListOfUnits.Clear();
                break;

                case 2:
                //  END GAME
                if (hero.HeroQuests.Que[1] == 2)
                {
                    Output.TwriteLine("Вы убедили Таотота в своей силе", 30);
                    Reward(hero, 500, 100);
                    //Output.Final();
                    //LocationISS.Valley(hero);
                }
                break;
            }            
        }

        //2. Основная задача в ДЖ
        public void MainDJ(Hero hero)
        {
            switch (hero.HeroQuests.Que[2])
            {
                case 1:
                    Output.TwriteLine("\nВы находите Таотота\n", 1);
                    Battles.MakeCurrentBattle(hero, 7);

                    //  Чистка параметров
                    hero.Condition.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Condition.LeavedBattle)
                        {
                            hero.HeroQuests.Que[2] = 2;
                            hero.HeroQuests.MainDJ(hero);

                            Output.VictoryWarning();
                            hero.Statistic.Wins++;
                        }
                    }
                    hero.Condition.LeavedBattle = false;
                    Battles.ListOfUnits.Clear();
                    break;

                case 2:
                    if (hero.HeroQuests.Que[2] == 2)
                    {
                        Output.TwriteLine("Вы убедили Таотота в своей силе", 30);
                        Reward(hero, 500, 100);
                    }
                    break;
            }
        }

        //3. Основная задача в БТЛ
        public void MainBTL(Hero hero)
        {
            switch (hero.HeroQuests.Que[3])
            {
                case 1:
                    Output.TwriteLine("\nВы находите Таотота\n", 1);
                    Battles.MakeCurrentBattle(hero, 7);

                    //  Чистка параметров
                    hero.Condition.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Condition.LeavedBattle)
                        {
                            hero.HeroQuests.Que[3] = 2;
                            hero.HeroQuests.MainDJ(hero);

                            Output.VictoryWarning();
                            hero.Statistic.Wins++;
                        }
                    }
                    hero.Condition.LeavedBattle = false;
                    Battles.ListOfUnits.Clear();
                    break;

                case 2:
                    if (hero.HeroQuests.Que[3] == 2)
                    {
                        Output.TwriteLine("Вы убедили Таотота в своей силе", 30);
                        Reward(hero, 500, 100);
                    }
                    break;
            }
        }

        //4. Основная задача в ОП
        public void MainOP(Hero hero)
        {
            switch (hero.HeroQuests.Que[4])
            {
                case 1:
                    Output.TwriteLine("\nВы находите Таотота\n", 1);
                    Battles.MakeCurrentBattle(hero, 7);

                    //  Чистка параметров
                    hero.Condition.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Condition.LeavedBattle)
                        {
                            hero.HeroQuests.Que[4] = 2;
                            hero.HeroQuests.MainDJ(hero);

                            Output.VictoryWarning();
                            hero.Statistic.Wins++;
                        }
                    }
                    hero.Condition.LeavedBattle = false;
                    Battles.ListOfUnits.Clear();
                    break;

                case 2:
                    if (hero.HeroQuests.Que[4] == 2)
                    {
                        Output.TwriteLine("Вы убедили Таотота в своей силе", 30);
                        Reward(hero, 500, 100);
                    }
                    break;
            }
        }

        //5. Основная задача в ПП
        public void MainPP(Hero hero)
        {
            switch (hero.HeroQuests.Que[5])
            {
                case 1:
                    Output.TwriteLine("\nВы находите Таотота\n", 1);
                    Battles.MakeCurrentBattle(hero, 7);

                    //  Чистка параметров
                    hero.Condition.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Condition.LeavedBattle)
                        {
                            hero.HeroQuests.Que[5] = 2;
                            hero.HeroQuests.MainDJ(hero);

                            Output.VictoryWarning();
                            hero.Statistic.Wins++;
                        }
                    }
                    hero.Condition.LeavedBattle = false;
                    Battles.ListOfUnits.Clear();
                    break;

                case 2:
                    if (hero.HeroQuests.Que[5] == 2)
                    {
                        Output.TwriteLine("Вы убедили Таотота в своей силе", 30);
                        Reward(hero, 500, 100);
                    }
                    break;
            }
        }

        //6. Основная задача в НД
        public void MainND(Hero hero)
        {
            switch (hero.HeroQuests.Que[6])
            {
                case 1:
                    Output.TwriteLine("\nВы находите Таотота\n", 1);
                    Battles.MakeCurrentBattle(hero, 7);

                    //  Чистка параметров
                    hero.Condition.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Condition.LeavedBattle)
                        {
                            hero.HeroQuests.Que[6] = 2;
                            hero.HeroQuests.MainDJ(hero);

                            Output.VictoryWarning();
                            hero.Statistic.Wins++;
                        }
                    }
                    hero.Condition.LeavedBattle = false;
                    Battles.ListOfUnits.Clear();
                    break;

                case 2:
                    if (hero.HeroQuests.Que[6] == 2)
                    {
                        Output.TwriteLine("Вы убедили Таотота в своей силе", 30);
                        Reward(hero, 500, 100);
                    }
                    break;
            }
        }

        public void MainMainQ(Hero hero)
        {
            switch (hero.HeroQuests.Que[7])
            {
                case 0:
                    Output.TwriteLine("\nВы находите Покровителя\n", 1);
                    Battles.MakeCurrentBattle(hero, 20);

                    //  Чистка параметров
                    hero.Condition.Clear();
                    hero.Turn = 0;

                    if (hero.TotalHP <= 0)
                        hero.HeroDeath();
                    else
                    {
                        if (!hero.Condition.LeavedBattle)
                        {
                            hero.HeroQuests.Que[7] = 1;
                            hero.HeroQuests.MainISS(hero);

                            Output.VictoryWarning();
                            hero.Statistic.Wins++;
                        }
                    }
                    hero.Condition.LeavedBattle = false;
                    Battles.ListOfUnits.Clear();

                    hero.HeroQuests.MainMainQ(hero);
                    break;

                case 1:
                    //  END GAME
                    if (hero.HeroQuests.Que[7] == 1)
                    {
                        Output.TwriteLine("Вы одолели Покровителя", 30);
                        Output.TwriteLine("Вы вольный делать то что хотите", 30);
                        Reward(hero, 5000, 1000);
                        Output.Final();
                        hero.HeroQuests.Que[7] = 2;

                        //LocationISS.Valley(hero);
                    }
                    break;
                case 2:
                    //  END GAME
                    if (hero.HeroQuests.Que[7] == 2)
                    {
                        Output.TwriteLine("Место пустует, никто более его не займет...", 30, true);

                        //Output.Final();
                        //Output.Final();
                        //LocationISS.Valley(hero);
                    }
                    break;
            }
        }

        #region Квесты
        //  Квест "Секреты Бегемота"
        public void Q_Leva_1(Hero hero)
        {
            //  Введение
            switch (hero.HeroQuests.Que[11])
            {
                case 1:
                    if (GameFormulas.Vero(0.6))
                    {
                        Output.StartQuest("Секреты Бегемота");
                        
                        Output.TwriteLine("К вам подсаживается Бегемот и говорит:", 1);
                        Console.ReadKey(true);
                        Sound.VoiceLeva("- Вижу в глазах твоих битву! *кашляет и вытирает руку об пузо* ", 30);
                        Console.ReadKey(true);
                        Sound.VoiceLeva("- Раскрою тебе секрет! Но только тебе!", 1);
                        Console.ReadKey(true);
                        Output.TwriteLine("*Он подсаживается ближе и говорит на ухо*", 10);
                        Console.ReadKey(true);
                        Sound.VoiceLeva("- Но при условии если раздобудешь красивую деревянную статуэтку и 50 золотых\n", 10);
                        Console.ReadKey(true);
                        hero.HeroQuests.Que[11] = 2;
                    }
                    break; 

                case 3:
                    Output.TwriteLine("\nБегемот ждет статуэтку и 50 золотых монет\n", 1);
                    if (hero.Money >= 50)
                    {
                        hero.Money -= 50;
                        var item = hero.HeroInventory.FirstOrDefault(x => x.Name.Contains("Статуэтка"));
                        hero.HeroInventory.Remove(item);

                        Sound.VoiceLeva("- Вот она статуэтка!", 1);
                        Console.ReadKey(true);
                        Sound.VoiceLeva("- Ты можешь взять один мой огненный меч! ", 1);
                        Console.ReadKey(true);
                        ItemChar Q_Leva_swored = new ItemChar(name: "Меч 'Бегемота Левы'", itemType: ItemTyps.Weapon, cost: 300, attack: 11, speed: 0.2f, crit: 0.2f, block: 0.2f, maxMoves: 1);

                        Output.WriteColorLine(ConsoleColor.White, $"\n", $"{Q_Leva_swored.Name} ", "| ");
                        ItemStats(hero.CharecterWeapon, Q_Leva_swored);

                        Output.TwriteLine("\nВаши действия?\n"
                                      + "1) Взять меч\n"
                                      + "2) Я пришел за твоим секретом!", 1);

                        switch (Input.ChoisInput(hero, 1, 2))
                        {
                            case 1:
                                hero.CharecterWeapon = Q_Leva_swored;
                                Sound.VoiceLeva("Будь аккуратен с ним!\n", 1);
                                break;
                            case 2:
                                Sound.VoiceLeva("В таком случаи секрет в том...", 1);
                                Sound.VoiceLeva("... чтобы качать только здоровья, ну и немного атаку...\n", 1);
                                hero.PermanentBonus.MaxHp += 3;
                                hero.PermanentBonus.Attack += 1;
                                break;
                        }
                        hero.HeroQuests.Que[11] = 4;
                    }
                    break;
            }                     
        }

        public void Q_leva_Market(Hero hero)
        {
            Console.WriteLine("\nВаши действия?");
            Output.WriteColorLine(ConsoleColor.Yellow, "1) Купить статуэтку (", $"30{Output.MoneySymbol}", ")\n");
            Console.WriteLine("2) Купить оружие\n"
                            + "3) Купить броню");
            Output.WriteColorLine(ConsoleColor.Yellow, "4) Купить зелье здоровья (", $"{Output.PotionHPCost}{Output.MoneySymbol}", ")\n");
            Output.WriteColorLine(ConsoleColor.Yellow, "5) Купить зелье маны (", $"{Output.PotionMPCost}{Output.MoneySymbol}", ")\n");
            Console.WriteLine("6) Выйти");

            switch (Input.ChoisInput(hero, 1, 6))
            {
                case 1:
                    if (Output.Spent(hero.Money, Output.QStatueCost))
                    {
                        Inventory.ItemAdd(hero, "Статуэтка", true);
                        Output.TwriteLine("\nСпасибо за покупку!", 1);
                        hero.HeroQuests.Que[11] = 3;
                    }
                    else
                        Output.TwriteLine("\nВы нищеброд! Проваливайте!\n", 1);
                    break;

                case 2:
                    MarketMethods.ShowWeaponGoods(hero);
                    break;

                case 3:
                    MarketMethods.ShowArmorGoods(hero);
                    break;

                case 4:
                    if (Output.Spent(hero.Money, Output.PotionHPCost, "Зелье здоровья", "\nВы нищеброд! Проваливайте!\n"))
                        hero.PotionList[0].Count += 1;
                    break;

                case 5:
                    if (Output.Spent(hero.Money, Output.PotionMPCost, "Зелье маны", "\nВы нищеброд! Проваливайте!\n"))
                        hero.PotionList[1].Count += 1;
                    break;

                case 6:
                    LocationISS.OrdoColony(hero);
                    break;
            }
        }

        //  Квест "Твое имя камень!"
        public void QYourName(Hero hero)
        {
            if (hero.HeroQuests.Que[12] == 1)
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

                switch (Input.ChoisInput(hero, 1, 2))
                {
                    case 1:
                        hero.Statistic.knowYourName = true;
                        break;
                    case 2:
                        hero.Name = "Камень";
                        hero.Statistic.knowYourName = true;
                        break;
                }
                Output.TwriteLine("- Вы его извините, он совсем неугомонный. С ним я даже с работой не успеваю.", 10);
                Console.ReadKey(true);
                Output.TwriteLine("- Надеюсь он вам не сильно помешал. Всего доброго. - они поспешно удалились.\n", 10);
                Console.ReadKey(true);

                hero.HeroQuests.Que[12]++;
            }            
        }
        #endregion

        public static void Reward(Hero hero, short money, short exp)
        {
            Output.WriteColorLine(ConsoleColor.DarkCyan, $"\nВы получили ", $"{exp}{Output.ExpSymbol} ");
            if (money > 0)
            {
                Output.WriteColorLine(ConsoleColor.Yellow, "и ", $"{money}{Output.MoneySymbol}\n");
                hero.Money += money;
                hero.Statistic.Money += money;
            }
            else
                Console.WriteLine();

            hero.LevelUp(hero, exp);
        }
    }
}
