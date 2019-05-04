using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Neusoft.Registration
{
    public class RegistrationZhengZhou : RegistrationBase
    {
        //1
        public string HosSeq { get; set; }
        public string MedicalType { get; set; }
        public string RegDate { get; set; }
        public string ExpenseFlag { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisName { get; set; }
        public string CaseInfo { get; set; }
        public string DeptName { get; set; }
        public string BedNO { get; set; }
        public string DoctorNO { get; set; }
        public string DoctorName { get; set; }
        public string OperatorName { get; set; }
        public string FertilitySurgery { get; set; }
        public string FertilityNO { get; set; }
        public string MaleWorkerID { get; set; }
        public string MaleWorkerNAME { get; set; }
       
        public override string GetRegStr()
        {
            
            List<string> resultList = new List<string>();
            resultList.Add(CheckStringNull(HosSeq));
            resultList.Add(CheckStringNull(MedicalType));
            resultList.Add(CheckStringNull(RegDate)); 
            resultList.Add(CheckStringNull(ExpenseFlag)); 
            resultList.Add(CheckStringNull(DiagnosisCode)); 
            resultList.Add(CheckStringNull(DiagnosisName)); 
            resultList.Add(CheckStringNull(DeptName)); 
            resultList.Add(CheckStringNull(BedNO)); 
            resultList.Add(CheckStringNull(DoctorNO)); 
            resultList.Add(CheckStringNull(DoctorName)); 
            resultList.Add(CheckStringNull(OperatorName)); 
            resultList.Add(CheckStringNull(FertilitySurgery)); 
            resultList.Add(CheckStringNull(FertilityNO));
            resultList.Add(CheckStringNull(MaleWorkerID));
            resultList.Add(CheckStringNull(MaleWorkerNAME)); 

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in resultList)
            {
                stringBuilder.Append(item);
                stringBuilder.Append("|");
            }
            string result = stringBuilder.ToString() + "^";
            return result;
        }
    }
}
