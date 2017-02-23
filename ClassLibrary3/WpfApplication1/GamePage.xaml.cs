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
            if (position.X > playerPosition.X && position.Y == playerPosition.Y)
            {
                strPossibleDirection = "Tu peux aller à droite en " + position.X + ", " + position.Y + "\n";
            }
            else if (position.X < playerPosition.X && position.Y == playerPosition.Y)
            {
                strPossibleDirection = "Tu peux aller à gauche en " + position.X + ", " + position.Y + "\n";
            }
            else if (position.Y > playerPosition.Y && position.X == playerPosition.X)
            {
                strPossibleDirection = "Tu peux aller en bas en " + position.X + ", " + position.Y + "\n";
            }
            else if (position.Y < playerPosition.Y && position.X == playerPosition.X)
            {
                strPossibleDirection = "Tu peux aller en haut en " + position.X + ", " + position.Y + "\n";
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
    }
}
