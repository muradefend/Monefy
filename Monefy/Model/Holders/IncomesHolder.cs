using Monefy.Model.Incomes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Model.Holders
{
    public class IncomesHolder
    {
        public List<List<Income>> allIncomes{ get; set; }

        public IncomesHolder()
        {
            allIncomes = new List<List<Income>>();

            List<Income> depositIncome = new List<Income>();
            List<Income> salaryIncome = new List<Income>();
            List<Income> savingsIncome = new List<Income>();

            allIncomes.Add(depositIncome);
            allIncomes.Add(salaryIncome);
            allIncomes.Add(savingsIncome);
        }


        #region Add Income

        /* Add new mehtod for each new income */


        public void AddDepositIncome(double sum)
        {
            allIncomes[0].Add(new DepositIncome(sum));
        }

        public void AddSalaryIncome(double sum)
        {
            allIncomes[1].Add(new SalaryIncome(sum));
        }

        public void AddSavingsIncome(double sum)
        {
            allIncomes[2].Add(new SavingsIncome(sum));
        }


        #endregion



        #region Get Income for Provided Time Span


        /*
         
         Return order:
            -deposit
            -salary
            -savings

         */


        public List<double> GetAllIncome()
        {
            List<double> sums = new List<double>();
            double totalCount = 0;

            for (int i = 0; i < allIncomes.Count; i++)
            {
                totalCount = 0;

                for (int j = 0; j < allIncomes[i].Count; j++)
                {
                    totalCount += allIncomes[i][j].TotalIncome;
                }

                sums.Add(totalCount);
            }


            return sums;
        }


        public List<double> GetIncomesPerOneDay(DateTime day)
        {
            List<double> sums = new List<double>();

            // Default values
            for (int i = 0; i < allIncomes.Count; i++)
            {
                sums.Add(0);
            }


            for (int i = 0; i < allIncomes.Count; i++)
            {
                for (int j = 0; j < allIncomes[i].Count; j++)
                {
                    if (allIncomes[i][j].ExecutionDate.Day == day.Day && allIncomes[i][j].ExecutionDate.Month == day.Month && allIncomes[i][j].ExecutionDate.Year == day.Year)
                    {
                        sums[i] += allIncomes[i][j].TotalIncome;
                    }

                    else if ((allIncomes[i][j].ExecutionDate.Year > day.Year) || (allIncomes[i][j].ExecutionDate.Year == day.Year && allIncomes[i][j].ExecutionDate.Month > day.Month) ||
                        (allIncomes[i][j].ExecutionDate.Day > day.Day && allIncomes[i][j].ExecutionDate.Month == day.Month && allIncomes[i][j].ExecutionDate.Year == day.Year))
                    {
                        break;
                    }
                }
            }

            return sums;
        }


        public List<double> GetIncomesForLatestWeek()
        {

            List<double> sums = new List<double>();

            // Default values
            for (int i = 0; i < allIncomes.Count; i++)
            {
                sums.Add(0);
            }

            for (int i = 0; i < allIncomes.Count; i++)
            {
                for (int j = 0; j < allIncomes[i].Count; j++)
                {
                    if (DateTime.Now.Subtract(allIncomes[i][j].ExecutionDate).TotalDays <= 7)
                    {
                        sums[i] += allIncomes[i][j].TotalIncome;
                    }
                    else if (DateTime.Now.DayOfYear - allIncomes[i][j].ExecutionDate.DayOfYear > 7)
                    {
                        break;
                    }
                }
            }

            return sums;
        }


        public List<double> GetIncomesForLatestMonth()
        {
            List<double> sums = new List<double>();

            // Default values
            for (int i = 0; i < allIncomes.Count; i++)
            {
                sums.Add(0);
            }

            for (int i = 0; i < allIncomes.Count; i++)
            {
                for (int j = 0; j < allIncomes[i].Count; j++)
                {
                    if (DateTime.Now.Month == allIncomes[i][j].ExecutionDate.Month && DateTime.Now.Year == allIncomes[i][j].ExecutionDate.Year)
                    {
                        sums[i] += allIncomes[i][j].TotalIncome;
                    }
                }
            }

            return sums;
        }



        public List<double> GetIncomesForLatestYear()
        {
            List<double> sums = new List<double>();

            // Default values
            for (int i = 0; i < allIncomes.Count; i++)
            {
                sums.Add(0);
            }

            for (int i = 0; i < allIncomes.Count; i++)
            {
                for (int j = 0; j < allIncomes[i].Count; j++)
                {
                    if (DateTime.Now.Year == allIncomes[i][j].ExecutionDate.Year)
                    {
                        sums[i] += allIncomes[i][j].TotalIncome;
                    }
                }
            }

            return sums;
        }

        #endregion


    }
}
