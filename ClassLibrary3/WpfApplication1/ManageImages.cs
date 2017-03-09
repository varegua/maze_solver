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

namespace MazeSolver.Client
{
    public class ManageImages
    {

        public static void DisplayPlayerPossibilities(Player player, Canvas gameCanvas)
        {
            Position currentPlayerPosition = player.CurrentPosition;
            Cell[] visibleCells = player.VisibleCells;
            String possibility = "";
            foreach (Cell cell in visibleCells)
            {
                possibility += ManageImages.CellPossibility(cell, currentPlayerPosition, gameCanvas);
            }
        }

        private static String CellPossibility(Cell cell, Position playerPosition, Canvas gameCanvas)
        {
            String strPossibility = "";
            switch (cell.CellType)
            {
                case CellType.End:
                    ChooseImage(cell.Position, playerPosition, "end", gameCanvas);
                    break;
                case CellType.Empty:
                    ChooseImage(cell.Position, playerPosition, "empty", gameCanvas);
                    break;
                case CellType.Start:
                    ChooseImage(cell.Position, playerPosition, "start", gameCanvas);
                    break;
                case CellType.Wall:
                    ChooseImage(cell.Position, playerPosition, "wall", gameCanvas);
                    break;
                default:
                    break;
            }

            return strPossibility;
        }

        public static void ChooseImage(Position position, Position playerPosition, String name, Canvas gameCanvas)
        {

            if (name == "empty")
            {
                if ((position.Y > playerPosition.Y && position.X == playerPosition.X)
                || (position.Y < playerPosition.Y && position.X == playerPosition.X))
                {
                    addImage(position.X, position.Y, "ver", gameCanvas);
                }

                else if (position.Y != playerPosition.Y || position.X != playerPosition.X)
                {
                    addImage(position.X, position.Y, "hor", gameCanvas);
                }
            }
            else
            {
                switch (name)
                {
                    case "start":
                        addImage(position.X, position.Y, "start", gameCanvas);
                        break;
                    case "end":
                        addImage(position.X, position.Y, "end", gameCanvas);
                        break;
                    case "wall":
                        addImage(position.X, position.Y, "wall", gameCanvas);
                        break;
                }
            }
        }

        public static void addImage(int X, int Y, String img, Canvas gameCanvas)
        {
            BitmapImage cheminBitmapHor = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_hor.jpg", UriKind.RelativeOrAbsolute));
            BitmapImage cheminBitmapVer = new BitmapImage(new Uri("pack://application:,,,/Img/chemin_ver.jpg", UriKind.RelativeOrAbsolute));
            BitmapImage cheminBitmapWall = new BitmapImage(new Uri("pack://application:,,,/Img/Wall.jpg", UriKind.RelativeOrAbsolute));
            BitmapImage cheminBitmapStart = new BitmapImage(new Uri("pack://application:,,,/Img/Start.jpg", UriKind.RelativeOrAbsolute));
            BitmapImage cheminBitmapEnd = new BitmapImage(new Uri("pack://application:,,,/Img/End.jpg", UriKind.RelativeOrAbsolute));

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
            gameCanvas.Children.Add(cheminImage);
        }
    }
}
