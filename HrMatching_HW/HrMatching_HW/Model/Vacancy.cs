using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrMatching_HW.Model
{
    public class Vacancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string VacancyName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        public string Experience { get; set; }

        [Required]
        public string Job { get; set; }

        [Required]
        public string JobDescription { get; set; }

        [Required]
        public string City { get; set; }

        public int SalaryOffer { get; set; }

        [Required]
        public string Phone { get; set; }



        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CV> CVs { get; set; }

        public Vacancy()
        {
            CVs = new List<CV>();
        }
    }
}
