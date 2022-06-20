using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon
{
    internal enum Elementen
    {
        Fire,
        Elec,
        Dark,
        Physical,
        Water
    }

    internal class ConsoleMon
    {
        internal List<Skill> skills = new List<Skill>();

        internal Elementen weakness = Elementen.Elec;

        internal int health;
        internal int energy;
        internal string name;
        internal string monsterType;

        internal ConsoleMon()
        {

        }

        internal ConsoleMon(ConsoleMon copyFrom)
        {
            this.health = copyFrom.health;
            this.energy = copyFrom.energy;
            this.name = copyFrom.name;
            this.skills = copyFrom.skills;

            for (int i = 0; i < copyFrom.skills.Count; i++)
            {
                Skill copyFromThisSkill = copyFrom.skills[i];
                Skill clone = new Skill(copyFromThisSkill);
                this.skills.Add(clone);
            }
        }

        internal void TakeDamage(int damage)
        {
            health -= damage;
        }

        internal void DepleteEnergy(int energy)
        {
            this.energy -= energy;
        }
    }

    internal class ConsoleMonArena
    {
        public void DoBattle(ConsoleMon a, ConsoleMon b)
        {
            Random random = new Random();

            Skill skillA = a.skills[random.Next(2)];
            Skill skillB = b.skills[random.Next(2)];

            while (a.health > 0 || b.health > 0)
            {
                skillA.UseOn(b, a);
                skillB.UseOn(a, b);

                Console.WriteLine(a.health);
                Console.WriteLine(b.health);
            }
        }
    }
}
