using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marave.classes
{
    public class Enemy : Character
    {
        public Enemy()
        {
            this.maxHealth = 25;
            this.currentHealth = 25;
            this.armor = 12;
            this.strength = 12;
        }

        public void RedefineCharacteristics(int levelHero)
        {
            RedefineArmor(levelHero);
            RedefineStrength(levelHero);
            RedefineHealth(levelHero);
        }

        public void RedefineArmor(int levelHero)
        {
            this.armor += 2 * levelHero;
        }
        public void RedefineStrength(int levelHero)
        {
            this.strength += 2 * levelHero;
        }
        public void RedefineHealth(int levelHero)
        {
            this.currentHealth += 2 * levelHero;
            this.maxHealth += 2 * levelHero;
        }

    }
}
