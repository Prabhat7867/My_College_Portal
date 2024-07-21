using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students_Result.Models;
using System.Globalization;

namespace Students_Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentsRecordsContext context;
        public StudentAPIController(StudentsRecordsContext context)
        {
                this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<StudentDetail>>> GetStudent()
        {
            var data = await context.StudentDetails.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetail>> GetStudentByID(int id)
        {
            var data = await context.StudentDetails.FindAsync(id);
            return Ok(data);    
        }



        [HttpPost]
        public async Task<ActionResult<StudentDetail>> AddNew_Student(StudentDetail std)
        {
            await context.StudentDetails.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDetail>> Update_StudentDetails(StudentDetail std)
        {
            //if(id != std.RollNo)
            //{
            //    return BadRequest();
            //}
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDetail>> DeleteStudents(int id)
        {
            var std = await context.StudentDetails.FindAsync(id);
            if(std == null)
            {
                return NotFound();
            }
            context.StudentDetails.Remove(std);
            await context.SaveChangesAsync();
            return Ok();


        }

    }
}
