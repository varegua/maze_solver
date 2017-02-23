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
    /// Logique d'interaction pour GameEnd.xaml
    /// </summary>
    public partial class GameEnd : Page
    {
        private GameClient gameClient;
        private PlayerGame playerGame;

        public GameEnd()
        {
            InitializeComponent();
        }

        public GameEnd(GameClient gameClient, PlayerGame playerGame)
        {
            this.gameClient = gameClient;
            this.playerGame = playerGame;
            InitializeComponent();
            InitPage();
        }

        private void InitPage()
        {
            HideNextLevel();
            EditResult();
        }

        private void btnNextLevel_Click(object sender, RoutedEventArgs e)
        {
            Difficulty difficulty = getNextDifficulty(playerGame);
            String playerName = this.playerGame.Player.Name;
            GamePage page = new GamePage(playerName, difficulty);
            this.NavigationService.Navigate(page);
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            this.gameClient.ResetGame(this.playerGame.Key);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            GameAccueil page = new GameAccueil();
            this.NavigationService.Navigate(page);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void EditResult()
        {
            lblResult.Content = "You finish in "  + this.playerGame.Player.FinishTime + "and " + this.playerGame.Player.NbMove + " moves.\n";
        }

        private Difficulty getNextDifficulty(PlayerGame playerGame)
        {
            switch (playerGame.Difficulty)
            {
                case Difficulty.Easy:
                    return Difficulty.Medium;
                case Difficulty.Medium:
                    return Difficulty.Hard;
                case Difficulty.Hard:
                    return Difficulty.Extreme;
                default:
                    return Difficulty.Extreme;
            }
        }

        private void HideNextLevel()
        {
            if (playerGame.Difficulty.Equals(Difficulty.Extreme))
            {
                btnNextLevel.Visibility = Visibility.Hidden;
            }
        }
    }
}
