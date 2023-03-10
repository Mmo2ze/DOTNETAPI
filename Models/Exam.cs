using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZOPE.Models
{
    public class Exam
    {
        public int id { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public string questions { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public List<Degree> degree { get; set; }
    }
}