using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.Shared
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EntityPropertyMappingAttribute:  Attribute
    {
        public string MappedPropertyname { get; set; }

        public EntityPropertyMappingAttribute(string name)
        {
            MappedPropertyname = name;
        }
    }
}
