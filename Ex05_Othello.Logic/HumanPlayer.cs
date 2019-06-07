using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    public class HumanPlayer: Player
    {
        public override void Play(Board i_GameBoard, GameLogic.eGameMode i_GameMode, out int o_CurrentMoveRowIndex, out int o_CurrentMoveColumnIndex)
        {
            //TODO: i just put zero in order to assign a value
            o_CurrentMoveRowIndex = 0;
            o_CurrentMoveColumnIndex = 0;
        }

        public HumanPlayer(GameUtilities.ePlayerColor i_PlayerColor)
        {
            // Human player c'tor
            m_PlayerColor = i_PlayerColor;
        }
    }
}
