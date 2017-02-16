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
            this.name = name;
            this.difficulty = difficulty;
            InitializeComponent();
            lblPlayer.Content = "Bonjour " + name;
            this.gameClient = new GameClient("BasicHttpBinding_IGame");
            playerGame = gameClient.CreateGame(difficulty, name);
            player = playerGame.Player;
            currentPosition = player.CurrentPosition;
            lblPosibility.Content = "Tu es en " + currentPosition.X + ", " + currentPosition.Y;
            Cell[] visibleCells = player.VisibleCells;
            foreach(Cell cell in visibleCells)
            {
                lblPosibility.Content += "\nType " + cell.CellType + "Coordonnée " + cell.Position.X  + ", " + cell.Position.Y +"\n";
            }
        }


    }
}
