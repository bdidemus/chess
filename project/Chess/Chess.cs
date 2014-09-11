using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Chess
{
    public class Chess
    {
        public ChessBoard Board { get; private set; }
        public Player Turn { get; private set; }
        public position_t Selection { get; private set; }

        private UIBoard m_UI;
        private int m_nPlayers;

        public Chess(UIBoard ui, int nPlayers = 1, bool setupBoard = true)
        {
            // callback setup
            this.m_UI = ui;
            this.m_UI.SetStatus(true, "Generating...");


            // number of players = {0, 1, 2}
            this.m_nPlayers = nPlayers;
            // white always starts
            this.Turn = Player.WHITE;

            // create a new blank board unless setup is true
            this.Board = new ChessBoard();
            if (setupBoard)
            {
                this.Board.SetInitialPlacement();
            }

            // update ui
            this.m_UI.SetBoard(Board);
            this.m_UI.SetStatus(false, "White's turn.");
        }

        public void AISelect()
        {
            // wait for previous ai thread to stop
            while (AI.RUNNING)
            {
                Thread.Sleep(100);
            }

            // ai is dump
            this.m_UI.SetStatus(true, "Thinking...");

            // calculate move
            move_t move = AI.MiniMaxAB(this.Board, this.Turn);

            // if valid move, make the move
            if (move.to.letter >= 0 && move.to.number >= 0)
            {
                MakeMove(move);
            }
            else // if invalid move 
            {
                if (!AI.STOP) // and not caused by AI interupt
                {
                    // fuuuuuu
                    this.m_UI.LogMove("Null Move\n");
                }
            }

            bool checkmate = false;

            // if the AI wasn't interupted finish our turn
            if (!AI.STOP)
            {
                switchPlayer();
                checkmate = detectCheckmate();
            }

            // we're done now
            AI.RUNNING = false;

            // if the AI wan't interupted 
            // and we're in AI vs AI mode
            // and not in checkmate/stalemate
            // start the next AI's turn
            if (!AI.STOP && this.m_nPlayers == 0 && !checkmate)
            {
                new Thread(AISelect).Start();
            }
        }

        public List<position_t> Select(position_t pos)
        {
            // has previously selected something
            if (this.Board.Grid[this.Selection.number][this.Selection.letter].piece != Piece.NONE
                && this.Turn == this.Board.Grid[this.Selection.number][this.Selection.letter].player
                && (this.m_nPlayers == 2 
                || this.Turn == Player.WHITE)) 
            {
                // get previous selections moves and determine if we chose a legal one by clicking
                List<position_t> moves = LegalMoveSet.getLegalMove(this.Board, this.Selection);
                foreach (position_t move in moves)
                {
                    if (move.Equals(pos))
                    {
                        // we selected a legal move so update the board
                        MakeMove(new move_t(this.Selection, pos));

                        // If piece that was just moved is a king and it moved anyhthing other than 1 square, it was 
                        // a castling move, so we need to move the rook
                        if (this.Board.Grid[pos.number][pos.letter].piece == Piece.KING && Math.Abs(pos.letter - this.Selection.letter) == 2)
                        {
                            int row = (this.Turn == Player.WHITE) ? 0 : 7;

                            // Left rook
                            if (pos.letter < 4)
                            {
                                LegalMoveSet.move(this.Board, new move_t(new position_t(0, row), new position_t(3, row)));
                            }
                            // right rook
                            else
                            {
                                LegalMoveSet.move(this.Board, new move_t(new position_t(7, row), new position_t(5, row)));
                            }
                        }
                                
                        // finish move
                        switchPlayer();
                        if (detectCheckmate()) return new List<position_t>();

                        if (this.m_nPlayers == 1) // start ai
                        {
                            new Thread(AISelect).Start(); // thread turn
                        }
                        return new List<position_t>();
                    }
                }
            }

            // first click, let's show possible moves
            if (this.Board.Grid[pos.number][pos.letter].player == this.Turn && (this.m_nPlayers == 2 || this.Turn == Player.WHITE))
            {
                List<position_t> moves = LegalMoveSet.getLegalMove(this.Board, pos);
                this.Selection = pos;
                return moves;
            }

            // reset
            this.Selection = new position_t();
            return new List<position_t>();
        }

        private void MakeMove(move_t m)
        {
            // start move log output
            string move = (this.Turn == Player.WHITE) ? "W" : "B";

            move += ":\t";

            // piece
            switch (this.Board.Grid[m.from.number][m.from.letter].piece)
            {
                case Piece.PAWN:
                    move += "P";
                    break;
                case Piece.ROOK:
                    move += "R";
                    break;
                case Piece.KNIGHT:
                    move += "k";
                    break;
                case Piece.BISHOP:
                    move += "B";
                    break;
                case Piece.QUEEN:
                    move += "Q";
                    break;
                case Piece.KING:
                    move += "K";
                    break;
            }

            // kill
            if (this.Board.Grid[m.to.number][m.to.letter].piece != Piece.NONE || LegalMoveSet.isEnPassant(this.Board, m))
            {
                move += "x";
            }

            // letter
            switch (m.to.letter)
            {
                case 0: move += "a"; break;
                case 1: move += "b"; break;
                case 2: move += "c"; break;
                case 3: move += "d"; break;
                case 4: move += "e"; break;
                case 5: move += "f"; break;
                case 6: move += "g"; break;
                case 7: move += "h"; break;
            }

            // number
            move += (m.to.number + 1).ToString();

            // update board / make actual move
            this.Board = LegalMoveSet.move(this.Board, m);

            // if that move put someone in check
            if (LegalMoveSet.isCheck(this.Board, (Turn == Player.WHITE) ? Player.BLACK : Player.WHITE))
            {
                move += "+";
            }

            // show log
            this.m_UI.LogMove(move + "\n");
        }

        /// <summary>
        /// Toggle who's turn it is
        /// </summary>
        private void switchPlayer()
        {
            this.Turn = (this.Turn == Player.WHITE) ? Player.BLACK : Player.WHITE;
            this.m_UI.SetTurn(this.Turn);
            this.m_UI.SetStatus(false, ((this.Turn == Player.WHITE) ? "White" : "Black") + "'s Turn.");
            this.m_UI.SetBoard(this.Board);
        }

        /// <summary>
        /// Detects Checkmate, Stalemate or Draw conditions.
        /// </summary>
        /// <returns>True if no legal moves, or only kings left.</returns>
        public bool detectCheckmate()
        {
            bool wkingonly = this.Board.Pieces[Player.WHITE].Count == 1 && this.Board.Grid[this.Board.Pieces[Player.WHITE][0].number][this.Board.Pieces[Player.WHITE][0].letter].piece == Piece.KING;
            bool bkingonly = this.Board.Pieces[Player.BLACK].Count == 1 && this.Board.Grid[this.Board.Pieces[Player.BLACK][0].number][this.Board.Pieces[Player.BLACK][0].letter].piece == Piece.KING;

            if (!LegalMoveSet.hasMoves(this.Board, this.Turn))
            {
                if (LegalMoveSet.isCheck(this.Board, this.Turn))
                {
                    this.m_UI.LogMove("Checkmate!\n");
                    this.m_UI.SetStatus(false, ((this.Turn == Player.WHITE) ? "Black" : "White") + " wins!");
                }
                else
                {
                    this.m_UI.LogMove("Stalemate!\n");
                }
                return true;
            }
            else if (wkingonly && bkingonly)
            {
                this.m_UI.LogMove("Draw.\n");
                return true;
            }
            return false;
        }
    }
}
