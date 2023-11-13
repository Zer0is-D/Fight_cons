using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Fight_cons
{
    class Location
    {
        //  Название локации
        public static string Loc_name;

        //  Список врагов (Перенести в другое место)
        public static Enemy Enemies(Hero hero, int id)
        {
            List<Enemy> enemies = new List<Enemy>()
            {
                //  Пещерные противники
                new Enemy(hero, "Неизведанное", HP_min: 5, HP_max: 10, ATT_min: 1, ATT_max: 3, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 15, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 2),
                new Enemy(hero, "Бронированное", HP_min: 5, HP_max: 10, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 15, DEF_min: 20, DEF_max: 70, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 1, max_turn_max: 2, strategy: 2),
                new Enemy(hero, "Магическое", HP_min: 5, HP_max: 10, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 15, DEF_min: 0, DEF_max: 0, M_DEF_min: 30, M_DEF_max: 70, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 2),

                //  Противники в долине
                new Enemy(hero, "Зверь", HP_min: 10, HP_max: 20, ATT_min: 1, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 1, CRIT_max: 2, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 20, BLK_max: 40, max_turn_min: 1, max_turn_max: 2, strategy: 1),

                //  Противники в лесу
                new Enemy(hero, "Демон", HP_min: 10, HP_max: 15, ATT_min: 3, ATT_max: 6, SPD_min: 30, SPD_max: 30, CRIT_min: 10, CRIT_max: 15, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 1, BLK_max: 10, max_turn_min: 2, max_turn_max: 6, strategy: 2),

                //  Противники в деревне
                new Enemy(hero, "Ворюга", HP_min: 15, HP_max: 20, ATT_min: 3, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 20, CRIT_max: 30, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 20, BLK_max: 40, max_turn_min: 4, max_turn_max: 6, strategy: 1),
            };

            return enemies[id - 1];
        }


        //  Локации:
        //  Пещеры начало
        public static void Caves_begin(Hero hero)
        {
            //  Название локации
            Loc_name = "???";

            //  Описания локации
            string[] Discript = new string[2];
            Discript[0] = "Тут довольно холодно и сыро";
            Discript[1] = "Место очень заросло и было бы невозможно ориентироваться если бы не\n" +
                "маленькие отверстия в потолке";

            while (true)
            {
                //  Возможные события в локации

                Outer.ChangeColor("\nЛокация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);
                hero.HP_bar();
                hero.MP_bar();

                Console.Write("Ваши действия?\n"
                                + "1) Обыскать пещеру\n"
                                + "2) Отдохнуть\n");
                if (Hero.Exit_cave)
                    Console.Write("3) Выйти из пещеры\n");

                switch (Input.Chois_input(hero, 0, 4))
                {
                    case 1:
                        if (Mechanics.Vero(0.25))
                            if (!Hero.Exit_cave)
                            {
                                Outer.TwriteLine("\nВы находите выход\n", 1);
                                Hero.Exit_cave = true;
                            }
                        if (Mechanics.Vero(0.7))
                        {
                            if (Mechanics.Vero(0.4))
                                Mechanics.Battle(hero, Enemies(hero, 1));
                            else if (Mechanics.Vero(0.4))
                                Mechanics.Battle(hero, Enemies(hero, 4));
                            else if (Mechanics.Vero(0.4))
                                Mechanics.Battle(hero, Enemies(hero, 3));
                            else
                                Mechanics.Battle(hero, Enemies(hero, 2));
                        }
                        hero.Hero_stats.Cave_ad++;
                        Research(hero);
                        break;
                    case 2:
                        if (Mechanics.Vero(0.8))
                            Mechanics.Rest(hero);
                        else
                        {
                            Mechanics.Rest(hero);
                            Mechanics.Battle(hero, Enemies(hero, 1));
                        }
                        break;
                    case 3:
                        if (Hero.Exit_cave)
                            Vally(hero);
                        break;
                }
            }
        }

        //  Пещеры
        public static void Caves(Hero hero)
        {
            //  Название локации
            Loc_name = "Пещеры";

            //  Описания локации
            string[] Discript = new string[1];
            Discript[0] = "Эти пещеры наполнены зловонием павших тел";


            while (true)
            {
                //  Возможные события в локации

                Outer.ChangeColor("Локация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);
                hero.HP_bar();
                hero.MP_bar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Обыскать пещеру\n"
                                + "2) Отдохнуть\n"
                                + "3) Выйти из пещеры");

                switch (Input.Chois_input(hero, 0, 4))
                {
                    case 1:
                        if (Mechanics.Vero(0.7))
                        {
                            if (Mechanics.Vero(0.4))
                                Mechanics.Battle(hero, Enemies(hero, 1));
                            else if (Mechanics.Vero(0.4))
                                Mechanics.Battle(hero, Enemies(hero, 3));
                            else
                                Mechanics.Battle(hero, Enemies(hero, 2));
                        }
                        hero.Hero_stats.Cave_ad++;
                        Research(hero);
                        break;
                    case 2:
                        Mechanics.Rest(hero);
                        break;
                    case 3:
                        Vally(hero);
                        break;
                }
            }
        }

        //  Долина
        public static void Vally(Hero hero)
        {
            //  Название локации
            Loc_name = "Долина";

            //  Описания локации
            string[] Discript = new string[3];
            Discript[0] = "Долина дает увидеть пещеры под холмистой местность, темный лес, хижины людей и совсем рядом с ними жилище духов";
            Discript[1] = "Духи любят пировать вместе с другими";
            Discript[2] = "Чистая, приятная и свежая трава под ногами. Вам это по нраву";

            while (true)
            {
                //  Возможные события в локации
                if (Mechanics.Vero(0.4))
                    Mechanics.Battle(hero, Enemies(hero, 4));
                if (Mechanics.Vero(0.01))
                    Game_events.Pouch(hero, 1, 7);

                Outer.ChangeColor("\nЛокация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);
                hero.HP_bar();
                hero.MP_bar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Вернуться в пещеры\n"
                                + "2) Передохнуть\n"
                                + "3) Пойти в деревню\n"
                                + "4) Пойти в лес");

                switch (Input.Chois_input(hero, 0, 5))
                {
                    case 1:
                        Caves(hero);
                        break;
                    case 2:
                        Mechanics.Rest(hero);
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                    case 4:
                        Deep_woods(hero);
                        break;
                }
            }
        }

        //  Окрестности
        public static void Neighborhood(Hero hero)
        {
            //  Название локации
            Loc_name = "Окрестности деревни";

            //  Описания локации
            string[] Discript = new string[5];
            Discript[0] = "Духи хоть и живут отдельно, но видно, что им дозволено бродить по деревне";
            Discript[1] = "Люди занимаются земледелием и проводят вас взглядом";
            Discript[2] = "Бедный музыкант всегда может надеяться на монету, когда выступает для духов";
            Discript[3] = "Обрывки диалогов рассказывают вам о необычайно богатом духе и странным к нему\n отношению";
            Discript[4] = "Жизнь тут спокойная и размеренная, никто не торопиться и не спешит";

            while (true)
            {
                if (!hero.know_name)
                    Your_name(hero);

                //  Возможные события в локации
                if (Mechanics.Vero(0.3))
                    Game_events.Pouch(hero, 0, 5);
                if (Mechanics.Vero(0.1))
                    Mechanics.Battle(hero, Enemies(hero, 6));

                Outer.ChangeColor("\nЛокация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);
                hero.HP_bar();
                hero.MP_bar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Войти в деревню\n"
                                + "2) Отдохнуть\n"
                                + "3) Вернуться в долину");

                switch (Input.Chois_input(hero, 0, 4))
                {
                    case 1:
                        Village(hero);
                        break;
                    case 2:
                        Mechanics.Rest(hero);
                        break;
                    case 3:
                        Vally(hero);
                        break;
                }
            }
        }

        //  Деревня
        public static void Village(Hero hero)
        {
            //  Название локации
            Loc_name = "Деревня";

            //  Описания локации
            string[] Discript = new string[4];
            Discript[0] = "Небольшая деревня, безликие и уставшие направляются в трактир";
            Discript[1] = "Монахи, что бродят тут, строят дома, молятся Ораулу и приносят дары духам";
            Discript[2] = "Некоторые монахи достигли просветления и соединились с духами, теперь они едины и борются с демонами";
            Discript[3] = "Местные дети играют с животными-духами. Духи любят детей из-за схожести";

            while (true)
            {
                //  Возможные события в локации
                if (Mechanics.Vero(0.15))
                    Game_events.Pouch(hero, 3, 10);
                if (Mechanics.Vero(0.05))
                    Mechanics.Battle(hero, Enemies(hero, 6));

                Outer.ChangeColor("Локация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);
                hero.HP_bar();
                hero.MP_bar();

                Console.Write("\nВаши действия?\n");
                if (hero.lvl > Hero.Hero_lvl_know)
                    Console.Write("1) Пойти в трактир\n");
                else
                    Outer.ChangeColor("", "1) Пойти в трактир (Вас прогнали, приходите позже)", "\n", ConsoleColor.Gray);

                Console.WriteLine("2) Пойти на рынок\n"
                            + "3) Выйти из деревни");

                switch (Input.Chois_input(hero, 0, 4))
                {
                    case 1:
                        if (hero.lvl > Hero.Hero_lvl_know)
                            Inn(hero);
                        else
                            Village(hero);
                        break;
                    case 2:
                        Market_loc(hero);
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                }
            }
        }

        //  Трактир
        public static void Inn(Hero hero)
        {
            //  Название локации
            Loc_name = "Трактир";

            //  Описания локации
            string[] Discript = new string[4];
            Discript[0] = "Трактир, место для лечения горя";
            Discript[1] = "Люди шепчутся об очередном пробуждении Атронахов, коем вы и являетесь";
            Discript[2] = "Монах по кличке 'Бегемот Лева' пьет эль как не в себя, попутна рассказывая сомнительные истории и похабные анекдоты";
            Discript[3] = "Периодически вы чувствуете чей-то взгляд на себе, но оборачиваясь никого не находите";

            while (true)
            {
                Outer.ChangeColor("Локация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);

                if (IsThisNum(Discript[1], Discript, 1))
                    hero.Class_name = "Атронах";

                hero.HP_bar();
                hero.MP_bar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Наблюдать и подслушивать\n"
                                + "2) Выпить (5 золотых)\n"
                                + $"3) Армреслинг ({Arm_game.Cost} золотых)\n"
                                + "4) Выйти из трактира");

                switch (Input.Chois_input(hero, 0, 5))
                {
                    case 1:
                        hero.Hero_spying.Spying_tavern(hero);
                        break;
                    case 2:
                        if (hero.money >= 5)
                        {
                            hero.money -= 5;
                            Drinking(hero);
                        }
                        else
                            Outer.TwriteLine("Заплати, а потом пей!", Settings.T1);                       
                        break;
                    case 3:
                        if (hero.money >= Arm_game.Cost)
                            Bar_game(hero);
                        else
                            Outer.TwriteLine("Бесплатно не интересует\n", Settings.T1);
                        break;
                    case 4:
                        Village(hero);
                        break;    
                }
            }
        }

        //  Рынок
        public static void Market_loc(Hero hero)
        {
            //  Название локации
            Loc_name = "Рынок";

            //  Описания локации
            string[] Discript = new string[4];
            Discript[0] = "Духи зазывалы, еще более навязчивые, чем люди. Приходить сюда стоит с точным осознанием того что нужно купить";
            Discript[1] = "Орехи, драгоценности, оружия. Духи успевают раздобыть все что необходимо";
            Discript[2] = "Довольные лица покупателей и еще более довольное лицо продавцов";
            Discript[3] = "Духам нравятся ценности, они находят много самородков и просят делать украшения, взамен на пару приманутых овец и кувшин чистой воды";

            while (true)
            {
                //  Возможные события в локации
                if (Mechanics.Vero(0.01))
                    Game_events.Pouch(hero, 10, 100);

                Outer.ChangeColor("\nЛокация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);
                hero.HP_bar();
                hero.MP_bar();

                //  Квесты
                if (hero.Hero_quest.q_leva_1 == 1)
                    hero.Hero_quest.Q_leva_Market(hero);

                Console.WriteLine("\nВаши действия?\n"
                              + "1) Наблюдать и подслушивать\n"
                              + "2) Купить оружие\n"
                              + "3) Купить броню\n"
                              + "4) Купить зелье здоровья (20 золотых)\n"
                              + "5) Купить зелье маны (30 золотых)\n"
                              + "6) Выйти");

                switch (Input.Chois_input(hero, 0, 7))
                {
                    case 1:
                        //  Событие прослушивание  
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
                        Village(hero);
                        break;
                }
            }
        }

        //  ???
        public static void Manor_House(Hero hero)
        {
            //  Название локации
            Loc_name = "Поместье";

            //  Описания локации
            string[] Discript = new string[4];
            Discript[0] = "1";
            Discript[1] = "2";
            Discript[2] = "3";
            Discript[3] = "4";

            while (true)
            {
                Outer.ChangeColor("\nЛокация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), 0);
                hero.HP_bar();
                hero.MP_bar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Наблюдать и подслушивать\n"
                                + "2) Общаться\n"
                                + "3) Выйти из поместье");

                switch (Input.Chois_input(hero, 0, 4))
                {
                    case 1:
                        //  Событие "Осмотреться"
                        break;
                    case 2:
                        //  Событие прослушивание
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                }
            }
        }

        //  Храм
        public static void Templ(Hero hero)
        {
            //  Название локации
            Loc_name = "Храм";

            //  Описания локации
            string[] Discript = new string[4];
            Discript[0] = "Место где становятся монахами";
            Discript[1] = "Огромный красивый зал, можно только догадываться как тут было прекрасно, до обвала";
            Discript[2] = "3";
            Discript[3] = "4";

            while (true)
            {
                Outer.ChangeColor("\nЛокация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), 0);
                hero.HP_bar();
                hero.MP_bar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Наблюдать и подслушивать\n"
                                + "2) Общаться\n"
                                + "3) Выйти из поместье");

                switch (Input.Chois_input(hero, 0, 4))
                {
                    case 1:
                        //  Событие "Осмотреться"
                        break;
                    case 2:
                        //  Событие прослушивание
                        break;
                    case 3:
                        Neighborhood(hero);
                        break;
                }
            }
        }

        //  Темные леса
        public static void Deep_woods(Hero hero)
        {
            //  Название локации
            Loc_name = "Леса";

            //  Описания локации
            string[] Discript = new string[4];
            Discript[0] = "Лес настолько густой, что даже ясное солнце не может пробиться сквозь плотную листву";
            Discript[1] = "Находясь в лесу, кажется что ночная тьма отличается от тьмы здешней";
            Discript[2] = "Пугает ни сколько дикие животные звуки, сколь их отсутствие";
            Discript[3] = "В этом месте нет ветра, но холод пробирает до дрожи. Как и то что слышно только свое дыхание и хрустящие шаги";

            while (true)
            {
                Outer.ChangeColor("\nЛокация: ", $"{Loc_name}", "\n", ConsoleColor.Cyan);
                Outer.TwriteLine_general(Rand_discrip(Discript), Settings.T1);
                hero.HP_bar();
                hero.MP_bar();

                Console.WriteLine("\nВаши действия?\n"
                                + "1) Бродить\n"
                                + "2) Отдохнуть\n"
                                + "3) Вернуться в долину");

                switch (Input.Chois_input(hero, 0, 4))
                {
                    case 1:                           
                        if (Mechanics.Vero(0.1))
                        {
                            Outer.TwriteLine("Вы находите Таотота", Settings.T1);
                            hero.Hero_quest.Game_win_q = 1;
                            Game_events.Boss_fight(hero);
                        }
                        //else if (Mechanics.Vero(0.9))
                        //{
                        //    Enemy Drevo = new Enemy
                        //    {
                        //        Name = "Drevo",
                        //        MAX_HP = 20,
                        //        hp = 20,
                        //        RUN = false
                        //    };
                        //    Mechanics.Battle(hero, Drevo);
                        //}                            
                        else if (Mechanics.Vero(0.6))
                            Mechanics.Battle(hero, Enemies(hero, 4));
                        else if (Mechanics.Vero(0.4))
                            Mechanics.Battle(hero, Enemies(hero, 5));
                        else
                            Outer.TwriteLine("Вы ничего не находите\n", Settings.T1);
                        break;
                    case 2:
                        Mechanics.Rest(hero);
                        break;
                    case 3:
                        Vally(hero);
                        break;
                }
            }
        }


        //  Проверки и события
        //  Проверака индекса описания
        static bool IsThisNum(string val, string[] array, int num)
        {
            return val == array[num];
        }

        //  Рандомное описание
        public static string Rand_discrip(string[] Discript)
        {
            Random rand = new Random();
            return Discript[rand.Next(Discript.Length)];
        }            

        //  Находки при исследовании
        public static void Research(Hero hero)
        {
            if (hero.Hero_stats.Cave_ad == 20)
            {
                Console.WriteLine("Вы нашли древний свиток исцеления");

                Spell_des excision = new Spell_des(hero, "Исцеление")
                {
                    Spell = Spell_des.Excision,
                    Spell_cost = 6
                };
                excision.Description = $"Исцеление ({excision.Spell_cost} MP)";
            }
        }

        //  Выпить в таверне
        public static void Drinking(Hero hero)
        {
            Sound.DRINK();
            Outer.TwriteLine("Вы чувствуете как холодный эль заливается в вас", Settings.T1);
            Outer.TwriteLine("Вам нравится\n", Settings.T30);
            if (hero.drunk > 3)
            {
                Sound.HIT();
                Outer.TwriteLine("*Звук удара головы об стол*", Settings.T1);
                Outer.Wait_next(9, "Z");
                Outer.TwriteLine("Вы проснулись", Settings.T50);
                Outer.TwriteLine("Щас бы эля холодного...", Settings.T10);
                Console.ReadKey();
                hero.drunk = 0;
                hero.Max_drunk += 1;
                Inn(hero);
            }
            hero.Hero_spying.sneak = 0;
            hero.drunk++;
        }

        //  Name
        public static void Your_name(Hero hero)
        {
            Outer.TwriteLine("Проходя вдоль переулка к вам обращается рыжеволосый мальчик.", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("- Эй, Камень, ты что тут забыл? Мне мама говорила вы только зверьми бываете.", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("- ...", Settings.T30);
            Console.ReadKey(true);
            Outer.TwriteLine("Вы уже хотели ответить, но не смогли издать ни звука.", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("- Эй, ты чего молчишь? Говорить не умеешь?", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("- Ну и ну, в человека превращаешься, а Камнем и остался - просмеялся мальчик.", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("Неподалеку послышался крик:\n- Эй, ты опять...Ох, а вы?.. - спросил мужчина с светло рыжей бородой.", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("- Камень! Я его назвал Камень!", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("\n(Внимание вопрос! Вы Камень? потом это запишется в имя)\n"
                + "1) Неодобрительно кивнуть\n"
                + "2) Одобрительно кивнуть", Settings.T10);

            switch (Input.Chois_input(hero, 0, 3))
            {
                case 1:                    
                    hero.know_name = true;
                    break;
                case 2:
                    hero.Name = "Камень";
                    hero.know_name = true;
                    break;
            }
            Outer.TwriteLine("- Вы его извините, он совсем неугомонный. С ним я даже с работой не успеваю.", Settings.T10);
            Console.ReadKey(true);
            Outer.TwriteLine("- Надеюсь он вам не сильно помешал. Всего доброго. - они поспешно удалились.\n", Settings.T10);
            Console.ReadKey(true);
        }

        //  Timer
        public static void Waiting_tavern(int wait)
        {
            Timer timer = new Timer(wait);
        }

        //  Bar-game
        public static void Bar_game(Hero hero)
        {
            hero.money -= Arm_game.Cost;

            Arm_game form1 = new Arm_game(hero);
            DialogResult res = form1.ShowDialog();
            if (res == DialogResult.Yes)
            {
                Console.WriteLine("Поздравляю! Вот ваши деньги\n");
                hero.money += Arm_game.Cost * 2;
            }
            else
            {
                Console.WriteLine("Слабак...\n");
            }
        }
    }
}
