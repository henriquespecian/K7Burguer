using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K7Burguer.Website.Models
{
    public class HamburguerModel : HamburguerEntidade
    {
        public IEnumerable<HamburguerEntidade> ListaHamburguer { get; set; }
    }
}