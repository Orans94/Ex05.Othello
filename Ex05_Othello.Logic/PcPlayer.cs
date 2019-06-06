using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    public class PcPlayer: Player
    {
        private bool m_isPlayerPlaying = false;

        public override void Play(Board i_GameBoard, GameManager.eGameMode gameMode, out int io_CurrentMoveRowIndex, out int io_CurrentMoveColumnIndex)
        {
            // this method is activating PCPlay method from AI class and calls a message from UI
            UI.PCIsThinkingMessage();
            AI.PCPlay(i_GameBoard, out io_CurrentMoveRowIndex, out io_CurrentMoveColumnIndex);
        }

        public int Score
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

        public string Name
        {
            // a propertie for m_PlayerName
            get
            {

                return m_PlayerName;
            }
        }

        public bool Active
        {
            // a propertie for m_isPlayerPlaying
            get
            {

                return m_isPlayerPlaying;
            }

            set
            {
                m_isPlayerPlaying = value;
            }
        }
    }
}
