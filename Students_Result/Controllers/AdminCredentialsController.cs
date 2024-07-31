using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students_Result.Models;

namespace Students_Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCredentialsController : ControllerBase
    {
        private readonly StudentsRecordsContext context;
        public AdminCredentialsController(StudentsRecordsContext context)
        {
               this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminCredential>> GetAdminCredentials(int id)
        {
            var data = await context.AdminCredentials.FindAsync(id);
            return Ok(data);    
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdminCredential>> EditAdminCredentials(AdminCredential cred)
        {
            context.Entry(cred).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(cred);
        }


    }
}
