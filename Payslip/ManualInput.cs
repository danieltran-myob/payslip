using System;

namespace Payslip
{
    /// <summary>
    /// Class is inherits from GenerateSlip class
    /// </summary>
    class ManualInput : GenerateSlip
    {
        public void Manual()
        {

            Console.Write("Please input your name:  ");
            Name = Console.ReadLine();
            Console.Write("Please input your surname:  ");
            Surname = Console.ReadLine();
            Console.Write("Please enter your annual salary:  ");
            AnnualSalary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your super rate:  ");
            SuperRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter your payment start date:  ");
            PaymentStartDate = Console.ReadLine();
            Console.Write("Please enter your payment end date:  ");
            PaymentEndDate = Console.ReadLine();
            Console.WriteLine(" \n Your payslip has been generated: \n");

            Console.WriteLine(PrintPaySlip());
            GenerateCsv();
        }
    }


}
