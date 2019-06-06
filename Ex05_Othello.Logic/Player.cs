using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    abstract public class Player
    {
        private int m_PlayerScore;
        GameUtilities.ePlayerColor m_PlayerColor;

        abstract public void Play(Board i_GameBoard, GameLogic.eGameMode i_GameMode, out int io_CurrentMoveRowIndex, out int io_CurrentMoveColumnIndex);
    }
}
