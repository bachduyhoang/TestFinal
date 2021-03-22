
using FacultyAssembly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        FacultyDAO dao = new FacultyDAO();
        List<Faculty> listFaculty = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            listFaculty = dao.getListData("");
            dgvFaculty.DataSource = listFaculty;
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            txtAddress.DataBindings.Clear();


            txtID.DataBindings.Add("Text", listFaculty, "ID");
            txtName.DataBindings.Add("Text", listFaculty, "Name");
            txtAge.DataBindings.Add("Text", listFaculty, "Age");
            txtAddress.DataBindings.Add("Text", listFaculty, "Address");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string check = validation();
            if (check == null)
            {
                Faculty faculty = new Faculty
                {
                    ID = int.Parse(txtID.Text),
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Age = int.Parse(txtAge.Text)
                };

                bool checkAdd = dao.Update(faculty);
                if (checkAdd)
                {
                    MessageBox.Show("Update successfull");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("ID is not exist !");
                }
            }
            else
            {
                MessageBox.Show(check);
            }
        }

        private string validation()
        {
            if(txtID.Text.Trim() == string.Empty)
            {
                return "ID is not null";
            }else if(txtAddress.Text.Trim() == string.Empty)
            {
                return "Address is not null";
            }else if(txtAge.Text.Trim() == string.Empty)
            {
                return "Age is not null";
            }else if(txtName.Text.Trim() == string.Empty)
            {
                return "Name is not null";
            }

            try
            {
                int.Parse(txtID.Text);
            }
            catch (Exception)
            {
                return "Invalid Data ID";
            }

            try
            {
                int.Parse(txtAge.Text);
            }
            catch (Exception)
            {
                return "Invalid Data Age";
            }
            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string check = validation();
            if (check == null)
            {                
                
                Faculty faculty = new Faculty
                {
                    ID = int.Parse(txtID.Text),
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Age = int.Parse(txtAge.Text)
                };

                bool checkAdd = dao.Add(faculty);
                if (checkAdd == true)
                {
                    MessageBox.Show("Add successfull");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("ID existed !");
                }
            }
            else
            {
                MessageBox.Show(check);
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if(name.Trim() == null)
            {
                MessageBox.Show("Please Enter Name");
            }
            else
            {
                listFaculty = dao.getListData(name);
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                bool checkAdd = dao.Delete(id);
                if (checkAdd)
                {
                    MessageBox.Show("Delete successfull");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("ID is not exist !");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid id");
            }

        }
    }
}
