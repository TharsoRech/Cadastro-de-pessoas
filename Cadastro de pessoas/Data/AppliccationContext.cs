using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class AppliccationContext: DbContext
    {

        public DbSet<Cadastro_de_pessoas.Models.Pessoa> pessoas { get; set; }

        public AppliccationContext(DbContextOptions<AppliccationContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastro_de_pessoas.Models.Pessoa>(p =>
                {
                    p.ToTable("Pessoas");
                    p.Property(p => p.Id).ValueGeneratedOnAdd();
                    p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
                    p.Property(p => p.DataDeNascimento).HasColumnType("VARCHAR(80)").IsRequired();
                    p.Property(p => p.Ativo).HasColumnType("VARCHAR(80)");
                });
            
        }
    }
}
