using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class SubjectInherits
    {
        public List<Subject> Subjects = new List<Subject>();
        public void GetSubject()
        {
            foreach (Subject sub in Subjects)
            {
                Console.WriteLine(sub.ToString());
            }
        }
    }
}
