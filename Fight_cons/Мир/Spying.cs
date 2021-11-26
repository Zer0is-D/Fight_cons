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
        public sbyte tavern_talks_progress;
        public byte sneak = 0;

        //  Подслушивание в таверне
        public void Spying_tavern(Hero hero)
        {
            if (sneak < 3)
            {
                if (hero.Hero_quest.q_leva_1 >= 0 && hero.Hero_quest.q_leva_1 < 3 && sneak > 0)
                {
                    hero.Hero_quest.Q_Leva_1(hero);
                    sneak++;
                }                    
                else if (Mechanics.Vero(0.6))
                {
                    Tavern_talks(hero);
                    sneak++;
                }
                else
                {
                    Outer.TwriteLine("'А вот и наш герой!' - восклицает Бегемот.\nПозади него вы видите коллекцию статуэток из дерева\n", Settings.T1);
                    sneak++;
                }                    
            }
            else
            {
                Outer.TwriteLine("- Опять пришел уши греть?! Хочешь сидеть в трактире покупай выпивку!\n", Settings.T1);
                Console.Write("Ваши действия?\n"
                              + "1) Купить выпивку (5 золотых)\n"
                              + "2) Отказаться и уйти\n");

                switch (Input.Chois_input(hero.Choice, 0, 3))
                {
                    case 1:
                        if (hero.money >= 5)
                        {
                            hero.money -= 5;
                            Outer.TwriteLine("\n- Так-то лучше\n", 1);
                            Outer.TwriteLine("*Трактирщик наливает вам выпивки*\n", Settings.T1);
                            Location.Drinking(hero);
                        }
                        else
                        {
                            Outer.TwriteLine("- Пщел отсюда нищий!\n", Settings.T1);
                            Hero.Hero_lvl_know = hero.lvl;
                            Location.Village(hero);                                                        
                        }
                        break;
                    case 2:
                        Outer.TwriteLine("- Пщел отсюда нищий!\n", Settings.T1);
                        Hero.Hero_lvl_know = hero.lvl;
                        Location.Village(hero);
                        break;
                }
            }
        }

        //  Подслушка
        public void Tavern_talks(Hero hero)
        {
            //  Разговор о духах
            if (tavern_talks_progress == 2)
            {
                Outer.TwriteLine_general("- Мне тот старик рассказывал.", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Как это так тело живет дальше?! Человек умер, значит его тело должно \nбыть в могиле! Не иначе!", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Если бы не глава храмовников... как его?", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Жар-Брока.", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Да, то доктора бы уже повесили на близ растущего дерева.", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Он закрывает глаза на доктора потому, что думает что это поможет обществу \nэтими его исслу.. исследавы... Тьфу, его ересью!", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- И еще говорит что доктор никому не навредит. С его то куклами...\n", Settings.T30);
                Console.ReadKey(true);
                tavern_talks_progress++;
            }

            //  Разговор о кошельках
            if (tavern_talks_progress == 1)
            {
                Outer.TwriteLine("Разглядывая стены бара вы заметили знакомые лица. Это снова те запиваки. \nВы прислушались: ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- ...то воришек что-то развелося. А? ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Нету их у нас. Говорю же тебе. ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Да есть! Аль откуда столько кошельков на дороге? Прикарманили, забрали \nценное и выкидывают. ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Дурень, и что, они в них монеты забывают? А? Это всевышний нам дары посылает.", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- А-а-а, так может это храмовники нас..*Стук* ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine("Высокий мужчина сильно удалил балабола по затылку. ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Даже не вздумай сквернословить на храм. \n", Settings.T30);
                Console.ReadKey(true);
                tavern_talks_progress++;
            }


            //  Разговор о чудищах в лесу
            if (tavern_talks_progress == 0)
            {
                Outer.TwriteLine("Слушая болтовню в баре, вас увлек разговор группы запивак: ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- ...Помните? Так вот вы представляете, я его аж 5 раз убил. А он все живой. \nЯ таких чудишь еще видывал. ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Вранье! Да не мог ты его! Все тот лес за сотню миль обходят. ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Да! Вруешь! ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- И смельчаки, что живые прискакали, и слово теперь не вымолвят. \nА ты то как языком чешешь. - сказал посмеиваясь мужчина рядом. ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine("Мужики посмеялись кроме пустослова. ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine_general("- Эх, ну вас... Но морда у него..*ДУХ* ", Settings.T30);
                Console.ReadKey(true);
                Outer.TwriteLine("Грохот от упавшей бочки отвлек вас.\n", Settings.T30);
                Console.ReadKey(true);
                tavern_talks_progress++;
            }
        }
    }
}
