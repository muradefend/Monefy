using Monefy.Model.Holders;
using System;

namespace Monefy.Model.Expences
{
    public class HealthExpence : Expence
    {


        public HealthExpence() : this(0) { }

        public HealthExpence(double sum)
        {
            TotalSum = sum;
            ExecutionDate = DateTime.Now;
        }
    }
}
