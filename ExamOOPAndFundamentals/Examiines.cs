using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class Examiines
    {
        private static int _id;
        public int ID { get; set; }
        public string SubjectName { get; set; }
        public ExamineType Type { get; set; }
        public int Score { get; set; }
        public Examiines(string subjectname,ExamineType type,int score)
        {
            _id++;
            ID = _id;
            SubjectName = subjectname;
            Type = type;
            Score = score;

        }

        }
    enum ExamineType
    {
        Midterm = 1,
        Presendation = 2,
        Quiz = 3,
        Final = 4
    }

    }

