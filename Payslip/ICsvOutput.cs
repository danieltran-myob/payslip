using System;

namespace Payslip
{
    /// <summary>
    /// Method creates a csv output for the payslip
    /// </summary>
    interface ICsvOutput
    {
        void GenerateCsv();
    }
}
