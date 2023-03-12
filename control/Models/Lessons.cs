using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace control.Models
{
    public class Lessons
    {
        public virtual int LessonsId { get; set; }
        public virtual string LessonName { get; set; }
        public virtual string LessonRoom { get; set; }
        public virtual string Teacher { get; set; }

    }
}