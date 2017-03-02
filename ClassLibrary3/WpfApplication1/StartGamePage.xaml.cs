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

namespace WpfApplication1
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
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Difficulty difficulty =(Difficulty) cBDifficulty.SelectedItem;
            String name = tBPseudo.Text;
            GamePage page = new GamePage(name, difficulty);
            this.NavigationService.Navigate(page);
        }
    }
}
