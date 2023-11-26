using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Monefy.Model.Incomes
{
    [XmlInclude(typeof(SalaryIncome))]
    [XmlInclude(typeof(SavingsIncome))]
    [XmlInclude(typeof(DepositIncome))]
    public class Income
    {
        public double TotalIncome { get; set; }

        public DateTime ExecutionDate { get; set; }
    }
}
