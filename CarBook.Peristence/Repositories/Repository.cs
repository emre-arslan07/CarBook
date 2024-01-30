using CarBook.Application.Interfaces;
using CarBook.Domain.Common;
using CarBook.Peristence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Peristence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CarBookDbContext _context;

        public Repository(CarBookDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T model)
        {
            var addedEntity = _context.Entry(model);
            addedEntity.State = EntityState.Added;
            if (await _context.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter/*=null*/)
        {
            return (filter == null ?
                   await _context.Set<T>().ToListAsync() :
                   await _context.Set<T>().Where(filter).ToListAsync());
        }

        public async Task<bool> Remove(T model)
        {
            var deletedEntity = _context.Entry(model);
            deletedEntity.State = EntityState.Deleted;
            if (await _context.SaveChangesAsync()>= 1)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> Update(T model)
        {
            var deletedEntity = _context.Entry(model);
            deletedEntity.State = EntityState.Modified;
            if (await _context.SaveChangesAsync() >= 1)
            {
                return true;
            }
            else { return false; }
        }
    }
}
