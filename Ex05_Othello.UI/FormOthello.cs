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
        private readonly Image r_RedImage = Properties.Resources.CoinRed;
        private readonly Image r_YellowImage = Properties.Resources.CoinYellow;

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
            int windowLength, picBoxSize, windowMargin, picBoxMargin;

            flowLayoutPanelBoard.Top = 10;
            flowLayoutPanelBoard.Left = 10;
            picBoxMargin = 5;
            picBoxSize = flowLayoutPanelBoard.Controls[0].Width;
            windowMargin = flowLayoutPanelBoard.Top;
            windowLength = windowMargin * 2 + picBoxSize * (int)i_BoardSize+((int)i_BoardSize-1) * picBoxMargin + (int)i_BoardSize/2;
            flowLayoutPanelBoard.Size = new Size(windowLength, windowLength);

        }

        public void Initialize()
        {
            updateGameBoard();
        }

        private void showPlayersByGameBoard()
        {
            PictureBox cellAsPictureBox;

            foreach(Cell cell in m_GameLogic.GameBoard.Matrix)
            {
                cellAsPictureBox = convertCellToPictureBox(cell);
                if(cell.Sign == (char)Player.eColor.Red)
                {
                    // assign red player image
                    redPlayerPictureBoxStyle(cellAsPictureBox);
                }
                else if(cell.Sign == (char)Player.eColor.Yellow)
                {
                    // assign yellow player image
                    yellowPlayerPictureBoxStyle(cellAsPictureBox);
                }
            }
        }


        private void enableAllLegalPlayerPictureBoxs(Player.eColor i_Turn)
        {
            List<Cell> currentPlayerOptionList;

            currentPlayerOptionList = i_Turn == Player.eColor.Yellow ? m_GameLogic.YellowPlayerOptions : m_GameLogic.RedPlayerOptions;
            foreach (Cell cell in currentPlayerOptionList)
            {
                enableRepresentingPictureBox(cell);
            }
        }



        private void enableRepresentingPictureBox(Cell i_Cell)
        {
            // this method recieve a cell and enableing the representing pictureBox.
            PictureBox pictureBox;

            pictureBox = convertCellToPictureBox(i_Cell);
            //1. style the representing pictureBox.
            availablePictureBoxStyle(pictureBox);
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
            i_PictureBoxToStyle.Enabled = false;
            i_PictureBoxToStyle.BackColor = Color.Gray;
        }

        private void availablePictureBoxStyle(PictureBox i_PictureBoxToStyle)
        {
            // this method is styling an available pictureBox
            i_PictureBoxToStyle.Image = null;
            i_PictureBoxToStyle.Enabled = true;
            i_PictureBoxToStyle.BackColor = Color.Green;
        }

        private void yellowPlayerPictureBoxStyle(PictureBox i_PictureBoxToStyle)
        {
            // this method is styling a pictureBox occupied by a yellow player
            i_PictureBoxToStyle.Image = r_YellowImage;
            i_PictureBoxToStyle.Enabled = false;
            i_PictureBoxToStyle.BackColor = Color.Gray;
        }

        private void redPlayerPictureBoxStyle(PictureBox i_PictureBoxToStyle)
        {
            // this method is styling a pictureBox occupied by a red player
            i_PictureBoxToStyle.Image = r_RedImage;
            i_PictureBoxToStyle.Enabled = false;
            i_PictureBoxToStyle.BackColor = Color.Gray;
        }

        private void disableAllBoardPictureBoxes()
        {
            foreach (Control control in flowLayoutPanelBoard.Controls)
            {
               disabledPictureBoxStyle(control as PictureBox);
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
            // 1. disable all cells in game board.
            disableAllBoardPictureBoxes();

            // 2. show all player in game board. 
            showPlayersByGameBoard();

            // 3. show all legal option for this current turn. 
            enableAllLegalPlayerPictureBoxs(m_GameLogic.Turn);

            // 4. set the form title according to the player's turn.
            setFormTitle();
        }

        private void setFormTitle()
        {
            Player.eColor playerTurn;
            string formTitle;

            playerTurn = m_GameLogic.Turn;
            formTitle = string.Format("Othello - {0}'s turn", playerTurn.ToString());
            Text = formTitle;
        }

        private void pictureBoxCell_MouseDown(object i_Sender, MouseEventArgs i_E)
        {
            int rowIndex, columnIndex;
            bool isGameOver;
            
            if (i_E.Button == MouseButtons.Left)
            {
                m_GameLogic.ExtractCellIndex((i_Sender as PictureBox).Name, out rowIndex, out columnIndex);
                m_GameLogic.CellChosen(rowIndex, columnIndex);
                updateGameBoard();
                isGameOver = manageGameOver();
                if (!isGameOver)
                {
                    managePcPlaying();
                }
            }

        }
        private void managePcPlaying()
        {
            bool isPcPlaying;

            isPcPlaying = m_GameLogic.Mode == GameLogic.eGameMode.HumanVsPC && m_GameLogic.Turn == Player.eColor.Red;
            if (isPcPlaying)
            {
                disableAllBoardPictureBoxes();
                m_GameLogic.PcPlay();
                updateGameBoard();
                manageGameOver();
            }
        }

        private bool manageGameOver()
        {
            bool isGameOver;

            isGameOver = m_GameLogic.IsGameOver();
            if (isGameOver)
            {
                Close();
            }

            return isGameOver;
        }
    }
}
