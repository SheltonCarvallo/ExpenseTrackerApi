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

    public async Task<IEnumerable<User>> GetUsers(int page = 1, int pageSize = 5)
    {
        try
        {
            IQueryable<User> query = _context.Users
                .Include(user => user.Balances)
                .Where(user => user.StatusId == 1)
                .OrderByDescending(user => user.UserRegisterDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsSplitQuery();
            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sorry there have been an error{ex.Message}"); //TODO tha try-catch has to be corrected
            
        }

        return new List<User>();
    }

    public async Task<User> GetUser(Guid userID)
    {
        User? user = await _context.Users.FindAsync(userID);
        return user ?? new User() { };
    }

    public async Task<SavedAuthorization> PostUser(User user)
    {
    
            bool existUser = await _context.Users.AnyAsync(u => u.IdentificationID == user.IdentificationID);
            if (existUser)
            {
                return (new SavedAuthorization { CouldBeSaved = false});
            }
            user.UserRegisterDate = DateTime.Now;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new SavedAuthorization{CouldBeSaved = true};
        /*catch(DbUpdateException)
        {
            Console.WriteLine("You are entering a ID status which not exists in the database");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.GetType()} says There have been an erro: {ex.Message}");
        }*/
    }
}