using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    class Outer
    {
        //  Ожидание между событиями
        public static void Wait_next(int x, string str)
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

        //  Метод вывода с ожиданием
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
                Thread.Sleep(x);
            }
            Console.Write("\n");
        }

        //  Метод вывода с ожиданием и переходом на другую строку (+ звуковые эффекты)
        public static void TwriteLine_general(string str, int x)
        {
            foreach (char s in str)
            {
                Console.Write(s);
                Thread.Sleep(x);
                if (Settings.Sound_effects)
                    Console.Beep(800, 5);

            }
            Console.Write("\n");
        }

        //  Метод сравнение параметров (int)
        public static void Comparison(int parametr_1, int parametr_2, string text_left, string tab_or_line, string text_mid = "")
        {
            char Up = '\u2191';
            char Down = '\u2193';

            if (parametr_1 > parametr_2)
                ChangeColor($"{text_left}", $"{parametr_1} {text_mid} {Up} ", $"{tab_or_line}", ConsoleColor.Green);
            else if (parametr_1 == parametr_2)
                ChangeColor($"{text_left}", $"{parametr_1} {text_mid} ", $"{tab_or_line}", ConsoleColor.White);
            else
                ChangeColor($"{text_left}", $"{parametr_1} {text_mid} {Down} ", $"{tab_or_line}", ConsoleColor.Red);
        }

        //  Метод сравнение параметров (double)
        public static void Comparison(double parametr_1, double parametr_2, string text_left, string tab_or_line, string text_mid = "")
        {
            char Up = '\u2191';
            char Down = '\u2193';

            if (parametr_1 > parametr_2)
                ChangeColor($"{text_left}", $"{parametr_1 * 100}% {text_mid} {Up} ", $"{tab_or_line}", ConsoleColor.Green);
            else if (parametr_1 == parametr_2)
                ChangeColor($"{text_left}", $"{parametr_1 * 100}% {text_mid} ", $"{tab_or_line}", ConsoleColor.White);
            else
                ChangeColor($"{text_left}", $"{parametr_1 * 100}% {text_mid} {Down} ", $"{tab_or_line}", ConsoleColor.Red);
        }

        //  Экран нападения
        public static void Fight_log()
        {
            ChangeColor("", "##############################################################################################################", "", ConsoleColor.DarkGray);
            ChangeColor("", "    На вас напали!    ", "", ConsoleColor.Red);
            ChangeColor("", "############################################################################################################\n", "", ConsoleColor.DarkGray);

        }

        //  Экран победы над противником
        public static void Victoy_log()
        {
            ChangeColor("\n", "##############################################################################################################", "", ConsoleColor.DarkGray);
            ChangeColor("", "    Вы победили!    ", "", ConsoleColor.Green);
            ChangeColor("", "##############################################################################################################\n", "", ConsoleColor.DarkGray);
        }

        //  Экран побега
        public static void Run_log()
        {
            ChangeColor("", "##############################################################################################################", "", ConsoleColor.DarkGray);
            ChangeColor("", "    Вы сбежали!    ", "", ConsoleColor.White);
            ChangeColor("", "###############################################################################################################\n", "", ConsoleColor.DarkGray);
        }

        //  Лого
        public static void Game_logo(string vers)
        {
            //Game.ChangeColor("", " __                __               ", "\n", ConsoleColor.Yellow);
            //Game.ChangeColor("", "/__ __ _          (_ _|_    _| o  _ ", "\n", ConsoleColor.Yellow);
            //Game.ChangeColor("", "\\_| | (_)|_|\\^/   __) |_|_|(_| | (_)", "\n\n", ConsoleColor.Yellow);

            ChangeColor("", "################################################################################", "", ConsoleColor.White);
            ChangeColor("\t\t\t", " __               ", "\n", ConsoleColor.Green);
            ChangeColor("\t\t\t", "/__ __ _          ", "\n", ConsoleColor.Green);
            ChangeColor("\t\t\t", "\\_| | (_)|_|\\^/ ", "\n", ConsoleColor.Green);

            ChangeColor("\t\t\t\t", " __               ", "\n", ConsoleColor.Red);
            ChangeColor("\t\t\t\t", "(_ _|_    _| o  _ ", "\n", ConsoleColor.Red);
            ChangeColor("\t\t\t\t", "__) |_|_|(_| | (_)", "\n\n", ConsoleColor.Red);
            ChangeColor("", "################################################################################", "\n", ConsoleColor.White);

            ChangeColor("", $"Сборка: {vers}", "\n", ConsoleColor.White);
            ChangeColor("", $"Просьба поставить размер шрифта 20", "\n\n", ConsoleColor.White);

        }

        //  String color changer
        public static void ChangeColor(string before, string str, string after, ConsoleColor id)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(before);
            Console.ForegroundColor = id;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(after);
        }

        //  Помощь
        public static void Help()
        {
            Console.WriteLine("\nКлючевые слова:\n");
            ChangeColor("", "инв ", "- вызов инвентаря (в разработке)\n", ConsoleColor.Cyan);
            ChangeColor("", "статы ", "- вызов меню характеристики героя\n", ConsoleColor.Cyan);
            ChangeColor("", "настройки ", "- вызов меню настроек\n", ConsoleColor.Cyan);
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
