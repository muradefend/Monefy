using Monefy.Model;
using Monefy.Model.Expences;
using Monefy.Model.Incomes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Monefy.Services.FileServices
{
    class XmlFileService : IFileService
    {

        XmlSerializer xmlExpenceSerializer = new XmlSerializer(typeof(List<List<Expence>>));
       
        public void SaveExpences(string filename, List<List<Expence>> expences)
        {
            using (var ser = new StreamWriter(filename))
            {
                xmlExpenceSerializer.Serialize(ser, expences);
            }
        }

        public List<List<Expence>> LoadExpences(string filename)
        {
            List<List<Expence>> expences = new List<List<Expence>>();

            using (var ser = new StreamReader(filename))
            {
                expences = (List<List<Expence>>)xmlExpenceSerializer.Deserialize(ser);
            }

            return expences;
        }


        XmlSerializer xmlIncomeSerializer = new XmlSerializer(typeof(List<List<Income>>));

        public void SaveIncomes(string filename, List<List<Income>> incomes)
        {
            using (var ser = new StreamWriter(filename))
            {
                xmlIncomeSerializer.Serialize(ser, incomes);
            }

        }

        public List<List<Income>> LoadIncomes(string filename)
        {
            List<List<Income>> incomes = new List<List<Income>>();

            using (var ser = new StreamReader(filename))
            {
                incomes = (List<List<Income>>)xmlIncomeSerializer.Deserialize(ser);
            }

            return incomes;
        }
    }
}
