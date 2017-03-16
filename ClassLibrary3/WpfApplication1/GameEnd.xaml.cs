using System;
using System.Windows;
using System.Windows.Controls;
using MazeSolver.Client.Core.mazeSolverService;

namespace MazeSolver.Client.Wpf
{

    public partial class GameEnd : Page
    {
        private GameClient gameClient;
        private PlayerGame playerGame;
        private Player player;

        public GameEnd()
        {
            InitializeComponent();
        }

        public GameEnd(GameClient gameClient, PlayerGame playerGame, Player player)
        {
            this.gameClient = gameClient;
            this.playerGame = playerGame;
            this.player = player;
            InitializeComponent();
            InitPage();
        }

        private void InitPage()
        {
            HideNextLevelButton();
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
            String playerName = this.playerGame.Player.Name;
           // GamePage page = new GamePage(playerName, playerGame.Difficulty, gameClient);
           // this.NavigationService.Navigate(page);
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
            if(this.player.SecretMessage != null)
            {
                lblResult.Content = "Secret Message : " + this.player.SecretMessage + "\n";
            }
            lblResult.Content = "You finish in "  + this.player.FinishTime + " and " + this.player.NbMove + " moves.\n";
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

        /*
         * Si on est au dernier niveau, cache le bouton "Next Level"
         */ 
        private void HideNextLevelButton()
        {
            if (playerGame.Difficulty.Equals(Difficulty.Extreme))
            {
                btnNextLevel.Visibility = Visibility.Hidden;
            }
        }
    }
}
