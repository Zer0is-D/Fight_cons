using System;

namespace Fight_cons
{
    public class Settings
    {
        //  Режим
        public static bool BildVersActive = false;
        public static bool OwnBildVersion = false;
        public static bool DelayEffects = false;
        public static bool SoundEffects = false;

        //  Настройка окна
        //public static void Console_window()
        //{
        //    //Console.SetWindowSize(12, 20);
        //}

        public static void OptionWaitSkip(Hero hero)
        {
            Console.WriteLine("Убать задержку?\n"
                            + "1) Да\n"
                            + "2) Нет");
            
            if (Input.ChoisInput(hero, 1, 2) == 2)
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
        public static void Option_sound(Hero hero)
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
