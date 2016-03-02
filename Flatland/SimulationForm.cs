using Flatland.EA.DomainSpecific;
using System;
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
    partial class SimulationForm : Form
    {

        public Board board;
        
        public Individual bestIndividual;


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

            // Update sensor inputs
            UpdateSensorGUI(board.player);
        }

        public void UpdateBoardGUI(Board board)
        {
            for (int i = 0; i < board.board.GetLength(0); i++)
            {
                for (int j = 0; j < board.board.GetLength(1); j++)
                {
                    PictureBox pb = (PictureBox)tableLayoutPanel1.GetControlFromPosition(j, i);
                    if (pb.Image == null || (Board.State)pb.Image.Tag != board.board[i, j]) {
                        pb.Image = board.GetStateImage(board.board[i, j]);
                        pb.Refresh();
                    }
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

        public void SimulateVisualization(List<MovementDirection> moves, Board startingBoard)
        {
            Tuple<Board, List<MovementDirection>> arg = 
                new Tuple<Board, List<MovementDirection>>(startingBoard, moves);

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
            board.player.Move(MovementDirection.FORWARD);
            UpdateAllGUI(board);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            board.player.Move(MovementDirection.RIGHT);
            UpdateAllGUI(board);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            board.player.Move(MovementDirection.LEFT);
            UpdateAllGUI(board);
        }

        private void SimulationDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            Tuple<Board, List<MovementDirection>> args = 
                (Tuple<Board, List<MovementDirection>>)e.Argument;

            Board board = args.Item1;
            List<MovementDirection> moves = args.Item2;

            foreach (MovementDirection move in moves)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                board.player.Move(move);
                backgroundWorker1.ReportProgress(0, board);
                System.Threading.Thread.Sleep((int)delayNumericUpDown.Value);
            }
        }

        private void SimulationUpdate(object sender, ProgressChangedEventArgs e)
        {
                UpdateAllGUI((Board)e.UserState);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
            stopButton.Enabled = true;

            board.ResetBoard();
            ANNWeightPhenotype phenotype = (ANNWeightPhenotype)bestIndividual.Phenotype;
            board.player.ann.SetWeights(phenotype.Weights);

            List<MovementDirection> moves = new List<MovementDirection>();

            // TOOD
            for (int i = 0; i < 60; i++)
            {
                MovementDirection move = board.player.GetMove();
                moves.Add(move);
                board.player.Move(move);
            }

            board.ResetBoard();
            SimulateVisualization(moves, board);
        }

        private void newBoardButton_Click(object sender, EventArgs e)
        {
            board = board.GetRandomizedBoard();
            UpdateAllGUI(board);
        }

        private void SimulationCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonStart.Enabled = true;
            stopButton.Enabled = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
