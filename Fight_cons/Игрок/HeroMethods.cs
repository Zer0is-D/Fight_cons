using Fight_cons.Мир;
using System;
using System.Threading;
using static Fight_cons.AboutLoc;
using static Fight_cons.ItemChar;

namespace Fight_cons
{
    partial class Hero
    {
        //  Характеристики героя
        public void ShowHeroStats()
        {
            Output.WriteColorLine(ConsoleColor.DarkGreen, "\nHero name: ", $"{Name}\n");
            Console.WriteLine($"Class: {Class_name}\n"
                            + $"Lvl: {Lvl}\t\tExp: {Exp}/{NextLvlExp} \n"
                            + $"{Output.HPSymbol}: {TotalHP}/{TotalMaxHP} \t{Output.MPSymbol}: {MP}/{TotalMaxMP}\n"
                            + $"{Output.AttackStr}: {TotalAttack}\t\t{Output.ArcaneStr}: {TotalArcane}\n"
                            + $"{Output.DefenceStr}: {TotalDefence * 100}%\t\t{Output.MagicDefenceStr}: {TotalMagicDefence * 100}%\n"
                            + $"{Output.SpeedStr}: {TotalSpeed * 100}%\t{Output.CritStr}: {TotalCrit * 100}%\n"
                            + $"{Output.BlockStr}: {TotalBlock * 100}%\n");
            Output.WriteColorLine(ConsoleColor.Yellow, $"Money: {Money}", $"{Output.MoneySymbol}\n");
            Output.WriteColorLine(ConsoleColor.Cyan, "Экиперовано оружие:\n", $"{CharecterWeapon.Name} ", $"| {ItemChar.ItemStats(CharecterWeapon, false)}");
            Output.WriteColorLine(ConsoleColor.Cyan, "\nЭкиперована броня:\n", $"{CharecterArmor.Name} ", $"| {ItemChar.ItemStats(CharecterArmor, false)}\n");
        }

        //  Начало начал
        public static void CreateHero(Hero hero)
        {            
            Output.TwriteLine("Громкий и непонятной природы звук постепенно пробуждает ваше тело.\n"
                      + "После чего вы слышите голос словно он у вас в голове.\n"
                      + "'ВСТАВАЙ ДУША, ВЕЛЮ ТЕБЕ РОЗЫСКАТЬ ТОАТОТА И ИЗНЕЧТОЖИТЬ!'\n", 10);
            hero.Name = "No_name";
            Console.ReadKey(true);
            Output.TwriteLine("Ощущая внутри некую ответственность со странным желанием выполнить поручение\n"
                      + "вы решаетесь открыть глаза, но тьма не дает вам что-либо увидеть...\n", 10);

            CharecterClases.GiveHeroClass(hero);
            GiveHeroWeapon(hero);

            Output.TwriteLine("Проходя рукой по пространству вокруг себя вы находите деревянную палку с чем-то мягким.\n"
                          + "Догадка была верна, это оказался факел, что освятил пространство. Но ответить на вопрос где вы, пока не удается.\n", 1);

            DefualtLoad(hero, Locations[(int)LocationName.CaveStart]);
        }        

        public static void GiveHeroWeapon(Hero hero)
        {
            ItemChar Sword_N_sheeld = new ItemChar("Меч и щит", ItemTyps.Weapon, attack: 4, speed: 0, cost: 10, crit: 0, block: 0.25f, maxMoves: -1);
            ItemChar Twohand_sword = new ItemChar("Двуручник", ItemTyps.Weapon, attack: 8, speed: -0.2f, cost: 10, crit: 0.1f, block: 0, maxMoves: -1);
            ItemChar Two_knifes = new ItemChar("Два клинка", ItemTyps.Weapon, attack: 3, speed: 0.2f, cost: 10, crit: 0.3f, block: 0, maxMoves: 0);
            ItemChar Bow = new ItemChar("Лук", ItemTyps.Weapon, attack: 5, speed: 0, cost: 10, crit: 0.1f, block: 0, maxMoves: 1);

            string quo = "Выбери оружие?\n"
                          + $"1) {ItemStats(Sword_N_sheeld)}\n"
                          + $"2) {ItemStats(Twohand_sword)}\n"
                          + $"3) {ItemStats(Two_knifes)}\n"
                          + $"4) {ItemStats(Bow)}";

            switch (Input.ChoisInput(hero, 0, 4, quo))
            {
                case 1:
                    hero.CharecterWeapon = Sword_N_sheeld;
                    break;

                case 2:
                    hero.CharecterWeapon = Twohand_sword;
                    break;

                case 3:
                    hero.CharecterWeapon = Two_knifes;
                    break;

                case 4:
                    hero.CharecterWeapon = Bow;
                    break;
            }
        }

        // Смерть героя
        public void HeroDeath()
        {
            if (HeroQuests.Que[0] == 1)
                Output.TwriteLine("\nВы погибли в попытки остановить Таотота", 30);
            else
                Console.WriteLine("Вы погибли!");

            Thread.Sleep(2000);
            Console.WriteLine("\nВаш счет:");
            Console.WriteLine($"Ур: {Lvl}\n"
                           + $"Опыт: {Exp}/{NextLvlExp}\n"
                           + $"Золото: {Money}\n");
            Console.ReadKey();

            //  Подсчет победных очков и запись в локальный рейтинг
            Rating.RatingSystem(this);

            Output.TwriteLine("\nНачать с начала?\n"
                            + "1) Да\n"
                            + "2) Нет\n", 1);

            switch (Input.SbyteInput())
            {
                case 1:
                    Hero hero = new Hero(25,10);
                    CreateHero(hero);
                    break;

                default:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
