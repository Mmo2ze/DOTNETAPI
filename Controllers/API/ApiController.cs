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
        public async Task<ActionResult<List<Group>>> GetGroups()
        {
            List<Group> groups = _db.Groups.ToList();
            return Ok(groups);
        }
        [HttpGet("/Group/{id}")]
        public async Task<ActionResult<Group>> GetGroups(int id)
        {
            Group group = _db.Groups.Find(id);
            if (group == null)
            {
                return NotFound("This Group does not exist.");
            }
            else
                return Ok(group);
        }
        [HttpPost("/Group")]
        public async Task<ActionResult> AddGroup(Group group)
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
        public async Task<ActionResult> GetStudents()
        {
            List<Student> Students = _db.students.ToList();
            return Ok(Students);
        }


        [HttpPost("/Student")]
        public async Task<ActionResult<List<Student>>> AddStudent(StudentDto student)
        {
            Student student1 = new Student();
            student1.email = student.email;
            student1.name = student.name;
            student1.groupId = student.groupId;
            _db.students.Add(student1);
            _db.SaveChanges();
            List<Student> students = _db.students.ToList();
            return Ok(students);
        }

        [HttpPut("/Student")]
        public async Task<ActionResult<Student>> UpdateStudents(StudentDto request)
        {
            Student student = _db.students.Find(request.id);
            if (student == null)
            {
                return NotFound("This student dose not exist");
            }
            else
            {
                student.name = request.name;
                student.email = request.email;
                student.groupId = request.groupId;
                _db.students.Update(student);
                _db.SaveChanges();
                return Ok(student);
            }
        }
        [HttpPut("/Student/{id}&{name}")]
        public async Task<ActionResult<Student>> UpdateStudentsName(int id,string name)
        {
            Student student = _db.students.Find(id);
            if (student == null)
            {
                return NotFound("This student dose not exist");
            }
            else
            {
                student.name = name;
                _db.students.Update(student);
                _db.SaveChanges();
                return Ok(student);
            }
        }
        [HttpDelete("/Student")]
        public async Task<ActionResult> DeleteStudents(int id)
        {
            Student student = _db.students.Find(id);
            if (student == null)
            {
                return NotFound("This student dose not exist");
            }
            _db.students.Remove(student);
            _db.SaveChanges();
            return Ok("Success");
        }
    }
}