using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    public class GameLogic
    {
        public enum eGameMode
        {
            HumanVsHuman = 1,
            HumanVsPC = 2
        }

        public enum eGameDecision
        {
            Rematch = 1,
            Exit = 2
        }

        public enum eDirection
        {
            Up = -1,
            Down = 1,
            Left = -1,
            Right = 1,
            NoDirection = 0
        }

        private Board m_GameBoard;
        private List<Cell> m_BlackPlayerOptions = new List<Cell>();
        private List<Cell> m_WhitePlayerOptions = new List<Cell>();
        private GameUtilities.ePlayerColor m_PlayerTurn;
        private eGameMode m_GameMode;

        public void configureGameSettings(Board.eBoardSize i_BoardSize, eGameMode i_GameMode)
        {
            m_GameBoard = new Board(i_BoardSize);
            m_GameMode = i_GameMode;
            if (userGameModeChoice == eGameMode.HumanVsHuman)
            {
                i_BlackHumanPlayer.Active = true;
                blackPlayerName = UI.AskUserForUserName();
                i_BlackHumanPlayer.Name = blackPlayerName;
            }
            else
            {
                i_BlackPCPlayer.Active = true;
            }
        }

        public List<Cell> WhitePlayerOptions
        {
            // a propertie for m_WhitePlayerOptions
            get
            {

                return m_WhitePlayerOptions;
            }
        }

        public GameUtilities.ePlayerColor Turn
        {
            // a propertie for m_PlayerTurn
            get
            {

                return m_PlayerTurn;
            }

            set
            {
                m_PlayerTurn = value;
            }
        }

        public eGameMode Mode
        {
            // a propertie for m_GameMode
            get
            {

                return m_GameMode;
            }

            set
            {
                m_GameMode = value;
            }
        }

        public Board GameBoard
        {
            // a propertie for m_GameBoard.
            get
            {

                return m_GameBoard;
            }
        }

        public List<Cell> BlackPlayerOptions
        {
            // a propertie for m_BlackPlayerOptions
            get
            {

                return m_BlackPlayerOptions;
            }
        }
    }
}
