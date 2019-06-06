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
    public partial class FormGameSettings : Form
    {
        private Board.eBoardSize m_BoardSize = Board.eBoardSize.size6x6;
        private GameLogic.eGameMode m_GameMode;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            changeBoardSize();
        }

        private void changeBoardSize()
        {
            // TODO: maybe add consts?
            string incOrDec;

            m_BoardSize += (int)m_BoardSize == 12 ? -6 : 2;
            incOrDec = (int)m_BoardSize == 12 ? "decrease" : "increase";
            buttonBoardSize.Text = string.Format("Board size: {0}x{0} (click to {1})", (int)m_BoardSize, incOrDec);
        }

        public Board.eBoardSize BoardSize
        {
            get
            {

                return m_BoardSize;
            }

            set
            {

                m_BoardSize = value;
            }
        }

        public GameLogic.eGameMode GameMode
        {
            get
            {

                return m_GameMode;
            }

            set
            {

                m_GameMode = value;
            }
        }

        private void buttonPlayHumanVsPC_Click(object sender, EventArgs e)
        {
            m_GameMode = GameLogic.eGameMode.HumanVsPC;
            Close();
        }

        private void buttonPlayHumanVsHuman_Click(object sender, EventArgs e)
        {
            m_GameMode = GameLogic.eGameMode.HumanVsHuman;
            Close();
        }
    }
}
