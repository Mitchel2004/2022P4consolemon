using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleMonsters.Tools;
using ConsoleMon;

namespace ConsoleMonsters.Loaders
{
    class ConsoleMonData
    {
        internal string monsterLine;
        internal string skillLine;
    }
    class ConsoleMonFactory
    {
        private Dictionary<string, ConsoleMonData> templates = new Dictionary<string, ConsoleMonData>();

        public void Load(/*string datafile*/)
        {
            //lees je regels in 
            string file = Path.Combine(PathHelper.ExeDir(), "monsterdata.txt");
            string[] lines = File.ReadAllLines(file);

            for (int i = 0; i < lines.Length; i+=2)
            {
                ConsoleMonData data = new ConsoleMonData();
                //zet monsterLine (regel1) & skillLine (regel2)
                data.monsterLine = lines[i];
                data.skillLine = lines[i+1];

                //split monsterline op ',' en pak de eerste, dit zou je monsterType moeten zijn
                string monsterType = data.monsterLine.Split(",")[0];



                //even toevoegen
                templates.Add(monsterType, data);

            }

        }

        private ConsoleMon.ConsoleMon MakeConsoleMon(ConsoleMonData data)
        {
            ConsoleMon.ConsoleMon temp = new ConsoleMon.ConsoleMon();
            //split de monsterLine uit data weer op ','
            string[] properties = data.monsterLine.Split(",");


           //zet nu de onderste fields met data 
            temp.monsterType = properties[0];
            temp.health = data.monsterLine[2];
            //temp.BaseDam = ???;
            temp.weakness = LoadElement(properties[6]);


            //nu de skills, OOF!
            string[] skillSep = data.skillLine.Split(';');
            //nu hebben we de verschillende skills in strings in skillSep (bv skillSep[0] is de data van de eerste skill)

            for (int j = 1; j < skillSep.Length; j++)
            {
                Skill skill = LoadSkill(skillSep[j]);

                //voeg nu skill van hierboven toe aan de skills van temp
                temp.skills.Add(skill);
            }
            return temp;
        }
        private Skill LoadSkill(string skillstring)
        {
            string[] split = skillstring.Split(',');
            Skill skill = new Skill()
            {
                name = split[0],
                damage = int.Parse(split[2]),
                energyCost = int.Parse(split[4]),
                element = LoadElement(split[6])
            };
            return skill;

        }


        //misschien dat jouw enum niet Element heet, dan even Element vervangen door jouw naam
        private static Elementen LoadElement(string split)
        {
            return (Elementen)Enum.Parse(typeof(Elementen), split);
        }

        internal ConsoleMon.ConsoleMon Make(string monstertype)
        {
            return MakeConsoleMon(templates[monstertype]);
        }
    }
}