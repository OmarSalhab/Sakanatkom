using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Sakanatcom.ViewModels
{
    public class MasterContactUsInformationViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterContactUsInformationId { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [DisplayName("Description")]
        public string MasterContactUsInformationDesc { get; set; }
        [Required(ErrorMessage = "Icon Is Required")]
        [DisplayName("Icon")]
        public string MasterContactUsInformationIcon { get; set; }
        [Required(ErrorMessage = "Redirect Is Required")]
        [DisplayName("Redirect")]
        public string MasterContactUsInformationRedirect { get; set; }
    }
}
