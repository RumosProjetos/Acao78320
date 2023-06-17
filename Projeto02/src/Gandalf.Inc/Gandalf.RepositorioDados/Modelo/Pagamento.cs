using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public decimal ValorPago { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public Loja Loja { get; set; }
    }
}


