using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.ViewModels.Users
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
