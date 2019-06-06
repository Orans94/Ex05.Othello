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
            Button b = new Button();
            b.Name = i.ToString();
            b.Width = 40;
            b.Height = 40;
            b.Text = i.ToString();

            return b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
