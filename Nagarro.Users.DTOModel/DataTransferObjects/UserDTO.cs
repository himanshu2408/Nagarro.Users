using Nagarro.Users.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.DTOModel
{
    public class UserDTO: IUserDTO
    {
        [EntityPropertyMappingAttribute("UserId")]
        public int UserId { get; set; }
        [EntityPropertyMappingAttribute("UserName")]
        public string Name { get; set; }
        [EntityPropertyMappingAttribute("UserAge")]
        public int Age { get; set; }
        [EntityPropertyMappingAttribute("UserGender")]
        public string Gender { get; set; }
    }
}
