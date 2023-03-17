using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OneToOneCrud.Authorization.Roles;
using OneToOneCrud.Authorization.Users;
using OneToOneCrud.MultiTenancy;
using OneToOneCrud.Company_Models;

namespace OneToOneCrud.EntityFrameworkCore
{
    public class OneToOneCrudDbContext : AbpZeroDbContext<Tenant, Role, User, OneToOneCrudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        public OneToOneCrudDbContext(DbContextOptions<OneToOneCrudDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithOne(d => d.Employee)
                .HasForeignKey<Department>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
