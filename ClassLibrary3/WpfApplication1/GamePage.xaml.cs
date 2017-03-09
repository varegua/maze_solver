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
using System.Threading;
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

            public GamePage(string name, Difficulty difficulty, GameClient gameClient, PlayerGame playerGame) : this(name, difficulty)
            {
                this.game.gameClient = gameClient;
                Game game = this.game.gameClient.ResetGame(playerGame.Key);

            }

            private void InitializeGame()
            {
                difficultyLabel.Content += this.game.difficulty.ToString();
                nbMoveValue.Content = game.player.NbMove;
                playerNameLabel.Content += game.player.Name;
                ManageImages.DisplayPlayerPossibilities(game.player, gameCanvas);
                InitWindows();
                InitGameCanvas();
            }

            private void InitWindows()
            {
                this.WindowHeight = 70 + this.game.playerGame.Maze.Height * 31;
                this.WindowWidth = 100 + this.game.playerGame.Maze.Width * 31;
            }


            private void InitGameCanvas()
            {
                gameCanvas.Width = game.playerGame.Maze.Width * 30;
                gameCanvas.Height = game.playerGame.Maze.Height * 30;
                personnage.Margin = new Thickness(game.currentPosition.X * 30, game.currentPosition.Y * 30, 0, 0);
                gameCanvas.IsHitTestVisible = false;
            }

            private void Page_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Up)
                {
                    doMovePlayer(this.game.playerGame, this.game.player, Direction.Up);
                }
                else if (e.Key == Key.Right)
                {
                    doMovePlayer(this.game.layerGame, this.game.player, Direction.Right);
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
                    PlayBot();
                    return;
                }
            }

            private void doMovePlayer(PlayerGame playerGame, Player player, Direction dir)
            {
                try
                {
                    this.game.player = this.game.gameClient.MovePlayer(playerGame.Key, player.Key, dir);
                    this.game.currentPosition = this.game.player.CurrentPosition;
                    personnage.Margin = new Thickness(game.currentPosition.X * 30, game.currentPosition.Y * 30, 0, 0);
                    nbMoveValue.Content = this.game.player.NbMove;

                }
                catch (System.ServiceModel.FaultException e)
                {
                    MessageBox.Show(e.Message);
                }
                FinishGame();
                ManageImages.DisplayPlayerPossibilities(this.game.player, gameCanvas);
                if (!this.IsFocused)
                {
                    this.Focus();
                }
            }



            private void FinishGame()
            {
                if (this.game.player.FinishTime != null)
                {
                    MessageBox.Show("You finish in " + this.game.player.FinishTime + "\n " + this.game.player.SecretMessage);
                    GameEnd page = new GameEnd(game.gameClient, game.playerGame, this.game.player);
                    this.NavigationService.Navigate(page);
                }

            }

            private void PlayBot()
            {
                Direction dir;
                while (this.game.player.FinishTime == null)
                {
                    dir = this.game.bot.SelectBestDirection(this.game.player);
                    doMovePlayer(game.playerGame, this.game.player, dir);
                    Console.WriteLine("position X: " + this.game.player.CurrentPosition.X + " Y: " + this.game.player.CurrentPosition.Y);
                    Thread.Sleep(500);
                }

            }

        }
    }