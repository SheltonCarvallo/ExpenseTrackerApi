using ExpenseTrackerApi.Authentication.Models;
using ModelLayer.Models;
using ModelLayer.Models.FakeModels;
using ExpenseTrackerApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTOs;

namespace ExpenseTrackerApi.Controllers;


[Authorize (Roles = AppRoles.User)]
[ApiController]
[Route("api/[Controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IExpense _expense;
    
    public ExpenseController(IExpense expense)
    {
        this._expense = expense;
    }

    [HttpGet("{expenseId:guid}")]  //Adding constraint
    public async Task<ActionResult<Expense>> GetExpense(Guid expenseId)
    {
        try
        {
            Expense expense = await _expense.GetExpense(expenseId);
            return expense.Id != Guid.Empty ? Ok(expense) : NotFound();
        }
        catch (Exception ex)
        {

            return ValidationProblem("Unexpected error occurred, contact IT department", ex.Message, 500, "Unexpected error");
        }
    }

   [HttpGet("user/{UserId:guid}")] //Adding constraint
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpensesUser(Guid userId)
    {
        try
        {
            IEnumerable<Expense> expensesUser = await _expense.GetExpensesUser(userId);


            return expensesUser.Any() ? Ok(expensesUser) :NoContent();
        }
        catch (Exception ex)
        {

            return ValidationProblem("Unexpected error occurred, contact IT department", ex.Message, 500, "Unexpected error");
        }
    }

    [HttpGet]
    [Route("user/GetExpensesFromADateUpToNow")]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> GetExpensesFromSpecificDateToNow(Guid userId, DateTime date)
    {
        try
        {
            IEnumerable<ExpenseDTO> expensesByDate = await _expense.GetExpensesFromSpecificDateToNow(userId, date);

            return expensesByDate.Any() ? Ok(expensesByDate) : NoContent();
        }
        catch (Exception ex)
        {

            return ValidationProblem("Unexpected error occurred, contact IT department", ex.Message, 500, "Unexpected error");
        }
    }

    [HttpGet]
    [Route("user/GetExpensesBetweenDates")]
    public async Task<ActionResult<IEnumerable<ExpenseBetweenDatesSP>>> GetExpenseBetweenDates(Guid userId, DateTime startDate, DateTime endDate)
    {
        try
        {
            IEnumerable<ExpenseBetweenDatesSP> expenses = await _expense.GetExpenseBetweenDates(userId, startDate, endDate);
            return expenses.Any() ? Ok(expenses) : NoContent(); 

        }
        catch (Exception ex)
        {


            return ValidationProblem("Unexpected error ocurred, contact IT deparment", ex.Message, 500, "Unexpected error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostExpense([FromBody] Expense expense)
    {
        try
        {
            ExpenseAuthorization expenseAuthorization = await _expense.PostExpense(expense);

            if(expenseAuthorization == ExpenseAuthorization.NoAccount)
            {
                return BadRequest(new { code = 400, problem = "It seems like you don't have a bank account or the BankId you entered doesn't exist" });
            }
            else if (expenseAuthorization == ExpenseAuthorization.NotEnoughMoney)
            {
                return BadRequest(new { code = 400, problem = "There isn't enough balance in your account to pay the expense" });
            }
            else 
            {
                return CreatedAtAction(nameof(GetExpense), new { expenseId = expense.Id} ,expense);
            }
           
        }
        catch (DbUpdateException ex)
        {
            return ValidationProblem($"{ex.GetType()}", ex.Message, 400, "There is an invalid ID");
        }
        catch (Exception ex)
        {
            return ValidationProblem("Unexpected error occurred, contact IT department", ex.Message, 500, "Unexpected error");
        }
    }

}
