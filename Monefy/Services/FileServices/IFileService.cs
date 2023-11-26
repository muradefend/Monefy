using Monefy.Model;
using Monefy.Model.Expences;
using Monefy.Model.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services.FileServices
{
    // For saving User

    public interface IFileService
    {
        void SaveExpences(string filename, List<List<Expence>> expences);

        List<List<Expence>> LoadExpences(string filename);


        void SaveIncomes(string filename, List<List<Income>> incomes);

        List<List<Income>> LoadIncomes(string filename);
    }
}
