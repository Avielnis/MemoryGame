using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGame
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            (new SettingsForm()).ShowDialog();
        }
    }
}
