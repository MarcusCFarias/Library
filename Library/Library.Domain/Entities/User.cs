using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            IsActive = true;
            CreatedAt = DateTime.Now;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }//adicionar um value object
        public string Password { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public virtual ICollection<BookLoan> BookLoans { get; private set; }
    }
}
