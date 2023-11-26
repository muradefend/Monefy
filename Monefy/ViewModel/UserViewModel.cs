using Monefy.Model;
using Monefy.Model.Expences;
using Monefy.Model.Holders;
using Monefy.Services;
using Monefy.Services.CommandDelegates;
using Monefy.Services.FileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monefy.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IFileService _fileService;

        User user = new User();

        public List<double> allExpences { get; set; } = new List<double>();
        public List<double> allIncomes { get; set; } = new List<double>();



        public UserViewModel(IFileService fileService)
        {
            _fileService = fileService;
            TotalExpencePerCategory = new List<double>();
            TotalIncomePerCategory = new List<double>();

            if (File.Exists("expences.xml"))
            {
                user.ExpencesHolder.allExpences = _fileService.LoadExpences("expences.xml");
            }

            if (File.Exists("incomes.xml"))
            {
                user.IncomesHolder.allIncomes = _fileService.LoadIncomes("incomes.xml");
            }

            SetListForAllPeriods();
            SetPercentagesExpences();
            SetTotalIncome();

            Balance = (Double.Parse(TotalIncome) - Double.Parse(TotalExpence)).ToString();

            allExpences = user.ExpencesHolder.GetAllExpences();
            allIncomes = user.IncomesHolder.GetAllIncome();
        }




        #region Expences Properties


        private string carExpencePercentage;
        public string CarExpencePercentage 
        { 
            get => carExpencePercentage; 
            set
            {
                carExpencePercentage = value;
                OnPropertyChanged(nameof(CarExpencePercentage));
            }
        }

        private string clothesExpencePercentage;
        public string ClothesExpencePercentage 
        { 
            get => clothesExpencePercentage;
            set
            {
                clothesExpencePercentage = value;
                OnPropertyChanged(nameof(ClothesExpencePercentage));
            } 
        }

        private string communicationExpencePercentage;
        public string CommunicationExpencePercentage
        {
            get => communicationExpencePercentage;
            set
            {
                communicationExpencePercentage = value;
                OnPropertyChanged(nameof(CommunicationExpencePercentage));
            }
        }

        private string eatingOutExpencePercentage;
        public string EatingOutExpencePercentage 
        { 
            get => eatingOutExpencePercentage;
            set
            {
                eatingOutExpencePercentage = value;
                OnPropertyChanged(nameof(EatingOutExpencePercentage));
            } 
        }

        private string entertainmentExpencePercentage;
        public string EntertainmentExpencePercentage
        {
            get => entertainmentExpencePercentage;
            set
            {
                entertainmentExpencePercentage = value;
                OnPropertyChanged(nameof(EntertainmentExpencePercentage));
            }
        }

        private string foodExpencePercentage;
        public string FoodExpencePercentage
        {
            get => foodExpencePercentage;
            set
            {
                foodExpencePercentage = value;
                OnPropertyChanged(nameof(FoodExpencePercentage));
            }
        }

        private string giftsExpencePercentage;
        public string GiftsExpencePercentage
        {
            get => giftsExpencePercentage;
            set
            {
                giftsExpencePercentage = value;
                OnPropertyChanged(nameof(GiftsExpencePercentage));
            }
        }

        private string healthExpencePercentage;
        public string HealthExpencePercentage
        {
            get => healthExpencePercentage;
            set
            {
                healthExpencePercentage = value;
                OnPropertyChanged(nameof(HealthExpencePercentage));
            }
        }

        private string houseExpencePercentage;
        public string HouseExpencePercentage
        {
            get => houseExpencePercentage;
            set
            {
                houseExpencePercentage = value;
                OnPropertyChanged(nameof(HouseExpencePercentage));
            }
        }

        private string petsExpencePercentage;
        public string PetsExpencePercentage
        {
            get => petsExpencePercentage;
            set
            {
                petsExpencePercentage = value;
                OnPropertyChanged(nameof(PetsExpencePercentage));
            }
        }

        private string sportsExpencePercentage;
        public string SportsExpencePercentage
        {
            get => sportsExpencePercentage;
            set
            {
                sportsExpencePercentage = value;
                OnPropertyChanged(nameof(SportsExpencePercentage));
            }
        }

        private string taxiExpencePercentage;
        public string TaxiExpencePercentage
        {
            get => taxiExpencePercentage;
            set
            {
                taxiExpencePercentage = value;
                OnPropertyChanged(nameof(TaxiExpencePercentage));
            }
        }

        private string toietryExpencePercentage;
        public string ToietryExpencePercentage
        {
            get => toietryExpencePercentage;
            set
            {
                toietryExpencePercentage = value;
                OnPropertyChanged(nameof(ToietryExpencePercentage));
               // MessageBox.Show($"{toietryExpencePercentage}");
            }
        }

        private string transportExpencePercentage;
        public string TransportExpencePercentage
        {
            get => transportExpencePercentage;
            set
            {
                transportExpencePercentage = value;
                OnPropertyChanged(nameof(TransportExpencePercentage));
            }
        }


        #endregion



        private string totalExpence;
        public string TotalExpence
        {
            get => totalExpence;
            set
            {
                totalExpence = value;
                OnPropertyChanged(nameof(TotalExpence));
            }
        }


        

        public List<double> TotalExpencePerCategory { get; set; }




        private string totalIncome;
        public string TotalIncome
        {
            get => totalIncome; 
            set 
            { 
                totalIncome = value;
                OnPropertyChanged(nameof(TotalIncome));
            }
        }


        public List<double> TotalIncomePerCategory { get; set; }


        private string balance;
        public string Balance
        {
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        




        // Used to identify amount of money to add
        private string selectedSum;
        public string SelectedSum
        {
            get => selectedSum;
            set
            {
                selectedSum = value;
                OnPropertyChanged(nameof(SelectedSum));
            }
        }



        public void SaveUserExpences()
        {
            _fileService.SaveExpences("expences.xml", user.ExpencesHolder.allExpences);
        }

        public void SaveUserIncomes()
        {
            _fileService.SaveIncomes("incomes.xml", user.IncomesHolder.allIncomes);
        }


        #region Adding Expence Commands


        private Command _addCarExpenceCommand;
        public Command AddCarExpenceCommand
        {
            get
            {
                return _addCarExpenceCommand ?? (_addCarExpenceCommand = new DelegateCommand(obj =>
                    {
                        if (!String.IsNullOrEmpty(SelectedSum)) { user.ExpencesHolder.AddCarExpence(Double.Parse(SelectedSum)); Balance = ( Double.Parse(Balance) - Double.Parse( SelectedSum )).ToString(); }
                    }));
            }
        }


        private Command _addClothesExpenceCommand;
        public Command AddClothesExpenceCommand
        {
            get
            {
                return _addClothesExpenceCommand ?? (_addClothesExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddClothesExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addCommunicacionsExpenceCommand;
        public Command AddCommunicacionsExpenceCommand
        {
            get
            {
                return _addCommunicacionsExpenceCommand ?? (_addCommunicacionsExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) { user.ExpencesHolder.AddCommunicationExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addEatingOutExpenceCommand;
        public Command AddEatingOutExpenceCommand
        {
            get
            {
                return _addEatingOutExpenceCommand ?? (_addEatingOutExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddEatingOutExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addEntertainmentExpenceCommand;
        public Command AddEntertainmentExpenceCommand
        {
            get
            {
                return _addEntertainmentExpenceCommand ?? (_addEntertainmentExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddEntertainmentExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addFoodExpenceCommand;
        public Command AddFoodExpenceCommand
        {
            get
            {
                return _addFoodExpenceCommand ?? (_addFoodExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddFoodExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addGiftsExpenceCommand;
        public Command AddGiftsExpenceCommand
        {
            get
            {
                return _addGiftsExpenceCommand ?? (_addGiftsExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddGiftsExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }



        private Command _addHealthExpenceCommand;
        public Command AddHealthExpenceCommand
        {
            get
            {
                return _addHealthExpenceCommand ?? (_addHealthExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) { user.ExpencesHolder.AddHealthExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addHouseExpenceCommand;
        public Command AddHouseExpenceCommand
        {
            get
            {
                return _addHouseExpenceCommand ?? (_addHouseExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddHouseExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addPetsExpenceCommand;
        public Command AddPetsExpenceCommand
        {
            get
            {
                return _addPetsExpenceCommand ?? (_addPetsExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddPetsExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addSportsExpenceCommand;
        public Command AddSportsExpenceCommand
        {
            get
            {
                return _addSportsExpenceCommand ?? (_addSportsExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddSportsExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }



        private Command _addTaxiExpenceCommand;
        public Command AddTaxiExpenceCommand
        {
            get
            {
                return _addTaxiExpenceCommand ?? (_addTaxiExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddTaxiExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addToiletryExpenceCommand;
        public Command AddToiletryExpenceCommand
        {
            get
            {
                return _addToiletryExpenceCommand ?? (_addToiletryExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddToiletryExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addTransportExpenceCommand;
        public Command AddTransportExpenceCommand
        {
            get
            {
                return _addTransportExpenceCommand ?? (_addTransportExpenceCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.ExpencesHolder.AddTransportExpence(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) - Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        #endregion


        #region Adding Income Commands

        private Command _addDepositIncomeCommand;
        public Command AddDepositIncomeCommand
        {
            get
            {
                return _addDepositIncomeCommand ?? (_addDepositIncomeCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.IncomesHolder.AddDepositIncome(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) + Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addsalaryIncomeCommand;
        public Command AddSalaryIncomeCommand
        {
            get
            {
                return _addsalaryIncomeCommand ?? (_addsalaryIncomeCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) { user.IncomesHolder.AddSalaryIncome(Double.Parse(SelectedSum));  Balance = (Double.Parse(Balance) + Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }


        private Command _addSavingsIncomeCommand;
        public Command AddSavingsIncomeCommand
        {
            get
            {
                return _addSavingsIncomeCommand ?? (_addSavingsIncomeCommand = new DelegateCommand(obj =>
                {
                    if (!String.IsNullOrEmpty(SelectedSum)) {user.IncomesHolder.AddSavingsIncome(Double.Parse(SelectedSum)); Balance = (Double.Parse(Balance) + Double.Parse(SelectedSum)).ToString(); }
                }));
            }
        }

        #endregion



        #region Choosing Time Interval Commands


        // gets Expences for all working period
        private Command _allIntervalCommand;
        public Command AllIntervalCommand
        {
            get
            {
                return _allIntervalCommand ?? (_allIntervalCommand = new DelegateCommand(obj =>
                {
                    SetListForAllPeriods();
                    SetPercentagesExpences();
                    SetTotalIncome();
                    }));
            }
        }


        // gets Expences for a provided day
        private Command _dayCommand;
        public Command DayCommand
        {
            get
            {
                return _dayCommand ?? (_dayCommand = new DelegateCommand(obj =>
                {
                    SetListForDay();
                    SetPercentagesExpences();
                    SetTotalIncome();
                }));
            }
        }


        // gets Expences for last week
        private Command _weekCommand;
        public Command WeekCommand
        {
            get
            {
                return _weekCommand ?? (_weekCommand = new DelegateCommand(obj =>
                {
                    SetListForLatestWeek();
                    SetPercentagesExpences();
                    SetTotalIncome();
                }));
            }
        }


        // gets Expences for last month
        private Command _monthCommand;
        public Command MonthCommand
        {
            get
            {
                return _monthCommand ?? (_monthCommand = new DelegateCommand(obj =>
                {
                    SetListForLatestMonth();
                    SetPercentagesExpences();
                    SetTotalIncome();
                }));
            }
        }


        // gets Expences for last year
        private Command _yearCommand;
        public Command YearCommand
        {
            get
            {
                return _yearCommand ?? (_yearCommand = new DelegateCommand(obj =>
                {
                    SetListForLatestYear();
                    SetPercentagesExpences();
                    SetTotalIncome();
                }));
            }
        }




        private DateTime chosenDate;
        public DateTime ChosenDate
        {
            get => chosenDate;
            set
            {
                chosenDate = value;
                OnPropertyChanged(nameof(ChosenDate));
            }

        }


        private Command _chosenDateCommand;
        public Command ChosenDateCommand
        {
            get
            {
                return _chosenDateCommand ?? (_chosenDateCommand = new DelegateCommand(obj =>
                {
                    SetListForDay(ChosenDate);
                    SetPercentagesExpences();
                    SetTotalIncome();
                }));
            }
        }



        #region Setting TotalExpencePerCategory and TotalIncomePerCategory For Chosen Time Interval



        private void SetListForDay()
        {
            TotalExpencePerCategory = user.ExpencesHolder.GetExpencesPerOneDay(DateTime.Now);
            TotalIncomePerCategory = user.IncomesHolder.GetIncomesPerOneDay(DateTime.Now);
        }

        private void SetListForDay(DateTime d)
        {
            TotalExpencePerCategory = user.ExpencesHolder.GetExpencesPerOneDay(d);
            TotalIncomePerCategory = user.IncomesHolder.GetIncomesPerOneDay(d);
        }

        private void SetListForLatestWeek()
        {
            TotalExpencePerCategory = user.ExpencesHolder.GetExpencesForLatestWeek();
            TotalIncomePerCategory = user.IncomesHolder.GetIncomesForLatestWeek();
        }

        private void SetListForLatestMonth()
        {
            TotalExpencePerCategory = user.ExpencesHolder.GetExpenceForLatestMonth();
            TotalIncomePerCategory = user.IncomesHolder.GetIncomesForLatestMonth();
        }

        private void SetListForLatestYear()
        {
            TotalExpencePerCategory = user.ExpencesHolder.GetExpenceForLatestYear();
            TotalIncomePerCategory = user.IncomesHolder.GetIncomesForLatestYear();
        }

        private void SetListForAllPeriods()
        {

            TotalExpencePerCategory = user.ExpencesHolder.GetAllExpences();
            TotalIncomePerCategory = user.IncomesHolder.GetAllIncome();
        }


        #endregion




        #endregion



        // Sets expence percentage for all expences taken from TotalExpencePerCategory
        // Should be manually modified when adding new type of Expence
        private void SetPercentagesExpences()
        {
            try
            {
                double overallExpence = 0;

                for (int i = 0; i < TotalExpencePerCategory.Count; i++)
                {
                    overallExpence += TotalExpencePerCategory[i];
                }


                CarExpencePercentage = ( Math.Round((TotalExpencePerCategory[0] / overallExpence), 2) * 100).ToString() + "%";
                ClothesExpencePercentage = (Math.Round((TotalExpencePerCategory[1] / overallExpence), 2) * 100).ToString() + "%";
                CommunicationExpencePercentage = (Math.Round((TotalExpencePerCategory[2] / overallExpence), 2) * 100).ToString() + "%";
                EatingOutExpencePercentage = (Math.Round((TotalExpencePerCategory[3] / overallExpence), 2) * 100).ToString() + "%";
                EntertainmentExpencePercentage = (Math.Round((TotalExpencePerCategory[4] / overallExpence), 2) * 100).ToString() + "%";
                FoodExpencePercentage = (Math.Round((TotalExpencePerCategory[5] / overallExpence), 2) * 100).ToString() + "%";
                GiftsExpencePercentage = (Math.Round((TotalExpencePerCategory[6] / overallExpence), 2) * 100).ToString() + "%";
                HealthExpencePercentage = (Math.Round((TotalExpencePerCategory[7] / overallExpence), 2) * 100).ToString() + "%";
                HouseExpencePercentage = (Math.Round((TotalExpencePerCategory[8] / overallExpence), 2) * 100).ToString() + "%";
                PetsExpencePercentage = (Math.Round((TotalExpencePerCategory[9] / overallExpence), 2) * 100).ToString() + "%";
                SportsExpencePercentage = (Math.Round((TotalExpencePerCategory[10] / overallExpence), 2) * 100).ToString() + "%";
                TaxiExpencePercentage = (Math.Round((TotalExpencePerCategory[11] / overallExpence), 2) * 100).ToString() + "%";
                ToietryExpencePercentage = (Math.Round((TotalExpencePerCategory[12] / overallExpence), 2) * 100).ToString() + "%";
                TransportExpencePercentage = (Math.Round((TotalExpencePerCategory[13] / overallExpence), 2) * 100).ToString() + "%";

                if ( CarExpencePercentage == "NaN%" || CarExpencePercentage == "0%") CarExpencePercentage = String.Empty;
                if (ClothesExpencePercentage == "NaN%" || ClothesExpencePercentage == "0%") ClothesExpencePercentage = String.Empty;
                if (CommunicationExpencePercentage == "NaN%" || CommunicationExpencePercentage == "0%") CommunicationExpencePercentage = String.Empty;
                if (EatingOutExpencePercentage == "NaN%" || EatingOutExpencePercentage == "0%") EatingOutExpencePercentage = String.Empty;
                if (EntertainmentExpencePercentage == "NaN%" || EntertainmentExpencePercentage == "0%") EntertainmentExpencePercentage = String.Empty;
                if (FoodExpencePercentage == "NaN%" || FoodExpencePercentage == "0%") FoodExpencePercentage = String.Empty;
                if (GiftsExpencePercentage == "NaN%" || GiftsExpencePercentage == "0%") GiftsExpencePercentage = String.Empty;
                if (HealthExpencePercentage == "NaN%" || HealthExpencePercentage == "0%") HealthExpencePercentage = String.Empty;
                if (HouseExpencePercentage == "NaN%" || HouseExpencePercentage == "0%") HouseExpencePercentage = String.Empty;
                if (PetsExpencePercentage == "NaN%" || PetsExpencePercentage == "0%") PetsExpencePercentage = String.Empty;
                if (SportsExpencePercentage == "NaN%" || SportsExpencePercentage == "0%") SportsExpencePercentage = String.Empty;
                if (TaxiExpencePercentage == "NaN%" || TaxiExpencePercentage == "0%") TaxiExpencePercentage = String.Empty;
                if (ToietryExpencePercentage == "NaN%" || ToietryExpencePercentage == "0%") ToietryExpencePercentage = String.Empty;
                if (TransportExpencePercentage == "NaN%" || TransportExpencePercentage == "0%") TransportExpencePercentage = String.Empty;


                TotalExpence = overallExpence.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetTotalIncome()
        {
            try
            {
                double income = 0;

                for (int i = 0; i < TotalIncomePerCategory.Count; i++)
                {
                    income += TotalIncomePerCategory[i];
                }

                TotalIncome = income.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Message: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
