using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Payslip
{
    class Program
    {
        static StringBuilder csvcontent = new StringBuilder();
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the payslip generator!");
            
            Console.Write("Would you like to upload a csv file? Please answer YES/NO    ");
            string answer = Console.ReadLine().ToUpper();
            if(answer == "YES")
            {
                useCsv();
            } else if (answer == "NO") {
                manualInput();
            } else {
                Console.WriteLine("Answer is invalid");
            }
        }

        static void useCsv()
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
                    
                    csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");

                    for (int i = 1; i < firstNameList.Count; i++)
                    {
                        GenerateSlip.Name = firstNameList[i];
                        GenerateSlip.Surname = lastNameList[i];
                        GenerateSlip.AnnualSalary = Convert.ToDouble(annualSalaryList[i]);
                        GenerateSlip.SuperRate = Convert.ToDouble(superRateList[i].Replace("%",""));
                        GenerateSlip.PaymentStartDate = paymentStartDateList[i];

                        Console.WriteLine(GenerateSlip.PrintPaySlip());
                        csvcontent.AppendLine($"{GenerateSlip.Name} {GenerateSlip.Surname},{GenerateSlip.PayPeriod()},{GenerateSlip.GrossIncome()},{GenerateSlip.IncomeTax()},{GenerateSlip.NetIncome()} , {GenerateSlip.Super()}");
                        
                        
                        // generateCsv();
                    }
                    string csvPath = $"csvOutput/new.csv";
                    File.AppendAllText(csvPath, csvcontent.ToString());
                }
        }
        static void manualInput()
        {
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
            // generateCsv();

            csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
            csvcontent.AppendLine($"{GenerateSlip.Name} {GenerateSlip.Surname},{GenerateSlip.PayPeriod()},{GenerateSlip.GrossIncome()},{GenerateSlip.IncomeTax()},{GenerateSlip.NetIncome()} , {GenerateSlip.Super()}");
            string csvPath = $"csvOutput/new.csv";
            File.AppendAllText(csvPath, csvcontent.ToString());
        }

        // static void generateCsv()
        // {
        //     csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
        //     csvcontent.AppendLine($"{GenerateSlip.Name} {GenerateSlip.Surname},{GenerateSlip.PayPeriod()},{GenerateSlip.GrossIncome()},{GenerateSlip.IncomeTax()},{GenerateSlip.NetIncome()} , {GenerateSlip.Super()}");
        //     string csvPath = $"csvOutput/new.csv";
        //     File.AppendAllText(csvPath, csvcontent.ToString());
        // }
    }
}
