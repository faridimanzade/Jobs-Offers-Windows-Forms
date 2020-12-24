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
    public partial class Form4AllVacancies : Form
    {
        public User User = new User();
        List<Vac> vacs = new List<Vac>();

        public Form4AllVacancies()
        {
            InitializeComponent();
        }

        public void GetUser(User user)
        {
            this.User = user;
        }


        //======================================= FILLS THE DATAGRIDVIEW
        private void Form4AllVacancies_Load(object sender, EventArgs e)
        {
            label2.Visible = true;
            button1.Visible = true;
            numericUpDown1.Visible = true;
            using (HrMatchingContext db = new HrMatchingContext())
            {
                foreach (var item in db.Vacancies)
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


        //=========================================== APPLIES TO THE VACANCY
        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Text == "")
            {
                MessageBox.Show("You haven't Entered id\nOr id that you entered is not valid", "Empty inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    //===================== CHECKS WHETHER VACANCY EXISTS OR NOT
                    bool isExists = db.Vacancies.ToList().Exists(x => x.id == numericUpDown1.Value);
                    if (isExists)
                    {
                        var foundCv = db.CVs.FirstOrDefault(x => x.UserId == User.id);
                        if (foundCv != null)
                        {
                            var selectedVac = db.Vacancies.FirstOrDefault(x => x.id == numericUpDown1.Value);
                            selectedVac.CVs.Add(foundCv);
                            db.SaveChanges();
                            MessageBox.Show("You have applied to the vacancy successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            numericUpDown1.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("You haven't Added your CV\nPlease, add your CV from main Menu, then you can apply For the Job", "CV Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have Entered Invalid vacancy id", "Invalid inputs", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }


    class Vac
    {
        public int id { get; set; }
        public string VacancyName { get; set; }
        public string CompanyName { get; set; }
        public string Job { get; set; }
        public string JobDescription { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public int SalaryOffer { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
    }
}
