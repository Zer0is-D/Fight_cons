using System;
using System.Threading;
using static FightCons.CharacterClasses;
using static FightCons.ItemChar;
using FightCons.World.Locations;
using System.Collections.Generic;
using System.Linq;

namespace FightCons
{
    partial class Hero  
    {
        //  Характеристики героя
        public void ShowHeroStats()
        {
            Output.WriteColorLine(ConsoleColor.DarkGreen, "\nИмя: ", $"{Name}\n");
            Console.WriteLine(//$"Class: {ClassName}\n"
                            $"Lvl: {Lvl}\t\tExp: {Exp}/{NextLvlExp} \n"
                            + $"{Output.HPSymbol}: {TotalHP}/{TotalMaxHP} \t{Output.MPSymbol}: {MP}/{TotalMaxMP}\n"
                            + $"{Output.AttackStr}: {TotalAttack}\t\t{Output.ArcaneStr}: {TotalArcane}\n"
                            + $"{Output.DefenseStr}: {TotalDefense * 100}%\t\t{Output.MagicDefenseStr}: {TotalMagicDefense * 100}%\n"
                            + $"{Output.SpeedStr}: {TotalSpeed * 100}%\t{Output.CritStr}: {TotalCrit * 100}%\n"
                            + $"{Output.BlockStr}: {TotalBlock * 100}%\n");
            Output.WriteColorLine(ConsoleColor.Yellow, $"Money: {Money}", $"{Output.MoneySymbol}\n");
            Output.WriteColorLine(ConsoleColor.Cyan, "Экипировано оружие:\n", $"{CharacterWeapon.Name} ", $"| {ItemStats(CharacterWeapon, false)}");
            Output.WriteColorLine(ConsoleColor.Cyan, "\nЭкипирована броня:\n", $"{CharacterArmor.Name} ", $"| {ItemStats(CharacterArmor, false)}\n");
        }

        //  Начало начал
        public static void CreateHero(Hero hero)
        {
            string HNmae;
            sbyte ChPlace;

            //  Проверочный сегмент //////////////////////////////////////////////////////////////
            hero.Name = "Nemo";

            InventoryItem item = new InventoryItem()
            {
                Name = "Бомба",
                Description = "(Наносит урон всем противникам)",
            };
            item.UseItem = item.Bomb;

            Inventory.ItemAdd(hero, item, 2);

            //hero.Statistic.SpecialSkills2.FirstOrDefault(x => x.ID == 10).Active = true;
            //Inventory.ItemAdd(hero, item, 5);


            List<BattleSession> battleList = new List<BattleSession>()
            {
                new BattleSession(11, ChaRole.Enemy),
                new BattleSession(11, ChaRole.Wild),
                new BattleSession(10, ChaRole.Enemy),
                new BattleSession(10, ChaRole.Enemy),
                new BattleSession(10, ChaRole.Ally),
                new BattleSession(12, ChaRole.Enemy),
            };
            Battles.MakeCurrentBattle(hero, battleList);

            //Inventory.ItemAdd(hero, item, 5);

            //Battles.MakeCurrentBattle(hero, battleList);

            ////hero.HeroCoordinates = Map.transit.CavesToValley;
            //LocationISS.Foothills(hero);
            //hero.HPnMPBar();





            //hero.Lvl = 10;

            //hero.HeroQuests.Que[4] = 1;
            //hero.HeroQuests.MainOP(hero);

            //  КОНЕЦ СЕГМЕНТА
            /////////////////////////////////////////////////////////////////////////////////////

            Output.TwriteLine("- Выбери себе имя которым будешь называться", 20, true);
            do
            {
                Console.WriteLine("Назовите себя (мин 3 символа):");
                HNmae = Console.ReadLine();
            } while (HNmae.Length < 3);

            hero.Name = HNmae;

            string quo = "\n- Время отправляться в путь. Куда ты сначала отправишься?\n"
                            + "1) Точка ИСС\n"
                            + "2) Точка ДЖ\n"
                            + "3) Точка БТЛ\n"
                            + "4) Точка ОП\n"
                            + "5) Точка ПП\n"
                            + "6) Точка НД";

            ChPlace = Input.ChoisInput(hero, 1, 6, quo);

            Output.TwriteLine("- Тебе понадобиться надежное снаряжения для такого пути - голос ненадолго затихает ", 20, true);//10
            Output.Twrite("- что ты выберешь?\n", 20, false);
            GiveHeroClass(hero);

            if (hero.CharacterClass.Class == ChaClass.NoMan)
                Output.TwriteLine("\n- Интересно...\n", 20, true);
            else
            {
                Output.TwriteLine("\nВам вводят в несколько мест раствор", 20, true);
                Output.TwriteLine("\nНа мгновение в голову вцепляется острая боль, а тело метается между\nзакостенелым напряжением" +
                    "и легкостью.", 20, true);
                Output.WriteColorLine(ConsoleColor.DarkRed, "\n[", "-1 ", $"{Output.HPSymbol} ");
                Output.WriteColorLine(ConsoleColor.Magenta, $"от ", "боли в теле и голове", "]\n\n");
                hero.HP -= 1;
                Console.ReadKey(true);

                Output.TwriteLine("В ту же секунду боль в голове и теле ушла. Вам показалось что боль тянулась\nнамного дольше...\n", 20, true);
            }

            GiveHeroWeapon(hero);

            Console.WriteLine("\nВаши характеристики:");
            hero.ShowHeroStats();

            Output.WriteColorLine(ConsoleColor.Cyan, "\nНажмите ", "Enter", " чтобы продолжить...\n\n");
            Console.ReadKey(true);

            //LocationBoss.Endroom(hero);

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

            //  Проверочный сегмент //////////////////////////////////////////////////////////////
            //hero.Name = "Nemo";
            //hero.HPnMPBar();

           

            //  КОНЕЦ СЕГМЕНТА
            /////////////////////////////////////////////////////////////////////////////////////

            switch (ChPlace)
            {
                case 1:
                    LocationISS.CavesStart(hero);
                    break;
                case 2:
                    LocationDJ.Woods1(hero);
                    break;
                case 3:
                    LocationBTL.Deepwoods(hero);
                    break;
                case 4:
                    LocationOP.Island1(hero);
                    break;
                case 5:
                    LocationPP.Coast(hero);
                    break;
                case 6:
                    LocationND.Island1(hero);
                    break;
            }            
        }        

        public static void GiveHeroWeapon(Hero hero)
        {
            ItemChar Sword_N_sheeld = new ItemChar("Меч и щит", ItemTypes.Weapon, attack: 4, speed: 0, cost: 10, crit: 0, block: 0.25f, maxMoves: -1);
            ItemChar Twohand_sword = new ItemChar("Двуручник", ItemTypes.Weapon, attack: 8, speed: -0.2f, cost: 10, crit: 0.1f, block: 0, maxMoves: -1);
            ItemChar Two_knifes = new ItemChar("Два клинка", ItemTypes.Weapon, attack: 3, speed: 0.2f, cost: 10, crit: 0.3f, block: 0, maxMoves: 0);
            ItemChar Bow = new ItemChar("Лук", ItemTypes.Weapon, attack: 5, speed: 0, cost: 10, crit: 0.1f, block: 0, maxMoves: 1);

            string quo = "Выбери оружие?\n"
                          + $"1) {ItemStats(Sword_N_sheeld)}\n"
                          + $"2) {ItemStats(Twohand_sword)}\n"
                          + $"3) {ItemStats(Two_knifes)}\n"
                          + $"4) {ItemStats(Bow)}";

            switch (Input.ChoisInput(hero, 0, 4, quo))
            {
                case 1:
                    hero.CharacterWeapon = Sword_N_sheeld;
                    break;

                case 2:
                    hero.CharacterWeapon = Twohand_sword;
                    break;

                case 3:
                    hero.CharacterWeapon = Two_knifes;
                    break;

                case 4:
                    hero.CharacterWeapon = Bow;
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
                           + $"Золото: {Statistic.Money}\n");
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
