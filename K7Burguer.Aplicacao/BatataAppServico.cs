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
    public class BatataAppServico : IBatataAppServico
    {
        private readonly BatataServico _Batata;

        public BatataAppServico(BatataServico Batata)
        // : base(cliente)
        {
            _Batata = Batata;
        }

        public IEnumerable<BatataEntidade> CarregarBatatas()
        {
            return _Batata.CarregarBatatas();
        }

        public void SalvarBatatas(BatataEntidade Batata)
        {
            _Batata.SalvarBatatas(Batata);
        }

        public void AtualizaBatatas(BatataEntidade Batata)
        {
            _Batata.AtualizaBatatas(Batata);
        }

        public void DeletaBatatas(int idBatata)
        {
            _Batata.DeletaBatatas(idBatata);
        }

        public BatataEntidade CarregarBatata(int idBatata)
        {
            return _Batata.CarregarBatata(idBatata);
        }

    }
}
