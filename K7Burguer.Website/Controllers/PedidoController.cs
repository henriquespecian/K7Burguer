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
    public class PedidoController : Controller
    {
        private readonly PedidoAppServico _Pedido;


        public PedidoController()
        {
            _Pedido = new PedidoAppServico(new PedidoServico());
        }

        public PedidoModel CarregaModel()
        {
            var model = new PedidoModel
            {
                ListaBatata = _Pedido.CarregarBatata(),
                ListaBebida = _Pedido.CarregarBebidas(),
                ListaHamburguer = _Pedido.CarregarHamburguer(),
            };

            return model;
        }

        public ActionResult Index()
        {
            return View(CarregaModel());
        }

        [HttpPost]
        public JsonResult Salvar(PedidoModel model)
        {
            try
            { 
                _Pedido.SalvarPedido(model);

                return Json(new { Sucesso = true, Mensagem = "Salvo com sucesso" });


            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Mensagem = ex.Message });

            }

        }
    }
}