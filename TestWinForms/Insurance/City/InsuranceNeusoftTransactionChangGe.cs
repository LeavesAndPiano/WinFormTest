
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Insurance.Comm;
using Insurance.Interface;

namespace Insurance.City
{
    public class InsuranceNeusoftTransactionChangGe:InsuranceNeusoftTransaction
    {
       public void Init()
        {
            SignIn = "99999999999999999";
            SignOut = "";
            ReadCard = "";
            ChangePassword = "";
            Registration = "";
            RevocationRegistration = "";
            UploadCostDetail = "";
            CancelCostDetail = "";
            PreSettlement = "";
            Settlement = "";
            CancelSettlement = "";
            CheckAccount = "";
            CheckAccountDetail = "";
            HosNo = "";
            CurUserNO = "";
            CurUserName = ""; 
       } 
    }
}
