using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace Payslip
{
    /// <summary>
    /// Class inherits from GenerateSlip class.
    /// </summary>
    class UploadCsv : GenerateSlip, IUserInput, ICsvOutput
    {
        public List<string> firstNameList;
        public List<string> FirstNameList
        {
            get { return firstNameList;}
            set { firstNameList = new List<string>(); }
        }
        public List<string> lastNameList;
        public List<string> LastNameList
        {
            get { return lastNameList;}
            set { lastNameList = new List<string>(); }
        }
        public List<string> annualSalaryList;
        public List<string> AnnualSalaryList
        {
            get { return annualSalaryList;}
            set { annualSalaryList = new List<string>(); }
        }
        public List<string> superRateList;
        public List<string> SuperRateList
        {
            get { return superRateList;}
            set { superRateList = new List<string>(); }
        }
        public List<string> paymentStartDateList;
        public List<string> PaymentStartDateList
        {
            get { return firstNameList;}
            set { firstNameList = new List<string>(); }
        }
        public void UserInput()
        {
            Console.Write("Please enter the csv file you would like to upload.  ");
                string csvFile = Console.ReadLine();
                using(var reader = new StreamReader($"csv/{csvFile}"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        firstNameList.Add(values[0]);
                        lastNameList.Add(values[1]);
                        annualSalaryList.Add(values[2]);
                        superRateList.Add(values[3]);
                        paymentStartDateList.Add(values[4]);
                    }
                    

                    for (int i = 1; i < firstNameList.Count; i++)
                    {
                        Name = firstNameList[i];
                        Surname = lastNameList[i];
                        AnnualSalary = Convert.ToDouble(annualSalaryList[i]);
                        SuperRate = Convert.ToDouble(superRateList[i].Replace("%",""));
                        PaymentStartDate = paymentStartDateList[i];

                        Console.WriteLine(PrintPaySlip());
                        // GenerateCsv();
                    }
                }
        }

        public void GenerateCsv()
        {
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine($"{Name} {Surname},{PayPeriod()},{GrossIncome()},{IncomeTax()},{NetIncome()} , {Super()}");
            string csvPath = $"csvOutput/new.csv";
            File.AppendAllText(csvPath, csvcontent.ToString());
        }
    }
}

