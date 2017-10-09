using K7Burguer.Aplicacao.Interface;
using K7Burguer.Dominio.Entidades;
using K7Burguer.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Aplicacao
{
    public class PedidoAppServico : IPedidoAppServico
    {
        private readonly PedidoServico _pedido;

        public PedidoAppServico(PedidoServico pedido)
        {
            _pedido = pedido;
        }

        public IEnumerable<PedidoEntidade> CarregarPedidos()
        {
            return _pedido.CarregarPedidos();
        }

        public Dictionary<int, string> CarregarBebidas()
        {
            return _pedido.CarregarBebidas();
        }

        public Dictionary<int, string> CarregarBatata()
        {
            return _pedido.CarregarBatata();
        }

        public Dictionary<int, string> CarregarHamburguer()
        {
            return _pedido.CarregarHamburguer();
        }

        public void SalvarPedido(PedidoEntidade pedido)
        {
            _pedido.SalvarPedido(pedido);
        }
    }
}
