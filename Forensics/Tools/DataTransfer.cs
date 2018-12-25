using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BLL;
using IBLL;

namespace Forensics.Tools
{
    public class DataTransfer<TSrc, TDest> where TSrc: class, new() where TDest : class, new()
    {
        public TDest GetResult(TSrc src)
        {
            TDest dest = new TDest();
            Type srcType = typeof(TSrc);
            Type destType = typeof(TDest);
            PropertyInfo[] piSrc = srcType.GetProperties();
            PropertyInfo[] piDest = destType.GetProperties();
            foreach (PropertyInfo propertySrc in piSrc)
            {
                foreach (PropertyInfo propertyDest in piDest)
                {
                    if (propertySrc.Name == propertyDest.Name && propertySrc.PropertyType == propertyDest.PropertyType)
                    {
                        Object obj = propertySrc.GetValue(src, null);
                        propertyDest.SetValue(dest, obj, null);
                    }
                }
            }
            return dest;
        }

    }
}
