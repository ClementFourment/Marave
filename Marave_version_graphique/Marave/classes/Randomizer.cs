using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marave.classes
{
    public class Randomizer 
    {
        public Randomizer()
        {

        }

        Random random = new Random();
        public int ThrowDice()
        {
            int roll = random.Next(1, 13);
            Console.WriteLine("Résultat du lancer de dé : " + roll);
            return roll;
        }
        public int GetPercentageToCreateRoom()
        {
            return random.Next(1, 101);
        }

        public int GetInsult()
        {
            return random.Next(0, 10);
        }
    }
}
