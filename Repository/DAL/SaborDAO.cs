using Domain.Models;
using Repository.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.DAL
{
    public class SaborDAO : IRepository<Sabor>
    {
        #region Configuração contexto
        private readonly PizzariaContext _context;
        public SaborDAO(PizzariaContext context)
        {
            _context = context;
        }
        #endregion

        public Sabor BuscarPorId(int? id)
        {
            return _context.Sabores.Find(id);
        }

        public bool Cadastrar(Sabor objeto)
        {
            _context.Sabores.Add(objeto);
            _context.SaveChanges();
            return true;
        }

        public List<Sabor> Listar()
        {
            return _context.Sabores.ToList();
        }
        public void Remover(int id)
        {
            _context.Sabores.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
    }
}
