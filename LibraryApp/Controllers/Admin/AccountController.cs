using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace LibraryApp.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _accountService.GetUsersAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUsername([FromQuery] string username)
        {
            return Ok(await _accountService.GetUserByUsernameAsync(username));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles()
        {
            await _accountService.CreateRoleAsync();

            return Ok();
        }

    }
}

