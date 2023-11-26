using Monefy.Model.Holders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Expences
{
    public class SportsExpence : Expence
    {
        public SportsExpence() : this(0) { }

        public SportsExpence(double sum)
        {
            TotalSum = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
