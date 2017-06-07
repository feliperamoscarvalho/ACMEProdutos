using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACMEProdutos.Models
{
    [Table("Produtos")]
    public class Produto
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public int Estoque { get; set; }
    }
}