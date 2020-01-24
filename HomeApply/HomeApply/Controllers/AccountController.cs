using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApply.Service.Interfaces;
using HomeApply.Service.Services;
using HomeApply.ViewModels.Account;
using HomeApply.ViewModels.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static HomeApply.Common.Enums;

namespace HomeApply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMembershipInterface _membershipService;

        public AccountController(IMembershipInterface membershipInterface)
        {
            _membershipService = membershipInterface;
        }




        [AllowAnonymous]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] RegistrationViewModel model)
        {
            var result = await _membershipService.RegisterUser(model);
            return getCommonStatus(result);
        }

        private IActionResult getCommonStatus(ApiResponse response)
        {
            if (response.Status == (int)Number.One)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}