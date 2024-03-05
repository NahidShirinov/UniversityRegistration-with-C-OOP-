using ExamOOPAndFundamentals.Exceptions;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace ExamOOPAndFundamentals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University university=new University("ADNSU",1920);
            int result = LoginPanel();
            while(result!=0)
            {
                switch (result)
                {
                    case 1:

                        Console.WriteLine("Istifadeci adini daxil edin: ");
                        string username=Console.ReadLine();
                        Console.WriteLine("Parolunuzu daxil edin: ");
                        string Password=Console.ReadLine();
                        

                        User user=university.Users.Find(x => x.Username == username);
                        if (user ==null || user.Password != Password)
                        {
                            Console.WriteLine("Bele istifadeci sistemde yoxdur,Parol ve ya ad Yalnisdir");
                            break;
                        }
                        else
                        {
                            if (user.Password == Password)
                            {
                                user.Islogged = true;
                            }
                           
                            result = Getselects();
                            
                        }
                        
                        while(result!=0)
                        {
                            switch (result)
                            {
                                case 1:
                                    Console.WriteLine("Telebenin adini daxil edin: ");
                                    string Firstname = Console.ReadLine();
                                    Console.WriteLine("Telebenin soyadini daxil edin: ");
                                    string Lastname = Console.ReadLine();
                                    Console.WriteLine("Telebenin kart nomresini daxil edin: ");
                                    string Cardnum = Console.ReadLine();
                                    university.GetGroups();
                                    Console.WriteLine("Qrupun nomresini secin: ");
                                    int GroupNo=int.Parse(Console.ReadLine());
                                    university.GetGroups();
                                    Group gr1 = university.Groups.Find(x => x.ID == GroupNo);
                                    while (gr1 == null)
                                    {
                                        Console.WriteLine("Bele qrup yoxdur ");
                                        GroupNo = int.Parse(Console.ReadLine());
                                        gr1 = university.Groups.Find(x => x.ID == GroupNo);
                                    }
                                    Student student = new Student(Firstname, Lastname, Cardnum);
                                    if (gr1.Limit > gr1.Students.Count())
                                    {

                                    gr1.Students.Add(student);
                                    Console.WriteLine(" Telebe elave olundu");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Limitden cox telebe daxil etmek olmaz");
                                    }
                                    gr1.GetStudents();


                                   

                                    break;
                                case 2:
                                    Console.WriteLine(" Muellimin adini daxil edin: ");
                                    string teachname = Console.ReadLine();
                                    Console.WriteLine("Muellimin soyadini daxil edin: ");
                                    string teachlastname = Console.ReadLine();
                                    Console.WriteLine("Muellimin ixtisasini daxil edin: ");
                                    string teachprofession = Console.ReadLine();
                                    Teacher teacher = new Teacher(teachname, teachlastname, teachprofession);
                                    university.Teachers.Add(teacher);
                                    Console.WriteLine("Muellim elave olundu");
                                    university.GetTeachers();

                                    break;
                                case 3:
                                   
                                    
                                    Console.WriteLine("Qrupun adini daxil edin: ");
                                    string GroupName = Console.ReadLine();
                                    if(university.Groups.Any(x=>x.Name == GroupName))
                                    {
                                        Console.WriteLine("Eyni iki qrup elave oluna bilmez");
                                    }
                                    else
                                    {

                                    Console.WriteLine( "Qrupun limitini daxil edin:" );
                                    int GroupLimit=int.Parse(Console.ReadLine());
                                    Group group = new Group(GroupName,GroupLimit);
                                    university.Groups.Add(group);
                                    university.GetGroups();
                                    Console.WriteLine("Qrup elave olundu");
                                 
                                    }

                                    break;

                                case 4:
                                    Console.WriteLine("Fennin adini elave edin: ");
                                    string subject=Console.ReadLine();
                                    Console.WriteLine("Fennin kreditini elave edin: ");
                                    int Ccredit = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Fennin kecirileceyi gun sayini elave edin: ");                                    
                                                                  
                                    int DayssofWeek=int.Parse(Console.ReadLine());
                                    try
                                    {
                                        Subject subject1 = new Subject(subject, Ccredit, DayssofWeek);
                                        university.Subjects.Add(subject1);
                                        Console.WriteLine("Fennler elave olundu");
                                        university.GetSubject();
                                    }
                                    catch (DaysOfWeekErrorHand ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }catch(CreditErrorHandler ex)
                                    {
                                        Console.WriteLine( ex.Message);
                                    }
                                    break;
                                    case 5:

                                    Console.WriteLine("Qrupu secin: ");
                                    university.GetGroups();
                                    int Grnumber = int.Parse(Console.ReadLine());
                                    Group gRoupExist = university.Groups.Find(x => x.ID == Grnumber);
                                    while(gRoupExist == null)
                                    {
                                        Console.WriteLine( "Bele qrup yoxdur");
                                        Grnumber = int.Parse(Console.ReadLine());
                                        gRoupExist = university.Groups.Find(x => x.ID == Grnumber);
                                    }

                                    Console.WriteLine("Fenni secin: ");
                                    university.GetSubject();
                                    int SubjectNum = int.Parse(Console.ReadLine());
                                   Subject SubjectExist = university.Subjects.Find(x => x.ID == SubjectNum);
                                    while (SubjectExist == null)
                                    {
                                        Console.WriteLine("Bele fenn yoxdur");
                                        SubjectNum = int.Parse(Console.ReadLine());
                                        SubjectExist = university.Subjects.Find(x => x.ID == SubjectNum);
                                    }
                                   if(university.Subjects.Any(x=>x.ID== SubjectExist.ID))
                                    {
                                        gRoupExist.Subjects.Add(SubjectExist);
                                        Console.WriteLine("Fenn qrupa elave olundu");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bu fenn bu qrupda tedris olunur");
                                    }
                                    Console.WriteLine("Muellimi secin: ");
                                    university.GetTeachers();
                                    int TeachID=int.Parse(Console.ReadLine());
                                    Teacher teacher1=university.Teachers.Find(x=>x.ID==TeachID);
                                    while(teacher1 == null)
                                    {
                                        Console.WriteLine("Bele muellim yoxdur");
                                        TeachID = int.Parse(Console.ReadLine());
                                         teacher1 = university.Teachers.Find(x => x.ID == TeachID);
                                    }
                                    if (!university.Teachers.Any(x => x.ID == TeachID))
                                    {
                                        university.Teachers.Add(teacher1);
                                        Console.WriteLine("Muellim qrupa elave olundu");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bu muellim bu qrupda artiq ders kecir");
                                    }
                                    gRoupExist.GetSubject();
                                    break;
                                case 6:
                                    Console.WriteLine("Qrupu secin: ");
                                    university.GetGroups();
                                    int GroupId=int.Parse(Console.ReadLine());
                                    gr1=university.Groups.Find(x=>x.ID == GroupId);
                                    while(gr1 == null)
                                    {
                                        Console.WriteLine("Bele qrup yoxdur");
                                        GroupId = int.Parse(Console.ReadLine());
                                        gr1 = university.Groups.Find(x => x.ID == GroupId);
                                    }
                                    Console.WriteLine("Fenni secin: ");
                                    university.GetSubject();
                                    SubjectNum = int.Parse(Console.ReadLine());
                                     SubjectExist = university.Subjects.Find(x => x.ID == SubjectNum);
                                    while (SubjectExist == null)
                                    {
                                        Console.WriteLine("Bele fenn yoxdur");
                                        SubjectNum = int.Parse(Console.ReadLine());
                                        SubjectExist = university.Subjects.Find(x => x.ID == SubjectNum);
                                    }
                                    Console.WriteLine("Telebeni secin: ");
                                    gr1.GetStudents();
                                    int StudentId=int.Parse(Console.ReadLine());
                                    student=gr1.Students.Find(x=>x.ID==StudentId);
                                    while(student == null)
                                    {
                                        Console.WriteLine("Bele telebe yoxdur");
                                        StudentId = int.Parse(Console.ReadLine());
                                        student = gr1.Students.Find(x => x.ID == StudentId);
                                    }

                                    Console.WriteLine("Imtahan novunu daxil edin: ");                                    
                                    Console.WriteLine("1.Midterm\n2.Presendation\n3.Quiz\n4.Final");
                                    int Type = int.Parse(Console.ReadLine());
                                    
                                    int[] ValidSelects = { 1, 2, 3, 4 };
                                    while(!ValidSelects.Any(x => x == Type))
                                    {
                                        Console.WriteLine("Duzgun imtahan novunu daxil edin");
                                        Type = int.Parse(Console.ReadLine());

                                    }
                                    Console.WriteLine("Max bali daxil edin");
                                    int max = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Telebenin aldigi bali daxil edin");
                                    int score = int.Parse(Console.ReadLine());
                                    while (score > max)
                                    {
                                        Console.WriteLine("Daxil  olunan max baldan artiq bal qeyd etmek olmaz");
                                        score = int.Parse(Console.ReadLine());
                                    }
                                    ExamineType type = (ExamineType)Type;
                                    Examiines examiines=new Examiines(SubjectExist.Name,type,score);
                                   if(!student.Examines.Where(x=>x.SubjectName==SubjectExist.Name && x.Type==type).Any()) 
                                    {
                                        student.Examines.Add(examiines);
                                        Console.WriteLine("Qiymetlendirilme aparildi");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bu telebe artiq qiymetlendirilib");
                                    }
                                    student.GetExamines();
                                    int FinalScore =   student.Examines.Where(x => x.SubjectName == SubjectExist.Name).Sum(x => x.Score);                                                                                                 
                                    if (FinalScore > 90 && FinalScore <= 100)
                                    {
                                        Console.WriteLine("Umumi bal: " + FinalScore + " A ");
                                    }
                                    else if (FinalScore > 80 && FinalScore <= 90)
                                    {
                                        Console.WriteLine("Umumi bal: " + FinalScore + " B ");
                                    }
                                    else if (FinalScore > 70 && FinalScore <= 80)
                                    {
                                        Console.WriteLine("Umumi bal: " + FinalScore + " C ");
                                    }
                                    else if (FinalScore > 60 && FinalScore <= 70)
                                    {
                                        Console.WriteLine("Umumi bal: " + FinalScore + " D ");
                                    }
                                    else if (FinalScore > 50 && FinalScore <= 60)
                                    {
                                        Console.WriteLine("Umumi bal: " + FinalScore + " E ");

                                    }
                                    else if (FinalScore > 0 && FinalScore <= 50)
                                    {

                                        Console.WriteLine("Umumi bal: " + FinalScore + " F, Siz bu imtahandan kesilmisiniz ");
                                    }
                                    break;
                               
                            }
                            result = Getselects();

                           

                        }
                        break;
                }
                       
            }


        }
        static int Getselects()
        {
            Console.WriteLine("Telebe elave etmek ucun 1 duymesini sixin: ");
            Console.WriteLine("Muellim elave etmek ucun 2 duymesini sixin: ");
            Console.WriteLine("Qrup elave etmek ucun 3 duymesini sixin: ");
            Console.WriteLine("Fenn elave etmek ucun 4 duymesini sixin: ");
            Console.WriteLine("Qrupa fenn ve Muellim elave etmek ucun 5 duymesini sixin: ");
            Console.WriteLine("Imtahan elave etmek ucun 6 duymesini sixin: ");
            Console.WriteLine("Cixis etmekucun 0 duymesini sixin: ");
            int result = int.Parse(Console.ReadLine());
            return result;
        }
        static int LoginPanel()
        {
            Console.WriteLine("Sisteme daxil olmaq ucun 1 duymesini sixin");
            Console.WriteLine("Sistemden cixis etmek ucun 0 duymesini sixin");
            int result = int.Parse(Console.ReadLine());
            return result;
        }
    }
}