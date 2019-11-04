using Domain.Models;
using Repository.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.DAL
{
    public class CargoDAO : IRepository<Cargo>
    {
        #region Configuração contexto
        private readonly PizzariaContext _context;
        public CargoDAO(PizzariaContext context)
        {
            _context = context;
        }
        #endregion

        public Cargo BuscarPorId(int? id)
        {
            return _context.Cargos.Find(id);
        }

        public bool Cadastrar(Cargo objeto)
        {
            throw new NotImplementedException();
        }

        public List<Cargo> Listar()
        {
            return _context.Cargos.ToList();
        }
    }
}
