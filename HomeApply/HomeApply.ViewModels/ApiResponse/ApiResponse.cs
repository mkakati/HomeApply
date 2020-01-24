using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApply.ViewModels.ApiResponse
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Status = 0;
            Message = Constants.Error;
        }
        public string Message { get; set; }
        public object ResponseData { get; set; }
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public int Total { get; set; }
    }

    public class Constants
    {
        public const string Error = "Some internal error occurred";
        public const string Success = "Data saved successfully";
        public const string Delete = "Data deleted successfully";
        public const string Warning = "Data is not in proper format";
        public const string Retreived = "Data retrieved successfully";
        public const string NotFound = "Data not found";
        public const string Empty = "Data are empty";
        public const string InvalidPassword = "Invalid Password";
        public const string InvalidEmail = "Invalid email id";
        public const string ResetPassword = "Reset password";
        public const string NotActive = "Please follow link in email to activate account";
        public const string RsaKeyValue = "RSAKeyValue";
        public const string Modulus = "Modulus";
        public const string Exponent = "Exponent";
        public const string P = "P";
        public const string Q = "Q";
        public const string DP = "DP";
        public const string DQ = "DQ";
        public const string InverseQ = "InverseQ";
        public const string D = "D";
        public const string InvalidXMLRSAkey = "Invalid XML RSA key";
        public const string Exist = "User already exist";
    }
}
