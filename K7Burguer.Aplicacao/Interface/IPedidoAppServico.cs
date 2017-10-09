using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Aplicacao.Interface
{
    public interface IPedidoAppServico
    {
        Dictionary<int, string> CarregarBebidas();
        
        Dictionary<int, string> CarregarBatata();

        Dictionary<int, string> CarregarHamburguer();

        void SalvarPedido(PedidoEntidade pedido);

        IEnumerable<PedidoEntidade> CarregarPedidos();

    }
}
