﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flatland
{
    public partial class SimulationForm : Form
    {

        public Board board;

        public SimulationForm(Board board)
        {
            this.board = board;
            InitializeComponent();

            InitializeGUI();
            UpdateAllGUI(board);
        }

        public void InitializeGUI()
        {
            float colWidth = 100.0f / board.GetColumns();
            float rowHeigth = 100.0f / board.GetRows();

            tableLayoutPanel1.RowCount = board.GetRows();
            tableLayoutPanel1.ColumnCount = board.GetColumns();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            for (int i = 0; i < board.GetRows(); i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeigth));
            }

            for (int i = 0; i < board.GetColumns(); i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colWidth));
            }
            
            for (int i = 0; i < board.GetRows(); i++)
            {
                for (int j = 0; j < board.GetColumns(); j++)
                {
                    PictureBox pb = new PictureBox();
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    tableLayoutPanel1.Controls.Add(pb);
                }
            }
        }

        public void UpdateAllGUI(Board board)
        {
            // Update board
            UpdateBoardGUI(board);

            // Update scores
            UpdatePlayerScoresGUI(board.player);
            UpdateSensorGUI(board.player);
        }

        public void UpdateBoardGUI(Board board)
        {
            for (int i = 0; i < board.board.GetLength(0); i++)
            {
                for (int j = 0; j < board.board.GetLength(1); j++)
                {
                    PictureBox pb = (PictureBox)tableLayoutPanel1.GetControlFromPosition(j, i);
                    pb.Image = board.GetStateImage(board.board[i, j]);
                    pb.Refresh();
                }
            }
        }

        public void UpdatePlayerScoresGUI(Player player)
        {
            foodEatenLabel.Text = player.foodScore.ToString();
            poisonEatenLabel.Text = player.poisonScore.ToString();
        }

        public void UpdateSensorGUI(Player player)
        {
            forwardSensorlabel.Text = player.sensors[0].ToString();
            rightSensorLabel.Text = player.sensors[1].ToString();
            leftSensorLabel.Text = player.sensors[2].ToString();
        }

        public void SimulateVisualization(List<Player.MovementDirection> moves, Board startingBoard)
        {
            Tuple<Board, List<Player.MovementDirection>> arg = 
                new Tuple<Board, List<Player.MovementDirection>>(startingBoard, moves);

            backgroundWorker1.RunWorkerAsync(arg);
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            //Board b = new Board(new float[] { 0.33f, 0.33f }, new int[] { 10, 10 });
            /*List<Player.MovementDirection> moves = new List<Player.MovementDirection>();

            
            moves.Add(Player.MovementDirection.FORWARD);
            moves.Add(Player.MovementDirection.FORWARD);
            moves.Add(Player.MovementDirection.RIGHT);
            moves.Add(Player.MovementDirection.FORWARD);
            moves.Add(Player.MovementDirection.LEFT);
            moves.Add(Player.MovementDirection.FORWARD);
            moves.Add(Player.MovementDirection.RIGHT);
            moves.Add(Player.MovementDirection.FORWARD);

            SimulateVisualization(moves, board);*/
            board.player.Move(Player.MovementDirection.FORWARD);
            UpdateAllGUI(board);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            board.player.Move(Player.MovementDirection.RIGHT);
            UpdateAllGUI(board);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            board.player.Move(Player.MovementDirection.LEFT);
            UpdateAllGUI(board);
        }

        private void SimulationDoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<Board, List<Player.MovementDirection>> args = 
                (Tuple<Board, List<Player.MovementDirection>>)e.Argument;

            Board board = args.Item1;
            List<Player.MovementDirection> moves = args.Item2;

            foreach (Player.MovementDirection move in moves)
            {
                board.player.Move(move);
                backgroundWorker1.ReportProgress(0, board);
                System.Threading.Thread.Sleep(500);
            }
        }

        private void SimulationUpdate(object sender, ProgressChangedEventArgs e)
        {
                UpdateAllGUI((Board)e.UserState);
        }
    }
}
