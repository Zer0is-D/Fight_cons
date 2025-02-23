using FightCons.CoreNSettings;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;

namespace FightCons
{
    public class Locations
    {
        #region Данные и настроки локации
        //protected enum LocationName
        //{
        //    //CaveStart = 0,
        //    //Caves = 1,
        //    //Vally = 2,
        //    //OrdoNeighborhood = 3,
        //    //VillageOrdo = 4,
        //    //Inn = 5,
        //    //Market = 6,
        //    //Woods = 7,
        //    //MagicManHouse = 8
        //}

        //private static string[][] Discript = new string[][]
        //{
        //    ////  Пещеры
        //    //new string[]
        //    //{
        //    //    "Тут довольно холодно и сыро",
        //    //    "Место очень заросло и было бы невозможно ориентироваться если бы не\n" + "маленькие отверстия в потолке",
        //    //    "Эти пещеры наполнены зловонием павших тел",
        //    //},
        //    ////  Долина
        //    //new string[]
        //    //{
        //    //    "Долина дает увидеть пещеры под холмистой местность, темный лес, хижины людей и совсем рядом с ними жилище духов",
        //    //    "Духи любят пировать вместе с другими",
        //    //    "Чистая, приятная и свежая трава под ногами. Вам это по нраву",
        //    //},
        //    ////  Окрестности Ордо
        //    //new string[]
        //    //{
        //    //    "Духи хоть и живут отдельно, но видно, что им дозволено бродить по деревне",
        //    //    "Люди занимаются земледелием и проводят вас взглядом",
        //    //    "Бедный музыкант всегда может надеяться на монету, когда выступает для духов",
        //    //    "Обрывки диалогов рассказывают вам о необычайно богатом духе и странным к нему\n отношению",
        //    //    "Жизнь тут спокойная и размеренная, никто не торопиться и не спешит",
        //    //},
        //    ////  Деревня Ордо
        //    //new string[]
        //    //{
        //    //    "Небольшая деревня, безликие и уставшие направляются в трактир",
        //    //    "Монахи, что бродят тут, строят дома, молятся Ораулу и приносят дары духам",
        //    //    "Некоторые монахи достигли просветления и соединились с духами, теперь они едины и борются с демонами",
        //    //    "Местные дети играют с животными-духами. Духи любят детей из-за схожести",
        //    //},
        //    ////  Трактир
        //    //new string[]
        //    //{
        //    //    "Трактир, место для лечения горя",
        //    //    "Люди шепчутся об очередном пробуждении Атронахов, коем вы видимо и являетесь",
        //    //    "Монах по кличке 'Бегемот Лева' пьет эль как не в себя, попутна рассказывая сомнительные истории и похабные анекдоты",
        //    //    "Периодически вы чувствуете чей-то взгляд на себе, но оборачиваясь никого не находите",
        //    //},
        //    ////  Рынок
        //    //new string[]
        //    //{
        //    //    "Духи зазывалы, еще более навязчивые, чем люди. Приходить сюда стоит с точным осознанием того что нужно купить",
        //    //    "Орехи, драгоценности, оружия. Духи успевают раздобыть все что необходимо",
        //    //    "Довольные лица покупателей и еще более довольное лицо продавцов",
        //    //    "Духам нравятся ценности, они находят много самородков и просят делать украшения, взамен на пару приманутых овец и кувшин чистой воды",
        //    //},
        //    ////  Леса
        //    //new string[]
        //    //{
        //    //    "Лес настолько густой, что даже ясное солнце не может пробиться сквозь плотную листву",
        //    //    "Находясь в лесу, кажется что ночная тьма отличается от тьмы здешней",
        //    //    "Пугает ни сколько дикие животные звуки, сколь их отсутствие",
        //    //    "В этом месте нет ветра, но холод пробирает до дрожи. Как и то что слышно только свое дыхание и хрустящие шаги",
        //    //},
        //    ////  Храм
        //    //new string[]
        //    //{
        //    //    "111",
        //    //}
        //};

        //private static string Dicscriptions(byte i)
        //{
        //    Random rand = new Random();
        //    return Discript[i][rand.Next(Discript[i].Length)];
        //}

        /// <summary>
        /// Список противников
        /// </summary>
        //protected static List<Order> ListOfUnits = new List<Order>();
        #endregion

        //ЗАГОТОВКА
        public static void Lorem(Hero hero)
        {
            while (true)
            {
                Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"Поселение Решеноми\n");
                //Output.TwriteLine(Dicscriptions(((byte)LocationName.Woods)), 1);

                hero.HPBar();
                hero.MPBar();

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
                            Battles.MakeCurrentBattle(hero, 5);
                        }
                        break;
                    case 3:
                        //Vally(hero);
                        break;
                }
            }
        }

        //  Событие отдых
        protected static void RestEvent(Hero hero)
        {
            if (hero.ClassName != "Волшебник")
                MakeRest(hero);
            else
            {
                string quo = "Выберите вид отдыха:\n" +
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
