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
    /// Logique d'interaction pour GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Difficulty difficulty;
        private String name;
        private GameClient gameClient;
        private PlayerGame playerGame;
        private Player player;
        private Position currentPosition;

        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(string name, Difficulty difficulty)
        {
            this.ShowsNavigationUI = false;
            this.name = name;
            this.difficulty = difficulty;
            InitializeComponent();
            InitializeGame();
            this.Focus();
        }

        public GamePage(string name, Difficulty difficulty, GameClient gameClient, PlayerGame playerGame) : this(name, difficulty)
        {
            this.gameClient = gameClient;
            Game game = this.gameClient.ResetGame(playerGame.Key);

        }

        private void InitializeGame()
        {
            this.gameClient = new GameClient("BasicHttpBinding_IGame");
            this.playerGame = gameClient.CreateGame(this.difficulty, this.name);
            this.player = playerGame.Player;
            this.currentPosition = player.CurrentPosition;
            difficultyLabel.Content += this.difficulty.ToString();
            nbMoveValue.Content = player.NbMove;
            playerNameLabel.Content += player.Name;
            refreshPlayerPossibilities(player);
            InitGameCanvas();
        }

        private void InitGameCanvas()
        {
            gameCanvas.Width = playerGame.Maze.Width * 30;
            gameCanvas.Height = playerGame.Maze.Height * 30;
            personnage.Margin = new Thickness(currentPosition.X * 30, currentPosition.Y * 30, 0, 0);
            addImage(60, 60);
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                doMovePlayer(this.playerGame, this.player, Direction.Up);
            }
            else if (e.Key == Key.Right)
            {
                doMovePlayer(this.playerGame, this.player, Direction.Right);
            }
            else if (e.Key == Key.Left)
            {
                doMovePlayer(this.playerGame, this.player, Direction.Left);
            }
            else if (e.Key == Key.Down)
            {
                doMovePlayer(this.playerGame, this.player, Direction.Down);
            }
            refreshPlayerPossibilities(this.player);
        }

        private void doMovePlayer(PlayerGame playerGame, Player player, Direction dir)
        {
            try
            {
                this.player = this.gameClient.MovePlayer(playerGame.Key, player.Key, dir);
                this.currentPosition = this.player.CurrentPosition;
                personnage.Margin = new Thickness(currentPosition.X * 30, currentPosition.Y * 30, 0, 0);
                nbMoveValue.Content = player.NbMove;
            }
            catch (System.ServiceModel.FaultException e)
            {
                MessageBox.Show(e.Message);
            }
            FinishGame();
            refreshPlayerPossibilities(this.player);
            if (!this.IsFocused)
            {
                this.Focus();
            }
        }

        private void refreshPlayerPossibilities(Player player)
        {
            Position currentPlayerPosition = player.CurrentPosition;
            Cell[] visibleCells = player.VisibleCells;
            String possibility = "";
            foreach (Cell cell in visibleCells)
            {
                possibility += CellPossibility(cell, currentPlayerPosition);
            }
        }

        private String CellPossibility(Cell cell, Position playerPosition)
        {
            String strPossibility = "";
            switch (cell.CellType)
            {
                case CellType.End:
                    strPossibility = "Sortie en " + cell.Position.X + ", " + cell.Position.Y + "\n";
                    strPossibility += GetPossibleDirection(cell.Position, playerPosition);
                    break;
                case CellType.Empty:
                    strPossibility = GetPossibleDirection(cell.Position, playerPosition);
                    break;
                case CellType.Start:
                    strPossibility = "Case départ en " + cell.Position.X + ", " + cell.Position.Y + "\n";
                    strPossibility += GetPossibleDirection(cell.Position, playerPosition);
                    break;
                default:
                    break;
            }

            return strPossibility;
        }

        private String GetPossibleDirection(Position position, Position playerPosition)
        {
            String strPossibleDirection = "";
            //droite
            if (position.X > playerPosition.X && position.Y == playerPosition.Y)
            {
                addImage(position.X, position.Y);
            }
            //gauche
            else if (position.X < playerPosition.X && position.Y == playerPosition.Y)
            {
                addImage(position.X, position.Y);
            }
            //bas
            else if (position.Y > playerPosition.Y && position.X == playerPosition.X)
            {
                addImage(position.X, position.Y);
            }
            //haut
            else if (position.Y < playerPosition.Y && position.X == playerPosition.X)
            {
                addImage(position.X, position.Y);
            }
            return strPossibleDirection;
        }

        private void FinishGame()
        {
            if (this.player.FinishTime != null)
            {
                MessageBox.Show("You finish in " + this.player.FinishTime);
                GameEnd page = new GameEnd(gameClient, playerGame);
                this.NavigationService.Navigate(page);
            }

        }

        BitmapImage cheminBitmap = new BitmapImage(new Uri("pack://application:,,,/Img/chemin.jpg", UriKind.RelativeOrAbsolute));

        private void addImage(int X, int Y)
        {
            Image cheminImage = new Image();
            cheminImage.Source = cheminBitmap;
            cheminImage.Width = 30;
            cheminImage.Height = 30;
            Canvas.SetLeft(cheminImage, X*30);
            Canvas.SetTop(cheminImage, Y*30);
            gameCanvas.Children.Add(cheminImage);
        }
    }
}
