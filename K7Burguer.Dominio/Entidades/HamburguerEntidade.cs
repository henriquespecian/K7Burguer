using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K7Burguer.Dominio.Entidades
{
    public class HamburguerEntidade
    {
        public int CodHamburguer { get; set; }
        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public decimal Valor { get; set; }
    }
}
