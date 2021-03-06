﻿using MazeSolver.Client.Core.mazeSolverService;
using System;
using System.Threading;

namespace MazeSolver.Client.Core
{
    public class Play
    {
        public Difficulty difficulty { get; }
        public String name { get; }
        public GameClient gameClient { get; }
        public PlayerGame playerGame { get; }
        public Player player { get; set; }
        public BotPlayerLogics bot { get; set; }

        public Play(String name, Difficulty difficulty)
        {
            this.difficulty = difficulty;
            this.name = name;
            this.gameClient = new GameClient("BasicHttpBinding_IGame");
            this.playerGame = gameClient.CreateGame(difficulty, name);
            this.player = playerGame.Player;
            this.bot = new BotPlayerLogics(this.player);
        }

        public Play(String name, String gameKey)
        {
            this.name = name;
            this.gameClient = new GameClient("BasicHttpBinding_IGame");
            this.player = gameClient.AddPlayer(gameKey, name);

            this.bot = new BotPlayerLogics(this.player);
        }


        public void DoMovePlayer(Direction dir)
        {
            try
            {
                this.player = this.gameClient.MovePlayer(this.playerGame.Key, this.player.Key, dir);
            }
            catch (System.ServiceModel.FaultException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Boolean IsFinishGame()
        {
            return this.player.FinishTime != null;
        }

        public Boolean PlayBot()
        {
            Direction dir;

            while (this.player.FinishTime == null)
            {
                dir = this.bot.FindBestDirection(this.player);
                DoMovePlayer(dir);
                Console.WriteLine("position X: " + this.player.CurrentPosition.X + " Y: " + this.player.CurrentPosition.Y);
                Thread.Sleep(500);
            }
            return true;
        }

    }
}
