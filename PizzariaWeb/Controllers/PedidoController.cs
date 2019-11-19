using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class PedidoController : Controller
    {
        #region DAO configuração
        private readonly TamanhoDAO _tamanhoDAO;
        private readonly SaborDAO _saborDAO;
        private readonly BebidaDAO _bebidaDAO;
        public PedidoController(TamanhoDAO tamanhoDAO, SaborDAO saborDAO, BebidaDAO bebidaDAO)
        {
            _tamanhoDAO = tamanhoDAO;
            _saborDAO = saborDAO;
            _bebidaDAO = bebidaDAO;
        }
        #endregion

        public IActionResult Index()
        {
            ViewBag.ListaTamanho = _tamanhoDAO.Listar();
            ViewBag.ListaSabor = _saborDAO.Listar();
            ViewBag.ListaBebida = _bebidaDAO.Listar();
            return View();
        }
    }
}