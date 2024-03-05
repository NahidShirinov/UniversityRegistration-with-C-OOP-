using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class Student
    {

        public static int _id;
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }

        public List<Examiines> Examines { get; set; }= new List<Examiines>();
        public Student(string name,string lastname,string cardnumbr)
        {
            _id++;
            ID = _id;
            Name = name;
            LastName = lastname;
            CardNumber=cardnumbr;

        }

        public void GetExamines()
        {
            foreach(Examiines examiines in Examines) 
            {
                Console.WriteLine($"{examiines.Type} - {examiines.Score}");
            }
        }
        public override string ToString()
        {
            return ID+" "+Name + " " + LastName;
        }

    }
}
