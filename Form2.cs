using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagementSystem
{
    public partial class Form2 : Form
    {

        public static string tb1 = "";
        public static string dat = "";
        public static double tot = 0.00;
        public static DataGridView ite;

        public Form2()
        {
            InitializeComponent();
        }

        string item;
        double itemprice;

        private void Form2_Load(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //to add items to data grid view
            if (checkBox1.Checked)
            {
                item = "Coffee";
                int quan = int.Parse(numericUpDown1.Value.ToString());
                itemprice = 60.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox2.Checked)
            {
                item = "Iced Coffee";
                int quan = int.Parse(numericUpDown2.Value.ToString());
                itemprice = 100.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox3.Checked)
            {
                item = "Milk Coffee";
                int quan = int.Parse(numericUpDown3.Value.ToString());
                itemprice = 120.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox4.Checked)
            {
                item = "Milk";
                int quan = int.Parse(numericUpDown4.Value.ToString());
                itemprice = 70.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox5.Checked)
            {
                item = "Tea";
                int quan = int.Parse(numericUpDown5.Value.ToString());
                itemprice = 50.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox6.Checked)
            {
                item = "Pastries";
                int quan = int.Parse(numericUpDown6.Value.ToString());
                itemprice = 350.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox7.Checked)
            {
                item = "Sandwiches";
                int quan = int.Parse(numericUpDown7.Value.ToString());
                itemprice = 150.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox8.Checked)
            {
                item = "Salads";
                int quan = int.Parse(numericUpDown8.Value.ToString());
                itemprice = 300.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }

            if (checkBox9.Checked)
            {
                item = "Desserts";
                int quan = int.Parse(numericUpDown9.Value.ToString());
                itemprice = 350.00;
                tot = quan * itemprice;
                this.dataGridView1.Rows.Add(item, itemprice, quan, tot);
            }



            double sum = 0.00;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[row].Cells[3].Value);

            }

            label11.Text = sum.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();

        }

        private int numberPerPage = 0;
        private int CountedNo = 0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var pen = new Pen(Color.Black, 2);
            var font1 = new Font("Monotype Corsiva", 24, FontStyle.Bold );
            var font4 = new Font("Monotype Corsiva", 18, FontStyle.Bold);

            var font2 = new Font("Segoe UI", 15, FontStyle.Bold);
            var font3 = new Font("Segoe UI", 15, FontStyle.Regular);
            var font5 = new Font("Segoe UI", 12, FontStyle.Regular);

            var blackBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("Ceylon Cafe", font1, blackBrush, new Point(350,25));

            e.Graphics.DrawString("INVOICE", font2, blackBrush, new Point(370, 75));

            e.Graphics.DrawLine(pen, 50, 100, 800, 100);



            e.Graphics.DrawString("Cashier Name:      " + textBox1.Text, font3, blackBrush, new Point(140, 110));
            //cashier name


            e.Graphics.DrawString("Items ordered on: " + label10.Text, font3, blackBrush, new Point(140, 140));
            //date and time




            //table with total amount
            e.Graphics.DrawLine(pen, 50, 175, 800, 175);

            //table columns
            e.Graphics.DrawString("Item", font2, blackBrush, new Point(50, 178));
            e.Graphics.DrawString("Item Price", font2, blackBrush, new Point(300, 178));
            e.Graphics.DrawString("Quantity", font2, blackBrush, new Point(500, 178));
            e.Graphics.DrawString("Total", font2, blackBrush, new Point(650, 178));

            e.Graphics.DrawLine(pen, 50, 210, 800, 210);

            var height = 230;
            for(var i=CountedNo; i< dataGridView1.Rows.Count; i++)
            {
                var row  = dataGridView1.Rows[i];
                numberPerPage++;

                if (numberPerPage <= 47)
                {
                    CountedNo++;

                    if (CountedNo <= dataGridView1.Rows.Count)
                    {
                        e.Graphics.DrawString(row.Cells["Column1"].Value.ToString(), font2, blackBrush, new Point(50, height));
                        e.Graphics.DrawString(row.Cells["Column2"].Value.ToString(), font2, blackBrush, new Point(300, height));
                        e.Graphics.DrawString(row.Cells["Column3"].Value.ToString(), font2, blackBrush, new Point(500, height));
                        e.Graphics.DrawString(row.Cells["Column4"].Value.ToString(), font2, blackBrush, new Point(650, height));


                
                        height += 20;
                    }

                    else
                    {
                        e.HasMorePages = false;

                    }
                }

                else
                {
                    CountedNo = 0;
                    e.HasMorePages = true;
                    return;
                }

            }


            height += 50;
            e.Graphics.DrawLine(pen, 50, height, 800, height);
            //total
            e.Graphics.DrawString("Total Amount", font2, blackBrush, new Point(50, height));
            e.Graphics.DrawString("Rs.", font2, blackBrush, new Point(550, height));
            e.Graphics.DrawString(label11.Text, font2, blackBrush, new Point(650, height));

            height += 20;
            //cash
            e.Graphics.DrawString("Cash", font2, blackBrush, new Point(50, height));
            e.Graphics.DrawString("Rs.", font2, blackBrush, new Point(550, height));
            e.Graphics.DrawString(textBox2.Text, font2, blackBrush, new Point(650, height));

            height += 20;
            //balance
            e.Graphics.DrawString("Balance", font2, blackBrush, new Point(50, height));
            e.Graphics.DrawString("Rs.", font2, blackBrush, new Point(550, height));
            e.Graphics.DrawString(label17.Text, font2, blackBrush, new Point(650, height));




            height += 80;
            e.Graphics.DrawLine(pen, 50, height, 800, height);

            e.Graphics.DrawString("THANKYOU COME AGAIN!!!", font2, blackBrush, new Point(290, height));

            height += 30;
            e.Graphics.DrawString("Ceylon Cafe", font4, blackBrush, new Point(370, height));

            height += 40;
            e.Graphics.DrawString("Tel: +94 77 1234 567", font3, blackBrush, new Point(335, height));

            height += 25;
            e.Graphics.DrawString("No. 12, Main Road, ", font3, blackBrush, new Point(345, height));

            height += 25;
            e.Graphics.DrawString("Anuradhapura", font3, blackBrush, new Point(368, height));

            height += 20;


            CountedNo = 0;
            numberPerPage = 0;

           

           













        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Visible = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double bal = Convert.ToDouble(textBox2.Text.ToString()) - Convert.ToDouble(label11.Text.ToString()) ;
            label17.Text = bal.ToString();
            
           
        }
    }
    
}
