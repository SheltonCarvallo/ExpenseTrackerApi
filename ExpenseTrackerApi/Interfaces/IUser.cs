using ModelLayer.Models;

namespace ExpenseTrackerApi.Interfaces;

public interface IUser
{
    public Task<IEnumerable<User>> GetUsers();
    public Task<User> GetUser(Guid userID);
    public Task PostUser(User user);
}