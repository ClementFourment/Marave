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

namespace Marave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NavigationWindow window = new NavigationWindow();

        private void Play(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            this.Visibility = Visibility.Hidden;
            game.ShowDialog();
            game.Close();
            this.Visibility = Visibility.Visible;
            game.MXP.controls.pause();
        }

        private void Leave(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void closeWindow(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
