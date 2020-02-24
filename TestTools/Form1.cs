using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsConnection.CareEntry("JJS2000", "192.168.55.101");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            clsConnection.CareEntry("JJS2000", "192.168.55.103");
        }
    }
}
