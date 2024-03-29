﻿// <auto-generated />
using API_DOTNET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_DOTNET.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("API_DOTNET.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("Sobrenome");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");

                    b.HasData(
                        new { Id = 1, Nascimento = "22/10/1987", Nome = "Eliu", Sobrenome = "Moraes", TeacherId = 1 },
                        new { Id = 2, Nascimento = "12/11/1990", Nome = "Rodrigo", Sobrenome = "Nasdaq", TeacherId = 1 },
                        new { Id = 3, Nascimento = "10/01/1988", Nome = "Letícia", Sobrenome = "Suarez", TeacherId = 1 },
                        new { Id = 4, Nascimento = "09/04/1992", Nome = "Douglas", Sobrenome = "Sauro", TeacherId = 2 }
                    );
                });

            modelBuilder.Entity("API_DOTNET.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new { Id = 1, Nome = "Vilma" },
                        new { Id = 2, Nome = "Malu" },
                        new { Id = 3, Nome = "Rafael" }
                    );
                });

            modelBuilder.Entity("API_DOTNET.Models.Student", b =>
                {
                    b.HasOne("API_DOTNET.Models.Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
