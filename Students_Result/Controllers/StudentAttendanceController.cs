using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Students_Result.Models;

namespace Students_Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        private readonly StudentsRecordsContext context;
        public StudentAttendanceController(StudentsRecordsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentAttendance>>> GetAttendance()
        {
            var data =  await context.StudentAttendances.ToListAsync();
            return Ok(data);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAttendance>> GetStudentAttendance(int id)
        {
            var data = await context.StudentAttendances.FindAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<StudentAttendance>> AddAttendance(StudentAttendance studentAttendance)
        {
            await context.StudentAttendances.AddAsync(studentAttendance);
            await context.SaveChangesAsync();
            return Ok(studentAttendance);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentAttendance>> EditAttendance(StudentAttendance attendance)
        {
            context.Entry(attendance).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(attendance); 
        }

        [HttpDelete]
        public async Task<ActionResult<StudentAttendance>> DeleteAttendance(int id)
        {
            var data = await context.StudentAttendances.FindAsync(id);
            if(data == null) {return NotFound(); }


            context.StudentAttendances.Remove(data);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
