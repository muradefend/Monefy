using Monefy.Model.Holders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Expences
{
    public class EatingOutExpence : Expence
    {

        public EatingOutExpence() : this(0) { }

        public EatingOutExpence(double sum)
        {
            TotalSum = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
