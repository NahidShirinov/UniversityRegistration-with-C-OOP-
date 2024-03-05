using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class Teacher
    {
        public static int _id;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Profession { get; set; }

        public Teacher(string name, string lastname, string profession)
        {
            _id++;
            ID = _id;
            Name = name;
            Lastname = lastname;
            Profession = profession;
        }
        public override string ToString()
        {
            return ID+" "+Name + " " + Lastname;
        }
    }
}
