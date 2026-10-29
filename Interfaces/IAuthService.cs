
using DotnetApi.Dtos;

namespace DotnetApi.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);

        Task<string> LoginAsync(LoginDto dto);
        
    }
}
