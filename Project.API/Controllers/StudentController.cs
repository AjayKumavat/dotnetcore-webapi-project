using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetStudents")]
        [Produces(typeof(Student))]
        public async Task<IActionResult> GetStudents()
        {
            IEnumerable<Student> students = await _studentService.GetStudents();
            return Ok(students);
        }
    }
}
