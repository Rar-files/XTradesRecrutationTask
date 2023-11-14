
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using XTradesRecrutationTask.Models;
using XTradesRecrutationTask.Dtos;
using AutoMapper;

namespace XTradesRecrutationTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly XTradesDBContext _context;
    private readonly IMapper _mapper;

    public UserController(XTradesDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    // GET: api/User/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        if(_context.Users == null)
        {
            return NotFound("Users not found");
        }

        var user = await _context.Users.FindAsync(id);

        if(user == null)
        {
            return NotFound("User not found");
        }

        return Ok(user);
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(UserDto userDto)
    {
        var userToCreate = _mapper.Map<User>(userDto);

        await _context.Users.AddAsync(userToCreate);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = userToCreate.Id }, userToCreate);
    }

    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, UserDto userDto)
    {
        if(_context.Users == null)
        {
            return NotFound("Users not found");
        }

        var user = await _context.Users.FindAsync(id);

        if(user == null)
        {
            return NotFound("User not found");
        }

        user = _mapper.Map<UserDto, User>(userDto, user);

        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(user);
    }
}