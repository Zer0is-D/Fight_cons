using System;
using System.Threading;
using static FightCons.Locations;
using static FightCons.CharecterClases;
using static FightCons.ItemChar;
using FightCons.World.Locations;

namespace FightCons
{
    partial class Hero
    {
        //  Характеристики героя
        public void ShowHeroStats()
        {
            Output.WriteColorLine(ConsoleColor.DarkGreen, "\nHero name: ", $"{Name}\n");
            Console.WriteLine(//$"Class: {ClassName}\n"
                            $"Lvl: {Lvl}\t\tExp: {Exp}/{NextLvlExp} \n"
                            + $"{Output.HPSymbol}: {TotalHP}/{TotalMaxHP} \t{Output.MPSymbol}: {MP}/{TotalMaxMP}\n"
                            + $"{Output.AttackStr}: {TotalAttack}\t\t{Output.ArcaneStr}: {TotalArcane}\n"
                            + $"{Output.DefenceStr}: {TotalDefence * 100}%\t\t{Output.MagicDefenceStr}: {TotalMagicDefence * 100}%\n"
                            + $"{Output.SpeedStr}: {TotalSpeed * 100}%\t{Output.CritStr}: {TotalCrit * 100}%\n"
                            + $"{Output.BlockStr}: {TotalBlock * 100}%\n");
            Output.WriteColorLine(ConsoleColor.Yellow, $"Money: {Money}", $"{Output.MoneySymbol}\n");
            Output.WriteColorLine(ConsoleColor.Cyan, "Экипировано оружие:\n", $"{CharecterWeapon.Name} ", $"| {ItemStats(CharecterWeapon, false)}");
            Output.WriteColorLine(ConsoleColor.Cyan, "\nЭкипирована броня:\n", $"{CharecterArmor.Name} ", $"| {ItemStats(CharecterArmor, false)}\n");
        }

        //  Начало начал
        public static void CreateHero(Hero hero)
        {
            byte ch_place = 0;

            //TODO Придумать имя
            hero.Name = "No_name";

            Output.TwriteLine("", 10, true);


            string quo = "- Время отправляться в путь. Куда ты сначала отправишься?\n"
                            + "1) Точка ИСС\n"
                            //+ "2) Точка ДЖ"
                            //+ "3) Точка БТЛ"
                            //+ "4) Точка ОП"
                            //+ "5) Точка ПП"
                            //+ "6) Точка НД"
                            ;

            switch (Input.ChoisInput(hero, 0, 1, quo))
            {
                default:
                    ch_place = 1;
                    break;
                case 1:
                    ch_place = 1;
                    break;
            }

            Output.TwriteLine("- Тебе понадобиться надежное снаряжения для такого пути - голос ненадолго\n затихает - что ты выберешь?\n", 300, false);//10
            GiveHeroClass(hero);

            if (hero.CharecterClass.Class == ChaClass.NoMan)
                Output.TwriteLine("\n- Интересно...\n", 300, true);
            else
            {
                Output.TwriteLine("\nВам вводят в несколько мест раствор", 100, true);
                Output.TwriteLine("\nНа мгновение в голову вцепляется острая боль, а тело метается между\nзакостенелым напряжением" +
                    "и легкостью.", 400, true);
                Output.WriteColorLine(ConsoleColor.DarkRed, "\n[", "-1 ", $"{Output.HPSymbol} ");
                Output.WriteColorLine(ConsoleColor.Magenta, $"от ", "боли в теле и голове", "]\n\n");
                hero.HP -= 1;
                Console.ReadKey(true);

                Output.TwriteLine("В ту же секунду боль в голове и теле ушла. Вам показалось что боль тянулась\n намного дольше...\n", 200, true);
            }

            GiveHeroWeapon(hero);

            Console.WriteLine("\nВаши характеристики:");
            hero.ShowHeroStats();

            Output.WriteColorLine(ConsoleColor.Cyan, "\nНажмите ", "Enter", " чтобы продолжить...\n\n");
            Console.ReadKey(true);

            /*
            Output.TwriteLine("\nГромкий и непонятной природы звук постепенно пробуждает ваше тело.\n"
                            + "После чего вы слышите голос словно он доносться из глубин вашего сознания.\n"
                            + "'ВСТАВАЙ ДУША, РОЗЫЩИ ТОАТОТА И ПОКОНЧИ С НИМ!'\n", 10, true);
            Output.TwriteLine("Затихший голос сменяется на острую головную боль", 10, true);
            

            Output.WriteColorLine(ConsoleColor.Magenta, $"от ", "головной боли", "]\n");
            Console.ReadKey(true);
            

            Output.TwriteLine("\nОщущая внутри некую ответственность со странным желанием выполнить поручение\n"
                      + "вы решаетесь открыть глаза, но тьма не дает вам что-либо увидеть...\n", 10, true);
            */

            Output.TwriteLine("Вы отправились в путешествие которое заняло у вас несколько дней, не столько потому что путь был сложный, сколько ориентиры на карте были далеки от действительности. "
                          + "\nНайдя похожую пещеры вы проходите дальше надеясь пройти сквозь гору.\nВы заплутали.\n", 1, true);


            Output.TwriteLine("Проходя рукой по пространству вокруг себя вы находите деревянную палку с чем-то мягким.\n"
                          + "Догадка была верна, это оказался факел, что освятил пространство.\nНо ответить на вопрос где вы, пока не удается.\n", 1, true);

            LocationISS.CavesStart(hero);
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
                Output.TwriteLine("\nВы погибли", 30);
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
