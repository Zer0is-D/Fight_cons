﻿using Fight_cons.Мир;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    partial class Hero
    {
        //  Характеристики героя
        public void Stats()
        {
            Output.WriteColorLine(ConsoleColor.DarkGreen, "\nHero name: ", $"{Name}\n");
            Console.WriteLine($"Class: {Class_name}\n"
                            + $"Lvl: {Lvl}\t\tExp: {Exp}/{_nextLvlExp} \n"
                            + $"HP: {TotalHP}/{TotalMaxHP} \tMP: {MP}/{TotalMaxMP}\n"
                            + $"ATT: {TotalAttack}\t\tARC: {TotalArcane}\n"
                            + $"DEF: {TotalDefence * 100}%\t\tMAG DEF: {TotalMagicDefence * 100}%\n"
                            + $"SPD: {TotalSpeed * 100}%\tCrit: {TotalCrit * 100}%\n"
                            + $"BLK: {TotalBlock * 100}%\n");
            Output.WriteColorLine(ConsoleColor.Yellow, $"Money: {Money}", "\u00A2\n");
            Output.WriteColorLine(ConsoleColor.Cyan, "Экиперовано оружие:\n", $"{HeroWeapon.Name} ", $"| {ItemChar.ItemStats(HeroWeapon, false)}");
            Output.WriteColorLine(ConsoleColor.Cyan, "\nЭкиперована броня:\n", $"{HeroArmor.Name} ", $"| {ItemChar.ItemStats(HeroArmor, false)}\n");
        }

        //  Начало начал
        public static void Creat_hero(Hero hero)
        {
            Output.TwriteLine("Громкий и непонятной природы звук постепенно пробуждает ваше тело.\n"
                      + "После чего вы слышите голос словно он у вас в голове.\n"
                      + "'ВСТАВАЙ ДУША, ВЕЛЮ ТЕБЕ РОЗЫСКАТЬ ТОАТОТА И ИЗНЕЧТОЖИТЬ!'\n", 10);

            hero.Name = "No_name";
            Console.ReadKey(true);
            Output.TwriteLine("Ощущая внутри некую ответственность со странным желанием выполнить поручение\n"
                      + "вы решаетесь открыть глаза, но тьма не дает вам что-либо увидеть...\n", 10);

            Console.WriteLine("Выберите класс:\n"
              + $"1) Воин (Упор на HP, Attack, Defence)\n"
              + $"2) Волшебник (Упор на Arcane, Magic Defence, MP)\n"
              + $"3) Ловкач (Упор на Crit, Speed, Block)\n");

            switch (Input.Chois_input(hero, 0, 4))
            {
                case 1:
                    hero.Class_name = "Воин";
                    hero.ClassBonuses.MaxHp += 1;
                    hero.ClassBonuses.Attack += 1;
                    hero.ClassBonuses.Defence += 0.01;
                    break;

                case 2:
                    hero.Class_name = "Волшебник";
                    hero.ClassBonuses.Arcane += 1;
                    hero.ClassBonuses.MagicDefence += 0.01;
                    hero.ClassBonuses.MaxMp += 1;
                    break;

                case 3:
                    hero.Class_name = "Ловкач";
                    hero.ClassBonuses.Crit += 0.01;
                    hero.ClassBonuses.Speed += 0.01;
                    hero.ClassBonuses.Block += 0.01;
                    break;
            }

            Weapon Sword_N_sheeld = new Weapon("Меч и щит", attack: 4, speed: 0, cost: 10, crit: 0, block: 0.25, maxMoves: -1);
            Weapon Twohand_sword = new Weapon("Двуручник", attack: 8, speed: -0.2, cost: 10, crit: 0.1, block: 0, maxMoves: -1);
            Weapon Two_knifes = new Weapon("Два клинка", attack: 3, speed: 0.2, cost: 10, crit: 0.3, block: 0, maxMoves: 0);
            Weapon Bow = new Weapon("Лук", attack: 5, speed: 0, cost: 10, crit: 0.1, block: 0, maxMoves: 1);

            Console.WriteLine("Выбери оружие?\n"
                          + $"1) {ItemChar.ItemStats(Sword_N_sheeld)}\n"
                          + $"2) {ItemChar.ItemStats(Twohand_sword)}\n"
                          + $"3) {ItemChar.ItemStats(Two_knifes)}\n"
                          + $"4) {ItemChar.ItemStats(Bow)}");

            switch (Input.Chois_input(hero, 0, 5))
            {
                case 1:
                    hero.HeroWeapon = Sword_N_sheeld;
                    break;

                case 2:
                    hero.HeroWeapon = Twohand_sword;
                    break;

                case 3:
                    hero.HeroWeapon = Two_knifes;
                    break;

                case 4:
                    hero.HeroWeapon = Bow;
                    break;
            }

            //  Выдать начальные навыки
            AllSkillsEver.Skills(hero, 1);


            Output.TwriteLine("Проходя рукой по пространству вокруг себя вы находите деревянную палку с чем-то мягким.\n"
                          + "Догадка была верна, это оказался факел, что освятил пространство. Но ответить на вопрос где вы, пока не удается.\n", 1);

            CavesLoc.Caves_begin(hero);
        }

        // Смерть героя
        public void HeroDeath()
        {
            if (Hero_quest.Que[0] == 1)
                Output.TwriteLine("\nВы погибли в попытки остановить Таотота", 30);
            else
                Console.WriteLine("Вы погибли!");

            Thread.Sleep(2000);
            Console.WriteLine("\nВаш счет:");
            Console.WriteLine($"Ур: {Lvl}\n"
                           + $"Опыт: {Exp}/{_nextLvlExp}\n"
                           + $"Золото: {Money}\n");
            Console.ReadKey();

            //  Подсчет победных очков и запись в локальный рейтинг
            Rating.Rating_system(this);

            Output.TwriteLine("\nНачать с начала?\n"
                            + "1) Да\n"
                            + "2) Нет\n", 1);

            switch (Input.Sbyte_input())
            {
                case 1:
                    Hero hero = new Hero(25,10);
                    Hero.Creat_hero(hero);
                    break;

                default:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
