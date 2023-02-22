using Microsoft.EntityFrameworkCore;
using EmployeeTwo.Models;
using EmployeeTwo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTwo.Models
{
     class EmployeeContext : DbContext
    {

        public EmployeeContext()
        {
            
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Department>()
             .HasIndex(u => u.DepartmentName)
             .IsUnique();

             modelBuilder.Entity<Designation>()
             .HasIndex(u => u.DesignationName)
             .IsUnique();*/

            /*
                        modelBuilder.Entity<EmployeeSkill>().HasKey(sc => new { sc.EmployeePersonId, sc.SkillId }); //ALL FROM EMPLOYEESKILLS1 intermidiate TABLE

                        modelBuilder.Entity<EmployeeSkill>()
                        .HasOne<EmployeePerson>(sc => sc.EmployeePerson) //taken from INTERMIDEATE TABLE
                        .WithMany(s => s.EmployeeSkills)
                        .HasForeignKey(sc => sc.EmployeePersonId);


                        modelBuilder.Entity<EmployeeSkill>()
                            .HasOne<Skill>(sc => sc.Skill)
                            .WithMany(s => s.EmployeeSkills)
                            .HasForeignKey(sc => sc.SkillId);*/


           // modelBuilder.Entity<Skill>().OwnsOne(x=>x.SkillName);










            modelBuilder.Entity<Department>().HasAlternateKey(u => u.DepartmentName);

            modelBuilder.Entity<Designation>().HasAlternateKey(u => u.DesignationName);

            modelBuilder.Entity<Skill>().HasAlternateKey(u => u.SkillName);
           

           // modelBuilder.Entity<EmpModelyoo>().HasNoKey().ToView(null);
           // modelBuilder.Entity<EmpModelyoo1>().HasNoKey().ToView(null);

         /*   modelBuilder.Entity<Skill>()
            .HasIndex(u => u.SkillName)
            .IsUnique();*/

            modelBuilder.Entity<EmployeeSkill>()
             .HasKey(sc => new { sc.EmployeePersonId, sc.SkillId });

            modelBuilder.Entity<List<string>>().HasNoKey();


        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Designation> designations { get; set; }
        public DbSet<EmployeePerson> employeePersons { get; set; }

        public DbSet<Skill> skills { get; set; }

        public DbSet<EmployeeSkill> employeeSkills { get; set; }
        //public DbSet<EmpModelyoo> EmpModelyoo { get; set; }
        public DbSet<SearchModel> SearchModel { get; set; }
        public DbSet<EmpModelyoo1> EmpModelyoo1 { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"connectionstring");
        }
    }
   // Server=myserver;Database=mydatabase;user id=id;password=mypwd
}
