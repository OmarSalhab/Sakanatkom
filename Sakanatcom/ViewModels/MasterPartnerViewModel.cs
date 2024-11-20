using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class MasterPartnerViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterPartnerId { get; set; }
        [Required(ErrorMessage = "Your Name Name Is Required")]
        [DisplayName("Name")]
        public string MasterPartnerName { get; set; }
        [DisplayName("Profile picture")]
        public string MasterPartnerLogoImageUrl { get; set; }
        [Required(ErrorMessage = "Discription Required")]
        [DisplayName("Discription")]
        public string MasterPartnerWebsiteUrl { get; set; }
        [DisplayName("Upload Logo")]
        public IFormFile UploadLogo { get; set; }
    }
}
