using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sakanatcom.Models
{
    public class MasterAbout : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterAboutId { get; set; }
        [MaxLength(250)]
        [MinLength(2)]
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string MasterAboutTitle { get; set; }
        [MaxLength(250)]
        [MinLength(2)]
        [Required(ErrorMessage = "Brief Is Required")]
        [DisplayName("Brief")]
        public string MasterAboutBrief { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterAboutDesc { get; set; }
        [Required(ErrorMessage = "Url Is Required")]
        [DisplayName("Url")]
        public string MasterAboutUrl { get; set; }
        [DisplayName("Image")]
        public string MasterAboutImageUrl { get; set; }
    }
}
