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
        HumanPlayer m_BlackHumanPlayer
        
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
                m_BlackHumanPlayer.Active = true;
            }
            else
            {
                i_BlackPCPlayer.Active = true;
            }
        }

        public void initialize()
        {
            // this method is initializing the player options, scores and board.
            m_GameBoard.Initialize();
            initializePlayersOptions();
            initializePlayersScores();
            m_PlayerTurn = GameUtilities.ePlayerColor.WhitePlayer;
        }

        private void initializePlayersScores()
        {
            // this method is initializing the players scores
            m_WhiteHumanPlayer.Score = 2;
            m_BlackHumanPlayer.Score = 2;
            m_BlackPCPlayer.Score = 2;
        }

        private void initializePlayersOptions()
        {
            // this method is initializing the player options lists.
            if (m_BlackPlayerOptions.Count != 0)
            {
                m_BlackPlayerOptions.Clear();
            }

            if (m_WhitePlayerOptions.Count != 0)
            {
                m_WhitePlayerOptions.Clear();
            }

            initializeBlackPlayerOptions();
            initializeWhitePlayerOptions();
        }

        private void initializeBlackPlayerOptions()
        {
            // this method is initializing the black player options list
            Cell cellToBeAddedToOptions1;
            Cell cellToBeAddedToOptions2;
            Cell cellToBeAddedToOptions3;
            Cell cellToBeAddedToOptions4;

            if (m_GameBoard.Size == Board.eBoardSize.size8x8)
            {
                cellToBeAddedToOptions1 = new Cell(2, 3);
                cellToBeAddedToOptions2 = new Cell(3, 2);
                cellToBeAddedToOptions3 = new Cell(5, 4);
                cellToBeAddedToOptions4 = new Cell(4, 5);
            }
            else
            {
                cellToBeAddedToOptions1 = new Cell(1, 2);
                cellToBeAddedToOptions2 = new Cell(2, 1);
                cellToBeAddedToOptions3 = new Cell(4, 3);
                cellToBeAddedToOptions4 = new Cell(3, 4);
            }

            m_BlackPlayerOptions.Add(cellToBeAddedToOptions1);
            m_BlackPlayerOptions.Add(cellToBeAddedToOptions2);
            m_BlackPlayerOptions.Add(cellToBeAddedToOptions3);
            m_BlackPlayerOptions.Add(cellToBeAddedToOptions4);
        }

        private void initializeWhitePlayerOptions()
        {
            // this method is initializing the white player options list
            Cell cellToBeAddedToOptions1;
            Cell cellToBeAddedToOptions2;
            Cell cellToBeAddedToOptions3;
            Cell cellToBeAddedToOptions4;

            if (m_GameBoard.Size == Board.eBoardSize.bigBoard)
            {
                cellToBeAddedToOptions1 = new Cell(2, 4);
                cellToBeAddedToOptions2 = new Cell(3, 5);
                cellToBeAddedToOptions3 = new Cell(4, 2);
                cellToBeAddedToOptions4 = new Cell(5, 3);
            }
            else
            {
                cellToBeAddedToOptions1 = new Cell(1, 3);
                cellToBeAddedToOptions2 = new Cell(2, 4);
                cellToBeAddedToOptions3 = new Cell(3, 1);
                cellToBeAddedToOptions4 = new Cell(4, 2);
            }

            m_WhitePlayerOptions.Add(cellToBeAddedToOptions1);
            m_WhitePlayerOptions.Add(cellToBeAddedToOptions2);
            m_WhitePlayerOptions.Add(cellToBeAddedToOptions3);
            m_WhitePlayerOptions.Add(cellToBeAddedToOptions4);
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
