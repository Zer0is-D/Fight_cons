using System;
using System.Threading;
using static FightCons.Character;

namespace FightCons
{
    public class Output
    {
        //  Лого
        public static void GameLogo(string vers)
        {
            //Game.ChangeColor("", " __                __               ", "\n", ConsoleColor.Yellow);
            //Game.ChangeColor("", "/__ __ _          (_ _|_    _| o  _ ", "\n", ConsoleColor.Yellow);
            //Game.ChangeColor("", "\\_| | (_)|_|\\^/   __) |_|_|(_| | (_)", "\n\n", ConsoleColor.Yellow);

            WriteColorLine(ConsoleColor.White, "", "################################################################################");
            WriteColorLine(ConsoleColor.Green, "\t\t\t", " __               ", "\n");
            WriteColorLine(ConsoleColor.Green, "\t\t\t", "/__ __ _          ", "\n");
            WriteColorLine(ConsoleColor.Green, "\t\t\t", "\\_| | (_)|_|\\^/ ", "\n");

            WriteColorLine(ConsoleColor.Red, "\t\t\t\t", " __               ", "\n");
            WriteColorLine(ConsoleColor.Red, "\t\t\t\t", "(_ _|_    _| o  _ ", "\n");
            WriteColorLine(ConsoleColor.Red, "\t\t\t\t", "__) |_|_|(_| | (_)", "\n\n");
            WriteColorLine(ConsoleColor.White, "", "################################################################################", "\n");

            WriteColorLine(ConsoleColor.White, "", $"Сборка: {vers}", "\n");
            WriteColorLine(ConsoleColor.White, "", $"Просьба поставить размер шрифта 20", "\n\n");

        }

        #region Обозначения и символы
        //⌂,↔,∟,↨,▬,§,¶,‼,↕,☼,♫,♥,♣,♦,♠,☺,☻,\u0072

        public static char UpSymbol = '\u001e';       // \u2191
        public static char DownSymbol = '\u001f';     // \u2193  

        public static char MoneySymbol = '\u00A2';
        public static char ExpSymbol = '\u0407';

        public static string HPSymbol = "HP";
        public static string MPSymbol = "MP";

        public static string MaxHpStr { get => "vHP"; }
        public static string MaxMpStr { get => "vMP"; }

        public static string AttackStr { get => "ATT"; }
        public static string ArcaneStr { get => "ARC"; }
        public static string DefenceStr { get => "DEF"; }
        public static string MagicDefenceStr { get => "MDEF"; }

        public static string SpeedStr { get => "SPD"; }
        public static string CritStr { get => "CRT"; }
        public static string BlockStr { get => "BLK"; }
        public static string MaxMovesStr { get => "vMOV"; }

        public static string DmgSymbol { get => "DMG"; }
        public static string EffMovSymbol { get => "MOV"; }
        //  Добавить меткость на англ
        #endregion

        #region Цены (общие)
        public static sbyte BeerCost = 5;

        public static sbyte PotionHPCost = 20;
        public static sbyte PotionMPCost = 30;
        public static sbyte QStatueCost = 30;

        public static sbyte ShowNewItemsCost = 10;

        public static short VisionSkillCost = 500;
        #endregion

        #region Боевой output
        //  Экран нападения
        public static void FightWarning()
        {
            WriteColorLine(ConsoleColor.DarkGray, "\n", "##############################################################################################################");
            WriteColorLine(ConsoleColor.Red, "", "    На вас напали!    ");
            WriteColorLine(ConsoleColor.DarkGray, "", "############################################################################################################\n");
        }

        //  В разработке
        public static void EnemyPic()
        {
            Console.WriteLine();
            Console.WriteLine(" 0");
            Console.WriteLine("/|\\/");
            Console.WriteLine("/ \\");
        }

        //  Экран победы над противником
        public static void VictoryWarning()
        {
            WriteColorLine(ConsoleColor.DarkGray, "\n", "##############################################################################################################");
            WriteColorLine(ConsoleColor.Green, "", "    Вы победили!    ");
            WriteColorLine(ConsoleColor.DarkGray, "", "##############################################################################################################\n");
        }

        //  Экран побега
        public static void RunWarning()
        {
            WriteColorLine(ConsoleColor.DarkGray, "", "##############################################################################################################");
            WriteColorLine(ConsoleColor.White, "", "    Вы сбежали!    ");
            WriteColorLine(ConsoleColor.DarkGray, "", "###############################################################################################################\n");
        }

        public static void NameAndId(Character character, bool NextLine = false)
        {
            if (NextLine)
                Console.WriteLine();

            if (!character.IsPlayer)
                Console.Write($"[{character.Id}] ");
            else if (!character.IsPlayer & !NextLine)
                Console.Write($"[{character.Id}] ");


            WriteColorName("", character, " ");
        }

        //  Определение цвета юнита
        public static ConsoleColor unitHPColor(ChaRole role)
        {
            ConsoleColor UnitHPColor;

            switch (role)
            {
                case ChaRole.Enemy:
                    UnitHPColor = ConsoleColor.DarkRed;
                    break;

                case ChaRole.Wild:
                    UnitHPColor = ConsoleColor.DarkRed;
                    break;

                case ChaRole.Ally:
                    UnitHPColor = ConsoleColor.Green;
                    break;

                default:
                    UnitHPColor = ConsoleColor.Green;
                    break;
            }

            return UnitHPColor;
        }

        public static ConsoleColor unitNameColor(ChaRole num)
        {
            ConsoleColor UnitNameColor;

            switch (num)
            {
                case ChaRole.Ally:
                    UnitNameColor = ConsoleColor.Green;
                    break;
                case ChaRole.Enemy:
                    UnitNameColor = ConsoleColor.DarkMagenta;
                    break;
                case ChaRole.Wild:
                    UnitNameColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    UnitNameColor = ConsoleColor.Green;
                    break;
            }

            return UnitNameColor;
        }
        #endregion

        #region Методы вывода и цвета
        //  String color changer
        public static void WriteColorLine(ConsoleColor color, string before, string str, string after = null)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(before);
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(after);
        }
        public static void WriteColorName(string NextL, Character charecter, string str = null)
        {
            Console.ForegroundColor = unitNameColor(charecter.Role);
            Console.Write(NextL+charecter.Name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(str);
        }

        //  Метод вывода с ожиданием
        /// <param name="str">Текст</param>
        /// <param name="x">Время задержки перед след символом</param>
        public static void Twrite(string str, int x, bool waitForKey = false)
        {
            foreach (char s in str)
            {
                Console.Write(s);
                if (Settings.DelayEffects)
                    Thread.Sleep(x);
            }

            if (waitForKey)
                Console.ReadKey(true);
        }

        //  Метод вывода с ожиданием и переходом на другую строку
        public static void TwriteLine(string str, int x, bool waitForKey = false)
        {
            foreach (char s in str)
            {
                Console.Write(s);
                if (Settings.DelayEffects)
                    Thread.Sleep(x);
                if (Settings.SoundEffects)
                    Console.Beep(800, 25);

                //foreach (char s in str)
                //{
                //    Console.Write(s);
                //    Thread.Sleep(x);
                //    if (Settings.SoundEffects)
                //        Console.Beep(220, 25);
                //}
                //Console.Write("\n");

            }
            Console.Write("\n");

            if (waitForKey)
                Console.ReadKey(true);
        }

        //  Ожидание между событиями
        public static void WaitNext(int x, string str)
        {
            for (int i = 1; x >= i; i++)
            {
                Thread.Sleep(400);
                Console.Write(str);
                if (i % 3 == 0)
                    Console.Write("\n");
            }
            TwriteLine("\n", 1);
        }
        #endregion

        #region Интерфейсные подсказки
        public static void Spent(string itemName, bool Find = false)
        {
            if (Find)
                WriteColorLine(ConsoleColor.Green, "[Вы нашли ", $"{itemName}", "!]\n\n");
            if (itemName.Length > 1 && !Find)
                WriteColorLine(ConsoleColor.Green, "[Вы получили ", $"{itemName}", "!]\n");

            Thread.Sleep(1000);
        }

        public static bool Spent(int money, int cost = 0, string itemName = "", string NoMoneyMes = "")
        {
            if (money >= cost)
            {
                WriteColorLine(ConsoleColor.Yellow, "\n[Вы потратили -", $"{cost}{MoneySymbol}", "!]\n");
                money -= cost;

                if (itemName.Length >= 1)
                    WriteColorLine(ConsoleColor.Green, "[Вы получили ", $"{itemName}", "!]\n");

                Thread.Sleep(1000);
                return true;
            }
            else
            {
                if (NoMoneyMes.Length != 0)
                    Console.WriteLine(NoMoneyMes);
                else
                    Console.WriteLine("Недостаточно средств");

                Thread.Sleep(1000);
                return false;
            }           
        }

        public static void StartQuest(string name)
        {
            WriteColorLine(ConsoleColor.Green, "\t\t\t[Квест \"", $"{name}", "\"]\n");
        }

        public static void PayMoneyLine(string message, int value, int money)
        {
            if (money >= value)
                WriteColorLine(ConsoleColor.Yellow, $"{message} (", $"{value}{MoneySymbol}", ")\n");
            else
                WriteColorLine(ConsoleColor.DarkGray, "", $"{message} (вам нахватает {value - money}{MoneySymbol})", "\n");
        }

        //Пояснения характеристик
        public static void Remark()
        {
            Console.WriteLine("\nОсновные понятия:\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Lvl ", "- уровень персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Exp ", "- опыт персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "HP ", "- здоровье персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "vHP ", "- максимальное здоровье персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "MP ", "- мана персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "vMP ", "- максимальная мана персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "ATT ", "- урон персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "ARC ", "- магический урон персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "DEF ", "- защита персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "MDEF ", "- магическая защита персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "SPD ", "- скорость персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "CRI ", "- критический урон персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "BLK ", "- блок персонажа\n");
            WriteColorLine(ConsoleColor.Cyan, "", "vMOV ", "- максимальное количество ходов персонажа\n");
        }

        //Подсказка команд
        public static void HelpCommand()
        {
            Console.WriteLine("\nКлючевые слова:\n");
            WriteColorLine(ConsoleColor.Cyan, "", "инв ", "- вызов инвентаря (в разработке)\n");
            WriteColorLine(ConsoleColor.Cyan, "", "статы ", "- вызов меню характеристики героя\n");
            WriteColorLine(ConsoleColor.Cyan, "", "настройки ", "- вызов меню настроек\n");
            WriteColorLine(ConsoleColor.Cyan, "", "толк ", "- вызов окна с объяснением параметров\n");
            WriteColorLine(ConsoleColor.Cyan, "", "fstate ", "- вызов окна статистики\n");
            WriteColorLine(ConsoleColor.Cyan, "", "ach ", "- вызов окна достижений\n");
        }

        //Полная статистика 
        public static void ShowFullHeroStats(Hero hero)
        {            
            Console.WriteLine("\nПолная статистика:\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Всего заработанных денег ", $"- {hero.Statistic.Money}\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Количество атак ", $"- {hero.Statistic.Attacks}\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Количество успешных заклинаний ", $"- {hero.Statistic.Spells}\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Количество побед ", $"- {hero.Statistic.Wins}\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Изучение пещеры ", $"- {hero.Statistic.CaveResearch}\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Изучение леса ", $"- {hero.Statistic.WoodsResearch}\n");
            WriteColorLine(ConsoleColor.Cyan, "", "Количество побед в арм реслинге ", $"- {hero.Statistic.ArmGameWins}\n");
        }

        //Достижения
        public static void HeroAchievements(Hero hero)
        {
            Console.WriteLine("\nДостижения:\n");

            WriteColorLine(hero.HeroQuests.Que[7] == 2 ? ConsoleColor.Cyan : ConsoleColor.DarkGray, "", "Победитель победителей ", 
                           hero.HeroQuests.Que[7] == 2 ? $"- получено\n" : $"- не получено\n");
        }
        #endregion       

        public static void Final()
        {
            Random rand = new Random();

            for (ushort a = 0; a < 1000; a++)
            {
                Console.ForegroundColor = (ConsoleColor)rand.Next(1, 16);
                Console.Write("Congratulations! ");
                Thread.Sleep(50);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
