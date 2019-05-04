using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Neusoft.Transaction
{
    public class TransactionZhengZhou: TransactionBase
    {
        public TransactionZhengZhou()
        {
            base.SignInNO = "031100";
            base.SignOutNO = "031110";
            base.ReadCardNO = "931000";
            base.ChangePasswordNO = "931010";
            base.OutpRegistrationNO = "931110";
            base.InpRegistrationNO = "931120";
            base.RegistrationModfiyNO = "931130";
            base.RevocationRegistrationNO = "931140";
            base.RegistrationOffsetNO = "931150";
            base.UploadCostDetailNO = "931300";
            base.CancelCostDetailNO = "931340";
            base.PreSettlementNO = "931220";
            base.SettlementNO = "931210";
            base.CancelSettlementNO = "931240";
            base.CheckAccountNO = "331400";
            base.CheckAccountDetailNO = "331410";

            //医院相关
            base.HospitalNO = "郑州医院";
            base.OperatorID = "admin";
            base.CenterCode = "neusoft";
        }
    }
}
