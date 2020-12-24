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
    public partial class Form5AppliedWorkers : Form
    {
        public User User = new User();
        List<AppliedCV> appliedCVs = new List<AppliedCV>();

        public Form5AppliedWorkers()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }

        private void Form5AppliedWorkers_Load(object sender, EventArgs e)
        {
            using (HrMatchingContext db = new HrMatchingContext())
            {
                //=================== FINDS THIS USERS VACANCIES AND INCLUDES APPLIED CVS TO IT
                var userPostVac = db.Vacancies.Include("CVs").Where(x => x.UserId == User.id).ToList();
                int row = 0;

                //======================== LOOPS THROUGH POSTED VACANCIES
                foreach (var vac in userPostVac)
                {
                    //======================== LOOPS THROUGH CVS THAT APPLIED TO ONE VACANY
                    foreach (var cv in vac.CVs)
                    {
                        appliedCVs.Add(new AppliedCV()
                        {
                            Row = row,

                            Vacancy_Name = vac.VacancyName,
                            Company_Name = vac.CompanyName,
                            Job_Description = vac.JobDescription,

                            CV_ID = cv.id,
                            Name = cv.Name,
                            Surname = cv.Surname,
                            Gender = cv.Gender,
                            Age = cv.Age,
                            Education = cv.Education,
                            Job = cv.Job,
                            Experience = cv.Experience,
                            City = cv.City,
                            Minimum_Salary = cv.MinSalary,
                            Phone = cv.Phone
                        });
                        row++;
                    }
                }

                dataGridView1.DataSource = appliedCVs;
            }
        }
    }

    public class AppliedCV
    {
        public int Row { get; set; }
        public string Vacancy_Name { get; set; }
        public string Company_Name { get; set; }
        public string Job_Description { get; set; }

        public int CV_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        public string Job { get; set; }
        public string Experience { get; set; }
        public string City { get; set; }
        public int Minimum_Salary { get; set; }
        public string Phone { get; set; }
    }
}
