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
    public class BebidaAppServico : IBebidaAppServico
    {
        private readonly BebidaServico _Bebida;

        public BebidaAppServico(BebidaServico Bebida)
        // : base(cliente)
        {
            _Bebida = Bebida;
        }

        public IEnumerable<BebidaEntidade> CarregarBebidas()
        {
            return _Bebida.CarregarBebidas();
        }

        public void SalvarBebidas(BebidaEntidade Bebida)
        {
            _Bebida.SalvarBebidas(Bebida);
        }

        public void AtualizaBebidas(BebidaEntidade Bebida)
        {
            _Bebida.AtualizaBebidas(Bebida);
        }

        public void DeletaBebidas(int idBebida)
        {
            _Bebida.DeletaBebidas(idBebida);
        }

        public BebidaEntidade CarregarBebida(int idBebida)
        {
            return _Bebida.CarregarBebida(idBebida);
        }

    }
}
