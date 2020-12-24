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
    public partial class Form5 : Form
    {
        //================================================ BOSS

        public User User = new User();
        public Form5()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }

        //========================================= ADD NEW VACANCY OFFER
        private void addVacancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5Vacancy form5Vacancy = new Form5Vacancy();
            form5Vacancy.GetUser(User);
            form5Vacancy.ShowDialog();
        }

        //========================================= LOG OUT
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        //==================================== SHOWS ALL WORKERS APPLIED TO THE WORKS
        private void showWorkAppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5AppliedWorkers form5AppliedWorkers = new Form5AppliedWorkers();
            form5AppliedWorkers.GetUser(User);
            form5AppliedWorkers.ShowDialog();
        }

        //==================================== SHOWS ALL VACANCIES THAT BOSS POSTED
        private void yourPostedVacanciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5PostedVacancies form5PostedVacancies = new Form5PostedVacancies();
            form5PostedVacancies.GetUser(User);
            form5PostedVacancies.Show();
        }

        //===================================== SEARCHS CVS PER CATEGORY
        private void searchPerCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5SearchPerCategory form5SearchPerCategory = new Form5SearchPerCategory();
            form5SearchPerCategory.GetUser(User);
            form5SearchPerCategory.ShowDialog();
        }
    }
}
