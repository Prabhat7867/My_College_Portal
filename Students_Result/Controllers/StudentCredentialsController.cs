using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students_Result.Models;

namespace Students_Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCredentialsController : ControllerBase
    {
        private readonly StudentsRecordsContext context;
        public StudentCredentialsController(StudentsRecordsContext context)
        {
               this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCredential>> GetStudentCredential(int id)
        {
            var data = await context.StudentCredentials.FindAsync(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentCredential>> EditStudentCred(StudentCredential cred)
        {
            context.Entry(cred).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();
        }
            


    }
}
