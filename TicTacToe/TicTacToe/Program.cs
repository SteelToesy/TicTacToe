using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        public static void Main(string[] args)
        {
            var c = new Game();
            c.Start();
        }
    }
    internal class Game
    {
        // This is the map that the game will use
        private string[] _map = new string[] { "1", "|", "2", "|", "3",
                                               "4", "|", "5", "|", "6",
                                               "7", "|", "8", "|", "9",};


        public void Start()
        {
            // set the first player to X
            string player = "X";

            // draw the first map
            DrawMap();

            // the game loop
            while (true)
            {
                // get the player's move
                Console.WriteLine("Player {0} turn", player);

                // check if the move is valid
                string input = Input();

                // draw the player's move on the map
                FillSquare(input, player);

                // clear the previous iteration of the map and print the updated map before checking draw.
                Console.Clear();
                DrawMap();

                // check if there's a winner or draw
                if (CheckDraw() || CheckWinner(player))
                    break;

                // switch the player
                if (player == "X")
                    player = "O";
                else
                    player = "X";
            }

            if (CheckWinner(player))
                Console.WriteLine("Player {0} wins!", player);
            else
                Console.WriteLine("It's a draw!");
            Console.ReadLine();
            Environment.Exit(0);
        }

        // Draw the map
        public void DrawMap()
        {
            int xi = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Console.Write(_map[xi]);
                    xi++;
                }
                Console.WriteLine();
            }
        }

        public string Input()
        {
            string input = Console.ReadLine().ToString();
            int inputInt = int.Parse(input);

            // validate input
            while (input != "1" &&
                    input != "2" &&
                    input != "3" &&
                    input != "4" &&
                    input != "5" &&
                    input != "6" &&
                    input != "7" &&
                    input != "8" &&
                    input != "9")
            {
                Console.WriteLine("Invalid input, please try again");
                input = Console.ReadLine().ToString();
            }
            //TODO: check if the square is already filled

            return input;
        }

        public void FillSquare(string pInput, string pPlayer)
        {
            // goes through the map array searching for the same value as input, and changes it to the player's symbol
            for (int i = 0; i < _map.Length; i++)
            {
                if (_map[i] == pInput)
                    _map[i] = pPlayer;
            }
        }

        public bool CheckWinner(string pPlayer)
        {
            // checks every possible winning combination
            if (_map[0] == pPlayer && _map[2] == pPlayer && _map[4] == pPlayer ||
                _map[5] == pPlayer && _map[7] == pPlayer && _map[9] == pPlayer ||
                _map[10] == pPlayer && _map[12] == pPlayer && _map[14] == pPlayer ||
                _map[0] == pPlayer && _map[5] == pPlayer && _map[10] == pPlayer ||
                _map[12] == pPlayer && _map[7] == pPlayer && _map[2] == pPlayer ||
                _map[14] == pPlayer && _map[9] == pPlayer && _map[4] == pPlayer ||
                _map[10] == pPlayer && _map[7] == pPlayer && _map[4] == pPlayer ||
                _map[0] == pPlayer && _map[7] == pPlayer && _map[14] == pPlayer)
            {
                return true;
            }
            return false;
        }

        public bool CheckDraw()
        {
            // checks if the map is full
            for (int i = 0; i < _map.Length; i++)
            {
                //ignores lines
                if (_map[i] == "|")
                    i++;
                if (_map[i] != "X" && _map[i] != "O")
                    return false;
            }
            return true;
        }
    }
}