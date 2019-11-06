using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class SaborController : Controller
    {
        #region DAO configuração
        private readonly SaborDAO _bebidaDAO;
        public SaborController(SaborDAO bebidaDAO)
        {
            _bebidaDAO = bebidaDAO;
        }
        #endregion
        #region INDEX LISTAR CADASTRAR
        public IActionResult Index()
        {
            ViewBag.ListaSabor = _bebidaDAO.Listar();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Sabor s)
        {
            _bebidaDAO.Cadastrar(s);
            ViewBag.ListaSabor = _bebidaDAO.Listar();
            return View();
        }
        #endregion
        #region REMOVER
        public IActionResult Remover(int id)
        {
            _bebidaDAO.Remover(id);
            return RedirectToAction("Index");
        }
        #endregion
    }

}