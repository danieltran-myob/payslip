using System;
using System.IO;
using System.Text;
namespace Payslip
{
    class GenerateSlip
    {
        public  string Name
        {get; set;}
        public  string Surname
        {get; set;}
        public  double AnnualSalary
        {get; set;}
        public  double SuperRate
        {get; set;}
        public  string PaymentStartDate
        {get; set;}
        public  string PaymentEndDate
        {get; set;}

        public  string PayPeriod()
        {
            return String.IsNullOrEmpty(PaymentEndDate) ? PaymentStartDate : $"{PaymentStartDate} - {PaymentEndDate}";
        }
        public  double GrossIncome()
        {
            return Math.Floor(AnnualSalary/12);
        }

        public  double IncomeTax()
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

        public  double NetIncome()
        {
            return GrossIncome() - IncomeTax();
        }

        public  double Super()
        {
            return Math.Floor(GrossIncome() * (SuperRate/100));
        }

        public  string PrintPaySlip()
        {
            return $"Name: {Name} {Surname} \nPay Period: {PayPeriod()} \nGross Income: {GrossIncome()} \nIncome Tax: {IncomeTax()} \nNet Income: {NetIncome()} \nSuper: {Super()} \n";
        }

        public void GenerateCsv()
        {
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine("name,pay period,gross income,income tax,net income,super");
                csvcontent.AppendLine($"{Name} {Surname},{PayPeriod()},{GrossIncome()},{IncomeTax()},{NetIncome()} , {Super()}");
                string csvPath = $"csvOutput/new.csv";
                File.AppendAllText(csvPath, csvcontent.ToString());
        }     
    }
}
