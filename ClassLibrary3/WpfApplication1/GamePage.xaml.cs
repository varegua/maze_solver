using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MazeSolver.Client.Core.mazeSolverService;
using MazeSolver.Client.Core;
using System.Threading;
using System.Windows.Threading;

namespace MazeSolver.Client.Wpf
{
    /// <summary>
    /// Logique d'interaction pour GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {

        private Play game;
        private ManageImages manageImage;

        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(string name, Difficulty difficulty)
        {
            this.game = new Play(name, difficulty);
            this.manageImage = new ManageImages(this);
            InitializeComponent();
            InitializeGame();
        }

        public GamePage(string name, string gameKey)
        {
            this.game = new Play(name, gameKey);
            this.manageImage = new ManageImages(this);
            InitializeComponent();
            InitializeGame();
        }

        /* public GamePage(string name, Difficulty difficulty, GameClient gameClient, PlayerGame playerGame) : this(name, difficulty)
         {
             this.gameClient = gameClient;
             Game game = this.gameClient.ResetGame(playerGame.Key);

         }*/

        private void InitializeGame()
        {
            InitWindows();
            manageImage.InitializeLabelGame(game);
            manageImage.DisplayPlayerPossibilities(game.player);
            manageImage.InitGameCanvas(game);
        }

        private void InitWindows()
        {
            this.WindowHeight = 70 + this.game.playerGame.Maze.Height * 31;
            this.WindowWidth = 100 + this.game.playerGame.Maze.Width * 31;
            this.ShowsNavigationUI = false;
            this.Focus();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    MovePlayerOnMaze(Direction.Up);
                    break;
                case Key.Right:
                    MovePlayerOnMaze(Direction.Right);
                    break;
                case Key.Down:
                    MovePlayerOnMaze(Direction.Down);
                    break;
                case Key.Left:
                    MovePlayerOnMaze(Direction.Left);
                    break;
                case Key.Space:
                    PlayBotVisually();
                    break;
                default:
                    break;
            }
        }

        private void MovePlayerOnMaze(Direction dir)
        {
            try
            {
                game.DoMovePlayer(dir);
                manageImage.MovePlayerImage(game.player);
            }
            catch (System.ServiceModel.FaultException e)
            {
                MessageBox.Show(e.Message);
            }
            manageImage.DisplayPlayerPossibilities(this.game.player);
            if (game.IsFinishGame())
            {
                ManageImages.DisplayFinishPage(this, game);
            }
            this.Focus();
        }
        
        private void PlayBotVisually()
        {
            while (!game.IsFinishGame())
            {
                game.DoMovePlayer(game.bot.FindBestDirection(game.player));
                manageImage.MovePlayerImage(game.player);
                manageImage.DisplayPlayerPossibilities(this.game.player);
                Thread.Sleep(500);
            }
            ManageImages.DisplayFinishPage(this, game);
        }
    }
}