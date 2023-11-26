using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Incomes
{
    public class SalaryIncome : Income
    {
        public SalaryIncome() : this(0) { }

        public SalaryIncome(double sum)
        {
            TotalIncome = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
