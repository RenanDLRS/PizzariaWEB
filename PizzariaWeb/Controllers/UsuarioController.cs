using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class UsuarioController : Controller
    {
        #region Confi
        private readonly UsuarioDAO _usuarioDAO;
        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }
        #endregion
        #region INDEX LISTAR
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        #region CADASTRAR
        public IActionResult Cadastrar()
        {
            Usuario u = new Usuario();
            if (TempData["Endereco"] != null)
            {
                string resultado = TempData["Endereco"].ToString();
                Endereco endereco =
                    JsonConvert.DeserializeObject<Endereco>
                    (resultado);
                u.Endereco = endereco;
            }
            return View(u);
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
        #region BUSCAR CEP
        [HttpPost]
        public IActionResult BuscarCep(Usuario u)
        {
            string url = "https://viacep.com.br/ws/" + u.Endereco.Cep + "/json/";
            WebClient client = new WebClient();
            TempData["Endereco"] = client.DownloadString(url);
            return RedirectToAction(nameof(Cadastrar));
        }
        #endregion
    }
}