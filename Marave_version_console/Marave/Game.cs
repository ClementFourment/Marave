using Marave.classes;

namespace Marave
{
    public class Game
    {
        
        private bool isInGame;
        private int roundNumber;

        public Game()
        {
            this.isInGame = false;
            roundNumber = 0;
        }
       
       
        static void Main(string[] args)
        {
            Game game = new Game();
            while(true)
            {
                game.Menu();
            }
        }
        private void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Menu du jeu");
            Console.WriteLine("1. Lancer le jeu");
            Console.WriteLine("2. Quitter le jeu");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Play(new Hero());
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
            }
        }
        private void Play(Hero hero)
        {
            this.isInGame = true;
            this.roundNumber = 0;

            hero.ManageAvailableCharacteristics();

            while (this.isInGame)
            {
                this.roundNumber++;

                Console.WriteLine("Début du tour " + this.roundNumber);

                this.isInGame = ChooseRandomRoom(hero, this.roundNumber);
            }
            if(!hero.IsDead())
            {
                Win();
            }
            else
            {
                Lose();
            }
        }

        static bool Combat(Hero hero, int roundNumber)
        {
            Fight fight = new Fight();
            Enemy enemy = new Enemy();
            enemy.RedefineCharacteristics(hero.GetLevel());

            Console.WriteLine("Vous rentrez en combat !");
            Console.WriteLine("Un ennemi apparaît ! Il a " + enemy.GetCurrentHealth() + " points de vie !");

            bool initiator = fight.ChooseInitiator();

            while (fight.IsInFight())
            {
                Console.WriteLine("Début du tour " + fight.GetRoundNumber());
                if(initiator) //le heros commence
                {
                    //attaque du hero
                    Console.WriteLine("Vous attaquez l'ennemi. Il perd " + hero.Attack(enemy) + " points de vie.");
                    if (fight.CheckFightersDeath(hero, enemy) != 0)
                    {
                        break;
                    }
                    Console.WriteLine("Il lui reste " + enemy.GetCurrentHealth() + " points de vie.");

                    //attaque de l'ennemi
                    Console.WriteLine("L'ennemi vous attaque. Vous subissez " + enemy.Attack(hero) + " points de vie");
                    if (fight.CheckFightersDeath(hero, enemy) != 0)
                    {
                        break;
                    }
                    Console.WriteLine("Il vous reste " + hero.GetCurrentHealth() + " points de vie.");
                }
                else //le méchant commence
                {
                    //attaque de l'ennemi
                    Console.WriteLine("L'ennemi vous attaque. Vous subissez " + enemy.Attack(hero) + " points de vie");
                    Console.WriteLine("Il vous reste " + hero.GetCurrentHealth() + " points de vie.");

                    //attaque du hero
                    Console.WriteLine("Vous attaquez l'ennemi. Il perd " + hero.Attack(enemy) + " points de vie.");
                    Console.WriteLine("Il lui reste " + enemy.GetCurrentHealth() + " points de vie.");
                }

                //checks de fin de tour
                if (fight.CheckFightersDeath(hero, enemy) == 0) //tout le monde est vivant
                {
                    fight.NextRound();
                }
                else if(fight.CheckFightersDeath(hero, enemy) == 1) //le heros est mort
                {
                    fight.SetIsInFight(false);
                    Console.WriteLine("Vous êtes morts.");
                }
                else //le mechant est mort
                {
                    fight.SetIsInFight(false);
                    Console.WriteLine("L'ennemi est mort.");
                }
            }
            return fight.CheckEndGame(hero, roundNumber);
        }
        static bool Merlin(Hero hero, int roundNumber)
        {
            Merlin merlin = new Merlin();
            int hp = merlin.Heal(hero);
            if(hp > 1)
            {
                Console.WriteLine("Vous avez récupéré " + hp + " points de vie.");
            }
            else
            {
                Console.WriteLine("Vous avez récupéré " + hp + " point de vie.");
            }
            return merlin.CheckEndGame(hero, roundNumber);
        }
        static bool Maitre_armes(Hero hero, int roundNumber)
        {
            MasterOfArms master = new MasterOfArms();
            Console.WriteLine("Vous rencontrez le Maître d'armes !");
            Console.WriteLine("Il vous crie : \"" + master.Insult() + "\" et vous prenez un niveau.");
            master.LevelUp(hero);

            return master.CheckEndGame(hero, roundNumber);
        }
        static void ChangerDeTour()
        {
            Console.WriteLine("Changement de tour");
        }

        static bool ChooseRandomRoom(Hero hero, int roundNumber)
        {
            Randomizer random = new Randomizer();

            int roll = random.GetPercentageToCreateRoom();
            bool b;
            if (roll <= 25)
            {
                b = Maitre_armes(hero, roundNumber);
            }
            else if(roll <= 50)
            {
                b = Merlin(hero, roundNumber);
            }
            else
            {
                b = Combat(hero, roundNumber);
            }
            return b;
        }

        public void Win()
        {
            Console.WriteLine("Vous avez gagné !");
        }
        public void Lose()
        {
            Console.WriteLine("Vous êtes mort. Fin du jeu.");
        }




    }

}