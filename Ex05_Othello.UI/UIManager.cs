using System;
using System.Collections.Generic;
using System.Text;
using Ex05_Othello.Logic;
using System.Windows.Forms;


namespace Ex05_Othello.UI
{
    public class UIManager
    {
        private GameLogic m_GameLogic = new GameLogic();
        public void Run()
        {
            DialogResult dialogResult;
            FormOthello formOthello;

            visualStyles();
            FormGameSettings formGameSettings = new FormGameSettings();
            Application.Run(formGameSettings);
            do
            {
                formOthello = new FormOthello(m_GameLogic, formGameSettings.BoardSize, formGameSettings.GameMode);
                formOthello.Initialize();
                Application.Run(formOthello);
                dialogResult = endOfRoundDialog(formOthello.GameLogic);
                restartGame(formOthello);
            }
            while (dialogResult == DialogResult.Yes);
        }

        private void restartGame(FormOthello i_FormOthello)
        {
            // this method is doing a logic restart.
            i_FormOthello.GameLogic.RestartGame();
        }

        private DialogResult endOfRoundDialog(GameLogic i_GameLogic)
        {
            bool isGameEndedInTie;
            int yellowPlayerRoundScore, redPlayerRoundScore, yellowPlayerOverallScore, redPlayerOverallScore;
            string winnerColor, endOfRoundMessage;
            DialogResult dialogResult;

            i_GameLogic.getPlayersCurrentRoundScores(out yellowPlayerRoundScore, out redPlayerRoundScore);
            i_GameLogic.getPlayersOverallScores(out yellowPlayerOverallScore, out redPlayerOverallScore);
            i_GameLogic.getCurrentRoundWinner(out winnerColor, out isGameEndedInTie);
            if (isGameEndedInTie)
            {
                endOfRoundMessage = string.Format("Its a DRAW !!({0}/{1})({2}/{3}){4}Would you like another round?", redPlayerRoundScore, yellowPlayerRoundScore,
                   redPlayerOverallScore, yellowPlayerOverallScore, Environment.NewLine);
            }
            else
            {
                endOfRoundMessage = string.Format("{0} Won!!({1}/{2})({3}/{4}){5}Would you like another round?", winnerColor, redPlayerRoundScore, yellowPlayerRoundScore,
                   redPlayerOverallScore, yellowPlayerOverallScore, Environment.NewLine);
            }
            dialogResult = MessageBox.Show(endOfRoundMessage, "Othello", MessageBoxButtons.YesNo);

            return dialogResult;
        }

        private static void visualStyles()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
