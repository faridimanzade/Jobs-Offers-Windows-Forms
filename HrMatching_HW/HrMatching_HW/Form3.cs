using HrMatching_HW.DbContexts;
using HrMatching_HW.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatching_HW
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //======================= RANDOM CODE GENERATOR
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //======================= RANDOM CODE GENERATOR

        private void button1_Click(object sender, EventArgs e)
        {
            var checkedButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            var passPattern = @"^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{4,})";

            //====================== CHECKS WHETHER INPUTS ARE EMPTY OR NOT
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || checkedButton == null)
            {
                MessageBox.Show("Please, Complete the Form", "Empty Inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //====================== CHECKS WHETHER EMAIL IS VALID 
                if (Regex.IsMatch(textBox2.Text, emailPattern))
                {
                    //====================== CHECKS WHETHER PASSWORD IS VALID 
                    if (Regex.IsMatch(textBox3.Text, passPattern))
                    {
                        //====================== CHECKS WHETHER PASSWORDS MATCH 
                        if (textBox3.Text == textBox4.Text)
                        {
                            //====================== CHECKS WHETHER RANDOM GENERATED CODE IS CORRECT
                            if (label8.Text == textBox5.Text)
                            {
                                //====================== ADD NEW USER TO DB
                                using (HrMatchingContext db = new HrMatchingContext())
                                {
                                    //====================== CHECKS WHETHER SUCH USERNAME EXISTS OR NOT 
                                    var flag = db.Users.ToList().Exists(x => x.Username == textBox1.Text);
                                    if (flag == false)
                                    {
                                        //====================== GETS STATUS RELATIVE TO RADIO BUTTON
                                        int status = checkedButton.Text == "Boss" ? 2 : 1;

                                        User user = new User()
                                        {
                                            Username = textBox1.Text,
                                            Email = textBox2.Text,
                                            Status = status,
                                            Password = textBox3.Text,
                                        };

                                        db.Users.Add(user);
                                        db.SaveChanges();

                                        MessageBox.Show("You Signed Up Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        Form2 form2 = new Form2();
                                        form2.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Username Is Already Taken, Please change it.", "Reserved Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }                                    
                                }
                            }
                            else
                            {
                                label8.Text = RandomString(4);
                                MessageBox.Show("Enter Random Generated Code Again", "Cannot Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Passwords don't match", "Cannot Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please, Provide Valid Password\n\n(Characters at Least 4, 1 Capital letter, 1 small letter, 1 number, 1 special Character)\n\nExample: Farid_123", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please, Provide Valid Email Address", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //======================= SETS RANDOM STRING ON LOADING
            label8.Text = RandomString(4);
        }
    }
}
