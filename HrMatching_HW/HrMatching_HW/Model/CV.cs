using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrMatching_HW.Model
{
    public class CV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        public string Job { get; set; }

        [Required]
        public string Experience { get; set; }

        [Required]
        public string City { get; set; }

        public int MinSalary { get; set; }

        [Required]
        public string Phone { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Vacancy> Vacancies { get; set; }

        public CV()
        {
            Vacancies = new List<Vacancy>();
        }
    }
}
