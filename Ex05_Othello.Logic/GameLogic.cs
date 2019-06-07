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
        private List<Player> m_Players = new List<Player>();

        public GameLogic(Board i_GameBoard, GameUtilities.ePlayerColor i_PlayerTurn)
        {
            Board copiedBoard = i_GameBoard;
            m_GameBoard = copiedBoard;
            m_PlayerTurn = i_PlayerTurn;
        }

        public GameLogic()
        {

        }

        public List<Player> Players
        {
            get
            {

                return m_Players;
            }

            set
            {
                m_Players = value;
            }
        }

        public void configureGameSettings(Board.eBoardSize i_BoardSize, eGameMode i_GameMode)
        {
            m_GameBoard = new Board(i_BoardSize);
            m_GameMode = i_GameMode;
            setGameParticipants();
        }

        public void CellChosen(string i_CellName)
        {
            // this method is getting a name of a cell and acting like it was chosen(the cell is surely on option list)
            List<Cell> cellsToUpdate = new List<Cell>();
            int rowIndex, columnIndex;
            //check if current cell is in options?? or button that is not in options cant be clicked?

            //1.extract the move from the name(explanation: take "E3" from "BUTTON E3")
            extractCellIndex(i_CellName, out rowIndex, out columnIndex);
            //2.add all cells that should be updated to cellToUpdate list!(how?)
            isPlayerMoveBlockingEnemy(rowIndex, columnIndex, ref cellsToUpdate);
            //3.update board
            m_GameBoard.UpdateBoard(cellsToUpdate, m_PlayerTurn);
            //4.update player options
            updatePlayersOptions();
            //5.update player scores
            updatePlayersScore();
            //6.turn changing
            turnChangingManager();
            //7.check if game over

            //  7.1 if game over - UI should know and print message of winner etc...
            //  7.2 UI should also ask if user want another game...
            //      7.2.1 if user want another game- restart game.
        }

        public bool IsGameOver()
        {
            // this method checks if the game is over(if both of the players has no options to play).
            bool doesBothPlayersHasNoOptions;

            doesBothPlayersHasNoOptions = isPlayerOptionEmpty(GameUtilities.ePlayerColor.BlackPlayer) && isPlayerOptionEmpty(GameUtilities.ePlayerColor.WhitePlayer);

            return doesBothPlayersHasNoOptions;
        }

        private bool isPlayerOptionEmpty(GameUtilities.ePlayerColor i_PlayerColor)
        {
            // this method recieve a PlayerColor and check if his options list is empty.
            bool isOptionListEmpty;

            if (i_PlayerColor == GameUtilities.ePlayerColor.BlackPlayer)
            {
                isOptionListEmpty = m_BlackPlayerOptions.Count == 0;
            }
            else
            {
                // if not black player - than its a white player.
                isOptionListEmpty = m_WhitePlayerOptions.Count == 0;
            }

            return isOptionListEmpty;
        }

        private void restartGame()
        {
            // this method restarts a game.
            Initialize();
        }

        private void updatePlayersScore()
        {
            // this method is updating the players scores.
            int updatedWhitePlayerScore, updatedBlackPlayerScore;

            updatedWhitePlayerScore = m_GameBoard.CountSignAppearances((char)GameUtilities.ePlayerColor.WhitePlayer);
            updatedBlackPlayerScore = m_GameBoard.CountSignAppearances((char)GameUtilities.ePlayerColor.BlackPlayer);
            m_Players[0].Score = updatedWhitePlayerScore;
            m_Players[1].Score = updatedBlackPlayerScore;
        }

        private void turnChangingManager()
        {
            // this method is managing the players turn changing
            if (m_PlayerTurn == GameUtilities.ePlayerColor.BlackPlayer && m_WhitePlayerOptions.Count > 0)
            {
                m_PlayerTurn = GameUtilities.ePlayerColor.WhitePlayer;
            }
            else if (m_PlayerTurn == GameUtilities.ePlayerColor.WhitePlayer && m_BlackPlayerOptions.Count > 0)
            {
                m_PlayerTurn = GameUtilities.ePlayerColor.BlackPlayer;
            }
            else if ((m_PlayerTurn == GameUtilities.ePlayerColor.BlackPlayer && m_WhitePlayerOptions.Count == 0)
                 || (m_PlayerTurn == GameUtilities.ePlayerColor.WhitePlayer && m_BlackPlayerOptions.Count == 0))
            {
                // TODO:(?) UI.InformTurnHasBeenChanged(m_PlayerTurn);
                // if you dont have options - should we put a message to the user?
            }
        }

        private void extractCellIndex(string i_CellName, out int rowIndex, out int columnIndex)
        {
            // this method get a button name and assign the row and column.
            throw new NotImplementedException();
            
        }

        private void setGameParticipants()
        {
            // this method is setting the player list according to the game mode.
            Player whitePlayer = new HumanPlayer(GameUtilities.ePlayerColor.WhitePlayer);
            Player blackPlayer;

            if (m_GameMode == eGameMode.HumanVsHuman)
            {
                blackPlayer = new HumanPlayer(GameUtilities.ePlayerColor.BlackPlayer);
            }
            else
            {
                blackPlayer = new PcPlayer(GameUtilities.ePlayerColor.BlackPlayer);
            }

            m_Players.Add(whitePlayer);
            m_Players.Add(blackPlayer);
        }

        public void Initialize()
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
            foreach(Player player in m_Players)
            {
                player.Score = 2;
            }
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
            // TODO: add initializing for 10x10 and 12x12
            // this method is initializing the white player options list
            Cell cellToBeAddedToOptions1;
            Cell cellToBeAddedToOptions2;
            Cell cellToBeAddedToOptions3;
            Cell cellToBeAddedToOptions4;

            if (m_GameBoard.Size == Board.eBoardSize.size6x6)
            {
                cellToBeAddedToOptions1 = new Cell(1, 3);
                cellToBeAddedToOptions2 = new Cell(2, 4);
                cellToBeAddedToOptions3 = new Cell(3, 1);
                cellToBeAddedToOptions4 = new Cell(4, 2);
            }
            else
            {
                cellToBeAddedToOptions1 = new Cell(2, 4);
                cellToBeAddedToOptions2 = new Cell(3, 5);
                cellToBeAddedToOptions3 = new Cell(4, 2);
                cellToBeAddedToOptions4 = new Cell(5, 3);
            }

            m_WhitePlayerOptions.Add(cellToBeAddedToOptions1);
            m_WhitePlayerOptions.Add(cellToBeAddedToOptions2);
            m_WhitePlayerOptions.Add(cellToBeAddedToOptions3);
            m_WhitePlayerOptions.Add(cellToBeAddedToOptions4);
        }

        public void updatePlayersOptions()
        {
            // this method is updating the Lists of the players options
            List<Cell> cellList = new List<Cell>();
            GameUtilities.ePlayerColor lastPlayerTurn;
            bool isCellAnOption, shouldMethodAddCellsToUpdateList;

            m_WhitePlayerOptions.Clear();
            m_BlackPlayerOptions.Clear();
            lastPlayerTurn = m_PlayerTurn;
            shouldMethodAddCellsToUpdateList = false;
            foreach (Cell cellIteator in m_GameBoard.Matrix)
            {
                if (cellIteator.Sign == Cell.k_Empty)
                {
                    m_PlayerTurn = GameUtilities.ePlayerColor.WhitePlayer;
                    isCellAnOption = isPlayerMoveBlockingEnemy(cellIteator.Row, cellIteator.Column, ref cellList, shouldMethodAddCellsToUpdateList);
                    if (isCellAnOption)
                    {
                        m_WhitePlayerOptions.Add(cellIteator);
                    }

                    m_PlayerTurn = GameUtilities.ePlayerColor.BlackPlayer;
                    isCellAnOption = isPlayerMoveBlockingEnemy(cellIteator.Row, cellIteator.Column, ref cellList, shouldMethodAddCellsToUpdateList);
                    if (isCellAnOption)
                    {
                        m_BlackPlayerOptions.Add(cellIteator);
                    }
                }
            }

            // restore the turn of the last player
            m_PlayerTurn = lastPlayerTurn;
        }

        public bool isPlayerMoveBlockingEnemy(int i_PlayerMoveRowIndex, int i_PlayerMoveColumnIndex, ref List<Cell> io_CellsToUpdate, bool i_AddCellsToList = true)
        {
            // this method recieves a player move and return true if the move is blocking the enemy.
            // its also updates the list of cells to update.
            bool isVerticalBlocking, isHorizontalBlocking, isDiagonalOneBlocking, isDiagonalTwoBlocking, isMoveBlockingEnemy;

            isVerticalBlocking = isVerticallyBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.Up, (int)eDirection.NoDirection, i_AddCellsToList);
            isVerticalBlocking = isVerticallyBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.Down, (int)eDirection.NoDirection, i_AddCellsToList) || isVerticalBlocking;
            isHorizontalBlocking = isHorizontallyBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.NoDirection, (int)eDirection.Left, i_AddCellsToList);
            isHorizontalBlocking = isHorizontallyBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.NoDirection, (int)eDirection.Right, i_AddCellsToList) || isHorizontalBlocking;
            isDiagonalOneBlocking = isDiagonallyOneBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.Up, (int)eDirection.Right, i_AddCellsToList);
            isDiagonalOneBlocking = isDiagonallyOneBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.Down, (int)eDirection.Left, i_AddCellsToList) || isDiagonalOneBlocking;
            isDiagonalTwoBlocking = isDiagonallyTwoBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.Up, (int)eDirection.Left, i_AddCellsToList);
            isDiagonalTwoBlocking = isDiagonallyTwoBlocking(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, ref io_CellsToUpdate, (int)eDirection.Down, (int)eDirection.Right, i_AddCellsToList) || isDiagonalTwoBlocking;
            isMoveBlockingEnemy = isVerticalBlocking || isHorizontalBlocking || isDiagonalOneBlocking || isDiagonalTwoBlocking;

            return isMoveBlockingEnemy;
        }

        private bool isHorizontallyBlocking(int i_PlayerMoveRowIndex, int i_PlayerMoveColumnIndex, ref List<Cell> io_CellsToUpdate, int i_VerticalDirection, int i_HorizontalDirection, bool i_AddCellsToList)
        {
            // this method return true if a blocking sequence has been found in horizontal direction.
            Cell cellIterator = null;
            bool isBlockFound;

            isBlockFound = isBlockingLine(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, i_VerticalDirection, i_HorizontalDirection, out cellIterator);
            if (isBlockFound && i_AddCellsToList == true)
            {
                if (i_HorizontalDirection == (int)eDirection.Left)
                {
                    for (int column = i_PlayerMoveColumnIndex; column > cellIterator.Column; column--)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[i_PlayerMoveRowIndex, column]);
                    }
                }
                else
                {
                    for (int column = i_PlayerMoveColumnIndex; column < cellIterator.Column; column++)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[i_PlayerMoveRowIndex, column]);
                    }
                }
            }

            return isBlockFound;
        }

        private bool isDiagonallyTwoBlocking(int i_PlayerMoveRowIndex, int i_PlayerMoveColumnIndex, ref List<Cell> io_CellsToUpdate, int i_VerticalDirection, int i_HorizontalDirection, bool i_AddCellsToList)
        {
            // this method return true if a blocking sequence has been found in diagonal direction.
            // **(Diagonal two is going down by Y).
            Cell cellIterator = null;
            bool isBlockFound;
            int row;

            isBlockFound = isBlockingLine(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, i_VerticalDirection, i_HorizontalDirection, out cellIterator);
            if (isBlockFound && i_AddCellsToList == true)
            {
                if (i_HorizontalDirection == (int)eDirection.Left && i_VerticalDirection == (int)eDirection.Up)
                {
                    row = i_PlayerMoveRowIndex;
                    for (int column = i_PlayerMoveColumnIndex; column > cellIterator.Column; column--)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[row, column]);
                        row += (int)eDirection.Up;
                    }
                }
                else
                {
                    // elsewise we are going RIGHT and DOWN
                    row = i_PlayerMoveRowIndex;
                    for (int i = i_PlayerMoveColumnIndex; i < cellIterator.Column; i++)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[row, i]);
                        row += (int)eDirection.Down;
                    }
                }
            }

            return isBlockFound;
        }

        private bool isDiagonallyOneBlocking(int i_PlayerMoveRowIndex, int i_PlayerMoveColumnIndex, ref List<Cell> io_CellsToUpdate, int i_VerticalDirection, int i_HorizontalDirection, bool i_AddCellsToList)
        {
            // this method return true if a blocking sequence has been found in diagonal direction.
            // **(Diagonal one is going up by Y).
            Cell cellIterator = null;
            bool isBlockFound;
            int row;

            isBlockFound = isBlockingLine(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, i_VerticalDirection, i_HorizontalDirection, out cellIterator);
            if (isBlockFound && i_AddCellsToList == true)
            {
                if (i_HorizontalDirection == (int)eDirection.Left && i_VerticalDirection == (int)eDirection.Down)
                {
                    row = i_PlayerMoveRowIndex;
                    for (int column = i_PlayerMoveColumnIndex; column > cellIterator.Column; column--)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[row, column]);
                        row += (int)eDirection.Down;
                    }
                }
                else
                {
                    // elsewise we are going UP and RIGHT
                    row = i_PlayerMoveRowIndex;
                    for (int i = i_PlayerMoveColumnIndex; i < cellIterator.Column; i++)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[row, i]);
                        row += (int)eDirection.Up;
                    }
                }
            }

            return isBlockFound;
        }

        private bool isVerticallyBlocking(int i_PlayerMoveRowIndex, int i_PlayerMoveColumnIndex, ref List<Cell> io_CellsToUpdate, int i_VerticalDirection, int i_HorizontalDirection, bool i_AddCellsToList)
        {
            // this method return true if a blocking sequence has been found in vertical direction.
            Cell cellIterator = null;
            bool isBlockFound;

            isBlockFound = isBlockingLine(i_PlayerMoveRowIndex, i_PlayerMoveColumnIndex, i_VerticalDirection, i_HorizontalDirection, out cellIterator);
            if (isBlockFound && i_AddCellsToList == true)
            {
                if (i_VerticalDirection == (int)eDirection.Up)
                {
                    for (int row = i_PlayerMoveRowIndex; row > cellIterator.Row; row--)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[row, i_PlayerMoveColumnIndex]);
                    }
                }
                else
                {
                    for (int row = i_PlayerMoveRowIndex; row < cellIterator.Row; row++)
                    {
                        io_CellsToUpdate.Add(m_GameBoard.Matrix[row, i_PlayerMoveColumnIndex]);
                    }
                }
            }

            return isBlockFound;
        }

        private bool isBlockingLine(int i_PlayerMoveRowIndex, int i_PlayerMoveColumnIndex, int i_VerticalDirection, int i_HorizontalDirection, out Cell o_CellIterator)
        {
            // this method return true if there is a sequence of legal blocking.
            // in addition, it return the last cell in the sequence as an out parameter.
            int currentRow, currentColumn;
            Cell cellIterator;
            bool isBlockFound, isInBoardLimits;

            currentRow = i_PlayerMoveRowIndex + i_VerticalDirection;
            currentColumn = i_PlayerMoveColumnIndex + i_HorizontalDirection;
            isInBoardLimits = GameBoard.IsCellInBoard(currentRow, currentColumn);
            isBlockFound = false;
            if (isInBoardLimits)
            {
                cellIterator = new Cell(currentRow, currentColumn, m_GameBoard.Matrix[currentRow, currentColumn].Sign);
                isBlockFound = isSeriesFound(ref cellIterator, i_VerticalDirection, i_HorizontalDirection);
            }
            else
            {
                cellIterator = null;
            }

            o_CellIterator = cellIterator;

            return isBlockFound;
        }

        private bool isSeriesFound(ref Cell i_CellIterator, int i_VerticalDirection, int i_HorizontalDirection)
        {
            // this method get directions, cell by ref
            // this method return true if series of blocks has been found
            bool isCellEnemy, isInBoardLimits;
            bool isBlockingLine, isCharSimilarToMeFound;

            isCellEnemy = false;
            isBlockingLine = false;
            isInBoardLimits = m_GameBoard.IsCellInBoard(i_CellIterator);
            if (isInBoardLimits)
            {
                isCellEnemy = isCellAnEnemy(i_CellIterator, Turn);
            }

            if (isInBoardLimits && isCellEnemy)
            {
                // this condition check if the first cell is an enemy and in board, if it is countiue
                do
                {
                    i_CellIterator.Row += i_VerticalDirection;
                    i_CellIterator.Column += i_HorizontalDirection;
                    isInBoardLimits = m_GameBoard.IsCellInBoard(i_CellIterator);
                    if (isInBoardLimits)
                    {
                        i_CellIterator.Sign = m_GameBoard.Matrix[i_CellIterator.Row, i_CellIterator.Column].Sign;
                        isCellEnemy = isCellAnEnemy(i_CellIterator, Turn);
                    }
                }
                while (isInBoardLimits && isCellEnemy);

                // check why the while has been stopped
                if (isInBoardLimits)
                {
                    isCharSimilarToMeFound = i_CellIterator.Sign == (char)Turn;
                    if (isCharSimilarToMeFound)
                    {
                        isBlockingLine = true;
                    }
                }
            }

            return isBlockingLine;
        }

        private bool isCellAnEnemy(Cell i_CellIterator, GameUtilities.ePlayerColor i_CurrentPlayerTurn)
        {
            // this method return true if the sign of the input cell is different from i_CurrentPlayerTurn
            bool isCellEnemy;

            isCellEnemy = i_CellIterator.Sign != (char)i_CurrentPlayerTurn && i_CellIterator.Sign != Cell.k_Empty;

            return isCellEnemy;
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
