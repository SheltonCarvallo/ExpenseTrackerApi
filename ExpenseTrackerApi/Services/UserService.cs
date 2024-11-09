using DataLayer;
using ExpenseTrackerApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTOs;
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

        IQueryable<User> query = _context.Users
            .Include(user => user.Balances)
            .Where(user => user.StatusId == 1)
            .OrderByDescending(user => user.UserRegisterDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsSplitQuery();
        return await query.ToListAsync();

    }

    public async Task<User> GetUser(Guid userID)
    {
        User? user = await _context.Users.Include(x => x.Balances).SingleOrDefaultAsync(u => u.Id == userID);
        return user ?? new User() { };
    }

    public async Task<SavedAuthorization> PostUser(User user)
    {

        bool existUser = await _context.Users.AnyAsync(u => u.IdentificationID == user.IdentificationID);
        if (existUser)
        {
            return (new SavedAuthorization { CouldBeSaved = false });
        }
        user.UserRegisterDate = DateTime.Now;
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return new SavedAuthorization { CouldBeSaved = true };
    }

    public async Task<SavedAuthorization> PutUser(PutUserDTO user)
    {
        User? userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.IdentificationID.Equals(user.IdentificationID));
        //bool existUser = await _context.Users.AnyAsync(u => u.Id == user.Id);
        if (userToUpdate is null)
        {
            return new SavedAuthorization { CouldBeSaved = false };
        }
        else
        {
            /*userToUpdate.IdentificationID = user.IdentificationID;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Username = user.Username; 
            userToUpdate.Email = user.Email;
            userToUpdate.UserUpdateDate = DateTime.Now;*/
            //_context.Entry(user).State = EntityState.Modified;
            _context.Entry(userToUpdate).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return new SavedAuthorization { CouldBeSaved = true };
        }   
    }
}
