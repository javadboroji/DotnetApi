using DotnetApi.Data;
using DotnetApi.Dtos;
using DotnetApi.Entities;
using DotnetApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Services
{
    public class RoleService :IRoleService
    {
        private readonly IRoleService _roleService;

        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

       public async Task<Role> CreateRoleAsync(CreateRoleDTo dto)
        {
            var role = new Role
            {
                Name = dto.Name,
            };
            _context.Add<Role>(role);
          await  _context.SaveChangesAsync();
            return role;
        }
    }
}
