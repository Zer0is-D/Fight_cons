using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fight_cons
{
    partial class Hero
    {
        //  Система лвл апа (Начало)
        //  Алгоритм и варианты
        static double H;
        public void Level_up(Hero hero, int x)
        {
            exp += x;
            while (exp >= exp_n_lvl)
            {
                // Обязательные операции
                exp -= exp_n_lvl;
                lvl++;
                exp_n_lvl += lvl * 20 + 5;
                byte points = 3;

                //bool[] Points =
                //{
                //    false,
                //    false,
                //    false,
                //    false,
                //    false,
                //    false,
                //    false,
                //    false
                //};

                bool MAX_HP_point = false;
                bool MAX_MP_point = false;
                bool DEF_point = false;
                bool BLK_point = false;
                bool SPD_point = false;
                bool ATC_point = false;
                bool ARC_point = false;
                bool CRIT_point = false;
                H = (MAX_HP / 100.0) * 20.0;

                if (Settings.Sound_effects)
                    Sound.LVL_MUSIC();

                Console.Write($"{Name} достигает {lvl}!\n", 1);
                while (points > 0)
                {
                    //  Поднятие уровня с возможностью выбора вар 2 (усложненая версия)                               
                    Console.Write($"Повышение характеристик, у вас осталось {points} ячеек\n", 1);

                    //  Здоровья
                    if (MAX_HP == 1000)
                    {
                        Outer.ChangeColor("", $"1) MAX Hp: {MAX_HP} (MAX)\n", "", ConsoleColor.DarkGray);
                        MAX_HP_point = true;
                    }
                    else
                        MAX_HP_lvl_point(hero, MAX_HP_point);

                    //  Мана
                    if (MAX_MP == 1000)
                    {
                        Outer.ChangeColor("", $"2) MAX Mp: {MAX_MP} (MAX)\n", "", ConsoleColor.DarkGray);
                        MAX_MP_point = true;
                    }
                    else
                        MAX_MP_lvl_point(hero, MAX_MP_point);

                    //  Броня
                    if (Defence >= 0.98)
                    {
                        Outer.ChangeColor("", $"3) DEF: {Defence * 100}% (MAX)\n", "", ConsoleColor.DarkGray);
                        DEF_point = true;
                    }
                    else
                        DEF_lvl_point(hero, DEF_point);

                    //  Блок
                    if (Block >= 0.98)
                    {
                        Outer.ChangeColor("", $"4) BLK: {Block * 100}% (MAX)\n", "", ConsoleColor.DarkGray);
                        BLK_point = true;
                    }
                    else
                        BLK_lvl_point(hero, BLK_point);

                    //  Скорость
                    if (Speed >= 0.98)
                    {
                        Outer.ChangeColor("", $"5) SPD: {Speed * 100}% (MAX)\n", "", ConsoleColor.DarkGray);
                        SPD_point = true;
                    }
                    else
                        SPD_lvl_point(hero, SPD_point);

                    //  Атака
                    if (Attack >= 100)
                    {
                        Outer.ChangeColor("", $"6) ATC: {Attack} (MAX)\n", "", ConsoleColor.DarkGray);
                        ATC_point = false;
                    }
                    else
                        ATC_lvl_point(hero, ATC_point);

                    //  Arcane
                    if (Arcane >= 100)
                    {
                        Outer.ChangeColor("", $"7) ARC: {Arcane}% (MAX)\n", "", ConsoleColor.DarkGray);
                        ARC_point = true;
                    }
                    else
                        ARC_lvl_point(hero, ARC_point);

                    //  Крит
                    if (Crit >= 0.98)
                    {
                        Outer.ChangeColor("", $"8) CRT: {Crit * 100}% (MAX)\n", "", ConsoleColor.DarkGray);
                        CRIT_point = true;
                    }
                    else
                        CRIT_lvl_point(hero, CRIT_point);

                    switch (Input.Chois_input(hero, 0, 9))
                    {
                        case 1:
                            if (!MAX_HP_point)
                            {
                                MAX_HP += (int)H;
                                MAX_HP += (int)class_Lvl_b.Hp;
                                //MAX_HP += 5;
                                points--;
                                if (!Settings.Bild_vers)
                                    MAX_HP_point = true;
                            }
                            else
                            {
                                MAX_HP -= (int)H;
                                MAX_HP -= (int)class_Lvl_b.Hp;
                                //MAX_HP -= 5;
                                points++;
                                MAX_HP_point = false;
                            }
                            break;
                        case 2:
                            if (!MAX_MP_point)
                            {
                                MAX_MP += 5;
                                MAX_MP += (int)class_Lvl_b.Mp;
                                points--;
                                if (!Settings.Bild_vers)
                                    MAX_MP_point = true;
                            }
                            else
                            {
                                MAX_MP -= 5;
                                MAX_MP -= (int)class_Lvl_b.Mp;
                                points++;
                                MAX_MP_point = false;
                            }
                            break;
                        case 3:
                            if (!DEF_point)
                            {
                                Defence += 0.02;
                                Defence += class_Lvl_b.Defence;
                                points--;
                                if (!Settings.Bild_vers)
                                    DEF_point = true;
                            }
                            else
                            {
                                Defence -= 0.02;
                                Defence -= class_Lvl_b.Defence;
                                points++;
                                DEF_point = false;
                            }
                            break;
                        case 4:
                            if (!BLK_point)
                            {
                                Block += 0.02;
                                Block += class_Lvl_b.Block;
                                points--;
                                if (!Settings.Bild_vers)
                                    BLK_point = true;
                            }
                            else
                            {
                                Block -= 0.02;
                                Block -= class_Lvl_b.Block;
                                points++;
                                BLK_point = false;
                            }
                            break;
                        case 5:
                            if (!SPD_point)
                            {
                                Speed += 0.02;
                                Speed += class_Lvl_b.Speed;
                                points--;
                                if (!Settings.Bild_vers)
                                    SPD_point = true;
                            }
                            else
                            {
                                Speed -= 0.02;
                                Speed -= class_Lvl_b.Speed;
                                points++;
                                SPD_point = false;
                            }
                            break;
                        case 6:
                            if (!ATC_point)
                            {
                                Attack += 1;
                                Attack += (int)class_Lvl_b.Attack;
                                points--;
                                if (!Settings.Bild_vers)
                                    ATC_point = true;
                            }
                            else
                            {
                                Attack -= 1;
                                Attack -= (int)class_Lvl_b.Attack;
                                points++;
                                ATC_point = false;
                            }
                            break;
                        case 7:
                            if (!ARC_point)
                            {
                                Arcane += 1;
                                Arcane += (int)class_Lvl_b.Arcane;
                                points--;
                                if (!Settings.Bild_vers)
                                    ARC_point = true;
                            }
                            else
                            {
                                Arcane -= 1;
                                Arcane -= (int)class_Lvl_b.Arcane;
                                points++;
                                ARC_point = false;
                            }
                            break;
                        case 8:
                            if (!CRIT_point)
                            {
                                Crit += 0.02;
                                Crit += class_Lvl_b.Crit;
                                points--;
                                if (!Settings.Bild_vers)
                                    CRIT_point = true;
                            }
                            else
                            {
                                Crit -= 0.02;
                                Crit -= class_Lvl_b.Crit;
                                points++;
                                CRIT_point = false;
                            }
                            break;
                    }
                }
                Achive();
                hero.hp = MAX_HP;
                hero.mp = MAX_MP;                
            }
        }

        //  Отображение выбранных улучшений
        public void MAX_HP_lvl_point(Hero hero, bool MAX_HP_point)
        {
            if (!MAX_HP_point)
            {
                Console.Write($"1) MAX Hp: {MAX_HP} => {MAX_HP + (int)H} ");
                if (hero.class_Lvl_b.Hp > 0)
                    Console.Write($"(+{(int)(((MAX_HP / 100.0) * 2.0) * 10)} от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"1) MAX Hp: {MAX_HP}\n", "", ConsoleColor.DarkGray);
        }

        public void MAX_MP_lvl_point(Hero hero, bool MAX_MP_point)
        {
            if (!MAX_MP_point)
            {
                Console.Write($"2) MAX Mp: {MAX_MP} => {MAX_MP + 5} ");
                if (hero.class_Lvl_b.Mp > 0)
                    Console.Write($"({(int)(((MAX_MP / 100.0) * 2.0) * 10)} от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"2) MAX Mp: {MAX_MP + 5}\n", "", ConsoleColor.DarkGray);
        }

        public void DEF_lvl_point(Hero hero, bool DEF_point)
        {
            if (!DEF_point)
            {
                Console.Write($"3) DEF: {Defence * 100}% => {(Defence + 0.02) * 100}% ");
                if (hero.class_Lvl_b.Defence > 0)
                    Console.Write($"(+{class_Lvl_b.Defence * 100}% от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"3) DEF: {Defence * 100}%\n", "", ConsoleColor.DarkGray);
        }

        public void BLK_lvl_point(Hero hero, bool BLK_point)
        {
            if (!BLK_point)
            {
                Console.Write($"4) BLK: {Block * 100}% => {(Block + 0.02) * 100}% ");
                if (hero.class_Lvl_b.Block > 0)
                    Console.Write($"(+{class_Lvl_b.Block * 100}% от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"4) BLK: {Block * 100}%\n", "", ConsoleColor.DarkGray);
        }

        public void SPD_lvl_point(Hero hero, bool SPD_point)
        {
            if (!SPD_point)
            {
                Console.Write($"5) SPD: {Speed * 100}% => {(Speed + 0.02) * 100}% ");
                if (hero.class_Lvl_b.Speed > 0)
                    Console.Write($"(+{class_Lvl_b.Speed * 100}% от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"5) SPD: {Speed * 100}%\n", "", ConsoleColor.DarkGray);
        }

        public void ATC_lvl_point(Hero hero, bool ATC_point)
        {
            if (!ATC_point)
            {
                Console.Write($"6) ATC: {Attack} => {Attack + 1} ");
                if (hero.class_Lvl_b.Attack > 0)
                    Console.Write($"(+{class_Lvl_b.Attack} от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"6) ATC: {Attack + 1}\n", "", ConsoleColor.DarkGray);
        }

        public void ARC_lvl_point(Hero hero, bool ARC_point)
        {
            if (!ARC_point)
            {
                Console.Write($"7) ARC: {Arcane} => {Arcane + 1} ");
                if (hero.class_Lvl_b.Arcane > 0)
                    Console.Write($"(+{class_Lvl_b.Arcane} от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"7) ARC: {Arcane + 1}\n", "", ConsoleColor.DarkGray);
        }

        public void CRIT_lvl_point(Hero hero, bool CRIT_point)
        {
            if (!CRIT_point)
            {
                Console.Write($"8) CRIT: {Crit * 100}% => {(Crit + 0.02) * 100}% ");
                if (hero.class_Lvl_b.Crit > 0)
                    Console.Write($"(+{class_Lvl_b.Crit * 100}% от класса)\n");
                else
                    Console.WriteLine();
            }
            else
                Outer.ChangeColor("", $"8) CRIT: {Crit * 100}%\n", "", ConsoleColor.DarkGray);
        }

        //  Проверка максимума
        public void Check_max()
        {

        }

        //  Система достижения
        public void Achive()
        {
            //  Здоровья
            if (MAX_HP >= 500)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Жирный ублюдок_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }


            //  Мана
            if (MAX_MP >= 500)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Колдун_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }


            //  Броня
            if (Defence >= 0.98)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Бронерованный_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }


            //  Блок
            if (Block >= 0.98)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Человек башня_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }


            //  Скорость
            if (Speed >= 0.98)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Чел на скоростях_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }


            //  Атака
            if (Attack >= 100)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Руки базуки_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }


            //  Крит
            if (Crit >= 0.98)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Удачлевый чорт_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }


            //  Arcane
            if (Arcane >= 100)
            {
                Outer.ChangeColor("\n Поздравляю вы получаете достижение: ", $"{Name = "_Колдун_"}", "\n", ConsoleColor.DarkGreen);
                MessageBox.Show("Вы получили достижение!");
            }
        }
    }
}
