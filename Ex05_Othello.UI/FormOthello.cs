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

        public FormOthello(Board.eBoardSize i_BoardSize, GameLogic.eGameMode i_GameMode)
        {
            InitializeComponent();
            //initializeBoardSize(i_BoardSize);
            configureGameSettings(i_BoardSize, i_GameMode);
            createGameBoard();
        }

        private void configureGameSettings(Board.eBoardSize i_BoardSize, GameLogic.eGameMode i_GameMode)
        {
            m_GameLogic.configureGameSettings(i_BoardSize, i_GameMode);
            m_GameLogic.initialize();
        }

        private void createGameBoard()
        {
            for (int i = 0; i < (int)m_GameLogic.GameBoard.Size* (int)m_GameLogic.GameBoard.Size; i++)
            {
                flowLayoutPanelBoard.Controls.Add(btn(i));
            }
        }

        Button btn(int i)
        {
            Button button = new Button();
            button.Name = i.ToString();
            button.Width = 40;
            button.Height = 40;
            button.Text = i.ToString();
            button.Click += buttonCell_Click;
            return button;
        }


        private void buttonCell_Click(object sender, EventArgs e)
        {
            //m_GameLogic.;
            MessageBox.Show((sender as Button).Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
