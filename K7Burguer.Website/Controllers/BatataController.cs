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
    public class BatataController : Controller
    {
        private readonly BatataAppServico _Batata;


        public BatataController()
        {
            _Batata = new BatataAppServico(new BatataServico());
        }

        public ActionResult Adicionar()
        {
            return View("Adicionar");

        }

        public ActionResult Editar(int idBatata)
        {
            try
            {
                //Buscar Informações e carregar
                var data = _Batata.CarregarBatata(idBatata);

                var model = new BatataModel
                {
                    CodBatata = data.CodBatata,
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
                var model = new BatataModel
                {
                    ListaBatata = _Batata.CarregarBatatas()
                };

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public JsonResult Salvar(BatataModel model)
        {
            try
            {
                if (model.CodBatata != 0)
                {
                    //Atualiza
                    _Batata.AtualizaBatatas(model);
                }
                else
                {
                    //Salva um novo
                    _Batata.SalvarBatatas(model);
                }

                return Json(new { Sucesso = true, Mensagem = "Salvo com sucesso" });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = true, Mensagem = ex.Message });
            }

        }

        public JsonResult Excluir(int idBatata)
        {
            try
            {
                //Excluir
                _Batata.DeletaBatatas(idBatata);

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