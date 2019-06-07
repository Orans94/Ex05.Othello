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
        private GameLogic m_GameLogic = new GameLogic();

        public GameLogic GameLogic
        {
            get
            {
                return m_GameLogic;
           }
        }
        public FormOthello(Board.eBoardSize i_BoardSize, GameLogic.eGameMode i_GameMode)
        {
            InitializeComponent();
            //initializeBoardSize(i_BoardSize);
            configureGameSettings(i_BoardSize, i_GameMode);
            createGameBoard();
            updateBoardButtonsStatus();
        }

        private void updateBoardButtonsStatus()
        {
            // 1. disable all buttons in flow and color it gray
            disableAllBoardButtons();

            // 2. enable current player buttons options and color it green
            enableAllLegalPlayerButtons(m_GameLogic.Turn);
        }

        private void enableAllLegalPlayerButtons(Player.ePlayerColor i_Turn)
        {
            List<Cell> currentPlayerOptionList;

            currentPlayerOptionList = i_Turn == Player.ePlayerColor.White ? m_GameLogic.WhitePlayerOptions : m_GameLogic.BlackPlayerOptions;
            foreach (Cell cell in currentPlayerOptionList)
            {
                enableRepresentingButton(cell);
            }
        }

        private void enableRepresentingButton(Cell cell)
        {
            // this method recieve a cell and enableing the representing button.
            Control button;
            string buttonName;

            buttonName = string.Format("button{0}", cell.ToString()); // TODO :override cell to string..
            button = flowLayoutPanelBoard.Controls[buttonName];
            //1.enable the representing button.
            button.Enabled = true;
            //2.style the representing button.
            availableButtonStyle(button as Button);
        }

        private void disabledButtonStyle(Button i_ButtonToStyle)
        {
            // this method is styling a disabled button
            //TODO:
        }

        private void availableButtonStyle(Button i_ButtonToStyle)
        {
            // this method is styling an available button
            //TODO:

        }

        private void whitePlayerButtonStyle(Button i_ButtonToStyle)
        {
            // this method is styling a button occupied by a white player
            //TODO:

        }

        private void blackPlayerButtonStyle(Button i_ButtonToStyle)
        {
            // this method is styling a button occupied by a black player
            //TODO:

        }

        private void disableAllBoardButtons()
        {
            foreach (Control control in flowLayoutPanelBoard.Controls)
            {
                control.Enabled = false;
                disabledButtonStyle(control as Button);
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
                flowLayoutPanelBoard.Controls.Add(createGameBoardButton(i, (int)m_GameLogic.GameBoard.Size));
            }
        }

        Button createGameBoardButton(int i_ButtonNumber, int i_BoardSize)
        {
            Button button = new Button();
            string buttonIndex;

            buttonIndex = extractButtonIndex(i_ButtonNumber, i_BoardSize);
            button.Name = string.Format("button{0}",buttonIndex);
            button.Width = 40;
            button.Height = 40;
            button.Click += buttonCell_Click;

            return button;
        }

        private string extractButtonIndex(int i_ButtonNumber, int i_BoardSize)
        {
            string buttonIndex;
            char buttonRow, buttonColumn;

            buttonRow = (char)((i_ButtonNumber / i_BoardSize) + '1');
            buttonColumn = (char)((i_ButtonNumber % i_BoardSize) + 'A');
            buttonIndex = string.Format("{0}{1}", buttonColumn, buttonRow);

            return buttonIndex;
        }

        private void buttonCell_Click(object sender, EventArgs e)
        {
            bool isGameOver;
            
            m_GameLogic.CellChosen((sender as Button).Name);
            setFormTitle();
            isGameOver = m_GameLogic.IsGameOver();
            if (isGameOver)
            {
                Close();
            }
        }

        private void setFormTitle()
        {
            Player.ePlayerColor playerTurn;
            string formTitle;

            playerTurn = m_GameLogic.Turn;
            formTitle = string.Format("Othello - {0}'s turn", playerTurn.ToString());
            Text = formTitle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete - TODO
        }

        private void flowLayoutPanelBoard_Paint(object sender, PaintEventArgs e)
        {
            //delete - TODO
        }
    }
}
