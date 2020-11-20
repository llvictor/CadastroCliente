using CadastroClientes.Dados.Contexto;
using CadastroClientes.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadastroClientes.Dados.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly Context _context;

        public RepositorioBase(Context context)
        {
            _context = context;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
