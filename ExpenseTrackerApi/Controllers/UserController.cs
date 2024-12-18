using ExpenseTrackerApi.Authentication.Models;
using ExpenseTrackerApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTOs;
using ModelLayer.Models;

namespace ExpenseTrackerApi.Controllers;

[Authorize (Roles = AppRoles.Admin)]
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
            return ValidationProblem("Unexpected error occurred, contact IT department", ex.Message, 500,
                "Unexpected error");
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
            SavedAuthorization savedAuthorization = await _user.PostUser(user);
            return savedAuthorization.CouldBeSaved
                ? CreatedAtAction(nameof(GetUser), new { id = user.Id }, user)
                : BadRequest(new { error = "Identification number already register" });
            //If I am not mistaken the first parameter in CreatedAtAction returns the url with the action method to get the resource recently created
        }
        catch (DbUpdateException ex)
        {
            return ValidationProblem($"{ex.GetType()}", ex.Message, 400, "There is an invalid ID");
        }
        catch (Exception ex)
        {
            return ValidationProblem("Unexpected error occurred, contact IT department", ex.Message, 500,
                "Unexpected error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> PutUser([FromBody] PutUserDto user)
    {
        try
        {
            SavedAuthorization savedAuthorization = await _user.PutUser(user);
            return savedAuthorization.CouldBeSaved
                ? NoContent()
                : BadRequest(
                    new { error = "The username isn't registered, please check if you are sending the correct username" });
        }
        catch (Exception ex)
        {
            return ValidationProblem("Unexpected error occurred, contact IT department", ex.Message, 500,
                "Unexpected error");
        }
    }
}