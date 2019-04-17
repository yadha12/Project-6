using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project6
{
    public partial class eathere : Form
    {
        public eathere()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            menu fm = new menu();
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            drink dr = new drink();
            dr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Order o = new Order();
            o.ShowDialog();
        }
    }
}
