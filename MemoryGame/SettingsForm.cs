using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class SettingsForm : Form
    {
        private readonly string[] m_BoardSizes = { "4X4", "4X5", "4X6", "5X4", "5X6", "6X4", "6X5", "6X6" };
        private int m_SizesIndex = 1;
        private bool m_VsComputer = true;
        public SettingsForm()
        {
            InitializeComponent();
        }
        public SettingsForm(bool i_VsComputer, string i_FirstPlayerName, string i_SecondPlayerName,string i_BoardSize)
        {
            InitializeComponent();
            m_VsComputer = i_VsComputer;
            this.BoradSizeButton.Text = i_BoardSize;
            this.FirstPlayerNameTextBox.Text = i_FirstPlayerName;
            if (i_VsComputer)
            {
                this.SecondPlayerNameTextBox.Text = "-Computer-";
            }
            else
            {
                this.AgaisntWho.Text = "Against Computer";
                m_VsComputer = false;
                this.SecondPlayerNameTextBox.Enabled = true;
                this.SecondPlayerNameTextBox.Text = "";
                this.SecondPlayerNameTextBox.Text = i_SecondPlayerName;
            }
        }
        private void AgaisntAFriend_Click(object sender, EventArgs e)
        {
            if (m_VsComputer)
            {
                this.AgaisntWho.Text = "Against Computer";
                m_VsComputer = false;
                this.SecondPlayerNameTextBox.Enabled = true;
                this.SecondPlayerNameTextBox.Text = "";
            }
            else
            {
                this.AgaisntWho.Text = "Against Friend";
                m_VsComputer = true;
                this.SecondPlayerNameTextBox.Enabled = false;
                this.SecondPlayerNameTextBox.Text = "-Computer-";
            }

        }
        private void BoradSizeButton_Click(object sender, EventArgs e)
        {
            this.BoradSizeButton.Text = m_BoardSizes[m_SizesIndex];
            m_SizesIndex = (m_SizesIndex + 1) % 8;
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (this.FirstPlayerNameTextBox.Text != ""
                && this.FirstPlayerNameTextBox.Text != "Enter Your Name!")
            {
                if (this.m_VsComputer == true)
                {
                    MemoryGameForm gameForm = new MemoryGameForm(this.FirstPlayerNameTextBox.Text, this.SecondPlayerNameTextBox.Text, m_VsComputer, this.BoradSizeButton.Text);
                    this.Visible = false;
                    gameForm.ShowDialog();
                }
                else
                {
                    if (SecondPlayerNameTextBox.Text != ""
                        && this.SecondPlayerNameTextBox.Text != "Enter Your Name! or Choose to play Against the computer")
                    {
                        MemoryGameForm gameForm = new MemoryGameForm(this.FirstPlayerNameTextBox.Text, this.SecondPlayerNameTextBox.Text, m_VsComputer, this.BoradSizeButton.Text);
                        this.Visible = false;
                        gameForm.ShowDialog();
                    }
                    else
                    {
                        this.SecondPlayerNameTextBox.Text = "Enter Your Name! or Choose to play Against the computer";
                    }
                }
            }
            else
            {
                this.FirstPlayerNameTextBox.Text = "Enter Your Name!";
            }

        }
    }
}
