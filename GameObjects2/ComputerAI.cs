using System;

namespace GameObjects2
{
    public class ComputerAI
    {
        private int m_Rows;
        private int m_Cols;
        private char[,] m_Memory;

        public ComputerAI(int i_Rows, int i_Cols)
        {
            m_Rows = i_Rows;
            m_Cols = i_Cols;
            m_Memory = new char[i_Rows, i_Cols];
        }
        public string SearchAPiar()
        {
            string returnVal = "";
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    if (m_Memory[i, j] != '#')
                    {
                        if (findSecond(m_Memory[i, j], i, j))
                        {
                            returnVal = String.Format("{0}{1}", (char)(j + 'A'), i + 1);
                            m_Memory[i, j] = '#';
                            break;
                        }
                    }
                    if (returnVal != "")
                    {
                        break;
                    }
                }
            }
            return returnVal;
        }
        private bool findSecond(char i_Character, int i_Row, int i_Col)
        {
            bool returnVal = false;
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    if (m_Memory[i, j] == i_Character && (i != i_Row || j != i_Col)){
                        returnVal = true;
                        break;
                    }
                }
            }
            return returnVal;
        }
        private bool isCharInMemory(char i_Charcter, ref int io_Row, ref int io_Col)
        {
            bool returnVal = false;
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    if (m_Memory[i, j] == i_Charcter)
                    {
                        returnVal = true;
                        io_Row = i;
                        io_Col = j;
                        break;
                    }
                }
                if (returnVal)
                {
                    break;
                }
            }
            return returnVal;
        }
        public void Add(char i_Character, int i_Row, int i_Col)
        {
            m_Memory[i_Row, i_Col] = i_Character;

        }
        public string FindChar(char i_Character)
        {
            string returnVal = "";
            int row = -1;
            int col = -1;
            if (isCharInMemory(i_Character, ref row, ref col))
            {
                m_Memory[row, col] = '#';
                returnVal = String.Format("{0}{1}", (char)(col + 'A'), row + 1);
            }
            return returnVal;
        }
        public string RandomeChoose()
        {
            Random random = new Random();
            char randomChar = (char)(random.Next('A', 'A' + m_Cols));
            int randomDigit = random.Next(0, m_Rows) + 1;
            return string.Format("{0}{1}", randomChar, randomDigit);

        }
    }
}
