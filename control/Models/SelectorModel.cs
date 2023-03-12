using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace control.Models
{
    public class SelectorModel
    {
        public int[] SelectedIds { get; set; }
        public IEnumerable<SelectListItem> List { get; set; }
    }
}