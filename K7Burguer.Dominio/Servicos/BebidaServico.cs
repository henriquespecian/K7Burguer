using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;


namespace K7Burguer.Dominio.Servicos
{
    public class BebidaServico
    {
        private readonly K7Burguer.Dados.HamburgueriaVerityEntities _contexto;

        public BebidaServico()
        {
            _contexto = new Dados.HamburgueriaVerityEntities();
        }

        public IEnumerable<BebidaEntidade> CarregarBebidas()
        {
            var retorno = _contexto.Bebida.Select(s => new BebidaEntidade
            {
                Nome = s.Nome,
                CodBebida = s.CodBebida,
                Descricao = s.Descricao,
                Valor = s.Valor
            }).OrderBy(o => o.Nome).ToList();

            return retorno;
        }

        public void SalvarBebidas(BebidaEntidade Bebida)
        {
            _contexto.Bebida.Add(new Dados.Bebida
            {
                Nome = Bebida.Nome,
                Descricao = Bebida.Descricao,
                Valor = Bebida.Valor
            });

            _contexto.SaveChanges();
        }

        public void AtualizaBebidas(BebidaEntidade Bebida)
        {
            var h = _contexto.Bebida.FirstOrDefault(f => f.CodBebida == Bebida.CodBebida);

            if (h != null)
            {
                h.Nome = Bebida.Nome;
                h.Descricao = Bebida.Descricao;
                h.Valor = Bebida.Valor;

                _contexto.SaveChanges();
            }

        }

        public BebidaEntidade CarregarBebida(int idBebida)
        {
            var h = _contexto.Bebida.FirstOrDefault(f => f.CodBebida == idBebida);

            return new BebidaEntidade
            {
                Nome = h.Nome,
                Descricao = h.Descricao,
                Valor = h.Valor,
                CodBebida = h.CodBebida
            };

        }


        public void DeletaBebidas(int idBebida)
        {
            var h = _contexto.Bebida.FirstOrDefault(f => f.CodBebida == idBebida);

            if (h != null)
            {
                _contexto.Bebida.Remove(h);
                _contexto.SaveChanges();
            }

        }
    }
}
