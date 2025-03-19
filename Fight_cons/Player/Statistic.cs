using System.Collections.Generic;

namespace FightCons
{
    public class Statistic
    {
        //TODO Довести до ума статистику 
        //  Добавить достижение прохождение всех миров
        //  Достижение побывать во всех КУЛЬТУРНЫХ МЕСТАХ

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

        #region Локации
        //  Изучение пещеры
        public byte CaveResearch;
        public byte WoodsResearch;

        //  События из бара
        //  На каком уровне выперли героя из бара
        public sbyte HeroLvlKickOff;

        //  Разговорные штуки в таверне:
        public sbyte TavernTalksProgress;
        #endregion

        //  Информация о противниках
        //public bool EnemyAbout = false;

        #region Способности
        //  Особые способности
        public List<SpecialSkills> SpecialSkills2 = new List<SpecialSkills>
        {
            //  1. ИСС
            new SpecialSkills(10, false),   // 0 Видеть противника
            //  2. ДЖ
            //  3. БТЛ
            new SpecialSkills(30, false),   // 1 Вскрытие брони
            //  4. ОП
            //  5. ПП
            //  6. НД
            //  7. ВБ
        };
        #endregion

        //  Победы в мини-играх
        public sbyte ArmGameWins;


        public List<sbyte> ChaActions = new List<sbyte>();
    }

    public class SpecialSkills
    {
        public sbyte ID;

        public bool Active;

        public SpecialSkills(sbyte id, bool active)
        {
            ID = id;
            Active = active;
        }
    }
}
