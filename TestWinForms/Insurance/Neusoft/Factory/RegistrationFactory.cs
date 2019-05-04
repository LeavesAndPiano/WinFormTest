using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Insurance.Neusoft.Registration;

namespace Insurance.Neusoft.Factory
{
    public class RegistrationFactory
    {
        private RegistrationBase registration = null;
          public  RegistrationBase  CreateRegistration(string centerName)
        {
            switch (centerName)
            {
                case "ZhengZhou":
                    registration = new RegistrationZhengZhou();
                    break;
                case "ChangGe":
                    registration = new RegistrationChangGe();
                    break;
                default:
                    break;
            } 
            return registration;
        }
    }
}
