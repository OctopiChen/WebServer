using System.ComponentModel.DataAnnotations;

namespace WebServer.Models
{
    public class UserIndexViewModel
    {
        public string? ID { get; set; }
        [SortingType(SortingTypeEnum.Disabled)]
        [Display(Name = "Account")]
        public string? Account { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Birthday")]
        public string? Birthday { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
    }
}