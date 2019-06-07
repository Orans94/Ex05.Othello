using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    public class PcPlayer: Player
    {
        public void Play(Board i_GameBoard, out int io_CurrentMoveRowIndex, out int io_CurrentMoveColumnIndex)
        {
            // this method is activating PCPlay method from AI class and calls a message from UI
            AI.PCPlay(i_GameBoard, out io_CurrentMoveRowIndex, out io_CurrentMoveColumnIndex);

        }

        public PcPlayer(Player.ePlayerColor i_PlayerColor)
        {
            m_PlayerColor = i_PlayerColor;
        }
    }
}
