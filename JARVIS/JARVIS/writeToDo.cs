using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JARVIS
{
    public partial class writeToDo : Form
    {
        string toWrite;
        Speak speak = new Speak();
        public writeToDo()
        {
            InitializeComponent();
        }

        public string inputFound()
        {
            toWrite = input.Text;
            return toWrite;
        }

        private void done_Click(object sender, EventArgs e)
        {
            string toWrite = inputFound();
            using (StreamWriter writer = File.AppendText(@"C:\Users\Alex\Desktop\JARVIS\ToDo.txt"))
            {
                writer.WriteLineAsync(toWrite + Environment.NewLine);
            }
            speak.wrote();
            this.Close();
        }

        
    }
}
