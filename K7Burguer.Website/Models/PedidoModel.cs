using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K7Burguer.Website.Models
{
    public class PedidoModel : PedidoEntidade
    {
        public Dictionary<int, string> ListaBatata { get; set; }
        public Dictionary<int, string> ListaHamburguer { get; set; }
        public Dictionary<int, string> ListaBebida { get; set; }
        public IEnumerable<PedidoEntidade> ListaPedido { get; set; }

    }
}