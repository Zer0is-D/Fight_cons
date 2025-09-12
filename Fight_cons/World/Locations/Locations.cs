using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static FightCons.CharacterClasses;

namespace FightCons
{
    public class Locations
    {
        //зелья
        //Перстова вода/Варево/Пойло/Брага/Сыта/Взвар 
        // ИСС - отвар/Варево
        // ДЖ - роса /Живица 
        // БТЛ - бальзам - сделано
        // ОП - настойки
        // ПП - зелье
        // НД - наливки
        // ВБ

        public static sbyte NamOfGoods = 4;
        public static sbyte NamOfBonuses = 2; //  1-8

        //  Список наименований материалов
        protected static string WoodMat = "дерево";
        protected static string MixedMat = "смешенное";
        protected static string IronMat = "железо";
        protected static string AlloyMat = "сплав";

        #region Наименование предметов

        protected static string[] LowWoodMatTierList =
        {
            "Деревянный меч", 
            "Деревянная пика", 
            "Деревянный топор",
        };
        

        #endregion



        #region Данные и настроки локации
        protected static string Descriptions(byte i, string[][] descript)
        {
            Random rand = new Random();
            return descript[i][rand.Next(descript[i].Length)];
        }

        #endregion

        //ЗАГОТОВКА
        public static void Lorem(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Решеноми\n");
                //Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPnMPBar(true, true);

                string quo = "\nВаши действия?\n"
                           + "1) Войти в деревню\n"
                           + "2) Отдохнуть\n"
                           + "3) Вернуться в долину";

                switch (Input.ChoisInput(hero, 1, 3, quo))
                {
                    case 1:
                        //OrdoСolony(hero);
                        break;
                    case 2:
                        if (GameFormulas.Vero(0.9))
                            RestEvent(hero);
                        else
                        {
                            RestEvent(hero);
                            List<BattleSession> battleList = new List<BattleSession>()
                            {
                                new BattleSession(3, Character.ChaRole.Enemy),
                            };
                            Battles.MakeCurrentBattle(hero, battleList);
                        }
                        break;
                    case 3:
                        //Vally(hero);
                        break;
                }
            }
        }

        //  Событие отдых
        public static void RestEvent(Hero hero)
        {
            if (hero.CharacterClass.Class != ChaClass.Wizard)
                MakeRest(hero);
            else
            {
                string quo = "\nВыберите вид отдыха:\n" +
                            "1) Обычный\n" +
                            "2) Медитация";

                switch (Input.ChoisInput(hero, 1, 2, quo))
                {
                    case 1:
                        MakeRest(hero);
                        break;
                    case 2:
                        MakeMeditation(hero);
                        break;
                }
            }
        }

        //  Отдых
        private static void MakeRest(Hero hero)
        {
            sbyte usualRestoredHP = 30;
            sbyte usualRestoredMP = 20;

            hero.HP += GameFormulas.GetCurrentPercent(hero.MaxHp, usualRestoredHP);
            hero.MP += GameFormulas.GetCurrentPercent(hero.MaxMp, usualRestoredMP);
            Output.WriteColorLine(ConsoleColor.Green, "Небольшой перерыв восстановил вам ", $"+{GameFormulas.GetCurrentPercent(hero.MaxHp, usualRestoredHP)} ", $"{Output.HPSymbol} ");
            Output.WriteColorLine(ConsoleColor.Blue, "и ", $"+{GameFormulas.GetCurrentPercent(hero.MaxMp, usualRestoredMP)} ", $"{Output.MPSymbol}\n");
            Output.WaitNext(3, ".");
        }

        //  Медитация
        private static void MakeMeditation(Hero hero)
        {
            //  Mage restore
            sbyte mageRestoredHP = 20;
            sbyte mageRestoredMP = 50;

            hero.HP += GameFormulas.GetCurrentPercent(hero.MaxHp, mageRestoredHP);
            hero.MP += GameFormulas.GetCurrentPercent(hero.MaxMp, mageRestoredMP);
            Output.WriteColorLine(ConsoleColor.Green, "Медитация восстановила вам ", $"+{GameFormulas.GetCurrentPercent(hero.MaxHp, mageRestoredHP)} ", $"{Output.HPSymbol} ");
            Output.WriteColorLine(ConsoleColor.Blue, "и ", $"+{GameFormulas.GetCurrentPercent(hero.MaxMp, mageRestoredMP)} ", $"{Output.MPSymbol}\n");
            Output.WaitNext(3, ".");
        }
    }
}
