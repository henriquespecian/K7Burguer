using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;


namespace K7Burguer.Dominio.Servicos
{
    public class BatataServico
    {
        private readonly K7Burguer.Dados.HamburgueriaVerityEntities _contexto;

        public BatataServico()
        {
            _contexto = new Dados.HamburgueriaVerityEntities();
        }

        public IEnumerable<BatataEntidade> CarregarBatatas()
        {
            var retorno = _contexto.Batata.Select(s => new BatataEntidade
            {
                Nome = s.Nome,
                CodBatata = s.CodBatata,
                Descricao = s.Descricao,
                Valor = s.Valor
            }).OrderBy(o => o.Nome).ToList();

            return retorno;
        }

        public void SalvarBatatas(BatataEntidade Batata)
        {
            _contexto.Batata.Add(new Dados.Batata
            {
                Nome = Batata.Nome,
                Descricao = Batata.Descricao,
                Valor = Batata.Valor
            });

            _contexto.SaveChanges();
        }

        public void AtualizaBatatas(BatataEntidade Batata)
        {
            var h = _contexto.Batata.FirstOrDefault(f => f.CodBatata == Batata.CodBatata);

            if (h != null)
            {
                h.Nome = Batata.Nome;
                h.Descricao = Batata.Descricao;
                h.Valor = Batata.Valor;

                _contexto.SaveChanges();
            }

        }

        public BatataEntidade CarregarBatata(int idBatata)
        {
            var h = _contexto.Batata.FirstOrDefault(f => f.CodBatata == idBatata);

            return new BatataEntidade
            {
                Nome = h.Nome,
                Descricao = h.Descricao,
                Valor = h.Valor,
                CodBatata = h.CodBatata
            };

        }


        public void DeletaBatatas(int idBatata)
        {
            var h = _contexto.Batata.FirstOrDefault(f => f.CodBatata == idBatata);

            if (h != null)
            {
                _contexto.Batata.Remove(h);
                _contexto.SaveChanges();
            }

        }
    }
}
