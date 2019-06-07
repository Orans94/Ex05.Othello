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
            visualStyles();
            FormGameSettings formGameSettings = new FormGameSettings();
            Application.Run(formGameSettings);
            FormOthello formOthello = new FormOthello(formGameSettings.BoardSize, formGameSettings.GameMode);
            while (true)
            {
                //TODO: show end of round form(?) if user choose yes - restarts game if no - exit.
                Application.Run(formOthello);
                
            }
            //FormEndOfRound formEndOfRound = new FormEndOfRound();
           // Application.Run(formEndOfRound);
        }

        private static void visualStyles()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
