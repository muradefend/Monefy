using Monefy.Model.Expences;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Monefy.Model.Holders
{
    public class ExpencesHolder
    {
        public List<List<Expence>> allExpences { get; set; }


        public ExpencesHolder()
        {
            allExpences = new List<List<Expence>>();

            List<Expence> carExpences = new List<Expence>();
            List<Expence> clothesExpences = new List<Expence>();
            List<Expence> communicationsExpences = new List<Expence>();
            List<Expence> eatingOutExpences = new List<Expence>();
            List<Expence> entertainmentExpences = new List<Expence>();
            List<Expence> foodExpences = new List<Expence>();
            List<Expence> giftsExpences = new List<Expence>();
            List<Expence> healthExpences = new List<Expence>();
            List<Expence> houseExpences = new List<Expence>();
            List<Expence> petsExpences = new List<Expence>();
            List<Expence> sportsExpences = new List<Expence>();
            List<Expence> taxiExpences = new List<Expence>();
            List<Expence> toiletryExpences = new List<Expence>();
            List<Expence> transportExpences = new List<Expence>();

            allExpences.Add(carExpences);
            allExpences.Add(clothesExpences);
            allExpences.Add(communicationsExpences);
            allExpences.Add(eatingOutExpences);
            allExpences.Add(entertainmentExpences);
            allExpences.Add(foodExpences);
            allExpences.Add(giftsExpences);
            allExpences.Add(healthExpences);
            allExpences.Add(houseExpences);
            allExpences.Add(petsExpences);
            allExpences.Add(sportsExpences);
            allExpences.Add(taxiExpences);
            allExpences.Add(toiletryExpences);
            allExpences.Add(transportExpences);
        }


        #region Add Expence

        /* Add new mehtod for each new expence */


        public void AddCarExpence(double sum)
        {
            allExpences[0].Add(new CarExpence(sum));
        }


        public void AddClothesExpence(double sum)
        {
            allExpences[1].Add(new ClothesExpence(sum));
        }


        public void AddCommunicationExpence(double sum)
        {
            allExpences[2].Add(new CommunicationsExpence(sum));
        }


        public void AddEatingOutExpence(double sum)
        {
            allExpences[3].Add(new EatingOutExpence(sum));
        }


        public void AddEntertainmentExpence(double sum)
        {
            allExpences[4].Add(new EntertainmentExpence(sum));
        }


        public void AddFoodExpence(double sum)
        {
            allExpences[5].Add(new FoodExpence(sum));
        }


        public void AddGiftsExpence(double sum)
        {
            allExpences[6].Add(new GiftsExpence(sum));
        }


        public void AddHealthExpence(double sum)
        {
            allExpences[7].Add(new HealthExpence(sum));
        }


        public void AddHouseExpence(double sum)
        {
            allExpences[8].Add(new HouseExpence(sum));
        }


        public void AddPetsExpence(double sum)
        {
            allExpences[9].Add(new PetsExpence(sum));
        }


        public void AddSportsExpence(double sum)
        {
            allExpences[10].Add(new SportsExpence(sum));
        }


        public void AddTaxiExpence(double sum)
        {
            allExpences[11].Add(new TaxiExpence(sum));
        }


        public void AddToiletryExpence(double sum)
        {
            allExpences[12].Add(new ToiletryExpence(sum));
        }


        public void AddTransportExpence(double sum)
        {
            allExpences[13].Add(new TransportExpence(sum));
        }


        #endregion


        #region Get Expences for Provided Time Span


        /*
         
         Return order:
            -car
            -clothes
            -communication
            -eatingOut
            -entertainment
            -food
            -gifts
            -health
            -house
            -pets
            -sports
            -taxi
            -toiletry
            -transport
         */


        public List<double> GetAllExpences()
        {
            List<double> sums = new List<double>();
            double totalCount = 0;

            for (int i = 0; i < allExpences.Count; i++)
            {
                totalCount = 0;
                
                for (int j = 0; j < allExpences[i].Count; j++)
                {
                    totalCount += allExpences[i][j].TotalSum;
                }

                //MessageBox.Show($"{totalCount}");
                sums.Add(totalCount);
            }


            return sums;
        }


        public List<double> GetExpencesPerOneDay(DateTime day)
        {
            List<double> sums = new List<double>();

            // Default values
            for (int i = 0; i < allExpences.Count; i++)
            {
                sums.Add(0);
            }


            for (int i = 0; i < allExpences.Count; i++)
            {
                for (int j = 0; j < allExpences[i].Count; j++)
                {
                    if (allExpences[i][j].ExecutionDate.Day == day.Day && allExpences[i][j].ExecutionDate.Month == day.Month && allExpences[i][j].ExecutionDate.Year == day.Year)
                    {
                        sums[i] += allExpences[i][j].TotalSum;
                    }

                    else if ((allExpences[i][j].ExecutionDate.Year > day.Year) || (allExpences[i][j].ExecutionDate.Year == day.Year && allExpences[i][j].ExecutionDate.Month > day.Month) ||
                        (allExpences[i][j].ExecutionDate.Day > day.Day && allExpences[i][j].ExecutionDate.Month == day.Month && allExpences[i][j].ExecutionDate.Year == day.Year))
                    {
                        break;
                    }
                }
            } 

            return sums;
        }


        public List<double> GetExpencesForLatestWeek()
        {

            List<double> sums = new List<double>();

            // Default values
            for (int i = 0; i < allExpences.Count; i++)
            {
                sums.Add(0);
            }

            for (int i = 0; i < allExpences.Count; i++)
            {
                for (int j = 0; j < allExpences[i].Count; j++)
                {
                    if (DateTime.Now.Subtract(allExpences[i][j].ExecutionDate).TotalDays <= 7)
                    {
                        sums[i] += allExpences[i][j].TotalSum;
                    }
                    else if (DateTime.Now.DayOfYear - allExpences[i][j].ExecutionDate.DayOfYear > 7)
                    {
                        break;
                    }
                }
            }

            return sums;
        }


        public List<double> GetExpenceForLatestMonth()
        {
            List<double> sums = new List<double>();
            
            // Default values
            for (int i = 0; i < allExpences.Count; i++)
            {
                sums.Add(0);
            }

            for (int i = 0; i < allExpences.Count; i++)
            {
                for (int j = 0; j < allExpences[i].Count; j++)
                {
                    if (DateTime.Now.Month == allExpences[i][j].ExecutionDate.Month && DateTime.Now.Year == allExpences[i][j].ExecutionDate.Year)
                    {
                        sums[i] += allExpences[i][j].TotalSum;
                    }
                }
            }

            return sums;
        }



        public List<double> GetExpenceForLatestYear()
        {
            List<double> sums = new List<double>();

            // Default values
            for (int i = 0; i < allExpences.Count; i++)
            {
                sums.Add(0);
            }

            for (int i = 0; i < allExpences.Count; i++)
            {
                for (int j = 0; j < allExpences[i].Count; j++)
                {
                    if (DateTime.Now.Year == allExpences[i][j].ExecutionDate.Year)
                    {
                        sums[i] += allExpences[i][j].TotalSum;
                    }
                }
            }

            return sums;
        }

        #endregion


    }
}
