using FightCons.Enemies;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static FightCons.CoreNSettings.CharecterProfiles;

namespace FightCons
{
    public class EnemyFromXML
    {
        // TODO сделать hash проверки
        private static string Path = Application.StartupPath + "\\Units.xml";

        public static Unit LoudedEnemies(short id)
        {
            var res = Bestiaries.GetUnit(id);

            if (res != null)
            {
                //TODO посути надо запихивать сюда готового юнита из списка тварей, но список тварей еще не сгенерен. Надом думу думать, а пока удаляем файл
                //  Временное решение
                //Bestiaries.CreateBasicBestiary();
                //return new Unit(Bestiaries.BestiaryList.FirstOrDefault(x => x.Id == id));

                // Иначальное решение
                return new Unit(Bestiaries.GetUnit(id));
            }                
            else
                return LoadUnit(id);
        }

        static Unit LoadUnit(short id)
        {
            if (File.Exists(Path))
            {
                XDocument document = XDocument.Load(Path);

                XElement currentEnemy = document.Root.Elements("Unit")
                    .FirstOrDefault(e => short.Parse(e.Element("ID").Value) == id);

                if (currentEnemy == null)
                {
                    Console.WriteLine($"Ошибка при загрузки юнита с ID {id}");
                    return null;
                }

                XElement element = currentEnemy.Element("MaxHp");

                Bestiaries loadedUnit;

                if (element != null)
                {
                    loadedUnit = new Bestiaries
                    (
                        name: currentEnemy.Element("Name").Value,
                        phase: sbyte.Parse(currentEnemy.Element("Phase").Value),
                        hpMin: short.Parse(currentEnemy.Element("MinHp").Value), hpMax: short.Parse(currentEnemy.Element("MaxHp").Value),
                        attMin: short.Parse(currentEnemy.Element("MinAttack").Value), attMax: short.Parse(currentEnemy.Element("MaxAttack").Value),
                        spdMin: sbyte.Parse(currentEnemy.Element("MinSpeed").Value), spdMax: sbyte.Parse(currentEnemy.Element("MaxSpeed").Value),
                        critMin: sbyte.Parse(currentEnemy.Element("MinCrit").Value), critMax: sbyte.Parse(currentEnemy.Element("MaxCrit").Value),
                        defMin: sbyte.Parse(currentEnemy.Element("MinDefense").Value), defMax: sbyte.Parse(currentEnemy.Element("MaxDefense").Value),
                        mDefMin: sbyte.Parse(currentEnemy.Element("MinMagicDefense").Value), mDefMax: sbyte.Parse(currentEnemy.Element("MaxMagicDefense").Value),
                        blkMin: sbyte.Parse(currentEnemy.Element("MinBlock").Value), blkMax: sbyte.Parse(currentEnemy.Element("MaxBlock").Value),
                        movMin: sbyte.Parse(currentEnemy.Element("MinMoves").Value), movMax: sbyte.Parse(currentEnemy.Element("MaxMoves").Value),
                        role: (ChaRole) Enum.Parse(typeof(ChaRole), currentEnemy.Element("Role").Value),
                        strategy: (Strategeis)Enum.Parse(typeof(Strategeis), currentEnemy.Element("Strategies").Value)
                    )
                    {
                        Id = id
                    };
                }
                else
                {
                    loadedUnit = new Bestiaries
                    (
                        name: currentEnemy.Element("Name").Value,
                        phase: sbyte.Parse(currentEnemy.Element("Phase").Value),
                        hp: short.Parse(currentEnemy.Element("HP").Value),
                        attack: short.Parse(currentEnemy.Element("Attack").Value),
                        speed: sbyte.Parse(currentEnemy.Element("Speed").Value),
                        critChance: sbyte.Parse(currentEnemy.Element("Crit").Value),
                        defence: sbyte.Parse(currentEnemy.Element("Defense").Value),
                        magicDefence: sbyte.Parse(currentEnemy.Element("MagicDefense").Value),
                        block: sbyte.Parse(currentEnemy.Element("Block").Value),
                        moves: sbyte.Parse(currentEnemy.Element("Moves").Value),
                        noRun: bool.Parse(currentEnemy.Element("CantRun").Value),
                        role: (ChaRole) Enum.Parse(typeof(ChaRole), currentEnemy.Element("Role").Value),
                        strategy: (Strategeis)Enum.Parse(typeof(Strategeis), currentEnemy.Element("Strategies").Value)
                    )
                    {
                        Id = id
                    };
                }

                Bestiaries.AddNewBestiaries(loadedUnit);
                SaveUnits();

                return new Unit(loadedUnit);
            }

            SaveUnits();            
            return null;
        }

        //  если список с противниками есть, то загружаем противников из него. В ином случаи создаем список с базовыми противниками 
        public static List<Bestiaries> LoadBestiaryList()
        {
            if (File.Exists(Path))
            {
                XDocument document = XDocument.Load(Path);

                var uniqueUnits = document.Root.Elements("Unit")
                    .GroupBy(x => (short)x.Element("ID"))
                    .Select(g => g.First())
                    .ToList();

                List<Bestiaries> loaded = new List<Bestiaries>();                

                foreach (var unit in uniqueUnits)
                {
                    XElement element = unit.Element("MaxHp");

                    if (element != null)
                    {
                        loaded.Add(new Bestiaries
                        (
                            name: unit.Element("Name")?.Value,
                            phase: sbyte.Parse(unit.Element("Phase")?.Value),
                            hpMin: short.Parse(unit.Element("MinHp")?.Value), hpMax: short.Parse(unit.Element("MaxHp")?.Value),
                            attMin: short.Parse(unit.Element("MinAttack")?.Value), attMax: short.Parse(unit.Element("MaxAttack")?.Value),
                            spdMin: sbyte.Parse(unit.Element("MinSpeed")?.Value), spdMax: sbyte.Parse(unit.Element("MaxSpeed")?.Value),
                            critMin: sbyte.Parse(unit.Element("MinCrit")?.Value), critMax: sbyte.Parse(unit.Element("MaxCrit")?.Value),
                            defMin: sbyte.Parse(unit.Element("MinDefense")?.Value), defMax: sbyte.Parse(unit.Element("MaxDefense")?.Value),
                            mDefMin: sbyte.Parse(unit.Element("MinMagicDefense")?.Value), mDefMax: sbyte.Parse(unit.Element("MaxMagicDefense")?.Value),
                            blkMin: sbyte.Parse(unit.Element("MinBlock")?.Value), blkMax: sbyte.Parse(unit.Element("MaxBlock")?.Value),
                            movMin: sbyte.Parse(unit.Element("MinMoves")?.Value), movMax: sbyte.Parse(unit.Element("MaxMoves")?.Value),
                            role: (ChaRole)Enum.Parse(typeof(ChaRole), unit.Element("Role")?.Value),
                            strategy: (Strategeis)Enum.Parse(typeof(Strategeis), unit.Element("Strategies")?.Value)
                        )
                        { Id = short.Parse(unit.Element("ID")?.Value) });
                    }
                    else
                    {
                        loaded.Add(new Bestiaries
                        (
                            name: unit.Element("Name").Value,
                            phase: sbyte.Parse(unit.Element("Phase").Value),
                            hp: short.Parse(unit.Element("HP").Value),
                            attack: short.Parse(unit.Element("Attack").Value),
                            speed: sbyte.Parse(unit.Element("Speed").Value),
                            critChance: sbyte.Parse(unit.Element("Crit").Value),
                            defence: sbyte.Parse(unit.Element("Defense").Value),
                            magicDefence: sbyte.Parse(unit.Element("MagicDefense").Value),
                            block: sbyte.Parse(unit.Element("Block").Value),
                            moves: sbyte.Parse(unit.Element("Moves").Value),
                            noRun: bool.Parse(unit.Element("CantRun").Value),
                            role: (ChaRole)Enum.Parse(typeof(ChaRole), unit.Element("Role").Value),
                            strategy: (Strategeis)Enum.Parse(typeof(Strategeis), unit.Element("Strategies").Value)
                        )
                        { Id = short.Parse(unit.Element("ID").Value) });
                    }
                }                

                if (loaded.Count > 0)
                {
                    Bestiaries.BestiaryList.Clear();
                    Bestiaries.BestiaryList.AddRange(loaded);
                    return loaded;
                }

                Console.WriteLine("Ошибка загрузки списка. Список пуст!");
                return Bestiaries.BestiaryList;
            }

            Bestiaries.CreateBasicBestiary();

            SaveUnits();

            return Bestiaries.BestiaryList;
        }

        public static void SaveUnits(List<Bestiaries> bestiary = null)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
                File.WriteAllText(Path, $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}<catalog></catalog>");
            }

            XDocument document = new XDocument(new XElement("Units"));

            if (File.Exists(Path))
            {
                foreach (var uni in Bestiaries.BestiaryList)
                {
                    if (uni.HpMax != 0)
                    {
                        XElement xelem = new XElement($"Unit",
                            new XElement("ID", uni.Id),
                            new XElement("Name", uni.Name),
                            new XElement("Phase", uni.CharacterProfile.Phase),

                            new XElement("MinHp", uni.HpMin), new XElement("MaxHp", uni.HpMax),
                            new XElement("MinAttack", uni.AttMin), new XElement("MaxAttack", uni.AttMax),
                            new XElement("MinSpeed", uni.SpdMin), new XElement("MaxSpeed", uni.SpdMax),
                            new XElement("MinCrit", uni.CrtMin), new XElement("MaxCrit", uni.CrtMax),
                            new XElement("MinDefense", uni.DefMin), new XElement("MaxDefense", uni.DefMax),
                            new XElement("MinMagicDefense", uni.MDefMin), new XElement("MaxMagicDefense", uni.MDefMax),
                            new XElement("MinBlock", uni.BlkMin), new XElement("MaxBlock", uni.BlkMax),
                            new XElement("MinMoves", uni.MovMin), new XElement("MaxMoves", uni.MovMax),
                            new XElement("Role", uni.CharacterProfile.Role),
                            new XElement("Strategies", uni.CharacterProfile.Strategy));

                        document.Root.Add(xelem);
                    }
                    else
                    {
                        XElement xelem = new XElement($"Unit",
                            new XElement("ID", uni.Id),
                            new XElement("Name", uni.Name),
                            new XElement("Phase", uni.CharacterProfile.Phase),
                            new XElement("HP", uni.HpMin),
                            new XElement("Attack", uni.AttMin),
                            new XElement("Speed", uni.SpdMin),
                            new XElement("Crit", uni.CrtMin),
                            new XElement("Defense", uni.DefMin),
                            new XElement("MagicDefense", uni.MDefMin),
                            new XElement("Block", uni.BlkMin),
                            new XElement("Moves", uni.MovMin),
                            new XElement("CantRun", uni.CharacterProfile.TooBrave),
                            new XElement("Role", uni.CharacterProfile.Role),
                            new XElement("Strategies", uni.CharacterProfile.Strategy));

                        document.Root.Add(xelem);
                    }
                }
            }            

            document.Save(Path);
        }
    }
}
