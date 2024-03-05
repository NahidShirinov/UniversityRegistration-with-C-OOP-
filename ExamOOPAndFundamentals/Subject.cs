using ExamOOPAndFundamentals.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOPAndFundamentals
{
    internal class Subject
    {
        public static int _id;

        public int ID { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public int DaysOfWeek { get; set; }
        


        public Subject(string name,int credit,int daysofweek)
        {
            _id++;
            ID = _id;
            Name = name;
            Credit = credit;
            if (credit > 7)
            {
                throw new CreditErrorHandler("Fenn krediti 7 den artiq ola bilmez");
            }
            DaysOfWeek = daysofweek;
            if (daysofweek > 5)
            {
                throw new DaysOfWeekErrorHand("Ders heftede 5 gunden artiq kecirile bilmez");
            }
            
        }
        public override string ToString()
        {
            return $"Fennin Id: {ID} \n Fennin adi: {Name} \n Fennin gun sayi: {DaysOfWeek} \n Fennin krediti: {Credit}"; 
        }
    }
}
