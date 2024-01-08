using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> Remove(T model);
        Task<bool> Update(T model);

        Task<List<T>> GetList(Expression<Func<T, bool>> filter=null);
        Task<T> Get(int id);
    }
}
