using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EmployeeRecords
{
    public partial class mainForm : Form
    {
        List<Employee> employeeDB = new List<Employee>();

        public mainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Employee ep = new Employee(idInput.Text, fnInput.Text, lnInput.Text, dateInput.Text, salaryInput.Text);
            employeeDB.Add(ep);
            outputLabel.Text = "New Employee added";
            ClearLabels();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = null;
            foreach (Employee ep in  employeeDB)
            {
                outputLabel.Text += ep.id + "\n" + ep.firstName + "  " + ep.lastName + "  " + ep.date + "  " + ep.salary + "\n\n";
            }
        }

        private void ClearLabels()
        {
            idInput.Text = "";
            fnInput.Text = "";
            lnInput.Text = "";
            dateInput.Text = "";
            salaryInput.Text = "";
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void loadDB()
        {
            
        }

        public void saveDB()
        {
            XmlWriter write = XmlWriter.Create("Resources/EmployeeData.xml", null);
            write.WriteStartElement("Employee");

            foreach (Employee ep in employeeDB)
            {
                write.WriteElementString("id", ep.id);
                write.WriteElementString("firstName", ep.firstName);
                write.WriteElementString("lastName", ep.lastName);
                write.WriteElementString("date", ep.date);
                write.WriteElementString("salary", ep.salary);
            }
        }
    }
}