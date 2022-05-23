using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon
{
    internal enum Elementen
    {
        Lucht,
        Aarde,
        Vuur,
        Water
    }

    class ConsoleMon
    {
        List<Skill> skills = new List<Skill>();

        Elementen weakness = Elementen.Water;

        internal int health;
        internal int energy;
        internal string name;

        internal ConsoleMon()
        {

        }

        internal ConsoleMon(ConsoleMon copyFrom)
        {
            this.health = copyFrom.health;
            this.energy = copyFrom.energy;
            this.name = copyFrom.name;
            this.skills = copyFrom.skills;

            for(int i = 0; i < copyFrom.skills.Count; i++)
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
}
