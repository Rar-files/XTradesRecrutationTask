
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using XTradesRecrutationTask.Models;

namespace XTradesRecrutationTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly XTradesDBContext _context;

    public UserController(XTradesDBContext context)
    {
        _context = context;
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        if(_context.Users == null)
        {
            return NotFound("Users not found");
        }

        return await _context.Users.ToListAsync();
    }
}