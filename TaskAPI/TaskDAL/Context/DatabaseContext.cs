using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shared.Entity.Accomplishments;
using Shared.Entity;
using Shared.Entity.License;
using Shared.Entity.Country;
using SharedFiles.Entities;
using Shared.Entity.Skill;
using License = Shared.Entity.License.License;
using Shared.Entity.Education;

namespace TaskDAL.Context
{

    public class DatabaseContext : IdentityDbContext {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base (options) {

        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext> {
            public DatabaseContext CreateDbContext (string[] args) {
                IConfigurationRoot configuration = new ConfigurationBuilder ()
                    .SetBasePath (Directory.GetCurrentDirectory ())
                    .AddJsonFile (@Directory.GetCurrentDirectory () + "/appsettings.json")
                    .Build ();
                var builder = new DbContextOptionsBuilder<DatabaseContext> ();
                var connectionString = configuration.GetConnectionString ("DefaultConnection");

                builder.UseSqlServer (connectionString);
                return new DatabaseContext (builder.Options);
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<UserCourse> ()
                .HasOne (u => u.ApplicationUser)
                .WithMany ()
                .HasForeignKey (u => u.userId);


            modelBuilder.Entity<UserProject>()
                .HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<District>()
                .HasOne(u => u.Province)
                .WithMany()
                .HasForeignKey(u => u.provinceId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Industry)
                .WithMany()
                .HasForeignKey(u => u.industryId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.District)
                .WithMany()
                .HasForeignKey(u => u.districtId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Province)
                .WithMany()
                .HasForeignKey(u => u.provinceId);

            modelBuilder.Entity<License>()
                .HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(u => u.companyId);

            modelBuilder.Entity<UserLicense>()
                .HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<UserLicense>()
                .HasOne(u => u.License)
                .WithMany()
                .HasForeignKey(u => u.licenseId);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<UserSkill>()
                .HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<UserSkill>()
                .HasOne(u => u.Skill)
                .WithMany()
                .HasForeignKey(u => u.skillId);

            modelBuilder.Entity<UserExperience>()
                .HasOne(u => u.Company)
                .WithMany()
                .HasForeignKey(u => u.companyId);

            modelBuilder.Entity<UserExperience>()
                .HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<UserEducation>()
                .HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.userId);

            modelBuilder.Entity<UserEducation>()
                .HasOne(u => u.Education)
                .WithMany()
                .HasForeignKey(u => u.educationId);

            modelBuilder.Entity<Publication>()
                .HasOne(u => u.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.userId);

        }

        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<UserLicense> UserLicenses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<Publication> Publications { get; set; }     
    }
}