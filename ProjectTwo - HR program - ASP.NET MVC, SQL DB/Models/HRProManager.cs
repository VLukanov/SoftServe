namespace Demo2._1.Models
{
    using System.Data.Entity;

    public partial class HRProManager : DbContext
    {
        public HRProManager()
            : base("name=HRProManager")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<ProjectName> ProjectNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employee1)
                .WithOptional(e => e.Employee2)
                .HasForeignKey(e => e.Manager);

            modelBuilder.Entity<Position>()
                .Property(e => e.PositionName)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectName>()
                .Property(e => e.Project)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectName>()
                .Property(e => e.ManagerID);
                



            modelBuilder.Entity<ProjectName>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.ProjectName)
                .HasForeignKey(e => e.ProjectID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
               .HasMany(e => e.Projects)
               .WithOptional(e => e.ProjectManager)
               .HasForeignKey(e => e.ManagerID);
        }
    }
}
