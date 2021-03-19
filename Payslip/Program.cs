using System;

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
                var uploadCsvFile = new UploadCsv();
                uploadCsvFile.UserInput();

            } 
            else if (answer == "NO") 
            {
                var manualEntry = new ManualInput();
                manualEntry.UserInput();
            }
            else 
            {
                Console.WriteLine("Answer is invalid");
            }
        }
    }
}
