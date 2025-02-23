using System.Collections.Generic;

namespace FightCons
{
    public class Statistic
    {
        //TODO Довести до ума статистику 

        //  Имя
        public bool knowYourName = false;

        //  События из бара
        //  На каком уровне выперли героя из бара
        public sbyte HeroLvlKickOff;

        //  Разговорные штуки в таверне:
        public sbyte TavernTalksProgress;


        //  Влияния на субъекта
        public sbyte GetDamegeInFight;


        //  Действия субъекта
        //  Боевая статистика
        //  Количество физ атак
        public sbyte Attacks;

        //  Количество маг атак
        public sbyte Spells;

        //  Количество побед
        public sbyte Wins;


        //  Мини игры
        //  Изучение пещеры
        public byte CaveResearch;
        public byte WoodsResearch;

        //  Победы в мини-играх
        public sbyte ArmGameWins;


        public List<sbyte> ChaActions = new List<sbyte>();
    }
}
