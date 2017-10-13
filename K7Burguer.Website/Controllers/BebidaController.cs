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
    public class BebidaController : Controller
    {
        private readonly BebidaAppServico _Bebida;


        public BebidaController()
        {
            _Bebida = new BebidaAppServico(new BebidaServico());
        }

        public ActionResult Adicionar()
        {
            return View("Adicionar");

        }

        public ActionResult Editar(int idBebida)
        {
            try
            {
                //Buscar Informações e carregar
                var data = _Bebida.CarregarBebida(idBebida);

                var model = new BebidaModel
                {
                    CodBebida = data.CodBebida,
                    Nome = data.Nome,
                    Descricao = data.Descricao,
                    Valor = data.Valor
                };

                return View("Editar", model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        #region Metodos


        public ActionResult Index()
        {
            try
            {
                var model = new BebidaModel
                {
                    ListaBebida = _Bebida.CarregarBebidas()
                };

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public JsonResult Salvar(BebidaModel model)
        {
            try
            {
                if (model.CodBebida != 0)
                {
                    //Atualiza
                    _Bebida.AtualizaBebidas(model);
                }
                else
                {
                    //Salva um novo
                    _Bebida.SalvarBebidas(model);
                }

                return Json(new { Sucesso = true, Mensagem = "Salvo com sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = true, Mensagem = ex.Message });
            }

        }

        public JsonResult Excluir(int idBebida)
        {
            try
            {
                //Excluir
                _Bebida.DeletaBebidas(idBebida);

                return Json(new { Sucesso = true, Mensagem = "Excluido com sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Mensagem = ex.Message });
            }
        }

        #endregion
    }
}