using System;

namespace Payslip
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the payslip generator!");
            
            Console.Write("Would you like to upload a csv file? Please answer YES/NO    ");
            var answer = Console.ReadLine().ToUpper();
            switch (answer)
            {
                case "YES":
                {
                    var uploadCsvFile = new UploadCsv();
                    uploadCsvFile.UserInput();
                    break;
                }
                case "NO":
                {
                    var manualEntry = new ManualInput();
                    manualEntry.UserInput();
                    break;
                }
                default:
                    Console.WriteLine("Answer is invalid");
                    break;
            }
        }
    }
}
