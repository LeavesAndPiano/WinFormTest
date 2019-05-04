
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Insurance.Interface;
using Insurance.Comm;
using Insurance.Neusoft.Transaction;
using Insurance.Neusoft.Registration;
using Insurance.Neusoft.Factory;
namespace Insurance.Neusoft.Business
{
    public class InsuranceNeusoft : InsuranceNeusoftBase
    {
        private string center;
        //业务编号  
        private TransactionBase transaction = null;
        //登记
        private RegistrationBase registration = null;
        public InsuranceNeusoft(string centerName)
        {
            TransactionFactory transactionFactory = new TransactionFactory();
            RegistrationFactory registrationFactory = new RegistrationFactory(); 
            transaction = transactionFactory.CreateTransaction(centerName);
            registration = registrationFactory.CreateRegistration(centerName);
            center = centerName;
        }
        public string GetCycleNO()
        {
            return "";
        }
        public string GetTransactionNO()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff"); 
        }
        public string GetHead(string transactionID,string parameterIN)
        {
            string result = string.Empty;
            List<string> resultList = new List<string>();
            resultList.Add(transactionID);
            resultList.Add(transaction.HospitalNO);
            resultList.Add(transaction.OperatorID);
            resultList.Add(GetCycleNO());
            resultList.Add(GetTransactionNO());
            resultList.Add(transaction.CenterCode); 
            StringBuilder stringBuilder = new StringBuilder(); 
            foreach (var item in resultList)
            { 
                stringBuilder.Append(item);
                stringBuilder.Append("^");
            }
            result = stringBuilder.ToString() + parameterIN;
            return result;
        }
        public override int BUSINESS_HANDLE(string parameterIn, ref string parameterOut)
        {
            throw new NotImplementedException();
        }

        public override int CancelCostDetail()
        {
            throw new NotImplementedException();
        }

        public override int CancelSettlement()
        {
            throw new NotImplementedException();
        }

        public override int ChangePassword()
        {
            throw new NotImplementedException();
        }

        public override int CheckAccount()
        {
            throw new NotImplementedException();
        }

        public override int CheckAccountDetail()
        {
            throw new NotImplementedException();
        }

        public override int INIT(ref string msg)
        {
            //初始化相关DLL文件
            msg = "初始化成功！";
            return 0;
        }

        public override int PreSettlement()
        {
            throw new NotImplementedException();
        }

        public override int ReadCard(out object cardInfo)
        {
            throw new NotImplementedException();
        }
         
         
        public override int Settlement()
        {
            throw new NotImplementedException();
        }

        public override int SignIn(out string cycleNO)
        {
            cycleNO = transaction.SignInNO;
            return 0;
        }

        public override int SignOut()
        {
            throw new NotImplementedException();
        }

        public override int UploadCostDetail()
        {
            throw new NotImplementedException();
        }

        public override int RegistrationOutp()
        {
            throw new NotImplementedException();
        }

        public override int RegistrationModify()
        {
            throw new NotImplementedException();
        }

        public override int RegistrationInp()
        {
            throw new NotImplementedException();
        }

        public override int RegistrationRevocation()
        {
            throw new NotImplementedException();
        }

        public override int Registration(ref string msg)
        {
            msg = GetHead(transaction.OutpRegistrationNO, registration.GetRegStr());

            return 0;
        }
    }
}
