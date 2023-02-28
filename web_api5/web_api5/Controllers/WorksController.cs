using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api5.Data;
using web_api5.Model;

namespace web_api5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksController : ControllerBase
    {
        private readonly MyDBContext _context;

        public WorksController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Works
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Work>>> GetWorks()
        {
            return await _context.Works.ToListAsync();
        }

        // GET: api/Works/5
        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Work>> GetWork(int id)
        {
            var work = await _context.Works.FindAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            return work;
        }
        //Get:api/Works/workname
        [HttpGet]
        [Route("workname")]

        public IActionResult GetWorkByName(string workname)
        {
            var work = _context.Works.Where(x => x.Workname.Contains(workname));

            return Ok(work);
        }

        // PUT: api/Works/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWork(int id, Work work)
        {
            if (id != work.ID)
            {
                return BadRequest();
            }

            _context.Entry(work).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Works
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Work>> PostWork(WorkMD workmd)
        {
            var work = new Work
            {
                Workname = workmd.Workname,
                Detail = workmd.Detail,
                Status = workmd.Status
            };
            _context.Works.Add(work);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWork", new { id = work.ID }, work);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            var work = await _context.Works.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            _context.Works.Remove(work);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkExists(int id)
        {
            return _context.Works.Any(e => e.ID == id);
        }
        [HttpGet]
        [Route("Status")]

        public IActionResult GetUserByName(string status)
        {
            var user = _context.Works.Where(x => x.Status=="hoan thanh" || x.Status=="chua hoan thanh");

            return Ok(user);
        }
    }
}
