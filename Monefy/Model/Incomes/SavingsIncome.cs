using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Incomes
{
    public class SavingsIncome : Income
    {
        public SavingsIncome() : this(0) { }

        public SavingsIncome(double sum)
        {
            TotalIncome = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
