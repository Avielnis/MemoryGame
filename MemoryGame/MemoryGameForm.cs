using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameObjects2;
namespace MemoryGame
{
    public partial class MemoryGameForm : Form
    {
        private bool m_GameEnded;
        private Card[,] m_CardsArr;
        private Board m_Board;
        private GamePlayers m_GamePlayers;
        private ComputerAI m_ComputerAI = null;
        private bool m_VsComp;
        private bool m_Turn;// false its user1 and true its user2/computer
        private int m_CountOpenCards;
        private String m_FirstCardOpened;
        private readonly Color r_User1Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
        private readonly Color r_User2Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
        private readonly Dictionary<char, int> r_KeyIndexPairs = new Dictionary<char, int>()
        {   { 'A', 0 }, { 'B', 1 }, { 'C', 2 }, { 'D', 3 }, { 'E', 4 }, { 'F', 5 },
            {'1',0 },{'2',1 },{'3',2},{'4',3},{'5',4},{'6',5}};

        public MemoryGameForm()
        {
            InitializeComponent();
        }
        public MemoryGameForm(string i_FirstPlayerName, string i_SecondPlayerName, bool i_VsComp, string i_BoardSize)
        {
            InitializeComponent();
            initCardsArrAndBoard(i_BoardSize);
            initPlayers(i_FirstPlayerName, i_SecondPlayerName, i_VsComp);
            m_GameEnded = false;
            m_CountOpenCards = 0;
        }
        private void initPlayers(string i_FirstPlayerName, string i_SecondPlayerName, bool i_VsComp)
        {
            if (i_FirstPlayerName.Length > 15)
            {
                i_FirstPlayerName = i_FirstPlayerName.Substring(0, 15);
            }
            if(i_SecondPlayerName.Length > 15)
            {
                i_SecondPlayerName = i_SecondPlayerName.Substring(0, 15);
            }
            m_VsComp = i_VsComp;
            m_Turn = false;
            m_GamePlayers = new GamePlayers(i_FirstPlayerName, i_SecondPlayerName, i_VsComp);
            if (i_VsComp)
            {
                m_ComputerAI = new ComputerAI(m_Board.Rows, m_Board.Cols);
            }
            this.User1ScoreLable.Text = string.Format("{0} Score is: {1}", m_GamePlayers.User1.Name, m_GamePlayers.User1.Score);
            if (m_VsComp)
            {
                this.User2ScoreLable.Text = string.Format("Computers Score is: {0}", m_GamePlayers.Computer.Score);
            }
            else
            {
                this.User2ScoreLable.Text = string.Format("{0} Score is: {1}", m_GamePlayers.User2.Name, m_GamePlayers.User1.Score);
            }
            this.CurrentPlyaerLable.Text = string.Format("Current Player: {0}", m_GamePlayers.User1.Name);
            this.CurrentPlyaerLable.Top = m_CardsArr[m_Board.Rows - 1, m_Board.Cols - 1].Top + 100;
            this.User1ScoreLable.Top = this.CurrentPlyaerLable.Top + 20;
            this.User2ScoreLable.Top = this.User1ScoreLable.Top + 20;
        }
        private void initCardsArrAndBoard(string i_BoardSize)
        {

            m_CardsArr = new Card[i_BoardSize[0] - '0', i_BoardSize[2] - '0'];
            this.m_Board = new Board(i_BoardSize[0] - '0', i_BoardSize[2] - '0');
            m_CardsArr[0, 0] = Card.CloneFirstButton(this.FirstCard);
            this.FirstCard.Dispose();
            for (int i = 0; i < m_Board.Rows; i++)
            {
                if (i != 0)
                {
                    m_CardsArr[i, 0] = new Card(i, 0);
                    m_CardsArr[i, 0].Top = m_CardsArr[i - 1, 0].Bottom + 12;
                    m_CardsArr[i, 0].Left = m_CardsArr[0, 0].Left;
                    m_CardsArr[i, 0].Size = m_CardsArr[0, 0].Size;

                }
                for (int j = 1; j < m_Board.Cols; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    m_CardsArr[i, j] = new Card(i, j);
                    m_CardsArr[i, j].Top = m_CardsArr[i, j - 1].Top;
                    m_CardsArr[i, j].Left = m_CardsArr[i, j - 1].Right + 12;
                    m_CardsArr[i, j].Size = m_CardsArr[i, j - 1].Size;
                }
            }

            foreach (Card card in this.m_CardsArr)
            {
                this.Controls.Add(card);
                card.InitClick();
            }
        }
        private void MemoryGameForm_Load(object sender, EventArgs e)
        {
        }
        private void enableAllCards()
        {
            foreach (Card card in this.m_CardsArr)
            {
                if (card.Text != "")
                {
                    card.Enabled = false;
                }
                else
                {
                    card.Enabled = true;
                }
            }
        }
        private void disableAllCards()
        {
            foreach (Card card in this.m_CardsArr)
            {
                card.Enabled = false;
            }
        }
        public void Card_Click(object sender, EventArgs e)
        {
            Card currentCard = sender as Card;
            if (!m_Turn)// if user1's turn the color is green
            {
                currentCard.BackColor = r_User1Color;
            }
            else
            {
                currentCard.BackColor = r_User2Color;
            }
            int row = (currentCard.Row + 1);
            char col = (char)(currentCard.Col + 'A');
            string UserCoise = "" + col + "" + row;
            playUser(m_Turn, UserCoise, currentCard);
            m_CountOpenCards++;
            if (m_CountOpenCards == 2)
            {
                WaitTimer.Start();
                disableAllCards();
                checkChoices(m_FirstCardOpened, UserCoise);
                m_CountOpenCards = 0;
                m_Turn = !m_Turn;
                checkIfToEndGame();
                if (!m_Turn)// if user1 turn
                {
                    this.CurrentPlyaerLable.Text = string.Format("Current Player: {0}", m_GamePlayers.User1.Name);
                }
                else
                {
                    if (m_VsComp)
                    {
                        WaitTimer.Stop();
                        CompTimer.Start();
                    }
                    else
                    {
                        this.CurrentPlyaerLable.Text = string.Format("Current Player: {0}", m_GamePlayers.User2.Name);
                    }
                }
            }
            else
            {
                m_FirstCardOpened = UserCoise;
                currentCard.Enabled = false;
            }
        }
        private void CompTimer_TickComp(object sender, EventArgs e)
        {
            if (!m_GameEnded)
            {
                WaitTimer.Start();
                this.CurrentPlyaerLable.Text = "Current Player: Computer";
                disableAllCards();
                playComp();
                enableAllCards();
                this.CurrentPlyaerLable.Text = string.Format("Current Player: {0}", m_GamePlayers.User1.Name);
                m_Turn = !m_Turn;
                checkIfToEndGame();
            }
            CompTimer.Stop();
        }
        private void checkIfToEndGame()
        {
            StringBuilder messege = new StringBuilder();
            bool EndGameFlag = false;
            if (m_GamePlayers.User2 == null)
            {
                int sum = (m_GamePlayers.User1.Score * 2) + (m_GamePlayers.Computer.Score * 2);
                if (sum == m_Board.Rows * m_Board.Cols)
                {
                    messege.AppendLine(GetGameScore());
                    int compScore = m_GamePlayers.Computer.Score;
                    int user1Score = m_GamePlayers.User1.Score;
                    if (compScore == user1Score)
                    {
                        messege.AppendLine("It's A Tie!");
                    }
                    if (compScore > user1Score)
                    {
                        messege.AppendLine("The Computer Wins!");
                    }
                    if (compScore < user1Score)
                    {
                        messege.AppendLine(string.Format("{0} Wins!", m_GamePlayers.User1.Name));
                    }
                    EndGameFlag = true;
                }
            }
            else
            {
                int sum = (m_GamePlayers.User1.Score * 2) + (m_GamePlayers.User2.Score * 2);
                if (sum == m_Board.Rows * m_Board.Cols)
                {
                    messege.AppendLine(GetGameScore());
                    int user1Score = m_GamePlayers.User1.Score;
                    int user2Score = m_GamePlayers.User2.Score;
                    if (user2Score == user1Score)
                    {
                        messege.AppendLine("It's A Tie!");
                    }
                    if (user2Score > user1Score)
                    {
                        messege.AppendLine(string.Format("{0} Wins!", m_GamePlayers.User2.Name));
                    }
                    if (user2Score < user1Score)
                    {
                        messege.AppendLine(string.Format("{0} Wins!", m_GamePlayers.User1.Name));
                    }
                    EndGameFlag = true;
                }
            }
            if (EndGameFlag)
            {
                m_GameEnded = true;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                messege.AppendLine("Another Game?");
                result = MessageBox.Show(messege.ToString(), "Game Ended!", buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SettingsForm SettingsForm;
                    string boardSize = string.Format("{0}X{1}", m_Board.Rows, m_Board.Cols);
                    if (m_VsComp) {
                        SettingsForm = new SettingsForm(m_VsComp, m_GamePlayers.User1.Name,"-Computer-",boardSize);
                        this.FormClosing -= MemoryGameForm_FormClosing; //remove event 
                       this.Dispose(); // close the form 
                    }
                    else
                    {
                        SettingsForm = new SettingsForm(m_VsComp, m_GamePlayers.User1.Name, m_GamePlayers.User2.Name,boardSize);
                        this.FormClosing -= MemoryGameForm_FormClosing; //remove event
                       this.Dispose(); // close the form 
                    }
                    SettingsForm.ShowDialog();
                    this.Dispose();
                }
                else
                {
                    this.Dispose();
                    Environment.Exit(0);
                }
            }
        }
        private void playComp()
        {
            string computerChoice1 = m_ComputerAI.SearchAPiar();
            string computerChoice2 = "";
            while (!checkInput(computerChoice1, true))
            {
                computerChoice1 = m_ComputerAI.RandomeChoose();
            }
            computerChoice2 = m_ComputerAI.FindChar(m_Board.MatrixValues[r_KeyIndexPairs[computerChoice1[1]],
                   r_KeyIndexPairs[computerChoice1[0]]]);
            if (computerChoice2 == "" || m_Board.CellsToShowMatrix[r_KeyIndexPairs[computerChoice2[1]], r_KeyIndexPairs[computerChoice2[0]]] == true || computerChoice1 == computerChoice2)
            {
                computerChoice2 = "";
                while (computerChoice1 == computerChoice2 || !checkInput(computerChoice2, true))
                {
                    computerChoice2 = m_ComputerAI.RandomeChoose();
                }
                m_ComputerAI.Add(m_Board.MatrixValues[r_KeyIndexPairs[computerChoice1[1]],
                r_KeyIndexPairs[computerChoice1[0]]], r_KeyIndexPairs[computerChoice1[1]], r_KeyIndexPairs[computerChoice1[0]]);
                m_ComputerAI.Add(m_Board.MatrixValues[r_KeyIndexPairs[computerChoice2[1]],
                r_KeyIndexPairs[computerChoice2[0]]], r_KeyIndexPairs[computerChoice2[1]], r_KeyIndexPairs[computerChoice2[0]]);
            }
            m_Board.CellsToShowMatrix[r_KeyIndexPairs[computerChoice1[1]], r_KeyIndexPairs[computerChoice1[0]]] = true;
            m_Board.CellsToShowMatrix[r_KeyIndexPairs[computerChoice2[1]], r_KeyIndexPairs[computerChoice2[0]]] = true;
            validateWhichToOpen();
            m_CardsArr[r_KeyIndexPairs[computerChoice1[1]], r_KeyIndexPairs[computerChoice1[0]]].BackColor = r_User2Color;
            m_CardsArr[r_KeyIndexPairs[computerChoice2[1]], r_KeyIndexPairs[computerChoice2[0]]].BackColor = r_User2Color;
            if (m_Board.MatrixValues[r_KeyIndexPairs[computerChoice1[1]], r_KeyIndexPairs[computerChoice1[0]]] ==
                m_Board.MatrixValues[r_KeyIndexPairs[computerChoice2[1]], r_KeyIndexPairs[computerChoice2[0]]])
            {
                m_GamePlayers.Computer.Score++;
            }
            else
            {
                m_Board.CellsToShowMatrix[r_KeyIndexPairs[computerChoice1[1]], r_KeyIndexPairs[computerChoice1[0]]] = false;
                m_Board.CellsToShowMatrix[r_KeyIndexPairs[computerChoice2[1]], r_KeyIndexPairs[computerChoice2[0]]] = false;
            }
            this.User2ScoreLable.Text = string.Format("Computers score is: {0}", m_GamePlayers.Computer.Score);
        }
        private void validateWhichToOpen()
        {
            for (int i = 0; i < m_Board.Rows; i++)
            {
                for (int j = 0; j < m_Board.Cols; j++)
                {
                    if (m_Board.CellsToShowMatrix[i, j] == true)
                    {
                        m_CardsArr[i, j].Text = String.Format("{0}", m_Board.MatrixValues[i, j]);
                    }
                    else
                    {
                        m_CardsArr[i, j].Text = "";
                        m_CardsArr[i,j].BackColor = default(Color);
                    }
                }
            }
        }
        private void playUser(bool i_Turn, string i_UserChoice, Card i_Card)
        {
            string userInput1 = i_UserChoice;
            if (m_ComputerAI != null)
            {
                m_ComputerAI.Add(m_Board.MatrixValues[r_KeyIndexPairs[userInput1[1]],
                    r_KeyIndexPairs[userInput1[0]]], r_KeyIndexPairs[userInput1[1]], r_KeyIndexPairs[userInput1[0]]);
            }
            m_Board.CellsToShowMatrix[r_KeyIndexPairs[userInput1[1]], r_KeyIndexPairs[userInput1[0]]] = true;
            i_Card.Text = string.Format("{0}", m_Board.MatrixValues[r_KeyIndexPairs[userInput1[1]], r_KeyIndexPairs[userInput1[0]]]);
        }
        private void checkChoices(string i_UserInput1, string i_UserInput2)
        {
            if (m_Board.MatrixValues[r_KeyIndexPairs[i_UserInput2[1]], r_KeyIndexPairs[i_UserInput2[0]]] ==
                m_Board.MatrixValues[r_KeyIndexPairs[i_UserInput1[1]], r_KeyIndexPairs[i_UserInput1[0]]])
            {
                if (!m_Turn)
                {
                    m_GamePlayers.User1.Score++;
                    this.User1ScoreLable.Text = string.Format("{0} Score is: {1}", m_GamePlayers.User1.Name, m_GamePlayers.User1.Score);
                }
                else
                {
                    m_GamePlayers.User2.Score++;
                    this.User2ScoreLable.Text = string.Format("{0} Score is: {1}", m_GamePlayers.User2.Name, m_GamePlayers.User2.Score);
                }
            }
            else
            {
                m_Board.CellsToShowMatrix[r_KeyIndexPairs[i_UserInput1[1]], r_KeyIndexPairs[i_UserInput1[0]]] = false;
                m_Board.CellsToShowMatrix[r_KeyIndexPairs[i_UserInput2[1]], r_KeyIndexPairs[i_UserInput2[0]]] = false;
            }
            if (m_ComputerAI != null)
            {
                m_ComputerAI.Add(m_Board.MatrixValues[r_KeyIndexPairs[i_UserInput2[1]], r_KeyIndexPairs[i_UserInput2[0]]],
                    r_KeyIndexPairs[i_UserInput2[1]], r_KeyIndexPairs[i_UserInput2[0]]);
                m_ComputerAI.Add(m_Board.MatrixValues[r_KeyIndexPairs[i_UserInput1[1]], r_KeyIndexPairs[i_UserInput1[0]]],
                    r_KeyIndexPairs[i_UserInput1[1]], r_KeyIndexPairs[i_UserInput1[0]]);

            }
        }
        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            if (m_CountOpenCards == 0)
            {
                validateWhichToOpen();
                enableAllCards();
                WaitTimer.Stop();
            }
        }
        private bool checkInput(string i_Input, bool i_IsComp)
        {
            bool returnVal = true;
            if (i_Input.Length != 2)
            {
                returnVal = false;
            }
            else if (!(i_Input[0] >= 'A' && i_Input[0] < ('A' + m_Board.Cols)))
            {
                returnVal = false;
            }
            else if (!(i_Input[1] >= '1' && i_Input[1] < ('1' + m_Board.Rows)))
            {
                returnVal = false;
            }
            else if (returnVal)
            {
                if (m_Board.CellsToShowMatrix[r_KeyIndexPairs[i_Input[1]], r_KeyIndexPairs[i_Input[0]]])
                {
                    returnVal = false;
                }
            }
            return returnVal;
        }
        private string GetGameScore()
        {
            StringBuilder score = new StringBuilder();
            if (m_GamePlayers.Computer == null)
            {
                score.AppendLine(string.Format("{0}'s Score is: {1}", m_GamePlayers.User1.Name, m_GamePlayers.User1.Score));
                score.AppendLine(string.Format("{0}'s Score is: {1}", m_GamePlayers.User2.Name, m_GamePlayers.User2.Score));
            }
            else
            {
                score.AppendLine(string.Format("{0} Score is: {1}", m_GamePlayers.User1.Name, m_GamePlayers.User1.Score));
                score.AppendLine(string.Format("Computer's Score is: {0}", m_GamePlayers.Computer.Score));
            }
            return score.ToString();
        }
        private void MemoryGameForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Are you sure you want to quit?", "End Game", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void FirstCard_Click(object sender, EventArgs e)
        {

        }
    }
}

