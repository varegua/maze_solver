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
           difficultyLabel.Content += game.difficulty.ToString();
           nbMoveValue.Content = game.player.NbMove;
           playerNameLabel.Content += game.player.Name;
           DisplayPlayerPossibilities(game.player);
           InitWindows();
           InitGameCanvas();
        }

        private void InitWindows()
        {
            this.WindowHeight = 70 + game.playerGame.Maze.Height * 31;
            this.WindowWidth = 100 + game.playerGame.Maze.Width * 31;
        }

        private void InitGameCanvas()
        {
            gameCanvas.Width = game.playerGame.Maze.Width * 30;
            gameCanvas.Height = game.playerGame.Maze.Height * 30;
            personnage.Margin = new Thickness(game.player.CurrentPosition.X * 30, game.player.CurrentPosition.Y * 30, 0, 0);
            addImage(60, 60, "ver");
            gameCanvas.IsHitTestVisible = false;
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                doMovePlayer(game.playerGame, game.player, Direction.Up);
            }
            else if (e.Key == Key.Right)
            {
                doMovePlayer(game.playerGame, game.player, Direction.Right);
            }
            else if (e.Key == Key.Left)
            {
                doMovePlayer(game.playerGame, game.player, Direction.Left);
            }
            else if (e.Key == Key.Down)
            {
                doMovePlayer(game.playerGame, game.player, Direction.Down);
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
                game.player = game.gameClient.MovePlayer(playerGame.Key, player.Key, dir);
                Position currentPosition = game.player.CurrentPosition;
                personnage.Margin = new Thickness(currentPosition.X * 30, currentPosition.Y * 30, 0, 0);
                nbMoveValue.Content = game.GetNbMoves();
            }
            catch (System.ServiceModel.FaultException e)
            {
                MessageBox.Show(e.Message);
            }
            FinishGame();
            DisplayPlayerPossibilities(game.player);
            this.Focus();
        }

        private void DisplayPlayerPossibilities(Player player)
        {
            Position currentPlayerPosition = player.CurrentPosition;
            Cell[] visibleCells = player.VisibleCells;
            foreach (Cell cell in visibleCells)
            {
                CellPossibility(cell, currentPlayerPosition);
            }
        }

        private void CellPossibility(Cell cell, Position playerPosition)
        {
            switch (cell.CellType)
            {
                case CellType.End:
                    GetPossibleDirection(cell.Position, playerPosition, "end");
                    break;
                case CellType.Empty:
                    GetPossibleDirection(cell.Position, playerPosition, "empty");
                    break;
                case CellType.Start:
                    GetPossibleDirection(cell.Position, playerPosition, "start");
                    break;
                case CellType.Wall:
                    GetPossibleDirection(cell.Position, playerPosition, "wall");
                    break;
                default:
                    break;
            }

        }

        private String GetPossibleDirection(Position position, Position playerPosition, String name)
        {
            String strPossibleDirection = "";
            //droite
            if (position.X > playerPosition.X && position.Y == playerPosition.Y)
            {
                if (name == "empty")
                    addImage(position.X, position.Y, "hor");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }

            //gauche
            else if (position.X < playerPosition.X && position.Y == playerPosition.Y)
            {
                if (name == "empty")
                        addImage(position.X, position.Y, "hor");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }
            //bas
            else if (position.Y > playerPosition.Y && position.X == playerPosition.X)
            {
                if (name == "empty")
                    addImage(position.X, position.Y, "ver");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }
            //haut
            else if (position.Y < playerPosition.Y && position.X == playerPosition.X)
            {
                if (name == "empty")
                    addImage(position.X, position.Y, "ver");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }

            //droite haut
            if (position.X > playerPosition.X && position.Y < playerPosition.Y)
            {
                if (name == "empty")
                    addImage(position.X, position.Y, "hor");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }

            //droite bas
            if (position.X > playerPosition.X && position.Y > playerPosition.Y)
            {
                if (name == "empty")
                    addImage(position.X, position.Y, "hor");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }

            //gauche haut
            if (position.X < playerPosition.X && position.Y < playerPosition.Y)
            {
                if (name == "empty")
                    addImage(position.X, position.Y, "hor");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }

            //gauche bas
            if (position.X < playerPosition.X && position.Y > playerPosition.Y)
            {
                if (name == "empty")
                    addImage(position.X, position.Y, "hor");
                else if (name == "start")
                    addImage(position.X, position.Y, "start");
                else if (name == "end")
                    addImage(position.X, position.Y, "end");
                else if (name == "wall")
                    addImage(position.X, position.Y, "wall");
            }

            return strPossibleDirection;
        }

        private void FinishGame()
        {
            if (game.player.FinishTime != null)
            {
                MessageBox.Show("You finish in " + game.player.FinishTime + "\n " + game.player.SecretMessage);
                GameEnd page = new GameEnd(game.gameClient, game.playerGame, game.player);
                this.NavigationService.Navigate(page);
            }

        }

        BitmapImage cheminBitmapHor = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_hor.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapVer = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_ver.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapWall = new BitmapImage(new Uri("pack://application:,,,/Img/Wall.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapStart = new BitmapImage(new Uri("pack://application:,,,/Img/Start.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapEnd = new BitmapImage(new Uri("pack://application:,,,/Img/End.jpg", UriKind.RelativeOrAbsolute));
        int imageSize = 30;

        private void addImage(int X, int Y, String typeImg)
        {
            Image cheminImage = new Image();
            switch (typeImg)
            {
                case "hor":
                    cheminImage.Source = cheminBitmapHor;
                    break;
                case "ver":
                    cheminImage.Source = cheminBitmapVer;
                    break;
                case "wall":
                    cheminImage.Source = cheminBitmapWall;
                    break;
                case "start":
                    cheminImage.Source = cheminBitmapStart;
                    break;
                case "end":
                    cheminImage.Source = cheminBitmapEnd;
                    break;
                default:
                    break;
            }

            cheminImage.Width = imageSize;
            cheminImage.Height = imageSize;
            Canvas.SetLeft(cheminImage, X * imageSize);
            Canvas.SetTop(cheminImage, Y * imageSize);
            gameCanvas.Children.Add(cheminImage);
        }

    }
}
