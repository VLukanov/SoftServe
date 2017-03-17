namespace Demo2._1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //Create tabel ProjectName with all fields in this table as a constructor
    [Table("ProjectName")]
    public partial class ProjectName
    {
        public ProjectName()
        {
            Employees = new HashSet<Employee>();
        }

        public int ID { get; set; }

        public int? ManagerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Project { get; set; }

        //Show a foreign key from SQL Server
        //Create a foreign keys
        
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Employee ProjectManager { get; set; }
    }
}
