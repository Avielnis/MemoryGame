using System;
using System.Text;
namespace GameObjects2
{
    public class Board
    {
        private int m_Rows = 4;
        private int m_Cols = 4;
        private char[,] m_MatrixValues;
        private bool[,] m_CellsToShowMatrix;
        public Board(int i_Rows, int i_Cols)
        {
            this.m_Rows = i_Rows;
            this.m_Cols = i_Cols;
            initializeMatrixValues();
            m_CellsToShowMatrix = new bool[m_Rows, m_Cols];
        }
        private void initializeMatrixValues()
        {
            m_MatrixValues = new char[m_Rows, m_Cols];
            Random random = new Random();
            char[] dobleRandomeArr = new char[m_Rows * m_Cols];
            for (int i = 0; i < m_Rows * m_Cols; i += 2)
            {
                dobleRandomeArr[i] = (char)(random.Next('A', 'Z' + 1));
                dobleRandomeArr[i + 1] = dobleRandomeArr[i];
            }
            int arrayIndex = 0;
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    m_MatrixValues[i, j] = dobleRandomeArr[arrayIndex];
                    arrayIndex++;
                }
            }
            // randomize the matrix
            for (int i = 1; i < m_Cols * m_Rows; i++)
            {
                int rowIndex1 = random.Next(0, m_Rows);
                int colIndex1 = random.Next(0, m_Cols);
                int rowIndex2 = random.Next(0, m_Rows);
                int colIndex2 = random.Next(0, m_Cols);
                // swap randome cels
                char swapTemp = m_MatrixValues[rowIndex1, colIndex1];
                m_MatrixValues[rowIndex1, colIndex1] = m_MatrixValues[rowIndex2, colIndex2];
                m_MatrixValues[rowIndex2, colIndex2] = swapTemp;
            }
        }
        //UI Function To Get Board Sizes
        private void initializeBoardSize()
        {
            while (true)
            {
                Console.WriteLine("Please enter height of the board betwwen 4 - 6");
                string rows = Console.ReadLine();
                if (checkBoardSize(rows))
                {
                    m_Rows = int.Parse(rows);
                    break;
                }
                Console.WriteLine("the input is invalid! please try again!\n");
            }

            while (true)
            {
                Console.WriteLine("Please enter width of the board betwwen 4 - 6");
                string cols = Console.ReadLine();
                if (checkBoardSize(cols))
                {
                    m_Cols = int.Parse(cols);
                    break;
                }
                Console.WriteLine("the input is invalid! please try again!\n");
            }
            if ((m_Cols * m_Rows) % 2 == 1)
            {
                Console.WriteLine("the number off cells is odd, please try again");
                initializeBoardSize();
            }
        }
        private bool checkBoardSize(string i_Size)
        {
            bool returnVal = false;
            int size;
            if (int.TryParse(i_Size, out size))
            {
                if (size >= 4 && size <= 6)
                {
                    returnVal = true;
                }
            }

            return returnVal;
        }
        public int Rows
        {
            get { return m_Rows; }
        }
        public int Cols
        {
            get { return m_Cols; }
        }
        public char[,] MatrixValues
        {
            get { return m_MatrixValues; }
        }
        public bool[,] CellsToShowMatrix
        {
            get { return m_CellsToShowMatrix; }
        }
        public void PrintBorad()
        {
            StringBuilder table = new StringBuilder();
            table.Append("   ");
            for (int i = 0; i < this.Cols; i++)
            {
                char character = (char)('A' + i);
                table.Append(string.Format(" {0}  ", character));
            }
            table.Append("\n");
            for (int i = 0; i < this.Rows; i++)
            {
                table.Append("  ");
                for (int j = 0; j < this.Cols - 1; j++)
                {
                    table.Append("=====");
                }
                if (this.Cols == 4)
                {
                    table.Append("==");
                }
                table.Append(string.Format("\n{0} ", (i + 1)));

                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.CellsToShowMatrix[i, j])
                    {
                        table.Append(string.Format("| {0} ", this.MatrixValues[i, j]));
                    }
                    else
                    {
                        table.Append("|   ");
                    }

                }
                table.Append("|\n");
            }
            table.Append("  ");
            for (int j = 0; j < this.Cols - 1; j++)
            {
                table.Append("=====");
            }
            if (this.Cols == 4)
            {
                table.Append("==");
            }
            Console.WriteLine(table);
        }
        // for testing purpeses only:
        public void PrintMatrixValues()
        {
            for (int i = 0; i < m_Rows; i++)
            {
                for (int j = 0; j < m_Cols; j++)
                {
                    Console.Write(m_MatrixValues[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

