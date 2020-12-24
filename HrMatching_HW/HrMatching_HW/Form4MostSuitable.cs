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
    public partial class Form4MostSuitable : Form
    {
        public User User = new User();
        List<Vac> vacs = new List<Vac>();

        public Form4MostSuitable()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }

        private void Form4MostSuitable_Load(object sender, EventArgs e)
        {
            using (HrMatchingContext db = new HrMatchingContext())
            {
                //================================== FINDS WHETHER THIS USER HAS ADDED CV OR NOT
                var foundCV = db.CVs.FirstOrDefault(x => x.UserId == User.id);
                if (foundCV != null)
                {
                    //============================ FINDS VACANCIES WHICH HAS THE SAME "JOB","EDUCATION","CITY","EXPERIENCE","SALARY OFFER" with USER CV
                    var foundVacancies = db.Vacancies.Where(x => x.Job == foundCV.Job || 
                    x.Education == foundCV.Education ||
                    x.City == foundCV.City || 
                    x.Experience == foundCV.Experience || 
                    x.SalaryOffer >= foundCV.MinSalary).ToList();
                    
                    if (foundVacancies.Count > 0)
                    {
                        foreach (var item in foundVacancies)
                        {
                            vacs.Add(new Vac()
                            {
                                id = item.id,
                                VacancyName = item.VacancyName,
                                CompanyName = item.CompanyName,
                                Age = item.Age,
                                Education = item.Education,
                                Experience = item.Experience,
                                City = item.City,
                                Job = item.Job,
                                JobDescription = item.JobDescription,
                                SalaryOffer = item.SalaryOffer,
                                Phone = item.Phone
                            });
                        }

                        dataGridView1.DataSource = vacs;
                    }
                    else
                    {
                        MessageBox.Show("Currently there are no Suitable Jobs for You\nPlease, try later when new offers will be added", "Cannot Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You Haven't Added Your CV\nWe Cannot Show Suitable Jobs Without Knowing You", "CV Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
