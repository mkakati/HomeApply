
using HomeApply.ViewModels.Account;
using HomeApply.ViewModels.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApply.Service.Interfaces
{
    public interface IMembershipInterface
    {
        Task<ApiResponse> RegisterUser(RegistrationViewModel register);

    }
}
