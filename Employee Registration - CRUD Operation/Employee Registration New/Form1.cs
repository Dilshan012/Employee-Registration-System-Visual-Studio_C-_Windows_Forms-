using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Registration_New
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Rashini Madhuka\\Desktop\\VP\\Employee Registration New\\Employee Registration New\\EmployeeDatabase.mdf\";Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, gender = "", contact = textBox4.Text;
            double age = double.Parse(textBox3.Text);
            DateTime joiningdate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }else
                gender = radioButton2.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("exec InsertEmp '"+empid+ "', '"+empname+ "', '"+city+ "', '"+age+ "', '"+gender+ "', '"+joiningdate+"','"+contact+"'",con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully inserted");
            GetEmpList();
            con.Close();
        }
        void GetEmpList()
        {
            SqlCommand cmd = new SqlCommand("exec ListEmp",con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, city = comboBox1.Text, gender = "", contact = textBox4.Text;
            double age = double.Parse(textBox3.Text);
            DateTime joiningdate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else
                gender = radioButton2.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("exec UpdateEmp '" + empid + "', '" + empname + "', '" + city + "', '" + age + "', '" + gender + "', '" + joiningdate + "','" + contact + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully updated");
            GetEmpList();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete

            if(MessageBox.Show("Are you sure to delete", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int empid = int.Parse(textBox1.Text);
                con.Open();
                SqlCommand cmd = new SqlCommand("exec DeleteEmp '" + empid + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully deleted");
                GetEmpList();
                con.Close();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Search
            int empid = int.Parse(textBox1.Text);
            SqlCommand cmd = new SqlCommand("exec SearchEmp '" + empid + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
