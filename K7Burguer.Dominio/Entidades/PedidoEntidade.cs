using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Dominio.Entidades
{
    public class PedidoEntidade
    {
        public long CodPedido { get; set; }
        public string NomeHamburguer { get; set; }
        public int? CodHamburguer { get; set; }
        public string NomeBatata { get; set; }
        public int? CodBatata { get; set; }
        public string NomeBebida { get; set; }
        public int? CodBebida { get; set; }
        public decimal ValorTotal { get; set; }
        public int? QtdHamburguer { get; set; }
        public int? QtdBebida { get; set; }
        public int? QtdBatata { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
