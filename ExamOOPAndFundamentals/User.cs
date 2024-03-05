using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class User
    {
        public static int _id;
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool Islogged { get; set; } = false;


        public User(string username,bool isadmin)
        {
            _id++;
           ID = _id;
            Username = username;
            Password = "123";
            IsAdmin = isadmin;
        }
    }
}
