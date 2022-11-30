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
    /// Logique d'interaction pour Wheel.xaml
    /// </summary>
    public partial class Wheel : Page
    {
        public int roll = -1;
        public bool frameWheel = false;
        public bool roomDisplay = true;
        public Wheel()
        {
            InitializeComponent();
        }

        private void throwWheelRoom(object sender, RoutedEventArgs e)
        {
            Randomizer random = new Randomizer();
            int roll = random.GetPercentageToCreateRoom();
            int roll_modified = (int) (roll * 3.6);

            for (int i = 1; i <= 90 + roll_modified; i++)
            {
                rollPointer(i);
            }
            endWheel(90 + roll_modified, roll);
            throw_wheel.IsEnabled = false;
        }
        private async void rollPointer(int i)
        {
            await Task.Delay(5 * i);
            pointerContainer.RenderTransform = new RotateTransform(i);
        }
        private async void endWheel(int i, int roll)
        {
            await Task.Delay(5*i + 500);
            this.roll = roll;
            this.NavigationService.RemoveBackEntry();
            frameWheel = false;
            roomDisplay = false;
        }
    }
}
