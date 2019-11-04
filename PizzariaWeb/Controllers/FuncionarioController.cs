using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        #region Configuração dao e construtor
        private readonly FuncionarioDAO _funcionarioDAO;
        private readonly CargoDAO _cargoDAO;
        public FuncionarioController(FuncionarioDAO funcionarioDAO, CargoDAO cargoDAO)
        {
            _funcionarioDAO = funcionarioDAO;
            _cargoDAO = cargoDAO;
        }
        #endregion
        #region INDEX LISTAR
        public IActionResult Index()
        {
            return View(_funcionarioDAO.Listar());
        }
        #endregion
        #region CADASTRAR
        public IActionResult Cadastrar()
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.Listar(), "CargoId", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Funcionario f, int drpCargos)
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.Listar(), "CargoId", "Nome");
            f.Cargo = _cargoDAO.BuscarPorId(drpCargos);

            if (_funcionarioDAO.Cadastrar(f))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion
        #region REMOVER
        public IActionResult Remover(int id)
        {
            _funcionarioDAO.Remover(id);
            return RedirectToAction("Index");
        }
        #endregion
        #region ALTERAR
        public IActionResult Alterar(int id)
        {
            ViewBag.Cargos = new SelectList(_cargoDAO.Listar(), "CargoId", "Nome");
            return View(_funcionarioDAO.BuscarPorId(id));
        }
        [HttpPost]
        public IActionResult Alterar(Funcionario f, int drpCargos)
        {
            f.Cargo = _cargoDAO.BuscarPorId(drpCargos);
            _funcionarioDAO.Alterar(f);
            return RedirectToAction("Index");
        }
        #endregion
    }
}