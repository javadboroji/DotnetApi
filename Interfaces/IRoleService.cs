using DotnetApi.Dtos;
using DotnetApi.Entities;

namespace DotnetApi.Interfaces
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(CreateRoleDTo dto);
    }
}
