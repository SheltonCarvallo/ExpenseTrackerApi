using ExpenseTrackerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;

namespace ExpenseTrackerApi.Controllers;


[ApiController]
[Route("api/[Controller]")]
public class UserController : ControllerBase
{
    private readonly IUser _user;
    
    public UserController(IUser user)
    {
        this._user = user;
    }
    
    [HttpGet("{id:guid}")] //Adding constraint
   public async Task<ActionResult<User>> GetUser(Guid id)
   {
       User user = await _user.GetUser(id);
       if (user.Id == Guid.Empty)
       {
           return NotFound();
       }

       return Ok(user);
   }
    [HttpGet] 
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        IEnumerable<User> users = await _user.GetUsers();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] User user)
    {
        await _user.PostUser(user);
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        //If I am not mistaken the first parameter in CreatedAtAction returns the url with the action method to get the resource recently created
    }
} 