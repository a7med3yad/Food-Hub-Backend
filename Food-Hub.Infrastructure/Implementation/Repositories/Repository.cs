using Food_Hub.Core.Interfaces.Repositories;
using Food_Hub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Hub.Infrastructure.Implementation.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext _context;
        public Repository(AppDbContext _context)
        {
            this._context = _context;
        }


        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
