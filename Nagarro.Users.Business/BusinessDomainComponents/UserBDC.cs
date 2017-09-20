using Nagarro.Users.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.Business
{
    public class UserBDC : IUserBDC
    {
        IUserDAC userDAC = FactoryBase.CreateDACInstance<IUserDAC>();

        public List<IUserDTO> GetAllUsers()
        {
            return userDAC.GetAllUsers();
        }

        public IUserDTO GetAUser(int id)
        {
            return userDAC.GetAUser(id);
        }

        public int InsertUser(IUserDTO userDTO)
        {
            return userDAC.InsertUser(userDTO);
        }

        public bool UpdateUser(IUserDTO userDTO)
        {
            return userDAC.UpdateUser(userDTO);
        }

        public bool DeleteUser(int id)
        {
            return userDAC.DeleteUser(id);
        }
    }
}
