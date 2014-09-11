using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chess
{
    public class Graphics
    {
        private string data_dir;
        public Dictionary<Player,Dictionary<Piece, Image>> Pieces { get; private set; }
        public Dictionary<Player, Image> TurnIndicator { get; private set; }

        public Graphics(string path)
        {
            data_dir = path;

            LoadGraphics();   
        }

        /// <summary>
        /// Load the graphices only once into a dictionary for quicker drawing
        /// </summary>
        private void LoadGraphics()
        {
            TurnIndicator = new Dictionary<Player, Image>();
            TurnIndicator[Player.WHITE] = Bitmap.FromFile(data_dir + "turn_w.png");
            TurnIndicator[Player.BLACK] = Bitmap.FromFile(data_dir + "turn_b.png");

            Pieces = new Dictionary<Player, Dictionary<Piece, Image>>();
            foreach (Player pl in Enum.GetValues(typeof(Player)))
            {
                Pieces[pl] = new Dictionary<Piece, Image>();

                foreach (Piece p in Enum.GetValues(typeof(Piece)))
                {
                    string file = data_dir;

                    switch (p)
                    {
                        case Piece.PAWN:
                            file += "pawn";
                            break;
                        case Piece.ROOK:
                            file += "rook";
                            break;
                        case Piece.KNIGHT:
                            file += "knight";
                            break;
                        case Piece.BISHOP:
                            file += "bishop";
                            break;
                        case Piece.QUEEN:
                            file += "queen";
                            break;
                        case Piece.KING:
                            file += "king";
                            break;
                        case Piece.NONE:
                            continue;
                    }

                    file += "_";

                    switch (pl)
                    {
                        case Player.BLACK:
                            file += "b";
                            break;
                        case Player.WHITE:
                            file += "w";
                            break;
                    }

                    file += ".png";

                    Pieces[pl][p] = Bitmap.FromFile(file);
                }
            }
        }
    }
}
