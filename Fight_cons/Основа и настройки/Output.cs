using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using static Fight_cons.Charecter;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static Fight_cons.Основа_и_настройки.CharecterProfiles;

namespace Fight_cons
{
    public class Output
    {
        #region Обозначения и символы
        //⌂,↔,∟,↨,▬,§,¶,‼,↕,☼,♫,♥,♣,♦,♠,☺,☻,\u0072

        public static char UpSymbol = '\u001e';       // \u2191
        public static char DownSymbol = '\u001f';     // \u2193  

        public static char MoneySymbol = '\u00A2';
        public static char ExpSymbol = '\u0407';

        public static string HPSymbol = "HP";
        public static string MPSymbol = "MP";

        public static string MaxHpStr
        {
            get => "vHP";
        }
        public static string MaxMpStr
        {
            get => "vMP";
        }

        public static string AttackStr
        {
            get => "ATT";
        }
        public static string ArcaneStr
        {
            get => "ARC";
        }
        public static string DefenceStr
        {
            get => "DEF";
        }
        public static string MagicDefenceStr
        {
            get => "MDEF";
        }       
       
        public static string SpeedStr
        {
            get => "SPD";
        }
        public static string CritStr
        {
            get => "CRT";
        }
        public static string BlockStr
        {
            get => "BLK";
        }
        public static string MaxMovesStr
        {
            get => "vMOV";
        }

        public static string DmgSymbol = "DMG";
        public static string EffMovSymbol = "MOV";
        //  Добавить меткость на англ
        #endregion

        #region Цены (общие)
        public static sbyte BeerCost = 5;

        public static sbyte PotionHPCost = 20;
        public static sbyte PotionMPCost = 30;
        public static sbyte QStatueCost = 30;

        public static sbyte ShowNewItemsCost = 10;

        public static sbyte VisionSkillCost = 50;
        #endregion

        #region Логи
        //  Экран нападения
        public static void FightLog()
        {
            WriteColorLine(ConsoleColor.DarkGray, "", "##############################################################################################################");
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
        public static void VictoyLog()
        {
            WriteColorLine(ConsoleColor.DarkGray, "\n", "##############################################################################################################");
            WriteColorLine(ConsoleColor.Green, "", "    Вы победили!    ");
            WriteColorLine(ConsoleColor.DarkGray, "", "##############################################################################################################\n");
        }

        //  Экран побега
        public static void RunLog()
        {
            WriteColorLine(ConsoleColor.DarkGray, "", "##############################################################################################################");
            WriteColorLine(ConsoleColor.White, "", "    Вы сбежали!    ");
            WriteColorLine(ConsoleColor.DarkGray, "", "###############################################################################################################\n");
        }

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
        #endregion
        
        #region Работа со строками
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
        public static void WriteColorName(string NextL, Charecter charecter, string str = null)
        {
            Console.ForegroundColor = unitNameColor(charecter.CharecterProfile.Role);
            Console.Write(NextL+charecter.Name);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(str);
        }

        //  Метод вывода с ожиданием
        /// <param name="str">Текст</param>
        /// <param name="x">Время задержки перед след символом</param>
        public static void Twrite(string str, int x)
        {
            foreach (char s in str)
            {
                Console.Write(s);
                Thread.Sleep(x);
            }
        }

        //  Метод вывода с ожиданием и переходом на другую строку
        public static void TwriteLine(string str, int x)
        {
            foreach (char s in str)
            {
                Console.Write(s);
                if (Settings.DelayEffects)
                    Thread.Sleep(x);
                if (Settings.SoundEffects)
                    Console.Beep(800, 5);

            }
            Console.Write("\n");
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

        #region Уведомления
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

        public static void NameAndId(Charecter charecter, bool NextLine = false)
        {
            if (NextLine)
                Console.WriteLine();

            if (!charecter.CharecterProfile.IsPlayer)
                Console.Write($"[{charecter.Id}] ");
            else if (!charecter.CharecterProfile.IsPlayer & !NextLine)
                Console.Write($"[{charecter.Id}] ");


            WriteColorName("", charecter, " ");
        }

        public static void PayMoneyLine(string message, sbyte value, int money)
        {
            if (money >= value)
                WriteColorLine(ConsoleColor.Yellow, $"{message} (", $"{value}{MoneySymbol}", ")\n");
            else
                WriteColorLine(ConsoleColor.DarkGray, "", $"{message} (вам нехватает {value - money}{MoneySymbol})", "\n");
        }
        #endregion       

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

        public static void Final()
        {
            Random rand = new Random();

            for (ushort a = 0; a < 1000; a++)
            {
                Console.ForegroundColor = (ConsoleColor)rand.Next(1, 16);
                Console.Write("Congratulations! ");
                Thread.Sleep(50);
            }
            Console.ReadKey();
        }
    }
}
