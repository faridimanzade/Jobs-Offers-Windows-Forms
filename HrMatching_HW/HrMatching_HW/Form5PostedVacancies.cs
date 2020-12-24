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
    public partial class Form5PostedVacancies : Form
    {
        public User User = new User();
        List<PostedVacancy> postedVacancies = new List<PostedVacancy>();
        public Form5PostedVacancies()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }

        private void Form5PostedVacancies_Load(object sender, EventArgs e)
        {
            using (HrMatchingContext db = new HrMatchingContext())
            {
                var postedVacSelf = db.Vacancies.Where(x => x.UserId == User.id).ToList();

                if (postedVacSelf != null)
                {
                    foreach (var item in postedVacSelf)
                    {
                        postedVacancies.Add(new PostedVacancy()
                        {
                            id = item.id,
                            Vacancy_Name = item.VacancyName,
                            Company_Name = item.CompanyName,
                            Age = item.Age,
                            Education = item.Education,
                            Experience = item.Experience,
                            Job = item.Job,
                            Job_description = item.JobDescription,
                            City = item.City,
                            Offered_Salary = item.SalaryOffer,
                            Phone = item.Phone
                        });
                    }
                }
                dataGridView1.DataSource = postedVacancies;
            }
        }
    }

    public class PostedVacancy
    {
        public int id { get; set; }
        public string Vacancy_Name { get; set; }
        public string Company_Name { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Job { get; set; }
        public string Job_description { get; set; }
        public string City { get; set; }
        public int Offered_Salary { get; set; }
        public string Phone { get; set; }
    }
}
