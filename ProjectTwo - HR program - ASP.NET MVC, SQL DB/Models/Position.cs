namespace Demo2._1.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //Create tabel Position with all fields in this table as a constructors
    [Table("Position")]
    public partial class Position
    {        
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PositionName { get; set; }

        //Show a foreign key from SQL Server
        //Create a conection with Employees
       
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
