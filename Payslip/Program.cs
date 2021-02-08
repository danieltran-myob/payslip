using System;
using System.IO;
using System.Collections.Generic;

namespace Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateSlip generateSlip = new GenerateSlip();

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
                        generateSlip.Name = firstNameArr[i];
                        generateSlip.Surname = lastNameArr[i];
                        generateSlip.AnnualSalary = Convert.ToDouble(annualSalaryArr[i]);
                        generateSlip.SuperRate = Convert.ToDouble(superRateArr[i].Replace("%",""));
                        generateSlip.PaymentStartDate = paymentStartDateArr[i];

                        Console.WriteLine(generateSlip.PrintPaySlip());
                    }
                    
                }
            } else if (answer == "NO") {
            Console.Write("Please input your name:  ");
            generateSlip.Name = Console.ReadLine();
            Console.Write("Please input your surname:  ");
            generateSlip.Surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:  ");
            generateSlip.AnnualSalary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your super rate:  ");
            generateSlip.SuperRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your payment start date:  ");
            generateSlip.PaymentStartDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:  ");
            generateSlip.PaymentEndDate = Console.ReadLine();
            Console.WriteLine(" \n Your payslip has been generated: \n");

            Console.WriteLine(generateSlip.PrintPaySlip());
            } else {
                Console.WriteLine("Answer is invalid");
            }
        }
    }
}
