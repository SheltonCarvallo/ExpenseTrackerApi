using ModelLayer.Models;

namespace ExpenseTrackerApi.Interfaces

{
    public interface IExpense
    {
        public Task<ICollection<Expense>> GetExpensesUser(string userNumIdentification);
        public Task<Expense> GetExpense(Guid expenseId);
        public Task<ExpenseAuthorization> PostExpense(Expense expense);
        

        //PutExpense
        //DeleteExpense
        //GetDeleteExpenses
        //GetExpenses in a range of dates
    }
}
