using Fight_cons.form;
using Fight_cons.Противник;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static Fight_cons.Charecter;
using static Fight_cons.Основа_и_настройки.CharecterProfiles;

namespace Fight_cons
{
    public class DifrentFiles
    {
        private static string Path = Application.StartupPath + "\\Units.xml";

        public static Unit LoudedEnemies(short id)
        {
            var res = Bestiaria.GetUnit(id);

            if (res != null)
                return new Unit(res);
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

                Bestiaria loadedUnit;

                if (element != null)
                {
                    loadedUnit = new Bestiaria
                    (
                        name: currentEnemy.Element("Name").Value,
                        phase: sbyte.Parse(currentEnemy.Element("Phase").Value),
                        hpMin: short.Parse(currentEnemy.Element("MinHp").Value), hpMax: short.Parse(currentEnemy.Element("MaxHp").Value),
                        attMin: short.Parse(currentEnemy.Element("MinAttack").Value), attMax: short.Parse(currentEnemy.Element("MaxAttack").Value),
                        spdMin: sbyte.Parse(currentEnemy.Element("MinSpeed").Value), spdMax: sbyte.Parse(currentEnemy.Element("MaxSpeed").Value),
                        critMin: sbyte.Parse(currentEnemy.Element("MinCrit").Value), critMax: sbyte.Parse(currentEnemy.Element("MaxCrit").Value),
                        defMin: sbyte.Parse(currentEnemy.Element("MinDefence").Value), defMax: sbyte.Parse(currentEnemy.Element("MaxDefence").Value),
                        mDefMin: sbyte.Parse(currentEnemy.Element("MinMagicDefence").Value), mDefMax: sbyte.Parse(currentEnemy.Element("MaxMagicDefence").Value),
                        blkMin: sbyte.Parse(currentEnemy.Element("MinBlock").Value), blkMax: sbyte.Parse(currentEnemy.Element("MaxBlock").Value),
                        movMin: sbyte.Parse(currentEnemy.Element("MinMoves").Value), movMax: sbyte.Parse(currentEnemy.Element("MaxMoves").Value),
                        role: (ChaRole) Enum.Parse(typeof(ChaRole), currentEnemy.Element("Role").Value),
                        strategy: (Strategeis)Enum.Parse(typeof(Strategeis), currentEnemy.Element("Strategeis").Value)
                    )
                    {
                        Id = id
                    };
                }
                else
                {
                    loadedUnit = new Bestiaria
                    (
                        name: currentEnemy.Element("Name").Value,
                        phase: sbyte.Parse(currentEnemy.Element("Phase").Value),
                        hp: short.Parse(currentEnemy.Element("HP").Value),
                        attack: short.Parse(currentEnemy.Element("Attack").Value),
                        speed: sbyte.Parse(currentEnemy.Element("Speed").Value),
                        critChance: sbyte.Parse(currentEnemy.Element("Crit").Value),
                        defence: sbyte.Parse(currentEnemy.Element("Defence").Value),
                        magicDefence: sbyte.Parse(currentEnemy.Element("MagicDefence").Value),
                        block: sbyte.Parse(currentEnemy.Element("Block").Value),
                        moves: sbyte.Parse(currentEnemy.Element("Moves").Value),
                        noRun: bool.Parse(currentEnemy.Element("CantRun").Value),
                        role: (ChaRole) Enum.Parse(typeof(ChaRole), currentEnemy.Element("Role").Value),
                        strategy: (Strategeis)Enum.Parse(typeof(Strategeis), currentEnemy.Element("Strategeis").Value)
                    )
                    {
                        Id = id
                    };
                }

                Bestiaria.AddNewBestiarias(loadedUnit);
                SaveUnits();

                return new Unit(loadedUnit);
            }

            SaveUnits();            
            return null;
        }

        //  если список с противниками есть, то загружаем противников из него. В ином случаи создаем список с базовыми противниками 
        public static List<Bestiaria> LoadBestiarList()
        {
            if (File.Exists(Path))
            {
                XDocument document = XDocument.Load(Path);

                var uniqueUnits = document.Root.Elements("Unit")
                    .GroupBy(x => (short)x.Element("ID"))
                    .Select(g => g.First())
                    .ToList();

                List<Bestiaria> loaded = new List<Bestiaria>();                

                foreach (var unit in uniqueUnits)
                {
                    XElement element = unit.Element("MaxHp");

                    if (element != null)
                    {
                        loaded.Add(new Bestiaria
                        (
                            name: unit.Element("Name")?.Value,
                            phase: sbyte.Parse(unit.Element("Phase")?.Value),
                            hpMin: short.Parse(unit.Element("MinHp")?.Value), hpMax: short.Parse(unit.Element("MaxHp")?.Value),
                            attMin: short.Parse(unit.Element("MinAttack")?.Value), attMax: short.Parse(unit.Element("MaxAttack")?.Value),
                            spdMin: sbyte.Parse(unit.Element("MinSpeed")?.Value), spdMax: sbyte.Parse(unit.Element("MaxSpeed")?.Value),
                            critMin: sbyte.Parse(unit.Element("MinCrit")?.Value), critMax: sbyte.Parse(unit.Element("MaxCrit")?.Value),
                            defMin: sbyte.Parse(unit.Element("MinDefence")?.Value), defMax: sbyte.Parse(unit.Element("MaxDefence")?.Value),
                            mDefMin: sbyte.Parse(unit.Element("MinMagicDefence")?.Value), mDefMax: sbyte.Parse(unit.Element("MaxMagicDefence")?.Value),
                            blkMin: sbyte.Parse(unit.Element("MinBlock")?.Value), blkMax: sbyte.Parse(unit.Element("MaxBlock")?.Value),
                            movMin: sbyte.Parse(unit.Element("MinMoves")?.Value), movMax: sbyte.Parse(unit.Element("MaxMoves")?.Value),
                            role: (ChaRole)Enum.Parse(typeof(ChaRole), unit.Element("Role")?.Value),
                            strategy: (Strategeis)Enum.Parse(typeof(Strategeis), unit.Element("Strategeis")?.Value)
                        )
                        { Id = short.Parse(unit.Element("ID")?.Value) });
                    }
                    else
                    {
                        loaded.Add(new Bestiaria
                        (
                            name: unit.Element("Name").Value,
                            phase: sbyte.Parse(unit.Element("Phase").Value),
                            hp: short.Parse(unit.Element("HP").Value),
                            attack: short.Parse(unit.Element("Attack").Value),
                            speed: sbyte.Parse(unit.Element("Speed").Value),
                            critChance: sbyte.Parse(unit.Element("Crit").Value),
                            defence: sbyte.Parse(unit.Element("Defence").Value),
                            magicDefence: sbyte.Parse(unit.Element("MagicDefence").Value),
                            block: sbyte.Parse(unit.Element("Block").Value),
                            moves: sbyte.Parse(unit.Element("Moves").Value),
                            noRun: bool.Parse(unit.Element("CantRun").Value),
                            role: (ChaRole)Enum.Parse(typeof(ChaRole), unit.Element("Role").Value),
                            strategy: (Strategeis)Enum.Parse(typeof(Strategeis), unit.Element("Strategeis").Value)
                        )
                        { Id = short.Parse(unit.Element("ID").Value) });
                    }
                }                

                if (loaded.Count > 0)
                {
                    Bestiaria.BestiariaList.Clear();
                    Bestiaria.BestiariaList.AddRange(loaded);
                    return loaded;
                }

                Console.WriteLine("Ошибка загрузки списка. Список пуст!");
                return Bestiaria.BestiariaList;
            }

            Bestiaria.CreateBasicBestiaria();

            SaveUnits();

            return Bestiaria.BestiariaList;
        }

        public static void SaveUnits(List<Bestiaria> bestiars = null)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
                File.WriteAllText(Path, $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}<catalog></catalog>");
            }

            XDocument document = new XDocument(new XElement("Units"));

            if (File.Exists(Path))
            {
                foreach (var uni in Bestiaria.BestiariaList)
                {
                    if (uni.HpMax != 0)
                    {
                        XElement xelem = new XElement($"Unit",
                            new XElement("ID", uni.Id),
                            new XElement("Name", uni.Name),
                            new XElement("Phase", uni.CharecterProfile.Phase),

                            new XElement("MinHp", uni.HpMin), new XElement("MaxHp", uni.HpMax),
                            new XElement("MinAttack", uni.AttMin), new XElement("MaxAttack", uni.AttMax),
                            new XElement("MinSpeed", uni.SpdMin), new XElement("MaxSpeed", uni.SpdMax),
                            new XElement("MinCrit", uni.CrtMin), new XElement("MaxCrit", uni.CrtMax),
                            new XElement("MinDefence", uni.DefMin), new XElement("MaxDefence", uni.DefMax),
                            new XElement("MinMagicDefence", uni.MDefMin), new XElement("MaxMagicDefence", uni.MDefMax),
                            new XElement("MinBlock", uni.BlkMin), new XElement("MaxBlock", uni.BlkMax),
                            new XElement("MinMoves", uni.MovMin), new XElement("MaxMoves", uni.MovMax),
                            new XElement("Role", uni.CharecterProfile.Role),
                            new XElement("Strategeis", uni.CharecterProfile.Strategy));

                        document.Root.Add(xelem);
                    }
                    else
                    {
                        XElement xelem = new XElement($"Unit",
                            new XElement("ID", uni.Id),
                            new XElement("Name", uni.Name),
                            new XElement("Phase", uni.CharecterProfile.Phase),
                            new XElement("HP", uni.HpMin),
                            new XElement("Attack", uni.AttMin),
                            new XElement("Speed", uni.SpdMin),
                            new XElement("Crit", uni.CrtMin),
                            new XElement("Defence", uni.DefMin),
                            new XElement("MagicDefence", uni.MDefMin),
                            new XElement("Block", uni.BlkMin),
                            new XElement("Moves", uni.MovMin),
                            new XElement("CantRun", uni.CharecterProfile.TooBrave),
                            new XElement("Role", uni.CharecterProfile.Role),
                            new XElement("Strategeis", uni.CharecterProfile.Strategy));

                        document.Root.Add(xelem);
                    }
                }
            }            

            document.Save(Path);
        }
    }
}
