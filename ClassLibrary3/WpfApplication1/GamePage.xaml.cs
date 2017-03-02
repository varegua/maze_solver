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
        private BotPlayerLogic bot;

        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(string name, Difficulty difficulty)
        {
            this.name = name;
            this.difficulty = difficulty;
            InitializeComponent();
            InitializeGame();
            InitWindows();
            this.Focus();
            this.ShowsNavigationUI = false;
 
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
                this.bot = new BotPlayerLogic(this.player);

                difficultyLabel.Content += this.difficulty.ToString();
                nbMoveValue.Content = player.NbMove;
                playerNameLabel.Content += player.Name;
                refreshPlayerPossibilities(player);
                InitWindows();
                InitGameCanvas();
        }

        private void InitWindows()
        {
            this.WindowHeight = 70 + this.playerGame.Maze.Height * 31;
            this.WindowWidth = 100 + this.playerGame.Maze.Width * 31;
        }


        private void InitGameCanvas()
        {
            gameCanvas.Width = playerGame.Maze.Width * 30;
            gameCanvas.Height = playerGame.Maze.Height * 30;
            personnage.Margin = new Thickness(currentPosition.X * 30, currentPosition.Y * 30, 0, 0);
            addImage(60, 60, "ver");
            gameCanvas.IsHitTestVisible = false;
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
                this.player = this.gameClient.MovePlayer(playerGame.Key, player.Key, dir);
                this.currentPosition = this.player.CurrentPosition;
                personnage.Margin = new Thickness(currentPosition.X * 30, currentPosition.Y * 30, 0, 0);
                nbMoveValue.Content = this.player.NbMove;

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
                    strPossibility += GetPossibleDirection(cell.Position, playerPosition, "end");
                    break;
                case CellType.Empty:
                    strPossibility = GetPossibleDirection(cell.Position, playerPosition, "empty");
                    break;
                case CellType.Start:
                    strPossibility = "Case départ en " + cell.Position.X + ", " + cell.Position.Y + "\n";
                    strPossibility += GetPossibleDirection(cell.Position, playerPosition, "start");
                    break;
                case CellType.Wall:
                    strPossibility += GetPossibleDirection(cell.Position, playerPosition, "wall");
                    break;
                default:
                    break;
            }

            return strPossibility;
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
            if (this.player.FinishTime != null)
            {
                MessageBox.Show("You finish in " + this.player.FinishTime);
                GameEnd page = new GameEnd(gameClient, playerGame);
                this.NavigationService.Navigate(page);
            }

        }

        BitmapImage cheminBitmapHor = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_hor.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapVer = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_ver.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapWall = new BitmapImage(new Uri("pack://application:,,,/Img/Wall.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapStart = new BitmapImage(new Uri("pack://application:,,,/Img/Start.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapEnd = new BitmapImage(new Uri("pack://application:,,,/Img/End.jpg", UriKind.RelativeOrAbsolute));

        private void addImage(int X, int Y, String img)
        {
            Image cheminImage = new Image();
            if (img == "hor")
                cheminImage.Source = cheminBitmapHor;
            else if (img == "ver")
                cheminImage.Source = cheminBitmapVer;
            else if (img == "wall")
                cheminImage.Source = cheminBitmapWall;
            else if (img == "start")
                cheminImage.Source = cheminBitmapStart;
            else if (img == "end")
                cheminImage.Source = cheminBitmapEnd;

            cheminImage.Width = 30;
            cheminImage.Height = 30;
            Canvas.SetLeft(cheminImage, X * 30);
            Canvas.SetTop(cheminImage, Y * 30);
        }

        private void PlayBot()
        {
            Direction dir;

                dir = this.bot.SelectBestDirection(this.player);
                doMovePlayer(playerGame, this.player, dir);
                Thread.Sleep(500);
            
        }

    }
}
