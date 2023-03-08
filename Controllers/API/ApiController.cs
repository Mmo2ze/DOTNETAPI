using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZOPE.DataBase;
using ZOPE.Models;
namespace ZOPE.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIconteroller : ControllerBase
    {
        public readonly MainContext _db = new MainContext();
        [HttpGet("/Group")]
        public ActionResult GetGroups()
        {
            List<Group> groups = _db.Groups.ToList();
            return Ok(groups);
        }
        [HttpPost("/Group")]
        public ActionResult AddGroup(GroupDto group)
        {
            Console.WriteLine(group.name);
            Group group1 = new Group();
            group1.name = group.name;
            _db.Groups.Add(group1);
            _db.SaveChanges();
            string[] x = { "Pst", "laith", "Mmo2ze", "Fuck off" };
            return Ok(x);
        }
        [HttpGet("/Student")]
        public ActionResult GetStudents()
        {
            List<Student> Students = _db.students.ToList();
            return Ok(Students);
        }
        [HttpPost("/Student")]
        public ActionResult AddStudent(StudentDto student)
        {
            Console.WriteLine(student.name);
            Student group1 = new Student();
            group1.name = student.name;
            group1.email = student.email;
            group1.groupId = student.groupId;
            
            _db.students.Add(group1);
            _db.SaveChanges();
            string[] x = { "Pst", "laith", "Mmo2ze", "Fuck off" };
            return Ok(x);
        }
    }
}