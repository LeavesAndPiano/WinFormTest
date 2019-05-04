using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Comm
{
    public abstract class InsuranceNeusoftBase
    {
        public string TransactionID { get; set; }
        public string HospitalNO { get; set; }
        public string UserID { get; set; }
        public string CycleNO { get; set; }
        public string TransactionNO { get; set; }
        public string CenterCode { get; set; }
        public string ParameterIn { get; set; }

        public abstract int SignIn(out string cycleNO);
        public abstract int SignOut();
        public abstract int ReadCard(out object cardInfo);
        public abstract int ChangePassword();
        public abstract int Registration(ref string msg);
        public abstract int RegistrationOutp();
        public abstract int RegistrationModify(); 
        public abstract int RegistrationInp();
        public abstract int RegistrationRevocation();
        public abstract int UploadCostDetail();
        public abstract int CancelCostDetail();
        public abstract int PreSettlement();
        public abstract int Settlement();
        public abstract int CancelSettlement();
        public abstract int CheckAccount();
        public abstract int CheckAccountDetail();
        public abstract int INIT(ref string msg);
        public abstract int BUSINESS_HANDLE(string parameterIn, ref string parameterOut);
    }
}
