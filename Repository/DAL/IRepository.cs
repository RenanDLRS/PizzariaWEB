using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DAL
{
    interface IRepository<T>
    {
        bool Cadastrar(T objeto);
        List<T> Listar();
        T BuscarPorId(int? id);
    }
}
