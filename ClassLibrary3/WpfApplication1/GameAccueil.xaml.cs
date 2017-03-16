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

namespace MazeSolver.Client.Wpf
{
    /// <summary>
    /// Logique d'interaction pour GameAccueil.xaml
    /// </summary>
    public partial class GameAccueil : Page
    {
        public GameAccueil()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            StartGamePage page = new StartGamePage();
            this.NavigationService.Navigate(page);
        }

        private void btnRejoin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
