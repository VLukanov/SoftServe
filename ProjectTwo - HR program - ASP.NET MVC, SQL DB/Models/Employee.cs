namespace Demo2._1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //Create tabel Employee with all fields in the table as a constructors
    [Table("Employee")]
    public partial class Employee
    {       
        public Employee()
        {
            Employee1 = new HashSet<Employee>();
            Projects = new HashSet<ProjectName>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public int? PositionID { get; set; }

        public int ProjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string Workplace { get; set; }

        public decimal Salary { get; set; }

        public int? Manager { get; set; }

        //Show a foreign key from SQL Server
        //Create a foreign keys - conections between all tables
       
        public virtual ICollection<Employee> Employee1 { get; set; }

        public virtual Employee Employee2 { get; set; }

        public virtual Position Position { get; set; }

        public virtual ProjectName ProjectName { get; set; }

        public virtual ICollection<ProjectName> Projects { get; set; }
    }
}
