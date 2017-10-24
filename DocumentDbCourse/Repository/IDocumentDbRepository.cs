using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace DocumentDbCourse.Repository
{
    public interface IDocumentDbRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task UpdateAsync(int id);

        Task<T> GetAsync(int id);


        Task DeleteAsync(int id);

        Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter = null);
    }
}