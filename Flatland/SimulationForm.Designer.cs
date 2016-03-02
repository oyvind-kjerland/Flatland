namespace Flatland
{
    partial class SimulationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.forwardButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.foodEatenLabel = new System.Windows.Forms.Label();
            this.poisonEatenLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.forwardSensorlabel = new System.Windows.Forms.Label();
            this.rightSensorLabel = new System.Windows.Forms.Label();
            this.leftSensorLabel = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.newBoardButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(653, 132);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 2;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(563, 182);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(75, 23);
            this.leftButton.TabIndex = 3;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(733, 182);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(75, 23);
            this.rightButton.TabIndex = 5;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 500);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SimulationDoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SimulationUpdate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Food Eaten";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Poison Eaten";
            // 
            // foodEatenLabel
            // 
            this.foodEatenLabel.AutoSize = true;
            this.foodEatenLabel.Location = new System.Drawing.Point(650, 28);
            this.foodEatenLabel.Name = "foodEatenLabel";
            this.foodEatenLabel.Size = new System.Drawing.Size(13, 13);
            this.foodEatenLabel.TabIndex = 10;
            this.foodEatenLabel.Text = "0";
            // 
            // poisonEatenLabel
            // 
            this.poisonEatenLabel.AutoSize = true;
            this.poisonEatenLabel.Location = new System.Drawing.Point(650, 53);
            this.poisonEatenLabel.Name = "poisonEatenLabel";
            this.poisonEatenLabel.Size = new System.Drawing.Size(13, 13);
            this.poisonEatenLabel.TabIndex = 11;
            this.poisonEatenLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(563, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Forward: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(563, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Right:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(563, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Left:";
            // 
            // forwardSensorlabel
            // 
            this.forwardSensorlabel.AutoSize = true;
            this.forwardSensorlabel.Location = new System.Drawing.Point(612, 277);
            this.forwardSensorlabel.Name = "forwardSensorlabel";
            this.forwardSensorlabel.Size = new System.Drawing.Size(28, 13);
            this.forwardSensorlabel.TabIndex = 15;
            this.forwardSensorlabel.Text = "Free";
            // 
            // rightSensorLabel
            // 
            this.rightSensorLabel.AutoSize = true;
            this.rightSensorLabel.Location = new System.Drawing.Point(612, 300);
            this.rightSensorLabel.Name = "rightSensorLabel";
            this.rightSensorLabel.Size = new System.Drawing.Size(28, 13);
            this.rightSensorLabel.TabIndex = 16;
            this.rightSensorLabel.Text = "Free";
            // 
            // leftSensorLabel
            // 
            this.leftSensorLabel.AutoSize = true;
            this.leftSensorLabel.Location = new System.Drawing.Point(612, 325);
            this.leftSensorLabel.Name = "leftSensorLabel";
            this.leftSensorLabel.Size = new System.Drawing.Size(28, 13);
            this.leftSensorLabel.TabIndex = 17;
            this.leftSensorLabel.Text = "Free";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(563, 391);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 18;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // newBoardButton
            // 
            this.newBoardButton.Location = new System.Drawing.Point(644, 391);
            this.newBoardButton.Name = "newBoardButton";
            this.newBoardButton.Size = new System.Drawing.Size(75, 23);
            this.newBoardButton.TabIndex = 19;
            this.newBoardButton.Text = "New Board";
            this.newBoardButton.UseVisualStyleBackColor = true;
            this.newBoardButton.Click += new System.EventHandler(this.newBoardButton_Click);
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 561);
            this.Controls.Add(this.newBoardButton);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.leftSensorLabel);
            this.Controls.Add(this.rightSensorLabel);
            this.Controls.Add(this.forwardSensorlabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.poisonEatenLabel);
            this.Controls.Add(this.foodEatenLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.forwardButton);
            this.Name = "SimulationForm";
            this.Text = "SimulationForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label foodEatenLabel;
        private System.Windows.Forms.Label poisonEatenLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label forwardSensorlabel;
        private System.Windows.Forms.Label rightSensorLabel;
        private System.Windows.Forms.Label leftSensorLabel;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button newBoardButton;
    }
}