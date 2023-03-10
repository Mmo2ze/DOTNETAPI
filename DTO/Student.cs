using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZOPE.Models
{
    public class StudentDto
    {
        public int id { get; set; }
        public string name { get; set; }="";
        public string email { get; set; }="";
        public string phone { get; set; } ="";
        public int groupId { get; set; } = 0;
    }
}