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
    public partial class menu : Form
    {
        Calculating calc = new Calculating();//calculator
        RestaurantSystem rs = new RestaurantSystem();

        public struct Ordered
        {
           public int meat, cheesePizza, mushroom, shawarma, 
                veggie, chicken, ori, doublecheese,
                icecream, pudding, cheesecake, pancake;
        }

        #region
        MeatPizza meat = new MeatPizza();
        CheesePizza cheese = new CheesePizza();
        MushroomPizza mushroom = new MushroomPizza();
        Schwarma schwarma = new Schwarma();
        Original ori = new Original();
        ChickenBurger ayam = new ChickenBurger();
        VeggieBurger sayur = new VeggieBurger();
        DoubleCheeseBurger keju = new DoubleCheeseBurger();
        IceCream icecream = new IceCream();
        Pudding pudding = new Pudding();
        CheeseCake kueKeju = new CheeseCake();
        Pancake pancake = new Pancake();
        #endregion

        string toppings;
        double toppingPrice;
        private Ordered amountOrdered;
        FileStream fs;
        StreamWriter sw;
        string scriptPath = @"..\Debug\OrderHistory.txt";
        string foodCategory = "pizza";
        string foodName;
        double Price;
        
        public menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int i = 0, pizzaAmount, burgerAmount, DessertAmount;
            bool found = false;

            if (foodCategory.Equals("pizza"))//meat Pizza
            { 
                amountOrdered.meat++;
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(meat.Name))
                    {
                        pizzaAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(pizzaAmount, meat);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, meat.Name, pizzaAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = meat.price;
                    dataGridView1.Rows.Add(meat.Name, 1, Price);
                }
            }//Meat Pizza
            else if (foodCategory.Equals("burger"))
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(sayur.Name))
                    {
                        burgerAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(burgerAmount, sayur);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, sayur.Name, burgerAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = sayur.price;
                    dataGridView1.Rows.Add(sayur.Name, 1, sayur.price);
                }
            }//Veggie Burger
            else
            {

                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(icecream.Name))
                    {
                        DessertAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(DessertAmount, icecream);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, icecream.Name, DessertAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = icecream.price;
                    dataGridView1.Rows.Add(icecream.Name, 1, icecream.price);
                }
            }// Ice Cream
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int i = 0, pizzaAmount, burgerAmount, dessertAmount;
            bool found = false;

            if (foodCategory.Equals("pizza"))
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(cheese.Name))
                    {
                        pizzaAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(pizzaAmount, cheese);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, cheese.Name, pizzaAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = cheese.price;
                    dataGridView1.Rows.Add(cheese.Name, 1, Price);
                }
            }//Cheese Pizza
            else if (foodCategory.Equals("burger"))
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(ayam.Name))
                    {
                        burgerAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(burgerAmount, ayam);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, ayam.Name, burgerAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = ayam.price;
                    dataGridView1.Rows.Add(ayam.Name, 1, Price);
                }
            }//ayam Burger
            else
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(pudding.Name))
                    {
                        dessertAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(dessertAmount, pudding);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, pudding.Name, dessertAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = pudding.price;
                    dataGridView1.Rows.Add(pudding.Name, 1, Price);
                }
            }//pudding
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int i = 0, pizzaAmount, burgerAmount, dessertAmount;
            bool found = false;

            if (foodCategory.Equals("pizza"))
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(mushroom.Name))
                    {
                        pizzaAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(pizzaAmount, mushroom);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, mushroom.Name, pizzaAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = mushroom.price;
                    dataGridView1.Rows.Add(mushroom.Name, 1, Price);
                }
            }//mushroom Pizza
            else if(foodCategory.Equals("burger"))
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(ori.Name))
                    {
                        burgerAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(burgerAmount, ori);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, ori.Name, burgerAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = ori.price;
                    dataGridView1.Rows.Add(ori.Name, 1, Price);
                }
            }//original
            else
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(kueKeju.Name))
                    {
                        dessertAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(dessertAmount, kueKeju);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, kueKeju.Name, dessertAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = kueKeju.price;
                    dataGridView1.Rows.Add(kueKeju.Name, 1, Price);
                }
            }//cheese cake
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int i = 0, pizzaAmount, burgerAmount, dessertAmount;
            bool found = false;

            if (foodCategory.Equals("pizza"))
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(schwarma.Name))
                    {
                        pizzaAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(pizzaAmount, schwarma);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, schwarma.Name, pizzaAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = schwarma.price;
                    dataGridView1.Rows.Add(schwarma.Name, 1, Price);
                }
            }//schwarma Pizza
            else if (foodCategory.Equals("burger"))
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(keju.Name))
                    {
                        burgerAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(burgerAmount, keju);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, keju.Name, burgerAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = keju.price;
                    dataGridView1.Rows.Add(keju.Name, 1, Price);
                }
            }//Double Cheese Burger
            else
            {
                while (i < dataGridView1.Rows.Count - 1)
                {
                    foodName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (foodName.Equals(pancake.Name))
                    {
                        dessertAmount = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) + 1;
                        Price = calc.calculatePrice(dessertAmount, pancake);
                        dataGridView1.Rows.RemoveAt(i);
                        dataGridView1.Rows.Insert(i, pancake.Name, dessertAmount, Price);
                        found = true;
                        break;
                    }
                    i++;
                }

                if (!found)
                {
                    Price = pancake.price;
                    dataGridView1.Rows.Add(pancake.Name, 1, Price);
                }
            }//Pancake
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foodCategory = "pizza";

            pictureBox1.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\MeatPizza.png";
            label1.Text = "Meat Pizza";
            pictureBox2.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\CheesePizza.png";
            label2.Text = "Cheese Pizza";
            pictureBox3.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\MushroomPizza.png";
            label3.Text = "Mushroom Pizza";
            pictureBox4.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\ShawarmaPizza.png";
            label4.Text = "Shawarma Pizza";


            label7.Text = "RP. 20.000";
            label8.Text = "RP. 30.000";
            label9.Text = "RP. 35.000";
            label10.Text = "RP. 50.000";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foodCategory = "burger";

            pictureBox1.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\VeggieBurger.png";
            label1.Text = "Veggie Burger";
            pictureBox2.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\ChikenBurger.png";
            label2.Text = "Chicken Burger";
            pictureBox3.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\Original.png";
            label3.Text = "Original";
            pictureBox4.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\DoubleCheeseBurger.png";
            label4.Text = "Double Cheese Burger";

            label7.Text = "RP. 22.000";
            label8.Text = "RP. 29.000";
            label9.Text = "RP. 25.000";
            label10.Text = "RP. 50.000";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foodCategory = "dessert";

            pictureBox1.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\GreenTeaIceCream.png";
            label1.Text = "Green tea Ice Cream";
            pictureBox2.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\Pudding.png";
            label2.Text = "Pudding";
            pictureBox3.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\CheesCake.png";
            label3.Text = "Cheese Cake";
            pictureBox4.ImageLocation = @"C:\Users\gading\source\repos\Project6\Project6\Resources\PancCake.png";
            label4.Text = "Pancake";

            label7.Text = "RP. 10.000";
            label8.Text = "RP. 8.000";
            label9.Text = "RP. 16.000";
            label10.Text = "RP. 30.000";

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        void calGridView()
        {
            double cal = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                try
                {
                    cal = cal + double.Parse(dataGridView1.Rows[i].Cells["foodprice"].Value.ToString());
                }
                catch { }
                label5.Text = cal.ToString("RP . .00");
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Cancel")
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calGridView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"TOTAL PRICE IS \n {label5.Text}", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TransactionScript();
                dataGridView1.Rows.Clear();
            }
        }

        void TransactionScript()
        {
            string OrderCode = rs.AutoGenerateId();

            fs = new FileStream(scriptPath, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);

            sw.WriteLine(OrderCode + "\t\t\t\t|");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                {
                    sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t"+"|");
                }
                sw.WriteLine();
            }

            sw.WriteLine( $"TOTAL\t\t{label5.Text}\t|");
            sw.WriteLine("---------------------------------");

            sw.Close();
            fs.Close();
            
            fs = new FileStream(@"C:\Users\gading\source\repos\Project6\Project6\bin\Debug\Number.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);

            sw.Write(OrderCode);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                {
                    sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "#");
                }
            }
            sw.WriteLine("{0}", label5.Text);
            sw.Close();
            fs.Close();
        }

        private void menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                TransactionScript();
                dataGridView1.Rows.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                toppings = "1";
                toppingPrice = 5000;
            }
            else if (!checkBox1.Checked)
            {
                toppings = "";
                toppingPrice = 0;
            }
        }
    }
}
