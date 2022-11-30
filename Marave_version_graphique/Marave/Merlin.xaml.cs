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
    /// Logique d'interaction pour Merlin.xaml
    /// </summary>
    public partial class Merlin : Page
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Hero h = new Hero();
        private int frameCount = 0;
        
        public Merlin(Hero hero)
        {
            this.h = hero;
            InitializeComponent();
            

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(DispatcherPriority.Send, Dispatcher.CurrentDispatcher);
            dispatcherTimer.Tick += new EventHandler(heroBehaviour);
            dispatcherTimer.Tick += new EventHandler(merlinBehaviour);
            dispatcherTimer.Tick += new EventHandler((sender, e) => afficher_barre_de_vie(sender, e, h));
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);

            dispatcherTimer.Start();
            heroHealth.Maximum = h.GetMaxHealth();
            heroHealth.Value = h.GetCurrentHealth();
            heroHealthText.Text = "" + h.GetCurrentHealth() + "/" + h.GetMaxHealth();
        }

        public void afficher_barre_de_vie(object sender, EventArgs e, Hero hero)
        {
            heroHealth.Maximum = hero.GetMaxHealth();
            heroHealth.Value = hero.GetCurrentHealth();
            heroHealthText.Text = "" + hero.GetCurrentHealth() + "/" + hero.GetMaxHealth();
        }
        public void heroBehaviour(object sender, EventArgs e)
        {
            
            hero.Source = new BitmapImage(new Uri(@"images/hero_idle_" + frameCount % 10 + ".png", UriKind.Relative));
            frameCount++;
            CommandManager.InvalidateRequerySuggested();

        }
        public void merlinBehaviour(object sender, EventArgs e)
        {
            if ((frameCount + 20) % 40 > 20)
            {
                merlin.Source = new BitmapImage(new Uri(@"images/merlin_1.png", UriKind.Relative));
            }
            else
            {
                merlin.Source = new BitmapImage(new Uri(@"images/merlin_2.png", UriKind.Relative));
            }

            frameCount++;
            CommandManager.InvalidateRequerySuggested();
        }
        public bool CheckEndGame(Hero hero, int roundNumber)
        {
            if (roundNumber >= 20 || hero.IsDead())
            {
                return false;
            }
            return true;
        }

        public void Heal()
        {
            int heal;
            heal = this.h.GetMaxHealth() - this.h.GetCurrentHealth();
            this.h.SetCurrentHealth(this.h.GetMaxHealth());
        }
    }
}
