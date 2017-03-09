using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ClassLibrary3.mazeSolverService;
using MazeSolver.Client.Core;

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
                difficultyLabel.Content += this.game.difficulty.ToString();
                nbMoveValue.Content = game.player.NbMove;
                playerNameLabel.Content += game.player.Name;
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
                if (e.Key == Key.Up)
                {
                    doMovePlayer(this.game.playerGame, this.game.player, Direction.Up);
                }
                else if (e.Key == Key.Right)
                {
                    doMovePlayer(this.game.playerGame, this.game.player, Direction.Right);
                }
                else if (e.Key == Key.Left)
                {
                    doMovePlayer(this.game.playerGame, this.game.player, Direction.Left);
                }
                else if (e.Key == Key.Down)
                {
                    doMovePlayer(this.game.playerGame, this.game.player, Direction.Down);
                }
                else
                {
                    game.PlayBot();
                    return;
                }
            }

            private void doMovePlayer(PlayerGame playerGame, Player player, Direction dir)
            {
                try
                {
                    this.game.player = this.game.gameClient.MovePlayer(playerGame.Key, player.Key, dir);
                    this.game.player.CurrentPosition = this.game.player.CurrentPosition;
                    ManageImages.MovePlayerImage(game, gameCanvas);
                    nbMoveValue.Content = this.game.player.NbMove;

                }
                catch (System.ServiceModel.FaultException e)
                {
                    MessageBox.Show(e.Message);
                }
                ManageImages.DisplayPlayerPossibilities(this.game.player, gameCanvas);
                this.Focus();
            }


        }
    }