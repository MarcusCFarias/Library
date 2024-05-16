using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepository<User>
    {
        Task<User> LoginAsync(string email, string password);
    }
}
