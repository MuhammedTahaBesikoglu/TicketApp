using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Services
{
    public interface ITokenServicee
    {
        string GenerateToken(User user);
    }
}
