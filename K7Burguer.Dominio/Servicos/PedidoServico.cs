using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Dominio.Servicos
{
    public class PedidoServico
    {
            
        private readonly K7Burguer.Dados.HamburgueriaVerityEntities _contexto;

        public PedidoServico()
        {
            _contexto = new Dados.HamburgueriaVerityEntities();
        }

        public Dictionary<int, string> CarregarBebidas()
        {

            return _contexto.Bebida.ToList().ToDictionary(e => e.CodBebida, d => d.Nome);
        }

        public Dictionary<int, string> CarregarHamburguer()
        {
            return _contexto.Hamburguer.ToList().ToDictionary(e => e.CodHamburguer, d => d.Nome);
        }

        public Dictionary<int, string> CarregarBatata()
        {
            return _contexto.Batata.ToList().ToDictionary(e => e.CodBatata, d => d.Nome);

        }

        public void SalvarPedido(PedidoEntidade Pedido)
        {
            if (Pedido.CodBatata == null && Pedido.CodHamburguer == null && Pedido.CodBebida == null)
                throw new Exception("É necessário preencher ao menos um campo");

            decimal total = 0;

            if (Pedido.QtdBatata != null && Pedido.CodBatata != null)
            {
                var valorBatata = _contexto.Batata.FirstOrDefault(f => f.CodBatata == Pedido.CodBatata);

                total = total + (valorBatata.Valor * Convert.ToDecimal(Pedido.QtdBatata));
            }


            if (Pedido.QtdHamburguer != null && Pedido.CodHamburguer != null)
            {
                var valorHamburguer = _contexto.Hamburguer.FirstOrDefault(f => f.CodHamburguer == Pedido.CodHamburguer);

                total = total + (valorHamburguer.Valor * Convert.ToDecimal(Pedido.QtdHamburguer));
            }


            if (Pedido.QtdBebida != null &&  Pedido.CodBebida != null)
            {
                var valorBebida = _contexto.Bebida.FirstOrDefault(f => f.CodBebida == Pedido.CodBebida);

                total = total + (valorBebida.Valor * Convert.ToDecimal(Pedido.QtdBebida));
            }

            _contexto.Pedido.Add(new Dados.Pedido
            {
                CodHamburguer = Pedido.CodHamburguer,
                CodBebida = Pedido.CodBebida,
                CodBatata = Pedido.CodBatata,
                ValorTotal = total,
                QtdHamburguer = Pedido.QtdHamburguer,
                QtdBebida = Pedido.QtdBebida,
                QtdBatata = Pedido.QtdBatata,
                DataPedido = DateTime.Now
            });

            _contexto.SaveChanges();
        }

        public IEnumerable<PedidoEntidade> CarregarPedidos()
        {
            var retorno = _contexto.Pedido.Select(s => new PedidoEntidade
            {
                NomeBatata = s.Batata.Nome,
                NomeBebida = s.Bebida.Nome,
                NomeHamburguer = s.Hamburguer.Nome,
                QtdHamburguer = s.QtdHamburguer,
                QtdBebida = s.QtdBebida,
                QtdBatata = s.QtdBatata,
                DataPedido = s.DataPedido,
                CodPedido = s.CodPedido,
                ValorTotal = s.ValorTotal
            }).OrderByDescending(o => o.CodPedido).ToList();

            return retorno;
        }

    }
}
