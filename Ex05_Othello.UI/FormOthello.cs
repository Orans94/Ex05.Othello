using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex05_Othello.Logic;

namespace Ex05_Othello.UI
{
    public partial class FormOthello : Form
    {
        private GameLogic m_GameLogic;
        readonly Image r_RedImage = Properties.Resources.CoinRed;
        readonly Image r_YellowImage = Properties.Resources.CoinYellow;

        public GameLogic GameLogic
        {
            get
            {
                return m_GameLogic;
           }
        }
        public FormOthello(GameLogic i_GameLogic, Board.eBoardSize i_BoardSize, GameLogic.eGameMode i_GameMode)
        {
            m_GameLogic = i_GameLogic;
            InitializeComponent();
            configureGameSettings(i_BoardSize, i_GameMode);
            createGameBoard();
            Initialize();
            adjustWindowSize(i_BoardSize);
        }

        private void adjustWindowSize(Board.eBoardSize i_BoardSize)
        {
            int windowLength;

            flowLayoutPanelBoard.Top = 10;
            flowLayoutPanelBoard.Left = 10;
            windowLength = 10 * 2 + 40 * (int)i_BoardSize+((int)i_BoardSize-1)*5 + (int)i_BoardSize/2;
            flowLayoutPanelBoard.Size = new Size(windowLength, windowLength);

        }

        public void Initialize()
        {
            updateBoardPictureBoxesStatus();
            showPlayersByGameBoard();
        }

        private void showPlayersByGameBoard()
        {
            PictureBox cellAsPictureBox;
            foreach(Cell cell in m_GameLogic.GameBoard.Matrix)
            {
                cellAsPictureBox = convertCellToPictureBox(cell);
                if(cell.Sign == (char)Player.ePlayerColor.Red)
                {
                    // assign red player image
                    redPlayerPictureBoxStyle(cellAsPictureBox);
                }
                else if(cell.Sign == (char)Player.ePlayerColor.Yellow)
                {
                    // assign yellow player image
                    yellowPlayerPictureBoxStyle(cellAsPictureBox);
                }
            }
        }

        private void updateBoardPictureBoxesStatus()
        {
            // 1. disable all pictureBoxs in flow and color it gray
            bool isStyleNeeded = true;

            disableAllBoardPictureBoxes(isStyleNeeded);

            // 2. enable current player pictureBoxs options and color it green
            enableAllLegalPlayerPictureBoxs(m_GameLogic.Turn);
        }

        internal void RestartGame()
        {
            Initialize();
        }

        private void enableAllLegalPlayerPictureBoxs(Player.ePlayerColor i_Turn)
        {
            List<Cell> currentPlayerOptionList;

            currentPlayerOptionList = i_Turn == Player.ePlayerColor.Yellow ? m_GameLogic.YellowPlayerOptions : m_GameLogic.RedPlayerOptions;
            foreach (Cell cell in currentPlayerOptionList)
            {
                enableRepresentingPictureBox(cell);
            }
        }



        private void enableRepresentingPictureBox(Cell i_Cell)
        {
            // this method recieve a cell and enableing the representing pictureBox.
            Control pictureBox;

            pictureBox = convertCellToPictureBox(i_Cell);
            //1.enable the representing pictureBox.
            pictureBox.Enabled = true;
            //2.style the representing pictureBox.
            availablePictureBoxStyle(pictureBox as PictureBox);
        }

        private PictureBox convertCellToPictureBox(Cell i_Cell)
        {
            Control control;
            PictureBox pictureBox;
            string pictureBoxName;

            pictureBoxName = string.Format("pictureBox{0}", i_Cell.ToString());
            control = flowLayoutPanelBoard.Controls[pictureBoxName];
            pictureBox = control as PictureBox;

            return pictureBox;
        }

        private void disabledPictureBoxStyle(PictureBox i_PictureBoxToStyle)
        {
            // this method is styling a disabled pictureBox
            i_PictureBoxToStyle.Image = null;
            i_PictureBoxToStyle.BackColor = Color.Gray;
        }

        private void availablePictureBoxStyle(PictureBox i_PictureBoxToStyle)
        {
            // this method is styling an available pictureBox
            i_PictureBoxToStyle.Image = null;
            i_PictureBoxToStyle.BackColor = Color.Green;
        }

        private void yellowPlayerPictureBoxStyle(PictureBox i_PictureBoxToStyle)
        {
            // this method is styling a pictureBox occupied by a yellow player
            i_PictureBoxToStyle.BackColor = Color.Gray;
            i_PictureBoxToStyle.Image = r_YellowImage;
        }

        private void redPlayerPictureBoxStyle(PictureBox i_PictureBoxToStyle)
        {
            // this method is styling a pictureBox occupied by a red player
            i_PictureBoxToStyle.BackColor = Color.Gray;
            i_PictureBoxToStyle.Image = r_RedImage;
        }

        private void disableAllBoardPictureBoxes(bool i_IsStyleChangeNeeded)
        {
            foreach (Control control in flowLayoutPanelBoard.Controls)
            {
                control.Enabled = false;
                if(i_IsStyleChangeNeeded)
                {
                   disabledPictureBoxStyle(control as PictureBox);
                }
            }
        }

        private void configureGameSettings(Board.eBoardSize i_BoardSize, GameLogic.eGameMode i_GameMode)
        {
            m_GameLogic.configureGameSettings(i_BoardSize, i_GameMode);
            m_GameLogic.Initialize();
        }

        private void createGameBoard()
        {
            
            for (int i = 0; i < (int)m_GameLogic.GameBoard.Size* (int)m_GameLogic.GameBoard.Size; i++)
            {
                flowLayoutPanelBoard.Controls.Add(createGameBoardPictureBox(i, (int)m_GameLogic.GameBoard.Size));
            }
        }

        PictureBox createGameBoardPictureBox(int i_PictureBoxNumber, int i_BoardSize)
        {
            PictureBox pictureBox = new PictureBox();
            string pictureBoxIndex;

            pictureBoxIndex = extractPictureBoxIndex(i_PictureBoxNumber, i_BoardSize);
            pictureBox.Name = string.Format("pictureBox{0}",pictureBoxIndex);
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.BackColor = Color.Gray;
            pictureBox.Width = 40;
            pictureBox.Height = 40;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.MouseDown += pictureBoxCell_MouseDown;
            pictureBox.MouseUp += pictureBoxCell_MouseUp;

            return pictureBox;
        }

        private string extractPictureBoxIndex(int i_PictureBoxNumber, int i_BoardSize)
        {
            string pictureBoxIndex;
            char pictureBoxRow, pictureBoxColumn;

            pictureBoxRow = (char)((i_PictureBoxNumber / i_BoardSize) + '1');
            pictureBoxColumn = (char)((i_PictureBoxNumber % i_BoardSize) + 'A');
            pictureBoxIndex = string.Format("{0}{1}", pictureBoxColumn, pictureBoxRow);

            return pictureBoxIndex;
        }


        private void updateGameBoard()
        {
            enableAllLegalPlayerPictureBoxs(m_GameLogic.Turn);
            showPlayersByGameBoard();
            setFormTitle();
        }

        private void setFormTitle()
        {
            Player.ePlayerColor playerTurn;
            string formTitle;

            playerTurn = m_GameLogic.Turn;
            formTitle = string.Format("Othello - {0}'s turn", playerTurn.ToString());
            Text = formTitle;
        }

        private void pictureBoxCell_MouseUp(object sender, MouseEventArgs i_E)
        {
            bool isPcPlaying, isGameOver, isStyleNeeded = true;

            if(i_E.Button == MouseButtons.Left)
            {
                isPcPlaying = m_GameLogic.Mode == GameLogic.eGameMode.HumanVsPC && m_GameLogic.Turn == Player.ePlayerColor.Red;
                if (isPcPlaying)
                {
                    disableAllBoardPictureBoxes(isStyleNeeded);
                    m_GameLogic.PcPlay();
                    System.Threading.Thread.Sleep(2000);
                    updateGameBoard();
                    isGameOver = m_GameLogic.IsGameOver();
                    if (isGameOver)
                    {
                        m_GameLogic.UpdateWinnerOverallScore();
                        Close();
                    }
                }

            }
        }
        private void pictureBoxCell_MouseDown(object i_Sender, MouseEventArgs i_E)
        {
            bool isGameOver;
            int rowIndex, columnIndex;
            if (i_E.Button == MouseButtons.Left)
            {
                m_GameLogic.ExtractCellIndex((i_Sender as PictureBox).Name, out rowIndex, out columnIndex);
                m_GameLogic.CellChosen(rowIndex, columnIndex);
                updateGameBoard();
                isGameOver = m_GameLogic.IsGameOver();
                if (isGameOver)
                {
                    m_GameLogic.UpdateWinnerOverallScore();
                    Close();
                }
            }
        }
    }
}
