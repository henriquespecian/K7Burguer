using K7Burguer.Aplicacao;
using K7Burguer.Dominio.Servicos;
using K7Burguer.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K7Burguer.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly PedidoAppServico _Pedido;

        public HomeController()
        {
            _Pedido = new PedidoAppServico(new PedidoServico());
        }


        public ActionResult Index()
        {
            var model = new PedidoModel
            {
                ListaPedido = _Pedido.CarregarPedidos()
            };

            return View(model);
        }

    }
}