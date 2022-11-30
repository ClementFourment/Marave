using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Marave.classes;
using System.Media;
using System.Data;
using System.Drawing;
using System.IO;


namespace Marave
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    
    public partial class Game : Window
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public WMPLib.WindowsMediaPlayer MXP = new WMPLib.WindowsMediaPlayer();
        private int frameCount = 0;
        private int offsetLeft = 0;
        public string stateHero = "idle";
        public bool frameWheel = false;
        public bool frameCharacteristics = false;
        public bool ifNextRoom = false;
        private bool muted = false;
        private int roll = -1;
        private bool roomDisplayed = true;
        private int roundNumber;
        


        public Game()
        {
            InitializeComponent();

            

            roundNumber = 1;
            Hero hero = new Hero();
            Wheel wheel = new Wheel();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(DispatcherPriority.Send, Dispatcher.CurrentDispatcher);
            dispatcherTimer.Tick += new EventHandler(heroBehaviour);
            dispatcherTimer.Tick += new EventHandler((sender, e) => updateRoll(sender, e, wheel));
            dispatcherTimer.Tick += new EventHandler((sender, e) => updateRoomDisplayed(sender, e, wheel));
            dispatcherTimer.Tick += new EventHandler((sender, e) => afficher_barre_de_vie(sender, e, hero));

            dispatcherTimer.Tick += new EventHandler((sender, e) => afficherCharacteristics(sender, e, hero));
            dispatcherTimer.Tick += new EventHandler((sender, e) => afficherRoue(sender, e, hero, wheel));
            dispatcherTimer.Tick += new EventHandler((sender, e) => afficherRoom(sender, e, hero));
            dispatcherTimer.Tick += new EventHandler((sender, e) => nextRoom(sender, e, hero));
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);

            dispatcherTimer.Start();

            heroHealth.Maximum = hero.GetMaxHealth();
            heroHealth.Value = hero.GetCurrentHealth();
            heroHealthText.Text = "" + hero.GetCurrentHealth() + "/" + hero.GetMaxHealth();



            MXP.URL = "theme.wav";
            MXP.settings.playCount = 9999;
            MXP.controls.play();
        }
        private void sound(object sender, RoutedEventArgs e)
        {
            if (muted)
            {
                son.Source = new BitmapImage(new Uri(@"/Marave;component/images/sound.png", UriKind.Relative));
                muted = false;
                MXP.URL = "theme.wav";
                MXP.settings.playCount = 9999;
                MXP.controls.play();
            }
            else
            {
                son.Source = new BitmapImage(new Uri(@"/Marave;component/images/mute.png", UriKind.Relative));
                muted = true;
                MXP.settings.playCount = 0;
                MXP.controls.stop();
            }
    }
        public void afficherCharacteristics(object sender, EventArgs e, Hero hero)
        {
            if (hero.GetAvailableCharacteristic() > 0 && !frameCharacteristics)
            {
                frameCharacteristics = true;
                Characteristics characteristics = new Characteristics(hero);
                hero.ManageAvailableCharacteristics();

                characteristics.availableCharacteristics.Text = "Points disponibles : " + hero.GetAvailableCharacteristic();
                characteristics.health.Text = "" + hero.GetMaxHealth();
                characteristics.strength.Text = "" + hero.GetStrength();
                characteristics.armor.Text = "" + hero.GetArmor();

                frame.Content = characteristics;
            }
            if (hero.GetAvailableCharacteristic() == 0)
            {
                frameCharacteristics = false;
            }
        }
        public void afficherRoue(object sender, EventArgs e, Hero hero, Wheel wheel)
        {
            if (hero.GetAvailableCharacteristic() == 0 && !frameWheel)
            {
                frameWheel = true;
                wheel.pointerContainer.RenderTransform = new RotateTransform(0);
                wheel.throw_wheel.IsEnabled = true;
                
                this.roll = -1;
                frame.Visibility = Visibility.Visible;
                frame.Content = wheel;
            }
        }

        public void afficherRoom(object sender, EventArgs e, Hero hero)
        {
            if (!roomDisplayed)
            {
                roomDisplayed = true;

                if (this.roll <= 25)
                {
                    Maitre_armes(hero);
                }
                else if (this.roll <= 50)
                {
                    Merlin(hero);
                }
                else
                {
                    Combat(hero);
                }
            }
        }
        private void nextRoom(object sender, EventArgs e, Hero hero)
        {
            if(hero.GetCurrentHealth() > 0)
            {
                if (roundNumber > 20)
                {
                    MessageBox.Show("VICTOIRE");
                    dispatcherTimer.Stop();
                    this.Close();
                }
                else 
                { 
                    if (hero.GetAvailableCharacteristic() == 0 && ifNextRoom)
                    {
                        roundNumber++;
                        ifNextRoom = false;
                        frameCount = 0 + offsetLeft;
                        stateHero = "walk";
                        afficherRoueAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("DEFAITE");
                dispatcherTimer.Stop();
                this.Close();
            }
        }
        public async void afficherRoueAsync()
        {
            await Task.Delay(3000);
            frameWheel = false;
        }

        public void updateRoll(object sender, EventArgs e, Wheel wheel)
        {
            if(frameWheel)
                this.roll = wheel.roll;
            else
                this.roll = -1;
        }
        public void updateRoomDisplayed(object sender, EventArgs e, Wheel wheel)
        {
            this.roomDisplayed = wheel.roomDisplay;
            if(!wheel.roomDisplay)
                wheel.roomDisplay = true;
        }

        public void heroBehaviour(object sender, EventArgs e)
        {
            if(stateHero == "idle")
            {
                heroIdle();
            }
            else if(stateHero == "walk")
            {
                dispatcherTimer.Stop();
                for (int i = 1; i <= 40; i++)
                {
                    heroWalk(i);
                }
                stateHero = "idle";
            }

            frameCount++;
            CommandManager.InvalidateRequerySuggested();
        }


        public void heroIdle()
        {
            hero.Source = new BitmapImage(new Uri(@"images/hero_idle_" + frameCount%10 + ".png", UriKind.Relative)); 
        }
        public async void heroWalk(int i)
        {
            await Task.Delay(50*i);

            TransformGroup transform = new TransformGroup();
            ScaleTransform scale = new ScaleTransform(16, 1);
            TranslateTransform translate = new TranslateTransform(-3.94*offsetLeft, 0);
            transform.Children.Add(scale);
            transform.Children.Add(translate);
            background.Transform = transform;

            hero.Source = new BitmapImage(new Uri(@"images/hero_walk_" + i % 10 + ".png", UriKind.Relative));

            offsetLeft++;

            if(i==40)
            {
                dispatcherTimer.Start();
            }
        }


        
        public void Combat(Hero hero)
        {
            Fight fight = new Fight(hero);

            frameRoom.Content = fight;
            frameRoom.Visibility = Visibility.Visible;
            frame.Visibility = Visibility.Hidden;

            DispatcherTimer dTimer = new DispatcherTimer();
            dTimer = new System.Windows.Threading.DispatcherTimer(DispatcherPriority.Send, Dispatcher.CurrentDispatcher);
            dTimer.Tick += new EventHandler((sender, e) => updateEndFight(sender, e, fight, dTimer));
            dTimer.Interval = TimeSpan.FromMilliseconds(100);
            dTimer.Start();

        }
        public void updateEndFight(object sender, EventArgs e, Fight fight, DispatcherTimer dTimer)
        {
            if(fight.endFight)
            {
                fin_combat(dTimer);
                fight.endFight = false;
            }
        }
        public async void fin_combat(DispatcherTimer dTimer)
        {
            await Task.Delay(1000);
            frameRoom.NavigationService.RemoveBackEntry();
            frameRoom.Visibility = Visibility.Hidden;
            ifNextRoom = true;
            dTimer.Stop();
        }

        public void Maitre_armes(Hero hero)
        {
            MasterOfArms master = new MasterOfArms(hero);
            
            frameRoom.Content = master;
            frameRoom.Visibility = Visibility.Visible;
            string[] insult = master.Insult();
            string text = "Vous rencontrez le Maître d'armes !\nIl vous crie : \"" + insult[0] + "\"\n\nSuite à ce fabuleux entraînement, vous prenez un niveau.\nVous êtes soigné de 10% de vos points de vie actuels et gagnez 3 points de caractéristiques.";
            for (int i = 0; i < text.Length; i++)
            {
                afficher_text_maitre(i, text[i], master);
            }
            SoundPlayer player = new SoundPlayer(@"..\..\..\audio\maitre\maitre" + insult[1] + ".wav");
            player.Play();

            fin_maitre(text.Length, master, hero, player);
        }
        public async void afficher_text_maitre(int i, char letter, MasterOfArms master)
        {
            await Task.Delay(50 * i);
            master.texte_maitre.Text += letter;
        }
        public async void fin_maitre(int i, MasterOfArms master, Hero hero, SoundPlayer player)
        {
            await Task.Delay(50 * i + 1000);
            player.Stop();
            master.LevelUp(hero);
            await Task.Delay(1000);
            frameRoom.NavigationService.RemoveBackEntry();
            frameRoom.Visibility = Visibility.Hidden;
            ifNextRoom = true;
        }



        public void Merlin(Hero hero)
        {
            Merlin merlin = new Merlin(hero);
            frameRoom.Content = merlin;
            frameRoom.Visibility = Visibility.Visible;


            string text = "Vous rencontrez Merlin ! Il restaure toute votre vie actuelle. Vous avez de la chance !";
            for(int i = 0; i < text.Length; i++)
            {
                afficher_text_merlin(i, text[i], merlin);
            }
            soin_merlin(text.Length, merlin);

            fin_merlin(text.Length);
        }
        public async void soin_merlin(int i, Merlin merlin)
        {
            await Task.Delay(50 * i);
            merlin.Heal();
        }
        public async void fin_merlin(int i)
        {
            await Task.Delay(50 * i + 1000);
            frameRoom.NavigationService.RemoveBackEntry();
            frameRoom.Visibility = Visibility.Hidden;
            roll = -1;
            ifNextRoom = true;
            frame.Content = null;
        }
        public async void afficher_text_merlin(int i, char letter, Merlin merlin)
        {
            await Task.Delay(50 * i);
            merlin.texte_merlin.Text += letter;
            frameRoom.Content = merlin;
            frameRoom.Visibility = Visibility.Visible;
        }
        public void afficher_barre_de_vie(object sender, EventArgs e, Hero hero)
        {
            heroHealth.Maximum = hero.GetMaxHealth();
            heroHealth.Value = hero.GetCurrentHealth();
            heroHealthText.Text = "" + hero.GetCurrentHealth() + "/" + hero.GetMaxHealth();
        }


        public void Win()
        {
            Console.WriteLine("Vous avez gagné !");
        }
        public void Lose()
        {
            Console.WriteLine("Vous êtes mort. Fin du jeu.");
        }

        private void frameRoom_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

    }
}
