using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZOPE.Models
{
    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public List<Student> students { get; set; }
        
    }
}