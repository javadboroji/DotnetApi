using DotnetApi.Data;
using DotnetApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) 
        { 
            _context = context; 
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u=>u.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task AddAsync(User user) 
        { 
            await _context.Users.AddAsync(user);
        }
        public async Task SaveChangesAsync()
        { 
            await _context.SaveChangesAsync(); 
        }
    }
}
