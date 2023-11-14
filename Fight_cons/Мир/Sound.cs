using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fight_cons
{
    class Sound
    {
        public static async void Music_player() => await Task.Run(() => LongFanfares_Play());

        #region Звуковые эффекты
        public static async void HIT()
        {
            if (Settings.SoundEffects)
            {
                Console.Beep(130, 60);
                Console.Beep(65, 60);
            }
        }

        public static void LVL_MUSIC()
        {
            if (Settings.SoundEffects)
            {
                //Console.Beep(300, 120);
                //Console.Beep(400, 120);
                //Console.Beep(500, 120);
                //Console.Beep(600, 200);

                Console.Beep(300, 120);
                Console.Beep(400, 120);
                Console.Beep(500, 120);
                Console.Beep(600, 200);
                Console.Beep(300, 100);
                Console.Beep(600, 300);
            }
        }

        public static async void DRINK()
        {
            if (Settings.SoundEffects)
            {
                Console.Beep(138, 60);
                Console.Beep(164, 60);
                Console.Beep(196, 60);
            }
        }

        public static async void DEAD()
        {
            if (Settings.SoundEffects)
            {
                Console.Beep(2093, 240);
                Console.Beep(1568, 240);
                Console.Beep(1046, 240);
                Console.Beep(622, 480);
                Console.Beep(523, 480);
            }
        }

        public static async void WOW()
        {
            if (Settings.SoundEffects)
            {
                Console.Beep(1046, 240);
                Console.Beep(1975, 240);
                Console.Beep(1864, 480);
            }
        }

        public static void Horse_Play()
        {
            Console.Beep(150, 60);
            Console.Beep(100, 60);
            Thread.Sleep(250);
            Console.Beep(150, 60);
            Console.Beep(100, 60);
            Thread.Sleep(250);
            Console.Beep(150, 60);
            Console.Beep(100, 60);
        }
        #endregion

        #region Музыка
        public static void LongFanfares_Play()
        {
            while (true)
            {
                Console.Beep(392, 180);
                Console.Beep(523, 180);
                Console.Beep(783, 180);
                Console.Beep(987, 180);
                Console.Beep(783, 720);
                Thread.Sleep(180);
                Console.Beep(783, 360);
                Console.Beep(523, 420);
                Console.Beep(392, 900);
            }
        }

        public static void BATTLE_MUSIC()
        {
            if (Settings.SoundEffects)
            {
                Console.Beep(200, 200);
                Console.Beep(190, 100);
                Console.Beep(170, 300);
            }
        }
        #endregion

        #region Симуляция голоса
        //  Метод вывода с ожиданием и переходом на другую строку
        public static void Voice_Leva(string str, int x, int f = 220)
        {
            foreach (char s in str)
            {
                Console.Write(s);
                Thread.Sleep(x);
                if (Settings.SoundEffects)
                    Console.Beep(220, 25);
            }
            Console.Write("\n");
        }

        public static void Male_voice(string str, int x = 5)
        {
            var rand = new Random();

            foreach (char s in str)
            {
                Console.Write(s);
                Thread.Sleep(x);
                if (Settings.SoundEffects)
                    Console.Beep(rand.Next(250, 300), /*rand.Next(25, 60)*/40);
            }
            Console.Write("\n");
        }

        public static void Female_voice(string str, int x = 5)
        {
            var rand = new Random();

            foreach (char s in str)
            {
                Console.Write(s);
                Thread.Sleep(x);
                if (Settings.SoundEffects)
                    Console.Beep(rand.Next(350, 480), /*rand.Next(35, 80)*/40);
            }
            Console.Write("\n");
        }

        public static void Monster_voice(string str, int x = 5)
        {
            var rand = new Random();

            foreach (char s in str)
            {
                Console.Write(s);
                Thread.Sleep(20);
                if (Settings.SoundEffects)
                    Console.Beep(rand.Next(140, 200), /*rand.Next(60, 100)*/40);
            }
            Console.Write("\n");
        }

        public static void Pet_voice(string str, int x = 5)
        {
            var rand = new Random();

            foreach (char s in str)
            {
                Console.Write(s);
                Thread.Sleep(x);
                if (Settings.SoundEffects)
                    Console.Beep(rand.Next(500, 600), /*rand.Next(25, 80)*/40);
            }
            Console.Write("\n");
        }
        #endregion
    }
}
