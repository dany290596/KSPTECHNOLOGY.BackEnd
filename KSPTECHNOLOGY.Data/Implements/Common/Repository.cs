using KSPTECHNOLOGY.Data.Context;
using KSPTECHNOLOGY.Data.Interfaces.Common;
using KSPTECHNOLOGY.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Implements.Common
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly KSPTECHNOLOGYContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(KSPTECHNOLOGYContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T t)
        {
            await _entities.AddAsync(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }

        public async Task Delete(Guid id)
        {
            T t = await GetById(id);
            _context.Remove(t);
        }
    }
}