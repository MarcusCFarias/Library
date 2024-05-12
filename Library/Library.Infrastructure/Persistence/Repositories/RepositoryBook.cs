using Azure;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class RepositoryBook : Repository<Book>, IRepositoryBook
    {
        public RepositoryBook(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Book>> GetByGenreAsync(string genre, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.Set<Book>()
                 .AsNoTracking()
                 .Where(b => b.Genre.Contains(genre))
                 .ToListAsync(cancellationToken);
        }

        public async Task<Book?> GetByISBNAsync(string isbn, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _context.Set<Book>()
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.ISBN == isbn, cancellationToken);
        }
    }
}
