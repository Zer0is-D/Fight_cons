using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_cons.Основа_и_настройки
{
    public class Info
    {
        public double ParamValue;
        public string ParamName;

        public Info(object a, object b)
        {
            string check = a.ToString();

            ParamValue = double.Parse(check);
            ParamName = (string) b;
        }
    }
}
