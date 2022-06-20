using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMon
{
    internal class Skill
    {
        internal Elementen element = Elementen.Fire;

        internal int damage;
        internal int energyCost;
        internal string name;

        internal Skill()
        {

        }

        internal Skill(Skill copyFrom)
        {
            this.damage = copyFrom.damage;
            this.energyCost = copyFrom.energyCost;
            this.name = copyFrom.name;
        }

        public void UseOn(ConsoleMon target, ConsoleMon caster)
        {
            caster.DepleteEnergy(energyCost);
            target.TakeDamage(damage);
        }
    }
}
