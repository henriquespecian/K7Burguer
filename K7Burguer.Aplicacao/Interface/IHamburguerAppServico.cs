using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Aplicacao.Interface
{
    public interface  IHamburguerAppServico
    {
        IEnumerable<HamburguerEntidade> CarregarHamburguers();

        void SalvarHamburguers(HamburguerEntidade hamburguer);

        void AtualizaHamburguers(HamburguerEntidade hamburguer);

        void DeletaHamburguers(int idHamburguer);

        HamburguerEntidade CarregarHamburguer(int idHamburguer);
    }
}
