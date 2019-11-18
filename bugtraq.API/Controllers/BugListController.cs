using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bugtraq.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bugtraq.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class BugListController : ControllerBase
  {
    private readonly DataContext _context;
    public BugListController(DataContext context)
    {
      _context = context;

    }
    // GET api/values
    [HttpGet]
    public async Task<IActionResult> GetBugLists()
    {
      var buglists = await _context.BugLists.ToListAsync();

      return Ok(buglists);
    }

    // GET api/values/5
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBugList(int id)
    {
      var buglist = await _context.BugLists.FirstOrDefaultAsync(x => x.Id == id);

      return Ok(buglist);
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
