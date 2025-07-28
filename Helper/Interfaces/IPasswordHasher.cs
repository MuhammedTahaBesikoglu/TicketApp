using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Interfaces
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string password, string storedHash);
    }
}
