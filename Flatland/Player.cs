using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland
{
    public enum FacingDirection { NORTH, EAST, WEST, SOUTH}
    public enum MovementDirection { FORWARD, LEFT, RIGHT}

    public class Player
    {


        public FacingDirection facingDirection = FacingDirection.SOUTH;
        public Board.State[] sensors = new Board.State[3];
        public Tuple<int, int> position;
        public Board board;
        public int foodScore { get; set; }
        public int poisonScore { get; set; }

        public Player(Board board, Tuple<int, int> position)
        {
            this.board = board;
            this.position = position;
            UpdateSensors(position);
        }

        /// <summary>
        /// Updates the players position on the board after moving.
        /// </summary>
        /// <param name="dir">Direction to move</param>
        public void Move(MovementDirection dir)
        {
            FacingDirection nextFacingDirection = GetNewDirection(dir, facingDirection);
            Tuple<int, int> nextPos = board.GetNextPosition(nextFacingDirection, position);

            // Remove the player from where we were before, i.e set it to FREE
            board.board[position.Item1, position.Item2] = Board.State.Free;

            // Update to new position
            position = nextPos;

            // Consume item at new position
            ConsumeItem(position);

            // Update direction
            facingDirection = nextFacingDirection;

            // Update position in board
            board.board[position.Item1, position.Item2] = Board.State.Player;

            UpdateSensors(position);
        }

        private void UpdateSensors(Tuple<int, int> position)
        {
            // Forward
            FacingDirection forwardDirection = GetNewDirection(MovementDirection.FORWARD, facingDirection);
            sensors[0] = board.GetStateOfPosition(board.GetNextPosition(forwardDirection, position));
            // Right
            FacingDirection rightDirection = GetNewDirection(MovementDirection.RIGHT, facingDirection);
            sensors[1] = board.GetStateOfPosition(board.GetNextPosition(rightDirection, position));
            // Left
            FacingDirection leftDirection = GetNewDirection(MovementDirection.LEFT, facingDirection);
            sensors[2] = board.GetStateOfPosition(board.GetNextPosition(leftDirection, position));
        }

        private void ConsumeItem(Tuple<int,int> position)
        {
            // Update scores.
            switch (board.board[position.Item1, position.Item2])
            {
                case Board.State.Food:
                    foodScore++;
                    break;
                case Board.State.Poison:
                    poisonScore++;
                    break;
            }
        }

        private FacingDirection GetNewDirection(MovementDirection dir, FacingDirection facingDirection)
        {
            switch (facingDirection)
            {
                case FacingDirection.NORTH:
                    if (dir == MovementDirection.FORWARD)
                    {
                        return FacingDirection.NORTH;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        return FacingDirection.WEST;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        return FacingDirection.EAST;
                    }
                    break;

                case FacingDirection.EAST:
                    if (dir == MovementDirection.FORWARD)
                    {
                        return FacingDirection.EAST;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        return FacingDirection.NORTH;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        return FacingDirection.SOUTH;
                    }
                    break;

                case FacingDirection.WEST:
                    if (dir == MovementDirection.FORWARD)
                    {
                        return FacingDirection.WEST;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        return FacingDirection.SOUTH;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        return FacingDirection.NORTH;
                    }
                    break;

                case FacingDirection.SOUTH:
                    if (dir == MovementDirection.FORWARD)
                    {
                        return FacingDirection.SOUTH;
                    }
                    else if (dir == MovementDirection.LEFT)
                    {
                        return FacingDirection.EAST;
                    }
                    else if (dir == MovementDirection.RIGHT)
                    {
                        return FacingDirection.WEST;
                    }
                    break;
            }

            return FacingDirection.NORTH;
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
