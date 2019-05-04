using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Neusoft.Registration
{
    public   class RegistrationBase
    { 
        public virtual string GetRegStr()
        {
            return "";
        }
        public string CheckStringNull(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            else
            {
                return str;

            }
        }

    }
}
