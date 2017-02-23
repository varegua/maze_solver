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
            this.Focus();
            this.gameClient = new GameClient("BasicHttpBinding_IGame");
            this.playerGame = gameClient.CreateGame(difficulty, name);
            this.player = playerGame.Player;
            lblPlayer.Content = "Bonjour " + name + ", tu vas jouer sur une grille de " + playerGame.Maze.Height + "x" + playerGame.Maze.Width + "   \t " + this.player.FinishTime;
            currentPosition = player.CurrentPosition;
            refreshPossibility();
            myGrid.Width = playerGame.Maze.Width*30;
            myGrid.Height = playerGame.Maze.Height*30;
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
                Canvas.SetLeft(personnage, 30);
            }
            else if (e.Key == Key.Down)
            {
                doMovePlayer(this.playerGame, this.player, Direction.Down);
                Canvas.SetBottom(personnage, 30);
            }
            refreshPossibility();
        }

        private void doMovePlayer(PlayerGame playerGame, Player player, Direction dir)
        {
            try
            {
                this.player = this.gameClient.MovePlayer(playerGame.Key, player.Key, dir);
            }
            catch (System.ServiceModel.FaultException e)
            {
                MessageBox.Show(e.Message);
            }
            if (this.player.FinishTime != null)
            {
                MessageBox.Show("You finish in " + this.player.FinishTime);
                GameAccueil page = new GameAccueil();
                this.NavigationService.Navigate(page);
            }
            refreshPossibility();
            if (!this.IsFocused)
            {
                this.Focus();
            }
        }

        private void refreshPossibility()
        {
            currentPosition = player.CurrentPosition;
            lblPosibility.Content = "";
            lblPosibility.Content = "Tu es en " + currentPosition.X + ", " + currentPosition.Y + "\n";
            Cell[] visibleCells = player.VisibleCells;
            foreach (Cell cell in visibleCells)
            {
                if (cell.CellType.Equals(CellType.End))
                {
                    lblPosibility.Content += "Sortie en " + cell.Position.X + ", " + cell.Position.Y + "\n";
                }
                if (cell.CellType.Equals(CellType.Empty) || cell.CellType.Equals(CellType.Start))
                {
                    if (cell.Position.X > currentPosition.X && cell.Position.Y == currentPosition.Y)
                    {
                        lblPosibility.Content += "Tu peux aller à droite en " + cell.Position.X + ", " + cell.Position.Y + "\n";
                    }
                    else if (cell.Position.X < currentPosition.X && cell.Position.Y == currentPosition.Y)
                    {
                        lblPosibility.Content += "Tu peux aller à gauche en " + cell.Position.X + ", " + cell.Position.Y + "\n";

                    }
                    else if (cell.Position.Y > currentPosition.Y && cell.Position.X == currentPosition.X)
                    {
                        lblPosibility.Content += "Tu peux aller en bas en " + cell.Position.X + ", " + cell.Position.Y + "\n";

                    }
                    else if (cell.Position.Y < currentPosition.Y && cell.Position.X == currentPosition.X)
                    {
                        lblPosibility.Content += "Tu peux aller en haut en " + cell.Position.X + ", " + cell.Position.Y + "\n";
                    }
                }
            }
        }
    }
}
