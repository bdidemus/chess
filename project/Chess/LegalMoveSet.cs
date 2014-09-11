using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class LegalMoveSet
    {        
        /// <summary>
        /// Performs all necessary steps to update the game state and move the pieces.
        /// </summary>
        /// <param name="b">The state of the game.</param>
        /// <param name="m">The desired move.</param>
        /// <returns>The new state of the game.</returns>
        public static ChessBoard move(ChessBoard b, move_t m)
        {
            // create a copy of the board
            ChessBoard b2 = new ChessBoard(b); 

            // determine if move is enpassant or castling
            bool enpassant = (b2.Grid[m.from.number][m.from.letter].piece == Piece.PAWN && isEnPassant(b2, m));
            bool castle = (b2.Grid[m.from.number][m.from.letter].piece == Piece.KING && Math.Abs(m.to.letter - m.from.letter) == 2);

            // update piece list, remove old position from piece list for moving player
            b2.Pieces[b2.Grid[m.from.number][m.from.letter].player].Remove(m.from);

            // if move kills a piece directly, remove killed piece from killed player piece list
            if (b2.Grid[m.to.number][m.to.letter].piece != Piece.NONE && b2.Grid[m.from.number][m.from.letter].player != b2.Grid[m.to.number][m.to.letter].player)
                b2.Pieces[b2.Grid[m.to.number][m.to.letter].player].Remove(m.to);
            else if(enpassant) 
            {
                // if kill was through enpassant determine which direction and remove the killed pawn
                int step = (b.Grid[m.from.number][m.from.letter].player == Player.WHITE) ? -1 : 1;
                b2.Pieces[b2.Grid[m.to.number + step][m.to.letter].player].Remove(new position_t(m.to.letter, m.to.number + step));
            }
            else if (castle)
            {
                // if no kill but enpassant, update the rook position
                if (m.to.letter == 6)
                {
                    b2.Pieces[b2.Grid[m.to.number][m.to.letter].player].Remove(new position_t(7, m.to.number));
                    b2.Pieces[b2.Grid[m.to.number][m.to.letter].player].Add(new position_t(5, m.to.number));
                }
                else
                {
                    b2.Pieces[b2.Grid[m.to.number][m.to.letter].player].Remove(new position_t(0, m.to.number));
                    b2.Pieces[b2.Grid[m.to.number][m.to.letter].player].Remove(new position_t(3, m.to.number));
                }
            }

            // add the new piece location to piece list
            b2.Pieces[b2.Grid[m.from.number][m.from.letter].player].Add(m.to);

            // update board grid
            b2.Grid[m.to.number][m.to.letter] = new piece_t(b2.Grid[m.from.number][m.from.letter]);
            b2.Grid[m.to.number][m.to.letter].lastPosition = m.from;
            b2.Grid[m.from.number][m.from.letter].piece = Piece.NONE;
            if (enpassant)
            {
                // if kill was through enpassant determine which direction and remove the killed pawn
                int step = (b.Grid[m.from.number][m.from.letter].player == Player.WHITE) ? -1 : 1;
                b2.Grid[m.to.number + step][m.to.letter].piece = Piece.NONE;
            }
            else if (castle)
            {
                // if no kill but enpassant, update the rook position
                if (m.to.letter == 6)
                {
                    b2.Grid[m.to.number][5] = new piece_t(b2.Grid[m.to.number][7]);
                    b2.Grid[m.to.number][7].piece = Piece.NONE;
                }
                else
                {
                    b2.Grid[m.to.number][3] = new piece_t(b2.Grid[m.to.number][0]);
                    b2.Grid[m.to.number][0].piece = Piece.NONE;
                }
            }


            //promotion
            if (b2.Grid[m.to.number][m.to.letter].piece == Piece.PAWN)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (b2.Grid[0][i].piece == Piece.PAWN)
                        b2.Grid[0][i].piece = Piece.QUEEN;
                    if (b2.Grid[7][i].piece == Piece.PAWN)
                        b2.Grid[7][i].piece = Piece.QUEEN;
                }
            }

            // update king position
            if (b2.Grid[m.to.number][m.to.letter].piece == Piece.KING)
            {
                b2.Kings[b2.Grid[m.to.number][m.to.letter].player] = m.to;
            }

            // update last move 
            b2.LastMove[b2.Grid[m.to.number][m.to.letter].player] = m.to;

            return b2;
        }

        /// <summary>
        /// Determine if the provided player has any valid moves.
        /// </summary>
        /// <param name="b">The state of the game.</param>
        /// <param name="player">The player.</param>
        /// <returns>True if the player has moves.</returns>
        public static bool hasMoves(ChessBoard b, Player player)
        {
            foreach(position_t pos in b.Pieces[player])
                if (b.Grid[pos.number][pos.letter].piece != Piece.NONE && 
                    b.Grid[pos.number][pos.letter].player == player && 
                    getLegalMove(b, pos).Count > 0) return true;
            return false;
        }

        /// <summary>
        /// Get all legal moves for the player on the current board.
        /// </summary>
        /// <param name="b">The state of the game.</param>
        /// <param name="player">The player whose moves you want.</param>
        /// <returns>A 1-to-many dictionary of moves from one position to many</returns>
        public static Dictionary<position_t, List<position_t>> getPlayerMoves(ChessBoard b, Player player)
        {
            Dictionary<position_t, List<position_t>> moves = new Dictionary<position_t, List<position_t>>();
            foreach (position_t pos in b.Pieces[player])
                if (b.Grid[pos.number][pos.letter].piece != Piece.NONE)
                {
                    if (!moves.ContainsKey(pos)) moves[pos] = new List<position_t>();
                    moves[pos].AddRange(LegalMoveSet.getLegalMove(b, pos));
                }
            return moves;
        }

        /// <summary>
        /// Get any legal move from the current position on the provided board.
        /// </summary>
        /// <param name="board">The state of the game.</param>
        /// <param name="pos">The piece/position to check for valid moves.</param>
        /// <param name="verify_check">Whether or not to recurse and check if the current move puts you in check.</param>
        /// <returns>A list of positions the piece can move to.</returns>
        public static List<position_t> getLegalMove(ChessBoard board, position_t pos, bool verify_check = true)
        {
            piece_t p = board.Grid[pos.number][pos.letter];
            if (p.piece == Piece.NONE) return new List<position_t>();

            switch (p.piece)
            {
                case Piece.PAWN:
                    return LegalMoveSet.Pawn(board, pos, verify_check);
                case Piece.ROOK:
                    return LegalMoveSet.Rook(board, pos, verify_check);
                case Piece.KNIGHT:
                    return LegalMoveSet.Knight(board, pos, verify_check);
                case Piece.BISHOP:
                    return LegalMoveSet.Bishop(board, pos, verify_check);
                case Piece.QUEEN:
                    return LegalMoveSet.Queen(board, pos, verify_check);
                case Piece.KING:
                    return LegalMoveSet.King(board, pos, verify_check);
                default:
                    return new List<position_t>();
            }
        }

        /// <summary>
        /// Slide along the path steps until you hit something. Return path to point and if it ends attacking with the attack.
        /// </summary>
        private static List<position_t> Slide(ChessBoard board, Player p, position_t pos, position_t step)
        {
            List<position_t> moves = new List<position_t>();
            for (int i = 1; i < 8; i++)
            {
                position_t moved = new position_t(pos.letter + i * step.letter, pos.number + i * step.number);

                if (moved.letter < 0 || moved.letter > 7 || moved.number < 0 || moved.number > 7)
                    break;

                if (board.Grid[moved.number][moved.letter].piece != Piece.NONE)
                {
                    if (board.Grid[moved.number][moved.letter].player != p)
                        moves.Add(moved);
                    break;
                }
                moves.Add(moved);
            }
            return moves;
        }

        /// <summary>
        /// Checks to see if the king for a player is in check. This function
        /// works by pretending the king is each of the different board pieces and seeing if it can attack
        /// any of the same type of price from its current position.
        /// </summary>
        /// <param name="b">Board state</param>
        /// <param name="king">the currnet player</param>
        /// <returns>Is in check</returns>
        public static bool isCheck(ChessBoard b, Player king)
        {
            if (b.Kings.Count == 0) return true;

            position_t king_pos = b.Kings[king];
            if (king_pos.number < 0 || king_pos.letter < 0) return true;

            Piece[] pieces = { Piece.PAWN, Piece.ROOK, Piece.KNIGHT, Piece.BISHOP, Piece.QUEEN, Piece.KING };

            ChessBoard tempBoard = new ChessBoard(b);

            for (int i = 0; i < 6; i++)
            {
                tempBoard.Grid[king_pos.number][king_pos.letter] = new piece_t(pieces[i], king);
                List<position_t> moves = getLegalMove(tempBoard, king_pos, false);
                foreach (var move in moves)
                {
                    if (b.Grid[move.number][move.letter].piece == pieces[i] &&
                        b.Grid[move.number][move.letter].player != king)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static List<position_t> King(ChessBoard board, position_t pos, bool verify_check = true)
        {
            List<position_t> moves = new List<position_t>();

            piece_t p = board.Grid[pos.number][pos.letter];
            if (p.piece == Piece.NONE) return moves;

            // collect all relative moves possible
            List<position_t> relative = new List<position_t>();

            relative.Add(new position_t(-1, 1));
            relative.Add(new position_t(0, 1));
            relative.Add(new position_t(1, 1));

            relative.Add(new position_t(-1, 0));
            relative.Add(new position_t(1, 0));

            relative.Add(new position_t(-1, -1));
            relative.Add(new position_t(0, -1));
            relative.Add(new position_t(1, -1));

            // Iterate moves
            foreach (position_t move in relative)
            {
                position_t moved = new position_t(move.letter + pos.letter, move.number + pos.number);

                // bound check
                if (moved.letter < 0 || moved.letter > 7 || moved.number < 0 || moved.number > 7)
                    continue;

                // if it's not blocked we can move
                if (board.Grid[moved.number][moved.letter].piece == Piece.NONE || board.Grid[moved.number][moved.letter].player != p.player)
                {
                    if (verify_check) // make sure we don't put ourselves in check
                    {
                        ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, moved));
                        if(!isCheck(b2, p.player))
                        {
                            moves.Add(moved);
                        }
                    }
                    else
                    {
                        moves.Add(moved);
                    }
                }
            }
			
			// Castling
            /* A king can only castle if:
             * king has not moved
             * rook has not moved
             * king is not in check
             * king does not end up in check
             * king does not pass through any other peieces
             * king does not pass through any squares under attack
             * king knows secret handshake
             */
            if (verify_check)
            {
                if (!isCheck(board, p.player)
                    && p.lastPosition.Equals(new position_t(-1,-1)))
                {
                    bool castleRight = allowCastle(board, p.player, pos, true);
                    bool castleLeft = allowCastle(board, p.player, pos, false);

                    if (castleRight)
                    {
                        moves.Add(new position_t(6, pos.number));
                    }
                    if (castleLeft)
                    {
                        moves.Add(new position_t(2, pos.number));
                    }
                }
            }

            return moves;
        }

        private static bool allowCastle(ChessBoard board, Player player, position_t pos, bool isRight)
        {
            bool isValid = true;
            int rookPos;
            int kingDirection;
            if (isRight)
            {
                rookPos = 7;
                kingDirection = 1;
            }
            else
            {
                rookPos = 0;
                kingDirection = -1;
            }

            //Check for valid right castling
            // Is the peice at H,7 a rook owned by the player and has it moved
            if (board.Grid[pos.number][rookPos].piece == Piece.ROOK &&
                board.Grid[pos.number][rookPos].player == player && board.Grid[pos.number][rookPos].lastPosition.Equals(new position_t(-1,-1)))
            {
                // Check that the adjacent two squares are empty
                for (int i = 0; i < 2; i++)
                {
                    if (board.Grid[pos.number][pos.letter + (i + 1) * kingDirection].piece != Piece.NONE)
                    {
                        isValid = false;
                        break;
                    }
                }

                // Don't bother running secondary checks if the way isn't even clear
                if (isValid)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        // Move kings postion over i squares to check if king is passing over an attackable
                        // square
                        ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, new position_t(pos.letter + (i + 1) * kingDirection, pos.number)));

                        // Attackable square is in between king and rook so
                        // its not possible to castle to the right rook
                        if (isCheck(b2, player))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }

        private static List<position_t> Queen(ChessBoard board, position_t pos, bool verify_check = true)
        {
            List<position_t> moves = new List<position_t>();

            piece_t p = board.Grid[pos.number][pos.letter];
            if (p.piece == Piece.NONE) return moves;

            // horizontal/vertical
            moves.AddRange(Slide(board, p.player, pos, new position_t(1, 0)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(-1, 0)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(0, 1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(0, -1)));

            // diagonals
            moves.AddRange(Slide(board, p.player, pos, new position_t(1, 1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(-1, -1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(-1, 1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(1, -1)));

            if (verify_check) // make sure each move doesn't put us in check
            {
                for (int i = moves.Count - 1; i >= 0; i--)
                {
                    ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, moves[i]));
                    if (isCheck(b2, p.player))
                    {
                        moves.RemoveAt(i);
                    }
                }
            }
            return moves;
        }

        private static List<position_t> Bishop(ChessBoard board, position_t pos, bool verify_check = true)
        {
            List<position_t> moves = new List<position_t>();

            piece_t p = board.Grid[pos.number][pos.letter];
            if (p.piece == Piece.NONE) return moves;

            // slide along diagonals to find available moves
            moves.AddRange(Slide(board, p.player, pos, new position_t(1, 1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(-1, -1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(-1, 1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(1, -1)));

            if (verify_check) // make sure each move doesn't put us in check
            {
                for (int i = moves.Count - 1; i >= 0; i--)
                {
                    ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, moves[i]));
                    if (isCheck(b2, p.player))
                    {
                        moves.RemoveAt(i);
                    }
                }
            }
            return moves;
        }

        private static List<position_t> Knight(ChessBoard board, position_t pos, bool verify_check = true)
        {
            List<position_t> moves = new List<position_t>();

            piece_t p = board.Grid[pos.number][pos.letter];
            if (p.piece == Piece.NONE) return moves;

            // collect all relative moves possible
            List<position_t> relative = new List<position_t>();

            relative.Add(new position_t(2, 1));
            relative.Add(new position_t(2, -1));

            relative.Add(new position_t(-2, 1));
            relative.Add(new position_t(-2, -1));

            relative.Add(new position_t(1, 2));
            relative.Add(new position_t(-1, 2));

            relative.Add(new position_t(1, -2));
            relative.Add(new position_t(-1, -2));

            // iterate moves
            foreach (position_t move in relative)
            {
                position_t moved = new position_t(move.letter + pos.letter, move.number + pos.number);

                // bounds check
                if (moved.letter < 0 || moved.letter > 7 || moved.number < 0 || moved.number > 7)
                    continue;

                // if empty space or attacking
                if (board.Grid[moved.number][moved.letter].piece == Piece.NONE ||
                    board.Grid[moved.number][moved.letter].player != p.player) 
                    moves.Add(moved);
            }

            if (verify_check)// make sure each move doesn't put us in check
            {
                for (int i = moves.Count - 1; i >= 0; i--)
                {
                    ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, moves[i]));
                    if (isCheck(b2, p.player))
                    {
                        moves.RemoveAt(i);
                    }
                }
            }
            return moves;
        }

        private static List<position_t> Rook(ChessBoard board, position_t pos, bool verify_check = true)
        {
            List<position_t> moves = new List<position_t>();

            piece_t p = board.Grid[pos.number][pos.letter];
            if (p.piece == Piece.NONE) return moves;

            // slide along vert/hor for possible moves
            moves.AddRange(Slide(board, p.player, pos, new position_t(1, 0)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(-1, 0)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(0, 1)));
            moves.AddRange(Slide(board, p.player, pos, new position_t(0, -1)));

            if (verify_check)// make sure each move doesn't put us in check
            {
                for (int i = moves.Count - 1; i >= 0; i--)
                {
                    ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, moves[i]));
                    if (isCheck(b2, p.player))
                    {
                        moves.RemoveAt(i);
                    }
                }
            }
            return moves;
        }

        private static List<position_t> Pawn(ChessBoard board, position_t pos, bool verify_check = true)
        {
            List<position_t> moves = new List<position_t>();

            piece_t p = board.Grid[pos.number][pos.letter];
            if (p.piece == Piece.NONE) return moves;

            // gather relative moves
            List<position_t> relative = new List<position_t>();
            relative.Add(new position_t(-1, 1 * ((p.player == Player.BLACK) ? -1 : 1)));
            relative.Add(new position_t(0, 1 * ((p.player == Player.BLACK) ? -1 : 1)));
            relative.Add(new position_t(0, 2 * ((p.player == Player.BLACK) ? -1 : 1)));
            relative.Add(new position_t(1, 1 * ((p.player == Player.BLACK) ? -1 : 1)));

            // iterate moves
            foreach (position_t move in relative)
            {
                position_t moved = new position_t(move.letter + pos.letter, move.number + pos.number);

                // bounds check
                if (moved.letter < 0 || moved.letter > 7 || moved.number < 0 || moved.number > 7)
                    continue;

                // double forward move
                if (moved.letter == pos.letter && board.Grid[moved.number][moved.letter].piece == Piece.NONE && Math.Abs(moved.number - pos.number) == 2)
                {
                    // check the first step
                    int step = -((moved.number - pos.number) / (Math.Abs(moved.number - pos.number)));
                    bool hasnt_moved = pos.number == ((p.player == Player.BLACK) ? 6 : 1);
                    if (board.Grid[moved.number + step][moved.letter].piece == Piece.NONE && hasnt_moved)
                    {
                        moves.Add(moved);
                    }
                }
                // if it's not blocked we can move forward
                else if (moved.letter == pos.letter && board.Grid[moved.number][moved.letter].piece == Piece.NONE)
                {
                    moves.Add(moved);
                }
                // angled attack
                else if (moved.letter != pos.letter && board.Grid[moved.number][moved.letter].piece != Piece.NONE && board.Grid[moved.number][moved.letter].player != p.player)
                {
                    moves.Add(moved);
                }
                // en passant
                else if(isEnPassant(board, new move_t(pos,moved)))
                {
                    moves.Add(moved);
                }
            }

            if (verify_check)// make sure each move doesn't put us in check
            {
                for (int i = moves.Count - 1; i >= 0; i--)
                {
                    ChessBoard b2 = LegalMoveSet.move(board, new move_t(pos, moves[i]));
                    if (isCheck(b2, p.player))
                    {
                        moves.RemoveAt(i);
                    }
                }
            }
            return moves;
        }

        public static bool isEnPassant(ChessBoard b, move_t m)
        {
            // step = where opposite pawn is
            int step = ((b.Grid[m.from.number][m.from.letter].player == Player.WHITE) ? -1 : 1);

            // true if
            // move is pawn
            // space is blank
            // move is diagonal
            // opposite pawn exists at step
            // the last move for opposite player was the pawn
            // the last move for opposite pawn was the double jump
            return (
                b.Grid[m.from.number][m.from.letter].piece == Piece.PAWN &&
                b.Grid[m.to.number][m.to.letter].piece == Piece.NONE &&
                m.to.letter != m.from.letter &&
                b.Grid[m.to.number + step][m.to.letter].piece == Piece.PAWN &&
                b.LastMove[(b.Grid[m.from.number][m.from.letter].player == Player.WHITE) ? Player.BLACK : Player.WHITE].Equals(new position_t(m.to.letter, m.to.number + step)) &&
                Math.Abs(b.Grid[m.to.number + step][m.to.letter].lastPosition.number - (m.to.number + step)) == 2 //jumped from last position
                );
        }
    }
}
