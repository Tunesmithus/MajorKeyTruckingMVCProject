using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MajorKeyTruckingMVCProject.DataLayer.ExtensionMethods
{
    public static class StringExtension
    {
        public static int ToInt(this string s)
        { 
            
            int.TryParse(s, out int id);
            return id;
        }

        public static bool EqualsNoCase(this string s, string toCompare) => s?.ToLower() == toCompare?.ToLower();

    }

}
