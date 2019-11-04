using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class CargoController : Controller
    {
        #region DAO configuração
        private readonly CargoDAO _cargoDAO;
        public CargoController(CargoDAO cargoDAO)
        {
            _cargoDAO = cargoDAO;
        }
        #endregion
        #region INDEX LISTAR CADASTRAR
        public IActionResult Index()
        {
            ViewBag.Cargo = new Cargo();
            return View(_cargoDAO.Listar());
        }
        [HttpPost]
        public IActionResult Index(string txtNome, string txtSalario)
        {
            Cargo cargo = new Cargo
            {
                Nome = txtNome,
                Salario = Convert.ToDouble(txtSalario)
            };
            _cargoDAO.Cadastrar(cargo);
            return View(_cargoDAO.Listar());
        }
        #endregion
        #region REMOVER
        public IActionResult Remover(int id)
        {
            _cargoDAO.Remover(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}