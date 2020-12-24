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
    public partial class Form4SearchPerCategory : Form
    {
        public User User = new User();
        List<Vac> vacs = new List<Vac>();

        public Form4SearchPerCategory()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (comboBox3.Text != "")
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundVac = db.Vacancies.Where(x => x.Job == comboBox3.Text).ToList();
                    ListAdder(foundVac);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (comboBox2.Text != "")
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundVac = db.Vacancies.Where(x => x.Education == comboBox2.Text).ToList();
                    ListAdder(foundVac);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (comboBox4.Text != "")
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundVac = db.Vacancies.Where(x => x.City == comboBox4.Text).ToList();
                    ListAdder(foundVac);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (comboBox5.Text != "")
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundVac = db.Vacancies.Where(x => x.Experience == comboBox5.Text).ToList();
                    ListAdder(foundVac);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (numericUpDown2.Value > 100)
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundVac = db.Vacancies.Where(x => x.SalaryOffer >= numericUpDown2.Value).ToList();
                    if (foundVac != null)
                    {
                        ListAdder(foundVac);
                    }
                }
            }

            //======================= EMPITIES DATA GRID VIEW FOR THE NEXT SEARCHING
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = vacs;
            //======================= EMPITIES LIST FOR THE NEXT SEARCHING
            vacs = new List<Vac>();
        }


        //============================= FUNCTION THAT CHECKS TO ADD
        private void ListAdder(List<Vacancy> foundVac)
        {
            foreach (var item in foundVac)
            {
                //================ IF SUCH VACANCY ALREADY ADDED TO THE LIST, THEN IT WILL NOT BE ADDED AGAIN
                if (!vacs.Exists(x => x.id == item.id))
                {
                    vacs.Add(new Vac()
                    {
                        id = item.id,
                        VacancyName = item.VacancyName,
                        CompanyName = item.CompanyName,
                        Age = item.Age,
                        Education = item.Education,
                        Experience = item.Experience,
                        Job = item.Job,
                        JobDescription = item.JobDescription,
                        City = item.City,
                        SalaryOffer = item.SalaryOffer,
                        Phone = item.Phone,
                    });
                }
            }
        }
    }
}

