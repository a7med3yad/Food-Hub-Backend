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
    public class UnitOfWork(FoodHubDbContext context) : IUnitOfWork
    {
        private readonly FoodHubDbContext _context = context;
        
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
