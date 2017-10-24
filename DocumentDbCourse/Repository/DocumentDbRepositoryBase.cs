using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DocumentDbCourse.Repository
{
    public abstract class DocumentDbRepositoryBase<T> : IDocumentDbRepository<T> where T : class
    {
    
        Task IDocumentDbRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task IDocumentDbRepository<T>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IList<T>> IDocumentDbRepository<T>.GetAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Task<T> IDocumentDbRepository<T>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IDocumentDbRepository<T>.UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}