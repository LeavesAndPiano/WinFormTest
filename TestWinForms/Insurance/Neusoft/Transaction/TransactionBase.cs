using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Neusoft.Transaction
{
    public  class TransactionBase
    { 
        public string SignInNO { get; set; }
        public string SignOutNO { get; set; }
        public string ReadCardNO { get; set; }
        public string ChangePasswordNO { get; set; }
        public string OutpRegistrationNO { get; set; }
        public string InpRegistrationNO { get; set; } 
        public string RegistrationModfiyNO { get; set; }
        public string RevocationRegistrationNO { get; set; }
        public string RegistrationOffsetNO { get; set; }  
        public string UploadCostDetailNO { get; set; }
        public string CancelCostDetailNO { get; set; }
        public string PreSettlementNO { get; set; }
        public string SettlementNO { get; set; }
        public string CancelSettlementNO { get; set; }
        public string CheckAccountNO { get; set; }
        public string CheckAccountDetailNO { get; set; }

        //医院信息相关内容    
        public string HospitalNO { get; set; }
        public string OperatorID { get; set; }
        public string OperatorName { get; set; }
        //public string CycleNO { get; set; }
        //public string TransactionNO { get; set; }
        public string CenterCode { get; set; }
     



    }
}
