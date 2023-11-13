using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons
{
    partial class Hero
    {
        //  Шкала здоровья
        public void HP_bar()
        {
            double part = MAX_HP / 10.0, c = 0;
            //Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nHp: [");
            while (c <= MAX_HP)
            {
                if (c <= hp)
                    Outer.ChangeColor("", "#", "", ConsoleColor.Green);
                else
                    Outer.ChangeColor("", "#", "", ConsoleColor.Black);
                c += part;
            }

            Console.Write("]    ");
            Outer.Twrite($"HP: {hp}/{MAX_HP}", Settings.T50);
        }

        //  Шкала маны
        public void MP_bar()
        {
            double part = MAX_MP / 10.0, c = 0;
            //Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nMp: [");
            while (c <= MAX_MP)
            {
                if (mp == 0)
                    Outer.ChangeColor("", "#", "", ConsoleColor.Black);
                else if (c <= mp)
                    Outer.ChangeColor("", "#", "", ConsoleColor.Blue);
                else
                    Outer.ChangeColor("", "#", "", ConsoleColor.Black);
                c += part;
            }

            Console.Write("]    ");
            Outer.Twrite($"MP: {mp}/{MAX_MP}\n", 1);
        }

        //  Характеристики героя
        public void Stats()
        {
            Outer.ChangeColor("\nHero name: ", $"{Name}", "\n", ConsoleColor.DarkGreen);
            Console.WriteLine($"Class: {Class_name}\n"
                            + $"Lvl: {lvl}\t\tExp: {exp}/{exp_n_lvl} \n"
                            + $"HP: {hp}/{MAX_HP} \tMP: {mp}/{MAX_MP}\n"
                            + $"ATT: {Attack}\t\tARC: {Arcane}\n"
                            + $"DEF: {Defence * 100}%\t\tBLK: {Block * 100}%\n"
                            + $"SPD: {Speed * 100}%\tCrit: {Crit * 100}%\n"
                            + $"Money: {money}\n");
            Outer.ChangeColor("Экиперовано оружие:\n", $"{weapon.Name}", $" | {weapon.Weapon_stats(true, false)}\n", ConsoleColor.Cyan);
            Outer.ChangeColor("\nЭкиперована броня:\n", $"{armor.Name}", $" | {armor.Armor_stats(true, false)}\n", ConsoleColor.Cyan);
        }

        //  Начало начал
        public void Creat_hero(Hero hero)
        {
            Outer.TwriteLine_general("Громкий и непонятной природы звук постепенно пробуждает ваше тело.\n"
                      + "После чего вы слышите голос словно он у вас в голове.\n"
                      + "'ВСТАВАЙ ДУША, ВЕЛЮ ТЕБЕ РОЗЫСКАТЬ ТОАТОТА И ИЗНЕЧТОЖИТЬ!'\n", Settings.T10);

            hero.Name = "No_name";
            Console.ReadKey(true);
            Outer.TwriteLine_general("Ощущая внутри некую ответственность со странным желанием выполнить поручение\n"
                      + "вы решаетесь открыть глаза, но тьма не дает вам что-либо увидеть...\n", Settings.T10);

            Console.WriteLine("Выберите класс:\n"
              + $"1) Воин\n"
              + $"2) Волшебник\n"
              + $"3) Ловкач\n");

            switch (Input.Chois_input(hero, 0, 4))
            {
                case 1:
                    hero.Class_name = "Воин";
                    hero.class_Lvl_b.Hp += 1;
                    hero.class_Lvl_b.Attack += 1;
                    hero.class_Lvl_b.Defence += 0.01;
                    break;

                case 2:
                    hero.Class_name = "Волшебник";
                    hero.class_Lvl_b.Arcane += 1;
                    hero.class_Lvl_b.Magic_defence += 0.01;
                    hero.class_Lvl_b.Mp += 1;
                    break;

                case 3:
                    hero.Class_name = "Ловкач";
                    hero.class_Lvl_b.Crit += 0.01;
                    hero.class_Lvl_b.Speed += 0.01;
                    hero.class_Lvl_b.Block += 0.01;
                    break;
            }


            Weapon Sword_N_sheeld = new Weapon("Меч и щит", attack: 4, speed: 0, cost: 10, crit: 0, block: 0.25, move: -1);
            Weapon Twohand_sword = new Weapon("Двуручник", attack: 8, speed: -0.2, cost: 10, crit: 0.1, block: 0, move: -1);
            Weapon Two_knifes = new Weapon("Два клинка", attack: 3, speed: 0.2, cost: 10, crit: 0.3, block: 0, move: 0);
            Weapon Bow = new Weapon("Лук", attack: 5, speed: 0, cost: 10, crit: 0.1, block: 0, move: 1);

            Console.WriteLine("Выбери оружие?\n"
                          + $"1) {Sword_N_sheeld.Weapon_stats()}\n"
                          + $"2) {Twohand_sword.Weapon_stats()}\n"
                          + $"3) {Two_knifes.Weapon_stats()}\n"
                          + $"4) {Bow.Weapon_stats(true)}");

            switch (Input.Chois_input(hero, 0, 5))
            {
                case 1:
                    hero.weapon = Sword_N_sheeld;
                    break;

                case 2:
                    hero.weapon = Twohand_sword;
                    break;

                case 3:
                    hero.weapon = Two_knifes;
                    break;

                case 4:
                    hero.weapon = Bow;
                    break;
            }

            //  Выдать начальные навыки
            All_skills_ever.Skills(hero, 1);


            Outer.TwriteLine_general("Проходя рукой по пространству вокруг себя вы находите деревянную палку с чем-то мягким.\n"
                          + "Догадка была верна, это оказался факел, что освятил пространство. Но ответить на вопрос где вы, пока не удается.\n", Settings.T1);

            Location.Caves_begin(hero);
        }

        // Смерть героя
        public void Death()
        {
            if (Hero_quest.Game_win_q == 1)
                Outer.TwriteLine_general("\nВы погибли в попытки остановить Таотота", 30);
            else
                Console.WriteLine("Вы погибли!");

            Console.WriteLine("\nВаш счет:");
            Console.WriteLine($"Ур: {lvl}\n"
                           + $"Опыт: {exp}/{exp_n_lvl}\n"
                           + $"Золото: {money}\n");
            Console.ReadKey();

            //  Подсчет победных очков и запись в локальный рейтинг
            Rating.Rating_system(hero_lvl: lvl, hero_exp: exp, hero_money: money);

            Outer.TwriteLine("\nНачать с начала?\n"
                            + "1) Да\n"
                            + "2) Нет\n", 1);

            switch (Input.Sbyte_input())
            {
                case 1:
                    Hero hero = new Hero();
                    Creat_hero(hero);
                    break;

                default:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
