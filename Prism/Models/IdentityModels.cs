﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Prism.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           // this.Configuration.LazyLoadingEnabled = false;
            //this.Projects.Include(o => o.Client);
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SkillScoringMatrixCell> SkillScoringMatrixCells { get; set; }
        public DbSet<GradeScoringMatrixCell> GradeScoringMatrixCells { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consultant>()
                .HasMany<Skill>(c => c.Skills)
                .WithMany(s => s.Consultants)
                .Map(cs =>
                {
                    cs.MapLeftKey("ConsultantId");
                    cs.MapRightKey("SkillId");
                    cs.ToTable("ConsultantSkills");
                });
        }
    }
}