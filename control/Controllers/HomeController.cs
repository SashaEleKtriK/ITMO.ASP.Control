using control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace control.Controllers
{
    public class HomeController : Controller
    {
        
        private LogContext db = new LogContext();
        // GET: Home
        public List<string> GetClassesList()
        {
            var Classes = from ClassLog in db.ClassLogs
                          where ClassLog != null
                          orderby ClassLog.Name
                          select ClassLog.Name;

            List<string> items = new List<string>();
            
            foreach (var ClassLog in Classes)
            {
                
                items.Add(ClassLog.ToString());
            }
            return items;
        }
        public List<Users> GetUsersInClass(string userclass)
        {
            var students = from Users in db.Users
                        where Users.ClassNum == userclass
                        orderby Users.LastName
                        select Users;
            List<Users> items = new List<Users>();
            
            foreach (var stud in students)
            {
                
                items.Add(stud);
            }
            return items;

        }
        public ActionResult Index()
        {
            ViewBag.Classes = GetClassesList();
            ViewBag.Table = db.LessonsTable.ToList<LessonsTable>();
            ViewBag.Lessons = db.Lessons.ToList<Lessons>().OrderBy(Lessons => Lessons.LessonName);
            ViewBag.WeekDay = db.Week.ToList<Week>();
            return View();
        }
        public ActionResult RateStud()
        {
            var AllStud = from Marks in db.Marks
                          group Marks by Marks.Student into g
                          select new { Name = g.Key, Count = g.Count(), Marks = from m in g select m}; ;
            List<StudentRate> rateList = new List<StudentRate>();
            foreach (var Stud in AllStud)
            {
                StudentRate studRate= new StudentRate();
                studRate.Stud = Stud.Name;
                studRate.MarksCount = Stud.Count;
                foreach (var mark in Stud.Marks)
                {
                    double MarkInt = 0;
                    try
                    {
                        MarkInt = Double.Parse(mark.Mark);
                        studRate.MarksSum += MarkInt;
                        studRate.MiddleMark = studRate.MarksSum / studRate.MarksCount;
                        if (MarkInt == 5) 
                        {
                            studRate.Rate += 3;
                        }
                        if (MarkInt == 4)
                        {
                            studRate.Rate += 2;
                        }
                        if (MarkInt == 3)
                        {
                            studRate.Rate += 1;
                        }
                        if (MarkInt == 2)
                        {
                            studRate.Rate -= 2;
                        }
                    }
                    catch
                    {
                        studRate.MarksCount--;
                        continue;
                    }
                    
                }
                rateList.Add(studRate);
            }
            var Best = (from StudentRate in rateList
                        where StudentRate.MiddleMark != 0
                        orderby StudentRate.Rate descending, StudentRate.MiddleMark descending
                       select StudentRate).Take(5);
            var Worst = (from StudentRate in rateList
                         where StudentRate.MiddleMark != 0
                        orderby StudentRate.Rate ascending, StudentRate.MiddleMark ascending
                        select StudentRate).Take(5);
            ViewBag.Best = Best;
            ViewBag.Worst = Worst;
            return View();
        }
  
        public ActionResult About() 
        {
            ViewBag.Classes = db.ClassLogs.ToList<ClassLog>();
            return View();
        }
        public ActionResult Add()
        {
            ViewBag.Students = db.Users.ToList<Users>();
            return View();
        }
        public ActionResult ChooseClass()
        {
            ViewBag.Classes = db.ClassLogs.ToList <ClassLog>();
            return View();
        }
        [HttpGet]
        public ActionResult ChooseStud(int Class)
        {
            var classNum = from ClassLog in db.ClassLogs
                           where ClassLog.ClassLogId == Class
                           select ClassLog;
            string classNumb = string.Empty;
            ClassLog ChosenClass = new ClassLog();
            foreach (var classC in classNum)
            {
                ChosenClass = classC;
                classNumb = classC.Name.ToString();
            }
            List<Marks> marks = new List<Marks>();
            List<string> lesStud = new List<string>();
            ViewBag.Lessons = lesStud;
            ViewBag.CurStud = "Выберите ученика";
            ViewBag.Class = ChosenClass;
            ViewBag.stud = GetUsersInClass(classNumb);
            ViewBag.Marks = marks;
            return View();
        }
        [HttpPost]
        public ViewResult ChooseStud(string Student, string Class)
        {
            int IdClass = Int32.Parse(Class);
            var classNum = from ClassLog in db.ClassLogs
                           where ClassLog.ClassLogId == IdClass
                           select ClassLog;
            string classNumb = string.Empty;
            ClassLog ChosenClass = new ClassLog();
            foreach (var classC in classNum)
            {
                ChosenClass = classC;
                classNumb = classC.Name.ToString();
            }
            var marksStud = from Marks in db.Marks
                            where Marks.Student == Student
                            orderby Marks.MarksId
                            select Marks;
            var lessons = from Marks in db.Marks
                          where Marks.Student == Student
                          group Marks by Marks.Lesson;
            List<string> lesStud = new List<string>();
            foreach (var mark in lessons)
            {
                string les = mark.Key;
                lesStud.Add(les);
            }
            ViewBag.CurStud = Student;
            ViewBag.Lessons = lesStud;
            ViewBag.Marks = marksStud;
            ViewBag.stud = GetUsersInClass(classNumb);
            ViewBag.Class = ChosenClass;
            return View();
        }
        public ActionResult ChooseLesson(int id)
        {
            var classNum = from ClassLog in db.ClassLogs
                           where ClassLog.ClassLogId == id
                           select ClassLog;
            string classNumb = string.Empty;
            ClassLog ChosenClass = new ClassLog();  
            foreach (var classC in classNum)
            {
                ChosenClass = classC;
                classNumb = classC.Name.ToString();
            }
            var allLessons = from LessonsTable in db.LessonsTable
                             where LessonsTable.Class == classNumb
                             select LessonsTable;
            List<string> LessonName = new List<string>();
            
            foreach (LessonsTable table in allLessons)
            {
                string lesson;
                lesson = table.FirstLesson;
                if (!LessonName.Contains(lesson))
                {
                    LessonName.Add(lesson);
                }
                lesson = table.SecondLesson;
                if (!LessonName.Contains(lesson))
                {
                    LessonName.Add(lesson);
                }
                lesson = table.ThirdLesson;
                if (!LessonName.Contains(lesson))
                {
                    LessonName.Add(lesson);
                }
                lesson = table.FourthLesson;
                if (!LessonName.Contains(lesson))
                {
                    LessonName.Add(lesson);
                }
                lesson = table.FifthLesson;
                if (!LessonName.Contains(lesson))
                {
                    LessonName.Add(lesson);
                }
                lesson = table.SixLesson;
                if (!LessonName.Contains(lesson))
                {
                    LessonName.Add(lesson);
                }
            }    
            List <Lessons> ClassLessons= new List<Lessons>();
            foreach (string lesString in LessonName)
            {
                int LesId = 1;
                string[]lessons = lesString.Split(',');
                try
                {
                    LesId = Int32.Parse(lessons[0]); 
                }
                catch(Exception)
                {
                    continue;
                }
                Lessons ClasLes = new Lessons();
                var les = from Lessons in db.Lessons
                              where Lessons.LessonsId == LesId
                              select Lessons;
                foreach (Lessons lesClass in les)
                {
                    ClasLes = lesClass;
                }
                ClassLessons.Add(ClasLes);
            }
            ViewBag.Lessons = ClassLessons;
            ViewBag.Class = ChosenClass;
            return View();
        }
        [HttpPost]
        public ActionResult SetMark(string Student, string Mark,string lesson,string chosenClass)
        {
            string DateNow = DateTime.Now.ToShortDateString();
            Marks mark = new Marks();
            if (Student != string.Empty)
            {
                mark.Student = Student;
                mark.Mark= Mark;
                mark.MarkDate = DateNow;
                mark.Lesson = lesson;
                mark.ClassNum = chosenClass;
                db.Marks.Add(mark);
                db.SaveChanges();
                
            }
            
            ViewBag.lesson = lesson;
            int classId = Int32.Parse(chosenClass);
            var classC = from ClassLog in db.ClassLogs
                         where ClassLog.ClassLogId == classId
                         select ClassLog;
            ClassLog ClassToMark = new ClassLog();
            string ClassNum = string.Empty;
            foreach (ClassLog c in classC)
            {
                ClassNum = c.Name;
                ClassToMark = c;
            }
            ViewBag.chosenClass = ClassToMark;
            ViewBag.stud = GetUsersInClass(ClassNum);
            var ClassMarks = from Marks in db.Marks
                             where Marks.ClassNum == chosenClass & Marks.Lesson == lesson & Marks.MarkDate == DateNow
                             orderby Marks.Student
                             select Marks;
            
            
            ViewBag.marks = ClassMarks;
            
            return View();
        }
        
        [HttpGet]
        public ActionResult CreateClass()
        {
            ViewBag.ClassLessons = new List<Lessons>();
            ViewBag.Lessons = db.Lessons.ToList<Lessons>();
            return View();
        }
        [HttpPost]
        public ViewResult CreateClass(ClassLog p)
        {
  
            db.ClassLogs.Add(p);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult CreateLessonTable()
        {
            ViewBag.Classes = GetClassesList();
            ViewBag.Table = db.LessonsTable.ToList<LessonsTable>();
            ViewBag.Lessons = db.Lessons.ToList<Lessons>().OrderBy(Lessons => Lessons.LessonName);
            ViewBag.WeekDay = db.Week.ToList<Week>();
            return View();

        }
        [HttpPost]
        public ViewResult CreateLessonTable(LessonsTable p)
        {
            var oldLessons = from LessonsTable in db.LessonsTable
                             where LessonsTable.Class == p.Class & LessonsTable.WeekDay == p.WeekDay
                             select LessonsTable;
            foreach (var oldL in oldLessons)
            {
                db.LessonsTable.Remove(oldL);
            }
            db.LessonsTable.Add(p);
            db.SaveChanges();
            ViewBag.Classes = GetClassesList();
            ViewBag.Table = db.LessonsTable.ToList<LessonsTable>();
            ViewBag.Lessons = db.Lessons.ToList<Lessons>().OrderBy(Lessons => Lessons.LessonName);
            ViewBag.WeekDay = db.Week.ToList<Week>();
            return View();
        }

        [HttpGet]
        public ActionResult CreateLesson()
        {
            ViewBag.Lessons = db.Lessons.ToList<Lessons>();

            return View();
        }
        [HttpPost]
        public ViewResult CreateLesson(Lessons p)
        {
            
            db.Lessons.Add(p);
            db.SaveChanges();

            ViewBag.Classes = GetClassesList();
            ViewBag.Table = db.LessonsTable.ToList<LessonsTable>();
            ViewBag.Lessons = db.Lessons.ToList<Lessons>().OrderBy(Lessons => Lessons.LessonName);
            ViewBag.WeekDay = db.Week.ToList<Week>();
            return View("Index");

        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.Students = db.Users.ToList<Users>();
            ViewBag.Classes = GetClassesList();
            
            return View();
        }
        [HttpPost]
        public ViewResult CreateUser(Users p)
        {
            p.FirstName = TextChecker(p.FirstName);
            p.LastName = TextChecker(p.LastName);
            if (p.FirstName == "error" || p.LastName == "error")
            {
                ViewBag.Error = "Имя и Фамилия могут содержать исключительно буквы";
                return View("Error");
            }
            else
            {
                db.Users.Add(p);
                db.SaveChanges();
                ViewBag.Classes = GetClassesList();
                ViewBag.Table = db.LessonsTable.ToList<LessonsTable>();
                ViewBag.Lessons = db.Lessons.ToList<Lessons>().OrderBy(Lessons => Lessons.LessonName);
                ViewBag.WeekDay = db.Week.ToList<Week>();
                return View("Index");
            }
            
        }
        public string TextChecker(string text)
        {
            try
            {
                char[] chars = text.ToCharArray();
                bool isFirst = true;
                foreach (char k in chars)
                {
                    if (char.IsLetter(k))
                    {
                        if (isFirst)
                        {
                            text = k.ToString().ToUpper();
                            isFirst = false;
                        }
                        else
                        {
                            text += k.ToString().ToLower();
                        }
                    }
                    else
                    {
                        text = "error";
                        break;
                    }

                }
            }
            catch
            {
                text = "error";
            }
            
            return text;
        }
       
        public ActionResult DeleteUser(int id)
        {
            var p = from Users in db.Users
                    where Users.UsersId == id
                    select Users;
            foreach (Users k in p)
            {
                db.Users.Remove(k);
                
            }
            db.SaveChanges();
            ViewBag.Students = db.Users.ToList<Users>();
            ViewBag.Classes = GetClassesList();
            return View("CreateUser");
        }
       public ActionResult DeleteLesson(int id)
        {
            var p = from Lessons in db.Lessons
                    where Lessons.LessonsId == id
                    select Lessons;
            foreach (Lessons k in p)
            {
                db.Lessons.Remove(k);

            }
            db.SaveChanges();
            ViewBag.Lessons = db.Lessons.ToList<Lessons>();
            return View("CreateLesson");
        }
        public ActionResult DeleteMark(int id)
        {
            var p = from Marks in db.Marks
                    where Marks.MarksId == id
                    select Marks;
            foreach (Marks k in p)
            { db.Marks.Remove(k); }
            db.SaveChanges();
            ViewBag.Classes = db.ClassLogs.ToList<ClassLog>();
            return View("ChooseClass");
        }
    }
}