using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace control.Models
{
    public class LessonsTable
    {
        public virtual int Id { get; set; }
        public virtual string FirstLesson { get; set; } = "нет урока";
        public virtual string SecondLesson { get; set; } = "нет урока";
        public virtual string ThirdLesson { get; set; } = "нет урока";
        public virtual string FourthLesson { get; set; } = "нет урока";
        public virtual string FifthLesson { get; set; } = "нет урока";
        public virtual string SixLesson { get; set; } = "нет урока";
        public virtual string WeekDay { get; set; }
        public virtual string Class { get; set; }
        //public virtual string Name { get; set; }   

    }
}