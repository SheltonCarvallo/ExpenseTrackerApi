using ModelLayer.DTOs;
using ModelLayer.Models;

namespace ExpenseTrackerApi.Interfaces

{
    public interface IExpense
    {
        public Task<IEnumerable<Expense>> GetExpensesUser(Guid userId);
        public Task<Expense> GetExpense(Guid expenseId);
        public Task<IEnumerable<ExpenseDTO>> GetExpensesFromSpecificDateToNow (Guid userId, DateTime date);
        public Task<ExpenseAuthorization> PostExpense(Expense expense);


        
        //I need to create a method to get the expense in a range of dates and if the user don't send any parameter I want to have default dates
        //PutExpense
        //If I want to update a a expense I have to make sure if the amount to expense is to Decrese on Increse de balance
        //DeleteExpense
        //GetDeleteExpenses
        //GetExpenses in a range of dates
    }
}
