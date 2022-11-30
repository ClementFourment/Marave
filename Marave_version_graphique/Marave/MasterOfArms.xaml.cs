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
    /// Logique d'interaction pour MasterOfArms.xaml
    /// </summary>
    public partial class MasterOfArms : Page
    {
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Hero h = new Hero();
        private int frameCount = 0;
        public MasterOfArms(Hero hero)
        {
            InitializeComponent();
            this.h = hero;

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer(DispatcherPriority.Send, Dispatcher.CurrentDispatcher);
            dispatcherTimer.Tick += new EventHandler(heroBehaviour);
            dispatcherTimer.Tick += new EventHandler(masterBehaviour);
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
        public void masterBehaviour(object sender, EventArgs e)
        {
            if ((frameCount + 20) % 40 > 20)
            {
                maitre.Source = new BitmapImage(new Uri(@"images/maitre_1.png", UriKind.Relative));
            }
            else
            {
                maitre.Source = new BitmapImage(new Uri(@"images/maitre_2.png", UriKind.Relative));
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
        public int LevelUp(Hero hero)
        {
            hero.SetLevel(hero.GetLevel() + 1);
            hero.AddAvailableCharacteristic(3);
            hero.ManageAvailableCharacteristics();
            hero.SetCurrentHealth((int)Math.Round(hero.GetCurrentHealth() * 1.1));
            if (hero.GetCurrentHealth() > hero.GetMaxHealth())
            {
                hero.SetCurrentHealth(hero.GetMaxHealth());
            }
            return hero.GetLevel();
        }

        public string[] Insult()
        {
            Randomizer random = new Randomizer();


            string[] insults = {
                "En garde, espèce de vieille pute dégarnie !",
                "HAHA, Sire ! Je vous attends ! À moins que vous préfériez que l’on dise partout que le roi est une petite pédale qui pisse dans son froc à l’idée de se battre !",
                "Du nerf, mon lapinou !… Vous allez vous faire tailler le zizi en pointe !",
                "En garde, ma biquette ! Je vais vous découper le gras du cul, ça vous fera ça de moins à trimbaler !",
                "Mon père est peut-être unijambiste, mais moi, ma femme n'a pas de moustache ! Alors ça vient? p'tite bite !",
                "Allez en garde espèce de p'tite couille molle !",
                "Allez en garde grosse conne !",
                "C'est pas l'tout d'avoir une épée magique pas vrai? Encore faut-il savoir s'en servir !",
                "J'ai l'impression d'me battre contre une vieille...",
                "Montrez-moi ce que vous avez dans le slibard, p'tite pucelle !"
            };
            int nb = random.GetInsult();
            string[] res = {insults[nb], "" + nb};
            return res;
        }
    }
}
