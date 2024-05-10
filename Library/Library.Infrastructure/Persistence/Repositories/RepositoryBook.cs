using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class RepositoryBook : Repository<Book>, IRepositoryBook
    {
        public RepositoryBook(AppDbContext context) : base(context)
        {

        }
        public Task<IEnumerable<Book>> GetByGenreAsync(string genre)
        {
            throw new NotImplementedException();
        }
    }
}
