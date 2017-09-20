using Nagarro.Users.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.EntityDataModel.Converter
{
    public class EntityConverter
    {
        public static void FillDTOFromEntity(IDTO dto, Object entity)
        {
            Type sourceType = entity.GetType();
            Type destinationType = dto.GetType();
            foreach (PropertyInfo pSource in sourceType.GetProperties())
            {
                var valueTobeSet = pSource.GetValue(entity);
                foreach (PropertyInfo pDestination in destinationType.GetProperties())
                {
                    var nameOfEntityPropertyToBeMapped = pDestination.GetCustomAttribute<EntityPropertyMappingAttribute>().MappedPropertyname;
                    if (pSource.Name.Equals(nameOfEntityPropertyToBeMapped))
                    {
                        pDestination.SetValue(dto, valueTobeSet);
                        break;
                    }
                }
            }
        }

        public static void FillEntityFromDTO(IDTO dto, Object entity)
        {
            Type sourceType = dto.GetType();
            Type destinationType = entity.GetType();
            foreach (PropertyInfo pSource in sourceType.GetProperties())
            {
                var valueToBeSet = pSource.GetValue(dto);
                var nameOfEntityPropertyToBeMapped = pSource.GetCustomAttribute<EntityPropertyMappingAttribute>().MappedPropertyname;
                foreach (PropertyInfo pDestination in destinationType.GetProperties())
                {
                    if (pDestination.Name.Equals(nameOfEntityPropertyToBeMapped))
                    {
                        pDestination.SetValue(entity, valueToBeSet);
                        break;
                    }
                }
            }
        }
    }
}
