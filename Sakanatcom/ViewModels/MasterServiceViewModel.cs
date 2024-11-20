using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class MasterServiceViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterServiceId { get; set; }
        [Required(ErrorMessage = "Title Is Required")]
        [DisplayName("Title")]
        public string MasterServiceTitle { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterServiceDesc { get; set; }
        [Required(ErrorMessage = "Icon Is Required")]
        [DisplayName("Icon")]
        public string MasterServiceIcon { get; set; }
    }
}
