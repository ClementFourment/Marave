using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marave.classes
{
    public class Hero : Character
    {
        private int level;
        private int availableCharacteristic;

        public Hero()
        {
            this.level = 1;
            this.maxHealth = 30;
            this.currentHealth = 30;
            this.armor = 15;
            this.strength = 15;
            this.availableCharacteristic = 12;
        }

        public int GetLevel()
        {
            return this.level;
        }
        public void SetLevel(int level)
        {
            this.level = level;
        }
        public int GetAvailableCharacteristic()
        {
            return this.availableCharacteristic;
        }
        public void AddAvailableCharacteristic(int characteristicNumber)
        {
            this.availableCharacteristic += characteristicNumber;
        }

        public void AddStrength()
        {
            this.strength++;
            this.availableCharacteristic--;
        }
        public void AddHealth()
        {
            this.maxHealth++;
            if(this.currentHealth < this.maxHealth)
            {
                this.currentHealth++;
            }
            this.availableCharacteristic--;
        }
        public void AddArmor()
        {
            this.armor++;
            this.availableCharacteristic--;
        }

        public void ManageAvailableCharacteristics()
        {
            switch (Console.ReadLine())
            {
                case "h":
                    AddHealth();
                    break;
                case "s":
                    AddStrength();
                    break;
                case "a":
                    AddArmor();
                    break;
            }
           
        }
    }
}
