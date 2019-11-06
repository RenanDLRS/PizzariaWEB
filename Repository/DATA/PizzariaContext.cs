using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DATA
{
    public class PizzariaContext : DbContext
    {

        public PizzariaContext(DbContextOptions<PizzariaContext> options) : base(options)
        {

        }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().ToTable("Funcionarios");
            modelBuilder.Entity<Cargo>().ToTable("Cargos");
            modelBuilder.Entity<Sabor>().ToTable("Sabores");
            modelBuilder.Entity<Tamanho>().ToTable("Tamanhos");
            modelBuilder.Entity<Bebida>().ToTable("Bebidas");
        }

    }
}
