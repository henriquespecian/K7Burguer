using K7Burguer.Website.Models;
using K7Burguer.Aplicacao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K7Burguer.Aplicacao;
using K7Burguer.Dominio.Servicos;

namespace K7Burguer.Website.Controllers
{
    public class HamburguerController : Controller
    {
        private readonly HamburguerAppServico _hamburguer;


        public HamburguerController()
        {
            _hamburguer = new HamburguerAppServico(new HamburguerServico());
        }

        public ActionResult Adicionar()
        {
            return View("Adicionar");

        }

        public ActionResult Editar(int idHamburguer)
        {
            try
            {
                //Buscar Informações e carregar
                var data = _hamburguer.CarregarHamburguer(idHamburguer);

                var model = new HamburguerModel
                {
                    CodHamburguer = data.CodHamburguer,
                    Nome = data.Nome,
                    Ingredientes = data.Ingredientes,
                    Valor = data.Valor
                };

                return View("Editar", model);
            }
            catch(Exception )
            {
                return RedirectToAction("Index");
            }          

        }

        #region Metodos

        
        public ActionResult Index()
        {
            try
            {
                var model = new HamburguerModel
                {
                    ListaHamburguer = _hamburguer.CarregarHamburguers()
                };

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public JsonResult Salvar(HamburguerModel model)
        {
            try
            {
                if (model.CodHamburguer != 0)
                {
                    //Atualiza
                    _hamburguer.AtualizaHamburguers(model);
                }
                else
                {
                    //Salva um novo
                    _hamburguer.SalvarHamburguers(model);
                }

                return Json(new { Sucesso = true, Mensagem = "Salvo com sucesso" });
            }
            catch(Exception ex)
            {
                return Json(new { Sucesso = true, Mensagem = ex.Message});
            }

        }

        public JsonResult Excluir(int idHamburguer)
        {
            try
            {
                //Excluir
                _hamburguer.DeletaHamburguers(idHamburguer);

                return Json(new { Sucesso = true, Mensagem = "Excluido com sucesso" });
            }
            catch(Exception ex)
            {
                return Json(new { Sucesso = false, Mensagem = ex.Message });
            }
        }

        #endregion
    }
}