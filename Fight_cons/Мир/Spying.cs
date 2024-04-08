using Fight_cons.Основа_и_настройки;
using System;
using System.IO;
using System.Windows.Forms;
using static Fight_cons.AboutLoc;

namespace Fight_cons
{
    //  Подслушивание в локациях
    public class Spying
    {
        ////  Разговорные штуки в таверне:
        private static string Path = @"C:\Users\user\source\repos\AsyncListener\AsyncListener\bin\Debug\net6.0\AsyncListener.exe";

        //  Подслушивание в таверне
        internal void SpyingInTavern(Hero hero)
        {
            hero.HeroQuests.StartQ(hero, 1);
            hero.HeroQuests.Q_Leva_1(hero);

            if (hero.Sneak < 3)
            {
                if (GameFormulas.Vero(0.6))
                    TavernTalks(hero);
                if (hero.HeroQuests.Que[1] == 4)
                    Output.TwriteLine("'А вот и наш герой!' - восклицает Бегемот.\nПозади него вы видите коллекцию статуэток из дерева\n", 1);

                hero.Sneak++;
            }
            else
            {
                Output.TwriteLine("- Пришел уши греть?! Хочешь сидеть в трактире покупай выпивку!\n", 1);
                Console.Write("Ваши действия?\n");
                Output.PayMoneyLine("1) Купить выпивку", Output.BeerCost, hero.Money);
                Console.Write("2) Отказаться и уйти\n");

                switch (Input.ChoisInput(1, 2))
                {
                    case 1:
                        if (Output.Spent(hero.Money, Output.BeerCost, "", "- Пщел отсюда скряга!\n"))
                            Drinking(hero);
                        else
                        {
                            //Output.TwriteLine("- Пщел отсюда скряга!\n", 1);
                            hero.Statistic.HeroLvlKickOff = hero.Lvl;
                            DefualtLoad(hero, Locations[(int)LocationName.Village]);
                        }
                        break;
                    case 2:
                        //Output.TwriteLine("- Пщел отсюда скряга!\n", 1);
                        DefualtLoad(hero, Locations[(int)LocationName.Village]);
                        break;
                }
            }
        }       

        //  Подслушка
        private static void TavernTalks(Hero hero)
        {
            if (File.Exists(Path))
                PipeMessage.TavernLocal(hero);
            else
            {
                switch (hero.Statistic.TavernTalksProgress)
                {
                    #region Разговор о чудищах в лесу
                    case 0:
                        Output.TwriteLine("Слушая болтовню в трактире, вас увлек разговор группы запивак: ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- ...Помните? Так вот вы представляете, я его аж 5 раз убил. А он все живой. \nЯ таких чудишь еще видывал. ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Вранье! Да не мог ты его! Все тот лес за сотню миль обходят. ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Да! Вруешь! ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- И смельчаки, что живые прискакали, и слово теперь не вымолвят. \nА ты то как языком чешешь. - сказал посмеиваясь мужчина рядом. ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("Мужики посмеялись кроме пустослова. ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Эх, ну вас... Но морда у него..*ДУХ* ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("Грохот от упавшей бочки отвлек вас.\n", 30);
                        Console.ReadKey(true);
                        hero.Statistic.TavernTalksProgress++;
                        break;
                    #endregion

                    #region Разговор о кошельках
                    case 1:
                        Output.TwriteLine("Разглядывая стены бара вы заметили знакомые лица. Это снова те запиваки. \nВы прислушались: ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- ...то воришек что-то развелося. А? ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Нету их у нас. Говорю же тебе. ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Да есть! Аль откуда столько кошельков на дороге? Прикарманили, забрали \nценное и выкидывают. ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Дурень, и что, они в них монеты забывают? А? Это всевышний нам дары посылает.", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- А-а-а, так может это храмовники нас..*Стук* ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("Высокий мужчина сильно удалирил балабола по затылку. ", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Даже не вздумай сквернословить на храм. \n", 30);
                        Console.ReadKey(true);
                        hero.Statistic.TavernTalksProgress++;
                        break;
                    #endregion

                    #region Разговор о духах
                    case 2:
                        Output.TwriteLine("- Мне тот старик рассказывал.", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Как это так тело живет дальше?! Человек умер, значит его тело должно \nбыть в могиле! Не иначе!", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Если бы не глава храмовников... как его?", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Жар-Брока.", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Да, то чудного знахаря бы уже повесили на близ растущего дерева.", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- Он закрывает глаза на знахаря потому, что думает что это поможет деревне \nэтими его исслу.. исследавы... Тьфу, его колдовством!", 30);
                        Console.ReadKey(true);
                        Output.TwriteLine("- И еще говорит что доктор никому не навредит. С его то куклами...\n", 30);
                        Console.ReadKey(true);
                        hero.Statistic.TavernTalksProgress++;
                        break;
                        #endregion
                }
            }           
        }

        //  Подслушка окно
        public static string[] TavernTalks(sbyte i)
        {
            switch (i)
            {
                #region Разговор о чудищах в лесу
                case 0:
                    string[] mas =
                    {
                        "Разговор в таверне",
                        "Слушая болтовню в трактире, вас увлек разговор группы запивак: ",
                        "- ...Помните? Так вот вы представляете, я его аж 5 раз убил. А он все живой. \nЯ таких чудишь еще видывал. ",
                        "- Вранье! Да не мог ты его! Все тот лес за сотню миль обходят. ",
                        "- Да! Вруешь! ",
                        "- И смельчаки, что живые прискакали, и слово теперь не вымолвят. \nА ты то как языком чешешь. - сказал посмеиваясь мужчина рядом. ",
                        "Мужики посмеялись кроме пустослова. ",
                        "- Эх, ну вас... Но морда у него..*ДУХ* ",
                        "Грохот от упавшей бочки отвлек вас.\n"
                    };

                    return mas;
                    break;
                #endregion

                #region Разговор о кошельках
                case 1:
                    string[] mas2 =
                    {
                        "Разговор в таверне",
                        "Разглядывая стены бара вы заметили знакомые лица. Это снова те запиваки. \nВы прислушались: ",
                        "- ...то воришек что-то развелося. А? ",
                        "- Нету их у нас. Говорю же тебе. ",
                        "- Да есть! Аль откуда столько кошельков на дороге? Прикарманили, забрали \nценное и выкидывают. ",
                        "- Дурень, и что, они в них монеты забывают? А? Это всевышний нам дары посылает.",
                        "- А-а-а, так может это храмовники нас..*Стук* ",
                        "Высокий мужчина сильно удалирил балабола по затылку. ",
                        "- Даже не вздумай сквернословить на храм. \n",
                    };

                    return mas2;
                #endregion

                #region Разговор о духах
                case 2:
                    string[] mas3 =
                    {
                        "Разговор в таверне",
                        "- Мне тот старик рассказывал.",
                        "- Как это так тело живет дальше?! Человек умер, значит его тело должно \nбыть в могиле! Не иначе!",
                        "- Если бы не глава храмовников... как его?",
                        "- Жар-Брока.",
                        "- Да, то чудного знахаря бы уже повесили на близ растущего дерева.",
                        "- Он закрывает глаза на знахаря потому, что думает что это поможет деревне \nэтими его исслу.. исследавы... Тьфу, его колдовством!",
                        "- И еще говорит что доктор никому не навредит. С его то куклами...\n",
                    };

                    return mas3;
                    #endregion
            }

            return null;
        }
    }
}
