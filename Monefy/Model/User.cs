using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monefy.Model.Holders;

namespace Monefy.Model
{
    public class User
    {
        public ExpencesHolder ExpencesHolder { get; set; }

        public IncomesHolder IncomesHolder { get; set; }

        public User()
        {
            ExpencesHolder = new ExpencesHolder();
            IncomesHolder = new IncomesHolder();
        }

    }
}
