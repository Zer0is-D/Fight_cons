using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FightCons
{
    public class Settings
    {
        //  Режим
        //public static bool BildVersActive = false;
        public static bool OwnBildVersion = false;
        public static bool DelayEffects = false;
        public static bool SoundEffects = false;
        public static bool DetailedParamValue = false;
        public static bool SkipStart = false;


        #region Фиксированное окно
        const int MF_BYCOMMAND = 0x00000000;
        const int SC_SIZE = 0xF000;
        const int SC_MAXIMIZE = 0xF030;

        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        static extern IntPtr GetConsoleWindow();
        #endregion

        public static void RecommendedWindowSize()
        {
            IntPtr consoleWindow = GetConsoleWindow();
            IntPtr systemMenu = GetSystemMenu(consoleWindow, false);

            if (consoleWindow != IntPtr.Zero)
            {
                // Отключаем возможность изменения размера окна
                DeleteMenu(systemMenu, SC_SIZE, MF_BYCOMMAND);
                // Отключаем кнопку максимизации
                DeleteMenu(systemMenu, SC_MAXIMIZE, MF_BYCOMMAND);
            }

            Console.SetWindowSize(80, 40);
            Console.SetBufferSize(80, Console.BufferHeight);
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("\nПеред тем чтобы продолжить отрегулируйте ширину консоли так чтобы нижняя линия была прямая и впритык к правой стенке");
            Output.WriteColorLine(ConsoleColor.DarkGray, "\n", "################################################################################", "\n");
            Output.WriteColorLine(ConsoleColor.Cyan, "\nНажмите ", "Любую кнопку", " чтобы продолжить...\n");
            Console.ReadKey(true);

            //TODO Плохое решение надо найти более грамотный способ (удалять символьно)
            Console.Clear();
        }

        public static void OptionWaitSkip(Hero hero)
        {
            string quo = "Убрать задержку?\n"
                            + "1) Да\n"
                            + "2) Нет";
            
            if (Input.ChoisInput(hero, 1, 2, quo) == 2)
                DelayEffects = true;
            else
                DelayEffects = false;
        }

        //  Настройка версии 
        public static void OptionVersions(Hero hero)
        {
            Console.WriteLine("Выберите режим игры:\n"
                            + "1) Режим стандартный (рекомендуется)\n"
                            + "2) Режим с возможностью билдиться");

            switch (Input.ChoisInput(hero, 1, 2))
            {
                case 1:
                    OwnBildVersion = false;
                    break;
                case 2:
                    OwnBildVersion = true;
                    break;
            }
        }

        //  Настройки звуковых эффектов
        public static void OptionSound(Hero hero)
        {
            Console.WriteLine("Оставить звук?\n"
                            + "1) Да\n"
                            + "2) Нет");

            switch (Input.ChoisInput(hero, 1, 2))
            {
                case 1:
                    SoundEffects = true;
                    break;
                case 2:                    
                    SoundEffects = false;
                    break;
            }
        }
    }
}
