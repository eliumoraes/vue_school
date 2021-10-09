using System.Collections.Generic;
using API_DOTNET.Models;
using Microsoft.EntityFrameworkCore;

namespace API_DOTNET.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>()
                .HasData(
                    new List<Teacher>() {
                        new Teacher() {
                            Id = 1,
                            Nome = "Vilma"
                        },
                        new Teacher() {
                            Id = 2,
                            Nome = "Malu"
                        },
                        new Teacher() {
                            Id = 3,
                            Nome = "Rafael"
                        }
                    }
                );

            builder.Entity<Student>()
                .HasData(
                    new List<Student>() {
                        
                        new Student() {
                            Id = 1,
                            Nome = "Eliu",
                            Sobrenome = "Moraes",
                            Nascimento = "22/10/1987",
                            TeacherId = 1
                        },
                        new Student() {
                            Id = 2,
                            Nome = "Rodrigo",
                            Sobrenome = "Nasdaq",
                            Nascimento = "12/11/1990",
                            TeacherId = 1
                        },
                        new Student() {
                            Id = 3,
                            Nome = "Letícia",
                            Sobrenome = "Suarez",
                            Nascimento = "10/01/1988",
                            TeacherId = 1
                        },
                        new Student() {
                            Id = 4,
                            Nome = "Douglas",
                            Sobrenome = "Sauro",
                            Nascimento = "09/04/1992",
                            TeacherId = 2
                        }
                    }
                );
        }
    }
}