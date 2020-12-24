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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //============================== CHECKS WHETHER INPUT FIELDS ARE EMPTY
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please, Complete the Form", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //============================== CONNECT TO DB AND TRYING TO ENTER
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    //========================= FINDS CORRESPONDING USER 
                    var User = db.Users.FirstOrDefault(x => x.Username == textBox1.Text && x.Password == textBox2.Text);

                    //===================== CHECKS WHETHER USER IS FOUND OR NOT
                    if (User != null)
                    {
                        //===================== CHECKS WHETHER USER IS BOSS OR WORKER
                        if (User.Status == 1)
                        {
                            Form4 form4 = new Form4();
                            //===================== SENDS FOUND USER TO THE OTHER FORM
                            form4.GetUser(User);

                            form4.Show();
                            this.Hide();
                        }
                        else if (User.Status == 2)
                        {
                            Form5 form5 = new Form5();
                            //===================== SENDS FOUND USER TO THE OTHER FORM
                            form5.GetUser(User);

                            form5.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Such User, Try Again!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        //============================= OPEN SIGN UP PAGE
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
