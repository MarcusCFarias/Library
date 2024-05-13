using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IRepositoryBookLoan : IRepository<BookLoan>
    {
        Task<IEnumerable<BookLoan>> GetAllDetailAsync(int page, int pageSize = 10, CancellationToken cancellationToken = default(CancellationToken));
    }
}
