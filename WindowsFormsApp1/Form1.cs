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
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        string stringConnection = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        DateTime date;

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

                if (employeeIdTextBox.Text != "" && lastNameTextBox.Text != "" && birthDayTextBox.Text != "")
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Empleado insertado correctamente!");
                    connection.Close();
                    employeeIdTextBox.Text = "";
                    lastNameTextBox.Text = "";
                    firstNameTextBox.Text = "";
                    birthDayTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Debe ingresar los valores en los campos correspondientes");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la BD..." + ex);
            }
        }

        private void createTextFileButton_Click(object sender, EventArgs e)
        {

            DataTable employees = new DataTable();

            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Employees";

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                adapter.Fill(employees);
                connection.Close();

                foreach (DataRow row in employees.Rows)
                {
                    string id = row["EmployeeID"].ToString();
                    string lastName = row["LastName"].ToString();
                    string firstName = row["FirstName"].ToString();
                    string birthday = row["DOB"].ToString();

                    Console.WriteLine(id+"|"+lastName + "|"+firstName + "|"+birthday);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void createXML()
        {

        }

        private void employeeIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(employeeIdTextBox.Text))
            {
                e.Cancel = true;
                employeeIdTextBox.Focus();
                errorProvider1.SetError(employeeIdTextBox, "Ingrese un ID");
            }
            else if (employeeIdTextBox.Text.Length > 8 || employeeIdTextBox.Text.Length < 8)
            {
                e.Cancel = true;
                employeeIdTextBox.Focus();
                errorProvider1.SetError(employeeIdTextBox, "ID debe contener 8 numeros");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(employeeIdTextBox.Text, "[^0-9]"))
            {
                e.Cancel = true;
                employeeIdTextBox.Focus();
                errorProvider1.SetError(employeeIdTextBox, "ID solo caracteres numéricos");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(employeeIdTextBox, "");
            }
        }

        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                e.Cancel = true;
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Ingrese el Apellido");
            }
            else if (lastNameTextBox.Text.Length > 30 )
            {
                e.Cancel = true;
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Admite solo 30 carácteres");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(lastNameTextBox.Text, "[a-zA-Z]")==false)
            {
                e.Cancel = true;
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Solo a-z y comas");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(lastNameTextBox, "");
            }
        }

        

        private void firstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (firstNameTextBox.Text.Length > 30)
            {
                e.Cancel = true;
                firstNameTextBox.Focus();
                errorProvider3.SetError(firstNameTextBox, "Admite solo 30 carácteres");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(firstNameTextBox.Text, "^[a-zA-Z]$"))
            {
                e.Cancel = true;
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Solo a-z y comas");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(firstNameTextBox, "");
            }
        }

        private void birthDayTextBox_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                date = DateTime.ParseExact(birthDayTextBox.Text, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                e.Cancel = true;
                birthDayTextBox.Focus();
                errorProvider4.SetError(birthDayTextBox, "");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Formato de fecha incorrecto: debe estar en formato MMddyyyy");
            }

            if (string.IsNullOrEmpty(birthDayTextBox.Text))
            {
                e.Cancel = true;
                birthDayTextBox.Focus();
                errorProvider4.SetError(birthDayTextBox, "Ingrese cumpleaños");
            }
            else if (birthDayTextBox.Text.Length > 8)
            {
                e.Cancel = true;
                birthDayTextBox.Focus();
                errorProvider4.SetError(birthDayTextBox, "Formato fecha incorrecto");
            }
            else if (date>DateTime.Now)
            {
                e.Cancel = true;
                birthDayTextBox.Focus();
                errorProvider4.SetError(birthDayTextBox, "La fecha no ha pasado");
            }

            else
            {
                e.Cancel = false;
                errorProvider4.SetError(firstNameTextBox, "");
            }
        }
    }
   
}


