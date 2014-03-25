using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JARVIS
{
    public partial class googleOther : Form
    {
        string toSearch;
        public googleOther()
        {
            InitializeComponent();
        }

        public string inputFound()
        {
            toSearch = input.Text;
            return toSearch;
        }

        private void search_Click(object sender, EventArgs e)
        {
            string toSearch = inputFound();
            string searchTemplate = "www.google.com/search?q=";
            Process.Start(searchTemplate + toSearch);
            this.Close();
        }


    }
}
