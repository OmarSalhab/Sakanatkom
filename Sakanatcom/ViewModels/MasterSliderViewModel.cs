using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class MasterSliderViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterSliderId { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string MasterSliderTitle { get; set; }
        [Required(ErrorMessage = "Breif Is Required")]
        [DisplayName("Breif")]
        public string MasterSliderBreif { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterSliderDesc { get; set; }
        [Required(ErrorMessage = "Url Is Required")]
        [DisplayName("Url")]
        public string MasterSliderUrl { get; set; }
        [DisplayName("Image")]
        public string MasterSliderImageUrl { get; set; }
        [DisplayName("Upload Image")]
        public IFormFile UploadImage { get; set; }
    }
}
