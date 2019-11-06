using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class TamanhoController : Controller
    {
        #region DAO configuração
        private readonly TamanhoDAO _tamanhoDAO;
        public TamanhoController(TamanhoDAO tamanhoDAO)
        {
            _tamanhoDAO = tamanhoDAO;
        }
        #endregion
        #region INDEX LISTAR CADASTRAR
        public IActionResult Index()
        {
            ViewBag.ListaTamanho = _tamanhoDAO.Listar();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Tamanho c, int drpQntdSabores)
        {
            c.QtdSabores = drpQntdSabores;
            _tamanhoDAO.Cadastrar(c);
            ViewBag.ListaTamanho = _tamanhoDAO.Listar();
            return View();
        }
        #endregion
        #region REMOVER
        public IActionResult Remover(int id)
        {
            _tamanhoDAO.Remover(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}