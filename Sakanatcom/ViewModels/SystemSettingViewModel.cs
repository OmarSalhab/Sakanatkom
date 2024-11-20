using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class SystemSettingViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int SystemSettingId { get; set; }
        [DisplayName("Logo")]
        public string SystemSettingLogoImageUrl { get; set; }
        [DisplayName("Logo 2")]
        public string SystemSettingLogoImageUrl2 { get; set; }
        [Required(ErrorMessage = "Copyright Is Required")]
        [DisplayName("Copyright")]
        public string SystemSettingCopyright { get; set; }
        [Required(ErrorMessage = "Note Title Is Required")]
        [DisplayName("Note Title")]
        public string SystemSettingWelcomeNoteTitle { get; set; }
        [Required(ErrorMessage = "Note Breif Is Required")]
        [DisplayName("Note Breif")]
        public string SystemSettingWelcomeNoteBreif { get; set; }
        [Required(ErrorMessage = "Note Description Is Required")]
        [DisplayName("Note Description")]
        public string SystemSettingWelcomeNoteDesc { get; set; }
        [Required(ErrorMessage = "Note Url Is Required")]
        [DisplayName("Note Url")]
        public string SystemSettingWelcomeNoteUrl { get; set; }
        [DisplayName("Image")]
        public string SystemSettingWelcomeNoteImageUrl { get; set; }
        [DisplayName("Image 2")]
        public string SystemSettingWelcomeNoteImageUrl2 { get; set; }
        [DisplayName("Image 3")]
        public string SystemSettingWelcomeNoteImageUrl3 { get; set; }
        [DisplayName("Image 4")]
        public string SystemSettingWelcomeNoteImageUrl4 { get; set; }
        [DisplayName("Map Location")]
        public string SystemSettingMapLocation { get; set; }
        [DisplayName("Upload Logo")]
        public IFormFile UploadLogo { get; set; }
        [DisplayName("Upload Logo 2")]
        public IFormFile UploadLogo2 { get; set; }
        [DisplayName("Upload Image")]
        public IFormFile UploadImage { get; set; }
        [DisplayName("Upload Image 2")]
        public IFormFile UploadImage2 { get; set; }
        [DisplayName("Upload Image 3")]
        public IFormFile UploadImage3 { get; set; }
        [DisplayName("Upload Image 4")]
        public IFormFile UploadImage4 { get; set; }
    }
}
