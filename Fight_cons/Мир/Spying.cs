using Fight_cons.Мир;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    //  Подслушивание в локациях
    public class Spying
    {
        //  Разговорные штуки в таверне:
        private sbyte TavernTalksProgress;
        internal byte Sneak = 0;

        //  Подслушивание в таверне
        internal void Spying_tavern(Hero hero)
        {
            hero.HeroQuests.StartQ(hero, 1);
            hero.HeroQuests.Q_Leva_1(hero);

            if (Sneak < 3)
            {
                if (Battles.Vero(0.6))
                    Tavern_talks(hero);
                if (hero.HeroQuests.Que[1] == 4)
                    Output.TwriteLine("'А вот и наш герой!' - восклицает Бегемот.\nПозади него вы видите коллекцию статуэток из дерева\n", 1);

                Sneak++;
            }
            else
            {
                Output.TwriteLine("- Пришел уши греть?! Хочешь сидеть в трактире покупай выпивку!\n", 1);
                Console.Write("Ваши действия?\n");
                Output.WriteColorLine(ConsoleColor.Yellow, "1) Купить выпивку (", "5\u00A2", ")\n");
                Console.Write("2) Отказаться и уйти\n");

                switch (Input.ChoisInput(1, 2))
                {
                    case 1:
                        if (hero.Money >= 5)
                        {
                            hero.Money -= 5;
                            Output.TwriteLine("\n- Так-то лучше\n", 1);
                            Output.TwriteLine("*Трактирщик наливает вам выпивки*\n", 1);
                            AboutLoc.Drinking(hero);
                        }
                        else
                        {
                            Output.TwriteLine("- Пщел отсюда скряга!\n", 1);
                            hero.HeroStatistic.Hero_lvl_know = hero.Lvl;
                            VillageLoc.Village(hero);                                                        
                        }
                        break;
                    case 2:
                        Output.TwriteLine("- Пщел отсюда скряга!\n", 1);
                        VillageLoc.Village(hero);
                        break;
                }
            }
        }

        //  Подслушка
        private void Tavern_talks(Hero hero)
        {
            switch (TavernTalksProgress)
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
                    TavernTalksProgress++;
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
                    Output.TwriteLine("Высокий мужчина сильно удалил балабола по затылку. ", 30);
                    Console.ReadKey(true);
                    Output.TwriteLine("- Даже не вздумай сквернословить на храм. \n", 30);
                    Console.ReadKey(true);
                    TavernTalksProgress++;
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
                    TavernTalksProgress++;
                    break;
                #endregion
            }
        }
    }
}
