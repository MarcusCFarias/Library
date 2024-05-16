using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> LoginAsync(string email, string password)
        {
            return await _context.Set<User>()
                .SingleOrDefaultAsync(u => u.Email == email
                                           && u.Password == password);
        }
    }
}
