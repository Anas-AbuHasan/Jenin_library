﻿// <auto-generated />
using Jenin_library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jenin_library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240927185701_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hammam_library.Models.Authors", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"), 1L, 1);

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorID = 1,
                            AuthorName = "Hammam"
                        },
                        new
                        {
                            AuthorID = 2,
                            AuthorName = "Davinci"
                        },
                        new
                        {
                            AuthorID = 3,
                            AuthorName = "John"
                        });
                });

            modelBuilder.Entity("Hammam_library.Models.Books", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookID"), 1L, 1);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookID = 1,
                            AuthorID = 1,
                            Edition = "First",
                            Title = "Web Programming"
                        },
                        new
                        {
                            BookID = 2,
                            AuthorID = 2,
                            Edition = "Second",
                            Title = "Mona lisa"
                        },
                        new
                        {
                            BookID = 3,
                            AuthorID = 3,
                            Edition = "Third",
                            Title = "Doe"
                        });
                });

            modelBuilder.Entity("Hammam_library.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Name = "Administrator",
                            Password = "admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Hammam_library.Models.Books", b =>
                {
                    b.HasOne("Hammam_library.Models.Authors", "Authors")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");
                });
#pragma warning restore 612, 618
        }
    }
}
