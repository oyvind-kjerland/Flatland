using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland
{
    public class Board
    {

        public enum State { Free, Food, Poison, Player }

        public State[,] board { get; set; }
        public State[,] initialBoard { get; }
        public float[] FPD { get; }
        public int[] dimensions { get; }
        public Player player;


        /// <summary>
        /// Create a board with given dimensions and FDP
        /// </summary>
        /// <param name="FPD">Food Poison Distribution</param>
        /// <param name="dimensions">Board dimensinos</param>
        public Board(float[] FPD, int[] dimensions)
        {
            this.FPD = FPD;
            this.dimensions = dimensions;
            board =  new State[dimensions[0], dimensions[1]];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = State.Free;
                }
            }


            InitializeBoard(FPD);

            PlaceRandomPlayer();
            initialBoard = (State[,])board.Clone();

        }

        public Board GetRandomizedBoard()
        {
            Board newBoard = new Board(this.FPD, this.dimensions);
            newBoard.player.ann = player.ann;
            return newBoard;
        }

        public void ResetBoard()
        {
            board = (State[,])initialBoard.Clone();
            player.ResetPlayer();
        }

        private void InitializeBoard(float[] FPD)
        {
            Random r = new Random();
            float foodRate = FPD[0];
            float poisonRate = FPD[1];

            // Do one pass over the board and put food
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    double probability = r.NextDouble();

                    if (probability < foodRate)
                        board[i, j] = State.Food;
                    else if (probability < foodRate + poisonRate)
                        board[i, j] = State.Poison;
                }
            }
        }

        /// <summary>
        /// Returns the next position for a given direction. Loops around the board.
        /// </summary>
        /// <param name="dir">Direction player is facing</param>
        /// <param name="previosPosition">previous position</param>
        /// <returns></returns>
        public Tuple<int, int> GetNextPosition(FacingDirection dir, Tuple<int, int> previosPosition)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            switch (dir)
            {
                case FacingDirection.NORTH:
                    return new Tuple<int, int>( Utility.Mod(previosPosition.Item1 - 1, rows), previosPosition.Item2);
                case FacingDirection.EAST:
                    return new Tuple<int, int>(previosPosition.Item1, Utility.Mod(previosPosition.Item2 + 1, cols));
                case FacingDirection.WEST:
                    return new Tuple<int, int>(previosPosition.Item1, Utility.Mod(previosPosition.Item2 - 1, cols));
                case FacingDirection.SOUTH:
                    return new Tuple<int, int>( Utility.Mod(previosPosition.Item1 + 1, rows), previosPosition.Item2);
                default:
                    return null;
            }

        }

        /// <summary>
        /// Randomly places a player on the board.
        /// Will overwrite whatever was there before.
        /// </summary>
        private void PlaceRandomPlayer()
        {
            Random r = new Random();
            int row = r.Next(board.GetLength(0));
            int col = r.Next(board.GetLength(1));
            board[row, col] = State.Player;
            this.player = new Player(this, new Tuple<int, int>(row, col));
        }

        /// <summary>
        /// </summary>
        /// <param name="s">State</param>
        /// <returns>Returns appropriate image for a given state</returns>
        public Image GetStateImage(State s)
        {
            Image image = null;
            switch (s)
            {
                case State.Free:
                    image = Properties.Resources.empty;
                    image.Tag = State.Free;
                    break;
                case State.Food:
                    image = Properties.Resources.rice;
                    image.Tag = State.Food;
                    break;
                case State.Poison:
                    image = Properties.Resources.poison;
                    image.Tag = State.Poison;
                    break;
                case State.Player:
                    image = Properties.Resources.player;
                    image.Tag = State.Player;
                    image.RotateFlip(player.GetRotationFlipType());
                    break;
            }

            return image;
        }

        public State GetStateOfPosition(Tuple<int,int> position)
        {
            return board[position.Item1, position.Item2];
        }

        public int GetRows()
        {
            return board.GetLength(0);
        }

        public int GetColumns()
        {
            return board.GetLength(1);
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    s += board[i, j] + " ";
                }
                s += "\r\n";
            }

            return s;
        }

    }
}
