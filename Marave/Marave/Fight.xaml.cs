using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Marave.classes;

namespace Marave
{
    /// <summary>
    /// Logique d'interaction pour Fight.xaml
    /// </summary>
    public partial class Fight : Page
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Hero h = new Hero();
        private int frameCount = 0;
        private bool initiator;
        private int roll = -1;
        public bool frameDice = false; 
        public bool enemyAttack = false;
        private string turn = "";
        public bool endFight = false;
        private bool animHero = true;
        private bool animEnemy = true;
        Enemy en = new Enemy();
        public Fight(Hero hero)
        {
            InitializeComponent();
            this.h = hero;
            en.RedefineCharacteristics(h.GetLevel());
            De de = new De();

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(DispatcherPriority.Send, Dispatcher.CurrentDispatcher);
            dispatcherTimer.Tick += new EventHandler(heroBehaviour);
            dispatcherTimer.Tick += new EventHandler(enemyBehaviour);
            dispatcherTimer.Tick += new EventHandler((sender, e) => updateRoll(sender, e, de));
            dispatcherTimer.Tick += new EventHandler((sender, e) => afficherDice(sender, e, de, h));
            dispatcherTimer.Tick += new EventHandler((sender, e) => barre_de_vie_hero(sender, e, h));
            dispatcherTimer.Tick += new EventHandler((sender, e) => barre_de_vie_enemy(sender, e));
            dispatcherTimer.Tick += new EventHandler((sender, e) => heroAttaque(sender, e, h));
            dispatcherTimer.Tick += new EventHandler((sender, e) => enemyAttaque(sender, e, h));
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);

            dispatcherTimer.Start();
            heroHealth.Maximum = h.GetMaxHealth();
            heroHealth.Value = h.GetCurrentHealth();
            heroHealthText.Text = "" + h.GetCurrentHealth() + "/" + h.GetMaxHealth();

            enemyHealth.Maximum = en.GetMaxHealth();
            enemyHealth.Value = en.GetCurrentHealth();
            enemyHealthText.Text = "" + en.GetCurrentHealth() + "/" + en.GetMaxHealth();


            this.initiator = ChooseInitiator(de);

            mouseEnterFunctions(hero);
            heroInfo.Visibility = Visibility.Hidden;
            enemyInfo.Visibility = Visibility.Hidden;
        }

        private void mouseEnterFunctions(Hero h)
        {
            hero.MouseEnter += (sender, e) => afficherInfosHero(sender, e, h);
            hero.MouseLeave += cacherInfosHero;
            enemy.MouseEnter += afficherInfosEnemy;
            enemy.MouseLeave += cacherInfosEnemy;
        }
        private void afficherInfosHero(object sender, MouseEventArgs e, Hero h)
        {
            heroInfo.Visibility = Visibility.Visible;
            heroInfoLevel.Text = "" + h.GetLevel();
            heroInfoStrength.Text = "" + h.GetStrength();
            heroInfoArmor.Text = "" + h.GetArmor();
        }
        private void cacherInfosHero(object sender, MouseEventArgs e)
        {
            heroInfo.Visibility = Visibility.Hidden;
        }

        private void afficherInfosEnemy(object sender, MouseEventArgs e)
        {
            enemyInfo.Visibility = Visibility.Visible;
            enemyInfoLevel.Text = "" + h.GetLevel();
            enemyInfoStrength.Text = "" + en.GetStrength();
            enemyInfoArmor.Text = "" + en.GetArmor();
        }
        private void cacherInfosEnemy(object sender, MouseEventArgs e)
        {
            enemyInfo.Visibility = Visibility.Hidden;
        }
        public bool ChooseInitiator(De de)
        {
            ChooseInitiator init = new ChooseInitiator();
            frame.Content = init;
            init.wheel.Source = new BitmapImage(new Uri("/Marave;component/images/chooseInitiator_2.png", UriKind.Relative));
            
            bool initiator;
            Randomizer random = new Randomizer();
            int percent = random.GetPercentageToCreateRoom();
            if (percent <= 65)
            {
                initiator = true;
            }
            else
            {
                initiator = false;
            }

            for (int i = 1; i <= 19 + Convert.ToInt32(initiator); i++)
            {
                displayChooseInitiator(i, init);
            }
            closeChooseInitiator(init, de);

            return initiator;
        }

        private async void displayChooseInitiator(int i, ChooseInitiator init)
        {
            await Task.Delay((int)((i*i)*10));
            init.wheel.Source = new BitmapImage(new Uri("/Marave;component/images/chooseInitiator_" + (i%2+1) + ".png", UriKind.Relative));
        }
        private async void closeChooseInitiator(ChooseInitiator init, De de)
        {
            await Task.Delay(6000);
            init.Content = null;
            initFight(de);
        }
        private void initFight(De de)
        {
            
            if (initiator)
            {
                turn = "h";
            }
            else
            {
                turn = "e";
            }
        }
        private void afficherDice(object sender, EventArgs e, De de, Hero hero)
        {
            if(!frameDice && turn == "h" && hero.GetCurrentHealth() > 0)
            {
                frameDice = true;
                de.throw_dice.IsEnabled = true;

                frame.Content = de;
            }
        }
       


        public void heroAttaque(object sender, EventArgs e, Hero hero)
        {
            if (roll != -1 && hero.GetCurrentHealth() > 0)
            {
                frame.Content = null;
                retirerVieMechant(hero, roll);

                for(int i = 0; i < 10; i++)
                {
                    animAttaqueHero(i);
                }
                endAnimAttaqueHero();
            }
        }
        public async void retirerVieMechant(Hero hero, int dmg)
        {
            await Task.Delay(6 * 100 + 500);
            hero.Attack(dmg, this.en);
            animEnemy = false;

            if (en.GetCurrentHealth() > 0)
            {
                for (int i = 0; i < 12; i++)
                {
                    animHurtEnemy(i);
                }
                endAnimHurtEnemy();
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    animDieEnemy(i);
                }
                endAnimDieEnemy();
            }
        }
        public async void animDieEnemy(int i)
        {
            await Task.Delay(i * 100);
            enemy.Source = new BitmapImage(new Uri(@"images/enemy/enemy_die_" + i % 12 + ".png", UriKind.Relative));
        }
        public async void endAnimDieEnemy()
        {
            await Task.Delay(2000);
            //this.Content = null;
            endFight = true;
        }
        public async void animHurtEnemy(int i)
        {
            await Task.Delay(i * 100);
            enemy.Source = new BitmapImage(new Uri(@"images/enemy/enemy_hurt_" + i % 12 + ".png", UriKind.Relative));
        }
        public async void endAnimHurtEnemy()
        {
            await Task.Delay(1200);
            animEnemy = true;
        }

        public async void animAttaqueHero(int i)
        {
            await Task.Delay(i*100 + 500);
            animHero = false;
            hero.Source = new BitmapImage(new Uri(@"images/hero_attack_" + i % 10 + ".png", UriKind.Relative));
        }
        public async void endAnimAttaqueHero()
        {
            await Task.Delay(2500);
            animHero = true;
            frameDice = false;
            turn = "e";
        }


        public void updateRoll(object sender, EventArgs e, De de)
        {
            if (frameDice)
            {
                this.roll = de.roll;
                de.roll = -1;
            }
            else
                this.roll = -1;

        }

        public void enemyAttaque(object sender, EventArgs e, Hero hero)
        {
            if (turn == "e" && !enemyAttack && en.GetCurrentHealth() > 0)
            {
                enemyAttack = true;
                retirerVieHero(hero);
                for (int i = 0; i < 12; i++)
                {
                    animAttaqueEnemy(i);
                }
                endAnimAttaqueEnemy();
            }
        }
        

        public async void retirerVieHero(Hero hero)
        {
            await Task.Delay(7 * 100 + 500);
            Randomizer random = new Randomizer();
            en.Attack(random.ThrowDice(), hero);
            animHero = false;

            if (hero.GetCurrentHealth() > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    animHurtHero(i);
                }
                endAnimHurtHero();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    animDieHero(i);
                }
                endAnimDieHero();
            }
        }
        public async void animDieHero(int i)
        {
            await Task.Delay(i * 100);
            hero.Source = new BitmapImage(new Uri(@"images/hero_die_" + i % 10 + ".png", UriKind.Relative));
        }
        public async void endAnimDieHero()
        {
            await Task.Delay(2000);
            //this.Content = null;
            endFight = true;
        }
        public async void animHurtHero(int i)
        {
            await Task.Delay(i * 100);
            hero.Source = new BitmapImage(new Uri(@"images/hero_hurt_" + i % 10 + ".png", UriKind.Relative));
        }
        public async void endAnimHurtHero()
        {
            await Task.Delay(1000);
            animHero = true;
        }

        public async void animAttaqueEnemy(int i)
        {
            await Task.Delay(i * 100 + 500);
            animEnemy = false;
            enemy.Source = new BitmapImage(new Uri(@"images/enemy/enemy_attack_" + i % 12 + ".png", UriKind.Relative));
        }
        public async void endAnimAttaqueEnemy()
        {
            await Task.Delay(2500);
            animEnemy = true;
            turn = "h";
            enemyAttack = false;
        }










        public void heroBehaviour(object sender, EventArgs e)
        {
            if(animHero)
            {
                hero.Source = new BitmapImage(new Uri(@"images/hero_idle_" + frameCount % 10 + ".png", UriKind.Relative));
                frameCount++;
            }
            CommandManager.InvalidateRequerySuggested();
        }

        public void enemyBehaviour(object sender, EventArgs e)
        {
            if (animEnemy)
            {
                enemy.Source = new BitmapImage(new Uri(@"images/enemy/enemy_idle_" + frameCount % 12 + ".png", UriKind.Relative));
                frameCount++;
            }
            CommandManager.InvalidateRequerySuggested();
        }
        public void barre_de_vie_hero(object sender, EventArgs e, Hero hero)
        {
            heroHealth.Maximum = hero.GetMaxHealth();
            heroHealth.Value = hero.GetCurrentHealth();
            heroHealthText.Text = "" + hero.GetCurrentHealth() + "/" + hero.GetMaxHealth();
        }
        public void barre_de_vie_enemy(object sender, EventArgs e)
        {
            
            enemyHealth.Maximum = en.GetMaxHealth();
            enemyHealth.Value = en.GetCurrentHealth();
            enemyHealthText.Text = "" + en.GetCurrentHealth() + "/" + en.GetMaxHealth();
        }

        public bool CheckEndGame(Hero hero, int roundNumber)
        {
            if (roundNumber >= 20 || hero.IsDead())
            {
                return false;
            }
            return true;
        }
        







        /*public int GetRoundNumber()
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
            if (character1.IsDead())
            {
                return 1;
            }
            else if (character2.IsDead())
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }*/
    }
}
