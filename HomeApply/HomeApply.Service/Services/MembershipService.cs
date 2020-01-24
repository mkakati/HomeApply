using HomeApply.Common.Cryptography;
using HomeApply.Entities;
using HomeApply.Entities.DataModels;
using HomeApply.Entities.DbContext;
using HomeApply.Service.Interfaces;

using HomeApply.ViewModels.Account;
using HomeApply.ViewModels.ApiResponse;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static HomeApply.Common.Enums;

namespace HomeApply.Service.Services
{
    public class MembershipService : IMembershipInterface
    {
        private readonly IUnitOfWork _uow;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MembershipService(IUnitOfWork uow, UserManager<ApplicationUser> userManager)
        {
            _uow = uow;
            _userManager = userManager;

        }
        public async Task<ApiResponse> RegisterUser(RegistrationViewModel register)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var result = await _uow.UserRepository.FindAsync(x => x.Email == register.Email || x.MobileNo == register.MobileNo & x.IsDeleted == false);
                if (result != null)
                {
                    response.Status = (int)Number.Zero;
                    response.Message = Constants.Exist;
                    response.ResponseData = null;
                    return response;
                }
                else
                {
                    var newUser = new ApplicationUser
                    {
                        UserName = register.Email,
                        Email = register.Email,
                        ProviderId = 1,
                        ProviderType = "SK",

                    };
                    IdentityResult userCreationResult = null;
                    try
                    {
                        userCreationResult = await _userManager.CreateAsync(newUser);

                    }
                    catch (System.Data.SqlClient.SqlException)
                    {

                        response.StatusCode = (int)Number.Zero;
                        response.Message = Constants.Error;
                        response.ResponseData = null;
                        return response;
                    }
                    if (!userCreationResult.Succeeded)
                    {

                        response.StatusCode = (int)Number.Zero;
                        response.Message = Constants.Error;
                        response.ResponseData = null;

                        return response;

                    }
                    Users user = new Users();
                    user.UserId = Guid.NewGuid();
                    user.FirstName = register.FirstName;
                    user.LastName = register.LastName;
                    user.Email = register.Email;
                    user.MobileNo = register.MobileNo;
                    user.DOB = register.DOB;
                    user.Qualification = register.Qualification;
                    user.Specification = register.Specification;
                    user.State = register.State;
                    user.District = register.District;
                    user.AddressLine = register.AddressLine;
                    user.Pin = register.Pin;
                    user.CreatedBy = user.UserId;
                    user.CreatedDate = System.DateTime.UtcNow;
                    user.IsActive = true;
                    user.IsDeleted = false;
                    user.IsVerified = false;
                    user.ModifiedBy = user.UserId;

                    var finalresult = await _uow.UserRepository.AddAsyn(user);

                    response.Status = (int)Number.One;
                    response.Message = Constants.Success;
                    response.ResponseData = finalresult;

                }
               
            }
            catch (Exception ex)
            {
                response.Status = (int)Number.Zero;
                response.Message = ex.Message;
                response.ResponseData = null;
                
            }
            return response;
        }

    }
}
