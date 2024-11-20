using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class MasterOfferViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterOfferId { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string MasterOfferTitle { get; set; }
        [Required(ErrorMessage = "Breif Is Required")]
        [DisplayName("Breif")]
        public string MasterOfferBreif { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterOfferDesc { get; set; }
        [DisplayName("Image")]
        public string MasterOfferImageUrl { get; set; }
        [DisplayName("Upload Image")]
        public IFormFile UploadImage { get; set; }
    }
}
