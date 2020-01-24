using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeApply.Entities.DataModels
{
    [Table("Users", Schema = "SK")]
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]

        public Guid UserId { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string Email { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string MobileNo { get; set; }
        public DateTime DOB { get; set; }
        public string Qualification { get; set; }
        public string Specification { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public string InterestField { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
