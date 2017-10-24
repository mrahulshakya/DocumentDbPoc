using DocumentDbCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DocumentDbCourse.Repository
{
    public class UserRepository : IDocumentDbRepository<User>
    {
        Task IDocumentDbRepository<User>.AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task IDocumentDbRepository<User>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IList<User>> IDocumentDbRepository<User>.GetAsync(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Task<User> IDocumentDbRepository<User>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IDocumentDbRepository<User>.UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}