using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.Users.Shared
{
    public static class FactoryBase
    {
        public static T CreateBDCInstance<T>()
        {
            var retVal = (T)CreateInstance(typeof(T).FullName, "BDCdllKey");
            return retVal;
        }

        public static T CreateDACInstance<T>()
        {
            var retVal = (T)CreateInstance(typeof(T).FullName, "DACdllKey");
            return retVal;
        }

        public static T CreateDTOInstance<T>()
        {
            var retVal = (T)CreateInstance(typeof(T).FullName, "DTOdllKey");
            return retVal;
        }

        private static object CreateInstance(string interfaceName, string dllPathKey)
        {
            Object retVal = null;
            string outputBinPath = ConfigurationManager.AppSettings["OutputBinPath"];
            string fileName = ConfigurationManager.AppSettings[dllPathKey];
            string assemblyPath = Path.Combine(outputBinPath, fileName);

            Assembly asm = Assembly.LoadFrom(assemblyPath);
            if (asm != null)
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (t.GetInterface(interfaceName) != null)
                    {
                        retVal = Activator.CreateInstance(t);
                        break;
                    }
                }
            }
            return retVal;
        }
    }
}
