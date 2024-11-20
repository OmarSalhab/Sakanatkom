using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sakanatcom.ViewModels
{
    public class MasterMenuViewModel : BaseEntity
    {
        [DisplayName("Id")]
        public int MasterMenuId { get; set; }
        [MaxLength(250)]
        [MinLength(2)]
        [Required(ErrorMessage = "Name Is Required")]
        [DisplayName("Name")]
        public string MasterMenuName { get; set; }
        [Required(ErrorMessage = "Url Is Required")]
        [DisplayName("Url")]
        public string MasterMenuUrl { get; set; }
    }
}
