using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApply.ViewModels.Account
{
    public class RegistrationViewModel
    {
      
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
      
        public string Email { get; set; }
       
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string Qualification { get; set; }
        public string Specification { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public string InterestField { get; set; }
    }
}
