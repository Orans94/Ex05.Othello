using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    public class GameLogic
    {
        public enum eGameMode
        {
            HumanVsHuman = 1,
            HumanVsPC = 2
        }

        public enum eGameDecision
        {
            Rematch = 1,
            Exit = 2
        }

        public enum eDirection
        {
            Up = -1,
            Down = 1,
            Left = -1,
            Right = 1,
            NoDirection = 0
        }
    }
}
