using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO _usuarioDAO;
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }
        #region INDEX LISTAR
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        #region CADASTRAR
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (_usuarioDAO.Cadastrar(usuario))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Este e-mail já está sendo utilizado!");
            }
            return View(usuario);
        }
        #endregion
    }
}