using System.Collections.Generic;

namespace FightCons
{
    public class Statistic
    {
        //TODO Довести до ума статистику 

        //  Имя
        public bool knowYourName = false;

        //  Влияния на субъекта
        public sbyte GetDamageInFight;


        //  Действия субъекта
        //  Боевая статистика
        //  Количество заработанных денег 
        public int Money;

        //  Количество физ атак
        public sbyte Attacks;

        //  Количество маг атак
        public sbyte Spells;

        //  Количество побед
        public sbyte Wins;


        //  Изучение пещеры
        public byte CaveResearch;
        public byte WoodsResearch;



        //  События из бара
        //  На каком уровне выперли героя из бара
        public sbyte HeroLvlKickOff;

        //  Разговорные штуки в таверне:
        public sbyte TavernTalksProgress;

        //  Победы в мини-играх
        public sbyte ArmGameWins;


        public List<sbyte> ChaActions = new List<sbyte>();
    }
}
