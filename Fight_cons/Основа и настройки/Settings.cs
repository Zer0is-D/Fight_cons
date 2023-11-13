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
        public static bool Delay_effect = false;
        public static bool Sound_effects = false;

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
            
            if (Input.Chois_input(hero, 0, 3) == 2)
                Delay_effect = !Delay_effect;
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
