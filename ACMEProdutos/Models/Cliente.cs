using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACMEProdutos.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}