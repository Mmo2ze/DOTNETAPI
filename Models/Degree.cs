using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZOPE.Models
{
    public class Degree
    {
        public int id { get; set; }
        public float value { get; set; }
        [JsonIgnore]
        public Student student { get; set; }
        public int StudentId { get; set; }
        public Exam Exam { get; set; }
        public int ExamId { get; set; }
    }
}