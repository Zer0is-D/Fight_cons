using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Fight_cons
{
    //  Категории сложности
    public enum RestlingDifficult
    {
        VeryEasy,
        Easy,
        Normal,
        Hard,
        VeryHard
    }

    public partial class Arm_game : Form
    {
        Timer timer = new Timer(250);
        Dispatcher dispatcher;
        static Hero arm_hero;

        //  Характеристики стандартного опонента
        //static string PersonName;
        static private int Interval = 150;
        static private sbyte Difficult = 20;
        public static sbyte Cost = 20;


        public Arm_game(Hero hero)
        {
            InitializeComponent();

            arm_hero = hero;
            dispatcher = Dispatcher.CurrentDispatcher;
            timer.Elapsed += Timer_el;
            timer.AutoReset = true;

            RestlingDifficult dif = GetDifficult(hero);
            switch (dif)
            {
                case RestlingDifficult.VeryEasy:
                    Hard_lab.ForeColor = Color.Green;
                    Hard_lab.Text = "Очень легко";
                    break;
                case RestlingDifficult.Easy:
                    Hard_lab.ForeColor = Color.DarkGreen;
                    Hard_lab.Text = "Легко";
                    break;
                case RestlingDifficult.Normal:
                    Hard_lab.Text = "Нормально";
                    break;
                case RestlingDifficult.Hard:
                    Hard_lab.ForeColor = Color.Red;
                    Hard_lab.Text = "Сложно";
                    break;
                case RestlingDifficult.VeryHard:
                    Hard_lab.ForeColor = Color.DarkRed;
                    Hard_lab.Text = "Очень сложно";
                    break;
            }

            Start_b.Location = Click_b.Location;
        }

        //  Сила опонента
        public void Timer_el(object sender, ElapsedEventArgs e)
        {
            bool min_chek = dispatcher.Invoke(() => slider_.Minimum > slider_.Value - Difficult);

            if (min_chek)
                dispatcher.Invoke(() => slider_.Value = slider_.Minimum);
            else
                dispatcher.Invoke(() => slider_.Value -= Difficult);

            if (dispatcher.Invoke(() => { return slider_.Value == 1; }))
            {
                dispatcher.Invoke(
                    () => 
                    {
                        timer.Enabled = timer.AutoReset = false;
                        Click_b.Enabled = false;
                        Start_b.Enabled = false;
                    });

                MessageBox.Show("Вы проиграли");
                DialogResult = DialogResult.No;
            }
        }

        //  Start
        private void Start_btn_Click(object sender, EventArgs e)
        {
            timer.Enabled = Click_b.Enabled = true;
            Start_b.Visible = false;
        }

        //  Click!
        private void button1_Click_1(object sender, EventArgs e)
        {
            //  Проверка на выход из диапазона 
            bool max_chek = dispatcher.Invoke(() => slider_.Maximum < slider_.Value + 20 + (arm_hero.Attack * 10));
            
            if (max_chek)
                slider_.Value = slider_.Maximum;
            else
                slider_.Value += 20 + (int) arm_hero.Attack;

            //  Стратегия поведения если игрок близок к победе
            if (slider_.Value / slider_.Maximum >= 0.7)
                timer.Interval = Interval - 20;
            else
                timer.Interval = Interval;

            //  При достижении игрока максимума
            if (slider_.Value == 300)
            {
                timer.Enabled = timer.AutoReset = false;
                Click_b.Enabled = false;
                Start_b.Enabled = false;
                MessageBox.Show("Вы победили");
                Difficult += 10;
                Interval -= 5;
                Cost += 10;
                DialogResult = DialogResult.Yes;
            }
        }

        //  Опоненты
        //public void Persons()
        //{

        //}

        //  Определние сложности
        public RestlingDifficult GetDifficult(Hero hero)
        {
            RestlingDifficult difficult = RestlingDifficult.Normal;

            if ((hero.Attack * 10) < Difficult - 10)
                difficult++;

            else if ((hero.Attack * 10) > Difficult)
                difficult--;

            if (Interval < 140)
                difficult++;
            else if (Interval > 170)
                difficult--;

            return difficult;
        }
    }
}
