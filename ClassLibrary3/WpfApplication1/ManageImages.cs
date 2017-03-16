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
using MazeSolver.Client.Core.mazeSolverService;
using System.Threading;
using MazeSolver.Client.Core;
using MazeSolver.Client.Wpf;

namespace MazeSolver.Client.Wpf
{
    public class ManageImages
    {
        public ScrollViewer scrollViewver;
        public Canvas gameCanvas;
        public Label difficultyLabel;
        public Label playerNameLabel;
        public Label nbMoveLabel;
        public Label nbMoveValue;
        public Image personnage;
        public ImageBrush background;

        BitmapImage BitmapPersonnage = new BitmapImage(new Uri("pack://application:,,,/Img/oeil.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapHor = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_hor.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapVer = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_ver.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapWall = new BitmapImage(new Uri("pack://application:,,,/Img/Wall.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapStart = new BitmapImage(new Uri("pack://application:,,,/Img/Start.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage cheminBitmapEnd = new BitmapImage(new Uri("pack://application:,,,/Img/End.jpg", UriKind.RelativeOrAbsolute));
        BitmapImage bitmapBackground = new BitmapImage(new Uri("pack://application:,,,/Img/background.jpg", UriKind.RelativeOrAbsolute));

        public ManageImages(Page page)
        {
            this.scrollViewver = new ScrollViewer();
            this.scrollViewver.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            this.scrollViewver.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

            this.gameCanvas = new Canvas();
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Margin = new Thickness(0, 30, 0, 0); ;
            this.gameCanvas.Width = 250;//game.playerGame.Maze.Width * 30;
            this.gameCanvas.Height = 250;//game.playerGame.Maze.Height * 30;
            this.gameCanvas.IsHitTestVisible = false;

            this.personnage = new Image();
            personnage.Source = BitmapPersonnage;
            personnage.Height = 30;
            personnage.Width = 30;
            Canvas.SetLeft(personnage, 30);
            Canvas.SetTop(personnage, 30);
            Canvas.SetZIndex(personnage, 1);
            gameCanvas.Children.Add(personnage);

            //top : -29
            this.difficultyLabel = new Label();
            this.difficultyLabel.Content = "Difficulty : ";
            this.difficultyLabel.MaxHeight = 25;
            this.difficultyLabel.MaxWidth = 140;
            this.difficultyLabel.Height = 25;
            Canvas.SetTop(difficultyLabel, -29);
            gameCanvas.Children.Add(difficultyLabel);

            //top:-29 left 138
            this.playerNameLabel = new Label();
            this.playerNameLabel.Content = "Player : ";
            this.playerNameLabel.MaxHeight = 25;
            this.playerNameLabel.MaxWidth = 160;
            this.playerNameLabel.Height = 25;
            Canvas.SetLeft(playerNameLabel, 138);
            Canvas.SetTop(playerNameLabel, -29);
            gameCanvas.Children.Add(playerNameLabel);

            //top:-29 left 344
            this.nbMoveValue = new Label();
            this.nbMoveValue.Content = "";
            this.nbMoveValue.MaxHeight = 25;
            this.nbMoveValue.MaxWidth = 65;
            this.nbMoveValue.Height = 25;
            Canvas.SetLeft(nbMoveValue, 344);
            Canvas.SetTop(nbMoveValue, -29);
            gameCanvas.Children.Add(nbMoveValue);

            //top:-29 left 274
            this.nbMoveLabel = new Label();
            this.nbMoveLabel.Content = "Nb moves : ";
            this.nbMoveLabel.MaxHeight = 25;
            this.nbMoveLabel.MaxWidth = 160;
            this.nbMoveLabel.Height = 25;
            Canvas.SetLeft(nbMoveLabel, 274);
            Canvas.SetTop(nbMoveLabel, -29);
            gameCanvas.Children.Add(nbMoveLabel);

            this.background = new ImageBrush(bitmapBackground);
            gameCanvas.Background = this.background;

             scrollViewver.Content = gameCanvas;
            page.Content = scrollViewver;

        }

        public void InitGameCanvas(Play game)
        {
            this.gameCanvas.Width = game.playerGame.Maze.Width * 30;
            this.gameCanvas.Height = game.playerGame.Maze.Height * 30;
            this.gameCanvas.IsHitTestVisible = false;
        }

        public void InitializeLabelGame(Play game)
        {
            this.difficultyLabel.Content += game.difficulty.ToString();
            this.nbMoveValue.Content = "0";
            this.playerNameLabel.Content += game.player.Name;
        }

        public void DisplayPlayerPossibilities(Player player)
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
                    ChooseImage(cell.Position, playerPosition, "end");
                    break;
                case CellType.Empty:
                    ChooseImage(cell.Position, playerPosition, "empty");
                    break;
                case CellType.Start:
                    ChooseImage(cell.Position, playerPosition, "start");
                    break;
                case CellType.Wall:
                    ChooseImage(cell.Position, playerPosition, "wall");
                    break;
                default:
                    break;
            }
        }

        public void ChooseImage(Position position, Position playerPosition, String name)
        {
            if (name == "empty")
            {
                if ((position.Y > playerPosition.Y && position.X == playerPosition.X)
                || (position.Y < playerPosition.Y && position.X == playerPosition.X))
                {
                    addImage(position.X, position.Y, "ver");
                }

                else if (position.Y != playerPosition.Y || position.X != playerPosition.X)
                {
                    addImage(position.X, position.Y, "hor");
                }
            }
            else
            {
                switch (name)
                {
                    case "start":
                        addImage(position.X, position.Y, "start");
                        break;
                    case "end":
                        addImage(position.X, position.Y, "end");
                        break;
                    case "wall":
                        addImage(position.X, position.Y, "wall");
                        break;
                }
            }
        }

        public void addImage(int X, int Y, String img)
        {

            Image cheminImage = new Image();
            switch (img)
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
            }
            cheminImage.Width = 30;
            cheminImage.Height = 30;
            Canvas.SetLeft(cheminImage, X * 30);
            Canvas.SetTop(cheminImage, Y * 30);
            this.gameCanvas.Children.Add(cheminImage);
        }

        public void MovePlayerImage(Player player)
        {
            Canvas.SetLeft(personnage, player.CurrentPosition.X * 30);
            Canvas.SetTop(personnage, player.CurrentPosition.Y * 30);
            this.nbMoveValue.Content = player.NbMove;
        }

        public static void DisplayFinishPage(Page gamePage, Play game)
        {
            MessageBox.Show("You finish in " + game.player.FinishTime + " en " + game.player.NbMove + "moves.\n " + game.player.SecretMessage);
            GameEnd page = new GameEnd(game.gameClient, game.playerGame, game.player);
            gamePage.NavigationService.Navigate(page);
        }


    }
}
