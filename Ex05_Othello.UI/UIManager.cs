using System;
using System.Collections.Generic;
using System.Text;
using Ex05_Othello.Logic;
using System.Windows.Forms;


namespace Ex05_Othello.UI
{
    public class UIManager
    {
        public void Run()
        {
            DialogResult dialogResult;
            visualStyles();
            FormGameSettings formGameSettings = new FormGameSettings();
            Application.Run(formGameSettings);
            FormOthello formOthello = new FormOthello(formGameSettings.BoardSize, formGameSettings.GameMode);
            do
            {
                Application.Run(formOthello);
                dialogResult = endOfRoundDialog(formOthello.GameLogic);
            }
            while (dialogResult == DialogResult.Yes);
        }

        private DialogResult endOfRoundDialog(GameLogic i_GameLogic)
        {
            int whitePlayerRoundScore, blackPlayerRoundScore, whitePlayerOverallScore, blackPlayerOverallScore;
            string winnerColor, endOfRoundMessage;
            DialogResult dialogResult;

            i_GameLogic.getPlayersCurrentRoundScores(out whitePlayerRoundScore, out blackPlayerRoundScore);
            i_GameLogic.getPlayersOverallScores(out whitePlayerOverallScore, out blackPlayerOverallScore);
            i_GameLogic.getCurrentRoundWinner(out winnerColor);
            endOfRoundMessage = string.Format("{0} Won!!({1}/{2})({3}/{4}){5}Would you like another round?", winnerColor, blackPlayerRoundScore, whitePlayerRoundScore,
                blackPlayerOverallScore, whitePlayerOverallScore, Environment.NewLine);
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
