using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Insurance.Comm;

namespace Insurance.Interface
{
    public interface IInsuranceNeusoft
    {

        //string TransactionID { get; set; }
        //string HospitalNO { get; set; }
        //string UserID { get; set; }
        //string CycleNO { get; set; }
        //string TransactionNO { get; set; }
        //string CenterCode { get; set; }
        //string ParameterIn { get; set; }
        
        int SignIn(out string cycleNO);
        int SignOut();
        int ReadCard(out object cardInfo);
        int ChangePassword(); 
        int Registration();
        int RevocationRegistration();
        int UploadCostDetail();
        int CancelCostDetail(); 
        int PreSettlement();
        int Settlement();
        int CancelSettlement();
        int CheckAccount();
        int CheckAccountDetail(); 
        int INIT(ref string msg);
        int BUSINESS_HANDLE(string parameterIn,ref string parameterOut);
          
    }
}
