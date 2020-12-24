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
    public partial class Form4 : Form
    {
        //==================================== WORKER

        public User User = new User();
        public Form4()
        {
            InitializeComponent();
        }

        //============================ GETS AND ASSIGNS ENTERED USER
        public void GetUser(User user)
        {
            this.User = user;
        }


        //===================================== ADDS NEW CV
        private void aDDYourCVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            bool isExists = false;
            using (HrMatchingContext db = new HrMatchingContext())
            {
                isExists = db.CVs.ToList().Exists(x => x.UserId == User.id);
            }

            //=========================== CHECKS WHETHER USER ALREAYD HAVE CV OR NOT
            if (isExists)
            {
                MessageBox.Show("You Have Already Uploaded CV, You can Check it from Info section", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Form4CV form4CV = new Form4CV();
                form4CV.GetUser(User);
                form4CV.ShowDialog();
            }
        }

        //===================================== SHOWS ALL INFORMATION WRITTEN IN THE CV
        private void showYourInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HrMatchingContext db = new HrMatchingContext())
            {
                var foundCV = db.CVs.ToList().FirstOrDefault(x => x.UserId == User.id);

                //==================== CHECLS WHETHER SUCH USER HAVE CV OR NOT
                if (foundCV != null)
                {
                    panel1.Visible = true;
             
                    label2.Text = foundCV.Name + " " + foundCV.Surname;
                    label8.Text = foundCV.Gender;
                    label9.Text = foundCV.Age.ToString();
                    label10.Text = foundCV.Education;
                    label11.Text = foundCV.Job;
                    label16.Text = foundCV.Experience;
                    label17.Text = foundCV.City;
                    label18.Text = foundCV.MinSalary.ToString();
                    label19.Text = foundCV.Phone;
                }
                else
                {
                    MessageBox.Show("You Haven't added your CV yet.\nYou can do it From 'Add Your CV' Section", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //===================================== LOG OUT
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        //===================================== SHOW ALL VACANCIES
        private void showAllVacanciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Form4AllVacancies form4AllVacancies = new Form4AllVacancies();
            form4AllVacancies.GetUser(User);
            form4AllVacancies.ShowDialog();
        }

        //===================================== SHOWS ALL JOBS THAT WORKER APPLIED
        private void allAppliedJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Form4AppliedList form4AppliedList = new Form4AppliedList();
            form4AppliedList.GetUser(User);
            form4AppliedList.ShowDialog();
        }

        //===================================== SEARCHS VACANCIES PER CATEGORY
        private void searchPerCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Form4SearchPerCategory form4SearchPerCategory = new Form4SearchPerCategory();
            form4SearchPerCategory.GetUser(User);
            form4SearchPerCategory.ShowDialog();
        }

        //=================================== MOST SUITABLE OFFERS FOR YOU
        private void mostSuitableOffersForYouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4MostSuitable form4MostSuitable = new Form4MostSuitable();
            form4MostSuitable.GetUser(User);
            form4MostSuitable.ShowDialog();
        }
    }
}
