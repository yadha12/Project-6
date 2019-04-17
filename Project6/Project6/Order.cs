using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project6
{
    public partial class Order : Form
    {

        public Order()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            eathere eh = new eathere();
            eh.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            eathere eh = new eathere();
            eh.ShowDialog();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            RestaurantSystem rs = new RestaurantSystem();

            orderno.Text = rs.AutoGenerateId();
        }
    }
}
