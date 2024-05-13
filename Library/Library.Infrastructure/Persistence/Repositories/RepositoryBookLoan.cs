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
    public class RepositoryBookLoan : Repository<BookLoan>, IRepositoryBookLoan
    {
        public RepositoryBookLoan(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookLoan>> GetAllDetailAsync(int page, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            return await _context.Set<BookLoan>()
               .Include(b => b.Book)
               .Include(b => b.User)
               .AsNoTracking()
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync(cancellationToken);
        }
    }
}
