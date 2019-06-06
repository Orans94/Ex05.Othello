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
            configureBoardSize(i_BoardSize);
            configureGameMode(i_GameMode);

        }

        private void configureGameMode(GameLogic.eGameMode i_GameMode)
        {
            m_GameLogic.Mode = i_GameMode;
        }

        private void configureBoardSize(Board.eBoardSize i_BoardSize)
        {
            m_GameLogic.GameBoard.Size = i_BoardSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
