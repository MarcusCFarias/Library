using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}
