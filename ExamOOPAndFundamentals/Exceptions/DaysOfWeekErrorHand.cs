using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals.Exceptions
{
    internal class DaysOfWeekErrorHand:Exception
    {
        public DaysOfWeekErrorHand(string message) : base(message)
        {
            
        }
    }
}
