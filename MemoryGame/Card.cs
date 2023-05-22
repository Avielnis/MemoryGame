using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public class Card : Button
    {
        private int m_Row;
        private int m_Col;
        public Card(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }
        public void InitClick()
        {
            MemoryGameForm ParentForm = this.Parent as MemoryGameForm;
            this.Click += ParentForm.Card_Click;
        }
        public static Card CloneFirstButton(Button i_Button)
        {
            Card card = new Card(0, 0);
            card.AutoSize = i_Button.AutoSize;
            card.Location = i_Button.Location;
            card.Padding = i_Button.Padding;
            card.Size = i_Button.Size;
            card.UseVisualStyleBackColor = i_Button.UseVisualStyleBackColor;
            return card;
        }
        public int Row
        {
            get { return m_Row; }
        }
        public int Col
        {
            get { return m_Col; }
        }
    }
}
