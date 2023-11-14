using Fight_cons.form;
using Fight_cons.Основа_и_настройки;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fight_cons
{
    //  Класс допуск
    public class LvlTicket
    {
        internal int NextMaxHp = 5;
        internal int NextMaxMp = 5;
        internal int NextAttack = 1;
        internal int NextArcane = 1;
        internal double NextSpeed = 0.02;
        internal double NextCrit = 0.02;
        internal double NextDefence = 0.02;
        internal double NextMagicDefence = 0.02;
        internal double NextBlock = 0.02;

        public LvlTicket(Hero hero)
        {
            NextMaxHp += hero.PermanentBonuses.MaxHp;
            NextMaxMp += hero.PermanentBonuses.MaxMp;
            NextAttack += hero.PermanentBonuses.Attack;
            NextArcane += hero.PermanentBonuses.Arcane;
            NextSpeed += hero.PermanentBonuses.Speed;
            NextCrit += hero.PermanentBonuses.Crit;
            NextDefence += hero.PermanentBonuses.Defence;
            NextMagicDefence += hero.PermanentBonuses.MagicDefence;
            NextBlock += hero.PermanentBonuses.Block;
        }

        internal bool[] Points =
        {
            false,  //  0.MAX_HP_point
            false,  //  1.MAX_MP_point
            false,  //  2.DEF_point
            false,  //  3.MAG_DEF_point
            false,  //  4.BLK_point
            false,  //  5.SPD_point
            false,  //  6.ATC_point
            false,  //  7.ARC_point
            false   //  8.CRIT_point
        };
        internal byte LvlPoints = 3;
    }

    partial class Hero
    {
        //  Система lvl up
        LvlTicket LTicket;

        public void Level_up(Hero hero, int x)
        {
            LTicket = new LvlTicket(hero);

            Exp += x;      

            while (Exp >= _nextLvlExp)
            {
                // Обязательные операции
                Exp -= _nextLvlExp;
                Lvl++;
                _nextLvlExp += Lvl * 20 + 5;                

                if (Settings.SoundEffects)
                    Sound.LVL_MUSIC();

                Console.WriteLine($"{hero.Name} достигает {Lvl}!\n", 1);
                while (LTicket.LvlPoints > 0)
                {
                    //  Поднятие уровня с возможностью отмены выбора вар 2 (усложненая версия)                               
                    Console.Write($"Повышение характеристик, у вас осталось {LTicket.LvlPoints} ячеек\n", 1);

                    //  Макс здоровье
                    ParamsLvlUp(0, LTicket.Points[0], "MAX Hp", hero.MaxHp, LTicket.NextMaxHp, hero.ClassBonuses.HP, false);

                    //  Макс мана
                    ParamsLvlUp(1, LTicket.Points[1], "MAX Mp", hero.MaxMp, LTicket.NextMaxMp, hero.ClassBonuses.MaxMp, false);

                    //  Защита
                    ParamsLvlUp(2, LTicket.Points[2], "DEF", hero.Defence, LTicket.NextDefence, hero.ClassBonuses.Defence, true);

                    //  Маг защита
                    ParamsLvlUp(3, LTicket.Points[3], "MAG DEF", hero.MagicDefence, LTicket.NextMagicDefence, hero.ClassBonuses.MagicDefence, true);

                    //  Блок
                    ParamsLvlUp(4, LTicket.Points[4], "BLK", hero.Block, LTicket.NextBlock, hero.ClassBonuses.Block, true);

                    //  Скорость
                    ParamsLvlUp(5, LTicket.Points[5], "SPD", hero.Speed, LTicket.NextSpeed, hero.ClassBonuses.Speed, true);

                    //  Атака
                    ParamsLvlUp(6, LTicket.Points[6], "ATC", hero.Attack, LTicket.NextAttack, hero.ClassBonuses.Attack, false);

                    //  Arcane
                    ParamsLvlUp(7, LTicket.Points[7], "ARC", hero.Arcane, LTicket.NextArcane, hero.ClassBonuses.Arcane, false);

                    //  Крит
                    ParamsLvlUp(8, LTicket.Points[8], "CRT", hero.Crit, LTicket.NextCrit, hero.ClassBonuses.Crit, true);

                    switch (Input.ChoisInput(hero, 1, 9))
                    {
                        case 1:
                            MaxHp = (int) SelectedParam(0, MaxHp, LTicket.NextMaxHp, hero.ClassBonuses.MaxHp);
                            break;
                        case 2:
                            MaxMp = (int) SelectedParam(1, hero.MaxMp, LTicket.NextMaxMp, hero.ClassBonuses.MaxMp);
                            break;
                        case 3:
                            Defence = SelectedParam(2, hero.Defence, LTicket.NextDefence, hero.ClassBonuses.Defence);
                            break;
                        case 4:
                            MagicDefence = SelectedParam(3, hero.MagicDefence, LTicket.NextMagicDefence, hero.ClassBonuses.MagicDefence);
                            break;
                        case 5:
                            Block = SelectedParam(4, hero.Block, LTicket.NextBlock, hero.ClassBonuses.Block);
                            break;
                        case 6:
                            Speed = SelectedParam(5, hero.Speed, LTicket.NextSpeed, hero.ClassBonuses.Speed);
                            break;
                        case 7:
                            Attack = (int) SelectedParam(6, hero.Attack, LTicket.NextAttack, hero.ClassBonuses.Attack);
                            break;
                        case 8:
                            Arcane = (int) SelectedParam(7, hero.Arcane, LTicket.NextArcane, hero.ClassBonuses.Arcane);
                            break;
                        case 9:
                            Crit = SelectedParam(8, hero.Crit, LTicket.NextCrit, hero.ClassBonuses.Crit);
                            break;
                    }
                }
                Achivments();
                HP = MaxHp;
                MP = MaxMp;                
            }
        }

        public double SelectedParam(int pointIndex, double mainParam, double val, double classBonusVal)
        {
            if (!LTicket.Points[pointIndex])
            {
                mainParam += val;
                mainParam += classBonusVal;
                LTicket.LvlPoints--;
                if (!Settings.OwnBildVersion)
                    LTicket.Points[pointIndex] = true;
            }
            else
            {
                mainParam -= val;
                mainParam -= classBonusVal;
                LTicket.LvlPoints++;
                LTicket.Points[pointIndex] = false;
            }

            return mainParam;
        }

        //  Отображение выбранных улучшений
        public void ParamsLvlUp(int i, bool point, string paramName, double mainParam, double paramVal, double classBonusParam, bool IsParcent)
        {
            if (IsParcent)
            {
                if (mainParam >= 1)
                {
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{i + 1}) {paramName}: {mainParam} (MAX)\n");
                    LTicket.Points[i] = true;
                }
                else
                {
                    if (!point)
                    {
                        Console.Write($"{i + 1}) {paramName}: {mainParam * 100}% => {(mainParam + paramVal) * 100}% ");
                        if (classBonusParam > 0)
                            Console.Write($"(+{classBonusParam * 100}% от класса)\n");
                        else
                            Console.WriteLine();
                    }
                    else
                        Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{i + 1}) {paramName}: {mainParam * 100}%\n");
                }               
            }
            else
            {
                if (paramName.Contains("MAX") && mainParam >= 1000)
                {
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{i + 1}) {paramName}: {mainParam} (MAX)\n");
                    LTicket.Points[i] = true;
                }
                else if (!paramName.Contains("MAX") && mainParam >= 100)
                {
                    Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{i + 1}) {paramName}: {mainParam} (MAX)\n");
                    LTicket.Points[i] = true;
                }
                else 
                {
                    if (!point)
                    {
                        Console.Write($"{i + 1}) {paramName}: {mainParam} => {mainParam + paramVal} ");
                        if (classBonusParam > 0)
                            Console.Write($"(+{classBonusParam} от класса)\n");
                        else
                            Console.WriteLine();
                    }
                    else
                        Output.WriteColorLine(ConsoleColor.DarkGray, "", $"{i + 1}) {paramName}: {mainParam}\n");
                }
            }
        }

        //  Система достижения
        public void Achivments()
        {
            //  Здоровье
            if (MaxHp >= 500)
                AchiveName("_Жирнич_");

            //  Мана
            if (MaxMp >= 500)
                AchiveName("_Знаток_");

            //  Защита
            if (Defence >= 0.98)
                AchiveName("_Бронерованный_");

            //  Маг защита
            if (MagicDefence >= 0.98)
                AchiveName("_Бес_");

            //  Блок
            if (Block >= 0.98)
                AchiveName("_Человек башня_");

            //  Скорость
            if (Speed >= 0.98)
                AchiveName("_Чел на скоростях_");

            //  Атака
            if (Attack >= 100)
                AchiveName("_Руки базуки_");

            //  Крит
            if (Crit >= 0.98)
                AchiveName("_Удачлевый чорт_");

            //  Arcane
            if (Arcane >= 100)
                AchiveName("_Колдун_");
        }

        public void AchiveName(string name)
        {
            MessageBox.Show("Вы получили достижение!");
            Output.WriteColorLine(ConsoleColor.DarkGreen, "\n Поздравляю вы получаете достижение: ", $"{name}");
            Name = name;            
        }
    }
}
