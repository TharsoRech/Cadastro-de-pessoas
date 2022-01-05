using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_pessoas.Data
{
    public class AppliccationContext: DbContext
    {

        public DbSet<Models.Pessoa> Pessoas { get; set; }

        public DbSet<Models.Animal> Animais { get; set; }

        public DbSet<Models.Endereco> Endereços { get; set; }

        public DbSet<Models.Evento> Eventos { get; set; }

        public DbSet<Models.Tipo> TiposDeAnimais { get; set; }

        public DbSet<Models.Atendente> Atendentes { get; set; }

        public AppliccationContext(DbContextOptions<AppliccationContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PetShopDB;User Id=PetShop;Password=Pet2021;Trusted_Connection=True;MultipleActiveResultSets=true");

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cadastro_de_pessoas.Models.Pessoa>(p =>
        //        {
        //            p.ToTable("Pessoas");
        //            p.Property(p => p.Id).ValueGeneratedOnAdd();
        //            p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
        //            p.Property(p => p.DataDeNascimento).HasColumnType("VARCHAR(80)").IsRequired();
        //            p.Property(p => p.CPF).HasColumnType("VARCHAR(80)");
        //        });
            
        //}
    }
}
