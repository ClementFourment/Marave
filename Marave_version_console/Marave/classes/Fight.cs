using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marave.interfaces;

namespace Marave.classes
{
    public class Fight : IRoom
    {
        private int roundNumber;
        private bool isInFight;
        public Fight()
        {
            this.roundNumber = 1;
            this.isInFight = true;
        }
        public bool CheckEndGame(Hero hero, int roundNumber)
        {
            if (roundNumber >= 20 || hero.IsDead())
            {
                return false;
            }
            return true;
        }
        public bool ChooseInitiator()
        {
            Randomizer random = new Randomizer();
            int percent = random.GetPercentageToCreateRoom();
            if (percent <= 65)
            {
                Console.WriteLine("Vous commencez.");
                return true;
            }
            Console.WriteLine("L'ennemi commence.");
            return false;
        }
        public int GetRoundNumber()
        {
            return this.roundNumber;
        }
        public void SetIsInFight(bool b)
        {
            this.isInFight = b;
        }
        public bool IsInFight()
        {
            return this.isInFight;
        }
        
        public void NextRound()
        {
            this.roundNumber++;
        }
        public int CheckFightersDeath(Character character1, Character character2)
        {
            if(character1.IsDead())
            {
                return 1;
            }
            else if(character2.IsDead())
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
    
}
