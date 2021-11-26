using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Fight_cons
{
    public class Settings
    {
        //  Режим
        public static bool Bild_vers_active = false;
        public static bool Bild_vers = false;
        public static bool Sound_effects;

        public static int T1 = 1;
        public static int T10 = 10;
        public static int T20 = 20;
        public static int T30 = 30;
        public static int T40 = 40;
        public static int T50 = 50;
        public static int T80 = 0;
        public static int T100 = 0;
        public static int T140 = 0;

        //  Настройка окна
        public static void Console_window()
        {
            //Console.SetWindowSize(12, 20);
        }

        public static void Option_wait_skip(Hero hero)
        {
            Console.WriteLine("Убать задержку?\n"
                            + "1) Да\n"
                            + "2) Нет");

            switch (Input.Chois_input(hero, 0, 3))
            {
                case 1:
                    T1 = 0;
                    T10 = 0;
                    T20 = 0;
                    T30 = 0;
                    T40 = 0;
                    T50 = 0;
                    T80 = 0;
                    T100 = 0;
                    T140 = 0;
                    break;
                case 2:
                    T1 = 1;
                    T10 = 10;
                    T20 = 20;
                    T30 = 30;
                    T40 = 40;
                    T50 = 50;
                    T80 = 0;
                    T100 = 0;
                    T140 = 0;
                    break;
            }
        }

        //  Настройка версии 
        public static void Option_vers(Hero hero)
        {
            Console.WriteLine("Выберите режим игры:\n"
                            + "1) Режим стандартный (рекомендуется)\n"
                            + "2) Режим с возможностью билдиться");

            switch (Input.Chois_input(hero, 0, 3))
            {
                case 1:
                    Bild_vers = false;
                    break;
                case 2:
                    Bild_vers = true;
                    break;
            }
        }

        //  Настройки звуковых эффектов
        public static void Option_sound(Hero hero)
        {
            Console.WriteLine("Оставить звук?\n"
                            + "1) Да\n"
                            + "2) Нет");

            switch (Input.Chois_input(hero, 0, 3))
            {
                case 1:
                    Sound_effects = true;
                    break;
                case 2:                    
                    Sound_effects = false;
                    break;
            }
        }
    }
}
