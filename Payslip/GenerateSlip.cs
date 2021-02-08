using System;
using System.IO;
using System.Collections.Generic;
namespace Payslip
{
    static class GenerateSlip
    {
        public static string Name
        {get; set;}
        public static string Surname
        {get; set;}
        public static double AnnualSalary
        {get; set;}
        public static double SuperRate
        {get; set;}
        public static string PaymentStartDate
        {get; set;}
        public static string PaymentEndDate
        {get; set;}

        public static string PayPeriod()
        {
            return String.IsNullOrEmpty(PaymentEndDate) ? PaymentStartDate : $"{PaymentStartDate} - {PaymentEndDate}";
        }
        public static double GrossIncome()
        {
            return Math.Floor(AnnualSalary/12);
        }

        public static double IncomeTax()
        {
            if(AnnualSalary <= 18200)
            {
                return 0;
            } else if (AnnualSalary > 18200 && AnnualSalary <= 37000) {
                return Math.Ceiling(((AnnualSalary - 18200) * 0.19) / 12); 
            } else if (AnnualSalary > 37000 && AnnualSalary <= 87000) {
                return Math.Ceiling((3572 + (AnnualSalary - 37000) * 0.325) / 12);
            } else if (AnnualSalary > 87000 && AnnualSalary <= 180000) {
                return Math.Ceiling((19822 + (AnnualSalary - 87000) * 0.37) / 12);
            } else {
                return Math.Ceiling((54232 + (AnnualSalary - 180000) * 0.45) / 12);
            }
        }

        public static double NetIncome()
        {
            return GrossIncome() - IncomeTax();
        }

        public static double Super()
        {
            return Math.Floor(GrossIncome() * (SuperRate/100));
        }

        public static string PrintPaySlip()
        {
            return $"Name: {Name} {Surname} \nPay Period: {PayPeriod()} \nGross Income: {GrossIncome()} \nIncome Tax: {IncomeTax()} \nNet Income: {NetIncome()} \nSuper: {Super()} \n";
        }
    }
}
