using ExpenseTrackerApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTOs;
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
        try
        {
            User user = await _user.GetUser(id);
            if (user.Id == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception ex) 
        {
            return ValidationProblem("Unexpected error ocurred, contact IT deparment", ex.Message, 500, "Unexpected error"); throw;
        }
       
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(int page = 1, int pageSize = 5)
    {
        IEnumerable<User> users = await _user.GetUsers(page, pageSize);
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] User user)
    {
        try
        {
            SavedAuthorization wasSaved = await _user.PostUser(user);
            return wasSaved.CouldBeSaved ?
                CreatedAtAction(nameof(GetUser), new { id = user.Id }, user) : 
                BadRequest(new { error = "Identification number already register" });
            //If I am not mistaken the first parameter in CreatedAtAction returns the url with the action method to get the resource recently created
        }
        catch (DbUpdateException ex)
        {
            return ValidationProblem($"{ex.GetType()}",ex.Message, 400, "Invalid ID");
        }
        catch(Exception ex)
        {
            return ValidationProblem("Unexpected error ocurred, contact IT deparment", ex.Message, 500, "Unexpected error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> PutUser([FromBody] PutUserDTO user)
    {
        try
        {
            SavedAuthorization wasUpdated = await _user.PutUser(user);
            return wasUpdated.CouldBeSaved ? NoContent() : BadRequest(new { error = "The ID user doesn't exist, please check if you are sendind the correct ID" });
        }
        catch (Exception ex)
        {
            return ValidationProblem("Unexpected error ocurred, contact IT deparment", ex.Message, 500, "Unexpected error");
        }
    }
}