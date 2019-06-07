using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    abstract public class Player
    {
        protected int m_PlayerScore;
        protected GameUtilities.ePlayerColor m_PlayerColor;

        abstract public void Play(Board i_GameBoard, GameLogic.eGameMode i_GameMode, out int io_CurrentMoveRowIndex, out int io_CurrentMoveColumnIndex);

        public virtual GameUtilities.ePlayerColor Color
        {
            // a propertie for m_PlayerScore
            get
            {

                return m_PlayerColor;
            }

            set
            {
                m_PlayerColor = value;
            }
        }

        public virtual int Score
        {
            // a propertie for m_PlayerScore
            get
            {

                return m_PlayerScore;
            }

            set
            {
                m_PlayerScore = value;
            }
        }
    }
}
