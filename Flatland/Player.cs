using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland
{
    public class Player
    {

        public enum FacingDirection { NORTH, EAST, WEST, SOUTH}
        public enum MovementDirection { FORWARD, LEFT, RIGHT}

        public FacingDirection facingDirection = FacingDirection.SOUTH;
        public Tuple<int, int> position;
        public Board board;

        public Player(Board board, Tuple<int, int> position)
        {
            this.board = board;
            this.position = position;
        }

        /// <summary>
        /// Updates the players position on the board after moving.
        /// </summary>
        /// <param name="dir">Direction to move</param>
        public void Move(MovementDirection dir)
        {
            Tuple<int, int> nextPos = null;
            FacingDirection nextFacingDirection = FacingDirection.NORTH;

            switch (facingDirection)
            {
                case FacingDirection.NORTH:
                    if (dir == MovementDirection.FORWARD)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.NORTH, position);
                        nextFacingDirection = FacingDirection.NORTH;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.WEST, position);
                        nextFacingDirection = FacingDirection.WEST;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.EAST, position);
                        nextFacingDirection = FacingDirection.EAST;
                    }
                    break;

                case FacingDirection.EAST:
                    if (dir == MovementDirection.FORWARD)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.EAST, position);
                        nextFacingDirection = FacingDirection.EAST;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.NORTH, position);
                        nextFacingDirection = FacingDirection.NORTH;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.SOUTH, position);
                        nextFacingDirection = FacingDirection.SOUTH;
                    }
                    break;

                case FacingDirection.WEST:
                    if (dir == MovementDirection.FORWARD)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.WEST, position);
                        nextFacingDirection = FacingDirection.WEST;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.SOUTH, position);
                        nextFacingDirection = FacingDirection.SOUTH;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.NORTH, position);
                        nextFacingDirection = FacingDirection.NORTH;
                    }
                    break;

                case FacingDirection.SOUTH:
                    if (dir == MovementDirection.FORWARD)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.SOUTH, position);
                        nextFacingDirection = FacingDirection.SOUTH;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.EAST, position);
                        nextFacingDirection = FacingDirection.EAST;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        nextPos = board.GetNextPosition(FacingDirection.WEST, position);
                        nextFacingDirection = FacingDirection.WEST;
                    }
                    break;
            }

            // Consume the item at the state we were in before, i.e set it to FREE
            board.board[position.Item1, position.Item2] = Board.State.Free;

            // Update to new position
            position = nextPos;

            // Update direction
            facingDirection = nextFacingDirection;
            Console.WriteLine("Facing: " + facingDirection);

            // Update position in board
            board.board[position.Item1, position.Item2] = Board.State.Player;

        }

        internal RotateFlipType GetRotationFlipType()
        {
            // South is the default image rotation

            switch (facingDirection)
            {
                case FacingDirection.NORTH:
                    return RotateFlipType.Rotate180FlipNone;
                case FacingDirection.WEST:
                    return RotateFlipType.Rotate90FlipNone;
                case FacingDirection.SOUTH:
                    return RotateFlipType.RotateNoneFlipNone;
                case FacingDirection.EAST:
                    return RotateFlipType.Rotate270FlipNone;
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }
    }
}
