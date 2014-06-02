using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JARVIS
{
    public partial class sendMailInput : Form
    {
        public sendMailInput()
        {
            InitializeComponent();
        }

        public string getMessage()
        {
            string message = messageInput.Text;
            return message;
        }

        public string subject()
        {
            string subject = subjectInput.Text;
            return subject;
        }

        public string[] sendTo()
        {
            string[] reciepients = new string[20];
            int index = 0;
            Console.WriteLine(sendToInput.Items.Count.ToString());
            foreach (string reciepient in sendToInput.Items)
            {
                if (!reciepient.Equals(String.Empty))
                {
                    reciepients[index] = reciepient;
                }
                index++;
                Console.WriteLine(reciepient);
            }
            return reciepients;
        }

        private void sendMail_Load(object sender, EventArgs e)
        {
            sendToInput.Items.Clear();
        }

        private void addToList_Click(object sender, EventArgs e)
        {
            sendToInput.Items.Add(recipentInput.Text);
            Console.WriteLine(sendToInput.Items.Count.ToString());
        }
    }
}
