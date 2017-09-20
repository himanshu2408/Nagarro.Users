using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.Shared
{
    public interface IUserDAC: IDAC
    {
        List<IUserDTO> GetAllUsers();
        IUserDTO GetAUser(int id);
        int InsertUser(IUserDTO userDTO);
        bool UpdateUser(IUserDTO userDTO);
        bool DeleteUser(int id);
    }
}
