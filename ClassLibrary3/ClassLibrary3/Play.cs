using ClassLibrary3.mazeSolverService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.MessageBox;

namespace MazeSolver.Client.Core
{
    public class Play
    {
        public Difficulty difficulty { get; }
        public String name { get; }
        public GameClient gameClient { get; }
        public PlayerGame playerGame { get; }
        public Player player { get; set; }
        private BotPlayerLogic bot;

        public Play(String name, Difficulty difficulty)
        {
            this.difficulty = difficulty;
            this.name = name;
            this.gameClient = new GameClient("BasicHttpBinding_IGame");
            this.playerGame = gameClient.CreateGame(difficulty, name);
            this.player = playerGame.Player;
            this.bot = new BotPlayerLogic(this.player);
        }

        public int GetNbMoves()
        {
            return this.player.NbMove;
        }

        private void DoMovePlayer(PlayerGame playerGame, Player player, Direction dir)
        {
            try
            {
                this.player = this.gameClient.MovePlayer(playerGame.Key, player.Key, dir);
                //MovePersonnage(this.player.CurrentPosition);
            }
            catch (System.ServiceModel.FaultException e)
            {
                throw new System.ServiceModel.FaultException(e);
            }
            IsFinishGame();
          //  DisplayPlayerPossibilities(this.player.VisibleCells, this.player.CurrentPosition);
        }

        public void PlayBot()
        {
            Direction dir;
            while (this.player.FinishTime == null)
            {
                dir = this.bot.SelectBestDirection(this.player);
                DoMovePlayer(playerGame, this.player, dir);
                Console.WriteLine("position X: " + this.player.CurrentPosition.X + " Y: " + this.player.CurrentPosition.Y);
                Thread.Sleep(500);
            }

        }

        private Boolean IsFinishGame()
        {
            return this.player.FinishTime != null;
        }
    }
}
