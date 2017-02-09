using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary3.ServiceReference1;
using System.Threading;

namespace ConsoleApplication1
{
    class Test
    {
        static void Main()
        {   
            GameClient client = new GameClient("BasicHttpBinding_IGame");
            Console.WriteLine(client);
            PlayerGame player = client.CreateGame(Difficulty.Easy, "Test");
            Console.WriteLine(player.Player.Name);
            Console.WriteLine(player.Player.NbMove);
            Console.WriteLine(player.Player.CurrentPosition.X);
            Console.WriteLine(player.Player.CurrentPosition.Y);
            Console.WriteLine(player.Player.SecretMessage);
            Console.WriteLine(player.Player.VisibleCells);
            Cell[] visibleCells = player.Player.VisibleCells;
            foreach (Cell C in visibleCells) {
                Console.WriteLine("cellule :");
                Console.WriteLine(C.CellType);
                Console.WriteLine(C.Position.X);
                Console.WriteLine(C.Position.Y);
            }
            Thread.Sleep(500);
            Player P1 = player.Player;
            Console.WriteLine(player.Key);
            P1 = client.MovePlayer(player.Key, player.Player.Key, Direction.Down);
            Console.WriteLine(P1.Name);
            Console.WriteLine(P1.NbMove);
            Console.WriteLine(P1.CurrentPosition.X);
            Console.WriteLine(P1.CurrentPosition.Y);
            Console.WriteLine(P1.SecretMessage);
            Console.WriteLine(P1.VisibleCells);
            visibleCells = P1.VisibleCells;
            foreach (Cell C in visibleCells)
            {
                Console.WriteLine("cellule :");
                Console.WriteLine(C.CellType);
                Console.WriteLine(C.Position.X);
                Console.WriteLine(C.Position.Y);
            }
            while (true) { }

            // Use the 'client' variable to call operations on the service.

            // Always close the client.

   
        }
    }
}