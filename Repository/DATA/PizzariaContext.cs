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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().ToTable("Funcionarios");
            modelBuilder.Entity<Cargo>().ToTable("Cargos");
        }

    }
}
