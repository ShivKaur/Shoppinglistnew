using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Shoppinglist
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            radioButton1.ForeColor = System.Drawing.Color.Green;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            radioButton3.ForeColor = System.Drawing.Color.Red;
            radioButton4.ForeColor = System.Drawing.Color.Red;

            combo.Items.Clear();
            combo.Items.Add("Full Cream Milk");
            combo.Items.Add("Lite Reduced Fat Milk");
            combo.Items.Add("Skim Milk");



        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            radioButton3.ForeColor = System.Drawing.Color.Green;
            radioButton4.ForeColor = System.Drawing.Color.Red;

            combo.Items.Clear();
            combo.Items.Add("Free Range Eggs");
            combo.Items.Add("Cage Free Extra Large Eggs");
            combo.Items.Add("Farm Fresh Cage Eggs");

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Red;
            radioButton3.ForeColor = System.Drawing.Color.Red;
            radioButton4.ForeColor = System.Drawing.Color.Green;

            combo.Items.Clear();
            combo.Items.Add("Multi-Grain Bread");
            combo.Items.Add("White Bread");
            combo.Items.Add("Wholemeal Sandwich Bread");

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Red;
            radioButton2.ForeColor = System.Drawing.Color.Green;
            radioButton3.ForeColor = System.Drawing.Color.Red;
            radioButton4.ForeColor = System.Drawing.Color.Red;

            combo.Items.Clear();
            combo.Items.Add("Orange Juice");
            combo.Items.Add("Apple Juice");
            combo.Items.Add("Mango Juice");

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo.SelectedItem.ToString() == "Full Cream Milk")
            {
                txt_price.Text = "3.35";
            }
            else if (combo.SelectedItem.ToString() == "Lite Reduced Fat Milk")
            {
                txt_price.Text = "3.35";
            }
            else if (combo.SelectedItem.ToString() == "Skim Milk")
            {
                txt_price.Text = "3.35";
            }
            else if (combo.SelectedItem.ToString() == "Free Range Eggs")
            {
                txt_price.Text = "3.50";
            }
            else if (combo.SelectedItem.ToString() == "Cage Free Extra Large Eggs")
            {
                txt_price.Text = "4.00";
            }
            else if (combo.SelectedItem.ToString() == "Farm Fresh Cage Eggs")
            {
                txt_price.Text = "5.50";
            }
            else if (combo.SelectedItem.ToString() == "Multi-Grain Bread")
            {
                txt_price.Text = "3.30";
            }
            else if (combo.SelectedItem.ToString() == "White Bread")
            {
                txt_price.Text = "3.90";
            }
            else if (combo.SelectedItem.ToString() == "Wholemeal Sandwich Bread")
            {
                txt_price.Text = "4.45";
            }
            else if (combo.SelectedItem.ToString() == "Orange Juice")
            {
                txt_price.Text = "2.50";
            }
            else if (combo.SelectedItem.ToString() == "Apple Juice")
            {
                txt_price.Text = "3.00";
            }
            else if (combo.SelectedItem.ToString() == "Mango Juice")
            {
                txt_price.Text = "3.90";
            }
            else
            {
                txt_price.Text = "0";
            }
            txt_total.Text = "";
            txt_qty.Text = "";
        }
        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            
                if (txt_qty.Text.Length > 0)
                {
                    txt_total.Text = (Convert.ToDecimal(txt_price.Text) * Convert.ToDecimal(txt_qty.Text)).ToString();
                }
            
           

        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            string[] arr = new string[4];
            arr[0] = combo.SelectedItem.ToString();
            arr[1] = txt_price.Text;
            arr[2] = txt_qty.Text;
            arr[3] = txt_total.Text;
            ListViewItem lvi = new ListViewItem(arr);
            listView1.Items.Add(lvi);
            txt_sub.Text = (Convert.ToDecimal(txt_sub.Text) + Convert.ToDecimal(txt_total.Text)).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

           if (listView1.Items.Count>0)
            {
                try 
                {
                     string Con = "Data Source=DESKTOP-PFO1JF7\\SQLEXPRESS;Initial Catalog=Shoppinglist;Integrated Security=True";
                    SqlConnection connection = new SqlConnection(Con);
                    SqlCommand command = connection.CreateCommand();

                    connection.Open();
                    command.CommandText = "Insert into Invoice_table(Invoice_Date, Sub_total) values" +
                        "(getdate(), " + txt_sub.Text + ") select scope_identity()";

                    string Invoice_ID = command.ExecuteScalar().ToString();
                    int Invoice = Int16.Parse(Invoice_ID);
                    //for(int j=0; j<listView1.Items.Count; j++)
                    //{
                    //  int k=0;
                    //MessageBox.Show(listView1.Items[j].SubItems[k].Text );
                    //MessageBox.Show(listView1.Items[j].SubItems[k+1].Text );
                    //MessageBox.Show (listView1.Items[j].SubItems[k+2].Text );
                    //MessageBox.Show (listView1.Items[j].SubItems[k+3].Text );

                    //}
                   // SqlCommand cmd;
                   // cmd= new SqlCommand("insert into Detail_table(Master_ID, Item_name, Item_price, Item_qty, Item_total) values(@Master_ID, @Item_name, @Item_price, @Item_qty, @Item_total)", connection);
                    //cmd.Parameters.Add("@Master_ID", (SqlDbType)Invoice);
                    
                        for (int j = 0; j < listView1.Items.Count; j++)
                        {
                            int k = 0;

                       // MessageBox.Show(Int16.Parse(listView1.Items[j].SubItems[k].Text));
                        // MessageBox.Show(Invoice_ID);
                        // MessageBox.Show(listView1.Items[j].SubItems[k+1].Text);
                        //MessageBox.Show(listView1.Items[j].SubItems[k+2].Text);
                        //MessageBox.Show(listView1.Items[j].SubItems[k+3].Text);
                        //MessageBox.//Show(listView1.Items[i].SubItems[ii].Text);
                        // command.CommandText = "Insert into detaaa(Master_ID) values" + "("+ Invoice +") select scope_identity()";
                        //command.ExecuteNonQuery();
                        //MessageBox.Show("Successful");
                        command.CommandText = "Insert into Detail_table(Master_ID,Item_name, Item_price, Item_qty, Item_total) values" +
                    "('" + Invoice + "','" + listView1.Items[j].SubItems[k].Text + "'," + listView1.Items[j].SubItems[k+1].Text + ",'" + listView1.Items[j].SubItems[k+2].Text + "," + listView1.Items[j].SubItems[k+3].Text + ") select scope_identity()";
                        //
                        //command.ExecuteNonQuery();
                        //command.Parameters["Master_ID"].Value = Invoice;
                       // command.Parameters["Item_name"].Value = listView1.Items[j].SubItems[k].Text;
                    }
                    // ListItem.SubItems[3].Text
                    //int r;
                    //r= command.ExecuteNonQuery();
                      //  if(r>=1)
                    //{
                      //  MessageBox.Show("Records inserted");
                    //}
                    //}
                    //command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Sale Created Successfully, with Invoice # " + Invoice);
                }
                catch(Exception ee)
                {
                    
                    MessageBox.Show("Error!");
                }
            }
            else
            {
                MessageBox.Show("Must add an item in the list");
            }
        }
    }
    
}
