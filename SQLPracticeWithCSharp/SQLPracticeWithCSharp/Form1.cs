using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLPracticeWithCSharp
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

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtBoxID.Text);
            int EMP = Convert.ToInt32(txtBoxEmp.Text);

            ExecNQ("INSERT INTO Business (ID, Owner, BusinessName, Employees) VALUES('" + ID + "','" + txtBoxOwner.Text + "','" + txtBoxBusiness.Text + "','"+ EMP +"')");
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            ExecNQ($"DELETE Business WHERE ID={txtBoxID.Text}");
        }
        private void ExecNQ(string commTXT)
        {
            string connectString = @"Data Source=DESKTOP-FTT4EST\SQLEXPRESS;Initial Catalog=BusinessDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectString);

            con.Open();
            SqlCommand command = new SqlCommand(commTXT, con);
            int res = command.ExecuteNonQuery(); //Insert,Update,Delete - when we want to use this command need NonQuery

            con.Close();
            MessageBox.Show((res == 1 ? "" : "not") + "succeeded");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txtBoxID.Text);
            int EMP = Convert.ToInt32(txtBoxEmp.Text);
            ExecNQ($" UPDATE Business Set Name='{txtBoxOwner.Text}' " +
                $", BusinessName='{txtBoxBusiness.Text}'"+
                $", Employees='{EMP}'"
                + $"WHERE ID='{ID}'");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string output = "";
            string connectString = @"Data Source=DESKTOP-FTT4EST\SQLEXPRESS;Initial Catalog=BusinessDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand("SELECT * " +
                "FROM Business " +
                "Order By Name", con);
            con.Open();
            
            
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                output += reader[0]+ ", "+reader["Owner"]+" , "+reader["BusinessName"] + " , " + reader["Employees"]+"\n";
            }
            con.Close();
            lblUsers.Text = output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxBusiness_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
