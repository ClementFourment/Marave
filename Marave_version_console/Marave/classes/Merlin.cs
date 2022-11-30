using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marave.interfaces;

namespace Marave.classes
{
    public class Merlin : IRoom
    {
        public Merlin()
        {

        }
        public bool CheckEndGame(Hero hero, int roundNumber)
        {
            if (roundNumber >= 20 || hero.IsDead())
            {
                return false;
            }
            return true;
        }

        public int Heal(Hero hero)
        {
            int heal;
            Console.WriteLine("Vous rencontrer Merlin ! Il restaure 10% de votre vie actuelle. Il ne peut malheureusement pas faire mieux... car il pratique maintenant la médecine, pas de chance !");
            heal = hero.GetMaxHealth() - hero.GetCurrentHealth();
            hero.SetCurrentHealth(hero.GetMaxHealth());
            return heal;
        }
    }
}
