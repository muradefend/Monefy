using Monefy.Model.Holders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Expences
{
    public class HouseExpence : Expence
    {

        public HouseExpence() : this(0) { }

        public HouseExpence(double sum)
        {
            TotalSum = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
