using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sakanatcom.Models
{
    public partial class SystemSetting : BaseEntity
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
    }
}
