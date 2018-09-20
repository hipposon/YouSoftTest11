using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouSoftTest1.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Table> Tables { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}