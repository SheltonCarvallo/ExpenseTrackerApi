using DataLayer;
using ExpenseTrackerApi.Interfaces;
using Microsoft.EntityFrameworkCore;
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

    public Task<ICollection<Expense>> GetExpensesUser(string userNumIdentification) //For now I want to show the 5 last expenses of a user
    {
        throw new NotImplementedException();
    }

    public async Task<ExpenseAuthorization> PostExpense(Expense expense)
    {
        //bool hasUserBankAccount = await _context.Balances.AnyAsync(e => e.UserId == expense.UserId && e.BankId == expense.BankId);
        Balance? currentBalance = await _context.Balances.SingleOrDefaultAsync( e => e.UserId == expense.UserId && e.BankId == expense.BankId);
        
        if (currentBalance is null)
        {
            return ExpenseAuthorization.NoAccount;
        }
        else
        {
            bool enoughMoney = currentBalance.Amount > expense.Amount;
            if (!enoughMoney) 
            {
                return ExpenseAuthorization.NotEnoughMoney;
            }
            //Updating the balance
            decimal resultTransaction = currentBalance.Amount - expense.Amount;
            currentBalance.Amount = resultTransaction;
            currentBalance.BalanceUpdateDate = DateTime.Now;
            //I have to do some validation here like the user have enough money in its balance
            expense.ExpenseRegisterDate = DateTime.Now;
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return ExpenseAuthorization.Authorized;
        }
    }
}
