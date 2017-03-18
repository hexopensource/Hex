using Hex.DataTypes.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.DataAccess.Helper
{
    public class DataHelper
    {
        public static void CopyValues(Node target, Node source)
        {
            Type t = typeof(Node);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                    prop.SetValue(target, value, null);
            }
        }
    }
}
