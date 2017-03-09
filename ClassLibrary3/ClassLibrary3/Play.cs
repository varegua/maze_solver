using ClassLibrary3.mazeSolverService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{


    class Play
    {
        public Difficulty difficulty { get; }
        public String name { get; }
        public GameClient gameClient { get; }
        public PlayerGame playerGame { get; }
        public Player player { get; set; }
        public BotPlayerLogic bot { get; set; }

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
                MessageBox.Show(e.Message);
            }
            FinishGame();
          //  DisplayPlayerPossibilities(this.player.VisibleCells, this.player.CurrentPosition);
        }

        public void PlayBot()
        {
            Direction dir;
            while (this.player.FinishTime == null)
            {
                dir = this.bot.SelectBestDirection(this.player);
                doMovePlayer(playerGame, this.player, dir);
                Console.WriteLine("position X: " + this.player.CurrentPosition.X + " Y: " + this.player.CurrentPosition.Y);
                Thread.Sleep(500);
            }

        }

        private void FinishGame()
        {
            if (this.player.FinishTime != null)
            {
                MessageBox.Show("You finish in " + this.player.FinishTime + "\n " + this.player.SecretMessage);
                GameEnd page = new GameEnd(gameClient, playerGame, this.player);
            }
        }
    }
}
