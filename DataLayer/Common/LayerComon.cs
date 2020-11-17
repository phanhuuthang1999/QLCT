using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Common
{
    public static class LayerComon
    {
        public static string GetDescription(this Enum val)
        {
            string name = Enum.GetName(val.GetType(), val);

            System.Reflection.FieldInfo obj = val.GetType().GetField(name);

            if (obj != null)
            {
                object[] attributes = obj.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

                return attributes.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description : null;
            }

            return null;
        }
    }
}
