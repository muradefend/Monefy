using Monefy.Model.Holders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Expences
{
    public class ClothesExpence : Expence
    {
        public ClothesExpence() : this(0) { }

        public ClothesExpence(double sum)
        {
            TotalSum = sum;
            ExecutionDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{ TotalSum } {ExecutionDate}";
        }
    }
}
