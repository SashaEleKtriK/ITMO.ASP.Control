using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace control.Models
{
    public class UsersInitializer : DropCreateDatabaseIfModelChanges<LogContext>
    {
        protected override void Seed(LogContext context)
        {
            context.Users.Add(new Users { FirstName = "Антон", LastName = "Ковалев", ClassNum = "8 А" });

            context.Users.Add(new Users { FirstName = "Игорь", LastName = "Танцев", ClassNum = "8 А" });

            context.Users.Add(new Users { FirstName = "Федор", LastName = "Апполонов", ClassNum = "8 А" });

            context.Users.Add(new Users { FirstName = "Ира", LastName = "Матюхина", ClassNum = "8 А" });

            context.Users.Add(new Users { FirstName = "Аня", LastName = "Матюхина", ClassNum = "8 Б" });

            context.Users.Add(new Users { FirstName = "Юля", LastName = "Скороварова", ClassNum = "8 Б" });

            context.Users.Add(new Users { FirstName = "Павел", LastName = "Князь", ClassNum = "8 В" });

            context.Users.Add(new Users { FirstName = "Алексей", LastName = "Егоров", ClassNum = "8 В" });


            context.ClassLogs.Add(new ClassLog { Name = "8 А" });

            context.ClassLogs.Add(new ClassLog { Name = "8 Б" });

            context.ClassLogs.Add(new ClassLog { Name = "8 В" });

            context.Week.Add(new Week { Name = "Понедельник" });

            context.Week.Add(new Week { Name = "Вторник" });

            context.Week.Add(new Week { Name = "Среда" });

            context.Week.Add(new Week { Name = "Четверг" });

            context.Week.Add(new Week { Name = "Пятница" });

            context.Week.Add(new Week { Name = "Суббота" });

            context.LessonsTable.Add(new LessonsTable
            {
                FirstLesson = "1, Русский язык",
                SecondLesson = "2, Английский язык",
                ThirdLesson = "3, Физкультура",
                FourthLesson = "4, Математика",
                Class = "8 А",
                WeekDay = "Понедельник"
                
            });
            context.LessonsTable.Add(new LessonsTable
            {
                FirstLesson = "1, Русский язык",
                SecondLesson = "2, Английский язык",
                ThirdLesson = "3, Физкультура",
                FourthLesson = "4, Математика",
                Class = "8 Б",
                WeekDay = "Понедельник"

            });
            context.LessonsTable.Add(new LessonsTable
            {
                FirstLesson = "1, Русский язык",
                SecondLesson = "2, Английский язык",
                ThirdLesson = "3, Физкультура",
                FourthLesson = "4, Математика",
                Class = "8 В",
                WeekDay = "Понедельник"

            });
            context.LessonsTable.Add(new LessonsTable
            {
                FirstLesson = "1, Русский язык",
                SecondLesson = "2, Английский язык",
                ThirdLesson = "3, Физкультура",
                FourthLesson = "4, Математика",
                Class = "8 А",
                WeekDay = "Вторник"

            });
            context.LessonsTable.Add(new LessonsTable
            {
                FirstLesson = "1, Русский язык",
                SecondLesson = "2, Английский язык",
                ThirdLesson = "3, Физкультура",
                FourthLesson = "4, Математика",
                Class = "8 А",
                WeekDay = "Среда"

            });
            context.Lessons.Add(new Lessons { LessonName = "Русский язык" });

            context.Lessons.Add(new Lessons { LessonName = "Английский язык" });

            context.Lessons.Add(new Lessons { LessonName = "Физкультура" });

            context.Lessons.Add(new Lessons { LessonName = "Математика" });

            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Апполонов Федор",
                ClassNum = "1",
                Mark = "3",
                MarkDate= new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Апполонов Федор",
                ClassNum = "1",
                Mark = "5",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Апполонов Федор",
                ClassNum = "1",
                Mark = "4",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Ковалев Антон",
                ClassNum = "1",
                Mark = "4",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Ковалев Антон",
                ClassNum = "1",
                Mark = "2",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Матюхина Ира",
                ClassNum = "1",
                Mark = "3",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Матюхина Ира",
                ClassNum = "1",
                Mark = "4",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Матюхина Ира",
                ClassNum = "1",
                Mark = "5",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Танцев Игорь",
                ClassNum = "1",
                Mark = "5",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Матюхина Аня",
                ClassNum = "2",
                Mark = "4",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Матюхина Аня",
                ClassNum = "2",
                Mark = "3",
                MarkDate = new DateTime().ToShortDateString()

            });
            context.Marks.Add(new Marks
            {
                Lesson = "Русский язык",
                Student = "Скороварова Юля",
                ClassNum = "2",
                Mark = "3",
                MarkDate = new DateTime().ToShortDateString()

            });

            base.Seed(context);
        }
    }
}