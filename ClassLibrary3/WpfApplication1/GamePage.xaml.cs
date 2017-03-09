using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ClassLibrary3.mazeSolverService;
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

        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(string name, Difficulty difficulty)
        {
            this.game = new Play(name, difficulty);
            InitializeComponent();
            InitializeGame();
            this.Focus();
            this.ShowsNavigationUI = false;
        }

        /* public GamePage(string name, Difficulty difficulty, GameClient gameClient, PlayerGame playerGame) : this(name, difficulty)
         {
             this.gameClient = gameClient;
             Game game = this.gameClient.ResetGame(playerGame.Key);

         }*/

        private void InitializeGame()
        {
            ManageImages.InitializeLabelGame(game, difficultyLabel, playerNameLabel, nbMoveValue);
            ManageImages.DisplayPlayerPossibilities(game.player, gameCanvas);
            InitWindows();
            ManageImages.InitGameCanvas(gameCanvas, game);
        }

        private void InitWindows()
        {
            this.WindowHeight = 70 + this.game.playerGame.Maze.Height * 31;
            this.WindowWidth = 100 + this.game.playerGame.Maze.Width * 31;
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
                    if (game.PlayBot())
                    {
                        ManageImages.DisplayFinishPage(this, game);
                    }
                    break;
            }
        }

        private void MovePlayerOnMaze(Direction dir)
        {
            try
            {
                game.DoMovePlayer(dir);
                ManageImages.MovePlayerImage(game.player, personnage, nbMoveValue);
            }
            catch (System.ServiceModel.FaultException e)
            {
                MessageBox.Show(e.Message);
            }
            ManageImages.DisplayPlayerPossibilities(this.game.player, gameCanvas);
            if (game.IsFinishGame())
            {
                ManageImages.DisplayFinishPage(this, game);
            }
            this.Focus();
        }
        
        private void PlayBotVisually()
        {
              Action EmptyDelegate = delegate () { };

            while (!game.IsFinishGame())
            {
                game.DoMovePlayer(game.bot.FindBestDirection(game.player));
                ManageImages.UpdateMazeImages(gameCanvas, game.player, personnage, nbMoveLabel);
                for (int i = 0; i < gameCanvas.Children.Count; i++)
                    gameCanvas.Children[i].InvalidateVisual();
                Thread.Sleep(500);
            }
            ManageImages.DisplayFinishPage(this, game);
        }
    }
}