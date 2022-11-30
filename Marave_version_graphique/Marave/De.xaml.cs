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
    /// Logique d'interaction pour De.xaml
    /// </summary>
    public partial class De : Page
    {
        public int roll = -1;
        public De()
        {
            InitializeComponent();
        }

        private void throwWheelRoom(object sender, RoutedEventArgs e)
        {
            throw_dice.IsEnabled = false;
            Randomizer random = new Randomizer(); 
            int roll = random.ThrowDice();
            int nb = 100 * (11 + roll);
            for(int i = 1; i <= nb; i++)
            {
                scrollDice(i);
            }
            endDice(nb, roll);
        }

        private async void scrollDice(int i)
        {
            await Task.Delay((int)(i * i)/800);
            de.Margin = new Thickness(0, -5-i, 0, 0);
        }
        private async void endDice(int i, int roll)
        {
            await Task.Delay((int)(i * i) / 800 + 500);
            this.roll = roll;
            await Task.Delay(1000);
            de.Margin = new Thickness(0, -3, 0, 0);
        }
    }
}
