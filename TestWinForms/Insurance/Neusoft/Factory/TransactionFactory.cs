using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Insurance.Neusoft.Transaction;
namespace Insurance.Neusoft.Factory
{
    public  class TransactionFactory
    {
        private TransactionBase transaction = null;

        public TransactionBase CreateTransaction(string centerName)
        {
            switch (centerName)
            {
                case "ZhengZhou":
                    transaction = new TransactionZhengZhou();
                    break;
                case "ChangGe":
                    transaction = new TransactionChangGe();
                    break;
                default:
                    break;
            }
            return transaction;
        }
    }
}
