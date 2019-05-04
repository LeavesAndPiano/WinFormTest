using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Comm
{
   
    public class InsuranceNeusoftTransaction
    {
        
        public string SignIn { get; set; }
        public string SignOut { get; set; }
        public string ReadCard { get; set; }
        public string ChangePassword { get; set; }
        public string Registration { get; set; }
        public string RevocationRegistration { get; set; }
        public string UploadCostDetail { get; set; }
        public string CancelCostDetail { get; set; }
        public string PreSettlement { get; set; }
        public string Settlement { get; set; }
        public string CancelSettlement { get; set; }
        public string CheckAccount { get; set; }
        public string CheckAccountDetail { get; set; }

        //医院信息
        public string HosNo { get; set; }
        public string CurUserNO { get; set; }
        public string CurUserName { get; set; }
    }

    
}
