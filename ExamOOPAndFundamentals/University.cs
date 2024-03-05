using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class University:SubjectInherits
    {
        public static int _id;
        public int ID { get; set; }
        public string Name { get; set; }
        public int EstabilishedYear { get; set; }

       public List<User> Users = new List<User>()
        {
            new User("nahid50",true)
        };

        public List<Teacher> Teachers = new List<Teacher>();
        public List<Group> Groups = new List<Group>();
        
        //public List<Subject> Subjects = new List<Subject>();
        public University(string name,int Year)
        {
            _id++;
            ID = _id;
            Name = name;
            EstabilishedYear= Year;

           

        }

        public string Fullinfo()
        {
            return Name + " " + EstabilishedYear;
        } 

        public void GetGroups()
        {
            foreach(Group group in Groups) 
            {
                Console.WriteLine(group.ID + " " + group.Name);
            }
           
        }
        public void GetTeachers()
        {
            foreach(Teacher t in Teachers)
            {
                Console.WriteLine(t.ToString());
            }
        }

       

    }
}
