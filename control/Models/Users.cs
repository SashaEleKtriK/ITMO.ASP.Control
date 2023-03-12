using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace control.Models
{
    public class Users
    {
        public virtual int UsersId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string ClassNum { get; set; }
        
        
    }
    public class StudentRate
    {
        public string Stud;
        public int MarksCount;
        public double MiddleMark;
        public double MarksSum;
        public int Rate;
        public StudentRate() { }
    }
}