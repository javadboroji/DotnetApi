using BCrypt.Net;
using DotnetApi.Data;
using DotnetApi.Dtos;
using DotnetApi.Entities;
using DotnetApi.Interfaces;
using DotnetApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Services
{
    public class AuthService : IAuthService
    {
       
         private readonly IUserRepository _userRepository;

            private readonly AppDbContext _context;

        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository ,IJwtService JwtService, AppDbContext context)
        {
            _userRepository = userRepository;
            _jwtService = JwtService;
            _context = context;
        }
        public async Task RegisterAsync(RegisterDto dto)

        {
            //check userName 

          var existUser=  await _userRepository.GetByUsernameAsync(dto.Username);
            if(existUser != null)
            {
                throw new Exception("usename already exists");
                     
            }
            //check email
            var existEmail =await _userRepository.GetByEmailAsync(dto.Email);
            if (existEmail != null)
            {
                throw new Exception("email already exists");

            }
            //hash password
            var passwordHash=BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var defaultUserRole = await _context.Roles
             .FirstOrDefaultAsync(r => r.Name == "User" && r.IsActive);

            if (defaultUserRole == null)
            {
                throw new Exception("Default User role not found");
            }

            //create user
            var user = new User
            {
                Email = dto.Email,
                FailedLoginAttempts = 0,
                IsActive = true,
                PasswordHash = passwordHash,
                Username = dto.Username,
                RoleId = defaultUserRole.Id,
                CreatedAt = DateTime.UtcNow,


            };
            //save in db
            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            //find user
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null) {

                throw new Exception("invalid Email or  password");
            }
            
            var validPassword=BCrypt.Net.BCrypt.Verify(dto.Password ,user.PasswordHash);

            if (!validPassword) throw new Exception("Invalid username or password");
            var token = _jwtService.GenerateToken(user.Id ,user.Username,user.Role.Name);

            return token;
        }
    }
}
