using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Aplicacao.Interface
{
    public interface IBatataAppServico
    {
        IEnumerable<BatataEntidade> CarregarBatatas();

        void SalvarBatatas(BatataEntidade Batata);

        void AtualizaBatatas(BatataEntidade Batata);

        void DeletaBatatas(int idBatata);

        BatataEntidade CarregarBatata(int idBatata);
    }
}
