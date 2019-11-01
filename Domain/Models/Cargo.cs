using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Cargos")]
    public class Cargo
    {
        [Key]
        public int CargoId { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
        public override string ToString()
        {
            return $"Cargo nome: {Nome}";
        }
    }
}
