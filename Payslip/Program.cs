using System;
using System.IO;
using System.Collections.Generic;

namespace Payslip
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the payslip generator!");
            
            Console.Write("Would you like to upload a csv file? Please answer YES/NO    ");
            string answer = Console.ReadLine().ToUpper();
            if(answer == "YES")
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
                    // Console.WriteLine(firstNameCsv[2]);
                    // Console.WriteLine(lastNameCsv[2]);
                    string[] firstNameArr = firstNameList.ToArray();
                    string[] lastNameArr = lastNameList.ToArray();
                    string[] annualSalaryArr = annualSalaryList.ToArray();
                    string[] superRateArr = superRateList.ToArray();
                    string[] paymentStartDateArr = paymentStartDateList.ToArray();
                    
                    for (int i = 1; i < firstNameArr.Length; i++)
                    {
                        GenerateSlip.Name = firstNameArr[i];
                        GenerateSlip.Surname = lastNameArr[i];
                        GenerateSlip.AnnualSalary = Convert.ToDouble(annualSalaryArr[i]);
                        GenerateSlip.SuperRate = Convert.ToDouble(superRateArr[i].Replace("%",""));
                        GenerateSlip.PaymentStartDate = paymentStartDateArr[i];

                        Console.WriteLine(GenerateSlip.PrintPaySlip());
                        String.IsNullOrEmpty(GenerateSlip.PaymentEndDate);
                    }
                    
                }
            } else if (answer == "NO") {
            Console.Write("Please input your name:  ");
            GenerateSlip.Name = Console.ReadLine();
            Console.Write("Please input your surname:  ");
            GenerateSlip.Surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:  ");
            GenerateSlip.AnnualSalary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your super rate:  ");
            GenerateSlip.SuperRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your payment start date:  ");
            GenerateSlip.PaymentStartDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:  ");
            GenerateSlip.PaymentEndDate = Console.ReadLine();
            Console.WriteLine(" \n Your payslip has been generated: \n");

            Console.WriteLine(GenerateSlip.PrintPaySlip());
            } else {
                Console.WriteLine("Answer is invalid");
            }
        }
    }
}
