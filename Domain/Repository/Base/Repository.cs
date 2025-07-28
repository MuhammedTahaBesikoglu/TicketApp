using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<T> AddAsync(T Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
        public void Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }

        public void Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
            
        }

    }
}
