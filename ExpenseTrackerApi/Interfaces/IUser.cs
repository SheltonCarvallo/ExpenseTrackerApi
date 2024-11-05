using ModelLayer.Models;

namespace ExpenseTrackerApi.Interfaces;

public interface IUser
{
    public Task<IEnumerable<User>> GetUsers(int page = 1, int pageSize = 5);
    public Task<User> GetUser(Guid userID);
    public Task<SavedAuthorization> PostUser(User user);
}