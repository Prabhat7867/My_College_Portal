using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students_Result.Models;

namespace Students_Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students_ResultController : ControllerBase
    {
        private readonly StudentsRecordsContext context;
        public Students_ResultController(StudentsRecordsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Y2024>>> GetResult()
        {
            var data = await context.Y2024s.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Y2024>> GetStudentByID(int id)
        {
            var data = await context.Y2024s.FindAsync(id);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Y2024>> Edit(Y2024 result)
        {
            context.Entry(result).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(result);

        }
        [HttpPost]
        public async Task<ActionResult<Y2024>> Add_Result(Y2024 result)
        {
            await context.AddAsync(result);
            await context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Y2024>> Delete(int id)
        {
            var result = await context.Y2024s.FindAsync(id);
            if(result == null)
            {
               return NotFound();
            }

            context.Y2024s.Remove(result);
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
