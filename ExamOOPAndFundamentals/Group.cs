using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class Group:SubjectInherits
    {
        public static int _id;
        public int ID { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public List<Student> Students = new List<Student>();
        
        public Group(string name,int limit)
        {
            _id++;
            ID = _id;
            Name = name;
            Limit = limit;
           
        

        }
        public void GetStudents()
        {
            foreach (Student student in Students)
            {
                Console.WriteLine(student.ToString());
            }
            
        }

        
    }
}
