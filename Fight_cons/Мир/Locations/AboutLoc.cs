using Fight_cons.Мир;
using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Fight_cons
{
    class AboutLoc
    {
        /// <summary>
        ///  Названия локаций с значением для вызова описания
        /// </summary>
        public enum LocationName
        {
            Caves = 0,
            Vally = 1,
            Neighborhood = 2,
            Village = 3,
            Inn = 4,
            Market = 5,
            DeepWoods = 6
        }

        /// <summary>
        ///  Описания локаций
        /// </summary> 
        public static string[][] Discript = new string[][]
        {
            //  Пещеры
            new string[]
            {
                "Тут довольно холодно и сыро",
                "Место очень заросло и было бы невозможно ориентироваться если бы не\n" + "маленькие отверстия в потолке",
                "Эти пещеры наполнены зловонием павших тел",
            },
            //  Долина
            new string[]
            {
                "Долина дает увидеть пещеры под холмистой местность, темный лес, хижины людей и совсем рядом с ними жилище духов",
                "Духи любят пировать вместе с другими",
                "Чистая, приятная и свежая трава под ногами. Вам это по нраву",
            },
            //  Окрестности деревни
            new string[]
            {
                "Духи хоть и живут отдельно, но видно, что им дозволено бродить по деревне",
                "Люди занимаются земледелием и проводят вас взглядом",
                "Бедный музыкант всегда может надеяться на монету, когда выступает для духов",
                "Обрывки диалогов рассказывают вам о необычайно богатом духе и странным к нему\n отношению",
                "Жизнь тут спокойная и размеренная, никто не торопиться и не спешит",
            },
            //  Деревня
            new string[]
            {
                "Небольшая деревня, безликие и уставшие направляются в трактир",
                "Монахи, что бродят тут, строят дома, молятся Ораулу и приносят дары духам",
                "Некоторые монахи достигли просветления и соединились с духами, теперь они едины и борются с демонами",
                "Местные дети играют с животными-духами. Духи любят детей из-за схожести",
            },
            //  Трактир
            new string[]
            {
                "Трактир, место для лечения горя",
                "Люди шепчутся об очередном пробуждении Атронахов, коем вы видимо и являетесь",
                "Монах по кличке 'Бегемот Лева' пьет эль как не в себя, попутна рассказывая сомнительные истории и похабные анекдоты",
                "Периодически вы чувствуете чей-то взгляд на себе, но оборачиваясь никого не находите",
            },
            //  Рынок
            new string[]
            {
                "Духи зазывалы, еще более навязчивые, чем люди. Приходить сюда стоит с точным осознанием того что нужно купить",
                "Орехи, драгоценности, оружия. Духи успевают раздобыть все что необходимо",
                "Довольные лица покупателей и еще более довольное лицо продавцов",
                "Духам нравятся ценности, они находят много самородков и просят делать украшения, взамен на пару приманутых овец и кувшин чистой воды",
            },
            //  Леса
            new string[]
            {
                "Лес настолько густой, что даже ясное солнце не может пробиться сквозь плотную листву",
                "Находясь в лесу, кажется что ночная тьма отличается от тьмы здешней",
                "Пугает ни сколько дикие животные звуки, сколь их отсутствие",
                "В этом месте нет ветра, но холод пробирает до дрожи. Как и то что слышно только свое дыхание и хрустящие шаги",
            }
        };

        public static string CurrentLocationName;

        /// <summary>
        /// Список противников
        /// </summary>
        public static List<Order> EnemyList = new List<Order>();

        /// <summary>
        /// Выбор противника из списка
        /// </summary>
        public static Enemy Enemies(int id)
        {
            List<Enemy> enemies = new List<Enemy>()
            {
                //  Пещерные противники
                /*0*/new Enemy("Нечто Неизведанное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 3, SPD_min: 30, SPD_max: 40, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, wild: true),
                /*1*/new Enemy("Нечто Бронированное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 40, CRIT_min: 5, CRIT_max: 10, DEF_min: 20, DEF_max: 70, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 1, max_turn_max: 2, strategy: 0, wild: true),
                /*2*/new Enemy("Нечто Магическое", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 45, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 30, M_DEF_max: 70, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, wild: true),

                //  Противники в долине
                /*3*/new Enemy("Зверь", phase: 0, HP_min: 10, HP_max: 20, ATT_min: 1, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 1, CRIT_max: 2, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 20, BLK_max: 40, max_turn_min: 1, max_turn_max: 2, strategy: 1, wild: true),

                //  Противники в лесу
                /*4*/new Enemy("Демон", phase: 0, HP_min: 15, HP_max: 30, ATT_min: 3, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 10, CRIT_max: 15, DEF_min: 0, DEF_max: 0, M_DEF_min: 20, M_DEF_max: 30, BLK_min: 1, BLK_max: 5, max_turn_min: 2, max_turn_max: 5, strategy: 0),

                //  Противники в деревне
                /*5*/new Enemy("Ворюга", phase: 0, HP_min: 10, HP_max: 15, ATT_min: 3, ATT_max: 5, SPD_min: 30, SPD_max: 30, CRIT_min: 20, CRIT_max: 30, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 20, BLK_max: 40, max_turn_min: 4, max_turn_max: 5, strategy: 1),
                //  Противники в деревне
                /*6*/new Enemy("Ог", phase: 4, HP_min: 40, HP_max: 60, ATT_min: 1, ATT_max: 2, SPD_min: 0, SPD_max: 10, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 0, BLK_max: 0, max_turn_min: 1, max_turn_max: 2, strategy: 1),
                /*7*/new Enemy("Таотот", phase: 3, hp: 50, attack: 3, speed: 30, crit_chance: 20, defence: 10, magic_defence: 30, block: 0, max_moves: 5, no_run: true),
                /*8*/new Enemy("Камень", phase: 0, hp: 6, attack: 0, speed: 0, crit_chance: 0, defence: 0, magic_defence: 0, block: 0, max_moves: 2, no_run: true),
                /*9*/new Enemy("Некромант", phase: 0, hp: 20, attack: 0, speed: 20, crit_chance: 0, defence: 0, magic_defence: 30, block: 0, max_moves: 5, no_run: true, strategy: 3),
                /*10*/new Enemy("Жертвиник", phase: 0, hp: 20, attack: 0, speed: 0, crit_chance: 0, defence: 0, magic_defence: 0, block: 0, max_moves: 2, no_run: true, strategy: 4),
            };

            return enemies[id];
        }
        public static Ally Allies(int id)
        {
            List<Ally> allies = new List<Ally>()
            {
                //  Пещерные противники
                /*0*/new Ally("Доброе Неизведанное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 3, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, wild: true),
                /*1*/new Ally("Доброе Бронированное", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 10, DEF_min: 20, DEF_max: 70, M_DEF_min: 0, M_DEF_max: 0, BLK_min: 10, BLK_max: 30, max_turn_min: 1, max_turn_max: 2, strategy: 0, wild: true),
                /*2*/new Ally("Доброе Магическое", phase: 0, HP_min: 5, HP_max: 15, ATT_min: 1, ATT_max: 2, SPD_min: 30, SPD_max: 30, CRIT_min: 5, CRIT_max: 10, DEF_min: 0, DEF_max: 0, M_DEF_min: 30, M_DEF_max: 70, BLK_min: 10, BLK_max: 30, max_turn_min: 2, max_turn_max: 3, strategy: 0, wild: true),
            };

            return allies[id];
        }

        /// <summary>
        /// Вызов рандомномного описания из массива описаний
        /// </summary>
        public static string Dicscriptions(LocationName en)
        {
            Random rand = new Random();
            return Discript[(int)en][rand.Next(Discript[(int)en].Length)];
        }

        /// <summary>
        ///  Находки при исследовании локаций
        /// </summary>
        public static void Research(Hero hero)
        {
            if (hero.HeroStatistic.CaveResearch == 20)
            {
                Output.Spent(0, "Древний свиток исцеления", true);

                SpellDes excision = new SpellDes(hero, "Исцеление")
                {
                    Spell = SpellDes.ExcisionSpell,
                    Description = $"Исцеление (3 MP)",
                    Spell_cost = 0,
                    Spell_power = 0,
                };
            }

            if (hero.HeroStatistic.CaveResearch == 30)
            {
                Console.WriteLine("Вы слышите в темноте как что-то огромное надвигается на вас!");
                Battles.MakeBattle(hero, 6);
            }
        }

        #region События на локациях
        //  Выпить в таверне
        public static void Drinking(Hero hero)
        {
            Sound.DRINK();
            Output.TwriteLine("Вы чувствуете как холодный эль заливается в вас", 1);
            Output.TwriteLine("Вам нравится\n", 30);
            if (hero.drunk > 3)
            {
                Sound.HIT();
                Output.TwriteLine("*Звук удара головы об стол*", 1);
                Output.Wait_next(9, "Z");
                Output.TwriteLine("Вы проснулись", 50);
                Output.TwriteLine("Щас бы эля холодного...", 10);
                Console.ReadKey();
                hero.drunk = 0;
                hero.Max_drunk += 1;
                VillageLoc.Inn(hero);
            }
            hero.HeroSpying.Sneak = 0;
            hero.drunk++;
        }

        //  Отдых  
        public static void RestEvent(Hero hero)
        {
            double H = (hero.MaxHp / 100.0) * 30.0, M = (hero.MaxMp / 100.0) * 20.0;
            hero.HP += (int)H;
            hero.MP += (int)M;
            Output.WriteColorLine(ConsoleColor.Green, "Небольшой перерыв восстановил вам ", $"+{(int)H} ", "HP ");
            Output.WriteColorLine(ConsoleColor.Blue, "и ", $"+{(int)M} ", "MP\n");
            Output.Wait_next(3, ".");
        }

        //  Кошелек
        public static void FindingPouchEvent(Hero hero, int n_min, int n_max)
        {
            Output.TwriteLine("Вы находите кошелек!\n"
                                         + "1) Взять его\n"
                                         + "2) Пройти мимо\n", 40);

            switch (Input.ChoisInput(hero, 1, 2))
            {
                case 1:
                    if (Battles.Vero(0.7))
                    {
                        Random rand = new Random();
                        Output.WriteColorLine(ConsoleColor.Yellow, "Открывая кошелек вы находите ", $"{n_min = rand.Next(n_min, n_max)}\u00A2 ", "монеток\n");
                        hero.Money += n_min;
                    }
                    else
                        Battles.MakeBattle(hero, 5);
                    break;
                case 2:
                    Output.TwriteLine("Вы проходите мимо", 40);
                    break;
            }
        }

        //  Bar-game
        public static void ArmGameEvent(Hero hero)
        {
            hero.Money -= Arm_game.Cost;

            Arm_game form1 = new Arm_game(hero);
            DialogResult res = form1.ShowDialog();
            if (res == DialogResult.Yes)
            {
                Console.WriteLine("Поздравляю! Вот ваши деньги\n");
                hero.Money += Arm_game.Cost * 2;
            }
            else
                Console.WriteLine("Слабак...\n");
        }

        #endregion
    }
}
