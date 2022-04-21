
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.createXmlFile = new System.Windows.Forms.Button();
            this.employeeId = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.Label();
            this.birthday = new System.Windows.Forms.Label();
            this.employeeIdTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.birthDayTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.createTextFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createXmlFile
            // 
            this.createXmlFile.Location = new System.Drawing.Point(519, 184);
            this.createXmlFile.Name = "createXmlFile";
            this.createXmlFile.Size = new System.Drawing.Size(123, 79);
            this.createXmlFile.TabIndex = 2;
            this.createXmlFile.Text = "Create XML file";
            this.createXmlFile.UseVisualStyleBackColor = true;
            this.createXmlFile.Click += new System.EventHandler(this.createXmlFile_Click);
            // 
            // employeeId
            // 
            this.employeeId.AutoSize = true;
            this.employeeId.Location = new System.Drawing.Point(60, 49);
            this.employeeId.Name = "employeeId";
            this.employeeId.Size = new System.Drawing.Size(100, 20);
            this.employeeId.TabIndex = 3;
            this.employeeId.Text = "Employee ID";
            // 
            // lastName
            // 
            this.lastName.AutoSize = true;
            this.lastName.Location = new System.Drawing.Point(66, 97);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(94, 20);
            this.lastName.TabIndex = 4;
            this.lastName.Text = "Last Name: ";
            // 
            // firstName
            // 
            this.firstName.AutoSize = true;
            this.firstName.Location = new System.Drawing.Point(66, 140);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(94, 20);
            this.firstName.TabIndex = 5;
            this.firstName.Text = "First Name: ";
            // 
            // birthday
            // 
            this.birthday.AutoSize = true;
            this.birthday.Location = new System.Drawing.Point(64, 199);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(105, 20);
            this.birthday.TabIndex = 6;
            this.birthday.Text = "Date of birth: ";
            // 
            // employeeIdTextBox
            // 
            this.employeeIdTextBox.Location = new System.Drawing.Point(167, 49);
            this.employeeIdTextBox.Name = "employeeIdTextBox";
            this.employeeIdTextBox.Size = new System.Drawing.Size(270, 26);
            this.employeeIdTextBox.TabIndex = 7;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(167, 97);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(270, 26);
            this.lastNameTextBox.TabIndex = 8;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(167, 140);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(270, 26);
            this.firstNameTextBox.TabIndex = 9;
            // 
            // birthDayTextBox
            // 
            this.birthDayTextBox.Location = new System.Drawing.Point(167, 199);
            this.birthDayTextBox.Name = "birthDayTextBox";
            this.birthDayTextBox.Size = new System.Drawing.Size(270, 26);
            this.birthDayTextBox.TabIndex = 10;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(540, 42);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 40);
            this.submitButton.TabIndex = 11;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // createTextFileButton
            // 
            this.createTextFileButton.Location = new System.Drawing.Point(519, 100);
            this.createTextFileButton.Name = "createTextFileButton";
            this.createTextFileButton.Size = new System.Drawing.Size(123, 66);
            this.createTextFileButton.TabIndex = 12;
            this.createTextFileButton.Text = "Create text file";
            this.createTextFileButton.UseVisualStyleBackColor = true;
            this.createTextFileButton.Click += new System.EventHandler(this.createTextFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 303);
            this.Controls.Add(this.createTextFileButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.birthDayTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.employeeIdTextBox);
            this.Controls.Add(this.birthday);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.employeeId);
            this.Controls.Add(this.createXmlFile);
            this.Name = "Form1";
            this.Text = "Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createXmlFile;
        private System.Windows.Forms.Label employeeId;
        private System.Windows.Forms.Label lastName;
        private System.Windows.Forms.Label firstName;
        private System.Windows.Forms.Label birthday;
        private System.Windows.Forms.TextBox employeeIdTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox birthDayTextBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button createTextFileButton;
    }
}

