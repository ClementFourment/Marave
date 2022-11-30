using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Marave.classes
{
    public abstract class Character
    {
        protected bool isDead = false;
        protected int currentHealth;
        protected int maxHealth;
        protected int armor;
        protected int strength;


        public Character()
        {

        }
        public int GetCurrentHealth()
        {
            return this.currentHealth;
        }
        public void SetCurrentHealth(int currentHealth)
        {
            this.currentHealth = currentHealth;
        }
        public int GetMaxHealth()
        {
            return this.maxHealth;
        }
        public void SetMaxHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
        }
        public int GetStrength()
        {
            return this.strength;
        }
        public int GetArmor()
        {
            return this.armor;
        }

        public int Attack(int i, Character target)
        {
            int damage = i + this.strength - target.GetArmor();
            if(damage < 0)
            {
                damage = 0;
            }
            target.currentHealth -= damage;
            if(target.currentHealth <= 0)
            {
                target.isDead = true;
            }
            
            return damage;
        }

        public void Die()
        {
            this.isDead = true;
        }
        public bool IsDead()
        {
            return this.isDead;
        }
    }
}
