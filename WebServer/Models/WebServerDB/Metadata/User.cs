using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//避免下次由資料庫產生Model把屬性蓋掉
//所以用Partial class
namespace WebServer.Models.WebServerDB
{

    [ModelMetadataType(typeof(UserMetadata))]
    public partial class User
    {
        [NotMapped]
        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = "請再次輸入密碼")]
        [Compare("Password", ErrorMessage = "密碼不相符")]
        public string? ConfirmPassword { get; set; }
    }
    public partial class UserMetadata
    {
        [Display(Name = "ID")]
        public string? ID { get; set; }

        [Display(Name = "Account")]
        [Required(ErrorMessage = "AccountRequired")]
        //帳號字元限3~20碼，英文和數字(中間可包含一個【_】或【.】)。
        [RegularExpression(@"^(?=[^\._]+[\._]?[^\._]+$)[\w\.]{3,20}$", ErrorMessage = "帳號字元限3~20碼，英文和數字(中間可包含一個【_】或【.】)。")]
        public string? Account { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "PasswordRequired")]
        //密碼限4~20個字
        [RegularExpression(@"^.{4,20}$", ErrorMessage = "密碼限4~20個字")]
        public string? Password { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "無效的電子信箱格式")]
        [MaxLength(50)]
        public string? Email { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "NameRequired")]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Display(Name = "Birthday")]
        [Required(ErrorMessage = "BirthdayRequired")]
        public string? Birthday { get; set; }

    }
}