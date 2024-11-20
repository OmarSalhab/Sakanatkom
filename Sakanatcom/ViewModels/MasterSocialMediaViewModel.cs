using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class MasterSocialMediaViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterSocialMediaId { get; set; }
        [Required(ErrorMessage = "Icon Is Required")]
        [DisplayName("Icon")]
        public string MasterSocialMediaIcon { get; set; }
        [Required(ErrorMessage = "Url Is Required")]
        [DisplayName("Url")]
        public string MasterSocialMediaUrl { get; set; }
    }
}
