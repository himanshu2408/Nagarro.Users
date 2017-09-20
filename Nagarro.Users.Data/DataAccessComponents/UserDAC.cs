using Nagarro.Users.EntityDataModel.Converter;
using Nagarro.Users.EntityDataModel.EntityModel;
using Nagarro.Users.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.Data
{
    public class UserDAC : IUserDAC
    {
        public List<IUserDTO> GetAllUsers()
        {
            List<IUserDTO> usersDTO = new List<IUserDTO>();
            UserStoryEntities context = new UserStoryEntities();
            using (context)
            {
                foreach (User user in context.Users)
                {
                    IUserDTO userDTO = FactoryBase.CreateDTOInstance<IUserDTO>();
                    EntityConverter.FillDTOFromEntity(userDTO, user);
                    usersDTO.Add(userDTO);
                }
            }
            return usersDTO;
        }

        public IUserDTO GetAUser(int id)
        {
            IUserDTO userDTO = FactoryBase.CreateDTOInstance<IUserDTO>();
            using (UserStoryEntities context = new UserStoryEntities())
            {
                User user = context.Users.Find(id);
                EntityConverter.FillDTOFromEntity(userDTO, user);
            }
            return userDTO;
        }

        public int InsertUser(IUserDTO userDTO)
        {
            int retVal = -1;
            using (UserStoryEntities context = new UserStoryEntities())
            {
                User user = new User();
                EntityConverter.FillEntityFromDTO(userDTO, user);
                context.Users.Add(user);
                context.SaveChanges();
                retVal = user.UserId;
            }
            return retVal;
            
        }

        public bool UpdateUser(IUserDTO userDTO)
        {
            bool retVal = false;
            using (UserStoryEntities context = new UserStoryEntities())
            {
                User user = context.Users.Where(u => u.UserId == userDTO.UserId).SingleOrDefault();
                EntityConverter.FillEntityFromDTO(userDTO, user);
                context.SaveChanges();
                retVal = true;
            }
            
            return retVal;
        }

        public bool DeleteUser(int id)
        {
            bool retVal = false;
            using (UserStoryEntities context = new UserStoryEntities())
            {
                context.Users.Remove(context.Users.Where(u => u.UserId == id).SingleOrDefault());
                context.SaveChanges();
                retVal = true;
            }
            return retVal;
        }
    }
}
