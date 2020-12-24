using HrMatching_HW.DbContexts;
using HrMatching_HW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HrMatching_HW
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (HrMatchingContext db = new HrMatchingContext())
            //{
                //db.Users.Add(new User() { Username = "Rasim", Email = "rasim@gmail.com", Status = 1, Password = "Rasim_123" });
                //db.SaveChanges();

                //db.Users.Add(new User() { Username = "Ismayil", Email = "ismayil@gmail.com", Status = 2, Password = "Ismayil_123" });
                //db.SaveChanges();

                //db.CVs.Add(new CV()
                //{
                //    Name = "Rasim",
                //    Surname = "Mammadov",
                //    Gender = "Male",
                //    Age = 19,
                //    Education = "Middle",
                //    Job = "IT Specialist",
                //    Experience = "1-",
                //    City = "Baku",
                //    MinSalary = 800,
                //    Phone = "+994506549875",
                //    User = db.Users.FirstOrDefault(x => x.id == 3),
                //});
                //db.SaveChanges();

                //db.Vacancies.Add(new Vacancy()
                //{
                //    VacancyName = "IT Specialist Axtarilir",
                //    CompanyName = "Labrin",
                //    Age = 20,
                //    Education = "High",
                //    Experience = "5+",
                //    Job = "IT Specialist",
                //    JobDescription = "Part-time",
                //    City = "Baku",
                //    SalaryOffer = 1000,
                //    Phone = "+994501236585",
                //    User = db.Users.FirstOrDefault(x => x.id == 4)
                //});
                //db.SaveChanges();

                //var cv = db.CVs.FirstOrDefault(x => x.id == 2);
                //var vac = db.Vacancies.FirstOrDefault(x => x.id == 1);

                //string name = cv.Name;
                //string otherName = vac.CompanyName;

                //vac.CVs.Add(cv);

                //db.SaveChanges();
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
