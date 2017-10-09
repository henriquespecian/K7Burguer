using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Aplicacao.Interface
{
    public interface IBebidaAppServico
    {
        IEnumerable<BebidaEntidade> CarregarBebidas();

        void SalvarBebidas(BebidaEntidade Bebida);

        void AtualizaBebidas(BebidaEntidade Bebida);

        void DeletaBebidas(int idBebida);

        BebidaEntidade CarregarBebida(int idBebida);
    }
}
