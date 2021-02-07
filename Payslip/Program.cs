using System;

namespace Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateSlip generateSlip = new GenerateSlip();

            Console.WriteLine("Welcome to the payslip generator!");

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
        }
    }
}
