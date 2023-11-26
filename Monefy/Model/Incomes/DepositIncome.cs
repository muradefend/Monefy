using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Incomes
{
    public class DepositIncome : Income
    {
        public DepositIncome() : this(0) { }

        public DepositIncome(double sum)
        {
            TotalIncome = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
