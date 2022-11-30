using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marave.interfaces;

namespace Marave.classes
{
    public class MasterOfArms : IRoom
    {
        public MasterOfArms()
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
        public int LevelUp(Hero hero)
        {
            hero.SetLevel(hero.GetLevel() + 1);
            hero.AddAvailableCharacteristic(3);
            hero.ManageAvailableCharacteristics();
            hero.SetCurrentHealth((int) Math.Round(hero.GetCurrentHealth() * 1.1));
            if(hero.GetCurrentHealth() > hero.GetMaxHealth())
            {
                hero.SetCurrentHealth(hero.GetMaxHealth());
            }
            return hero.GetLevel();
        }

        public string Insult()
        {
            Randomizer random = new Randomizer();
            string[] insults = {
                "En garde, espèce de vieille pute dégarnie !",
                "HAHA, Sire ! Je vous attends ! À moins que vous préfériez que l’on dise partout que le roi est une petite pédale qui pisse dans son froc à l’idée de se battre !",
                "Du nerf, mon lapinou !… Vous allez vous faire tailler le zizi en pointe !",
                "En garde, ma biquette ! Je vais vous découper le gras du cul, ça vous fera ça de moins à trimbaler !",
                "Allez ma p'tite cousine ! Secouez vous un peu les nichons !",
                "Mon père est peut-être unijambiste, mais moi, ma femme n'a pas de moustache ! Alors ça vient? p'tite bite !"
            };

            return insults[random.GetInsult()];
        }
    }
}
