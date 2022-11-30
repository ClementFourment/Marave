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
using Marave.classes;

namespace Marave
{
    /// <summary>
    /// Logique d'interaction pour Characteristics.xaml
    /// </summary>
    public partial class Characteristics : Page
    {
        Hero hero = new Hero();
        public Characteristics(Hero hero)
        {
            InitializeComponent();
            this.hero = hero;

        }

        private void addHealth_Click(object sender, RoutedEventArgs e)
        {
            hero.AddHealth();
            availableCharacteristics.Text = "Points disponibles : " + hero.GetAvailableCharacteristic();
            health.Text = "" + hero.GetMaxHealth();

            if (hero.GetAvailableCharacteristic() <= 0)
            {
                this.NavigationService.RemoveBackEntry();
                this.Visibility = Visibility.Hidden;
            }
            
        }

        private void addStrength_Click(object sender, RoutedEventArgs e)
        {
            hero.AddStrength();
            availableCharacteristics.Text = "Points disponibles : " + hero.GetAvailableCharacteristic();
            strength.Text = "" + hero.GetStrength();

            if (hero.GetAvailableCharacteristic() <= 0)
            {
                this.NavigationService.RemoveBackEntry();
                this.Visibility = Visibility.Hidden;
            }

        }

        private void addArmor_Click(object sender, RoutedEventArgs e)
        {
            hero.AddArmor();
            availableCharacteristics.Text = "Points disponibles : " + hero.GetAvailableCharacteristic();
            armor.Text = "" + hero.GetArmor();

            if (hero.GetAvailableCharacteristic() <= 0)
            {
                this.NavigationService.RemoveBackEntry();
                this.Visibility = Visibility.Hidden;
            }
        }
    }
}
