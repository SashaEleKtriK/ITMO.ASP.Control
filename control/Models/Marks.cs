using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace control.Models
{
    public class Marks
    {
        public virtual int MarksId { get; set; }
        public virtual string Student { get; set; }
        public virtual string Lesson{ get; set; }
        public virtual string MarkDate { get; set; }
        public virtual string Mark { get; set;}
        public virtual string ClassNum { get; set;}
    }
}