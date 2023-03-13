using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ZOPE.DataBase;
using ZOPE.Models;
namespace ZOPE.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIconteroller : ControllerBase
    {
        public readonly MainContext _db = new MainContext();


        // ------------------------------GROUP-------------------------
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
        public async Task<ActionResult<List<Group>>> AddGroup(GroupDto request)
        {
            var x = _db.Groups.Where(c => c.name == request.name);
            if (x.Count() != 0)
            {
                return BadRequest("This Group Name already exist.");
            }
            Group group = new Group();
            group.name = request.name;
            _db.Groups.Add(group);
            _db.SaveChanges();
            return Ok(group);
        }
        [HttpPut("/Group/{id}")]
        public async Task<ActionResult<Group>> UpdateGroup(int id, GroupDto request)
        {
            Group group = _db.Groups.Find(id);
            var x = _db.Groups.Where(c => c.name == request.name);
            if (x.Count() != 0)
            {
                return BadRequest("This Group Name already exist.");
            }
            if (group == null)
            {
                return NotFound("This Group does not exist.");
            }
            if (request.name == null || request.name.Length == 0)
            {
                return BadRequest("name cant be empty.");
            }
            _db.Groups.Update(group);
            _db.SaveChanges();
            return Ok(group);
        }
        
        [HttpDelete("/Group/{id}")]
        public ActionResult DeleteGroup(int id)
        {
            Group group = _db.Groups.Find(id);

            if (group == null)
            {
                return NotFound("This student dose not exist");
            }

            _db.Groups.Remove(group);
            _db.SaveChanges();
            return Ok("Success");
        }
        // ------------------------------STUDENT-------------------------
        [HttpGet("/Student")]
        public ActionResult<List<Student>> GetStudents()
        {
            List<Student> Students = _db.Students.ToList();
            return Ok(Students);
        }


        [HttpPost("/Student")]
        public ActionResult<List<Student>> AddStudent(StudentDto request)
        {
            Student student = new Student();
            student.email = request.email;
            student.name = request.name;
            student.groupId = request.groupId;
            student.phone = request.phone;
            _db.Students.Add(student);
            _db.SaveChanges();
            List<Student> students = _db.Students.ToList();
            return Ok("d");
        }

        [HttpPut("/Student")]
        public ActionResult<Student> UpdateStudents(StudentDto request)
        {
            Student student = _db.Students.Find(request.id);
            if (student == null)
            {
                return NotFound("This student dose not exist");
            }
            if (request.email != "")
                student.email = request.email;
            if (request.name != "")
                student.name = request.name;
            if (request.groupId != 0)
                student.groupId = request.groupId;
            _db.Students.Update(student);
            _db.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("/Student/{id}")]
        public ActionResult DeleteStudents(int id)
        {
            Student student = _db.Students.Find(id);

            if (student == null)
            {
                return NotFound("This student dose not exist");
            }

            _db.Students.Remove(student);
            _db.SaveChanges();
            return Ok("Success");
        }

        // ------------------------------EXAM-------------------------
        [HttpGet("/exams")]
        public IActionResult GetExams()
        {
            List<Exam> exams = _db.Exams.ToList();
            return Ok(exams);
        }
        [HttpPost("/exam")]
        public IActionResult AddExam(ExamDto request)
        {
            Exam exam = new Exam();
            exam.Date = DateTime.Now;
            exam.max = request.max;
            exam.min = request.min;
            exam.questions = request.questions;
            _db.Exams.Add(exam);
            _db.SaveChanges();
            return Ok(_db.Exams.ToList());
        }

        // ------------------------------DEGREE-------------------------
        [HttpGet("/Degrees")]
        public IActionResult GetDegrees()
        {
            var student = _db.Students.Include(c => c.group)
            .Include(c => c.degrees)
            .ToList();
            Console.WriteLine(student[0].id);
            var dbDegrees = _db.Degrees.Where(c => c.id == 1);
            for (int j = 0; j < student.Count; j++)
            {
                List<Degree> degrees = new List<Degree>();

                for (int i = 0; i < student[j].degrees.Count; i++)
                {
                    var x = dbDegrees.Include(c => c.Exam);
                    degrees.AddRange(x);
                }
                student[j].degrees = degrees;
            }
            return Ok(student);
        }
        [HttpPost("/Degree")]
        public IActionResult AddDegree(DegreeDto request)
        {
            Degree degree = new Degree();
            degree.ExamId = request.ExamId;
            degree.StudentId = request.StudentId;
            degree.value = request.value;
            _db.Degrees.Add(degree);
            _db.SaveChanges();
            return Ok(degree);
        }
    }
}