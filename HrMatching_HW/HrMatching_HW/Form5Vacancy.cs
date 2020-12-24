using HrMatching_HW.DbContexts;
using HrMatching_HW.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatching_HW
{
    public partial class Form5Vacancy : Form
    {
        public User User = new User();
        public Form5Vacancy()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //=============================================== CHECKS WHETHER INPUT FIELDS ARE EMPTY OR NOT
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) ||
                numericUpDown1.Text == "" || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox3.Text) || string.IsNullOrEmpty(comboBox4.Text) ||
                numericUpDown2.Text == "" || string.IsNullOrEmpty(comboBox5.Text) || !maskedTextBox1.MaskCompleted)
            {
                MessageBox.Show("Please, Complete the Form", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Vacancy vacancy = new Vacancy()
                {
                    VacancyName = textBox1.Text,
                    CompanyName = textBox2.Text,
                    JobDescription = textBox3.Text,
                    Age = int.Parse(numericUpDown1.Value.ToString()),
                    Education = comboBox2.Text,
                    Job = comboBox3.Text,
                    City = comboBox4.Text,
                    SalaryOffer = int.Parse(numericUpDown2.Value.ToString()),
                    Experience = comboBox5.Text,
                    Phone = maskedTextBox1.Text,
                    UserId = User.id
                };

                //===================================== ADDS VACANCY TO DB
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    db.Vacancies.Add(vacancy);
                    db.SaveChanges();
                    MessageBox.Show("Your Vacancy Offer added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
            }
        }
    }
}
