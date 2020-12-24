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
    public partial class Form5SearchPerCategory : Form
    {
        public User User = new User();
        List<CVSearch> CVSearches = new List<CVSearch>();

        public Form5SearchPerCategory()
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
                    var foundCV = db.CVs.Where(x => x.Job == comboBox3.Text).ToList();
                    ListAdder(foundCV);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (comboBox2.Text != "")
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundCV = db.CVs.Where(x => x.Education == comboBox2.Text).ToList();
                    ListAdder(foundCV);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (comboBox4.Text != "")
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundCV = db.CVs.Where(x => x.City == comboBox4.Text).ToList();
                    ListAdder(foundCV);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (comboBox5.Text != "")
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundCV = db.CVs.Where(x => x.Experience == comboBox5.Text).ToList();
                    ListAdder(foundCV);
                }
            }
            //======================== CHECKS WHETHER SEARCHING RELATIVE THIS CATEGORY IS SELECTED
            if (numericUpDown2.Value > 100)
            {
                using (HrMatchingContext db = new HrMatchingContext())
                {
                    var foundCV = db.CVs.Where(x => x.MinSalary >= numericUpDown2.Value).ToList();
                    if (foundCV != null)
                    {
                        ListAdder(foundCV);
                    }
                }
            }

            //======================= EMPITIES DATA GRID VIEW FOR THE NEXT SEARCHING
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CVSearches;
            //======================= EMPITIES LIST FOR THE NEXT SEARCHING
            CVSearches = new List<CVSearch>();
        }
        private void ListAdder(List<CV> foundCV)
        {
            foreach (var item in foundCV)
            {
                //================ IF SUCH CV ALREADY ADDED TO THE LIST, THEN IT WILL NOT BE ADDED AGAIN
                if (!CVSearches.Exists(x => x.id == item.id))
                {
                    CVSearches.Add(new CVSearch()
                    {
                        id = item.id,
                        Name= item.Name,
                        Surname = item.Surname,
                        Gender = item.Gender,
                        Age = item.Age,
                        Education = item.Education,
                        Job = item.Job,
                        Experience = item.Experience,
                        City = item.City,
                        Minimum_Salary = item.MinSalary,
                        Phone = item.Phone,
                    });
                }
            }
        }
    }

    public class CVSearch
    {
        public int id { get; set; }
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
