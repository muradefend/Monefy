using Monefy.Model.Holders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Expences
{
    public class EntertainmentExpence : Expence
    {

        public EntertainmentExpence() : this(0) { }

        public EntertainmentExpence(double sum)
        {
            TotalSum = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
