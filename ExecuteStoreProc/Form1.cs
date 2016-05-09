using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExecuteStoreProc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection mysqlConnection = new SqlConnection("server=D5090\\SQLEXPRESS;database=Sample;Integrated Security=SSPI");

            SqlCommand mysqlCmd = mysqlConnection.CreateCommand();

            mysqlCmd.CommandText = "EXECUTE AddEmployee @FName, @LName, @EmpNo, @IsDelete";

            mysqlCmd.Parameters.Add("@FName", SqlDbType.NChar, 10).Value = "Joe";
            mysqlCmd.Parameters.Add("@LName", SqlDbType.NChar, 10).Value = "Monatana";
            mysqlCmd.Parameters.Add("@EmpNo", SqlDbType.NChar, 10).Value = "49er";
            mysqlCmd.Parameters.Add("@IsDelete", SqlDbType.NChar, 10).Value = false;


            mysqlConnection.Open();
            mysqlCmd.ExecuteNonQuery();
            mysqlConnection.Close();
        }
    }
}
