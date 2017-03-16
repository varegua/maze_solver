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

    public partial class JoinExistingGamePage : Page
    {
        public JoinExistingGamePage()
        {
            InitializeComponent();
        }

        private void btnSeeExistingGame_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://ingesup-maze.azurewebsites.net/");
        }

        private void btnJoinGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String gameKey = tBGameKey.Text;
                String name = tBPseudo.Text;
                GamePage page = new GamePage(gameKey, name);
                this.NavigationService.Navigate(page);
            }
            catch (System.ServiceModel.FaultException exception)
            {
                MessageBox.Show(exception.Message + "\n Le nom du joueur n'est pas correct, veuillez en entrer un d'au moins 3 caractères.");
                return;
            }
        }
    }
}
