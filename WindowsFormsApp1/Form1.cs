using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        string stringConnection = ConfigurationManager.ConnectionStrings["Connection"].ToString();
       
        
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @stringConnection;
                
                
        }

       

        private void createXmlFile_Click(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            try
            {
                connection.Open();
                
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Employees (EmployeeID, LastName, FirstName, DOB) values ('" + employeeIdTextBox.Text + "','" + lastNameTextBox.Text + "','" + firstNameTextBox.Text + "','" + birthDayTextBox.Text + "')";

                command.ExecuteNonQuery();
                MessageBox.Show("Empleado insertado correctamente!");
                connection.Close();

                employeeIdTextBox.Text = "";
                lastNameTextBox.Text = "";
                firstNameTextBox.Text = "";
                birthDayTextBox.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la BD..." + ex);
            }
        }

        private void createTextFileButton_Click(object sender, EventArgs e)
        {
            
        }

        private void createXML()
        {

        }
    }
}
