using DataLayer;
using ExpenseTrackerApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;

namespace ExpenseTrackerApi.Services;

public class UserService : IUser
{
    private readonly ExpenseTrackerDbContext _context;

    public UserService(ExpenseTrackerDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        IEnumerable<User> users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUser(Guid userID)
    {
        User? user = await _context.Users.FindAsync(userID);
        return user ?? new User() { };
    }

    public async Task PostUser(User user)
    {
        bool existUser = await _context.Users.AnyAsync(u => u.Id == user.Id);
        if (existUser)
        {
            return;
        }
        user.UserRegisterDate = DateTime.Now;
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}