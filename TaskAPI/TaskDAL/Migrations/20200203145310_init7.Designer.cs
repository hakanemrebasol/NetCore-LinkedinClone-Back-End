﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskDAL.Context;

namespace TaskDAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200203145310_init7")]
    partial class init7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Shared.Entity.Accomplishments.UserCourse", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("currentlyWorking")
                        .HasColumnType("bit");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("projectEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("projectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projectStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("projectId");

                    b.HasIndex("userId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("Shared.Entity.Accomplishments.UserProject", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("currentlyWorking")
                        .HasColumnType("bit");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("projectEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("projectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("projectStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("projectId");

                    b.HasIndex("userId");

                    b.ToTable("UserProjects");
                });

            modelBuilder.Entity("Shared.Entity.Company", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Shared.Entity.Country.District", b =>
                {
                    b.Property<int>("districtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("districtName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("provinceId")
                        .HasColumnType("int");

                    b.HasKey("districtId");

                    b.HasIndex("provinceId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Shared.Entity.Country.Province", b =>
                {
                    b.Property<int>("provinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("provinceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("provinceId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Shared.Entity.Education.Education", b =>
                {
                    b.Property<int>("educationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("educationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("educationId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Shared.Entity.Education.UserEducation", b =>
                {
                    b.Property<int>("userEducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("educationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("userEducationId");

                    b.HasIndex("educationId");

                    b.HasIndex("userId");

                    b.ToTable("UserEducations");
                });

            modelBuilder.Entity("Shared.Entity.Industry", b =>
                {
                    b.Property<int>("industryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("industryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("industryId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("Shared.Entity.License.License", b =>
                {
                    b.Property<int>("licenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<string>("licenseName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("licenseId");

                    b.HasIndex("companyId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Shared.Entity.License.UserLicense", b =>
                {
                    b.Property<int>("userLicenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("canExpire")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("expirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("issueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("licenseId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("userLicenseId");

                    b.HasIndex("licenseId");

                    b.HasIndex("userId");

                    b.ToTable("UserLicenses");
                });

            modelBuilder.Entity("Shared.Entity.Publication", b =>
                {
                    b.Property<int>("publicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("publishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("publisherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("publicationId");

                    b.HasIndex("userId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("Shared.Entity.Skill.Skill", b =>
                {
                    b.Property<int>("skillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("skillName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("skillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Shared.Entity.Skill.UserSkill", b =>
                {
                    b.Property<int>("userSkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("skillId")
                        .HasColumnType("int");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("userSkillId");

                    b.HasIndex("skillId");

                    b.HasIndex("userId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("Shared.Entity.UserExperience", b =>
                {
                    b.Property<int>("experienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("experienceId");

                    b.HasIndex("companyId");

                    b.HasIndex("userId");

                    b.ToTable("UserExperiences");
                });

            modelBuilder.Entity("SharedFiles.Entities.RefreshToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("issueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("refreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("revoked")
                        .HasColumnType("bit");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Shared.Entity.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZIPCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("about")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("districtId")
                        .HasColumnType("int");

                    b.Property<string>("headline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("industryId")
                        .HasColumnType("int");

                    b.Property<int?>("provinceId")
                        .HasColumnType("int");

                    b.Property<string>("webSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("districtId");

                    b.HasIndex("industryId");

                    b.HasIndex("provinceId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Entity.Accomplishments.UserCourse", b =>
                {
                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Shared.Entity.Accomplishments.UserProject", b =>
                {
                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Shared.Entity.Country.District", b =>
                {
                    b.HasOne("Shared.Entity.Country.Province", "Province")
                        .WithMany()
                        .HasForeignKey("provinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Entity.Education.UserEducation", b =>
                {
                    b.HasOne("Shared.Entity.Education.Education", "Education")
                        .WithMany()
                        .HasForeignKey("educationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Shared.Entity.License.License", b =>
                {
                    b.HasOne("Shared.Entity.Company", "Company")
                        .WithMany()
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Entity.License.UserLicense", b =>
                {
                    b.HasOne("Shared.Entity.License.License", "License")
                        .WithMany()
                        .HasForeignKey("licenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Shared.Entity.Publication", b =>
                {
                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Shared.Entity.Skill.UserSkill", b =>
                {
                    b.HasOne("Shared.Entity.Skill.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("skillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Shared.Entity.UserExperience", b =>
                {
                    b.HasOne("Shared.Entity.Company", "Company")
                        .WithMany()
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("SharedFiles.Entities.RefreshToken", b =>
                {
                    b.HasOne("Shared.Entity.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Shared.Entity.ApplicationUser", b =>
                {
                    b.HasOne("Shared.Entity.Country.District", "District")
                        .WithMany()
                        .HasForeignKey("districtId");

                    b.HasOne("Shared.Entity.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("industryId");

                    b.HasOne("Shared.Entity.Country.Province", "Province")
                        .WithMany()
                        .HasForeignKey("provinceId");
                });
#pragma warning restore 612, 618
        }
    }
}
