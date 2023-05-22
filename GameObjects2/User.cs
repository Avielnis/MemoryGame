using System;

namespace GameObjects2
{
    public class User
    {
        private string m_Name;
        private int m_Score;

        // constructor for computer
        public User(string i_Name)
        {
            m_Name = i_Name;
            m_Score = 0;
        }
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }
        public string Name { get { return m_Name; } }
    }
}
