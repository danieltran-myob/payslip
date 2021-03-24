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
        public List<string> EmployeePaySlip = new List<string>();

        public void UserInput()
        {
            Console.Write("Please enter the csv file you would like to upload.  ");
                string csvFile = Console.ReadLine();
                using(var reader = new StreamReader($"csv/{csvFile}"))
                {
                    var firstNameList = new List<string>();
                    var lastNameList = new List<string>();
                    var annualSalaryList = new List<string>();
                    var superRateList = new List<string>();
                    var paymentStartDateList = new List<string>();
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
                        
                        EmployeePaySlip.Add($"{Name} {Surname},{PayPeriod()},{GrossIncome()},{IncomeTax()},{NetIncome()} , {Super()}");
                    }
                }
                GenerateCsv();
        }

        public void GenerateCsv()
        {
            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
            string csvPath = $"csvOutput/new.csv";
            foreach(string emplpoyee in EmployeePaySlip)
            {
                csvcontent.AppendLine(emplpoyee);
            }
            File.AppendAllText(csvPath, csvcontent.ToString());
        }
    }
}

