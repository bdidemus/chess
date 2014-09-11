using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Chess
{
    public partial class MainForm : Form, UIBoard
    {
        private ToolStripMenuItem temp; // selected difficulty
        TimeSpan m_whiteTime = new TimeSpan(0);
        TimeSpan m_blackTime = new TimeSpan(0);

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBoard();

            // setup turn indicator
            picTurn.SizeMode = PictureBoxSizeMode.StretchImage;
            picTurn.Image = graphics.TurnIndicator[Player.WHITE];

            // setup initial ai depth
            temp = mnuDif3;
            AI.DEPTH = 3;

            SetStatus(false, "Choose New Game or Manual Board.");

            // setup menu
            setPieceToolStripMenuItem.Enabled = false;
            manualBoardToolStripMenuItem.Checked = false;
            endCurrentGameToolStripMenuItem.Enabled = false;
        }

        private void windowClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void Shutdown(object sender, EventArgs e)
        {
            Stop();
            this.Close();
        }

        private void endGame(object sender, EventArgs e)
        {
            Stop();
        }

        private void NewGame(object sender, EventArgs e)
        {
            ToolStripMenuItem button = (ToolStripMenuItem)sender;
            if (button.Text.StartsWith("New AI vs AI"))
            {
                NewGame(0);
            }
            else if (button.Text.StartsWith("New AI vs Player"))
            {
                NewGame(1);
            }
            else if (button.Text.StartsWith("New Player"))
            {
                NewGame(2);
            }
        }

        private void Difficulty(object sender, EventArgs e)
        {
            // uncheck previously checked
            if (temp != null)
            {
                temp.CheckState = CheckState.Unchecked;
            }

            // if the ai was currently thinking, stop it
            bool was = AI.RUNNING;
            AI.STOP = true;

            // check the desired difficulty
            temp = (ToolStripMenuItem)sender;
            temp.CheckState = CheckState.Checked;

            // update the ai difficulty
            AI.DEPTH = Int32.Parse((String)temp.Tag);
            LogMove("AI Difficulty " + (string)temp.Tag + "\n");

            // if the ai was running when changed, restart their turn
            if (was)
            {
                LogMove("AI Replaying Move\n");
                new Thread(chess.AISelect).Start();
            }
        }

        private void manualBoardToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked) // turning on manual setup
            {
                m_manualBoard = false;
                doneToolStripMenuItem.Enabled = false;
                m_finalizedBoard = false;
                Stop();

                m_manualBoard = ((ToolStripMenuItem)sender).Checked;
                endCurrentGameToolStripMenuItem.Enabled = true;
                White_King.Enabled = true;
                Black_King.Enabled = true;

                SetStatus(false, "Choose a 1-Player or 2-Player manual game to start placing pieces.");
            }
            else if(!m_finalizedBoard)
            {
                Stop();
            }
        }

        private void manualPieceMenuItem_Click(object sender, EventArgs e)
        {
            String labelName = ((ToolStripMenuItem)sender).Name;

            m_manualPlayer = (labelName.StartsWith("White")) ? Player.WHITE : Player.BLACK;

            if (labelName.EndsWith("Pawn"))
            {
                m_manualPiece = Piece.PAWN;
            }
            else if (labelName.EndsWith("Knight"))
            {
                m_manualPiece = Piece.KNIGHT;
            }
            else if (labelName.EndsWith("Bishop"))
            {
                m_manualPiece = Piece.BISHOP;
            }
            else if (labelName.EndsWith("Rook"))
            {
                m_manualPiece = Piece.ROOK;
            }
            else if (labelName.EndsWith("Queen"))
            {
                m_manualPiece = Piece.QUEEN;
            }
            else if (labelName.EndsWith("King"))
            {
                m_manualPiece = Piece.KING;
            }
        }

        private void doneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no longer building board
            m_manualBoard = false;
            m_finalizedBoard = true;

            // menu changes
            manualBoardToolStripMenuItem.Checked = false;
            setPieceToolStripMenuItem.Enabled = false;
            doneToolStripMenuItem.Enabled = false;

            // start the manual game
            SetStatus(false, "White's Turn");
            tmrWhite.Start();
            m_checkmate = chess.detectCheckmate();

            if (m_aigame && !m_checkmate)
            {
                new Thread(chess.AISelect).Start();
            }
        }

        // ---
        // Player Turn Timer
        // ---
        private void tmrWhite_Tick(object sender, EventArgs e)
        {
            m_whiteTime = m_whiteTime.Add(new TimeSpan(0, 0, 0, 0, tmrWhite.Interval));
            lblWhiteTime.Text = string.Format("{0:d2}:{1:d2}:{2:d2}.{3:d1}", m_whiteTime.Hours, m_whiteTime.Minutes, m_whiteTime.Seconds, m_whiteTime.Milliseconds / 100);
        }

        private void tmrBlack_Tick(object sender, EventArgs e)
        {
            m_blackTime = m_blackTime.Add(new TimeSpan(0, 0, 0, 0, tmrBlack.Interval));
            lblBlackTime.Text = string.Format("{0:d2}:{1:d2}:{2:d2}.{3:d1}", m_blackTime.Hours, m_blackTime.Minutes, m_blackTime.Seconds, m_blackTime.Milliseconds / 100);
        }
    }
}
