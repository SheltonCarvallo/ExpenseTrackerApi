using DataLayer;
using ExpenseTrackerApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTOs;
using ModelLayer.Models;

namespace ExpenseTrackerApi.Services;

public class ExpenseService : IExpense
{
    private readonly ExpenseTrackerDbContext _context;
    public ExpenseService(ExpenseTrackerDbContext context) 
    {
        this._context = context;
    }
    public async Task<Expense> GetExpense(Guid expenseId)
    {
            Expense? expense = await _context.Expenses.FindAsync(expenseId);
            return expense is not null ? expense : new Expense { };
    }

    public async Task<IEnumerable<Expense>> GetExpensesUser(Guid userId) //For now I want to show the 5 last expenses of a user
    {
        IQueryable<Expense> query = _context.Expenses.Where(e => e.UserId == userId)
                                                      .OrderBy(e => e.ExpenseRegisterDate)
                                                      .Take(5);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<ExpenseDTO>> GetExpensesFromSpecificDateToNow(Guid userId, DateTime date) //I want to show the expense of a specific user and a range of dates
    {
        DateTime currentDate = DateTime.Now;

        IQueryable<ExpenseDTO> query =  from ex in _context.Expenses
                                              join u in _context.Users on ex.UserId equals u.Id
                                              join pm in _context.PaymentMethods on ex.PaymentMethodId equals pm.Id
                                              join b in _context.Banks on ex.BankId equals b.Id
                                              join c in _context.Categories on ex.CategoryId equals c.Id
                                              where ex.UserId == userId && ex.ExpenseRegisterDate >= date && ex.ExpenseRegisterDate <= currentDate
                                              select new ExpenseDTO
                                              {
                                                  ExpenseId = ex.Id,
                                                  UserName = u.Username,
                                                  Amount = ex.Amount,
                                                  Bank = b.BankName,
                                                  Category = c.CategoryName,
                                                  PaymentMethod = pm.PaymentMethodName,
                                                  RegisterDate = ex.ExpenseRegisterDate
                                              };

        return await query.ToListAsync();

    }

    public async Task<ExpenseAuthorization> PostExpense(Expense expense)
    {
        Balance? balanceIsRegistered = await _context.Balances.SingleOrDefaultAsync( e => e.UserId == expense.UserId && e.BankId == expense.BankId);
        
        if (balanceIsRegistered is null)
        {
            return ExpenseAuthorization.NoAccount;
        }
        else
        {
            bool enoughMoney = balanceIsRegistered.Amount > expense.Amount;
            if (!enoughMoney) 
            {
                return ExpenseAuthorization.NotEnoughMoney;
            }
            //Updating the balance
            decimal resultTransaction = balanceIsRegistered.Amount - expense.Amount;
            balanceIsRegistered.Amount = resultTransaction;
            balanceIsRegistered.BalanceUpdateDate = DateTime.Now;
            expense.ExpenseRegisterDate = DateTime.Now;
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return ExpenseAuthorization.Authorized;
        }
    }
}
