using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.Shared
{
    public interface IUserDTO: IDTO
    {
        int UserId { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        string Gender { get; set; }
    }
}
