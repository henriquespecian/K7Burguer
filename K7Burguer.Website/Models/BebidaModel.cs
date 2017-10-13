using K7Burguer.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K7Burguer.Website.Models
{
    public class BebidaModel : BebidaEntidade
    {
        public IEnumerable<BebidaEntidade> ListaBebida { get; set; }

    }
}