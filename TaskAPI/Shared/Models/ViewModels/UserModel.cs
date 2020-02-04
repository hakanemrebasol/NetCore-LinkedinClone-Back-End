using Shared.Entity;
using Shared.Entity.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Shared.Models.ViewModels {
    public class UserModel {
        //[JsonIgnore]
        public string Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }

       // [JsonIgnore]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }

       // [JsonIgnore]
        [DataType (DataType.Password)]
        [Display (Name = "Password")]
        public string Password { get; set; }

       //[JsonIgnore]
        public Boolean EmailConfirmed { get; set; }

       // [JsonIgnore]
        public Boolean PhoneNumberConfirmed { get; set; }
        public string about { get; set; }
        public string headline { get; set; }
        public string website { get; set; }
        public DateTime birthDate { get; set; }
        public string address { get; set; }
        public string ZIPCode { get; set; }
        public Province Province { get; set; }
        public District District { get; set; }
        public Industry Industry { get; set; }
    }

    public class ChangePasswordModel {
        [Required]
        [DataType (DataType.Password)]
        [Display (Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Display (Name = "NewPassword")]
        public string NewPassword { get; set; }
    }

    public class LoginModel {
        [Required (ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        [Display (Name = "E-Mail")]
        public String Username { get; set; }

        [Required (ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType (DataType.Password)]
        [Display (Name = "Şifre")]
        public String Password { get; set; }
    }

    public class OtherUserModel {
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
    }

}