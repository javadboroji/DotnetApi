using DotnetApi.Common.Responses;
using DotnetApi.Dtos;
using DotnetApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApi.Controllers

{
    [ApiController]

    [Route("api/[controller]")]
    public class RoleController: ControllerBase
    {
        private readonly IRoleService _roleService;
           public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task< IActionResult >CreateRole(CreateRoleDTo dto)
        {
           var result=await _roleService.CreateRoleAsync(dto);
            return Ok(new ApiResponse<object>(true, "CreateRole successfully", result));

        }
    }
}
