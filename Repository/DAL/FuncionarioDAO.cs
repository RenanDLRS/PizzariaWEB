using Domain.Models;
using Repository.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.DAL
{
    public class FuncionarioDAO : IRepository<Funcionario>
    {
        #region Configuração contexto
        private readonly PizzariaContext _context;
        public FuncionarioDAO(PizzariaContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos da interface
        public Funcionario BuscarPorId(int? id)
        {
            return _context.Funcionarios.Find(id);
        }

        public bool Cadastrar(Funcionario f)
        {
            _context.Funcionarios.Add(f);
            _context.SaveChanges();
            return true;
        }

        public List<Funcionario> Listar()
        {
            return _context.Funcionarios.ToList();
        }

        public void Remover(int id)
        {
            _context.Funcionarios.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Funcionario f)
        {
            _context.Funcionarios.Update(f);
            _context.SaveChanges();
        }
        #endregion
    }
}
