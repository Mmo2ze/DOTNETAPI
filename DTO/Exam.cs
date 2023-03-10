using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZOPE.Models
{
    public class ExamDto
    {
        public int max { get; set; }
        public int min { get; set; }
        public string questions { get; set; }
        public DateTime Date { get; set; }
    }
}