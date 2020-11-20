using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<T> : IDisposable where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        T GetById(int id);
        void Delete(int id);
        List<T> List();
    }
}
