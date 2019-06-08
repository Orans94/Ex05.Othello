using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex05_Othello.UI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            UIManager othello = new UIManager();
            othello.Run();
        }
    }
}
