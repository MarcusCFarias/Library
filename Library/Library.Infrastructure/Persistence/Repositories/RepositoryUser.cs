using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class RepositoryUser : Repository<User>, IRepositoryUser
    {
        public RepositoryUser(AppDbContext context) : base(context)
        {
        }
    }
}
