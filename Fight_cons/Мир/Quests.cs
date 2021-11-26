using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    public class Quests
    {
        //  Основные:
        //  Победить Таотота
        public sbyte Game_win_q = 0;

        //  Второстепенные:
        //  Квест "Секреты Бегемота"
        public sbyte q_leva_1 = 0;

        //  Квест "Кiт, ты хозяина мав?"
        public sbyte q_kit_1 = 0;

        //  Квест "ДА БУДЕТ СМЕРТЬ"
        public sbyte q_def_1 = 0;

        //  Квест "Яблочный убийца"
        public sbyte q_apple_1 = 0;


        //  Квест "Секреты Бегемота"
        public void Q_Leva_1(Hero hero)
        {
            //  Введение
            if (q_leva_1 == 0)
            {
                if (Mechanics.Vero(0.3))
                {
                    Outer.TwriteLine_general("К вам подсаживается Бегемот и говорит:", Settings.T1);
                    Console.ReadKey(true);
                    Sound.Voice_Leva("- Вижу в глазах твоих битву! *кашляет и вытерает руку об пузо* ", Settings.T30);
                    Console.ReadKey(true);
                    Sound.Voice_Leva("- Раскрою тебе секрет! Но только тебе!", Settings.T1);
                    Console.ReadKey(true);
                    Outer.TwriteLine_general("*Он подсаживается ближе и говорит на ухо*", Settings.T10);
                    Console.ReadKey(true);
                    Sound.Voice_Leva("- Но при условии если раздобудешь красивую деревянную статуэтку и 50 золотых\n", Settings.T10);
                    Console.ReadKey(true);
                    q_leva_1 = 1;
                }                
            }

            //  Ждет статуэтку и деньги
            if (hero.money >= 50 && (q_leva_1 == 2))
            {
                hero.money -= 50;
                Sound.Voice_Leva("- Вот она статуэтка!", Settings.T1);
                Console.ReadKey(true);
                Sound.Voice_Leva("- Ты можешь взять один мой огненный меч! ", Settings.T1);
                Console.ReadKey(true);
                Weapon Q_Leva_swored = new Weapon("Меч 'Бегемота Левы'", 13, 0.2, 300, 0.2, 0.2, 1);

                Outer.ChangeColor($"\n", $"{Q_Leva_swored.Name} ", "| ", ConsoleColor.White);
                Outer.Comparison(hero.weapon.Attack, Q_Leva_swored.Attack, text_left: "", tab_or_line: "| ", text_mid: "ATT");
                Outer.Comparison(hero.weapon.Speed, Q_Leva_swored.Speed, text_left: "", tab_or_line: "| ", text_mid: "SPD");
                Outer.Comparison(hero.weapon.Crit, Q_Leva_swored.Crit, text_left: "", tab_or_line: "| ", text_mid: "CRT");
                Outer.Comparison(hero.weapon.Block, Q_Leva_swored.Block, text_left: "", tab_or_line: "| ", text_mid: "BLK");
                if (Q_Leva_swored.Move >= 1)
                    Outer.Comparison(hero.weapon.Move, Q_Leva_swored.Move, text_left: "", tab_or_line: "| \n", text_mid: "MOV");
                else
                    Console.WriteLine();

                //Game.TwriteLine($"{Q_Leva_swored.Weapon_stats_market(hero.weapon, Q_Leva_swored, true)}\n", 1);

                Outer.TwriteLine_general("\nВаши действия?\n"
                              + "1) Взять меч\n"
                              + "2) Я пришел за твоим секретом!", Settings.T1);

                switch (Input.Chois_input(hero, 0, 3))
                {
                    case 1:
                        hero.weapon = Q_Leva_swored;
                        Sound.Voice_Leva("Будь аккуратен с ним!\n", Settings.T1);
                        break;
                    case 2:
                        Sound.Voice_Leva("В таком случаи секрет в том...", Settings.T1);
                        Sound.Voice_Leva("... чтобы качать только здоровья, ну и немного атаку...\n", Settings.T1);                    
                        break;
                }
                q_leva_1 = 3;
            }
            else if (q_leva_1 == 1)
                Outer.TwriteLine_general("\nБегемот ждет статуэтку и 50 золотых монет\n", Settings.T1);                
        }

        public void Q_leva_Market(Hero hero)
        {
            Console.WriteLine("\nВаши действия?\n"
                              + "1) Купить статуэтку (30 монеты)\n"
                              + "2) Купить оружие\n"
                              + "3) Купить броню\n"
                              + "4) Купить зелье здоровья (20 золотых)\n"
                              + "5) Купить зелье маны (30 золотых)\n"
                              + "6) Выйти");

            switch (Input.Chois_input(hero, 0, 7))
            {
                case 1:
                    if (hero.money >= 30)
                    {
                        hero.money -= 30;
                        Outer.TwriteLine("\nСпасибо за покупку!\n", Settings.T1);
                        q_leva_1 = 2;
                    }
                    break;

                case 2:
                    Market.Weapon_goods(hero);
                    break;

                case 3:
                    Market.Armor_goods(hero);
                    break;

                case 4:
                    if (hero.money >= 20)
                    {
                        hero.money -= 20;
                        hero.Potion_list[0].Count += 1;
                    }
                    else
                        Outer.TwriteLine("\nВы нищеброд! Проваливайте!\n", Settings.T1);
                    break;

                case 5:
                    if (hero.money >= 30)
                    {
                        hero.money -= 30;
                        hero.Potion_list[1].Count += 1;
                    }
                    else
                        Outer.TwriteLine("\nВы нищеброд! Проваливайте!\n", Settings.T1);
                    break;

                case 6:
                    Location.Village(hero);
                    break;
            }
        }

        //  Квест "Кiт, ты хозяина мав?"
        public void Q_kita(Hero hero)
        {
            Console.WriteLine("Вы видите кошку");
            Console.WriteLine("Идя вдоль рынка вы замечаете у прилавка человека, что часто кашляет. Старик, увидя вас приятно улыбается." +
                "- Добрый день, не хотите ли чего приобрести ? -сказал указав на прилавок с не особо свежими фруктами.");
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
    }
}
