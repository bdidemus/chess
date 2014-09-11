using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    public interface UIBoard
    {
        void SetBoard(ChessBoard board);
        void LogMove(string line);
        void SetStatus(bool thinking, string message);
        void SetTurn(Player p);
    }
}
