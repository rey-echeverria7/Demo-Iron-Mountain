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
using System.IO;

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

                if (employees != null)
                {
                    if (employees.Rows.Count > 0)
                    {
                        DataSet ds = new DataSet();
                        ds.Tables.Add(employees);
                        ds.DataSetName = "Employees";
                        employees.TableName = "Employee";
                        ds.WriteXml(@"C:\Users\user\Desktop\Rey\Demo .net/employeesXML.xml");
                        MessageBox.Show("Archivo XML creado!");
                    }
                    else
                    {
                        MessageBox.Show("No hay empleados registrados");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar los registros de la BD" + ex);
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

                if (employees != null)
                {
                    if (employees.Rows.Count > 0)
                    {
                        StreamWriter employeeRecords = new StreamWriter(@"C:\Users\user\Desktop\Rey\Demo .net/employees.txt");

                        foreach (DataRow row in employees.Rows)
                        {
                            string id = row["EmployeeID"].ToString();
                            string lastName = row["LastName"].ToString();
                            string firstName = row["FirstName"].ToString();
                            string birthday = row["DOB"].ToString();

                            employeeRecords.WriteLine(id + "|" + lastName + "|" + firstName + "|" + birthday);
                        }
                        MessageBox.Show("Archivo de texto creado!");
                        employeeRecords.Close();
                    }
                    else
                    {
                        MessageBox.Show("No hay empleados registrados");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recuperar los registros de la BD" + ex);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                date = DateTime.ParseExact(birthDayTextBox.Text, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "insert into Employees (EmployeeID, LastName, FirstName, DOB) values ('" + employeeIdTextBox.Text + "','" + lastNameTextBox.Text + "','" + firstNameTextBox.Text + "','" + DateTime.ParseExact(birthDayTextBox.Text, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToShortDateString() + "')";

                if (employeeIdTextBox.Text != "" && lastNameTextBox.Text != "" && birthDayTextBox.Text != "" && date < DateTime.Now)
                {
                    command.CommandText = query;
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
                    MessageBox.Show("Revise que todos los campos esten completos");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la BD...");
                connection.Close();
            }
        }
        private void employeeIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(employeeIdTextBox.Text))
            {
                employeeIdTextBox.Focus();
                errorProvider1.SetError(employeeIdTextBox, "Ingrese un ID");
            }
            else if (employeeIdTextBox.Text.Length > 8 || employeeIdTextBox.Text.Length < 8)
            {
                employeeIdTextBox.Focus();
                errorProvider1.SetError(employeeIdTextBox, "ID debe contener 8 numeros");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(employeeIdTextBox.Text, "[^0-9]"))
            {
                employeeIdTextBox.Focus();
                errorProvider1.SetError(employeeIdTextBox, "ID solo caracteres numéricos");
            }
            else
            {
                errorProvider1.SetError(employeeIdTextBox, "");
            }
        }
        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Ingrese el Apellido");
            }
            else if (lastNameTextBox.Text.Length > 30)
            {
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Admite solo 30 carácteres");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(lastNameTextBox.Text, "[a-zA-Z]") == false)
            {
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Solo a-z y comas");
            }
            else
            {
                errorProvider2.SetError(lastNameTextBox, "");
            }
        }
        private void firstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (firstNameTextBox.Text.Length > 30)
            {
                firstNameTextBox.Focus();
                errorProvider3.SetError(firstNameTextBox, "Admite solo 30 carácteres");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(firstNameTextBox.Text, "^[a-zA-Z]$"))
            {
                lastNameTextBox.Focus();
                errorProvider2.SetError(lastNameTextBox, "Solo a-z y comas");
            }
            else
            {
                errorProvider3.SetError(firstNameTextBox, "");
            }
        }
        private void birthDayTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                date = DateTime.ParseExact(birthDayTextBox.Text, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                errorProvider4.SetError(birthDayTextBox, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Formato de fecha incorrecto: debe estar en formato MMddyyyy: " + ex);
            }

            if (string.IsNullOrEmpty(birthDayTextBox.Text))
            {
                birthDayTextBox.Focus();
                errorProvider4.SetError(birthDayTextBox, "Ingrese cumpleaños");
            }
            else if (birthDayTextBox.Text.Length > 8)
            {
                birthDayTextBox.Focus();
                errorProvider4.SetError(birthDayTextBox, "Formato fecha incorrecto");
            }
            else if (date > DateTime.Now)
            {
                birthDayTextBox.Focus();
                errorProvider4.SetError(birthDayTextBox, "La fecha no ha pasado");
            }
            else
            {
                errorProvider4.SetError(firstNameTextBox, "");
            }
        }

    }
}