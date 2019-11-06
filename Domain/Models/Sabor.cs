using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    [Table("Sabores")]
    public class Sabor
    {
        [Key]
        public int SaborId { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }

        public Sabor()
        {
            CriadoEm = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Nome do sabor: {Nome}, Criado em: {CriadoEm}";
        }
    }
}
