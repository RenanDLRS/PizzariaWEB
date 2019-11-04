using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}