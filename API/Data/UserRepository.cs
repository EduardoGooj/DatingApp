namespace API.Data;

using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context;
    // public UserRepository(DataContext context)=>_context=context;

    public async Task<IEnumerable<AppUser>> GetAllAsync() => await context.Users.ToListAsync();
    public async Task<AppUser?> GetByIdAsync(int d) => await context.Users.FindAsync();
    public async Task<AppUser?> GetByUsernameAsync(string username) => await context.Users.SingleOrDefaultAsync(x => x.UserName == username);
    public async Task<bool> SaveAllAsync() => await context.SaveChangesAsync() > 0;
    public void Update(AppUser user) => throw new NotImplementedException();
}