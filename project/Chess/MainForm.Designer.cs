namespace Chess
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAIGame = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.new2PlayerGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endCurrentGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.manualBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPieceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.White_Pawn = new System.Windows.Forms.ToolStripMenuItem();
            this.White_Rook = new System.Windows.Forms.ToolStripMenuItem();
            this.White_Knight = new System.Windows.Forms.ToolStripMenuItem();
            this.White_Bishop = new System.Windows.Forms.ToolStripMenuItem();
            this.White_Queen = new System.Windows.Forms.ToolStripMenuItem();
            this.White_King = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Black_Pawn = new System.Windows.Forms.ToolStripMenuItem();
            this.Black_Rook = new System.Windows.Forms.ToolStripMenuItem();
            this.Black_Knight = new System.Windows.Forms.ToolStripMenuItem();
            this.Black_Bishop = new System.Windows.Forms.ToolStripMenuItem();
            this.Black_Queen = new System.Windows.Forms.ToolStripMenuItem();
            this.Black_King = new System.Windows.Forms.ToolStripMenuItem();
            this.doneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultyDepthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDif1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDif2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDif3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDif4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDif5 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prgThinking = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitView = new System.Windows.Forms.SplitContainer();
            this.lblBlackCheck = new System.Windows.Forms.Label();
            this.lblWhiteCheck = new System.Windows.Forms.Label();
            this.picTurn = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblWhiteTime = new System.Windows.Forms.Label();
            this.lblBlackTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrWhite = new System.Windows.Forms.Timer(this.components);
            this.tmrBlack = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).BeginInit();
            this.splitView.Panel2.SuspendLayout();
            this.splitView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.difficultyDepthToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAIGame,
            this.newGameToolStripMenuItem,
            this.new2PlayerGameToolStripMenuItem,
            this.endCurrentGameToolStripMenuItem,
            this.toolStripSeparator2,
            this.manualBoardToolStripMenuItem,
            this.setPieceToolStripMenuItem,
            this.doneToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Game";
            // 
            // newAIGame
            // 
            this.newAIGame.Name = "newAIGame";
            this.newAIGame.Size = new System.Drawing.Size(216, 22);
            this.newAIGame.Text = "New AI vs AI Game";
            this.newAIGame.Click += new System.EventHandler(this.NewGame);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.newGameToolStripMenuItem.Text = "New AI vs Player Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.NewGame);
            // 
            // new2PlayerGameToolStripMenuItem
            // 
            this.new2PlayerGameToolStripMenuItem.Name = "new2PlayerGameToolStripMenuItem";
            this.new2PlayerGameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.new2PlayerGameToolStripMenuItem.Text = "New Player vs Player Game";
            this.new2PlayerGameToolStripMenuItem.Click += new System.EventHandler(this.NewGame);
            // 
            // endCurrentGameToolStripMenuItem
            // 
            this.endCurrentGameToolStripMenuItem.Name = "endCurrentGameToolStripMenuItem";
            this.endCurrentGameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.endCurrentGameToolStripMenuItem.Text = "End current game";
            this.endCurrentGameToolStripMenuItem.Click += new System.EventHandler(this.endGame);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // manualBoardToolStripMenuItem
            // 
            this.manualBoardToolStripMenuItem.CheckOnClick = true;
            this.manualBoardToolStripMenuItem.Name = "manualBoardToolStripMenuItem";
            this.manualBoardToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.manualBoardToolStripMenuItem.Text = "Manual Board";
            this.manualBoardToolStripMenuItem.CheckedChanged += new System.EventHandler(this.manualBoardToolStripMenuItem_CheckedChanged);
            // 
            // setPieceToolStripMenuItem
            // 
            this.setPieceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whiteToolStripMenuItem1,
            this.blackToolStripMenuItem1});
            this.setPieceToolStripMenuItem.Enabled = false;
            this.setPieceToolStripMenuItem.Name = "setPieceToolStripMenuItem";
            this.setPieceToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.setPieceToolStripMenuItem.Text = "Set Piece";
            // 
            // whiteToolStripMenuItem1
            // 
            this.whiteToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.White_Pawn,
            this.White_Rook,
            this.White_Knight,
            this.White_Bishop,
            this.White_Queen,
            this.White_King});
            this.whiteToolStripMenuItem1.Name = "whiteToolStripMenuItem1";
            this.whiteToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.whiteToolStripMenuItem1.Text = "White";
            // 
            // White_Pawn
            // 
            this.White_Pawn.Name = "White_Pawn";
            this.White_Pawn.Size = new System.Drawing.Size(110, 22);
            this.White_Pawn.Text = "Pawn";
            this.White_Pawn.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // White_Rook
            // 
            this.White_Rook.Name = "White_Rook";
            this.White_Rook.Size = new System.Drawing.Size(110, 22);
            this.White_Rook.Text = "Rook";
            this.White_Rook.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // White_Knight
            // 
            this.White_Knight.Name = "White_Knight";
            this.White_Knight.Size = new System.Drawing.Size(110, 22);
            this.White_Knight.Text = "Knight";
            this.White_Knight.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // White_Bishop
            // 
            this.White_Bishop.Name = "White_Bishop";
            this.White_Bishop.Size = new System.Drawing.Size(110, 22);
            this.White_Bishop.Text = "Bishop";
            this.White_Bishop.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // White_Queen
            // 
            this.White_Queen.Name = "White_Queen";
            this.White_Queen.Size = new System.Drawing.Size(110, 22);
            this.White_Queen.Text = "Queen";
            this.White_Queen.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // White_King
            // 
            this.White_King.Name = "White_King";
            this.White_King.Size = new System.Drawing.Size(110, 22);
            this.White_King.Text = "King";
            this.White_King.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // blackToolStripMenuItem1
            // 
            this.blackToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Black_Pawn,
            this.Black_Rook,
            this.Black_Knight,
            this.Black_Bishop,
            this.Black_Queen,
            this.Black_King});
            this.blackToolStripMenuItem1.Name = "blackToolStripMenuItem1";
            this.blackToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.blackToolStripMenuItem1.Text = "Black";
            // 
            // Black_Pawn
            // 
            this.Black_Pawn.Name = "Black_Pawn";
            this.Black_Pawn.Size = new System.Drawing.Size(110, 22);
            this.Black_Pawn.Text = "Pawn";
            this.Black_Pawn.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // Black_Rook
            // 
            this.Black_Rook.Name = "Black_Rook";
            this.Black_Rook.Size = new System.Drawing.Size(110, 22);
            this.Black_Rook.Text = "Rook";
            this.Black_Rook.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // Black_Knight
            // 
            this.Black_Knight.Name = "Black_Knight";
            this.Black_Knight.Size = new System.Drawing.Size(110, 22);
            this.Black_Knight.Text = "Knight";
            this.Black_Knight.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // Black_Bishop
            // 
            this.Black_Bishop.Name = "Black_Bishop";
            this.Black_Bishop.Size = new System.Drawing.Size(110, 22);
            this.Black_Bishop.Text = "Bishop";
            this.Black_Bishop.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // Black_Queen
            // 
            this.Black_Queen.Name = "Black_Queen";
            this.Black_Queen.Size = new System.Drawing.Size(110, 22);
            this.Black_Queen.Text = "Queen";
            this.Black_Queen.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // Black_King
            // 
            this.Black_King.Name = "Black_King";
            this.Black_King.Size = new System.Drawing.Size(110, 22);
            this.Black_King.Text = "King";
            this.Black_King.Click += new System.EventHandler(this.manualPieceMenuItem_Click);
            // 
            // doneToolStripMenuItem
            // 
            this.doneToolStripMenuItem.Enabled = false;
            this.doneToolStripMenuItem.Name = "doneToolStripMenuItem";
            this.doneToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.doneToolStripMenuItem.Text = "Done";
            this.doneToolStripMenuItem.Click += new System.EventHandler(this.doneToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Shutdown);
            // 
            // difficultyDepthToolStripMenuItem
            // 
            this.difficultyDepthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDif1,
            this.mnuDif2,
            this.mnuDif3,
            this.mnuDif4,
            this.mnuDif5});
            this.difficultyDepthToolStripMenuItem.Name = "difficultyDepthToolStripMenuItem";
            this.difficultyDepthToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.difficultyDepthToolStripMenuItem.Text = "Difficulty (Depth)";
            // 
            // mnuDif1
            // 
            this.mnuDif1.Name = "mnuDif1";
            this.mnuDif1.Size = new System.Drawing.Size(144, 22);
            this.mnuDif1.Tag = "1";
            this.mnuDif1.Text = "Beginner ( 1 )";
            this.mnuDif1.Click += new System.EventHandler(this.Difficulty);
            // 
            // mnuDif2
            // 
            this.mnuDif2.Name = "mnuDif2";
            this.mnuDif2.Size = new System.Drawing.Size(144, 22);
            this.mnuDif2.Tag = "2";
            this.mnuDif2.Text = "Easy ( 2 )";
            this.mnuDif2.Click += new System.EventHandler(this.Difficulty);
            // 
            // mnuDif3
            // 
            this.mnuDif3.Checked = true;
            this.mnuDif3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuDif3.Name = "mnuDif3";
            this.mnuDif3.Size = new System.Drawing.Size(144, 22);
            this.mnuDif3.Tag = "3";
            this.mnuDif3.Text = "Medium ( 3 )";
            this.mnuDif3.Click += new System.EventHandler(this.Difficulty);
            // 
            // mnuDif4
            // 
            this.mnuDif4.Name = "mnuDif4";
            this.mnuDif4.Size = new System.Drawing.Size(144, 22);
            this.mnuDif4.Tag = "4";
            this.mnuDif4.Text = "Hard ( 4 )";
            this.mnuDif4.Click += new System.EventHandler(this.Difficulty);
            // 
            // mnuDif5
            // 
            this.mnuDif5.Name = "mnuDif5";
            this.mnuDif5.Size = new System.Drawing.Size(144, 22);
            this.mnuDif5.Tag = "5";
            this.mnuDif5.Text = "Insane ( 5 )";
            this.mnuDif5.Click += new System.EventHandler(this.Difficulty);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgThinking,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(634, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prgThinking
            // 
            this.prgThinking.Name = "prgThinking";
            this.prgThinking.Size = new System.Drawing.Size(100, 16);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 17);
            this.lblStatus.Text = "Thinking...";
            // 
            // splitView
            // 
            this.splitView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitView.IsSplitterFixed = true;
            this.splitView.Location = new System.Drawing.Point(0, 24);
            this.splitView.Name = "splitView";
            // 
            // splitView.Panel1
            // 
            this.splitView.Panel1.BackColor = System.Drawing.Color.Gray;
            this.splitView.Panel1.Resize += new System.EventHandler(this.ResizeBoard);
            this.splitView.Panel1MinSize = 400;
            // 
            // splitView.Panel2
            // 
            this.splitView.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitView.Panel2.Controls.Add(this.lblBlackCheck);
            this.splitView.Panel2.Controls.Add(this.lblWhiteCheck);
            this.splitView.Panel2.Controls.Add(this.picTurn);
            this.splitView.Panel2.Controls.Add(this.label3);
            this.splitView.Panel2.Controls.Add(this.txtLog);
            this.splitView.Panel2.Controls.Add(this.lblWhiteTime);
            this.splitView.Panel2.Controls.Add(this.lblBlackTime);
            this.splitView.Panel2.Controls.Add(this.label1);
            this.splitView.Panel2.Controls.Add(this.label2);
            this.splitView.Panel2MinSize = 200;
            this.splitView.Size = new System.Drawing.Size(634, 416);
            this.splitView.SplitterDistance = 414;
            this.splitView.TabIndex = 2;
            // 
            // lblBlackCheck
            // 
            this.lblBlackCheck.AutoSize = true;
            this.lblBlackCheck.Location = new System.Drawing.Point(153, 49);
            this.lblBlackCheck.Name = "lblBlackCheck";
            this.lblBlackCheck.Size = new System.Drawing.Size(50, 13);
            this.lblBlackCheck.TabIndex = 6;
            this.lblBlackCheck.Text = "In Check";
            this.lblBlackCheck.Visible = false;
            // 
            // lblWhiteCheck
            // 
            this.lblWhiteCheck.AutoSize = true;
            this.lblWhiteCheck.Location = new System.Drawing.Point(13, 49);
            this.lblWhiteCheck.Name = "lblWhiteCheck";
            this.lblWhiteCheck.Size = new System.Drawing.Size(50, 13);
            this.lblWhiteCheck.TabIndex = 6;
            this.lblWhiteCheck.Text = "In Check";
            this.lblWhiteCheck.Visible = false;
            // 
            // picTurn
            // 
            this.picTurn.Location = new System.Drawing.Point(89, 12);
            this.picTurn.Name = "picTurn";
            this.picTurn.Size = new System.Drawing.Size(39, 20);
            this.picTurn.TabIndex = 5;
            this.picTurn.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Moves:";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(16, 90);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(187, 264);
            this.txtLog.TabIndex = 3;
            // 
            // lblWhiteTime
            // 
            this.lblWhiteTime.AutoSize = true;
            this.lblWhiteTime.Location = new System.Drawing.Point(13, 32);
            this.lblWhiteTime.Name = "lblWhiteTime";
            this.lblWhiteTime.Size = new System.Drawing.Size(58, 13);
            this.lblWhiteTime.TabIndex = 2;
            this.lblWhiteTime.Text = "00:00:00.0";
            // 
            // lblBlackTime
            // 
            this.lblBlackTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBlackTime.AutoSize = true;
            this.lblBlackTime.Location = new System.Drawing.Point(145, 32);
            this.lblBlackTime.Name = "lblBlackTime";
            this.lblBlackTime.Size = new System.Drawing.Size(58, 13);
            this.lblBlackTime.TabIndex = 2;
            this.lblBlackTime.Text = "00:00:00.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "White";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(156, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Black";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tmrWhite
            // 
            this.tmrWhite.Tick += new System.EventHandler(this.tmrWhite_Tick);
            // 
            // tmrBlack
            // 
            this.tmrBlack.Tick += new System.EventHandler(this.tmrBlack_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.splitView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "MainForm";
            this.Text = "Chess";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.windowClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitView.Panel2.ResumeLayout(false);
            this.splitView.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).EndInit();
            this.splitView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTurn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prgThinking;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.SplitContainer splitView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblWhiteTime;
        private System.Windows.Forms.Label lblBlackTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picTurn;
        private System.Windows.Forms.ToolStripMenuItem new2PlayerGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultyDepthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDif1;
        private System.Windows.Forms.ToolStripMenuItem mnuDif2;
        private System.Windows.Forms.ToolStripMenuItem mnuDif3;
        private System.Windows.Forms.ToolStripMenuItem mnuDif4;
        private System.Windows.Forms.ToolStripMenuItem mnuDif5;
        private System.Windows.Forms.Label lblBlackCheck;
        private System.Windows.Forms.Label lblWhiteCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem manualBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setPieceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem White_Pawn;
        private System.Windows.Forms.ToolStripMenuItem White_Rook;
        private System.Windows.Forms.ToolStripMenuItem White_Knight;
        private System.Windows.Forms.ToolStripMenuItem White_Bishop;
        private System.Windows.Forms.ToolStripMenuItem White_King;
        private System.Windows.Forms.ToolStripMenuItem White_Queen;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Black_Pawn;
        private System.Windows.Forms.ToolStripMenuItem Black_Rook;
        private System.Windows.Forms.ToolStripMenuItem Black_Knight;
        private System.Windows.Forms.ToolStripMenuItem Black_Bishop;
        private System.Windows.Forms.ToolStripMenuItem Black_Queen;
        private System.Windows.Forms.ToolStripMenuItem Black_King;
        private System.Windows.Forms.ToolStripMenuItem endCurrentGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doneToolStripMenuItem;
        private System.Windows.Forms.Timer tmrWhite;
        private System.Windows.Forms.Timer tmrBlack;
        private System.Windows.Forms.ToolStripMenuItem newAIGame;
    }
}

