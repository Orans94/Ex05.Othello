using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    abstract public class Player
    {
        public enum ePlayerColor
        {
            Black = 1,
            White = 0
        }
        
        protected int m_CurrentRoundPlayerScore;
        protected int m_OverallPlayerScore = 0;
        protected ePlayerColor m_PlayerColor;

        abstract public void Play(Board i_GameBoard, GameLogic.eGameMode i_GameMode, out int io_CurrentMoveRowIndex, out int io_CurrentMoveColumnIndex);

        public virtual ePlayerColor Color
        {
            // a propertie for m_CurrentRoundPlayerScore
            get
            {
                
                return m_PlayerColor;
            }

            set
            {
                m_PlayerColor = value;
            }
        }

        public virtual int OverallScore
        {
            // a propertie for m_OverallPlayerScore
            get
            {

                return m_OverallPlayerScore;
            }

            set
            {
                m_OverallPlayerScore = value;
            }
        }

        public virtual int RoundScore
        {
            // a propertie for m_PlayerScore
            get
            {

                return m_CurrentRoundPlayerScore;
            }

            set
            {
                m_CurrentRoundPlayerScore = value;
            }
        }
    }
}
