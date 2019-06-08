using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05_Othello.Logic
{
    public struct Direction
    {
        private int m_Horizontal;
        private int m_Vertical;

        public int Horizontal
        {
            get
            {

                return m_Horizontal;
            }

            set
            {
                m_Horizontal = value;
            }
        }

        public int Vertical
        {
            get
            {

                return m_Vertical;
            }

            set
            {
                m_Vertical = value;
            }
        }
    }
}
