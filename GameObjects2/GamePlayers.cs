using System;
using System.Text;
namespace GameObjects2
{
    public class GamePlayers
    {
        private User m_User1;
        private User m_User2;
        private User m_Computer;
        public GamePlayers(string i_Player1Name, string i_Player2Name, bool i_VsComp)
        {
            m_User1 = new User(i_Player1Name);
            if (!i_VsComp)// playing with another user
            {
                m_User2 = new User(i_Player2Name);
                m_Computer = null;
            }
            else// playing with the computer
            {
                m_Computer = new User("computer");
                m_User2 = null;
            }
        }
        public User User1
        {
            get { return m_User1; }
        }
        public User User2
        {
            get { return m_User2; }
        }
        public User Computer
        {
            get { return m_Computer; }
        }
    }
}
