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
    public partial class SimulationForm : Form
    {

        public Board board;

        public SimulationForm(Board board)
        {
            this.board = board;
            InitializeComponent();

            InitializeGUI();
            VisualizeBoard(board);
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

        public void VisualizeBoard(Board board)
        {
            for(int i = 0; i < board.board.GetLength(0); i++)
            {
                for (int j = 0; j < board.board.GetLength(1); j++)
                {
                    PictureBox pb = (PictureBox)tableLayoutPanel1.GetControlFromPosition(j, i);
                    pb.Image = board.GetStateImage(board.board[i, j]);
                    pb.Refresh();
                }
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            board.player.Move(Player.MovementDirection.FORWARD);
            VisualizeBoard(board);
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            board.player.Move(Player.MovementDirection.RIGHT);
            VisualizeBoard(board);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            board.player.Move(Player.MovementDirection.LEFT);
            VisualizeBoard(board);
        }
    }
}
