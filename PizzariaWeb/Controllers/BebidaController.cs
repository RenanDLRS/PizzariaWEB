﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace PizzariaWeb.Controllers
{
    public class BebidaController : Controller
    {
        #region DAO configuração
        private readonly BebidaDAO _bebidaDAO;
        public BebidaController(BebidaDAO bebidaDAO)
        {
            _bebidaDAO = bebidaDAO;
        }
        #endregion
        #region INDEX LISTAR CADASTRAR
        public IActionResult Index()
        {
            ViewBag.ListaBebida = _bebidaDAO.Listar();
            return View();
        }
        [HttpPost]
        public IActionResult Index(Bebida b)
        {
            _bebidaDAO.Cadastrar(b);
            ViewBag.ListaBebida = _bebidaDAO.Listar();
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