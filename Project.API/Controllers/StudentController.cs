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
        [Produces(typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetStudents()
        {
            IEnumerable<Student> students = await _studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet]
        [Route("GetStudentById/{id}")]
        [Produces(typeof(Student))]
        public async Task<IActionResult> GetStudentById(int id)
        {
            Student student = await _studentService.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost]
        [Route("AddStudent")]
        [Produces(typeof(Student))]
        public IActionResult AddStudent(Student student)
        {
            Student _student = _studentService.AddStudent(student);
            return Ok(_student); 
        }

        [HttpPut]
        [Route("UpdateStudent")]
        [Produces(typeof(Student))]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            Student _student = await _studentService.UpdateStudent(student);
            return Ok(_student);
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        [Produces(typeof(bool))]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            bool isDeleted = await _studentService.DeleteStudent(id);
            return Ok(isDeleted);
        }
    }
}
