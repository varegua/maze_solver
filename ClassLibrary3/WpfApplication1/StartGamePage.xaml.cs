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
using ClassLibrary3.mazeSolverService;

namespace MazeSolver.Client.Wpf
{
    /// <summary>
    /// Logique d'interaction pour StartGamePage.xaml
    /// </summary>
    public partial class StartGamePage : Page
    {
        public StartGamePage()
        {
            InitializeComponent();

            foreach(var difficulty in Enum.GetValues(typeof(Difficulty)))
            {
                cBDifficulty.Items.Add(difficulty);
            }
            cBDifficulty.SelectedItem = cBDifficulty.Items.GetItemAt(0);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Difficulty difficulty = (Difficulty)cBDifficulty.SelectedItem;
                String name = tBPseudo.Text;
                GamePage page = new GamePage(name, difficulty);
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
