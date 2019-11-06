using Domain.Models;
using Repository.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.DAL
{
    public class TamanhoDAO : IRepository<Tamanho>
    {
        #region Configuração contexto
        private readonly PizzariaContext _context;
        public TamanhoDAO(PizzariaContext context)
        {
            _context = context;
        }
        #endregion

        public Tamanho BuscarPorId(int? id)
        {
            return _context.Tamanhos.Find(id);
        }

        public bool Cadastrar(Tamanho objeto)
        {
            _context.Tamanhos.Add(objeto);
            _context.SaveChanges();
            return true;
        }

        public List<Tamanho> Listar()
        {
            return _context.Tamanhos.ToList();
        }
        public void Remover(int id)
        {
            _context.Tamanhos.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }
    }
}
