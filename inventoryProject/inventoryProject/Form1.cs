﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-GH20HRO\\SQLEXPRESS;Initial Catalog=inventory_DB;Integrated Security=True;TrustServerCertificate=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //fetch data when load the table
            BindData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (productID.Text != "")
            {
                if (MessageBox.Show("Aare you sure to delete ?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete inventory where productID='" + int.Parse(productID.Text) + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("product deleted successfully");
                    BindData();
                }
            }
            else
            {
                MessageBox.Show("Please enter product ID to delete");
            }
        }
        void BindData() {
            SqlCommand cmd = new SqlCommand("select * from inventory", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd); //SqlDataAdapter is used to fill the DataTable with data from the database
            DataTable dt = new DataTable();    //create empty DataTable
            sd.Fill(dt);
            dataGridView.DataSource = dt;   //set the DataSource of the DataGridView to the DataTable
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into inventory values('"+int.Parse(productID.Text)+"','"+(productName.Text)+"','"+(productType.Text)+"','"+(productQuantity.Text)+"','"+(productColour.Text)+"','"+(productDate.Text)+"')",con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            con.Close();
            BindData(); //because after insert then refresh again the fetch table
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update inventory set productName='" + productName.Text + "',productType='" + productType.Text + "',productQuantity='" + productQuantity.Text + "',productColour='" + productColour.Text + "',productDate= '" + productDate.Text + "'"+"where productID='"+int.Parse(productID.Text)+"'", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Update Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            con.Close();
            BindData(); //because after insert then refresh again the fetch table
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            if (productID.Text != "")
            {
               
                SqlCommand cmd = new SqlCommand("select * from inventory where productID ='" + productID.Text + "'", con);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView.DataSource = dt;
                
            }
            else
            {
                BindData();
                MessageBox.Show("Please enter product ID to search");
            }
            con.Close();

        }
    }
}
