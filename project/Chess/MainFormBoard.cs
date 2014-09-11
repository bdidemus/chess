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
        const int PADDING = 10;
        const string DATA_PATH = "../../data/";

        private PictureBox[][] Board;
        Graphics graphics = new Graphics(DATA_PATH);

        private void CreateBoard()
        {
            // create the board pieces
            Board = new PictureBox[8][];
            for (int i = 0; i < 8; i++)
            {
                Board[i] = new PictureBox[8];
                for (int j = 0; j < 8; j++)
                {
                    Board[i][j] = new PictureBox();
                    Board[i][j].Parent = this.splitView.Panel1;
                    Board[i][j].Click += BoardClick;
                    Board[i][j].BackColor = ((j + i) % 2 == 0) ? Color.Black : Color.White;
                    Board[i][j].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }

            // align the board
            ResizeBoard(null, null);
        }

        private void ResizeBoard(object sender, EventArgs e)
        {
            // make sure board is initialized
            if (Board == null || Board[0] == null || Board[0][0] == null) return;

            // smallest of height or width
            int val = Math.Min(this.splitView.Panel1.Height - PADDING * 2, this.splitView.Panel1.Width - PADDING * 2);

            // 8 x 8 grid
            int width = val / 8;
            int height = val / 8;

            // center padding/spacing like { margin: auto auto; }
            int left = (this.splitView.Panel1.Width - val) / 2;
            int top = (this.splitView.Panel1.Height - val) / 2;

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Board[i][j].Left = j * width + left;
                    Board[i][j].Top = val - (i + 1) * height + top;
                    Board[i][j].Width = width;
                    Board[i][j].Height = height;
                }
        }

        private void SetPiece(Piece piece, Player player, int letter, int number)
        {
            // if a thread called this, invoke recursion
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetPiece(piece, player, letter, number)));
                return;
            }

            // out of bounds
            if (letter < 0 || letter > 7 || number < 0 || number > 7)
                return; // throw new IndexOutOfRangeException("Chess board letter or number out of range");

            // clear tile
            if (piece == Piece.NONE)
            {
                Board[number][letter].Image = null;
                Board[number][letter].Invalidate();
                return;
            }

            // update our render
            Board[number][letter].Image = graphics.Pieces[player][piece];
            Board[number][letter].Invalidate();
        }

        private void BoardClick(object sender, EventArgs e)
        {
            if (chess != null && !m_checkmate)
            {
                // clear board
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        Board[i][j].BackColor = ((i + j) % 2 == 0) ? Color.Black : Color.White;

                for (int i = 0; i < 8; i++)
                {
                    int k = Array.IndexOf(Board[i], sender);
                    if (k > -1)
                    {
                        // draw highlighting
                        if ((!m_manualBoard || m_finalizedBoard) && !m_aigame)
                        {
                            List<position_t> moves = chess.Select(new position_t(k, i));
                            foreach (position_t move in moves)
                            {
                                if ((chess.Board.Grid[move.number][move.letter].player != chess.Turn
                                    && chess.Board.Grid[move.number][move.letter].piece != Piece.NONE)
                                    || LegalMoveSet.isEnPassant(chess.Board, new move_t(chess.Selection, move)))
                                {
                                    // attack
                                    Board[move.number][move.letter].BackColor = Color.Red;
                                }
                                else
                                {
                                    // move
                                    Board[move.number][move.letter].BackColor = Color.Yellow;
                                }
                            }
                        }
                        // place piece
                        else
                        {
                            chess.Board.SetPiece(m_manualPiece, m_manualPlayer, k, i);
                            SetPiece(m_manualPiece, m_manualPlayer, k, i);

                            if (m_manualPiece == Piece.KING)
                            {
                                if (m_manualPlayer == Player.WHITE)
                                {
                                    White_King.Enabled = false;
                                }
                                else
                                {
                                    Black_King.Enabled = false;
                                }

                                // both players have kings, we could technically start
                                if (!White_King.Enabled && !Black_King.Enabled)
                                {
                                    doneToolStripMenuItem.Enabled = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
