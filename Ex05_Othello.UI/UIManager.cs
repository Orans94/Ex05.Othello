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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormGameSettings formGameSettings = new FormGameSettings();
            Application.Run(formGameSettings);
        }
    }
}
