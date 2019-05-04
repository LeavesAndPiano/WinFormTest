using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Interface
{
    public  interface IInsuranceNeusoftTransaction
    { 
       
        string signIn { get; set; }
        string signOut { get; set; }
        string readCard { get; set; }
        string changePassword { get; set; }
        string registration { get; set; } 
        string revocationRegistration { get; set; } 
        string uploadCostDetail { get; set; }
        string cancelCostDetail { get; set; }
        string preSettlement { get; set; }
        string settlement { get; set; }
        string cancelSettlement { get; set; } 
        string checkAccount { get; set; }
        string checkAccountDetail { get; set; }

        //医院信息
        string HosNo { get; set; }
        string CurUserNO { get; set; }
        string CurUserName { get; set; }



    }
}
