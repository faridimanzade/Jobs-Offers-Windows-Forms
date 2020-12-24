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
    public partial class Form4AppliedList : Form
    {
        public User User = new User();
        List<Vac> vacs = new List<Vac>();

        public Form4AppliedList()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }

        private void Form4AppliedList_Load(object sender, EventArgs e)
        {
            using (HrMatchingContext db = new HrMatchingContext())
            {
                //================ FINDS THE ENTERED WORKERS CV AND INCLUDES VACANCIES TO REACH THEM
                var cv = db.CVs.Include("Vacancies").FirstOrDefault(x=>x.UserId == User.id);

                //================ CHECKS WHETHER THIS USER HAS CV
                if (cv != null)
                {
                    foreach (var item in cv.Vacancies)
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
                            Phone = item.Phone
                        });
                    }
                }
                dataGridView1.DataSource = vacs;
            }
        }
    }
}
