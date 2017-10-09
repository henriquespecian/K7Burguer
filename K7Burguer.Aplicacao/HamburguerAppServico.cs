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
    public class HamburguerAppServico : IHamburguerAppServico
    {
        private readonly HamburguerServico _hamburguer;

        public HamburguerAppServico(HamburguerServico hamburguer)
           // : base(cliente)
        {
            _hamburguer = hamburguer;
        }

        public IEnumerable<HamburguerEntidade> CarregarHamburguers()
        {
            return _hamburguer.CarregarHamburguers();
        }

        public void SalvarHamburguers(HamburguerEntidade hamburguer)
        {
             _hamburguer.SalvarHamburguers(hamburguer);
        }

        public void AtualizaHamburguers(HamburguerEntidade hamburguer)
        {
            _hamburguer.AtualizaHamburguers(hamburguer);
        }

        public void DeletaHamburguers(int idHamburguer)
        {
            _hamburguer.DeletaHamburguers(idHamburguer);
        }

        public HamburguerEntidade CarregarHamburguer(int idHamburguer)
        {
            return _hamburguer.CarregarHamburguer(idHamburguer);
        }

    }
}
