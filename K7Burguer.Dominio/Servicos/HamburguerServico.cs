using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;


namespace K7Burguer.Dominio.Servicos
{
    public class HamburguerServico
    {
        private readonly K7Burguer.Dados.HamburgueriaVerityEntities _contexto;

        public HamburguerServico()
        {
            _contexto = new Dados.HamburgueriaVerityEntities();
        }

        public IEnumerable<HamburguerEntidade> CarregarHamburguers()
        {
            var retorno = _contexto.Hamburguer.Select(s => new HamburguerEntidade
            {
                Nome = s.Nome,
                CodHamburguer = s.CodHamburguer,
                Ingredientes = s.Ingredientes,
                Valor = s.Valor
            }).OrderBy(o => o.Nome).ToList();

            return retorno;
        }

        public void SalvarHamburguers(HamburguerEntidade hamburguer)
        {
            _contexto.Hamburguer.Add(new Dados.Hamburguer
            {
                Nome = hamburguer.Nome,
                Ingredientes = hamburguer.Ingredientes,
                Valor = hamburguer.Valor
            });

            _contexto.SaveChanges();
        }

        public void AtualizaHamburguers(HamburguerEntidade hamburguer)
        {
            var h = _contexto.Hamburguer.FirstOrDefault(f => f.CodHamburguer == hamburguer.CodHamburguer);

            if(h != null)
            {
                h.Nome = hamburguer.Nome;
                h.Ingredientes = hamburguer.Ingredientes;
                h.Valor = hamburguer.Valor;

                _contexto.SaveChanges();
            }

        }

        public HamburguerEntidade CarregarHamburguer(int idHamburguer)
        {
            var h = _contexto.Hamburguer.FirstOrDefault(f => f.CodHamburguer == idHamburguer);

            return new HamburguerEntidade
            {
                Nome = h.Nome,
                Ingredientes = h.Ingredientes,
                Valor = h.Valor,
                CodHamburguer = h.CodHamburguer
            };

        }


        public void DeletaHamburguers(int idHamburguer)
        {
            var h = _contexto.Hamburguer.FirstOrDefault(f => f.CodHamburguer == idHamburguer);

            if (h != null)
            {
                _contexto.Hamburguer.Remove(h);
                _contexto.SaveChanges();
            }

        }
    }
}
