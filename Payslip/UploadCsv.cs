using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace Payslip
{
    class UploadCsv : GenerateSlip
    {
        public void Upload()
        {
            Console.Write("Please enter the csv file you would like to upload.  ");
                string csvFile = Console.ReadLine();
                using(var reader = new StreamReader($"csv/{csvFile}"))
                {
                    List<string> firstNameList = new List<string>();
                    List<string> lastNameList = new List<string>();
                    List<string> annualSalaryList = new List<string>();
                    List<string> superRateList = new List<string>();
                    List<string> paymentStartDateList = new List<string>();
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
    }
}
